$.timeStampToBase64String = function (data) {
    var str = String.fromCharCode.apply(null, data);
    var serialObj = JSON.stringify(btoa(str));
    return serialObj;
};