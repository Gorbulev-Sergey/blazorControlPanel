// Функция, которая возвращает содержимое элемента редактора (div contenteditable=true)
var editor_html = function (editor_id) {
    return $(editor_id).html();
};
// Функция, которая возвращает содержимое элемента редактора (div contenteditable=true)
var editor_html = function () {
    return $("#editor").html();
};













/*Функция, которая очищает формат*/
var clear_formate = function () {
    var selectedElement = window.getSelection().focusNode.parentNode;
    $(selectedElement).removeAttr();
};
// Переменная, в которой хранится выделенный объект
var range;
// Функция вставки картинки или любого другого объекта в редактор
var insert_object = function (jq_editor, jq_object) {
    if (range.startContainer.id === $(jq_editor).attr('id') || range.startContainer.parentNode.id === $(jq_editor).attr('id') || range.startContainer.parentNode.parentNode.id === $(jq_editor).attr('id')) {
        // Создаём картинку для вставки
        $(range).focus();
        range.deleteContents();
        var el = document.createElement("div");
        el.innerHTML = $(jq_object).prop('outerHTML');
        range.insertNode(el.children[0]);
    }
};
// Функция, которая показывает html код редактора
var show_code = function (send, jq_editor) {
    if ($(send).hasClass('code')) {
        $(send).removeClass('code');
        $(send).button('toggle');
        $(jq_editor).css('white-space', 'normal');
        $(jq_editor).html($.parseHTML($(jq_editor).text()));
    }
    else {
        $(send).addClass('code');
        $(send).button('toggle');
        $(jq_editor).css('white-space', 'pre-wrap');
        $(jq_editor).text($(jq_editor).html());
    }
};