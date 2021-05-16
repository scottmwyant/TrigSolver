import { DataPoint } from './DataPoint'

export type CaseName = "side-side-side" | "side-side-angle" | "side-angle-angle" | "pair-and-angle" | "pair-and-side" | "no-solution";

export function parseInputId(inputId: string) {
  return {
    feature: inputId.substring(0, inputId.length - 1).toLowerCase(),
    label: inputId.substring(inputId.length - 1).toLowerCase()
  };
}

export const transform = {

  "getMissingLabel": function (label1: string, label2: string) {
    return 'abc'.replace(label1, '').replace(label2, '');
  },

  "filterByFeature": function (data: DataPoint[], feature: string) {
    return data.filter(item => item.feature === feature);
  },

  "getPair": function (data: DataPoint[]) {
    // Assumptions: 
    // - This object is constructed wtih a 3-element array.  
    // - Two of the three elements have the same label, so there
    //   are only two different labels within the array.

    // Put the labels into an array
    const labels = data.map(p => p.label);

    // Provide an internal method to filter to a given label
    function filterLabel(label: string) {
      return data.filter(p => p.label == label);
    }

    // Break the argument into two arrays, one array will have two elements
    // and the other one will have a single element.  The array with two
    // elements constitute the pair.
    const arrLabel0 = filterLabel(labels[0]);
    const arrLabel1 = filterLabel(labels[1]);
    const pointsWithSameLabel = arrLabel0.length == 2 ? arrLabel0 : arrLabel1;
    return new Pair(pointsWithSameLabel);

  },

  "getOther": function (data: DataPoint[]) {
    const pair = this.getPair(data);
    return data.filter(item => item.label != pair.label)[0];
  }

};




export class Pair {

  label?: string
  angle: number = 0
  length: number = 0

  constructor(arr: DataPoint[]) {

    const setFeature = (data: DataPoint) => {
      if (data.feature == 'angle') {
        this.angle = data.value;
      }
      else if (data.feature == 'length') {
        this.length = data.value;
      }
    }

    this.label = arr[0].label;
    setFeature(arr[0]);
    setFeature(arr[1]);
  }

}

export function profile(inputs: DataPoint[]) {

  const binary = (function () {
    const rtn = [0, 0, 0, 0, 0, 0];
    inputs.forEach(element => {
      switch (element.id) {
        case 'lengthA': rtn[0] = 1; break;
        case 'lengthB': rtn[1] = 1; break;
        case 'lengthC': rtn[2] = 1; break;
        case 'angleA': rtn[3] = 1; break;
        case 'angleB': rtn[4] = 1; break;
        case 'angleC': rtn[5] = 1; break;
      }
    });
    return rtn;
  })();

  const caseId = parseInt(binary.join(''), 2);

  const caseName = (function (): CaseName {
    const data: {name: CaseName, scope: number[]}[] = [
      { name: 'side-side-side', scope: [56] },
      { name: 'side-side-angle', scope: [28, 42, 49] },
      { name: 'side-angle-angle', scope: [14, 21, 35] },
      { name: "pair-and-side", scope: [25, 26, 41, 44, 50, 52] },
      { name: "pair-and-angle", scope: [11, 13, 19, 22, 37, 38] }
    ];
    
    const arr = data.filter(item => (item.scope.indexOf(caseId) > -1));
    return arr.length == 1 ? arr[0].name : 'no-solution';

    /*
    
      This array is included here in the source code and intentionally
      not used.  This is the only place we see the binaryId alongside
      the decimal form of the id and the algorithm name.
    */
   
    // const referenceData = [
    //   { "binary": "111000", "id": 56, "algorithm": "side-side-side" },
    //   { "binary": "001110", "id": 14, "algorithm": "side-angle-angle" },
    //   { "binary": "010101", "id": 21, "algorithm": "side-angle-angle" },
    //   { "binary": "100011", "id": 35, "algorithm": "side-angle-angle" },
    //   { "binary": "110001", "id": 49, "algorithm": "side-side-angle" },
    //   { "binary": "011100", "id": 28, "algorithm": "side-side-angle" },
    //   { "binary": "101010", "id": 42, "algorithm": "side-side-angle" },
    //   { "binary": "110100", "id": 52, "algorithm": "pair-and-side" },
    //   { "binary": "101100", "id": 44, "algorithm": "pair-and-side" },
    //   { "binary": "110010", "id": 50, "algorithm": "pair-and-side" },
    //   { "binary": "011010", "id": 26, "algorithm": "pair-and-side" },
    //   { "binary": "101001", "id": 41, "algorithm": "pair-and-side" },
    //   { "binary": "011001", "id": 25, "algorithm": "pair-and-side" },
    //   { "binary": "100110", "id": 38, "algorithm": "pair-and-angle" },
    //   { "binary": "100101", "id": 37, "algorithm": "pair-and-angle" },
    //   { "binary": "010110", "id": 22, "algorithm": "pair-and-angle" },
    //   { "binary": "010011", "id": 19, "algorithm": "pair-and-angle" },
    //   { "binary": "001101", "id": 13, "algorithm": "pair-and-angle" },
    //   { "binary": "001011", "id": 11, "algorithm": "pair-and-angle" },
    //   { "binary": "000111", "id": 7, "algorithm": "no-solution" }
    // ];

  })();

  const count = (function () {
    const obj = { angles: 0, lengths: 0, inputs: 0 };
    binary.forEach((item, i) => {
      if (item > 0) {
        obj.inputs++
        if (i <= 2) {
          obj.lengths++;
        } else {
          obj.angles++;
        }
      }
    });
    return obj;
  })();

  return { caseId, caseName, count }
}


export const convert = (function () {
  function multiplyAngles(data: DataPoint[], factor: number) {
    data.forEach(item => {
      if (item.feature == 'angle') {
        item.value = item.value * factor;
      }
    });
  }
  return {
    toDegrees: function (data: DataPoint[]) {
      multiplyAngles(data, 180 / Math.PI);
    },
    toRadians: function (data: DataPoint[]) {
      multiplyAngles(data, Math.PI / 180);
    }
  }
})();
