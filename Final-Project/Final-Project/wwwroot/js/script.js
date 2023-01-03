


$(function () {
  let scrollSection = document.getElementById("scroll-section");

  window.onscroll = function () {
    scrollFunction();
  };

  function scrollFunction() {
    if (
      document.body.scrollTop > 195 ||
      document.documentElement.scrollTop > 195
    ) {
      scrollSection.style.top = "0";
    } else {
      scrollSection.style.top = "-200px";
      $("div").removeClass("inActive");
    }
    }
    // Search-Product
    $(document).on("keyup", "#searchinp", function () {
        let inputVa = $(this).val().trim();
        $("#search-list-p li").slice(0).remove();
        //console.log("sss")
        $.ajax({
            method: "get",
            url: "/product/productsearch?search=" + inputVa,
            success: function (res) {
                $("#search-list-p").append(res);
            }
        })
    })
    //Search-Product
    //Search-Martyrs
    $(document).on("keyup", "#search-input", function () {
        let inputVal1 = $(this).val().trim();
        $("#searchlist li").slice(0).remove();
        $.ajax({
            method: "get",
            url: "unudulmazlar/Search?search=" + inputVal1,
            success: function (res) {
                $("#searchlist").append(res);
            }
        })
    })
    //Search-Martyrs
    //Search-Martyrs-Home

    $(document).on("keyup", "#search-inp", function () {
        let inputVal2 = $(this).val().trim();
        $("#search-list li").slice(0).remove();
        $.ajax({
            method: "get",
            url: "home/martyrs?search=" + inputVal2,
            success: function (res) {
                $("#search-list").append(res);
            }
        })
    })
    //Search-Martyrs-Home
 


});

let dropdownBtnn = document.querySelectorAll(".dropdown-btnn");


dropdownBtnn.forEach((element) => {
  element.addEventListener("click", function () {
    console.log(this.nextElementSibling);
    this.nextElementSibling.classList.toggle("drop-show");
  });
});

var swiper = new Swiper(".mySwiper", {
  slidesPerView: 4,
  loop: true,
  spaceBetween: 20,
  autoplay: {
    delay: 7000,
    disableOnInteraction: false,
  },
  breakpoints: {
    0: {
      slidesPerView: 1,
    },
    550: {
      slidesPerView: 1,
    },
    800: {
      slidesPerView: 1,
    },
    1000: {
      slidesPerView: 1,
    },
  },
  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },
});

$(function () {
  let headers = $("#black-slider .tab-menu .tab-header div");
  let contents = $("#black-slider .tab-menu .tab-body .swiperr");

  for (const header of headers) {
    $(header).on("click", function () {
      $(".active").removeClass("active");
      $(header).addClass("active");

      for (const content of contents) {
        if ($(header).attr("data-id") == $(content).attr("data-id")) {
          $(content).removeClass("d-none");
          var swiper = new Swiper(".mySwiper1", {
            slidesPerView: 4,
            loop: true,
            spaceBetween: 20,
            autoplay: {
              delay: 3000,
              disableOnInteraction: false,
            },
            breakpoints: {
              0: {
                slidesPerView: 1,
              },
              550: {
                slidesPerView: 2,
              },
              800: {
                slidesPerView: 3,
              },
              1000: {
                slidesPerView: 4,
              },
            },
            pagination: {
              el: ".swiper-pagination",
              clickable: true,
            },
          });
        } else {
          $(content).addClass("d-none");
        }
      }
    });
  }
});

var swiper = new Swiper(".mySwiper1", {
  slidesPerView: 4,
  loop: true,
  spaceBetween: 20,
  autoplay: {
    delay: 3000,
    disableOnInteraction: false,
  },
  breakpoints: {
    0: {
      slidesPerView: 1,
    },
    550: {
      slidesPerView: 2,
    },
    800: {
      slidesPerView: 3,
    },
    1000: {
      slidesPerView: 4,
    },
  },
  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },
});

var swiper = new Swiper(".mySwiper2", {
  slidesPerView: 5,
  loop: true,
  spaceBetween: 20,
  autoplay: {
    delay: 3000,
    disableOnInteraction: false,
  },
  breakpoints: {
    0: {
      slidesPerView: 1,
    },
    550: {
      slidesPerView: 2,
    },
    800: {
      slidesPerView: 4,
    },
    1000: {
      slidesPerView: 5,
    },
  },
  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },
});

/////////////////////////////////////////////////////////////

$("input").focus(function () {
  $(this).parents(".form-group").addClass("focused");
});

$("input").blur(function () {
  var inputValue = $(this).val();
  if (inputValue == "") {
    $(this).removeClass("filled");
    $(this).parents(".form-group").removeClass("focused");
  } else {
    $(this).addClass("filled");
  }
});

///////////////////////////////////////////////////////////////////////////

let basketBtns = document.querySelectorAll(".prod-add a");

let products = [];

if (localStorage.getItem("productes") != null) {
  products = JSON.parse(localStorage.getItem("products"));
}

basketBtns.forEach((basketBtn) => {
  basketBtn.addEventListener("click", function (e) {
    e.preventDefault();

    let productImage =
      this.parentNode.parentNode.firstElementChild.getAttribute("src");
    let productName =
      this.parentNode.parentNode.parentNode.nextElementSibling.firstElementChild
        .innerText;
    let productCost =
      this.parentNode.previousElementSibling.firstElementChild.lastElementChild
        .innerText;
    let productId = parseInt(
      this.parentNode.parentNode.parentNode.parentNode.getAttribute("cat-id")
    );
    let existProduct = products.find((m) => m.id == productId);
    let deleteProduct = products.delete;

    if (existProduct != undefined) {
      existProduct.count += 1;
    } else {
      products.push({
        id: productId,
        name: productName,
        cost: productCost,
        image: productImage,
        count: 1,
      });

      Swal.fire({
        position: "top-center",
        icon: "success",
        title: "Product added",
        showConfirmButton: false,
        timer: 1000,
      });
    }

    localStorage.setItem("products", JSON.stringify(products));
    document.querySelector("sup").innerText = productes.length;
  });
});

document.querySelector("sup").innerText = getProductsCount(products);
function getProductsCount(items) {
  let resultCount = 0;
  resultCount += items.length;
  return resultCount;
}
function getDeleteCount(items) {
  let resultCount = 0;
  for (const item of items) {
    resultCount -= 1;
  }
  return resultCount;
}
