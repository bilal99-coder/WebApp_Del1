// Hente alle mulige avgangshavner fra databasen når appen intansieres

$(function () {
    hentAlleHavner_Fra();
    // hentAlleHavner_Fra1(); // fungerte også 
    // lagBillett();
    //dispalyVue3(1);
    //hentAlleHavnerTil(1);

    }); 

    /*
    let counter = 0; 
    
    
    
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
    */

    //Henter alle havner for første select i Gui

    function hentAlleHavner_Fra() {
        $.get("billett/hentAlleHavner_Fra", function (listeAvHavner) {
            //alert(listeAvHavner);
            // console.log(listeAvHavner[0].HavnNavn);
            //  console.log(Object.keys(listeAvHavner))
            console.log("The response listeAvHavner is:" + typeof listeAvHavner);
            formaterHavner(listeAvHavner);
        });


    };


    /*
    function hentAlleHavnerTil(id) {
        const option = $("#fraHavn_" + "" + id + "");
        $.post("billett/hentAlleHavnerTil?id=", option, function () {
            formaterHavnerTil();
        })

        console.log(option.val());
        //$.get("billett/hentAlleHavner_til", function (listeAvHavner) {
    }*/


    function formaterHavner(listeAvHavner) {
        let ut = "";
        console.log(listeAvHavner);
        for (let enHavn of listeAvHavner) {
            ut += "<option  style='font-size:20px' id ='fraHavn_'" + enHavn.havnId + "data-value=" + enHavn.havnId + ">" + enHavn.havnNavn + "</option>";
            console.log(Object.keys(listeAvHavner));
            console.log(Object.values(enHavn));
            console.log(Object.values(enHavn)[1]);
            console.log(Object.entries(enHavn));
        }


        $("#fra").html(ut);
        console.log(ut);

    };

    /*
    function formaterHavnerTil(listeAvHavner) {
        let ut = "";
        console.log(listeAvHavner);
        for (let enHavn of listeAvHavner) {
            ut += "<option  style='font-size:20px' id ='fraHavn_'" + enHavn.havnId + "data-value=" + enHavn.havnId + ">" + enHavn.havnNavn + "</option>";
            console.log(Object.keys(listeAvHavner));
            console.log(Object.values(enHavn));
            console.log(Object.values(enHavn)[1]);
            console.log(Object.entries(enHavn));
        }

    }*/


//Gjør at bare et skjema viser om gangen. Dersom man trykker neste eller tilbake så endrer man skjema/

$('#regform2').hide();
$("#regform3").hide();


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

//validerer antall barn og voksne

$("#btnNeste").click(function () {
    const antallVoksneOk = validerAntallvoksne($("#antallVoksen").val());
    const antallBarnOk = validerAntallBarn($("#antallBarn").val());
    if (antallVoksneOk && antallBarnOk) {
        $("#regform").hide();
        $("#regform2").show();
    }

});
//Dersom det endres til "tur/retur vil det synliggjøres et nyttfelt for hjemreise" - dette fynker ikke enda/

$("#hjemreise").hide();

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

//Validere om alle feltene er i orden for å få en kvittering

$("#btnFerdig").click(function () {
    const kortnummerOk = validerKortnummer($("#kortnummer").val());
    const cvcOk = validerCvc($("#cvc").val());
    const kortdatoOk = validerKortdato($("#kortdato").val());
    if (kortnummerOk && cvcOk && kortdatoOk) {
        lagreBestilling();
    }
});

//lager en kvittering basert på input

function lagreBestilling() {
    const bestilling = {
        reisetype: $("#reisetype").val(),
        fra: $("#fra").val(),
        til: $("#til").val(),
        utreise: $("#utreise").val(),
        hjemreise: $("#hjemreise").val(),
        antallVoksne: $("#antallVoksen").val(),
        antallBarn: $("#antallBarn").val(),
        fornavn: $("#fornavn").val(),
        etternavn: $("#etternavn").val(),
        epost: $("#epost").val()
    };
    const url = "Billett/LagreBillett"
    $.post(url, bestilling, function () {
        window.location.href = "kvittering.html";
    });
}