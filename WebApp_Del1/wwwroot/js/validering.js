$("#btnNeste").click(function ({
    validerReisetype();
});

function validerReisetype() {
    const reisemåte = $("#reisemåte soption:selected").val();
    if (reisemåte == null) {
        $("#reisetypeFeil").html("Du må velge en reisetype!");
    }
}
