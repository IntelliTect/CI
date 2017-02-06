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
       $(options.compareButton).click(function(){

		   // if the button has the class active we have items to compare
	       	if($(this).hasClass('active')){

	       		$('.modal-products').empty(); // clear the modal
	       		$('.no-products').hide(); // hide the no products selected message

	       		var arrayLength = itemsarray.length;
	       		// loop through the array if products
				for (var i = 0; i < arrayLength; i++) {

					product = $('.product[data-id="'+itemsarray[i]+'"]');

					$('.modal-products').append('<div class="product"><img src="'+$(product).find('img').attr('src')+
					'"/><ul><li><span>'+$(product).data('title')+
					'</span></li><li><span>Technology: '+$(product).data('technology')+'</span></li>'+
'</span></li><li class=shortli><span>Depth of Focus: '+$(product).data('depth')+'</span></li>'+
'</span></li><li><span>Power: '+$(product).data('power')+'</span></li>'+
'</span></li><li><span>Film Resist Sides/hour: '+$(product).data('film ')+'</span></li>'+
'</span></li><li><span>Soldermask Sides/hour: '+$(product).data('soldermask')+'</span></li>'+
'</span></li><li><span>Speed Details: '+$(product).data('speed')+'</span></li>'+
'</span></li><li><span>Edge Roughness: '+$(product).data('edge')+'</span></li>'+
'</span></li><li><span>Positional Accuracy / Data Resolution / Alignment Accuracy: '+$(product).data('positional ')+'</span></li>'+
'</span></li><li><span>Registration Accuracy (Side by Side Alignment Accuracy): '+$(product).data('registration')+'</span></li>'+
'</span></li><li><span>Line/Space Width: '+$(product).data('line')+'</span></li>'+
'</span></li><li><span>Line/Space SEM Image: '+$(product).data('line2')+'</span></li>'+
'</span></li><li><span>DF Thickness: '+$(product).data('df ')+'</span></li>'+
'</span></li><li><span>Hole Diameter: '+$(product).data('hole ')+'</span></li>'+
'</span></li><li><span>Hole Diameter Image: '+$(product).data('hole2')+'</span></li>'+
'</span></li><li><span>SRO (solder resist opening): '+$(product).data('sro ')+'</span></li>'+
'</span></li><li><span>SR Thickness: '+$(product).data('sr')+'</span></li>'+
'</span></li><li><span>Address Pitch: '+$(product).data('address')+'</span></li>'+
'</span></li><li><span>Min. Image Size: '+$(product).data('min')+'</span></li>'+
'</span></li><li><span>Max. Image Size: '+$(product).data('max')+'</span></li>'+
'</span></li><li><span>Panel Thickness: '+$(product).data('panel ')+'</span></li>'+
'</span></li><li><span>Handling Options: '+$(product).data('handling')+'</span></li>'+
'</span></li><li><span>Machine Dimensions: '+$(product).data('machine ')+'</span></li>'+
'</span></li><li><span>Models: '+$(product).data('models')+'</span></li>'+
'</span></li><li><span>Double Machine Images: '+$(product).data('double ')+'</span></li>'+
'</span></li><li><span>Expected Laser DMD Head Lifetime: '+$(product).data('expected ')+'</span></li>'+
'</span></li><li><span>Warranty Standard: '+$(product).data('warranty')+'</span></li>'+
'</span></li><li><span>Warranty Cost/year: '+$(product).data('warranty2')+'</span></li>'+
'</span></li><li><span>Mechanical Clamping: '+$(product).data('mechanical')+'</span></li>'+
'</span></li><li><span>Autofocus if needed: '+$(product).data('autofocus')+'</span></li>'+
'</span></li><li><span>Panel Traceability(Serial Number Tracking): '+$(product).data('panel2')+'</span></li>'+
'</span></li><li><span>Non-linear Distortion: '+$(product).data('non-linear')+'</span></li>'+
'</span></li><li><span>URL: '+$(product).data('url')+'</span></li>'+
'</span></li><li><span>Video Examples: '+$(product).data('video')+'</span></li>'+
'</span></li><li><span>Notes: '+$(product).data('notes')+'</span></li></div>'+


					'</span></li></ul></div>');
					
					

				}

			// else we haven't selected any products to compare yet
	       	}else{
	       		$('.modal-products').empty(); // clear the modal
	       		$('.no-products').show(); // show the no products selected message       	
	       	}

       });


	   // If an item is click for comparison run this code
	   //
	   $(this).find('button').click(function(){
		    // toggle the class selected on the product wrapper
	   		$(this).parent().toggleClass('selected');
	   		// get the product id
	   		productId = $(this).parent().data('id');
	   		// check if this product is already in the array
	   	    var inArray = $.inArray(productId, itemsarray);

	   	    if(inArray < 0){
		   		// add this product to the array
		   		itemsarray.push(productId);
		   	}else{
		   		// remove if from the array
		   		itemsarray.splice( $.inArray(productId,itemsarray) ,1 );
		   	}		   

		   	if(itemsarray.length > 1){
			   	// if there are items in the array (selected) add the class 'active'
			   	// to the 'compare' button
		   		$(options.compareButton).addClass('active');

		   	}else{
			   	// if there are no items in the array (selected)
			   	// remove the active class
		   		$(options.compareButton).removeClass('active');

		   	}
		   
	   });
	   
    };
})(jQuery);