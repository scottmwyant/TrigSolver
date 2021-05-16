import { DataPoint } from './DataPoint';
import { Profile } from './TrigSolver';
import { trig } from './trig';
import { transform } from './utilities';

// export class Rule {

//     constructor(private ruleData: RuleData) { }

//     get name() { return this.ruleData.name }

//     test(given: any): RuleTestResult {
//         const rtn = this.ruleData.fn(given);
//         rtn.name = this.ruleData.name
//         return rtn;
//     }
// }

// export interface RuleData {
//     name: string,
//     scope: string[]
//     fn: (given: Dimension[]) => RuleTestResult
// }

export interface RuleResult {
    name: string
    text: string
    satisfied: boolean
}


export interface Rule {
    name: string,
    scope?: string[],
    fn: (given: any) => RuleResult
}

export function getRules(profile: Profile): Rule[] {

    const rules: Rule[] = [
        {
            name: "three-inputs",
            fn(given: DataPoint[]) {
                const satisfied = Array.isArray(given) && given.length == 3;
                const text = satisfied ? '' : `Three inputs must be given, you've provided ${profile.count.inputs}.`;
                return { name: this.name, satisfied, text };

            }
        },
        {
            name: "one-length",
            fn(given: DataPoint[]) {
                const satisfied = profile.count.lengths > 0;
                const text = satisfied ? '' : 'At least one of the given values must be a length.';
                return { name: this.name, satisfied, text };
            }
        }
    ]

    const ruleRepository = [

        // Length of longest side must be less than sum of the two other sides.
        {
            name: "sum-of-sides",
            scope: ['side-side-side'],
            fn: function (given: DataPoint[]) {
                const totalLength = given[0].value + given[1].value + given[2].value;
                const max = Math.max(...(given.map(input => input.value)));
                const delta = totalLength - (2 * max);
                const satisfied = delta >= 0
                const text = satisfied ? '' : `Longest side is too long by ${delta}`
                return { name: this.name, satisfied, text }
            }
        },

        // Sum of two angles given must be less than 180deg.
        {
            name: 'sum-of-anlges',
            scope: ['pair-and-angle', 'side-angle-angle'],
            fn: function (given: DataPoint[]) {
                const angles = transform.filterByFeature(given, 'angle');
                const satisfied = (angles[0].value + angles[1].value) < Math.PI;
                const text = satisfied ? '' : 'Sum of angles is greater than pi!';
                return { name: this.name, satisfied, text }
            }
        },

        // Check if the complement side is long enough to intersect the leg of the known pair.
        // Assume the one angle is 90, which will produce the shortest possible leg.  Then compare
        // the computed minimum length to the given length.
        {
            name: 'long-enough-side',
            scope: ['pair-and-side'],
            fn: function (given: DataPoint[]) {
                const minLenght = trig.lawOfSines({ "length": transform.getOther(given).value, "angle": 90 * Math.PI / 180 }, transform.filterByFeature(given, 'angle')[0]).value;
                const satisfied = (transform.getOther(given).value >= minLenght);
                const text = satisfied ? '' : 'The complement side is too short.  It needs to be at least ' + minLenght;
                return { name: this.name, satisfied, text }
            }
        }

    ];

    // Filtrer the repository of rules down to ones that apply to 
    // this specific set of inputs, and return an array of Rules
    return rules.concat(ruleRepository.filter(item => (item.scope.indexOf(profile.caseName) > -1)));

}