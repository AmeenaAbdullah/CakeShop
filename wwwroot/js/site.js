﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    console.log("done");


    $("#seemore").click(function () {
        $("#div1").load("/Cake/getCakes");
    });


    $("#seemore").click(function () {
        $("#div1").load("/Cake/PlaceHolder");
    });

});