

$(document).ready(function () {

    $('.sideMenuToggler').on('click', function () {
        $('.wrapper').toggleClass('active');

        console.log("clicked");

    });

    var adjustSidebar = function () {
        $('.sidebar').slimScroll({
            height: document.documentElement.clientHeight - $('.navbar').outerHeight()
        });
    };

    adjustSidebar();
    $(window).resize(function () {
        adjustSidebar();
    });


      /*  $("#UserType").change(function () {
            console("clicked");
            var val = $('#type option:selected').val();
            console.log(val);

        });*/
    

});
