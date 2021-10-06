//formaterer kvittering til bestillingen ved oppstart av siden

$(function () {
    $.get("Billett/HentBillett", function (bestillinger) {
        formaterBestilling(bestillinger);
    });
});

function formaterBestilling(bestillinger){
    let ut = "<form class='form'>";
    for (let bestilling of bestillinger) {
       // if (bestilling !== null)
        
        if (bestilling.reisetype == 'enVei') {
            console.log("Hei fra linje 15 i kvittering.js")
                ut +=
                    "<h1 id='overskrift'>Kvittering</h1>" +
                    "<div class='row'>" +
                    "<div class='col'>" +
                    "<img id='qr' src='frame.png' alt='QR' width='400px' height='400px'/>" +
                    "</div>" +
                    "<div class='col' id='kvitteringInfo'>" +
                    "<label class='form-control' id='kvitteringFraTil'>" + bestilling.fra + " - " + bestilling.til + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + "Utreise: " + bestilling.utreise + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + bestilling.fornavn + " " + bestilling.etternavn + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + bestilling.epost + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + bestilling.antallVoksne + " Voksen og " + bestilling.antallBarn + " Barn" + "</label>" +
                    "</div>" +
                    "</div>" +
                    "<label id='reiseKodeLabel'> ReiseKode: </label>" + "<br>" + "<h3 id='reiseKode'>RSDFS1254</h3>";
        } else {
            console.log("Hei fra linje 32 i kvittering.js // Dette må være for turRetur")
                ut +=
                    "<h1 id='overskrift'>Kvittering</h1>" +
                    "<div class='row'>" +
                    "<div class='col'>" +
                    "<img id='qr' src='frame.png' alt='QR' width='400px' height='400px'/>" +
                    "</div>" +
                    "<div class='col' id='kvitteringInfo'>" +
                    "<label class='form-control' id='kvitteringFraTil'>" + bestilling.fra + " - " + bestilling.til + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + "Utreise: " + bestilling.utreise + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + "Hjemreise: " + bestilling.hjemreise + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + bestilling.fornavn + " " + bestilling.etternavn + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + bestilling.epost + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + bestilling.antallVoksne + " Voksen og " + bestilling.antallBarn + " Barn" + "</label>" +
                    "</div>" +
                    "</div>" +
                    "<h5 id='reiseKodeLabel'> ReiseKode: </h5>" + "<br>" + "<h3 id='reiseKode'>KSWHFG275</h3>";
            }
        }


    ut += "</form>";
    $("#kvittering").html(ut);
}

//hentet fra nettet


