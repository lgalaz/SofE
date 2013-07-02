(function ($, $sofe) {

    var indexView = new kendo.View('index-template'),

		router = $sofe.router;

    router.route('/', function () {

        $sofe.mainLayout.showIn('#content', indexView);

    });

})(jQuery, jQuery.sofe);