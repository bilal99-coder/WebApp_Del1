﻿// Hente alle mulige avgangshavner fra databasen når appen intansieres

$(function () {
    hentAlleHavner_Fra();
    oppgiHavnerTil(); 
    dispalyVue3();
    oppdaterPris();
});



//datepicker. kan ikke velge tidligere datoer på utreise - kode funnet på nettet

$(function () {
    var dateFormat = "mm/dd/yy",
        from = $("#utreise")
            .datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: '2011:2037',
                minDate: 0,
                defaultDate: null,
                showAnim: "fold",
                showButtonPanel: true,
            })
            .on("change", function () {
                to.datepicker("option", "minDate", getDate(this));
            }),
        to = $("#hjemreise").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: '2011:2037',
            minDate: 0,
            defaultDate: null,
            showAnim: "fold",
            showButtonPanel: true,
        })
            .on("change", function () {
                from.datepicker("option", "maxDate", getDate(this));
            });

    function getDate(element) {
        var date;
        try {
            date = $.datepicker.parseDate(dateFormat, element.value);
        } catch (error) {
            date = null;
            alert("hei")
        }

        return date;
    }
});


function oppdaterPris() {
    //Vise prisen
    $("#pris").css("display", "block"); let valgteAkomstHavnen__Id;
    let pris = 0; $('#fra').on('change', function () {
        valgteAkomstHavnen__Id = $("#til option:selected").attr("id");
        console.log("valgte ankomstHavnen / Kommer fra linjen 131 i index.js ----> " + valgteAkomstHavnen__Id);
        $.ajax({
            type: 'POST',
            url: "billett/returnPris?id=" +
                encodeURIComponent(valgteAkomstHavnen__Id),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                beregnTotalPris(response);
                pris = response;
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    });
    $('#til').on('change', function () {
        valgteAkomstHavnen__Id = $("#til option:selected").attr("id");
        console.log("valgte ankomstHavnen / Kommer fra linjen 131 i index.js ----> " + valgteAkomstHavnen__Id);
        $.ajax({
            type: 'POST',
            url: "billett/returnPris?id=" +
                encodeURIComponent(valgteAkomstHavnen__Id),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                beregnTotalPris(response);
                pris = response;
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }); $("#reisetype").on('change', function () {
        valgteAkomstHavnen__Id = $("#til option:selected").attr("id");
        console.log("valgte ankomstHavnen / Kommer fra linjen 131 i index.js ----> " + valgteAkomstHavnen__Id);
        $.ajax({
            type: 'POST',
            url: "billett/returnPris?id=" +
                encodeURIComponent(valgteAkomstHavnen__Id),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                beregnTotalPris(response);
                pris = response;
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }); $("#antallVoksne").on('change', function () {
        valgteAkomstHavnen__Id = $("#til option:selected").attr("id");
        console.log("valgte ankomstHavnen / Kommer fra linjen 131 i index.js ----> " + valgteAkomstHavnen__Id);
        $.ajax({
            type: 'POST',
            url: "billett/returnPris?id=" +
                encodeURIComponent(valgteAkomstHavnen__Id),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                beregnTotalPris(response);
                pris = response;
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }); $("#antallBarn").on('change', function () {
        if ($("#antallBarn").val() > 0) {
            $("#antallBarnSpan").show();
            valgteAkomstHavnen__Id = $("#til option:selected").attr("id");
            console.log("valgte ankomstHavnen / Kommer fra linjen 131 i index.js ----> " + valgteAkomstHavnen__Id);
            $.ajax({
                type: 'POST',
                url: "billett/returnPris?id=" +
                    encodeURIComponent(valgteAkomstHavnen__Id),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    beregnTotalPris(response);
                    pris = response;
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        else {
            $("#antallBarnSpan").hide();
        }
    });
    console.log(" iden valgte ankomstHavnen er " + valgteAkomstHavnen__Id); //Kall på ajax for prisen til valgte ankomst havnen

}


function beregnTotalPris(response) {
    let totalPrisen = 0;
    let rutePrisen = response;
    totalPrisen = rutePrisen;
    let reisetype = $("#reisetype").val();
    if (reisetype == 'turRetur') {
        totalPrisen = rutePrisen * 2;
    } else if (reisetype != 'turRetur') {
        totalPrisen = response;
    }
    let antallVoksne = $("#antallVoksne").val();
    let antallBarn = $("#antallBarn").val();
    totalPrisen = totalPrisen + (rutePrisen * antallVoksne); // Barn betaler halv prisen //totalPrisen += (rutePrisen *antallBarn) / 2;
    $("#pris").html(totalPrisen);
    console.log(rutePrisen);
    console.log(reisetype);
    console.log(antallVoksne);
    console.log(antallBarn);
}



/*
$(function () {
    $("#utreise").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: '2011:2037',
        dateFormat: 'dd/mm/yy',
        minDate: 0,
        defaultDate: null,
        showAnim: "fold",
        showButtonPanel: true,
    }).on('select', function () {


        $(this).valid();

        // triggers the validation test
        // '$(this)' refers to '$("#datepicker")'

    });
});

$(function () {

    $("#hjemreise").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: '2011:2037',
        dateFormat: 'dd/mm/yy',
        minDate: 0,
        defaultDate: null,
        showAnim: "fold",
        showButtonPanel: true,
    }).on('select', function () {
        $(this).valid();  // triggers the validation test
        // '$(this)' refers to '$("#datepicker")'

    });
});*/

/*
$(function () {
    $('#departure-date').datepicker({
        numberOfMonths: 2,
        showAnim: "fold",
        showButtonPanel: true,
        onSelect: (function () {
            $('#return-date').focus();
        })
    });

    $('#return-date').datepicker({
        numberOfMonths: 2,
        showAnim: "fold",
        showButtonPanel: true,
        onSelect: (function () {

        })
    });
});
*/


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

function display2() {
    $('#fra').on('change', function () {
        let $op = $('#fra option:selected');
        let Havn_PåTxt = $op.text();
       /* let id = $('#fra option').filter(function () {
            return this.value == val;
        }).data('value');*/
        let id = $("#fra option:selected").attr("id");
        console.log(id);

        hentAlleHavnerTil(id);
        console.log($op.text());
    });
}

// Funksjon som oppgir havner til når kunden åpner nettsiden 

function oppgiHavnerTil() {
    $.ajax({
        type: "POST",
        url: "billett/hentAlleHavnerTil?id=" + 1,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            formaterHavnerTil(result);
        },
        failure: function (response) {
            alert(response.d);
        }

    }); 

}





function hentAlleHavnerTil(id) {
    // Kall på ajax for havner til 
    $.ajax({
        type: "POST",
        url: "billett/hentAlleHavnerTil?id=" +
            encodeURIComponent(id),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            formaterHavnerTil(result);
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}




//Formaterer havnertil med ikon
//Formaterer havnertil

function formaterHavnerTil(Havner) {
    let ut = "";
    for (let enHavn of Havner) {
        ut += "<option class='fa-bus' style='font-size:20px' id ='" + enHavn.havnId + "' " + " >" + enHavn.havnNavn + "</option>"
    }
    $("#til").html(ut);
    console.log(ut);
}

//formaterhavner

function formaterHavner(listeAvHavner) {
    let ut = "";
    console.log(listeAvHavner);
    for (let enHavn of listeAvHavner) {
        console.log(enHavn.havnId);
        ut += "<option  style='font-size:20px' id ='" + enHavn.havnId + "' " + "data-value=" + enHavn.havnId + ">" + enHavn.havnNavn + "</option>";
       console.log(Object.keys(listeAvHavner));
       console.log(Object.values(enHavn));
       console.log(Object.values(enHavn)[1]);
       console.log(Object.entries(enHavn));
    }
    $("#fra").html(ut);
    console.log(ut);

};


/*
// Når kunden bekrefter kjøpet 
function bekreftKjoop() {
    //Kaller funksjonen 
    lagBillett(); 
    $.ajax({
        type: "POST",
        url: "TelephoneNumbers.aspx/DeleteNumber",
        data: data0,

        success: function (data) {
            alert('Done');
        }
    });
}
    */
/*
function lagBillett() {
    let billett = {
        reiseType: $("select#reisetype").filter(":selected").text(),
        fra: $("select#fra").filter(":selected").text(),
        til: $("select#til").filter(":selected").text(),
        //  utreise: $("utreise").data("datetimepicker").getDate(),
        
        // antallVoksneStreng:  document.getElementById("antallVoksen").value, 
        //antallVoksne = Number(antallVoksneStreng),
   
       // antallBarn = Number($("antallBarn").text()),
        //antallReisende = antallBarn + antallVoksne

        antallReisende: {
            CountAlleReisende: function () {
                const antallVoksne = parseInt($("antallVoksen").text());
                const antallBarn = parseInt($("antallVoksen").text());
                const antallReisende = antallBarn + antallVoksne;
            }
        }
    }

    
    console.log(billett.reiseType);
}*/

/*
function count_AndReturn_Persons() {
    //Telle antall personer som e med i billetten 
    const antallVoksne = parseInt($("antallVoksen").text()); 
    const antallBarn = parseInt($("antallVoksen").text());
    const antallReisende = antallBarn + antallVoksne;
    let persons_counter = count + antallReisende;
    let personene = [];
    for (let i = 0; i < persons_counter; i++)
    {
        const person = {
            fornavn: $("#person_fornavn"+i).text(),
            etternavn: $("#person_etternavn"+i).text(),
            epost: $("#person_email" + i).text()
        }; 
        personene.push(person); 
    };
    return personene;
}*/


function dispalyVue3(accept) {
    if (accept === 1) {

        //Telle antall personer som e med i billetten 
        const antallVoksne = parseInt($("antallVoksen").val()); ////
        const antallBarn = parseInt($("antallVoksen").val());
        const antallVoksne_val = parseInt(antallVoksne);
        console.log(antallVoksne_val);
        console.log(parseInt(document.getElementById("antallVoksen").value));

        const antallReisende = antallBarn + antallVoksne;
        let persons_counter = 2;//antallVoksne;
        let barn_counter = 2; //antallBarn;
        console.log(antallVoksne);
        console.log(antallBarn); 
        //Disable the ability to delete the first person 

        $("#personer").html("");
        for (i = 1; i <= persons_counter; i++) {

            $('<div class="dynamic' + ' person' + i + ' "' + ' id=dynamicPerson-container_' + i + '>' +


                '<div class="row' + ' person' + i + ' "' + ' id=rowPerson_' + i + '>' +
                '<label for="person" ' + i + ' class="col-sm-3 control-label" ' + ' style= "font-size: 29px" >' +
                ' Person ' + i + ' </i> ' +
                '</label>' +
                '<div class="col">' +
                '<label for="fornavn"' + 'style = "font-size: 16px"' + '>Fornavn</label>' +
                '<input type="text" class="form-control" id="person_fornavn_"' + i + '/>' +
                '</div >' +

                '<div class="col">' +
                '<label for="etternavn"' + 'style= "font-size: 16px"' + '>Etternavn</label>' +
                '<input type="text" class="form-control" id="person_etternavn_"' + i + '/>' +
                '</div >' +
                '</div>' +

                '<div class="form-group">' +
                '<label for="epost"' + 'style= "font-size: 16px"' + '>Epost</label>' +
                '<input type="email" class="form-control" id="person_epost_"' + i + '/>' +
                ' </div>' +

                ' <button type="button" class="btn btn-primary" id="leggTilPerson_' + i + '" > Legg til </button> ' +
                ' <button type="button" class="btn btn-primary"' + 'id="endrePerson_' + i + '"' + 'style = "background-color:rgb(199,0,0); border: none"' + 'onclick=' + 'slettEnPerson(' + i + ')' + '>' + 'Slett </button> ' +

                '</div>' +
                '</div>').appendTo("#personer");
        }

            for (i = 1; i <= barn_counter; i++) {
                $('<div class="dynamic' + ' barn' + i + ' "' + ' id=dynamicBarn-container_' + i + '>' +


                    '<div class="row' + ' barn' + i + ' "' + ' id=rowBarn_' + i + '>' +
                    '<label for="Barn" ' + i + ' class="col-sm-3 control-label" ' + ' style= "font-size: 29px" >' +
                    ' Barn ' + i + ' </i> ' +
                    '</label>' +
                    '<div class="col">' +
                    '<label for="fornavn"' + 'style = "font-size: 16px"' + '>Fornavn</label>' +
                    '<input type="text" class="form-control" id="barn_fornavn_"' + i + '/>' +
                    '</div >' +

                    '<div class="col">' +
                    '<label for="etternavn"' + 'style= "font-size: 16px"' + '>Etternavn</label>' +
                    '<input type="text" class="form-control" id="barn_etternavn_"' + i + '/>' +
                    '</div >' +
                    '</div>' +

                    '<div class="form-group">' +
                    '<label for="epost"' + 'style= "font-size: 16px"' + '>Epost</label>' +
                    '<input type="email" class="form-control" id="barn_epost_"' + i + '/>' +
                    ' </div>' +

                    ' <button type="button" class="btn btn-primary" id="leggTilBarn_' + i + '" > Legg til </button> ' +
                    ' <button type="button" class="btn btn-primary"' + 'id="endreBarn_' + i + '"' + 'style = "background-color:rgb(199,0,0); border: none"' + 'onclick=' + 'slettEnBarn(' + i + ')' + '>' + 'Slett </button> ' +

                    '</div>' +
                    '</div>').appendTo("#personer");
            }



                console.log("Iam here dispalyvue3()");
                $("#endrePerson_1").prop("disabled", true);

            
        }
}


    
    /*
    function countAlleReisende() {
        //Telle antall personer som e med i billetten 
        const antallVoksne = parseInt($("antallVoksen").text());
        const antallBarn = parseInt($("antallVoksen").text());
        const antallReisende = antallBarn + antallVoksne;
        // a counter that listens to changes in case of deleting a person
        let persons_counter = antallReisende + counter;
        return antallReisende;
    }

    function slettEnPerson(id) {
        //$("#dynamicPerson-container_" + "" + id + "").hide();
        counter--;

        $("#dynamicPerson-container_" + "" + id + "").remove();

        console.log(id);
        console.log("rowPerson_" + "" + id + "");
    }


function slettEnBarn(id) {
    //$("#dynamicPerson-container_" + "" + id + "").hide();
    counter--;

    $("#dynamicBarn-container_" + "" + id + "").remove();

    console.log(id);
    console.log("rowPerson_" + "" + id + "");
}

*/




function display2() {
    $('#fra').on('change', function () {
        let $op = $('#fra option:selected');
        let Havn_PåTxt = $op.text();
        /* let id = $('#fra option').filter(function () {
        return this.value == val;
        }).data('value');*/
        let id = $("#fra option:selected").attr("id");
        console.log(id);



        hentAlleHavnerTil(id);
        console.log($op.text());
    });
}








    //Gjør at bare et skjema viser om gangen. Dersom man trykker neste eller tilbake så endrer man skjema/

$('#regform2').hide();
$("#regform3").hide();
$('#hjemreiseLabel').hide();


    $("#btnTilbake1").click(function () {
        $("#regform2").hide();
        $("#regform").show();
    });
    $("#btnTilbake2").click(function () {
        $("#regform3").hide();
        $("#regform2").show();
    });

$("#btnNeste2").click(function () {
    const fornavnOk = validerFornavn($("#fornavn").val());
    const etternavnOk = validerEtternavn($("#etternavn").val());
    const epostOk = validerEpost($("#epost").val());
    if (fornavnOk && etternavnOk && epostOk) {
        $("#regform2").hide();
        $("#regform3").show();
    }
});

    //validerer første side

$("#btnNeste").click(function () {
    const reisetype = $("#reisetype").val();
        if (reisetype === "turRetur") {
            const antallVoksneOk = validerAntallVoksne($("#antallVoksne").val());
            const antallBarnOk = validerAntallBarn($("#antallBarn").val());
            const utreisetreiseOk = validerUtreise($("#utreise").val());
            const hjemreiseOk = validerHjemreise($("#hjemreise").val());
            if (antallVoksneOk && antallBarnOk && utreisetreiseOk && hjemreiseOk) {
                $("#regform").hide();
                $("#regform2").show();
            } 
        } else if (reisetype === "enVei") {
            const antallVoksneOk = validerAntallVoksne($("#antallVoksne").val());
            const antallBarnOk = validerAntallBarn($("#antallBarn").val());
            const utreisetreiseOk = validerUtreise($("#utreise").val());
            if (antallVoksneOk && antallBarnOk && utreisetreiseOk) {
                $("#regform").hide();
                $("#regform2").show();
            }
        }
     
    });


    //Dersom det endres til "tur/retur vil det synliggjøres et nyttfelt for hjemreise
    $("#hjemreise").hide();

    $("#reisetype").change(function () {
        const reisetype = $("#reisetype").val();
        if (reisetype === "turRetur") {
            $('#hjemreise').show();
            $('#hjemreiseLabel').show();
        } else {
            $('#hjemreise').hide();
            $('#hjemreiseLabel').hide();
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
            antallVoksne: $("#antallVoksne").val(),
            antallBarn: $("#antallBarn").val(),
            fornavn: $("#fornavn").val(),
            etternavn: $("#etternavn").val(),
            epost: $("#epost").val()
    };
        const url = "Billett/LagreBillett"
        $.post(url, bestilling, function () {
            window.location.href = "kvittering.html";
        });
    // console.log(bestilling.hjemreise);
    }

function check() {
    const bestilling = {
        reisetype: $("#reisetype").val(),
        fra: $("#fra").val(),
        til: $("#til").val(),
        utreise: $("#utreise").val(),
        hjemreise: $("#hjemreise").val(),
        antallVoksne: $("#antallVoksne").val(),
        antallBarn: $("#antallBarn").val(),
        fornavn: $("#fornavn").val(),
        etternavn: $("#etternavn").val(),
        epost: $("#epost").val()
    };
    console.log(bestilling);

    let reisetype= $("#reisetype").val();
    if (reisetype == 'enVei') {
        console.log("Dette er en vei");
    }

    if (reisetype == 'turRetur') {
        console.log("Dette er en turRetur");
    }
}

 
 
 /*
  $(":input").on('keyup mouseup', function () {
  var coins = $("#coins").val();
  $("#reward").text(coins);
}).trigger('mouseup');
  
  */

//viser oversikt

$("#btnNeste2").click(function () {

    var reisetype = $("#reisetype").val();
    var fra = $("#fra").val();
    var til = $("#til").val();
    var utreise = $("#utreise").val();
    var hjemreise = $("#hjemreise").val();
    var antallVoksne = $("#antallVoksne").val();
    var antallBarn = $("#antallBarn").val();
    var fornavn = $("#fornavn").val();
    var etternavn = $("#etternavn").val();
    var epost = $("#epost").val();
    let ut = ""; 
    if (reisetype == 'enVei') {
        console.log("Dette er en vei fra linje 477");
        ut += "<h1 class='overskrift'>Oversikt</h1>" + "<div class='form-group'>" +
            "<label class='form-control' id='oversiktLabel'>" + fornavn + " " + etternavn + "</label>" +
            "<label class='form-control' id='oversiktLabel'>" + epost + "</label>" +
            "<label class='form-control' id='oversiktLabel'>" + reisetype + "</label>" +
            "<label class='form-control' id='oversiktLabel'>" + fra + " - " + til + "</label>" +
            "<label class='form-control' id='oversiktLabel'>" + "Utreise: " + utreise + "</label>" +
            "<label class='form-control' id='oversiktLabel'>" + antallVoksne + " Voksen og " + antallBarn + " Barn" + "</label>";
    }

    else if (reisetype == 'turRetur') {
        console.log("Dette er en turRetur fra linje 490");
        ut += "<h1 class='overskrift'>Oversikt</h1>" + "<div class='form-group'>" +
            "<label class='form-control' id='oversiktLabel'>" + fornavn + " " + etternavn + "</label>" +
            "<label class='form-control' id='oversiktLabel'>" + epost + "</label>" +
            "<label class='form-control' id='oversiktLabel'>" + reisetype + "</label>" +
            "<label class='form-control' id='oversiktLabel'>" + fra + " - " + til + "</label>" +
            "<label class='form-control' id='oversiktLabel'>" + "Utreise: " + utreise + "</label>" +
            "<label class='form-control' id='oversiktLabel'>" + "Hjemreise: " + hjemreise + "</label>" +
            "<label class='form-control' id='oversiktLabel'>" + antallVoksne + " Voksen og " + antallBarn + " Barn" + "</label>";
    }

        $("#oversikt").html(ut);
    
});
