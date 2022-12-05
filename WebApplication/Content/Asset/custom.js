//------------------------------------------
    //Custom JS
//------------------------------------------
jQuery(document).ready(function() {
	
	//lib--------------------------------------
	initScrollup("#id_your_btn"); // or .class_your_btn
	//initDatepicker();
	
	//your custom here-------------------------
	
});

function initScrollup(id_or_class){
	jQuery(id_or_class).click(function(){
		jQuery("html, body").animate({ scrollTop: 0 }, 600);
		return false;
	});
}

function initDatepicker(){
	//References: http://eonasdan.github.io/bootstrap-datetimepicker/Options/
	jQuery('input.datetimepicker').datetimepicker({
		format: 'DD/MM/YYYY'
	});
	
	jQuery('input.timepicker').datetimepicker({
		 format: 'HH:mm'
	});
}

function gotoEleClass(clss){
	 jQuery('html, body').animate({
        scrollTop: jQuery(clss).offset().top
    }, 1000);
}

function gotoEleId(id){
	 jQuery('html, body').animate({
        scrollTop: jQuery(id).offset().top
    }, 1000);
}

function gotoEle(e){
	 jQuery('html, body').animate({
        scrollTop: jQuery(e).offset().top
    }, 1000);
}
