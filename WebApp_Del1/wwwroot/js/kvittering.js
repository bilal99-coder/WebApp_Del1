//formaterer kvittering til bestillingen ved oppstart av siden

$(function () {
    $.get("billett/hentBillett", function (bestillinger) {
        formaterBestilling(bestillinger);
    });
});

formaterBestilling(bestillinger){
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Reisetype</th><th>Fra</th><th>Til</th><th>Utreise</th>" +
        "<th>Hjemreise</th><th>AntallVoksne</th><th>AntallBarn</th><th>Pris</th>" +
        "</tr>";
    for (let bestilling of bestillinger) {
        ut += "<tr>" +
            "<td>" + bestilling.reisetype + "</td>" +
            "<td>" + bestilling.fra + "</td>" +
            "<td>" + bestilling.til + "</td>" +
            "<td>" + bestilling.utreise + "</td>" +
            "<td>" + bestilling.hjemreise + "</td>" +
            "<td>" + bestilling.antallVoksen + "</td>" +
            "<td>" + bestilling.antallBarn + "</td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#kvittering").html(ut);
}