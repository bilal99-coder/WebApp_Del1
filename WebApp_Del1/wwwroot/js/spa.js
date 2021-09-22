
$(() => {


    let state = {
        warning: 0,
        success: 1,
        notFinished: 2,
        locked: 3,
        active: 4
    }


    $("#btnFerdig").click((e) => {
        if (GUIModuleSPA.erFerdig()) {
            alert("Du fikk kjøpt en billett");
        }
        else {
            alert("Du har ikke gitt tilstrekkelig riktig informasjon, for å kunne kjøpe en billett")
        }
    }
    )
    $("#nav0").click((e) => {
        e.preventDefault();
        GUIModuleSPA.changeSchemaState(0, state.active);
        $("#regform2").hide();
        $("#regform").show();


    });

    $("#suksess0").click((e) => {
        e.preventDefault();
        GUIModuleSPA.changeSchemaState(0, state.success);


    });

    $("#war0").click((e) => {

        GUIModuleSPA.changeSchemaState(0, state.warning);


    });

    $("#suksess1").click((e) => {
        e.preventDefault();
        GUIModuleSPA.changeSchemaState(1, state.success);


    });

    $("#war1").click((e) => {

        GUIModuleSPA.changeSchemaState(1, state.warning);


    });


    $("#suksess2").click((e) => {
        e.preventDefault();
        GUIModuleSPA.changeSchemaState(2, state.success);


    });

    $("#war2").click((e) => {

        GUIModuleSPA.changeSchemaState(2, state.warning);


    });



    $("#nav1").click((e) => {
        e.preventDefault();
        GUIModuleSPA.changeSchemaState(1, state.active);
        $("#regform").hide();
        $("#regform2").show();

    });

    $("#nav2").click((e) => {
        e.preventDefault();
        GUIModuleSPA.changeSchemaState(2, state.active);
        $("#regform2").hide();
        $("#regform3").show();

    });




});




var GUIModuleSPA = (function () {

    let state = {
        warning: 0,
        success: 1,
        notFinished: 2,
        locked: 3,
        active: 4
    }

    let warningClasses = ["bg-warning", "text-black-50"];
    let successClasses = ["bg-success", "text-white"];
    let notFinishedClasses = ["text-white"];
    let lockedClasses = ["text-black-50"];
    let activeClasses = ["text-white","bg-primary"];

    let preSchemaState = [state.notFinished, state.notFinished, state.notFinished];
    let schemaState = [state.active, state.notFinished, state.notFinished];
    let currentActive = 0;

    function changePschemaState(id, myState) {
        if (schemaState[id] == state.active && myState == state.active) return;
        removeAndRemClasses(id, schemaState[id]);
        schemaState[id] = myState;

        //goto new state
        if (myState == state.warning) {
            warningClasses.forEach((x) => { $("#nav" + id).addClass(x) });
            document.getElementById("warning" + id).style.visibility = "visible";

        }

        else if (myState == state.success) {
            successClasses.forEach((x) => { $("#nav" + id).addClass(x) });
            document.getElementById("success" + id).style.visibility = "visible";

        }
        else if (myState == state.notFinished) {
            notFinishedClasses.forEach((x) => { $("#nav" + id).addClass(x) });
        }
        else if (myState == state.locked) {
            lockedClasses.forEach((x) => { $("#nav" + id).addClass(x) });
            document.getElementById("locked" + id).style.visibility = "visible";
        }

        else if (myState == state.active) {
            activeClasses.forEach((x) => { $("#nav" + id).addClass(x) });
            changePschemaState(currentActive, preSchemaState[currentActive]);
            currentActive = id;
        }


    }
    function removeAndRemClasses(id, myState) {
        preSchemaState[id] = myState;
        if (myState == state.warning) {
            warningClasses.forEach((x) => { $("#nav" + id).removeClass(x) });
            document.getElementById("warning" + id).style.visibility = "hidden";

        }
        else if (myState == state.success) {
            successClasses.forEach((x) => { $("#nav" + id).removeClass(x) });
            document.getElementById("success" + id).style.visibility = "hidden";

        }
        else if (myState == state.notFinished) {
            successClasses.forEach((x) => { $("#nav" + id).removeClass(x) });
        }
        else if (myState == state.locked) {
            lockedClasses.forEach((x) => { $("#nav" + id).removeClass(x) });
            document.getElementById("locked" + id).style.visibility = "hidden";
        }

        else if (myState == state.active) {
            activeClasses.forEach((x) => { $("#nav" + id).removeClass(x) });
        }


    }

    function erPFerdig() {
        return schemaState.every((x, id) => { return (x == state.success || (id == currentActive && preSchemaState[currentActive] == state.success)) });
    }

    return {
        changeSchemaState: function (id, state) {

            changePschemaState(id, state);

        },
        erFerdig: function () {
            return erPFerdig();
        }
    };
})();