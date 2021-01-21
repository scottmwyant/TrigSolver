import { DataPoint } from './DataPoint'
import * as util from './utiliies' 

export const trig = (function () {

    const equations = {
      "sumOfAngles": function (angle1: number, angle2: number) {
        return (Math.PI - angle1 - angle2);
      },
      "lawOf": {
        "cosines": {
          "solveAngle1": function (length1: number, length2: number, length3: number) {
            return (Math.acos((Math.pow(length1, 2) - Math.pow(length2, 2) - Math.pow(length3, 2)) / (-2 * length2 * length3)));
          },
          "solveLength3": function (length1: number, length2: number, angle3: number) {
            return Math.pow((Math.pow(length1, 2) + Math.pow(length2, 2)) - (2 * length1 * length2 * Math.cos(angle3)), 0.5);
          }
        },
        "sines": {
          "solveAngle2": function (length1: number, angle1: number, length2: number) {
            return Math.asin((Math.sin(angle1) / length1) * length2);
          },
          "solveLength2": function (length1: number, angle1: number, angle2: number) {
            return (length1 / Math.sin(angle1)) * Math.sin(angle2);
          }
        }
      }
    };

    return {

      "lawOfCosines": function (lengths: DataPoint[], complement: DataPoint) {
        // The return will match the label of the second parameter and the feature of the return will
        // be the complement of the second parameter.
        if (complement.feature == 'length') {
          return new DataPoint(complement.label, 'angle', equations.lawOf.cosines.solveAngle1(complement.value, lengths[0].value, lengths[1].value));
        }
        else if (complement.feature == 'angle') {
          return new DataPoint(complement.label, 'length', equations.lawOf.cosines.solveLength3(lengths[0].value, lengths[1].value, complement.value));
        }
        else {
          return new DataPoint('', '', 0);
        }
      },
      "lawOfSines": function (pair: util.Pair, complement: DataPoint) {
        if (complement.feature == 'angle') {
          return new DataPoint(complement.label, 'length', equations.lawOf.sines.solveLength2(pair.length, pair.angle, complement.value));
        }
        else if (complement.feature == 'length') {
          return new DataPoint(complement.label, 'angle', equations.lawOf.sines.solveAngle2(pair.length, pair.angle, complement.value));
        }
        else {
          return new DataPoint('', '', 0);
        }
      },
      "sumOfAngles": function (angles: DataPoint[]) {
        // Accepts a two element array
        return new DataPoint(util.transform.getMissingLabel(angles[0].label, angles[1].label), 'angle', equations.sumOfAngles(angles[0].value, angles[1].value));
      }

    }

  })();