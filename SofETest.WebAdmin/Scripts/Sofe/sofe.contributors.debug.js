(function ($, $sofe) {

    var

	// DATAS0URCE
        dataSource = new kendo.data.DataSource({

		    transport: {

		        create: {
		            url: 'api/contributors',
		            dataType: 'json',
		            contentType: 'application/json',
		            type: 'POST'
		        },

		        read: {
		            url: 'api/contributors',
		            dataType: 'json',
		            contentType: 'application/json',
		            type: 'GET'
		        },

		        update: {
		            url: 'api/contributors',
		            dataType: 'json',
		            contentType: 'application/json',
		            type: 'PUT'
		        },

		        destroy: {
		            url: 'api/contributors',
		            dataType: 'json',
		            contentType: 'application/json',
		            type: 'DELETE'
		        },

		        parameterMap: function (data, type) {
		            return kendo.stringify(data);
		        }

		    },

		    schema: {
		        model: {
		            id: 'Id',
		            fields: {
		                Name: {
		                    type: 'string',
		                    validation: {
		                        required: true
		                    }
		                },
		                Phone: {
		                    type: 'string',
		                    validation: {
		                        required: true
		                    }
		                },
		                Email: {
		                    type: 'email',
		                    validation: {
		                        required: true
		                    }
		                }
		            }
		        }
		    },

		    pageSize: 5

		}),

	// M0DELS

        pageModel = new kendo.data.ObservableObject({

            data: dataSource

		}),

    // VIEWS

        pageView = new kendo.View('contributors-template', {

            model: pageModel

        }),

    // R0UTES

        router = $sofe.router;

    router.route('/contributors', function () {
        
        dataSource.fetch(function () {

            $sofe.mainLayout.showIn('#content', pageView);

        });
        
    });

})(jQuery, jQuery.sofe);