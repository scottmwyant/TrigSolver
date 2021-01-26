import { DataPoint, Given } from './DataPoint';
import { Rule, getRules, RuleResult } from './Rule';
import { getSolution, ISolution } from './Solutions';
import { Triangle } from './Triangle';
import * as util from './utiliies';

export interface Profile {
  caseId: number,
  caseName: util.CaseName
  count: {
    lengths: number,
    angles: number,
    inputs: number
  }
}

interface ITrigSolver {
  useDegrees: boolean
  validate(given: DataPoint[]): IValidationResponse
  solve(input: number[]): ISolveResponse
  solve(input: { id: string, value: number }[]): ISolveResponse
}

interface ISolveResponse {
  triangle: Triangle[]
  calculatedValues: DataPoint[] | DataPoint[][]
}

interface IValidationResponse {
  valid: boolean
  detail: RuleResult[]
}

export class TrigSolver implements ITrigSolver {

  public useDegrees: boolean
  private profile: Profile
  private rules: Rule[]
  private solution: ISolution
  private input: DataPoint[]

  get caseName() { return this.profile.caseName; }

  constructor(inputIds: string[]) {
    this.input = inputIds.map(item => new DataPoint(item));
    this.profile = util.profile(this.input)
    this.rules = getRules(this.profile);
    this.solution = getSolution(this.profile);
    this.useDegrees = true;
  }

  validate(given: Given): IValidationResponse {
    const results = this.rules.map(rule => rule.fn(given));
    return {
      detail: results,
      valid: results.filter(item => item.satisfied == false).length == 0,
    }
  }

  solve(input: number[]): ISolveResponse
  solve(input: { id: string, value: number }[]): ISolveResponse
  solve(input: any): ISolveResponse {

    const given: Given = (() => {
      if (typeof input[0] == 'number') {
        input.forEach((item: number, i: number) => {
          this.input[i].value = input[i];
        });
        return this.input
      }
      else if (typeof input[0] == 'object') {
        return input.map((item: { id: string, value: number }) => new DataPoint(item));
      }
    })();

    if (this.useDegrees) { util.convert.toRadians(given); }

    const calculatedValues = this.solution(given);

    const rtn = calculatedValues.map(sln => new Triangle(given.concat(sln)));

    if (this.useDegrees) { 
      rtn.forEach(item => {
        item.convert.toDegrees();
      });
    }

    return {
      triangle: rtn,
      calculatedValues
    };
      

  }

}
