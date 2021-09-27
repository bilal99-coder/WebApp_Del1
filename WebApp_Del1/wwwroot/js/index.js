$(() => {
    //TODO

    let reiseInfo = '' // = await hentReiseInfo();
    let infoPersoner = ''; //= await hentPersoner()
    let infoLugarer = ''; // = await hentLugarer;
    //   !-- initInfo(reiseInfo,infoPersoner,InfoLugarer)
    
    $("#reg0").click((e) => {
        let info = hentReiseInfo();
        let erGyldig = validerReise(info);

        if (erGyldig) {
            sendReiseInformasjon(info);

        }
    });

    //Kun en simulering, og skal fjernes når en kan^^
    $("#oversiktSimulator").click((e) => {
        let html = ' < div class= "card text-center col-md-4" >' +
            '    <div class="card-header"> Bilde her </div>' +
            '     <div class="card-body">' +
            '         <h5 class="card-title">Tittel </h5>' +
            '         <p class="card-text"> Beskrivelse.</p>' +
            '          <a href="#" class="btn btn-primary">Velg</a>' +
            '       </div>' +
            '        <div class="card-footer text-muted">' +

            '           <label class="control-label col-sm-8 align-content-center">Fasiliteter </label>' +
            '          <div class="col-sm-6">' +
            '              <div class="row">' +
            '                 <div class="col-sm-4 align-content-center">' +

            '                     <i class="fas fa-toilet"> Wc</i>' +

            '             </div>' +
            '              <div class="col-sm-4">' +


            '                 <i class="fa fa-shower" aria-hidden="true"> Dysj</i>' +

            '             </div>' +
            '            <div class="col-sm-4">' +

            ' < i class= "fa fa-wifi" aria - hidden="true" > Wifi </i > ' +

            '         </div> ' +
            '       </div>' +
            '     </div>' +
            '   </div>' +
            '     </div >' +
            '  </div >'
        leggTilLugarOversikt(html);
    });

    $("#slettLugarer").click((e) => {
        resetLugarOversikt();
    });


});

//---------GUI
function leggTilLugarOversikt(html) {
    $(html).appendTo("#lugarOversikt");
}

function resetLugarOversikt() {
    $("#lugarOversikt").html("");
}
    // Kommunikasjons funksjoner----------------

async function slettBillett(successFunc) {
    $.post("/billett/slettBillett",).done((res) => {
        successFunc.bind(this)();
    }).promise();
}

async function registrerBillett(successFunc) {
    $.post("/billett/registrerBillett",).done((res) => {
        successFunc.bind(this)();
    }).promise();
}


async function sendTilServerReiseInformasjon(info, successFunc) {
    $.post("/billett/addReiseInfo", info).done((res) => {
        successFunc.bind(this)(info);
    }).promise();
}

async function sendTilServerPerson(person, successFunc) {
    $.post("/billett/addPerson", person).done((res) => {
        successFunc.bind(this)(info);
    }).promise();
    }

async function sendTilServerLugar(lugar, successFunc) {
        $.post("/billett/addLugar", lugar).done((res) => {
            successFunc.bind(this)(info);
        }).promise();
}

async function endreServerReiseInformasjon(id,info, successFunc) {
        $.post("/billett/endreReiseInfo/id", info).done((res) => {
            successFunc.bind(this)(id,info);
        }).promise();
    }

async function endreServerPerson(id, person, successFunc) {
        $.post("/billett/endrePerson/id", person).done((res) => {
            successFunc.bind(this)(id, person);
        }).promise();
 }

async function endreServerLugar(id, lugar, successFunc) {
        $.post("/billett/endreLugar/id", lugar).done((res) => {
            successFunc.bind(this)(id, lugar);
        }).promise();
}

async function slettServerPerson(id, person, successFunc) {
        $.post("/billett/endrePerson/id", person).done((res) => {
            successFunc.bind(this)(id, person);
        }).promise();
 }

async function slettServerLugar(id, successFunc) {
        $.post("/billett/slettLugar/id").done((res) => {
            successFunc.bind(this)(id);
        }).promise();
}

async function slettServerPersoner( successFunc) {
    $.post("/billett/slettPerson").done((res) => {
        successFunc.bind(this)();
    }).promise();
}

async function slettServerLugarer(successFunc) {
    $.post("/billett/slettLugarer").done((res) => {
        successFunc.bind(this)();
    }).promise();
}

async function slettServerReiseInfo( successFunc) {
    $.post("/billett/slettReiseInfo").done((res) => {
        successFunc.bind(this)();
    }).promise();
}

async function sendTilServerLugarer(lugarer,successFunc) {
    await $.post({
        url: '/addLugaer',
        data: lugarer,
        contentType: 'application/json; charset=utf-8'
    }).done((res) => {
        successFunc.bind(this)(info);
    }).promise();
}

    async function sendTilServerPersoner(personer, successFunc) {
        await $.post({
            url: '/addPersoner',
            data: personer,
            contentType: 'application/json; charset=utf-8'
        }).done((res) => {
            successFunc.bind(this)(info);
        }).promise();
}


async function hentServerPersoner() {
    $.post("/billett/hentPersoner").done((res) => {
        successFunc.bind(this)(res);
    }).promise();
}

async function hentServerLugarer() {
    $.post("/billett/hentLugarer").done((res) => {
        successFunc.bind(this)(res);
    }).promise();
}

async function endreServerPerson() {
    $.post("/billett/hentReiseInformasjon").done((res) => {
        successFunc.bind(this)(res);
    }).promise();
}



//------------------------------------
//Trenger en callback funksjon til hver av ajax funksjonene



///----------------------------------

function genererPersonInfoSkjema(info) {

    let antBarn = parseInt(info.antallBarn, 10);
    let antVoksen = parseInt(info.antallVoksen, 10);

    let antPersoner = antBarn + antVoksen;

    $("#personer").html("");
    //Legger til et nytt person registerings skjema i element med id personer
    for (i = 1; i <= antPersoner; i++) {

        $('<div class="form-group">' +
            '<label for="person ' + i + ' class="col-sm-3 control-label"> ' +
            ' <h1>Person ' + i + ' </h1> ' +
            '</label>' +

            '<label for="fornavn ' + i + ' class="col-sm-3 control-label"> ' +
            '<b>  Fornavn ' + ' </b> ' +
            '</label>' +
            '<div class="col-sm-9">' +
            '   <input type="text" ' +
            '      id="fornavn' + i +
            '       placeholder="0"' +
            '       class="form-control"' +
            '       autofocus="" />' +
            ' </div>' +
            '<label for="etternavn ' + i + ' class="col-sm-3 control-label"> ' +
            '<b>  Etternavn ' + ' </b> ' +
            '</label>' +
            '<div class="col-sm-9">' +
            '   <input type="text" ' +
            '      id="adresse' + i +
            '       placeholder="0"' +
            '       class="form-control"' +
            '       autofocus="" />' +
            '<label for="telefon ' + i + ' class="col-sm-3 control-label"> ' +
            '<b>Telefon ' + ' </b> ' +
            ' </div>' +
            '</label>' +
            '<div class="col-sm-9">' +
            '   <input type="tlf" ' +
            '      id="telefon' + i +
            '       placeholder="0"' +
            '       class="form-control"' +
            '       autofocus="" />' +
            ' </div>' +
            ' <button type="button" class="btn btn-primary" id="leggTilPerson"' + i + ' > Legg til </button> ' +
            ' <button type="button" class="btn btn-primary" id="endrePerson"' + i + ' > Endre </button> ' +
            ' </div>' +
            '</div>').appendTo("#personer");


    }
}
function sendReiseInformasjon(info) {

    genererPersonInfoSkjema(info);

}



function validerReise(info) {
    const fra = info.fra;
    const til = info.til;

    if (fra == til) {
        $("#fraFeil").html("Feil! fra og til kan ikke være den samme");
        return false;
    } else {
        return true;
    }
}

function hentReiseInfo() {
    const reiseInfo = {
        reisetype: $('#reisetype').val(),
        fra: $('#fra').val(),
        til: $('#til').val(),
        utreise: $("#utreise").val(),
        antallBarn: $("#antallBarn").val(),
        antallVoksen: $("#antallVoksen").val(),
    };
    return reiseInfo;
  
}

function initInfo(reiseInfo, infoPersoner, infoLugarer) {
    setReiseInfo(reiseInfo);
    for ((personInfo, idx) in infoPersoner) {
        setPersonInfo(idx + 1, personInfo);
    }
    for (lugar in infoLugarer) {
        let html = ' ';
        leggTilLugarOversikt(html);
    }
}
function setReiseInfo(reiseInfo) {
    $('#reisetype').val(reiseInfo.reisetype);
    $('#fra').val(reiseInfo.fra);
    $('#til').val(reiseInfo.til);
    $('#utreise').val(reiseInfo.reisetype);
    $('#antallBarn').val(reiseInfo.antallBarn);
    $('#antallVoksen').val(reiseInfo.antallVoksen);

    genererPersonInfoSkjema(reisInfo);

}

function setPersonInfo(nummerPerson, personInfo) {
    $('#fornavn' + nummerPerson).val(personInfo.fornavn);
    $('#etternavn' + nummerPerson).val(personInfo.etternavn);
    $('#telefon' + nummerPerson).val(personInfo.telefon);


}