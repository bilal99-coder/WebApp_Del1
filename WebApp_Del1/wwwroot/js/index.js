$(() => {
    $("#reg0").click((e) => {
        let info = hentReiseInfo();
        let erGyldig = validerReise(info);

        if (erGyldig) {
            sendReiseInformasjon(info);

        }
    });
});


function sendReiseInformasjon(info) {
    // ajax kall til server
    let antBarn = parseInt(info.antallBarn, 10);
    let antVoksen = parseInt(info.antallVoksen, 10);

    let antPersoner = antBarn + antVoksen;

    for ( i = 1; i <= antPersoner; i++) {

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
