//accepts aplphabet only
function isAlphabateOnly(evt) {
    evt = (evt) ? evt : window.evt;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123)) {
        return true;
    }
    return false;
}
//accepts number only
function isNumber(evt) {
    evt = (evt) ? evt : window.evt;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}
//accepts aplphabet space and dot
function isAlphabetWithSpaceDot(evt) {
    evt = (evt) ? evt : window.evt;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode == 32) || (charCode == 46)) {
        return true;
    }
    return false;
}
//accepts aplphabet space
function isAlphabetWithSpace(evt) {
    evt = (evt) ? evt : window.evt;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode == 32)) {
        return true;
    }
    return false;
}
//accepts aplphabet space
function isNumberWithDot(evt, obj) {
    evt = (evt) ? evt : window.evt;
    var charCode = (evt.which) ? evt.which : evt.keyCode
    var value = obj.value;
    var dotcontains = value.indexOf(".") != -1;
    if (dotcontains) if (charCode == 46) return false;
    if (charCode == 46) return true;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) return false;
    return true;
}