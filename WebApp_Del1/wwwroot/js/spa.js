$(() => {


    let state = {
        warning: 0,
        success: 1,
        notFinished: 2,
        locked: 3
    }

    $("#nav0").click((e) => {
        e.preventDefault();
        GUIModule.changeSchemaState(0, state.warning);
    });

    $("#nav1").click((e) => {
        e.preventDefault();
        GUIModule.changeSchemaState(1, state.warning);
    });

    $("#nav2").click((e) => {
        e.preventDefault();
        GUIModule.changeSchemaState(2, state.warning);
    });

    $("#nav3").click((e) => {
        e.preventDefault();
        GUIModule.changeSchemaState(3, state.success);
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
    let notFinishedClasses = ["bg-success", "text-white"];
    let lockedClasses      = ["bg-success", "text-white"];
    let activeClasses      = ["active"];

    let preSchemaState = [state.notFinished, state.notFinished, state.notFinished, state.locked];
    let schemaState = [state.success, state.warning, state.notFinished, state.locked];

    function changePschemaState(id, myState) {

        removeAndRemClasses(id, schemaState[id]);
        schemaState[id] = state;

        //goto new state
        if (myState == state.warning) {
            warningClasses.forEach((x) => { $("#nav" + id).addClass(x) });

        }

        else if (myState == state.success) {
            successClasses.forEach((x) => { $("#nav" + id).addClass(x) });
  
        }
        else if (myState == state.notFinished) {
            notFinishedClasses.forEach((x) => { $("#nav" + id).addClass(x) });
        }
        else if (myState == state.lockedClasses) {
            lockedClasses.forEach((x) => { $("#nav" + id).addClass(x) });
        }
        
        
    }
    function removeAndRemClasses(id, myState) {
        preSchemaState[id] = myState;
        if (myState == state.warning) {
            warningClasses.forEach((x) => { $("#nav" + id).removeClass(x) });

        }
        else if (myState == state.success) {
            successClasses.forEach((x) => { $("#nav" + id).removeClass(x) });

        }
        else if (myState == state.notFinished) {
            successClasses.forEach((x) => { $("#nav" + id).removeClass(x) });
        }
        else if (myState == state.lockedClasses) {
            successClasses.forEach((x) => { $("#nav" + id).removeClass(x) });
        }

    }
  
    return {
       changeSchemaState : function (id,state) {

            changePschemaState(id,state);

        }
    };
})();