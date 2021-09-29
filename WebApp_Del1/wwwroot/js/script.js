$(function () {
    //Hent alle stasjoner ved document ready for første select. (Stasjonerfra)
    hentAlleStasjoner();

});

let stasjonerTilId;
let stasjonerId;
let pris;
let globAvgangTur;
let globAvgangRetur;

//Bekrefter kjøp med validering
function bekreftKjop() {

    validerCvc();
    validerKortnr();
    validerEpost();
    validerTlfnr();

    //validering
    if (validerCvc() && validerEpost() && validerKortnr() && validerTlfnr()) {

        //retur verdier
        let stasjonfra = $("#stasjoner").val();
        let tidtil = globAvgangRetur;
        let datotil = $("#returDato").val();
        let tidTilString = datotil + " " + tidtil;
        //tur verdier
        let stasjontil = $("#stasjonertil").val();
        let tidfra = globAvgangTur;
        let datofra = $("#turDato").val();
        let tidFraString = datofra + " " + tidfra;
        //Betalingsinformasjon
        let epost = $("#epost").val();
        let tlfNr = $("#tlfnr").val();
        let kortnummer = $("#kortnr").val();
        let cvc = $("#cvc").val();
        //url
        let url = "billett/kjopBillett";
        //fjerner buss ikon fra streng
        stasjonfra = stasjonfra.substring(1);
        stasjontil = stasjontil.substring(1);

        //Api kall for tur og retur
        if (document.getElementById("timetil").style.display === "block") {
            const billettRetur = {
                avgang: stasjontil,
                destinasjon: stasjonfra,
                tid: tidTilString,
                pris: pris,
                nummer: tlfNr,
                epost: epost,
                kortnummer: kortnummer,
                cvc: cvc
            }
            const billettTur = {
                avgang: stasjonfra,
                destinasjon: stasjontil,
                tid: tidFraString,
                pris: pris,
                nummer: tlfNr,
                epost: epost,
                kortnummer: kortnummer,
                cvc: cvc
            }
            //2 POST en for tur en for retur
            $.post(url, billettTur, function (OK) {
                if (OK) {
                    sessionStorage.setItem("billettTurId", OK);
                    // Hvis POST for tur er ok, kjør POST for retur.
                    $.post(url, billettRetur, function (OK) {
                        if (OK) {
                            let idag = new Date();
                            let dato = idag.getFullYear() + '-' + (idag.getMonth() + 1) + '-' + idag.getDate();
                            let tid = idag.getHours() + ":" + idag.getMinutes() + ":" + idag.getSeconds();
                            let datoOgTid = dato + ' ' + tid;
                            sessionStorage.setItem("pris", pris);
                            sessionStorage.setItem("tid", datoOgTid);
                            sessionStorage.setItem("billettReturId", OK);
                            window.location.href = "kvittering.html";
                        }
                        else {
                            console.log("Feil i db for retur - prøv igjen senere");
                        }
                    });
                }
                else {
                    console.log("Feil i db for tur - prøv igjen senere");
                }
            });
        }
        //Api kall for bare tur 
        else {
            const billettTur = {
                avgang: stasjonfra,
                destinasjon: stasjontil,
                tid: tidFraString,
                pris: pris,
                nummer: tlfNr,
                epost: epost,
                kortnummer: kortnummer,
                cvc: cvc
            }
            // POST for tur
            $.post(url, billettTur, function (OK) {
                if (OK) {
                    let idag = new Date();
                    let dato = idag.getFullYear() + '-' + (idag.getMonth() + 1) + '-' + idag.getDate();
                    let tid = idag.getHours() + ":" + idag.getMinutes() + ":" + idag.getSeconds();
                    let datoOgTid = dato + ' ' + tid;
                    sessionStorage.setItem("tid", datoOgTid);
                    sessionStorage.setItem("pris", pris);
                    sessionStorage.setItem("billettTurId", OK);
                    sessionStorage.removeItem("billettReturId");
                    window.location.href = "kvittering.html";
                }
                else {
                    $("#feil").html("Feil i db for tur - prøv igjen senere");
                }
            });
        }

    }

}






























//Jeg starter med å hente reiseinfo


const reiseType = document.getElementById('reisetype'); 
const fra = document.getElementById('fra'); 
const til = document.getElementById('til'); 
const utreise = document.getElementById('utreise'); 
const antallVoksne = document.getElementById('antallVoksne'); 
const antallBarn = document.getElementById('antallBarn'); 
const next = document.getElementById('btnNeste');
const btnSubmit = document.getElementById('submitBtn'); 


class Reiseinfo{
     name = "aname";
     reiseType = reiseType.options[reiseType.selectedIndex].value; // Med jquery can man bruke:   $('#reisetype').val()
     fraSted =  fra.options[fra.selectedIndex].value;
     tilSted = til.options[til.selectedIndex].value; 
     utreiseDato = utreise.value;
     antallVoksne = antallVoksne.value;
     antallBarn = antallBarn.value; 
}


btnSubmit.addEventListener('click', () => {
  
})

const test = new Reiseinfo(); 
console.log(test.name); 
 









console.log("HEI")



/*Gjør slik at man ikke kan velge samme by på fra og til feltene*/
$("#fra").change(function () {
    $("#til").find("option").each(function () {
        $(this).removeAttr("disabled");
    });
    $("#til [value=" + $(this).val() + "]").attr("disabled", "disabled");
})

$("#til").change(function () {
    $("#fra").find("option").each(function () {
        $(this).removeAttr("disabled");
    });
    $("#fra [value=" + $(this).val() + "]").attr("disabled", "disabled");
})
/*Gjør at bare et skjema viser om gangen. Dersom man trykker neste eller tilbake så endrer man skjema*/

$('#regform2').hide();
$("#lugar-container").hide();
//$("#container").hide();
$("#regform33").hide();
$("#regform3").hide();




$("#btnNeste").click(function () {
    $("#container").hide();
    $("#lugar-container").show();
});
$("#btnTilbake1").click(function () {
    $("#regform2").hide();
    $("#regform").show();
});
$("#btnTilbake2").click(function () {
    $("#personForm").hide();
    $("#regform2").show();
});
$("#btnNeste2").click(function () {
    $("#regform2").hide();
    $("#regform3").show();
});

$("#submitBtn").click(function () {
    $("#regform3").hide();
    $("#Billett").show();
});
$("#btnTilbake2").click(function () {
    $("#regform3").hide();
    $("#Billett").show();
});



/*  console.log('button was clicked');
    console.log('hello2');
    console.log($('#reisetype').val()); 
    console.log($('#fra').val()); 
    let reiseTypen = reiseType.options[select.selectedIndex].value;
    console.log(reiseTypen+"22222"); 
    console.log(reiseType.options[select.selectedIndex].value+"3333333");
    
    const info = new Reiseinfo(); 
    console.log("fra sted er: " + info.name);
    console.log("fra sted er: " + info.name);*/


    /*const info = new Reiseinfo(); 
console.log("fra sted er: " + info.name);
console.log("fra sted er: " + info.name);


var select = document.getElementById('reisetype');
var value = select.options[select.selectedIndex].value;
console.log(value); 

const reiseTypenn = reiseType.options[select.selectedIndex].value;
console.log(reiseTypenn);*/

/*
//JQuery code
$('#submitBtn').click(function(){
    console.log("button is now clicked");
    $('#console').html( $('#console').html() + '#foo is now visible'+ '<br>'  ) ;
}); */