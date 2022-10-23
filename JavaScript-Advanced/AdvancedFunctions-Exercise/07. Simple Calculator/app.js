function calculator() {
    let firstSelector;
    let secondSelector;
    let outputSelector;
    return {
        init: (selector1, selector2, resultSelector) => {
            firstSelector = document.querySelector(selector1);
            secondSelector = document.querySelector(selector2);
            outputSelector = document.querySelector(resultSelector);
        },
        add: () => {
            let num1 = Number(firstSelector.value);
            let num2 = Number(secondSelector.value);
            outputSelector.value = `${num1 + num2}`;
        },
        subtract: () => {
            let num1 = Number(firstSelector.value);
            let num2 = Number(secondSelector.value);
            outputSelector.value = `${num1 - num2}`;
        }
    }
}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result');



