$(() => {


    let state = {
        warning: 0,
        success: 1,
        notFinished: 2,
        locked: 3,
        active: 4
    }
    GUIModule.changeSchemaState(0, state.active);
    GUIModule.changeSchemaState(1, state.notFinished);
    GUIModule.changeSchemaState(2, state.notFinished);
    GUIModule.changeSchemaState(3, state.notFinished);

    $("#nav0").click((e) => {
        e.preventDefault();
        GUIModule.changeSchemaState(0, state.active);
        document.getElementById("regform").style.display = "block";
        document.getElementById("regform1").style.display = "none";
        document.getElementById("regform2").style.display = "none";
        document.getElementById("regform3").style.display = "none";

    });

    $("#suksess1").click((e) => {
        e.preventDefault();
        GUIModule.changeSchemaState(1, state.success);


    });

    $("#war1").click((e) => {

        GUIModule.changeSchemaState(1, state.warning);


    });

    $("#suksess3").click((e) => {
        e.preventDefault();
        GUIModule.changeSchemaState(3, state.success);


    });

    $("#war3").click((e) => {

        GUIModule.changeSchemaState(3, state.warning);


    });

    $("#nav1").click((e) => {
        e.preventDefault();
        GUIModule.changeSchemaState(1, state.active);
        document.getElementById("regform").style.display = "none";
        document.getElementById("regform1").style.display = "block";
        document.getElementById("regform2").style.display = "none";
        document.getElementById("regform3").style.display = "none";
    });

    $("#nav2").click((e) => {
        e.preventDefault();
        GUIModule.changeSchemaState(2, state.active);
        document.getElementById("skjema0").style.display = "none";
        document.getElementById("skjema1").style.display = "none";
        document.getElementById("skjema2").style.display = "block";
        document.getElementById("skjema3").style.display = "none";
    });

    $("#nav3").click((e) => {
        e.preventDefault();
        GUIModule.changeSchemaState(3, state.active);
        document.getElementById("skjema0").style.display = "none";
        document.getElementById("skjema1").style.display = "none";
        document.getElementById("skjema2").style.display = "none";
        document.getElementById("skjema3").style.display = "block";
    });


});




var GUIModule = (function () {

    let state = {
        warning: 0,
        success: 1,
        notFinished: 2,
        locked: 3,
        active: 4
    }

    let warningClasses = ["bg-warning", "text-black-50"];
    let successClasses     = ["bg-success", "text-white"];
    let notFinishedClasses = [""];
    let lockedClasses = ["text-black-50"];
    let activeClasses = ["active", "text-white"];

    let preSchemaState = [state.notFinished, state.notFinished, state.notFinished, state.locked];
    let schemaState = [state.success, state.warning, state.active, state.locked];
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

        else if (myState == state.active        ) {
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
  
    return {
       changeSchemaState : function (id,state) {

            changePschemaState(id,state);

        }
    };
})();