import { assert } from 'chai';

import { TrigSolver } from '../src/TrigSolver'

describe('The basics of the TrigSolver library...', function () {

  // This first suite of tests was written to guide early development
  // and could be skipped or just deleted once we have a working POC.

  it('The library provides a \'TrigSolver\' class.', function () {
    const ts = new TrigSolver(['lengthA', 'lengthB', 'angleA']);
    assert.isObject(ts);
  });

  it('The class provides two methods, \'validate\' and \'solve\'.', function () {
    const ts = new TrigSolver(['lengthA', 'lengthB', 'angleA']);
    assert.isFunction(ts.validate);
    assert.isFunction(ts.solve);
  });

  it('The class has a property to toggle angular units degrees and radians.', function () {
    const ts = new TrigSolver(['lengthA', 'lengthB', 'angleA']);
    assert.isBoolean(ts.useDegrees);
  });

  it('The class has a property identify a \'no-solution\' condition.', function () {
    const ts = new TrigSolver(['angleA', 'angleB', 'angleC']);
    assert.equal(ts.caseName, 'no-solution');
  });

  it('The \'solve\' method returns an object.', function () {
    const ts = new TrigSolver(['lengthA', 'lengthB', 'lengthC']);
    assert.isObject(ts.solve([3, 4, 5]));
  });

});


