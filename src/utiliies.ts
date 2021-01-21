import { DataPoint } from './DataPoint'

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

  const caseName = (function () {
    const data = [
      { name: 'side-side-side', scope: [56] },
      { name: 'side-side-angle', scope: [28, 42, 49] },
      { name: 'side-angle-angle', scope: [14, 21, 35] },
      { name: "pair-and-angle", scope: [11, 13, 19, 22, 37, 38] },
      { name: "pair-and-angle", scope: [11, 13, 19, 22, 37, 38] }
    ];
    const arr = data.filter(item => (item.scope.indexOf(caseId) > -1));
    return arr.length == 1 ? arr[0].name : 'no-solution';
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
