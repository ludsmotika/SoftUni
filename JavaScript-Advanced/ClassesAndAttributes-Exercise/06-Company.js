class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        if (this.departments[`${department}`] == undefined) {
            this.departments[`${department}`] = [];
        }

        class Employee {
            constructor(name, salary, position) {
                this.position = position;
                this.salary = salary;
                this.name = name;
            }
        }
        if (name == '' || name == undefined || name == null || salary == null || salary == undefined || salary == '' || position == '' || position == null || position == undefined || department == '' || department == null || department == undefined) {
            throw new Error("Invalid input!");
        }
        if (salary < 0) {
            throw new Error("Invalid input!");
        }

        this.departments[`${department}`].push(new Employee(name, salary, position));

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDepartmentName = '';
        let highestAverageSalary = 0;
        for (let key in this.departments) {
            let currentAverageSalary = 0;
            for (let employee of this.departments[key]) {
                currentAverageSalary += employee.salary;
            }
            if ((currentAverageSalary / this.departments[key].length) > highestAverageSalary) {
                bestDepartmentName = key;
                highestAverageSalary = currentAverageSalary / this.departments[key].length;
            }
        }
        let answer = `Best Department is: ${bestDepartmentName}\n`;
        answer += `Average salary: ${highestAverageSalary.toFixed(2)}\n`;
        for (let employee of this.departments[`${bestDepartmentName}`].sort((a, b) =>{return b.salary - a.salary|| a.name.localeCompare(b.name)})) {
            answer += `${employee.name} ${employee.salary} ${employee.position}\n`;
        }

        return answer.trimEnd();
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
