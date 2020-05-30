﻿$(document).ready(function () {
   $("#deleteComment").hide();
   $("#updateComment").hide();
});

function addComment() {
   var comment = $("#comment").val();
   document.getElementById("displayComment").innerHTML = comment;
   $("#comment").hide();
   $("#submitComment").hide();
   $("#deleteComment").show();
   $("#updateComment").show();
}

function deleteComment() {
   var result = confirm("Are you sure you want to delete this note?");
   if (result == true) {
      window.location.reload();
   }
}

function updateComment() {
   var comment = $("#comment").val();
   document.getElementById("displayComment").innerHTML = comment;
   $("#deleteComment").hide();
   $("#comment").show();
   $("#submitComment").show();
   $("#updateComment").hide();

}