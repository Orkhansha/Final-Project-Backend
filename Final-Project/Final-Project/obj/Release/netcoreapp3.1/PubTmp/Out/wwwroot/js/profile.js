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
});

let dropdownBtnn = document.querySelectorAll(".dropdown-btnn");

dropdownBtnn.forEach((element) => {
  element.addEventListener("click", function () {
    console.log(this.nextElementSibling);
    this.nextElementSibling.classList.toggle("drop-show");
  });
});

/////////////////////////////////////////////////////////////

let basketBtns = document.querySelectorAll(".prod-add a");

let products = [];

if (localStorage.getItem("products") != null) {
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
    document.querySelector("sup").innerText = products.length;
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
