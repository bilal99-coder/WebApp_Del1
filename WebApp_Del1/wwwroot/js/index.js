

// Hente alle mulige avgangshavner fra databasen når appen intansieres
$(function () {
    hentAlleHavner_Fra(); 
 // hentAlleHavner_Fra1(); 
}); 

function hentAlleHavner_Fra1(){
    let requestURL = 'billett/hentAlleHavner_Fra';
    let request = new XMLHttpRequest();
    request.open('GET', requestURL);
    request.responseType = 'json';
    
    request.onload = function () {
        const superHeroes = request.response;
        console.log(superHeroes['HavnNavn']);
    }
    request.send();
}; 

//Henter alle havner for første select i Gui ,
function hentAlleHavner_Fra() {
    $.get("billett/hentAlleHavner_Fra", function (listeAvHavner) {
        //alert(listeAvHavner);
       // console.log(listeAvHavner[0].HavnNavn);
        //  console.log(Object.keys(listeAvHavner))
        console.log("The response listeAvHavner is:" + typeof listeAvHavner);
        formaterHavner(listeAvHavner);
    });


};


function formaterHavner(listeAvHavner) {
    let ut = "Hei Fra oslo";
    console.log(listeAvHavner);
    for (let enHavn of listeAvHavner) {
        ut += "<option  style='font-size:24px' data-value=" + enHavn.havnId + ">" + "Hilsen fra Database :): " + enHavn.havnNavn + "</option>";
       console.log(Object.keys(listeAvHavner));
       console.log(Object.values(enHavn));
       console.log(Object.values(enHavn)[1]);
       console.log(Object.entries(enHavn));
    }
    

    $("#fra").html(ut);
    console.log(ut);

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