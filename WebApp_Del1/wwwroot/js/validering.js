function validerAntallVoksne(antallVoksne) {
    const regexp = /^[1-9]{1}$/;
    const ok = regexp.test(antallVoksne);
    if (!ok) {
        $("#antallVoksenFeil").html("Du må velge mellom 1-9 voksne").css('color', 'red');
        return false;
    }
    else {
        $("#antallVoksenFeil").html("");
        return true;
    }
}

function validerAntallBarn(antallBarn) {
    const regexp = /^[0-9]{1}$/;
    const ok = regexp.test(antallBarn);
    if (!ok) {
        $("#antallBarnFeil").html("Du kan bare velge 0 - 9 barn").css('color', 'red');
        return false;
    }
    else {
        $("#antallBarnFeil").html("");
        return true;
    }
}

//Må ha Visa, American Express, Mastercard, Discover, Diners Club eller JCB kort
//regex hentet fra internett

function validerKortnummer(kortnummer) {
    const regexpKort = /^(?:(4[0-9]{12}(?:[0-9]{3})?)|(5[1-5][0-9]{14})|(6(?:011|5[0-9]{2})[0-9]{12})|(3[47][0-9]{13})|(3(?:0[0-5]|[68][0-9])[0-9]{11})|((?:2131|1800|35[0-9]{3})[0-9]{11}))$/;
    const ok = regexpKort.test(kortnummer);
    if (ok) {
            $("#kortnummerFeil").html("");
            return true;
    }
    else {
        $("#kortnummerFeil").html("Ikke gyldig kort").css('color', 'red');
        return false;

    }
}


function validerUtreise(utreise) {
    const regexpUtreise = /^[0-9]{1,2}[- /.]{1}[0-9]{1,2}[- /.]{1}[0-9]{1,4}$/;
    const ok = regexpUtreise.test(utreise);
    if (ok) {
        $("#utreiseFeil").html("");
        return true;
    } else {
        $("#utreiseFeil").html("Du må velge utreise").css('color', 'red');
        return false;
    }
}


function validerHjemreise(hjemreise) {
    const reisetype = $("#reisetype").val();
    if (reisetype === "turRetur") {
        const regexpHjemreise = /^[0-9]{1,2}[- /.]{1}[0-9]{1,2}[- /.]{1}[0-9]{1,4}$/;
        const ok = regexpHjemreise.test(hjemreise);
        if (ok) {
            $("#hjemreiseFeil").html("");
            return true;
        } else {
            $("#hjemreiseFeil").html("Du må velge hjemreise").css('color', 'red');
            return false;
        }
    } else if (reisetype === "enVei") {
        $("#hjemreise").html("");
        return true;
    }
}

function validerCvc(cvc) {
    const regexpCvc = /^[0-9]{3,4}$/;
    const ok = regexpCvc.test(cvc);
    if (ok) {
        $("#cvcFeil").html("");
        return true;
    } else {
        $("#cvcFeil").html("Cvc må være mellom 3-4 tall").css('color', 'red');
        return false;
    }
}

function validerKortdato(kortdato) {
    const regexpKortdato = /^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$/;
    const ok = regexpKortdato.test(kortdato);
    if (ok) {
        $("#kortdatoFeil").html("");
        return true;
    } else {
        $("#kortdatoFeil").html("må være to tall for måned, en '/' og to tall for år").css('color', 'red');
        return false;
    }
}

function validerFornavn(fornavn) {
    const regexpFornavn = /^[a-zA-zæøåÆØÅ. \-]{2,20}$/;
    const ok = regexpFornavn.test(fornavn);
    if (ok) {
        $("#fornavnFeil").html("");
        return true;
    } else {
        $("#fornavnFeil").html("Ikke gyldig fornavn").css('color', 'red');
    }
}

function validerEtternavn(etternavn) {
    const regexpEtternavn = /^[a-zA-zæøåÆØÅ. \-]{2,20}$/;
    const ok = regexpEtternavn.test(etternavn);
    if (ok) {
        $("#etternavnFeil").html("");
        return true;
    } else {
        $("#etternavnFeil").html("Ikke gyldig etternavn").css('color', 'red');
    }
}

//regex hentet fra internett

function validerEpost(epost) {
    const regexpEpost = /^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$/;
    const ok = regexpEpost.test(epost);
    if (ok) {
        $("#epostFeil").html("");
        return true;
    } else {
        $("#epostFeil").html("Ikke gyldig epost").css('color', 'red');
    }
}

