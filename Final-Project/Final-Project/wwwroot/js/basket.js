//let products = [];

//if (localStorage.getItem("products") != null) {
//  products = JSON.parse(localStorage.getItem("products"));
//}

//let tableBody = document.querySelector(".table .table-body");
//let total = 0;
//for (let product of products) {
//  tableBody.innerHTML += `<tr>
//    <td scope="col" cat-id="${product.id}"><img src="${
//    product.image
//  }" height="100px" width="100px" class="card-img-top" alt="..."></td>
//    <td scope="col">${product.name}</td>
//    <td scope="col"><span>${product.cost}</span> $</td>
//    <td scope="col"><i class="fa-solid fa-minus"></i><span class="Count">${
//      product.count
//    }</span><i class="fa-solid fa-plus"></i></td>
//    <td scope="col"><span>${product.cost * product.count}</span>$</td>
//    <td scope="col" class="icon-del"><i class="fa-solid fa-trash"></i></td>
//  </tr>`;

//  total += product.cost * product.count;
//}
//let shipping = document.querySelector("#ship-cost").innerText;
//let gst = document.querySelector("#ship-cost-second").innerText;
//document.querySelector("#subtotal").innerHTML = total;
//document.querySelector("#totalprice").innerHTML =
//  parseFloat(shipping) + parseFloat(gst) + parseFloat(total);

////////////////Increment & Decrement////////////////////////
//var inc = document.getElementsByClassName("fa-plus");
//var dec = document.getElementsByClassName("fa-minus");
//for (let i = 0; i < inc.length; i++) {
//  var button = inc[i];
//  button.addEventListener("click", function (event) {
//    var buttonclick = event.target;
//    var numbertd = buttonclick.parentNode.children[1];
//    var number = numbertd.innerText;
//    var newnumber = parseInt(number) + 1;
//    numbertd.innerText = newnumber;
//    if (numbertd.innerText == newnumber) {
//      let old = this.parentNode.nextElementSibling.firstElementChild;
//      let oldcost = old.innerText;
//      let newcost =
//        parseFloat(oldcost) +
//        parseFloat(
//          this.parentNode.previousElementSibling.firstElementChild.innerText
//        );
//      old.innerText = newcost;

//      var subtotal = document.querySelector("#subtotal");
//      var totalprice = document.querySelector("#totalprice");
//      var oldsub = subtotal;
//      var oldsubtotal = oldsub.innerText;
//      var newsub =
//        parseFloat(oldsubtotal) +
//        parseFloat(
//          this.parentNode.previousElementSibling.firstElementChild.innerText
//        );
//      oldsub.innerText = newsub;
//      var oldtotal = totalprice;
//      var oldtotalprice = oldtotal.innerText;
//      var newtotal =
//        parseFloat(oldtotalprice) +
//        parseFloat(
//          this.parentNode.previousElementSibling.firstElementChild.innerText
//        );
//      oldtotal.innerText = newtotal;
//    }
//  });
//}

//for (let i = 0; i < dec.length; i++) {
//  var button = dec[i];
//  button.addEventListener("click", function (event) {
//    var buttonclick = event.target;
//    var numbertd = buttonclick.parentNode.children[1];
//    var number = numbertd.innerText;
//    var newnumber = parseInt(number) - 1;
//    numbertd.innerText = newnumber;
//    if (newnumber == 0) {
//      let id = parseInt(
//        this.parentNode.parentNode.firstElementChild.getAttribute("cat-id")
//      );
//      products = products.filter((m) => m.id != id);
//      localStorage.setItem("products", JSON.stringify(products));
//      this.parentNode.parentNode.remove();
//      document.querySelector("sup").innerText = products.length;
//    }
//    if (numbertd.innerText == newnumber) {
//      let old = this.parentNode.nextElementSibling.firstElementChild;
//      let oldcost = old.innerText;
//      let newcost =
//        parseFloat(oldcost) -
//        parseFloat(
//          this.parentNode.previousElementSibling.firstElementChild.innerText
//        );
//      old.innerText = newcost;

//      var subtotal = document.querySelector("#subtotal");
//      var totalprice = document.querySelector("#totalprice");
//      var oldsub = subtotal;
//      var oldsubtotal = oldsub.innerText;
//      var newsub =
//        parseFloat(oldsubtotal) -
//        parseFloat(
//          this.parentNode.previousElementSibling.firstElementChild.innerText
//        );
//      oldsub.innerText = newsub;
//      var oldtotal = totalprice;
//      var oldtotalprice = oldtotal.innerText;
//      var newtotal =
//        parseFloat(oldtotalprice) -
//        parseFloat(
//          this.parentNode.previousElementSibling.firstElementChild.innerText
//        );
//      oldtotal.innerText = newtotal;
//    }
//  });
//}

///////////////////////////////////////////////////////////////
//let deleteIcon = document.querySelectorAll(".icon-del i");

//deleteIcon.forEach((element) => {
//  element.addEventListener("click", function () {
//    let id = parseInt(
//      this.parentNode.parentNode.firstElementChild.getAttribute("cat-id")
//    );
//    products = products.filter((m) => m.id != id);
//    localStorage.setItem("products", JSON.stringify(products));
//    this.parentNode.parentNode.remove();
//    document.querySelector("sup").innerText = products.length;

//    Swal.fire({
//      position: "top-center",
//      icon: "success",
//      title: "Product deleted",
//      showConfirmButton: false,
//      timer: 1000,
//    });
//  });
//});
//document.querySelector("sup").innerText = products.length;

/////////////////////////////////////////////////////////////////////////////////
//$(function () {
//  let scrollSection = document.getElementById("scroll-section");

//  window.onscroll = function () {
//    scrollFunction();
//  };

//  function scrollFunction() {
//    if (
//      document.body.scrollTop > 195 ||
//      document.documentElement.scrollTop > 195
//    ) {
//      scrollSection.style.top = "0";
//    } else {
//      scrollSection.style.top = "-200px";
//      $("div").removeClass("inActive");
//    }
//  }
//});

//let dropdownBtnn = document.querySelectorAll(".dropdown-btnn");

//dropdownBtnn.forEach((element) => {
//  element.addEventListener("click", function () {
//    console.log(this.nextElementSibling);
//    this.nextElementSibling.classList.toggle("drop-show");
//  });
//});
























(function () {
    function c(a) { this.t = a } function l(a, b) { for (var e = b.split("."); e.length;) { if (!(e[0] in a)) return !1; a = a[e.shift()] } return a } function d(a, b) {
        return a.replace(h, function (e, a, i, f, c, h, k, m) { var f = l(b, f), j = "", g; if (!f) return "!" == i ? d(c, b) : k ? d(m, b) : ""; if (!i) return d(h, b); if ("@" == i) { e = b._key; a = b._val; for (g in f) f.hasOwnProperty(g) && (b._key = g, b._val = f[g], j += d(c, b)); b._key = e; b._val = a; return j } }).replace(k, function (a, c, d) {
            return (a = l(b, d)) || 0 === a ? "%" == c ? (new Option(a)).innerHTML.replace(/"/g, "&quot;") :
                a : ""
        })
    } var h = /\{\{(([@!]?)(.+?))\}\}(([\s\S]+?)(\{\{:\1\}\}([\s\S]+?))?)\{\{\/\1\}\}/g, k = /\{\{([=%])(.+?)\}\}/g; c.prototype.render = function (a) { return d(this.t, a) }; window.t = c
})();
// end of 't';

Number.prototype.to_$ = function () {
    return "$" + parseFloat(this).toFixed(2);
};
String.prototype.strip$ = function () {
    return this.split("$")[1];
};

var products = [];
if (localStorage.getItem("products") != null) {
  products = JSON.parse(localStorage.getItem("products"));
}

var app = {

    shipping: 5.00,
    products: products,
    

    removeProduct: function () {
        "use strict";

        var item = $(this).closest(".shopping-cart--list-item");

        item.addClass("closing");
        window.setTimeout(function () {
            item.remove();
            app.updateTotals();
        }, 500); // Timeout for css animation
    },

    addProduct: function () {
        "use strict";

        var qtyCtr = $(this).prev(".product-qty"),
            quantity = parseInt(qtyCtr.html(), 10) + 1;

        app.updateProductSubtotal(this, quantity);
    },

    subtractProduct: function () {
        "use strict";

        var qtyCtr = $(this).next(".product-qty"),
            num = parseInt(qtyCtr.html(), 10) - 1,
            quantity = num <= 0 ? 0 : num;

        app.updateProductSubtotal(this, quantity);
    },

    updateProductSubtotal: function (context, quantity) {
        "use strict";

        var ctr = $(context).closest(".product-modifiers"),
            productQtyCtr = ctr.find(".product-qty"),
            productPrice = parseFloat(ctr.data("product-price")),
            subtotalCtr = ctr.find(".product-total-price"),
            subtotalPrice = quantity * productPrice;

        productQtyCtr.html(quantity);
        subtotalCtr.html(subtotalPrice.to_$());

        app.updateTotals();
    },

    updateTotals: function () {
        "use strict";

        var products = $(".shopping-cart--list-item"),
            subtotal = 0,
            shipping;

        for (var i = 0; i < products.length; i += 1) {
            subtotal += parseFloat($(products[i]).find(".product-total-price").html().strip$());
        }

        shipping = (subtotal > 0 && subtotal < (100 / 1.06)) ? app.shipping : 0;

        $("#subtotalCtr").find(".cart-totals-value").html(subtotal.to_$());
        $("#taxesCtr").find(".cart-totals-value").html((subtotal * 0.06).to_$());
        $("#totalCtr").find(".cart-totals-value").html((subtotal * 1.06 + shipping).to_$());
        $("#shippingCtr").find(".cart-totals-value").html(shipping.to_$());
    },

    attachEvents: function () {
        "use strict";

        $(".product-remove").on("click", app.removeProduct);
        $(".product-plus").on("click", app.addProduct);
        $(".product-subtract").on("click", app.subtractProduct);
    },

    setProductImages: function () {
        "use strict";

        var images = $(".product-image"),
            ctr,
            img;

        for (var i = 0; i < images.length; i += 1) {
            ctr = $(images[i]),
                img = ctr.find(".product-image--img");

            ctr.css("background-image", "url(" + img.attr("src") + ")");
            img.remove();
        }
    },

    renderTemplates: function () {
        "use strict";

        var products = app.products,
            content = [],
            template = new t($("#shopping-cart--list-item-template").html());

        for (var i = 0; i < products.length; i += 1) {
            content[i] = template.render(products[i]);
        }

        $("#shopping-cart--list").html(content.join(""));
    }

};

app.renderTemplates();
app.setProductImages();
app.attachEvents();
