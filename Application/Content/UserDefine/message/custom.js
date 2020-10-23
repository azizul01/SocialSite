 
$(document).ready(function () {   
    //Added by kamrul 06.09.2016
    $(".IsNumber").keydown(function (e) {
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            // Allow: Ctrl+A
            (e.keyCode == 65 && e.ctrlKey === true) ||
            // Allow: home, end, left, right
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });

    $(".thousandSeperate").keyup(function (e) {
        //function addCommas(nStr) {
        var id = e.target.id;
        var nStr = $('#' + id).val();
        nStr = nStr.replace(/,/g, '');
        nStr += '';
        x = nStr.split('.');
        x1 = x[0];
        x2 = x.length > 1 ? '.' + x[1] : '';
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        //return $(this).val(x1 + x2);
        $('#' + id).val(x1 + x2);
        //return x1 + x2;
    })

});
 

//Date Formate 
function date(value) {
    var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
                      "July", "Aug", "Sep", "Oct", "Nov", "Dec"];
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (("0" + (dt.getDay())).slice(-2) + "-" + monthNames[dt.getMonth() + 1]) + "-" + dt.getFullYear();
} 

//Added by kamrul 06.09.2016
function validFromDateToDate(fromDateName, toDateName, fromDateID, toDateID, changeTxtName) {
    if (changeTxtName == 'fromDate') {
        var fromDate = $("#" + fromDateID).datepicker("getDate");
        var toDate = $("#" + toDateID).datepicker("getDate");
        if (toDate != "") {
            if (fromDate > toDate) {
                alert(fromDateName + ' Must Be Less Than ' + toDateName + '');
                $("#" + fromDateID).val('');
                return;
            }
        }
    }
    if (changeTxtName == 'toDate') {
        var fromDate = $("#" + fromDateID).datepicker("getDate");
        var toDate = $("#" + toDateID).datepicker("getDate");
        if (fromDate != "") {
            if (fromDate > toDate) {
                alert(toDateName + ' Must Be Greater Than ' + fromDateName + '');
                $("#" + fromDateID).val('');
                return;
            }
        }
    }
}

 

//******************** Start:: Message Box *******************
//************************************************************
//************************************************************

//*** Start:: Fixed Text 

//Success or Failed Operation
function ShowOpMessage(sOperation, IsSuccess, sFunctionName) {
    if (IsSuccess) {
        $.prompt(sOperation + " Operation Successful.", {
            title: "Success",
            zIndex: 20000,
            buttons: { "Ok": true },
            submit: function (e, v, m, f) {
                eval(sFunctionName + "(" + v + ")");
            }
        })

        $(".jqititle").css({ "color": "#0a7c71", "background-color": "#cff5f2", "border-color": "#0a7c71" });
    }
    else {
        $.prompt(sOperation + " Operation Failed!", {
            title: "Failed",
            zIndex: 20000,
            buttons: { "Ok": true },
            submit: function (e, v, m, f) {
                //eval(sFunctionName + "(" + v + ")");
            }
        })

        $(".jqititle").css({ "color": "#933432", "background-color": "#fddddd", "border-color": "#933432" });
    }
}

//Confirmation Delete Operation
function ShowConfirmDeletion_YESNO(sFunctionName) {
    $.prompt("Sure to DELETE this record?", {
        title: "Confirmation",
        buttons: { "Yes": true, "No": false },
        submit: function (e, v, m, f) {
            eval(sFunctionName + "(" + v + ")");
        }
    })
    $(".jqititle").css({ "color": "#957d32", "background-color": "#fef6dd", "border-color": "#957d32" });
}

//Confirmation Delete Operation
function ShowConfirmDeletion_OKCANCEL(sFunctionName) {
    $.prompt("Sure to DELETE this record?", {
        title: "Confirmation",
        buttons: { "Ok": true, "Cancel": false },
        submit: function (e, v, m, f) {
            eval(sFunctionName + "(" + v + ")");
        }
    })
    $(".jqititle").css({ "color": "#957d32", "background-color": "#fef6dd", "border-color": "#957d32" });
}

//No Record Operation
function ShowNoRecord() {
    $.prompt("Sorry, Data not found!", {
        title: "Warning",
        zIndex: 20000,
        buttons: { "Ok": true },
        submit: function (e, v, m, f) {
            //eval(sFunctionName + "(" + v + ")"); 
            return;
        }
    })

    $(".jqititle").css({ "color": "#933432", "background-color": "#fddddd", "border-color": "#933432" });
}

//*** End:: Fixed Text

//*** Start:: Dynamic Text 

//Start:: Body  
function ShowMessageBox_YESNO(sMessage, title, sFunctionName) {
    $.prompt(sMessage, {
        zIndex: 20000,
        title: title,
        buttons: { "Yes": true, "No": false },
        submit: function (e, v, m, f) {
            eval(sFunctionName + "(" + v + ")");
        }
    })
    $(".jqititle").css({ "color": "#0a7c71", "background-color": "#cff5f2", "border-color": "#0a7c71" });
}

function ShowMessageBox_OKCANCEL(sMessage, title, sFunctionName) {
    $.prompt(sMessage, {
        zIndex: 20000,
        title: title,
        buttons: { "Ok": true, "Cancel": false },
        submit: function (e, v, m, f) {
            eval(sFunctionName + "(" + v + ")");
        }
    })
    $(".jqititle").css({ "color": "#0a7c71", "background-color": "#cff5f2", "border-color": "#0a7c71" });
}

function ShowMessageBox_YES(sMessage, title, sFunctionName) {
    $.prompt(sMessage, {
        zIndex: 20000,
        title: title,
        buttons: { "Yes": true },
        submit: function (e, v, m, f) {
            eval(sFunctionName + "(" + v + ")");
        }
    })
    $(".jqititle").css({ "color": "#0a7c71", "background-color": "#cff5f2", "border-color": "#0a7c71" });
}

function ShowMessageBox_OK(sMessage, title, sFunctionName) {
    $.prompt(sMessage, {
        zIndex: 20000,
        title: title,
        buttons: { "Ok": true},
        submit: function (e, v, m, f) {
            eval(sFunctionName + "(" + v + ")");
        }
    })
    $(".jqititle").css({ "color": "#0a7c71", "background-color": "#cff5f2", "border-color": "#0a7c71" });
}

function ShowMessageBox_OKFailed(sMessage, title, sFunctionName) {
    $.prompt(sMessage, {
        zIndex: 20000,
        title: title,
        buttons: { "Ok": true },
        submit: function (e, v, m, f) {
            eval(sFunctionName + "(" + v + ")");
        }
    })
    $(".jqititle").css({ "color": "#933432", "background-color": "#fddddd", "border-color": "#933432" });
}

// End:: Body 

//Start:: Footer  

//Information Operation
function ShowInfoMsg(message) {
    $.toast({
        heading: 'Welcome to my Elite admin',
        text: 'Use the predefined ones, or specify a custom position object.',
        position: 'top-right',
        loaderBg: '#ff6849',
        icon: 'info',
        hideAfter: 6500,
        stack: 6
    }); 
}
//Success Operation
function ShowSuccessMsg(message) {
    $.toast({
        heading: 'Welcome to my Elite admin',
        text: 'Use the predefined ones, or specify a custom position object.',
        position: 'top-right',
        loaderBg: '#ff6849',
        icon: 'success',
        hideAfter: 3500,
        stack: 6
    });
}

//Warning Operation
function ShowWarningMsg(message) {
    $.toast({
        heading: 'Required the fields.',
        text: 'Please fill the mandatory fields.',
        position: 'bottom-right',
        loaderBg: '#ff6849',
        icon: 'error',
        hideAfter: 3000

    });
} 
//End::  Message showing Functions


//Data List Related Global Function
// RETURN DATALIST VALUE FIELD
function GetValue(value, dataList) {
    var z = $(dataList);
    var val = $(z).find('option[value="' + value + '"]');
    var endval = val.attr('id');
    return endval;
}
function GetValue2(value, dataList, atr) {
    var z = $(dataList);
    var val = $(z).find('option[value="' + value + '"]');
    var endval = val.attr(atr);
    return endval;
}

function GetAttrValue(value, dataList, atr) {
    var z = $(dataList);
    var val = $(z).find('option[value="' + value + '"]');
    var endval = val.attr(atr);
    return endval;
}

// SET DATALIST BY VALUE
function SetValue(value, dataList) {
    var z = $(dataList);
    var val = $(z).find('option[id="' + value + '"]');
    var endval = val.val();
    $(dataList).prev().val(endval);
}

function SetValue2(value, dataList, txtBox) {
    var z = $(dataList);
    var val = $(z).find('option[id="' + value + '"]');
    var endval = val.val();
    $(txtBox).val(endval);
}

function SetValue3(value, dataList) {
    var z = $(dataList);
    var val = $(z).find('option[id="' + value + '"]');
    var endval = val.val();
    return endval;
}



