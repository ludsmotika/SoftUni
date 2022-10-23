class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(first, second) {
        //√((x_2-x_1)²+(y_2-y_1)²)
        let firstHalf=(second.x-first.x)**2;
        let secondHalf=(second.y-first.y)**2;
        let answer= Math.sqrt(firstHalf+secondHalf);
        return answer
    }
}