import { assert } from 'chai';
import trigSolver from '../src';
import { sampleData } from './sampleData'

const precision = .01;

function outputValueForId(actual, expected) {
  const arr = actual.filter(item => item.id == expected.id);
  if (arr.length == 1) {
    return arr[0].value
  }
  else {
    return -1;
  }
}

describe('The TrigSolver library', function () {

  it('is a function', function () {
    assert.isFunction(trigSolver);
  });

  it('throws an error when passed inputs with no solution', function () {
    const fn = function () { trigSolver(['angleA', 'angleB', 'angleC']); }
    assert.throws(fn);
  });

})

describe('Object returned from TrigSolver()', function () {

  it('has keys .solve and .validation', function () {
    assert.hasAllKeys(
      trigSolver(['lengthA', 'lengthB', 'lengthC']),
      ['solve', 'validation']
    );
  });

  it('.validation is an array', function () {
    assert.isArray(trigSolver(['lengthA', 'lengthB', 'lengthC']).validation);
  });

  it('.solve is a function', function () {
    assert.isFunction(trigSolver(['lengthA', 'lengthB', 'lengthC']).solve);
  });

});

describe('Test each algorithm', function () {

  sampleData.forEach(sample => {

    describe(sample.testCase, function () {

      const obj = trigSolver(sample.input.map(item => item.id));
      let ans = null;

      try {
        ans = obj.solve(sample.input).solution;
      }
      catch (e) {
        console.log(e);
      }

      it('output 0', function () {
        assert.approximately(outputValueForId(ans, sample.output[0]), sample.output[0].value, precision);
      });
      it('output 1', function () {
        assert.approximately(outputValueForId(ans, sample.output[1]), sample.output[1].value, precision);
      });
      it('output 2', function () {
        assert.approximately(outputValueForId(ans, sample.output[2]), sample.output[2].value, precision);
      });

    });

  });

});
