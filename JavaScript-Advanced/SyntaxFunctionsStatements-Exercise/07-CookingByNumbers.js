function calculate(number, ...commands) {

    for (let command of commands) {
        number = executeCommand(command,number);
        console.log(number);
    }

    function executeCommand(command, toCalc) {
        switch (command) {
            case 'chop':
                return toCalc / 2;
                break;
            case 'dice':
                return Math.sqrt(toCalc);
                break;
            case 'spice':
                return toCalc+1;
                break;
            case 'bake':
                return toCalc * 3;
                break;
            case 'fillet':
                return toCalc * 0.80;
                break;

            default:
                break;
        }

    }
}