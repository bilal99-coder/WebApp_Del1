$(() => {
    $("#reg0").click((e) => {
        let info = hentReiseInfo();
        let erGyldig = validerReise(info);

        if (erGyldig) {
            sendReiseInformasjon(info);

        }
    });
});


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
    // Kommunikasjons funksjoner----------------

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





//------------------------------------


function sendReiseInformasjon(info) {



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
            '<b>Fornavn ' + i + ' </b> ' +
            '</label>' +
            '<div class="col-sm-9">' +
            '   <input type="text" ' +
            '      id="fornavn' + i +
            '       placeholder="0"' +
            '       class="form-control"' +
            '       autofocus="" />' +
            ' </div>' +
            '<label for="etternavn ' + i + ' class="col-sm-3 control-label"> ' +
            '<b>Etternavn ' + i + ' </b> ' +
            '</label>' +
            '<div class="col-sm-9">' +
            '   <input type="text" ' +
            '      id="adresse' + i +
            '       placeholder="0"' +
            '       class="form-control"' +
            '       autofocus="" />' +
            '<label for="telefon ' + i + ' class="col-sm-3 control-label"> ' +
            '<b>Telefon ' + i + ' </b> ' +
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
