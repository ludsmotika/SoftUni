function getRequest(obj) {

    //method check
    let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    if (validMethods.indexOf(obj['method']) == -1) {
        throw new Error("Invalid request header: Invalid Method");
    }

    //uri check
    let regexForURI =  /^[a-zA-Z0-9.]+$/gm;
    if ((regexForURI.test(obj['uri']) == false) || obj['uri'] === undefined) {
        if (obj['uri'] !== '*') {
            throw new Error("Invalid request header: Invalid URI");
        }
    }

    //version check
    let validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    if (validVersions.indexOf(obj['version']) == -1) {
        throw new Error("Invalid request header: Invalid Version");
    }

    //message check
    let messageAntiPattern = /[<>\\&'"]+/gm;
    if (messageAntiPattern.test(obj['message']) || obj['message'] == undefined) {
        throw new Error('Invalid request header: Invalid Message');
    }


    return obj;
}

console.log(getRequest({
    method: 'POST',
    uri: '%appdata%',
    version: 'HTTP/2.0',
    message: '\r\n'
}
));