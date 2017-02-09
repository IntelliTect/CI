(function ($) {
	$.fn.compare = function (options) {

		// setup the default options
		var defaults = {
			compareButton: '.compareButton'
		};

		var options = $.extend(defaults, options);
		var itemsarray = []; // array for storing selected items

		// if the compare button is clicked add the items to the
		// modal window - opening the modal is triggered by the modal
		// plugin seperately
		// $(options.compareButton).click(function () {

		// 	// if the button has the class active we have items to compare
		// 	if ($(this).hasClass('active')) {

		// 		$('.modal-products').empty(); // clear the modal
		// 		$('.no-products').hide(); // hide the no products selected message

		// 		var arrayLength = itemsarray.length;
		// 		// loop through the array if products
		// 		for (var i = 0; i < arrayLength; i++) {

		// 			product = $('.product[data-id="' + itemsarray[i] + '"]');

		// 			$('.modal-products').append('<div class="product"><img height="230p" width="250px" src="' + $(product).find('img').attr('src') +
		// 				'"/><ul><li><span>' + $(product).data('title') + '<br/>' + $(product).data('url') +
		// 				'</span></li>' +
		// 				'<li><span><span class="productHeader">Model<br></span>' + $(product).data('model') + '</span></li>' +
		// 				'<li><span><span class="productHeader">Technology:<br/></span>' + $(product).data('technology') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Depth of Focus:<br/></span>' + $(product).data('depth') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Power:<br/></span>' + $(product).data('power') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Film Resist Sides/hour:<br/></span>' + $(product).data('film') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Soldermask Sides/hour:<br/></span>' + $(product).data('soldermask') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Speed Details:<br/></span>' + $(product).data('speed') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Edge Roughness:<br/></span>' + $(product).data('edge') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Positional,Data, and Alignment Accuracy:<br/></span>' + $(product).data('positional') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Registration Accuracy (Side by Side Alignment Accuracy):<br/></span>' + $(product).data('registration') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Line/Space Width:<br/></span>' + $(product).data('line') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Line/Space SEM Image:<br/></span>' + $(product).data('line2') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">DF Thickness:<br/></span>' + $(product).data('df') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Hole Diameter:<br/></span>' + $(product).data('hole') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Hole Diameter Image:<br/></span>' + $(product).data('hole2') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Solder Resist Opening:<br/></span>' + $(product).data('sro') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">SR Thickness:<br/></span>' + $(product).data('sr') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Address Pitch:<br/></span>' + $(product).data('address') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Min. Image Size:<br/></span>' + $(product).data('min') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Max. Image Size:<br/></span>' + $(product).data('max') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Panel Thickness:<br/></span>' + $(product).data('panel') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Handling Options:<br/></span>' + $(product).data('handling') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Machine Dimensions:<br/></span>' + $(product).data('machine') + '</span></li>' +
		// 				//'</span></li><li><span><span class="productHeader">Models:<br/></span>'+$(product).data('models')+'</span></li>'+
		// 				'</span></li><li><span><span class="productHeader">Double Machine Images:<br/></span>' + $(product).data('double') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Expected Laser DMD Head Lifetime:<br/></span>' + $(product).data('expected') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Warranty Standard:<br/></span>' + $(product).data('warranty') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Warranty Cost/year:<br/></span>' + $(product).data('warranty2') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Mechanical Clamping:<br/></span>' + $(product).data('mechanical') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Autofocus if needed:<br/></span>' + $(product).data('autofocus') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Panel Traceability (Serial Number Tracking):<br/></span>' + $(product).data('panel2') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Non-linear Distortion:<br/></span>' + $(product).data('non-linear') + '</span></li>' +
		// 				//'</span></li><li><span>URL:<br/></span>'+$(product).data('url')+'</span></li>'+
		// 				'</span></li><li><span><span class="productHeader">Video Examples:<br/></span>' + $(product).data('video') + '</span></li>' +
		// 				'</span></li><li><span><span class="productHeader">Notes:<br/></span>' + $(product).data('notes') + '</span></li></div>' +
		// 				'</span></li></ul></div>');
		// 		}

		// 		// else we haven't selected any products to compare yet
		// 	} else {
		// 		$('.modal-products').empty(); // clear the modal
		// 		$('.no-products').show(); // show the no products selected message       	
		// 	}
		// });


		// If an item is click for comparison run this code
		//
		$(this).find('button').click(function () {
			// toggle the class selected on the product wrapper
			$(this).parent().toggleClass('selected');
			// get the product id
			productId = $(this).parent().data('id');
			// check if this product is already in the array
			var inArray = $.inArray(productId, itemsarray);

			if (inArray < 0) {
				// add this product to the array
				itemsarray.push(productId);
			} else {
				// remove if from the array
				itemsarray.splice($.inArray(productId, itemsarray), 1);
			}

			if (itemsarray.length > 1) {
				// if there are items in the array (selected) add the class 'active'
				// to the 'compare' button
				$(options.compareButton).addClass('active');

			} else {
				// if there are no items in the array (selected)
				// remove the active class
				$(options.compareButton).removeClass('active');

			}

		});

	};
})(jQuery);