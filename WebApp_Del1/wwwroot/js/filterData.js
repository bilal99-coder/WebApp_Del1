$(() => {
    $("#sok").click((e) => {
        e.preventDefault();
        let filterData = GUIModuleFilter.extractFiltrering();
        CommunicationModule.sendFilterData(filterData);
    });


});



var CommunicationModule = (function () {

    async function sendFilterData(filterData) {


        await $.post("/billett/filterData",filterData, (res) => {
            
        }).promise();


    }

    return {

        sendFilterData: function (filterData) {

            sendFilterData(filterData).then((x) => { },
                (error) => {
                    setTimeout(() => { CommunicationModule.sendFilterData(filterData) }, 10000);
                });
        }
    }
})();
    

var GUIModuleFilter = (function () {

    return {
        extractFiltrering: function () {
       
            let filterData = {
                prisMin:  $("#prisMin").val(),
                prisMaks: $("#prisMaks").val(),
                antall:   $("#antall").val(),
                harWc: $("#wc").prop("checked"),
                harDysj: $("#dysj").prop("checked"),
                harWifi: $("#wifi").prop("checked")

            }
            return filterData;

        }
    };
})();