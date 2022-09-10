// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

 $(document).ready(function () {
   
    $("#seemore").click(function () {
        $("#div1").load("/Cake/getCakes");
        $("#seemore").attr('style', 'display:block');
    });


     $("#txtCustomerName").keyup(function () {
         console.log("doneeeeeee");
         var customerName = $.trim($("#txtCustomerName").val());
         $.ajax({
             type: "POST",
             url: "/Cake/GetSearchData",
             data: "{customerName:'" + customerName + "'}",
             contentType: "application/json; charset=utf-8",
             dataType: "json",
             success: function (cakes) {
                 var table = $("#tblCustomers");
                 table.find("tr:not(:first)").remove();
                 $.each(cakes, function (i, cake) {
                     var table = $("#tblCustomers");
                     var row = table[0].insertRow(-1);
                     $(row).append("<td />");
                     $(row).find("td").eq(0).html(cake.Category);
                     $(row).append("<td />");
                     $(row).find("td").eq(1).html(cake.Price);
                     $(row).append("<td />");
                     $(row).find("td").eq(2).html(cake.Id);
                 });
             }
         });

    });

});