import { DataPoint } from './DataPoint';
import { trig } from './trig';
import { Profile } from './TrigSolver';
import { transform } from './utiliies';

export interface Solution {
  name: string
  fn: (given: DataPoint[]) => DataPoint[][]
}

export function getSolution(profile: Profile) {

  const noSolution = {
    name: "no-solution",
    fn: function (given: DataPoint[]): DataPoint[][] {
      return [];
    }
  }

  const data = [

    // -- All three sides given --
    // Get angle that pairs with given[0]
    // Get angle that pairs with given[1]
    // Then get the last angle
    {
      "name": "side-side-side",
      "fn": function (given: DataPoint[]): DataPoint[][] {
        const out0 = trig.lawOfCosines([given[1], given[2]], given[0]);
        const out1 = trig.lawOfCosines([given[0], given[2]], given[1]);
        const out2 = trig.sumOfAngles([out0, out1]);
        return [[out0, out1, out2]];
      }
    },

    // One feature from each pair is known; two sides and one angle.
    // Use law of cosines to get the last side then law of sines to get
    // one of the missing angles, then sum of angles.
    {
      "name": "side-side-angle",
      "fn": function (given: DataPoint[]): DataPoint[][] {
        const lengths = transform.filterByFeature(given, 'length');
        const angle = transform.filterByFeature(given, 'angle')[0];
        const out0 = trig.lawOfCosines(lengths, angle);
        const out1 = trig.lawOfSines(transform.getPair([angle, out0]), lengths[0]);
        const out2 = trig.sumOfAngles([angle, out1]);
        return [[out0, out1, out2]];
      }
    },

    // One feature from each pair is known; one side and two angles.
    // Solve the missing angle that pairs with the given side, then use
    // law of sines to get the other two sides.
    {
      "name": "side-angle-angle",
      "fn": function (given: DataPoint[]): DataPoint[][] {
        const angles = transform.filterByFeature(given, 'angle');
        const length = transform.filterByFeature(given, 'length')[0];
        const out0 = trig.sumOfAngles(angles);
        const pair = transform.getPair([length, out0]);
        const out1 = trig.lawOfSines(pair, angles[0]);
        const out2 = trig.lawOfSines(pair, angles[1]);
        return [[out0, out1, out2]];
      }
    },

    // One side and two angles given; the side and one of the angles form a pair (have the same label).
    // ** Something is wrong here **  the algorithm for this case should not be the same as the case above.
    {
      "name": "pair-and-angle",
      "fn": function (given: DataPoint[]): DataPoint[][] {
        const pair = transform.getPair(given);
        const angle = transform.getOther(given);
        const angles = transform.filterByFeature(given, 'angle');
        const out0 = trig.sumOfAngles(angles);
        const out1 = trig.lawOfSines(pair, angle);
        const out2 = trig.lawOfSines(pair, out0);
        return [[out0, out1, out2]];
      }
    },

    // Two sides and one angle given; one of the sides and the angle form a pair (have the same label).
    // Get the angle for the 'other' side that is given.  Then use sum of angles to get the last angle.
    // Use law of sines with the given pair to get the last side.
    // Consult: https://en.wikipedia.org/wiki/Solution_of_triangles#Solving_plane_triangles
    // and https://socratic.org/trigonometry/triangles-and-vectors/the-ambiguous-case
    {
      "name": "pair-and-side",
      "fn": function (given: DataPoint[]): DataPoint[][] {
        const pair = transform.getPair(given);
        const length = transform.getOther(given);
        const angle = transform.filterByFeature(given, 'angle')[0];
        const out0 = trig.lawOfSines(pair, length);
        const out1 = trig.sumOfAngles([angle, out0]);
        const out2 = trig.lawOfSines(pair, out1);
        return [[out0, out1, out2]];
      }
    }

  ];

  const solution = data.filter(item => item.name.indexOf(profile.caseName) > -1);
  return solution.length == 1 ? solution[0] : noSolution

}
