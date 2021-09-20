$(() => {


    let state = {
        warning: 0,
        success: 1,
        notFinished: 2,
        locked: 3,
        active: 4
    }
    GUIModule.changeSchemaState(0, state.notFinished);
    GUIModule.changeSchemaState(1, state.notFinished);
    GUIModule.changeSchemaState(2, state.notFinished);
    GUIModule.changeSchemaState(3, state.notFinished);

    $("#nav0").click((e) => {
        e.preventDefault();
        GUIModule.changeSchemaState(0, state.locked);
    });

    $("#nav1").click((e) => {
        e.preventDefault();
        GUIModule.changeSchemaState(1, state.success);
    });

    $("#nav2").click((e) => {
        e.preventDefault();
        GUIModule.changeSchemaState(2, state.warning);
    });

    $("#nav3").click((e) => {
        e.preventDefault();
        GUIModule.changeSchemaState(3, state.active);
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
    let notFinishedClasses = ["text-black-50"];
    let lockedClasses = ["text-black-50"];
    let activeClasses = ["active", "text-white"];

    let preSchemaState = [state.notFinished, state.notFinished, state.notFinished, state.locked];
    let schemaState = [state.success, state.warning, state.active, state.locked];

    function changePschemaState(id, myState) {

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