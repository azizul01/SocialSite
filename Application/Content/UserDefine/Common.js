
//var base = '@Url.Content("~/")';

$(document).ready(function () {
    Load_Unit();
    Load_Organization('0');
    Load_ItemCategory();
    Load_SubInventory();
    //Load_Unit_Floor();
    //Load_Supplier_List();
    //Load_Item_Category_List();ddlUnit
    $("#ddlUnit").change(function () {
        var UNIT_ID = $.trim($('#ddlUnit').val());
        Load_Organization(UNIT_ID);
        Load_Unit_Floor(UNIT_ID);
    });

    $("#ddlOrganization").change(function () {
        //load_StoreReceive();
    });

});


//function Load_Unit() {
//    $('#ddlUnit option').remove();
//    $.ajax({
//        async: false,
//        type: "POST",
//        url: base + "Home/Load_Unit_LIST",
//        dataType: "JSON",
//        contentType: "application/json;charset=utf-8",
//        success: function (data) {
//            if (data.length != undefined) {
//                var content = '';
//                $.each(data, function (i, obj) {
//                    content += '<option value="' + obj[0] + '">' + obj[1] + '</option>';
//                });
//                $('#ddlUnit').append( '<option value="-1">Select</option>' + content);
//            }
//        }
//    });
//}


function Load_Unit() {
    $('#ddlUnit option').remove();
    $.ajax({
        async: false,
        type: "POST",
        url: base + "Home/Load_Unit_LIST_With_ALL",
        dataType: "JSON",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data.length != undefined) {
                var content = '';
                $.each(data, function (i, obj) {
                    content += '<option value="' + obj[0] + '">' + obj[1] + '</option>';
                });
                $('#ddlUnit').append('<option value="-1">Select</option>' + content);
            }
        }
    });
}

function Load_Unit_Floor(UNIT_ID) {
    //$('#ddlUnitFloor option').remove();
    $.ajax({
        async: false,
        type: "POST",
        url: base + "Home/Load_Unit_Floor",
        dataType: "JSON",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify({
            "Lookup_Type": "XXDBL_USE_AREA_UNIT",
            "Unit_ID": UNIT_ID
        }),
        success: function (data) {
            if (data.length != undefined) {
                var content = '';
                $.each(data, function (i, obj) {
                    content += '<option value="' + obj[0] + '">' + obj[0] + '</option>';
                });
                $('#ddlUnitFloor').append('<option value="-1">Select</option>' + content);
            }
        }
    });
}

function Load_ItemCategory() {
    $('#ddlItemCategory option').remove();
    $.ajax({
        async: false,
        type: "POST",
        url: base + "Home/Load_Item_LIST",
        dataType: "JSON",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data.length != undefined) {
                var content = '';
                $.each(data, function (i, obj) {
                    content += '<option value="' + obj[0] + '">' + obj[0] + '</option>';
                });
                $('#ddlItemCategory').append('<option value="-1">Select</option>' + content);
            }
        }
    });
}

function Load_Organization(Unit) {
    $('#ddlOrganization option').remove();
    $.ajax({
        async: false,
        type: "POST",
        url: base + "Home/Load_ORG_LIST",
        dataType: "JSON",
        data: JSON.stringify({ "OPERATING_UNIT": Unit }),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data.length != undefined) {
                var content = '';
                $.each(data, function (i, obj) {
                    content += '<option value="' + obj[0] + '">' + obj[1] + '</option>';
                });
                $('#ddlOrganization').append('<option value="-1">Select</option>' + content);
            }
        }
    });
}


function Load_SubInventory() {
    $('#ddlSubInventory option').remove();
    $.ajax({
        async: false,
        type: "POST",
        url: base + "Home/Load_SubInventory_LIST",
        dataType: "JSON",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data.length != undefined) {
                var content = '';
                $.each(data, function (i, obj) {
                    content += '<option value="' + obj[0] + '">' + obj[0] + '</option>';
                });
                $('#ddlSubInventory').append('<option value="-1">Select</option>' + content);
            }
        }
    });
}


//PO Waiting For Receiving Report 

function Load_Supplier_List() {
    $("#dlSupplier option").remove();
    $.ajax({
        async: false,
        type: "POST",
        url: base + "Home/Load_Supplier",
        dataType: "JSON",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var content = '';
            $.each(data, function (i, obj) {
                content += '<option value="' + obj[0] + '" id="' + obj[1] + '"></option>';
            });
            $("#dlSupplier").append(content);
        },
        error: function (a, b, c) { alert(formatErrorMessage(a, c) + "...LoadDia"); }

    });
}

//function Load_Unit_Floor() {
//    $("#dlUnit_Floor1 option").remove();
//    $.ajax({
//        async: false,
//        type: "POST",
//        url: base + "Home/Load_Unit_Floor",
//        data: JSON.stringify({ "Lookup_Type": "XXDBL_USE_AREA_UNIT" }),
//        dataType: "JSON",
//        contentType: "application/json;charset=utf-8",
//        success: function (data) {
//            var content = '';
//            console.log(data);
//            $.each(data, function (i, obj) {               
//                content += '<option value="' + obj[0] + '" id="' + obj[0] + '"></option>';
//            });
//            console.log(content);
//            $("#dlUnit_Floor1").append(content);
//        },
//        error: function (a, b, c) { alert(formatErrorMessage(a, c) + "...LoadDia"); }

//    });
//}



