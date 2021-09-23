
$(() => {
    $("#reg0").click((e) => {
        let info = hentReiseInfo();
        let erGyldig = validerReise(info);

        if (erGyldig) {
           sendReiseInformasjon(info);
            alert("ta");
        }
    });

    
});

function sendReiseInformasjon(info) {
    // ajax kall til server
    let antBarn = parseInt(info.antallBarn, 10);
    let antVoksen = parseInt(info.antallVoksen, 10);

    let antPersoner = antBarn + antVoksen;
    

    $("#personer").html("");
    for ( i = 1; i <= antPersoner; i++) {

        $('<div class="form-group">' +
            '<label for="person ' + i + ' class="col-sm-3 control-label"> ' +
               ' Person ' + i + ' </i> ' +
            '</label>' +
            '<div class="col-sm-9">' +
             '   <input type="text" ' +
              '      id="person' + i +
             '       placeholder="0"'+
             '       class="form-control"'+
             '       autofocus="" />'+
           ' </div>'+
        '</div>').appendTo("#personer");

      
    }


}

function setAntallLugarer(lugarer) {

    storeModuleSPA.setAntallLugarer(lugarer);


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
