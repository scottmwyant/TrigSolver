import { Calculated, DataPoint, Given } from './DataPoint';
import { trig } from './trig';
import { Profile } from './TrigSolver';
import { transform } from './utilities';

export interface ISolution {
  (given: Given): Calculated[]
}

type SolutionLogic = (given: Given) => null | Calculated | [Calculated, Calculated]


// class Solution implements ISolution {

//   constructor(private fn: SolutionLogic) {
//   }

//   compute(given: Given): Calculated[] {
//     const sln = this.fn(given);
//     if (sln == null) {
//       return []
//     }
//     else if (sln.length == 2) {
//       return sln
//     }
//     else {
//       return [sln]
//     }
//   }

// }


export function getSolution(profile: Profile) {

  const solutionRepository = {

    "no-solution": function (given: Given) {
      return null;
    },

    // -- All three sides given --
    // Get angle that pairs with given[0]
    // Get angle that pairs with given[1]
    // Then get the last angle
    "side-side-side": function (given: Given): Calculated {
      const out0 = trig.lawOfCosines([given[1], given[2]], given[0]);
      const out1 = trig.lawOfCosines([given[0], given[2]], given[1]);
      const out2 = trig.sumOfAngles([out0, out1]);
      return [out0, out1, out2];
    },

    // One feature from each pair is known; two sides and one angle.
    // Use law of cosines to get the last side then law of sines to get
    // one of the missing angles, then sum of angles.
    "side-side-angle": function (given: Given): Calculated {
      const lengths = transform.filterByFeature(given, 'length');
      const angle = transform.filterByFeature(given, 'angle')[0];
      const out0 = trig.lawOfCosines(lengths, angle);
      const out1 = trig.lawOfSines(transform.getPair([angle, out0]), lengths[0]);
      const out2 = trig.sumOfAngles([angle, out1]);
      return [out0, out1, out2];
    },

    // One feature from each pair is known; one side and two angles.
    // Solve the missing angle that pairs with the given side, then use
    // law of sines to get the other two sides.
    "side-angle-angle": function (given: Given): Calculated {
      const angles = transform.filterByFeature(given, 'angle');
      const length = transform.filterByFeature(given, 'length')[0];
      const out0 = trig.sumOfAngles(angles);
      const pair = transform.getPair([length, out0]);
      const out1 = trig.lawOfSines(pair, angles[0]);
      const out2 = trig.lawOfSines(pair, angles[1]);
      return [out0, out1, out2];
    },

    // One side and two angles given; the side and one of the angles form a pair (have the same label).
    // ** Something is wrong here **  the algorithm for this case should not be the same as the case above.
    "pair-and-angle": function (given: Given): Calculated {
      const pair = transform.getPair(given);
      const angle = transform.getOther(given);
      const angles = transform.filterByFeature(given, 'angle');
      const out0 = trig.sumOfAngles(angles);
      const out1 = trig.lawOfSines(pair, angle);
      const out2 = trig.lawOfSines(pair, out0);
      return [out0, out1, out2];
    },

    // Two sides and one angle given; one of the sides and the angle form a pair (have the same label).
    // Get the angle for the 'other' side that is given.  Then use sum of angles to get the last angle.
    // Use law of sines with the given pair to get the last side.
    // Consult: https://en.wikipedia.org/wiki/Solution_of_triangles#Solving_plane_triangles
    // and https://socratic.org/trigonometry/triangles-and-vectors/the-ambiguous-case
    "pair-and-side": function (given: Given): Calculated {
      const pair = transform.getPair(given);
      const length = transform.getOther(given);
      const angle = transform.filterByFeature(given, 'angle')[0];
      const out0 = trig.lawOfSines(pair, length);
      const out1 = trig.sumOfAngles([angle, out0]);
      const out2 = trig.lawOfSines(pair, out1);
      return [out0, out1, out2];
    }

  };

  let fn: SolutionLogic = solutionRepository[profile.caseName];
  if (fn == undefined) { solutionRepository['no-solution']; }
  return function (given: Given): Calculated[] {
    const sln = fn(given);
    if (sln == null) {
      return []
    }
    else if (sln.length == 2) {
      return sln
    }
    else {
      return [sln]
    }
  }
}
