$(() => {
    $("#reg").click((e) => {
        alert("hei");
    });
});
/*function ValiderReise() {
    const fra = $('#fra option:selected').val();
    const til = $('#til option:selected').val();

    if (fra == til) {
        $("#fraFeil").html("Feil! fra og til kan ikke være den samme")
    } else {
        sokOgBestill();
    }
}

function sokOgBestill() {
    const info = {
        reisetype: $('#reisetype option:selected').val(),
        fra: $('#fra option:selected').val(),
        til: $('#til option:selected').val(),
        utreise: $("#utreise").val(),
        antall: $("#antall").val()
    };
}
