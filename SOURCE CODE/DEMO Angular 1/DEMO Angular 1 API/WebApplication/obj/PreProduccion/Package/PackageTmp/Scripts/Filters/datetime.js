app.filter("formatdate", [function () {
    var result = function(date, formatstring) {
        if (formatstring === null) {
            formatstring = "YYYY-MM-DD";
        }
        if (date == null || date == "")
            return "";

        return moment(date).format(formatstring);
    };
    return result;
}]);