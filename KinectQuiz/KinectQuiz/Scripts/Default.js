'use strict';

var context = SP.ClientContext.get_current();
var user = context.get_web().get_currentUser();
var quizCollection;

$(document).ready(function () {
    loadQuizCollection();
    //getQuizCollection();
    $.when(loadQuizCollection).done(getQuizCollection);
});

function getQuizCollection() {
    var deferred = $.Deferred();

    quizCollection = context.get_web().get_lists();
    context.load(quizCollection, "Include(Title, Id)");
    context.executeQueryAsync(onGetQuizCollection, onError);

    return deferred.promise();
}

function onGetQuizCollection() {
    var quizEnumerator = quizCollection.getEnumerator();

    while (quizEnumerator.moveNext()) {
        var quiz = quizEnumerator.get_current();
        alert(quiz.get_title());

        if (quiz.get_title().indexOf("Quiz ") == 0) {
            $("#quizCollection").append($("<option>").text(quiz.get_title()).val(quiz.get_id().toString()));
        }
    }
}

function onError(sender, args) {
    alert("Request failed: " + args.get_message() + "\n" + args.get_stackTrace());
}

function loadQuizCollection() {
    var deferred = $.Deferred();
    
    createNewQuiz("Quiz Geography");
    createNewQuiz("Quiz History");
    createNewQuiz("Quiz English");

    return deferred.promise();
}

function createNewQuiz(title) {
    //alert(title + " = " + listExists(title));

    if (!listExists(title)) {
        var info = new SP.ListCreationInformation();
        info.set_title(title);
        info.set_templateType(SP.ListTemplateType.genericList);

        var list = context.get_web().get_lists().add(info);
        context.load(list);

        context.executeQueryAsync(function () { }, onError);
    }
}

function listExists(title) {
    return context.get_web().get_lists().getByTitle(title) != "undefined";
}

function startQuiz() {
    alert($("#quizCollection").val());
}
