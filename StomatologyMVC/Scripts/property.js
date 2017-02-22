app.factory('property', function () {
    var options = [{ 'valueHiden': '0', 'valueScren': 'Выберете дату...' }]; //
    var selectedOption = options[0];
    var user = [];
    var entrys = [];
    return {
        setEntrys: function (entrysObj) {
            entrys.push(entrysObj)
        },
        getEntrys: function () {
            return entrys;
        },
        deleteEntrys: function () {
            entrys.splice(0, entrys.length);
        },

        setUser: function (userObj) {
            user = userObj;
        },
        getUser: function () {
            return user;
        },

        deleteOptions: function () {
            options.splice(0, options.length);
            selectedOption = null;
        },
        setOption: function (userObj) {
            options.push(userObj);
            selectedOption = options[0];
        },
        getOption: function () {
            return options;
        },
        getOptionSelected: function () {
            return selectedOption;
        }
    }
});