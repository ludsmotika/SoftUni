function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {

      let input = JSON.parse(document.querySelector('#inputs textarea').value);

      let restaurants = [];

      for (const restaurantEntity of input) {

         let restaurant = {};

         let [restaurantName, employeesString] = restaurantEntity.split(' - ');
         restaurant.name = restaurantName;
         let foundRestaurant = restaurants.find(x => x.name === restaurantName);

         let salaryByEmployeeName = employeesString.split(', ');
         let employees = [];
         restaurant.employees = [];

         for (const employeeEntity of salaryByEmployeeName) {
            let [employeeName, employeeSalary] = employeeEntity.split(' ');
            employeeSalary = Number(employeeSalary);

            let employee = {
               name: employeeName,
               salary: employeeSalary
            }

            employees.push(employee);
         }

         if (foundRestaurant) {
            restaurant = foundRestaurant;
         }

         for (const employee of employees) {
            restaurant.employees.push(employee);
         }

         if (!foundRestaurant) {
            restaurants.push(restaurant);
         }

         restaurant.averageSalary = restaurant.employees.reduce((a, e) => {
            return a + e.salary
         }, 0) / restaurant.employees.length;

         restaurant.bestSalary = restaurant.employees.sort((a, b) => b.salary - a.salary)[0].salary;
      }

      let bestRestaurant = restaurants.sort((a, b) => b.averageSalary - a.averageSalary)[0];

      let bestRestaurantElement = document.querySelector('#bestRestaurant p');
      bestRestaurantElement.textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;

      let bestRestaurantWorkersElement = document.querySelector('#workers p');

      let bestWorkers = '';
      for (const employee of bestRestaurant.employees) {
         bestWorkers += `Name: ${employee.name} With Salary: ${employee.salary} `;
      }

      bestRestaurantWorkersElement.textContent = bestWorkers.trimEnd();
   }
}