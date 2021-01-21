import { DataPoint } from './DataPoint'

export class Triangle {

    classification1: 'acute' | 'obtuse' | 'right'
    classification2: 'equilateral' | 'isosceles' | 'scalene'
    points: Point[]

    private useDegrees: boolean
    private rankedLengths: {min: number, mid: number, max: number}
    private rankedAngles: {min: number, mid: number, max: number}

    private featureAsKey: {
        length: { a: number, b: number, c: number },
        angle: { a: number, b: number, c: number }
    }


    // private labelAsKey: {
    //     a: {length: number, angle: number},
    //     b: {length: number, angle: number},
    //     c: {length: number, angle: number}
    // }

    constructor(private data: DataPoint[]) {

        // function dataByLabel() {
        //     const obj: any = {};
        //     data.forEach(item =>{
        //         obj[item.label][item.feature] = item.value;
        //     });
        //     return obj;
        // }

        function dataByFeature() {
            const obj: any = {};
            data.forEach(item => {
                if (obj[item.feature] == undefined) {
                    obj[item.feature] = {};
                }
                obj[item.feature][item.label] = item.value;
            });
            return obj;
        }

        this.featureAsKey = dataByFeature();
        // this.labelAsKey = dataByLabel();

        function rank(arr: number[]){
            const obj = {};
            return {
                min: Math.min(...arr),
                mid: arr.reduce((sum, val) => sum + val) - Math.min(...arr) - Math.max(...arr),
                max: Math.max(...arr)
            };
        }

        const len = this.lengths;
        this.rankedLengths = rank(len);

        const ang = this.angles;
        this.rankedAngles = rank(ang);
        
        this.classification1 = (() => {

            if (len.filter(value => value > 90).length > 0) {
                return 'obtuse'
            }
            else if (len.filter(value => value == 90).length > 0) {
                return 'right'
            }
            else {
                return 'acute'
            }

        })();

        this.classification2 = (() => {
            if (len[0] == len[1] && len[0] == len[2]) {
                return 'equilateral';
            }
            else if (len[0] == len[1] || len[0] == len[2] || len[1] == len[2]) {
                return 'isosceles';
            }
            else {
                return 'scalene';
            }
        })();

        this.useDegrees = (() => {
            const sumOfAngles = ang.reduce((total, current) => total + current);
            const deltaDeg = Math.abs(sumOfAngles - 180);
            const deltaRad = Math.abs(sumOfAngles - Math.PI);
            return deltaDeg < deltaRad;
        })();

        this.points = (() => {
            if (this.classification2 == 'equilateral') {
                const len = this.lengths[0];
                return [
                    new Point(0, 0),
                    new Point(len, 0),
                    new Point(len / 2, len * Math.cos(30 * Math.PI / 180))
                ];
            }
            else if (this.classification2 == 'isosceles') {
                const targetLabel = this.data.filter(item => item.feature == 'length' && item.value == this.rankedLengths.min)[0].label;
                const angle = this.data.filter(item => item.label == targetLabel && item.feature == 'angle')[0].value;
                const longLeg = this.rankedLengths.max;
                return [
                    new Point(0, 0),
                    new Point(longLeg, 0),
                    new Point(longLeg*Math.cos(angle*Math.PI/180), longLeg*Math.sin(angle*Math.PI/180))
                ];
            }
            else {
                const targetLabel = this.data.filter(item => item.feature == 'length' && item.value == this.rankedLengths.min)[0].label;
                const angle = this.data.filter(item => item.feature == 'angle' && item.label == targetLabel)[0].value;
                const midLeg = this.rankedLengths.mid;
                return [
                    new Point(0, 0),
                    new Point(this.rankedLengths.max, 0),
                    new Point(midLeg * Math.cos(angle*Math.PI/180), midLeg*Math.sin(angle*Math.PI/180))
                ];
            }
        })();

    }

    get lengths() {
        const obj = this.featureAsKey.length;
        return [obj.a, obj.b, obj.c];
    }

    get angles() {
        const obj = this.featureAsKey.angle;
        return [obj.a, obj.b, obj.c];
    }

}


class Point {
    constructor(
        public x: number,
        public y: number
    ) { }
}