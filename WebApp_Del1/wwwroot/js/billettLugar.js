$(() => {
    CommunicationModule.hentlugarer();
});


var CommunicationModule = (function () {

    async function hentPlugarer() {


        await $.post("/billett/hentLugarer", (res) => {
            GUIModule.renderLugarer(res);
        }).promise();


    }

    return {

        hentlugarer: function () {

            hentPlugarer().then((x) => { },
                (error) => {
                    setTimeout(() => { CommunicationModule.hentlugarer()}, 10000);
                }}
    }
})();
    

var GUIModule = (function () {

    return {
        renderLugarer: function (res) {

            $("<figure class= 'col-md-4' > " +
                " <a href='https://mdbootstrap.com/img/Photos/Lightbox/Original/img%20(145).jpg' data-size='1600x1067'> " +
                " <img alt='picture' src='https://mdbootstrap.com/img/Photos/Lightbox/Thumbnail/img%20(145).jpg' class='img-fluid'> " +
                "   </a> " +
                " </figure >").appendTo("#lugarPlaceholder");
        }
    };
)();