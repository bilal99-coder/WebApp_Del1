function validerAntallvoksne(antallVoksen) {
    const regexp = /^[1-9]{1}$/;
    const ok = regexp.test(antallVoksen);
    if (!ok) {
        $("#antallVoksenFeil").html("Du må velge mellom 1-9 voksne").css('color', 'red');
        return false;
    }
    else {
        $("#antallVoksenFeil").html("");
        return true;
    }
};

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

