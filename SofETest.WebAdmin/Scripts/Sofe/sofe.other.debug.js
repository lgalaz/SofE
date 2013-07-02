(function ($, $sofe) {

    var otherView = new kendo.View('other-template'),

		router = $sofe.router;

    router.route('/other', function () {

        $sofe.mainLayout.showIn('#content', otherView);

    });

})(jQuery, jQuery.sofe);