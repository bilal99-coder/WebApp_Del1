//formaterer kvittering til bestillingen ved oppstart av siden

$(function () {
    //Henter iden til kjøpte billetten 
    let billettId = sessionStorage.getItem("billettId");
    console.log(billettId);
    let url = "billett/hentBillett";

    //Henter ut nå billetten fra databasen

    if (billettId != null) {
        $.ajax({
            type: "POST",
            url: url + "?id="
             +  encodeURIComponent(1),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (Billett) {
                console.log(Billett);
                if (Billett) {
                    formaterBestilling(Billett);
                }
                
                else {
                    $("#feil").html("Feil i db - prøv igjen senere");
                    console.log("feil med db- linje 25")
                }
            }
        });
    }

});

function formaterBestilling(bestilling){
    let ut = "<form class='form'>";
    console.log("I am to be formatted ")
    if (bestilling.Reisetype == 'enVei') {
            console.log("Hei fra linje 15 i kvittering.js")
                ut +=
                    "<h1 id='overskrift'>Kvittering</h1>" +
                    "<div class='row'>" +
                    "<div class='col'>" +
                    "<img id='qr' src='frame.png' alt='QR' width='400px' height='400px'/>" +
                    "</div>" +
                    "<div class='col' id='kvitteringInfo'>" +
                    "<label class='form-control' id='kvitteringFraTil'>" + bestilling.Fra + " - " + bestilling.Til + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + "Utreise: " + bestilling.Utreise + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + bestilling.Fornavn + " " + bestilling.Etternavn + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + bestilling.Epost + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + bestilling.AntallVoksne + " Voksen og " + bestilling.AntallBarn + " Barn" + "</label>" +
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
                    "<label class='form-control' id='kvitteringFraTil'>" + bestilling.Fra + " - " + bestilling.Til + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + "Utreise: " + bestilling.Utreise + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + "Hjemreise: " + bestilling.Hjemreise + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + bestilling.Fornavn + " " + bestilling.Etternavn + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + bestilling.Epost + "</label>" +
                    "<label class='form-control' id='KvitteringFraTil'>" + bestilling.AntallVoksne + " Voksen og " + bestilling.AntallBarn + " Barn" + "</label>" +
                    "</div>" +
                    "</div>" +
                    "<h5 id='reiseKodeLabel'> ReiseKode: </h5>" + "<br>" + "<h3 id='reiseKode'>KSWHFG275</h3>";
            }
        


    ut += "</form>";
    $("#kvittering").html(ut);
}

//hentet fra nettet


