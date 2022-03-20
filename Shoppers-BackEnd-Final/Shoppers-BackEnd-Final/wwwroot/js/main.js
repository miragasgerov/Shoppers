$(document).on("click", ".add-basket", function (e) {
    e.preventDefault();


    let url = $(this).attr("href");
    fetch(url)
        .then(response => response.json())
        .then(data => {
            console.log(data)
            $('.basketBarHover').html("");
            for (var i = 0; i < data.basketItems.length; i++) {
                let elem = `                                    <div class="shoppingBar mt-3" id="shoppingBar">

                                        <div class="shoppingBarSec d-flex">
                                            <div class="shoppingBarImg">
                                                <img src="/uploads/product/`+ data.basketItems[i].posterImage +`" class="img-fluid">
                                            </div>

                                            <div class="shoppingBarText ms-4 d-flex">
                                                <div class="shoppingBarLeftText">
                                                    <h6>`+ data.basketItems[i].name +` </h6>
                                                    <p><span class="me-2">`+ data.basketItems[i].count + `x</span> ₼` + data.basketItems[i].price +`</p>
                                                </div>
                                                <div class="shoppingBarBtn mt-5">
                                                    <button type="button" class="heroBtn" style="width: 30px; height: 30px;">X</button>

                                                </div>
                                            </div>
                                        </div>

                                        <div class="shoppingBarBottom d-flex">
                                            <a asp-action="cart" asp-controller="order" class="mt-1">
                                                View Cart
                                                <i class="fa-solid fa-arrow-right"></i>
                                            </a>

                                            <a asp-action="checkout" asp-controller="shop" class="ms-auto checkShopBar">
                                                Checkout
                                                <i class="fa-solid fa-arrow-right "></i>
                                            </a>
                                        </div>

                                    </div>
`

                $('.basketBarHover').append($(elem));
            }
        })

    console.log(url)
})





$(function () {
    $('.tab-menu a').click(function (e) {
        e.preventDefault()
        $(this).tab('show')
    })
})



     



    var basketIconHover = document.getElementById("basketIconHover");
    var shoppingBar = document.getElementById("shoppingBar");


    basketIconHover.onclick = function(e) {
        console.log(basketIconHover);
        e.preventDefault();
        shoppingBar.style.visibility = 'visible';
    };


    basketIconHover.addEventListener('click', () => {
        shoppingBar.style.visibility = 'visible'
    })

    document.addEventListener('click', e => {
        if (
            !e.composedPath().includes(shoppingBar) &&
            !e.composedPath().includes(basketIconHover)
        ) {
            shoppingBar.style.visibility = 'hidden'

        }
    })




    let min_price = 0;
    let max_price = 1000;
    
    $(document).ready(function () {
      showAllItems(); 
    });
    
    $("#min-price").on("change mousemove", function () {
      min_price = parseInt($("#min-price").val());
      $("#min-price-txt").text("$" + min_price);
      showItemsFiltered();
    });
    
    $("#max-price").on("change mousemove", function () {
      max_price = parseInt($("#max-price").val());
      $("#max-price-txt").text("$" + max_price);
      showItemsFiltered();
    });
    






    var menSpan = document.getElementById("Men-Span");
    var womenSpan = document.getElementById("Women-Span");
    var childrenSpan = document.getElementById("Children-Span");
    var menListCategory = document.getElementById("Men-ListCategory");
    var womenListCategory = document.getElementById("Women-ListCategory");
    var childrenListCategory = document.getElementById("Children-ListCategory");


    
    menSpan.onclick = function(e) {
      console.log(menSpan);
      e.preventDefault();
      menListCategory.style.display = 'block';
  };


  menSpan.addEventListener('click', () => {
    menListCategory.style.display = 'block'
  })

  document.addEventListener('click', e => {
      if (
          !e.composedPath().includes(menListCategory) &&
          !e.composedPath().includes(menSpan)
      ) {
        menListCategory.style.display = 'none'

      }
  })


  womenSpan.onclick = function(e) {
    console.log(womenSpan);
    e.preventDefault();
    womenListCategory.style.display = 'block';
};


womenSpan.addEventListener('click', () => {
  womenListCategory.style.display = 'block'
})

document.addEventListener('click', e => {
    if (
        !e.composedPath().includes(womenListCategory) &&
        !e.composedPath().includes(womenSpan)
    ) {
      womenListCategory.style.display = 'none'

    }
})


childrenSpan.onclick = function(e) {
  console.log(childrenSpan);
  e.preventDefault();
  childrenListCategory.style.display = 'block';
};


childrenSpan.addEventListener('click', () => {
  childrenListCategory.style.display = 'block'
})

document.addEventListener('click', e => {
  if (
      !e.composedPath().includes(childrenListCategory) &&
      !e.composedPath().includes(childrenSpan)
  ) {
    childrenListCategory.style.display = 'none'

  }
})

