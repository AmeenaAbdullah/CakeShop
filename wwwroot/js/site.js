// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

 $(document).ready(function () {
   
    $("#seemore").click(function () {
        $("#div1").load("/Cake/getCakes");
        $("#seemore").attr('style', 'display:block');
    });

     $("#Searchbtn").click(function () {
         getCakesByValue();
     });
     $("#SearchCakes").keyup(function () {
         console.log("doneeeeeeekeyup");
         getCakesByValue();
     });

     $("#txtCustomerName").keyup(function () {
         console.log("doneeeeeee");
         var fullName = $('#txtCustomerName').val();
         var payload = { fullName: fullName }; // change name
         $.ajax({
             type: "POST",
             url: "/Cake/GetSearchData",
             data: payload, //remove JSON.stringify
             
             success: function (cakes) {
                 alert('Successfully received Data ');
                 console.log(cakes);
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
             ,
             error: function () {
                 alert('Failed to receive the Data');
                 console.log('Failed ');
             }
         });

    });

 });

//*********8Searching***********8
function getCakesByValue() {
    console.log("heloo search krooooo");
    var searchby = $("#SearchBy").val();
    var searcval = $("#SearchCakes").val();
    var container = $("#Componentcontainer");
    var payload = { searchby: searchby }; // change name
    var payload2 = { searcval: searcval }; // change name
    $.ajax({
        type: "POST",
        url: "/Cake/CakesViewComponent",
        data: payload, //remove JSON.stringify
        data: payload2,

        success: function (cakes) {
            alert('Successfully received Data ');
            console.log(cakes);
            container.html(cakes);

        }
        ,
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    }); 
}
