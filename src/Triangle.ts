import { DataPoint } from './DataPoint'

type Points = [Point, Point, Point]
type AngleClass = 'acute' | 'obtuse' | 'right'
type LengthClass = 'equilateral' | 'isosceles' | 'scalene'
type DataDetail = {
    a: number, b: number, c: number,
    min: number, mid: number, max: number
}

export class Triangle {

    public readonly class: {
        readonly byAngles: AngleClass
        readonly byLengths: LengthClass
    }

    get angle() { return this._angle; }

    readonly length: DataDetail;
    readonly points: Points;
    readonly degrees: boolean;

    private _angle: DataDetail;

    constructor(private data: DataPoint[]) {

        const organize = (() => {
            function fn(feature: string) {
                const obj = {} as DataDetail;
                const featureData = data.filter(item => item.feature == feature);
                obj.a = featureData.filter(item => item.label == 'a')[0].value;
                obj.b = featureData.filter(item => item.label == 'b')[0].value;
                obj.c = featureData.filter(item => item.label == 'c')[0].value;
                obj.min = Math.min(...featureData.map(item => item.value));
                obj.max = Math.max(...featureData.map(item => item.value));
                obj.mid = featureData.map(item => item.value).reduce((sum, current) => sum + current) - obj.min - obj.max;
                return obj
            }
            return {
                angles: function () { return fn('angle') },
                lengths: function () { return fn('length') }
            }
        })();

        this._angle = organize.angles();
        this.length = organize.lengths();

        this.degrees = (() => {
            const ang = this.angle;
            const sumOfAngles = ang.a + ang.b + ang.c;
            const deltaDeg = Math.abs(sumOfAngles - 180);
            const deltaRad = Math.abs(sumOfAngles - Math.PI);
            return deltaDeg < deltaRad;
        })();

        this.class = (() => ({

            byAngles: ((): AngleClass => {
                const rightAngle = this.degrees ? 90 : Math.PI / 2;
                if (this.angle.max > rightAngle) { return 'obtuse'; }
                else if (this.angle.max < rightAngle) { return 'acute'; }
                else { return 'right'; }
            })(),

            byLengths: ((): LengthClass => {
                const len = this.length
                if (len.a == len.b && len.a == len.c) { return 'equilateral'; }
                else if (len.a == len.b || len.a == len.c || len.b == len.c) { return 'isosceles'; }
                else { return 'scalene'; }
            })()

        }))();


        this.points = ((): Points => {
            if (this.class.byLengths == 'equilateral') {
                const len = this.length.a;
                return [
                    new Point(0, 0),
                    new Point(len, 0),
                    new Point(len / 2, len * Math.cos(30 * Math.PI / 180))
                ];
            }
            else if (this.class.byLengths == 'isosceles') {
                const targetLabel = this.data.filter(item => item.feature == 'length' && item.value == this.length.min)[0].label;
                const angle = this.data.filter(item => item.label == targetLabel && item.feature == 'angle')[0].value;
                const longLeg = this.length.max;
                return [
                    new Point(0, 0),
                    new Point(longLeg, 0),
                    new Point(longLeg * Math.cos(angle * Math.PI / 180), longLeg * Math.sin(angle * Math.PI / 180))
                ];
            }
            else { // (this.class.byLengths == 'scalene')
                const targetLabel = this.data.filter(item => item.feature == 'length' && item.value == this.length.min)[0].label;
                const angle = this.data.filter(item => item.feature == 'angle' && item.label == targetLabel)[0].value;
                const midLeg = this.length.mid;
                return [
                    new Point(0, 0),
                    new Point(this.length.max, 0),
                    new Point(midLeg * Math.cos(angle * Math.PI / 180), midLeg * Math.sin(angle * Math.PI / 180))
                ];
            }
        })();


    }

    private multiplyAngles(scaleFactor: number){
        return {
            a: this.angle.a * scaleFactor,
            b: this.angle.b * scaleFactor,
            c: this.angle.c * scaleFactor,
            min: this.angle.min * scaleFactor,
            mid: this.angle.mid * scaleFactor,
            max: this.angle.max * scaleFactor
        };
    }
    
    toDegrees(){ this._angle = this.multiplyAngles(180 / Math.PI); }

    toRadians(){ this._angle = this.multiplyAngles(Math.PI / 180) }


}


class Point {
    constructor(
        public x: number,
        public y: number
    ) { }
}