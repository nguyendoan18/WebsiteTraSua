var ScriptFooter = `<script type="text/javascript">
        var c = document.body.className;
        c = c.replace(/woocommerce-no-js/, 'woocommerce-js');
        document.body.className = c;
    </script>
    <link rel="stylesheet" id="metaslider-flex-slider-css" href="~/Content/Asset/flexslider.css" type="text/css" media="all" property="stylesheet">
    <link rel="stylesheet" id="metaslider-public-css" href="~/Content/Asset/public.css" type="text/css" media="all" property="stylesheet">
    <script type="text/javascript" src="~/Content/Asset/scripts.js"></script>
    <script type="text/javascript" src="~/Content/Asset/jquery.blockUI.min.js"></script>
    <script type="text/javascript" src="~/Content/Asset/add-to-cart.min.js"></script>
    <script type="text/javascript" src="~/Content/Asset/js.cookie.min.js"></script>
    <script type="text/javascript" src="~/Content/Asset/woocommerce.min.js"></script>
    <script type="text/javascript" src="~/Content/Asset/cart-fragments.min.js"></script>
    <script type="text/javascript" src="~/Content/Asset/skip-link-focus-fix.js"></script>
    <script type="text/javascript" src="~/Content/Asset/global.js"></script>
    <script type="text/javascript" src="~/Content/Asset/jquery.scrollTo.js"></script>
    <script type="text/javascript" src="~/Content/Asset/init.js"></script>
    <script type="text/javascript" src="~/Content/Asset/option-selectors.js"></script>
    <script type="text/javascript" src="~/Content/Asset/api.jquery.js"></script>
    <script type="text/javascript" src="~/Content/Asset/plugin.js"></script>
    <script type="text/javascript" src="~/Content/Asset/appear.js"></script>
    <script type="text/javascript" src="~/Content/Asset/cs.script.js"></script>
    <script type="text/javascript" src="~/Content/Asset/datepicker-min.js"></script>
    <script type="text/javascript" src="~/Content/Asset/ekko-lightbox.min.js"></script>
    <script type="text/javascript" src="~/Content/Asset/main.js"></script>
    <script type="text/javascript" src="~/Content/Asset/custom.js"></script>
    <script type="text/javascript" src="~/Content/Asset/ajax.js"></script>
    <script type="text/javascript" src="~/Content/Asset/wp-embed.min.js"></script>
    <script type="text/javascript" src="~/Content/Asset/jquery.flexslider.min.js"></script>
    <script type="text/javascript">
        var metaslider_108 = function ($) {
            $('#metaslider_108').addClass('flexslider');
            $('#metaslider_108').flexslider({
                slideshowSpeed: 3000,
                animation: "fade",
                controlNav: true,
                directionNav: false,
                pauseOnHover: true,
                direction: "horizontal",
                reverse: false,
                animationSpeed: 600,
                prevText: "Previous",
                nextText: "Next",
                fadeFirstSlide: false,
                slideshow: true
            });
            $(document).trigger('metaslider/initialized', '#metaslider_108');
        };
        var timer_metaslider_108 = function () {
            var slider = !window.jQuery ? window.setTimeout(timer_metaslider_108, 100) : !jQuery.isReady ? window.setTimeout(timer_metaslider_108, 1) : metaslider_108(window.jQuery);
        };
        timer_metaslider_108();
    </script>
`;
