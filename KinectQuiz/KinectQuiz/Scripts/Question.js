'use strict';

var context = SP.ClientContext.get_current();
var user = context.get_web().get_currentUser();

$(document).ready(function () {
    loadQuiz();
});

function loadQuiz() {
    var title = "---"; //$.url.param("quiz");
    $("#quizTitle").text(title);
}
