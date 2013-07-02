(function ($, $sofe) {

    if (!$sofe) {

        $sofe = $.sofe = {

            mainLayout: new kendo.Layout('app-layout-template'),

            router: new kendo.Router({

                init: function () {

                    $sofe.mainLayout.render('#application');

                }

            })

        };

    }

    $(function () {

        $sofe.router.start();

    });

})(jQuery, jQuery.sofe);