$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/FHome/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += `<div class="clear_ col-xs-12 col-sm-12 col-md-6 col-lg-6 product type-product post-192 status-publish last instock product_cat-ca-phe-cam-hung product_cat-ca-phe-pha-viet product_cat-ca-phe-the-gioi product_cat-do-uong has-post-thumbnail sale shipping-taxable purchasable product-type-simple">
                                        <div class="wrp_item_small">
                                            <div class="product-box product_grid_2">
                                                <div class="product_mini_2 clearfix">
                                                    <div class="img_product">
                                                        <a class="product-img" href="/san-pham/ca-phe-trung/" title="${item.title}">
                                                            <img width="150" height="150" src="${item.image}" class="attachment-thumbnail size-thumbnail wp-post-image" alt="${item.title}" srcset="/wp-content/uploads/2020/06/p-1-150x150.jpg 150w, /wp-content/uploads/2020/06/p-1-300x300.jpg 300w, /wp-content/uploads/2020/06/p-1-100x100.jpg 100w, /wp-content/uploads/2020/06/p-1.jpg 600w" sizes="100vw">
                                                        </a>
                                                    </div>
                                                    <div class="product-info">
                                                        <div class="infor_prd">
                                                            <h3 class="name_product">
                                                                <a href="/san-pham/ca-phe-trung/" title="${item.title}" class="product-name">
                                                                    <span class="name_product">${item.title}</span>
                                                                </a>
                                                            </h3>
                                                        </div>
                                                        <div class="price_base ">
                                                            <div class="price-box clearfix">
                                                                <div class="special-price"> <span class="price product-price"><span class="woocommerce-Price-amount amount">${item.price}<span class="woocommerce-Price-currencySymbol">₫</span></span></span> </div>
                                                            </div>
                                                        </div>
                                                        <div class="summary_grid">
                                                            <div class="rte description text2line">
                                                                ${item.description}
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>`;
            });
            $('._RenderItem').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}