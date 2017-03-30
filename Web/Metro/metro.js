document.write("<link rel='stylesheet' type='text/css' href='" + theme_root + "site.css' />");
document.write("<link rel='stylesheet' type='text/css' href='" + theme_root + "metro.css' />");
document.write("<link rel='stylesheet' type='text/css' id='style_color' href='" + theme_root + "color/" + (cur_color % 12) + ".css' />");

$(function () {

    bindWindowResize(function () {
        autoHeightDynamic('document', 46);
    });

    $(".search > .ad button,.body > ul.tab li, li input[type='button'], li input[type='submit'], li button, .portal > .head .title, .portal > .head .title > .text, .portal > .head .title > .menu, .portal > .head .button > div, .portal > .menu li, .portal > .document .submenu li:not(.sub),.portal > .head .action .btn, .portal > .head .info > .avatar,.avatar_detail li.right li.action, .setting_detail > .action").on("mouseenter mouseleave", function () { $(this).toggleClass("hover"); });

    //MainMenuToggle();
    //InitColorChange();
    //AvatarMenuToggle();
    //SettingMenuToggle();
    $('.setting').hide();

    $('.logout').click(function () {
        if (confirm('您确定要退出系统吗？'))
            location.href = '../SignOut.aspx';
    });

    //绑定分隔条点击事件
    bindSpliterClick();

    //点击第一个菜单
    $('.portal > .menu li:first').get(0).click();
});

function bindSpliterClick() {
    /// <summary>
    /// 绑定分隔条点击事件
    /// </summary>

    $('.spliter-wrap').click(function () {
        var menuContainer = $('.document > .submenu');
        //显示菜单
        if (menuContainer.is(':hidden')) {

            $('.document > .content').animate({ 'margin-left': 180 }, 250, function () {
                menuContainer.show(100);
                $('.spliter').removeClass('right');
            });
        }
            //隐藏菜单
        else {
            $('.document > .content').animate({ 'margin-left': 7 }, 250);

            menuContainer.hide(250, function () {
                $('.spliter').addClass('right');
            });
        }
    });
}

function bindWindowResize(func) {
    /// <summary>
    /// 给窗体绑定窗体大小改变事件
    /// </summary>
    /// <param name="func">事件函数</param>
    $(window).bind("resize", function (event) {
        func();
    });
    // 给窗体绑定加载事件
    $(window).bind("load", function (event) {
        func();
    });
}

function autoHeightDynamic(elemId, offset) {
    /// <summary>
    /// 根据窗口大小，自动设置elemId元素的高度
    /// </summary>
    /// <param name="elemId">要调整高度的元素Id</param>
    /// <param name="offset">要减去的偏移量</param>
    var eleHeight;
    if (document.documentElement && document.documentElement.clientHeight > 0)
        eleHeight = document.documentElement.clientHeight;
    else
        eleHeight = document.body.clientHeight;

    if (document.getElementById(elemId)) {

        var height = eleHeight - offset;
        if (height >= 0)
            document.getElementById(elemId).style.height = height + "px";
    }
}

var COLOR_TEMPLATES = [
	["", "", "#501cd8", "", "", ""], //  0
	["", "", "#7c4fe5", "", "", ""], //  1
	["", "", "#8c0095", "", "", ""], //  2
	["", "", "#dc4fad", "", "", ""], //  3
	["", "", "#ad193d", "", "", ""], //  4
	["", "", "#d24726", "", "", ""], //  5
	["", "", "#f97000", "", "", ""], //  6
	["", "", "#82ba01", "", "", ""], //  7
	["", "", "#008b18", "", "", ""], //  8
	["", "", "#00ad79", "", "", ""], //  9
	["", "", "#03b3b1", "", "", ""], // 10
	["", "", "#0099dc", "", "", ""]
];


function GetColor(hIdx, lvl) {
    if (!hIdx) hIdx = 0;
    return COLOR_TEMPLATES[hIdx % 12][lvl];
}

function InitColorChange() {
    $(".setting_detail > .clrpanel > div").each(function () {
        var clr = $(this).attr("color");
        $(this).css("background-color", GetColor(clr, 2));
        $(this).hover(function () {
            $("#style_color").prop("href", theme_root + "color/" + $(this).attr("color") + ".css");
            //UpdateColor(parseInt($(this).attr("color")));
        }, function () {
            $("#style_color").prop("href", theme_root + "color/" + (cur_color % 12) + ".css");
            //UpdateColor();
        }).click(function () {
            var mi = $(".portal > .head > .title")[0].item;
            mi.color = cur_color = parseInt($(this).attr("color"));
            $("#" + mi.id).css("background-color", GetColor(mi.color, 2));
        });
    });
}


function MainMenuToggle() {
    var isFocus = false;
    $(".portal > .head .menu > .icon").on("click", function () {
        if ($(":animated").length) return false;
        if (isFocus) {
            $(".portal .menu_helper").blur();
        }
        else {
            $(".portal .menu_helper").focus();
        }
        return false;
    });
    $(".portal .menu_helper").focus(function () {
        $(".portal > .menu").css({ opacity: 0 });
        $(".portal > .menu").show();
        $(".portal > .menu").animate({ opacity: 1 }, 250, function () { isFocus = true; });
    }).blur(function () {
        $(".portal > .menu").animate({ opacity: 0 }, 250, function () {
            $(".portal > .menu").hide();
            isFocus = false;
        });
    });
}

function initSubMenu(obj, hasChild) {
    $('#mainMenuName').html($(obj).data('name'));

    if (!hasChild) {
        $('.document > .content').css({ 'margin-left': 0 });
        $('#submenu').hide();
        $('#spliter-wrap').hide();

        clickMenu(obj);
        return;
    }

    $('.document > .content').css({ 'margin-left': 180 });
    $('#submenu').show();
    $('#spliter-wrap').show();

    var menuId = $(obj).data('id');

    $('#submenu').children().remove();
    $.ajax({
        type: "POST",
        url: "SubMenuHandler.ashx",
        data: { menuId: menuId },
        success: function (data) {
            $('#submenu').append(data);
        }
    });
}

function clickMenu(obj) {
    var link = $(obj).data("link");
    $('#submenu li').removeClass('cur');
    $(obj).addClass('cur');
    $('#iframe-main').attr('src', link);
}

function toggleMenu(obj) {
    $(obj).toggleClass("expand");
    var sub = $(obj).next(".sub");
    if (sub.hasClass("expand")) {
        sub.animate({ height: 0 }, function () {
            sub.removeClass("expand");
        });
    }
    else {
        sub.css({ height: "auto" });
        var dstHeight = sub.height();
        sub.css({ height: 0 });
        sub.addClass("expand");
        sub.animate({ height: dstHeight }, function () {
            sub.css({ height: "auto" });
        });

        setTimeout(function () {
            sub.find('li:first').get(0).click();
        }, 50);
    }
}

function AvatarMenuToggle() {
    var isAvatarFocus = false;
    $(".portal > .head .info > .avatar, .index_page .avatar_index a").on("click", function () {
        if ($(":animated").length) return false;
        if (isAvatarFocus) {
            $(".avatar_detail .helper").blur();
        }
        else {
            $(".avatar_detail").css({ height: 1 }).show();
            $(".avatar_detail .helper").focus();
        }
        return false;
    });
    $(".avatar_detail .helper").focus(function () {
        $(".avatar_detail")
			.animate({ height: 190 }, 200, function () {
			    isAvatarFocus = true;
			    $(".portal > .head .info > .avatar").addClass("cur");
			});
    }).blur(function () {
        setTimeout(function () {
            $(".avatar_detail").animate({ height: 1 }, 200, function () {
                $(".avatar_detail").hide();
                isAvatarFocus = false;
                $(".portal > .head .info > .avatar").removeClass("cur");
            });
        }, 100);
    });
}

function SettingMenuToggle() {
    var isSettingFocus = false;
    $(".portal > .head .info > .button .setting").on("click", function () {
        if ($(":animated").length) return false;
        if (isSettingFocus) {
            $(".setting_detail .helper").blur();
        }
        else {
            $(".setting_detail").css({ height: 1 }).show();
            $(".setting_detail .helper").focus();
        }
        return false;
    });
    $(".setting_detail .helper").focus(function () {
        $(".setting_detail").animate({ height: 225 }, 250, function () {
            isSettingFocus = true;
            $(".portal > .head .info > .button .setting").addClass("cur");
        });
    }).blur(function () {
        $(".setting_detail").animate({ height: 1 }, 250, function () {
            $(".setting_detail").hide();
            isSettingFocus = false;
            $(".portal > .head .info > .button .setting").removeClass("cur");
        });
    });
}