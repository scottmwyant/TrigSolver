import { assert } from 'chai';
import { TrigSolver } from '../src/TrigSolver';
import { sampleData } from './sampleData';
import { Triangle } from '../src/Triangle';

describe('The basics of the TrigSolver library...', function () {

  // This first suite of tests was written to guide early development
  // and could be skipped or just deleted once we have a working POC.

  it('The library provides a \'TrigSolver\' class.', function () {
    const ts = new TrigSolver(sampleData[0].input.map(item => item.id));
    assert.isObject(ts);
  });

  it('The class provides two methods, \'validate\' and \'solve\'.', function () {
    const ts = new TrigSolver(sampleData[0].input.map(item => item.id));
    assert.isFunction(ts.validate);
    assert.isFunction(ts.solve);
  });

  it('The class has a method to set angular unit to degrees or radians.', function () {
    const ts = new TrigSolver(sampleData[0].input.map(item => item.id));
    assert.isFunction(ts.useDegrees);
  });

  it('The class has a property identify a \'no-solution\' condition.', function () {
    const ts = new TrigSolver(['angleA', 'angleB', 'angleC']);
    assert.equal(ts.caseName, 'no-solution');
  });

  it('The \'solve\' method returns an array of type \'Triangle\'.', function () {
    const ts = new TrigSolver(sampleData[0].input.map(item => item.id));
    const ans = ts.solve(sampleData[0].input.map(item => item.value))
    assert.isArray(ans);
    assert.isTrue(ans[0] instanceof Triangle)
  });

});

describe('Test each algorithm...', function () {

  sampleData.forEach(sample => {

    describe(`${sample.testCase}`, function () {

      const ts = new TrigSolver(sample.input.map(item => item.id));
      const underTest = ts.solve(sample.input.map(item => item.value))[0];
      const precision = .01; // .00001

      sample.output.forEach((item, i) => {

        const feature = item.id.substr(0, item.id.length-1).toLowerCase();
        const label = item.id.substr(item.id.length-1).toLowerCase();
        
        it(item.id, function () {
          assert.approximately(underTest[feature][label], item.value, precision);
        });

      });

    });

  });

});

describe('The triangle object that gets returned...', function () {

  const data = sampleData[0];
  const precision = .001;
  const ts = new TrigSolver(data.input.map(item => item.id));
  
  it('Can convert to radians', function () {

    const triangle = ts.solve(data.input.map(item => item.value))[0];
    assert.approximately(triangle.angle.c, 90, precision);
    triangle.toRadians();
    assert.approximately(triangle.angle.c, 90 * Math.PI / 180, precision);

  });

  it('Can convert to degrees', function(){

    ts.useDegrees(false);
    const triangle = ts.solve(data.input.map(item => item.value))[0];
    assert.approximately(triangle.angle.c, 90 * Math.PI / 180, precision);
    triangle.toDegrees();
    assert.approximately(triangle.angle.c, 90, precision);

  });

});