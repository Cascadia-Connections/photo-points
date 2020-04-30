$(document).ready(function () {

    $(".editable").hover(
        function () {
            $(this).find(".delPill").toggleClass("shown");
        }
    );

    $(".delPill").click(
        function () {
            var t = $(this).parent();
            var parent = $(t[0]).parent();
            t[0].remove();
            if (parent.find(".delPill").length == 0)
                parent.empty();

        });

    $('.approve').click(function(){
        editStatus("EditCapture", getData("approve", $(this).parent()));
        return false;
    });
    $('.reject').click(function(){
        editStatus("EditCapture", getData("reject", $(this).parent()));
        return false;
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