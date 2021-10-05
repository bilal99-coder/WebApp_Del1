//formaterer kvittering til bestillingen ved oppstart av siden

$(function () {
    $.get("Billett/HentBillett", function (bestillinger) {
        formaterBestilling(bestillinger);
    });
});

function formaterBestilling(bestillinger){
    let ut = "<form class='form'>";

    for (let bestilling of bestillinger) {
        if (bestilling)
        ut += 
            "<div class='form-controll'>"
        + "<h1>Betaler</h1>" +
            "<h3>Navn:</h3>" +
        bestilling.fornavn + "<p> </p>" + bestilling.etternavn +
        "<h3>Epost:</h3>" +
        bestilling.epost + 
        "</div>" +
        "<div class='form-controll'>"
        + "<h1>Reiseinformasjon</h1>" +
        "<h3>Reisetype:</h3>" +
        bestilling.reisetype +
        "<h3>Fra - Til:</h3>" +
        bestilling.fra + "<p> - </p>" + bestilling.til +
        "<h3>Utreise - Hjemreise:</h3>" +
        bestilling.utreise + "<p> - </p>" + bestilling.hjemreise +
        "<h3>Antall Reisende:</h3>" +
        bestilling.antallVoksen + "<p> Voksen + </p>" + bestilling.antallBarn + "<p> Barn</p>"
        + "</div>"
    }
    ut += "</form>";
    $("#kvittering").html(ut);
}