/**
** WATER MARK
**/

// Numeric only control handler
jQuery.fn.ForceNumericOnly =
function () {
    return this.each(function () {
        $(this).keydown(function (e) {
            var key = e.charCode || e.keyCode || 0;
            // allow backspace, tab, delete, arrows, numbers and keypad numbers ONLY
            return (
                key == 8 ||
                key == 9 ||
                key == 46 ||
                (key >= 37 && key <= 40) ||
                (key >= 48 && key <= 57) ||
                (key >= 96 && key <= 105));
        })
    })
};

function onlyNumbers(evt) {
    var key;
    var keychar;

    if (window.event)
        key = window.event.keyCode;
    else if (e)
        key = e.which;
    else
        return true;
    keychar = String.fromCharCode(key);

    // control keys
    if ((key == null) || (key == 0) || (key == 8) ||
    (key == 9) || (key == 13) || (key == 27))
        return true;

    // numbers
    else if ((("0123456789").indexOf(keychar) > -1))
        return true;
    else {
        evt.preventDefault();
        return false;
    }


}

$.fn.watermark = function (css, text) {
    return this.each(function () {
        var i = $(this), w;
        i.focus(function () {
            w && !(w = 0) && i.removeClass(css).data('w', 0).val('');
        })
	.blur(function () {
	    !i.val() && (w = 1) && i.addClass(css).data('w', 1).val(text);
	})
	.closest('form').submit(function () {
	    w && i.val('');
	});
        i.blur();
    });
};

$.fn.removeWatermark = function () {
    return this.each(function () {
        $(this).data('w') && $(this).val('');
    });
};

/**
** UPDATE MESSAGES DIV
**/

function ShowSuccessfulMessage(message, summaryName, summaryServerName) {
    scroll(0, 0);
    if (summaryName == undefined)
        summaryName = "validationSummary";
    if (summaryServerName == undefined)
        summaryServerName = "validationServerSummary";

    if ($('#' + summaryName).attr("class") != "validation-summary-errors" &&
    $('#' + summaryServerName).attr("class") != "validation-summary-errors") {
        $("#Notice").addClass("successful-message");
        $("#Notice").removeClass("error-message");
        $('#NoticeMessage').html(message);
        $("#Notice").show();
        $("#Notice").delay(4000);
        $("#Notice").slideUp(400);
    }
}

function ShowErrorMessage(message, summaryName, summaryServerName) {
    scroll(0, 0);
    if (summaryName == undefined)
        summaryName = "validationSummary";
    if (summaryServerName == undefined)
        summaryServerName = "validationServerSummary";

    if ($('#' + summaryName).attr("class") != "validation-summary-errors" &&
    $('#' + summaryServerName).attr("class") != "validation-summary-errors") {
        $("#Notice").removeClass("successful-message");
        $("#Notice").addClass("error-message");
        $('#NoticeMessage').html(message);
        $("#Notice").show();
        //$("#Notice").delay(8000);
        //$("#Notice").slideUp(400);
    }
}

function CloseMessage() {
    $("#Notice").slideUp(400);
}

/**
** LOADING PANEL
**/
function ShowLoadingPanel() {
    loadingPanel.show();
    loadingPanel.show("Processing...");
}

function HideLoadingPanel() {
    loadingPanel.hide();
}

/**
** COLOUR GRID
**/
function ColorGridRow(column, checkValue, backgroundColor) {
    $(".grid tr:not(:first)").each(function () {

        var val = $(this).find("td:nth-child(" + column + ")").html();

        if (val == checkValue) {
            $(this).find("td").css("background-color", backgroundColor);
        }

    });
}

function ColorGridRowValue(column, checkValue, color) {
    $(".grid tr:not(:first)").each(function () {

        var val = $(this).find("td:nth-child(" + column + ")").html();

        if (val == checkValue) {
            $(this).find("td:nth-child(" + column + ")").css("color", color);
        }

    });
}