function getClasses() {

    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }

        changeUnits(value) {
            if (['cm', 'mm', 'm'].indexOf(value) == -1) {
                throw new Error("Invalid unit!");
            }
            this.units = value;
        };

        get area() {

        };

        toString() {
            return `Figures units: ${this.units}`;
        };
    }

    class Circle extends Figure {
        constructor(radius, units = 'cm') {
            super(units);
            this.radius = radius;
        }

        get area() {

            let answer = Math.PI * this.radius ** 2;
            switch (this.units) {
                case 'mm':
                    answer *= 100;
                    break;
                case 'm':
                    answer /= 1000;
                    break;
            }
            return answer;
        }

        toString() {
            let currentRadius = this.radius;
            switch (this.units) {
                case 'mm':
                    currentRadius *= 10;
                    break;
                case 'm':
                    currentRadius /= 100;
                    break;
            }

            return `Figures units: ${this.units} Area: ${this.area} - radius: ${currentRadius}`;
        }

    }

    class Rectangle extends Figure {

        constructor(width, height, units = 'cm') {
            super(units);
            this.width = width;
            this.height = height;
        }

        get area() {
            let answer = this.width * this.height;
            switch (this.units) {
                case 'mm':
                    answer *= 100;
                    break;
                case 'm':
                    answer /= 1000;
                    break;
            }

            return answer;
        }

        toString() {
            let currentWidth = this.width;
            let currentHeight = this.height;
            switch (this.units) {
                case 'mm':
                    currentWidth *= 10;
                    currentHeight *= 10;
                    break;
                case 'm':
                    currentWidth /= 100;
                    currentHeight /= 100;
                    break;
            }
            return `Figures units: ${this.units} Area: ${this.area} - width: ${currentWidth}, height: ${currentHeight}`;
        }
    }



    return { Figure, Circle, Rectangle };
}