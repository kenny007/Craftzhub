/// <reference path="../knockout-2.2.0.debug.js" />
$(function () {
			my.viewmodel = {
				metadata: {
					pageTitle: "Knockout: Built-In Bindings (value and valueUpdate)",
					personal: {
						link: "http://twitter.com/john_papa",
						text: "@kennymore007"
					}
                },
			    // text/html
				id: ko.observable("123"),
				model: {
					code: ko.observable("314ce"),
					name: ko.observable("Taylor 314 ce")
	            },
			    
                // value & valueUpdate				
				salePrice: ko.observable(1995)

			};
			ko.applyBindings(my.viewmodel);
		});