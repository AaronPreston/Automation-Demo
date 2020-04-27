var currentTask = "Begin";

$(document).ready(function () {
  setTimeout(function () {
    $(".output-panel").css("top", "0");
  }, 100);
});

$(".submit-button").click(function () {
  $(".output-panel").css("top", "-250px");
});

$(".next-button").click(function () {
  if (currentTask === "Begin") {
    $(".output").html("Enter any website URL");
    $(".input-panel").css("display", "inline");
    $(".next-button").html("<i class='fas fa-arrow-circle-right'></i>");
    $(".next-button").addClass("button-bottom-right");
    currentTask = "URL Screenshot";
  } else if (currentTask === "URL Screenshot") {
  }
});
