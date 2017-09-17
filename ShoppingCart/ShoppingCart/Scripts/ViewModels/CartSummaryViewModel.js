function CartSummaryViewModel(model) {
    var self = this;

    self.cart = model;
    self.cart.cartItems.foreach((cartItem, index) => {
        cartItem.quantity = ko.observable(cartItem.quantity).extend({ subTotal: cartItem.book.salePrice });
    })

    self.cart.cartItems = ko.observableArray(self.cart.cartItems);

    self.cart.total = self.cart.cartItems.total();

    self.showCart = function () {
        $('#cart').popover('toggle');
    };

    self.fadeIn = function (element) {
        setTimeout(function () {
            $('#cart').popover('show');

            $(element).slideDown(function () {
                setTimeout(function () {
                    $('#cart').popover('hide');
                }, 2000);
            });
        }, 100);
    };

    $('#cart').popover({
        html: true,
        content: function () {
            return $('#cart-summary').html();
        },
        title: 'Cart Details',
        placement: 'bottom',
        animation: true,
        trigger: 'manual'
    });
};

if (cartSummaryData !== undefined) {
    var cartSummaryViewModel = new CartSummaryViewModel(cartSummaryData);
    ko.applyBindings(cartSummaryViewModel, documente.getElementById("cart-details"));
} else {
    $('.body-content').prepend('<div class="alert alert-danger"><strong>Error!</strong> Could not find cart summary.</div>');
}