$(document).ready(function () {
    var setEditableEvents = function (elems) {
        elems.each(function () {
            var elem = $(this);
            elem.hover(
                function () {
                    var t = $(this);
                    if (t.hasClass('editable')) {
                        $(this).find(".delPill").toggleClass("shown");
                    }
                }
            );

            elem.find(".delPill").click(
                function () {
                    var t = $(this).parent();
                    var parent = $(t[0]).parent();
                    t[0].remove();
                    if (parent.find(".delPill").length == 0)
                        parent.empty();
                }
            );
        });
    }

    setEditableEvents($('.pill'));

    $('.approve').click(function(){
        editStatus("EditCapture", getData("approve", $(this).parent()));
        return false;
    });

    $('.reject').click(function(){
        editStatus("EditCapture", getData("reject", $(this).parent()));
        return false;
    });

    // dont use [0] in production
    $($('.tagsWrapper')[0]).each(function () {
        var th = $(this);
        var tagger = th.find('.tagger');
        var input = th.find('.tagName');

        // show and focus
        th.find('.addTag').click(function (e) {
            tagger.toggleClass('hide');
            tagger.css({ top: e.pageY , left: e.pageX });
            input.focus();
        });

        // clear on focus
        input.focus(function () {
            this.value = '';
        });

        var closeTagger = function () {
            input.autocomplete("close");
            tagger.toggleClass('hide');
        }

        input.autocomplete({
            autoFocus: true,
            source: ["Fern Growth", "two", "three", "four"],
            select: function (event, ui) {
                selected = true;
                // create, append, events new tag
                var newTag = $("<div class='pill editable' data-type='tag'>" +
                    "<div class='delPill'>x</div><div class='pillText'>" + ui.item.label + "</div></div>");
                th.find('.tags').append(newTag);
                setEditableEvents(newTag);

                // clear, close, hide
                closeTagger();
            }
        });

        input.keydown(function (e) {
            // close with ESC
            if (e.which === 27)
                closeTagger();
        })
    });

    var editStatus = function (url, data) {
        $.post(url, data, function (ans) {
            ans = $.parseJSON(ans);
            var capcard = $("[capture-card-id='" + ans.id + "']");
            if (capcard.length == 0)
                location.reload();
            else
                capcard.remove();
        });
    }
    var getData = function(status, elm) {
        var d = {};
        d.CaptureID = elm.attr('capture-id');
        d.Approval = status;
        d.Tags = [];
        d.Data = [];
        d.Note = "";

        try {
            $("[data-type='tag']").each(function () {
                var tag = {};
                var t = $(this);
                var id = t.attr("data-id");
                tag.tagid = id;
                tag.name = t.find('.pillText').val();
                tags.push(tag);
            });
        } catch (e) {
        }
        return d;
    }
});