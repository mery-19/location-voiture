

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


    var frensh = {
        "language": {
            "sProcessing": "Traitement en cours ...",
            "sLengthMenu": "Afficher _MENU_ lignes",
            "sZeroRecords": "Aucun résultat trouvé",
            "sEmptyTable": "Aucune donnée disponible",
            "sInfo": "Lignes _START_ à _END_ sur _TOTAL_",
            "sInfoEmpty": "Aucune ligne affichée",
            "sInfoFiltered": "(Filtrer un maximum de_MAX_)",
            "sInfoPostFix": "",
            "sSearch": "Chercher:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Chargement...",
            "oPaginate": {
                "sFirst": "Premier", "sLast": "Dernier", "sNext": "Suivant", "sPrevious": "Précédent"
            },
            "oAria": {
                "sSortAscending": ": Trier par ordre croissant", "sSortDescending": ": Trier par ordre décroissant"
            }
        }
    }
    if (Cookies.get('culture') === "fr") {
        window.$('.table').DataTable(frensh);

        $("#selected-language").html ("<img src='https://www.countryflags.io/fr/flat/32.png' class='icon-country' /> Français");

    } else {
        window.$('.table').DataTable();
        $("#selected-language").html("<img src='https://www.countryflags.io/us/flat/32.png' class='icon-country' /> English");


    }

    $(function () {
        console.log(Cookies.get('culture'));

    });

    $(function () {
        $("a.delete-link-voiture").click(function () {

            var token = $("[name='__RequestVerificationToken']").val();

            console.log(token);
            var checkstr;
            if (Cookies.get('culture') === "fr") {
                checkstr = confirm('Voullez vous vraiment supprimer cette Voiture?');

            } else {
                checkstr = confirm('are you sure you want to delete this?');
            }
            if (checkstr == true) {
                $.ajax({
                    url: '/Voitures/Delete/' + $(".delete-link-voiture").attr('data-delete-id'),
                    type: "POST",
                    data: {
                        __RequestVerificationToken: token,
                    },
                    success: function () {
                        window.location.replace("https://localhost:44333/Voitures/mycars");
                    }
                });
            }
        }
        );
    });
});
