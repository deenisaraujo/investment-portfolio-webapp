var util = util || {};

util.storage = {
    setItem: function (name, object) {
        var json = JSON.stringify(object);
        localStorage.setItem(name, json);
    },
    getItem: function (name) {
        return JSON.parse(localStorage.getItem(name));
    },
    clear: function () {
        localStorage.clear();
    }
};

util.ajax = {
    post: function (url, model, callBackSuccess, callBackError) {
        $.ajax({
            url: url,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(model),
            success: function (data) {
                if (callBackSuccess) {
                    callBackSuccess(data);
                }
            },
            error: function (xhr, status, errorThrown) {
                if (callBackError) {
                    callBackError(xhr);
                }
            }
        });
    }
};
util.URL = {
    getParam: function (name) {
        var url = location.href;

        var str = url;
        var spt = url.split('?');

        if (spt.length > 1) {
            var spt2 = spt[1].split('&');

            for (var i = 0; i < spt2.length; i++) {
                if (spt2[i].indexOf(name) >= 0) {

                    var spt3 = spt2[i].split('=');
                    return spt3[1].replace('%', '');
                }
            }
        }

        return "";
    }
};
util.Input = {
    onlyNumbers: function (event) {
        return /[0-9]+/.test(event.key);
    },
    onlyLetters: function (event) {
        return /[a-zA-Z]+/.test(event.key);
    }
};
util.change= {
    location: function (urlDestino) {
        window.location.replace(urlDestino);
    }
};