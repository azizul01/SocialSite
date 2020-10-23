function LoadJqueryDataTable_old(vTitle, vFileName, vTbodyHeight, vPageLength, vTargetsColumn) {
    $('.sample_2').DataTable({
        dom: 'Bfrtip',
        'autoWidth': false,
        "pageLength": vPageLength, //10,
        "scrollX": true,
        "scrollY": vTbodyHeight + "px", //"250px", 
        "scrollCollapse": true,
        //scroller: true,
        fixedHeader: {
            header: true,
            footer: false
        }, 
        columnDefs: [{
            //targets: -1,
            //visible: false
        }],
        buttons: [
            'copy',
            {
                extend: 'csv',
                footer: true,
                orientation: 'landscape',
                pageSize: 'LEGAL',
                title: vTitle,//'Bank Information',
                filename: vFileName,//'BankInformation',
                exportOptions: {
                    //columns: ':visible'
                    columns: [vTargetsColumn]
                }
            },
            {
                extend: 'excel',
                footer: true,
                orientation: 'landscape',
                pageSize: 'LEGAL',
                title: vTitle,//'Bank Information',
                filename: vFileName,//'BankInformation',
                exportOptions: {
                    //columns: ':visible'
                    columns: [vTargetsColumn]
                }
            },
            {
                extend: 'pdf',
                footer: true,
                orientation: 'landscape',
                pageSize: 'LEGAL',
                title: vTitle, //'Bank Information',
                filename: vFileName,//'BankInformation',
                exportOptions: {
                    //columns: ':visible'
                    columns: [vTargetsColumn]
                }
            },
            {
                extend: 'print',
                footer: true,
                //orientation: 'portrait',
                //pageSize: 'A4',
                orientation: 'landscape',
                pageSize: 'LEGAL',
                text: 'Print',
                title: vTitle,//'Bank Information',
                autoPrint: true,
                exportOptions: {
                    columns: [vTargetsColumn]
                    //columns: [ 2,3 ]//, //Your Colume value those you want
                    //columns: ':visible'//, 
                }
                //,
                //customize: function (win) {
                //    var footer = $('tfoot');
                //    if (footer.length > 0) {
                //        var exportFooter = $(win.document.body).find('thead:eq(2)');
                //        exportFooter.after(footer.clone());
                //        exportFooter.remove();
                //    }
                //}
            }
        ]
    });
}

function LoadJqueryDataTable(vTitle, vFileName, vTbodyHeight, vPageLength, vTargetsColumn) { 
    $('.sample_2').DataTable({
        dom: 'Bfrtip',
        //'autoWidth': false,
        "pageLength": 10, //vPageLength, //10,
        //"scrollX": true,
        //"scrollY": vTbodyHeight + "px", //"250px", 
        //"scrollCollapse": true,
        ////scroller: true,
        //fixedHeader: {
        //    header: true,
        //    footer: false
        //},
        //columnDefs: [{
        //    //targets: -1,
        //    //visible: false
        //}],
        buttons: [ 
            {
                extend: 'copy',
                footer: true,
                orientation: 'landscape',
                pageSize: 'LEGAL',
                title: vTitle,//'Bank Information',
                filename: vFileName,//'BankInformation',
                exportOptions: {
                    //columns: ':visible'
                    columns: [vTargetsColumn]
                }
            },
            {
                extend: 'csv',
                footer: true,
                orientation: 'landscape',
                pageSize: 'LEGAL',
                title: vTitle, 
                filename: vFileName, 
                exportOptions: { 
                    columns: [vTargetsColumn]
                }
            },
            {
                extend: 'excel',
                footer: true,
                orientation: 'landscape',
                pageSize: 'LEGAL',
                title: vTitle, 
                filename: vFileName, 
                exportOptions: { 
                    columns: [vTargetsColumn]
                }
            },
            {
                extend: 'pdf',
                footer: true,
                orientation: 'landscape',
                pageSize: 'LEGAL',
                title: vTitle,  
                filename: vFileName, 
                exportOptions: {
                    columns: [vTargetsColumn]
                }
            },
            {
                extend: 'print',
                footer: true,
                orientation: 'landscape',
                pageSize: 'LEGAL',
                text: 'Print',
                title: vTitle, 
                autoPrint: true,
                exportOptions: {
                    columns: [vTargetsColumn]
                }
            }
        ]
    });
}