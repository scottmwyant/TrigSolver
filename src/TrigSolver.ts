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
  useDegrees: (bool: boolean) => void
  validate(given: DataPoint[]): IValidationResponse
  solve(input: number[]): Triangle[]
  solve(input: { id: string, value: number }[]): Triangle[]
}

interface IValidationResponse {
  valid: boolean
  detail: RuleResult[]
}

export class TrigSolver implements ITrigSolver {

  private degrees: boolean
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
    this.degrees = true;
  }

  validate(given: Given): IValidationResponse {
    const results = this.rules.map(rule => rule.fn(given));
    return {
      detail: results,
      valid: results.filter(item => item.satisfied == false).length == 0,
    }
  }

  solve(input: number[]): Triangle[]
  solve(input: { id: string, value: number }[]): Triangle[]
  solve(input: any): Triangle[] {

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

    if (this.degrees) { util.convert.toRadians(given); }

    const calculatedValues = this.solution(given);

    const rtn = calculatedValues.map(sln => new Triangle(given.concat(sln)));

    if (this.degrees) {
      rtn.forEach(item => { item.toDegrees(); });
    }

    return rtn;

  }

  useDegrees(bool: boolean){
    this.degrees = bool;
  }

}
