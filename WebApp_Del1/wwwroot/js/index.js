

// Hente alle mulige avgangshavner fra databasen når appen intansieres
$(function () {
    hentAlleHavner_Fra(); 

}); 



//Henter alle havner for første select i Gui ,
function hentAlleHavner_Fra() {
    $.get("billett/hentAlleHavner_Fra", function (listeAvHavner) {
        //alert(listeAvHavner);
        alert(listeAvHavner[0].HavnNavn);
        formaterHavner(listeAvHavner);
    });
};


function formaterHavner(listeAvHavner) {
    let ut = "Hei Fra oslo";
   for (let enHavn of listeAvHavner) {
       ut += "<option  style='font-size:24px' data-value=" + enHavn.HavnId + ">" + enHavn.HavnNavn + "</option>";
    }
    $("#fra").html(ut);
    console.log(ut.val);

};







/Gjør at bare et skjema viser om gangen. Dersom man trykker neste eller tilbake så endrer man skjema/

$('#regform2').hide();
$("#regform3").hide();

$("#hjemreise").hide();

$("#btnNeste").click(function () {
    $("#regform").hide();
    $("#regform2").show();
});
$("#btnTilbake1").click(function () {
    $("#regform2").hide();
    $("#regform").show();
});
$("#btnTilbake2").click(function () {
    $("#regform3").hide();
    $("#regform2").show();
});
$("#btnNeste2").click(function () {
    $("#regform2").hide();
    $("#regform3").show();
});

//Dersom det endres til "tur/retur vil det synliggjøres et nyttfelt for hjemreise" - dette fynker ikke enda/


$("#reisetype").change(function () {
    const reisetype = $("#reisetype").val();
    if (reisetype === "turRetur") {
        $('#hjemreise').show();
    } else {
        $('#hjemreise').hide();
    }
})

$("#fra").change(function () {
    const fra = $("#fra").val();
    $.post("")
})