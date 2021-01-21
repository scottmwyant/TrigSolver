// export interface Dimension {
//     label: string
//     feature?: string
//     value?: number
//     id?: string
// }

export class DataPoint {

    id: string
    feature: string
    label: string
    value: number

    constructor(id: string)
    constructor(id: string, value: number)
    constructor(label: string, feature: string, value: number)
    constructor(input: { id: string, value: number })
    constructor(id: any) {

        function parse(id: string) {
            const feature = id.substr(0, id.length - 1).toLowerCase();
            const label = id.substr(id.length - 1).toLowerCase();
            return {
                id: feature + label.toUpperCase(),
                feature,
                label
            }
        }

        // console.dir(arguments);

        if (arguments.length < 3) {
            if (typeof arguments[0] == 'string') {
                const obj = parse(id)
                this.id = obj.feature + obj.label.toUpperCase()
                this.feature = obj.feature
                this.label = obj.label
                this.value = arguments.length == 2 ? arguments[1] : 0;
            }
            else {
                const obj = parse(arguments[0].id);
                this.feature = obj.feature
                this.label = obj.label
                this.id = obj.id
                this.value = arguments[0].value;
            }
        }
        else {
            this.label = arguments[0].toLowerCase();
            this.feature = arguments[1].toLowerCase();
            this.value = arguments[2];
            this.id = (this.label + this.feature.toUpperCase());
        }
    }
}

export interface BasicInput {
    id: string,
    value?: number
}