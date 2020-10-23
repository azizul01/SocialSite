$(document).ready(function () {
    Load_BatchStatus();
    Load_Process_Parameters('ddlLine', 'LINE_NUMBER_CERAMIC');
    Load_Process_Parameters('ddlGrade', 'CERAMIC_GRADE_MAPPING');
    Ceramics_Flex_Values('ddlSize', 'DBL_SALES_MINOR');
    Ceramics_Look_Up_Values('ddlShift', 'DBLCL_SHIFT_WISE_TIMING');
    Load_Process_Parameters('ddlLine_SORTING', 'SORTING_LINE_NUMBER_CERAMIC');
    Load_ItemFT();
    Load_Description();
    Load_FormulaNo();
    Load_FormulaDescription();

    $("#txtCounter").on('input', function () {
        if ($(this).val().length > 0) {
            $(this).val($(this).val().toUpperCase());
        }
    });
});



function Ceramics_Flex_Values(ListName, PARAMETER_NAME) {
    $("#" + ListName + " option").remove();
    $.ajax({
        async: false,
        type: "POST",
        url: base + "Ceramic/Load_Ceramics_Flex_Values",
        dataType: "JSON",
        data: JSON.stringify({
            "PARAMETER_NAME": PARAMETER_NAME
        }),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data.length != undefined) {
                var content = '';
                $.each(data, function (i, obj) {
                    content += '<option value="' + obj[1] + '">' + obj[1] + '</option>';
                });
                $("#" + ListName).append('<option value="-1">Select</option>' + content);
            }
        }
    });
}

function Load_Process_Parameters(ListName, PARAMETER_NAME) {
    $("#" + ListName + " option").remove();
    $.ajax({
        async: false,
        type: "POST",
        url: base + "Ceramic/Load_Ceramic_Process_Parameters",
        dataType: "JSON",
        data: JSON.stringify({
            "PARAMETER_NAME": PARAMETER_NAME
        }),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data.length != undefined) {
                var content = '';
                $.each(data, function (i, obj) {
                    content += '<option value="' + obj[0] + '">' + obj[1] + '</option>';
                });
                $("#" + ListName).append('<option value="-1">Select</option>' + content);
            }
        }
    });
}

function Ceramics_Look_Up_Values(ListName, PARAMETER_NAME) {
    $("#" + ListName + " option").remove();
    $.ajax({
        async: false,
        type: "POST",
        url: base + "Ceramic/Load_Ceramics_Look_Up_Values",
        dataType: "JSON",
        data: JSON.stringify({
            "PARAMETER_NAME": PARAMETER_NAME
        }),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data.length != undefined) {
                var content = '';
                $.each(data, function (i, obj) {
                    content += '<option value="' + obj[0] + '">' + obj[0] + ' - ' + obj[1] + '</option>';
                });
                $("#" + ListName).append('<option value="-1">Select</option>' + content);
            }
        }
    });
}


function Load_BatchStatus() {
    $("#ddlBatchStatus  option").remove();
    $.ajax({
        async: false,
        type: "POST",
        url: base + "Ceramic/Load_Batch_Status",
        dataType: "JSON",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var content = '';
            $.each(data, function (i, obj) {
                content += '<option value="' + obj[0] + '">' + obj[1] + '</option>';
            });
            $("#ddlBatchStatus").append('<option value="-1">All</option>' + content);
        },
        error: function (a, b, c) { alert(formatErrorMessage(a, c) + "...LoadDia"); }

    });
}

function Load_ItemFT() {
    $('#ddlItemCodeFT option').remove();
    $.ajax({
        async: false,
        type: "POST",
        url: base + "Ceramic/Load_Item_LIST_FT",
        dataType: "JSON",
        data: JSON.stringify({
            "ORG__ID": '152'
        }),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data.length != undefined) {
                var content = '';
                $.each(data, function (i, obj) {
                    content += '<option value="' + obj[0] + '">' + obj[1] + '</option>';
                });
                $('#ddlItemCodeFT').append('<option value="-1">Select</option>' + content);
            }
        }
    });
}

function Load_Description() {
    $('#ddlDescription option').remove();
    $.ajax({
        async: false,
        type: "POST",
        url: base + "Ceramic/Load_Description",
        dataType: "JSON",
        data: JSON.stringify({
            "ORG__ID": '152'
        }),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data.length != undefined) {
                var content = '';
                $.each(data, function (i, obj) {
                    content += '<option value="' + obj[0] + '">' + obj[0] + '</option>';
                });
                $('#ddlDescription').append('<option value="-1">Select</option>' + content);
            }
        }
    });
}

function Load_FormulaNo() {
    $('#ddlFormula option').remove();
    $.ajax({
        async: false,
        type: "POST",
        url: base + "Ceramic/Load_FormulaNO",
        dataType: "JSON",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data.length != undefined) {
                var content = '';
                $.each(data, function (i, obj) {
                    content += '<option value="' + obj[0] + '">' + obj[1] + '</option>';
                });
                $('#ddlFormula').append('<option value="-1">Select</option>' + content);
            }
        }
    });
}

function Load_FormulaDescription() {
    $('#ddlFormulaDescription option').remove();
    $.ajax({
        async: false,
        type: "POST",
        url: base + "Ceramic/Load_FormulaDescription",
        dataType: "JSON",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data.length != undefined) {
                var content = '';
                $.each(data, function (i, obj) {
                    content += '<option value="' + obj[0] + '">' + obj[0] + '</option>';
                });
                $('#ddlFormulaDescription').append('<option value="-1">Select</option>' + content);
            }
        }
    });
}


