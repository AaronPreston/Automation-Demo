var currentTask = "Begin";
var searching = false;

$(document).ready(function () {
  setTimeout(function () {
    $(".output-panel").css("top", "0");
  }, 100);
});
//https://localhost:44333/api/WebSnapshot/aaronpreston.dev

$(".input").keypress(function (e) {
  if (e.keyCode == 13) {
    findItem();
    searchAnimation();
  }
});

$(".submit-button").click(function () {
  findItem();
  searchAnimation();
});

$(".next-button").click(function () {
  if (currentTask === "Begin") {
    $(".output").html("Enter any item name to check its price.");
    $(".input-panel").css("display", "inline");
    $(".next-button").html(`<i class='fas fa-arrow-circle-right'></i>`);
    $(".next-button").addClass("button-bottom-right");
    currentTask = "Price Calculation";
  } else if (currentTask === "URL Screenshot") {
    $(".output").html("Enter any website URL");
  }
});

function findItem() {
  $(".output-panel").css("top", "-250px");
  $(".return-panel").html(`
  <div class="link-box">
    <div class='loading'>Searching</div>
  </div>
  `);

  searching = true;

  $.get("https://localhost:44333/api/Price/" + $(".input").val(), function (
    data
  ) {
    searching = false;
    $(".return-panel").html(
      `
        <div class="link-box">
          <div class="response">You can expect to pay about $` +
        data[0] +
        ` USD.</div>         
        </div>
`

      /*
        `
    <div class="link-box"><div class="title">` +
          data[0] +
          `</div>
          <div class="url">` +
          $(".input").val() +
          `</div>
          <div class="description">` +
          data[1] +
          `</div>
          <img class="screenshot" src="" />
          </div>
  `
  */
    );
    /*
    $(".screenshot").attr(
      "src",
      `data:image/png;base64,${data[2].fileContents}`
    );
    */
  });
}

function searchAnimation() {
  var count = 1;
  var waitingForReturn = setInterval(function () {
    if (count % 2 === 0) {
      $(".submit-button").css("background-color", "gray");
    } else {
      $(".submit-button").css("background-color", "rgb(90, 90, 90)");
    }
    count++;
    if (!searching) {
      $(".submit-button").css("background-color", "gray");
      clearInterval(waitingForReturn);
    }
  }, 500);
}
