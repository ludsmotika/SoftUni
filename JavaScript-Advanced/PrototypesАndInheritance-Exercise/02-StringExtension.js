(function extendString() {
    String.prototype.ensureStart = function (str) {

        if (!this.startsWith(str)) {
            return str.concat(this);
        }

        return this.toString();
    }

    String.prototype.ensureEnd = function (str) {

        if (!this.endsWith(str)) {
            this.concat(str);
        }

        return this.toString();
    }

    String.prototype.isEmpty = function () {

        if (this.length === 0) {
            return true;
        }
        return false;
    }

    String.prototype.truncate = function (n) {

        if (n < 3) {
            return '.'.repeat(n);
        }
        if (this.toString().length <= n) {
            return this.toString();
        } else {
            let lastIndex = this.toString().substring(0, n - 2).lastIndexOf(' ');
            if (lastIndex !== -1) {
                return this.toString().substring(0, lastIndex) + '...';
            } else {
                return this.toString().substring(0, n - 3) + '...';
            }
        }

    }

    String.format = function (str, ...params) {
        for (let i = 0; i < params.length; i++) {
            str = str.replace(`{${i}}`, params[i]);
        }

        return str;
    }

})();



