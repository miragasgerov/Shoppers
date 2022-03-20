$(function() {
    $('.tab-menu a').click(function (e) {
        e.preventDefault()
        $(this).tab('show')
      })
  })



     


    //Click Basket icon open sidebar

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



    // Filter Price

    let min_price = 0;
    let max_price = 1000;
    
    $(document).ready(function () {
      showAllItems(); //Display all items with no filter applied
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
    




    //Click ul open new ul shop


    var menSpan = document.getElementById("menSpan");
    var womenSpan = document.getElementById("womenSpan");
    var childrenSpan = document.getElementById("childrenSpan");
    var menListCategory = document.getElementById("menListCategory");
    var womenListCategory = document.getElementById("womenListCategory");
    var childrenListCategory = document.getElementById("childrenListCategory");


    
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

