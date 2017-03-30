/// <reference path="jquery-1.7.1-vsdoc.js" />
var theme_root = ___get_content_root("commonnocss.js");
var frm_stack = [];
var cur_color = 0, isIndex = false;
document.write("<script language='javascript' src='" + theme_root + "common_lang.js'></script>");

function PageInit() {
    $(".search > .ad button,.body > ul.tab li, li input[type='button'], li input[type='submit'], li button, .portal > .head .title, .portal > .head .title > .text, .portal > .head .title > .menu, .portal > .head .button > div, .portal > .menu li, .portal > .document .submenu li:not(.sub),.portal > .head .action .btn, .portal > .head .info > .avatar,.avatar_detail li.right li.action, .setting_detail > .action").live("mouseenter mouseleave", function () { $(this).toggleClass("hover"); });

    if ($("body > .portal").length) return PortalInit();
    if ($("body > .start").length) return StartInit();

    $(window).resize(ResizeFrame).triggerHandler("resize");
    Hint($(".search > input[type='text']"), "搜索");
    SetTitle($(".sitemap").text());

    InstallOpenAction();
    InstallListCheckBox();
    InstallBodyTab();
    InstallBodyPager();
    InstallAdSearch();
};

function ResizeFrame() {
    if ($("body").hasClass("noresize")) return;
    var height = $(window).height() - 50;
    if ($(".body > ul.tab").length) height -= 47;
    if ($(".sitemap").hasClass("hide") && $(".function").length == 0) height += 35;
    $(".body > .hscroll").css("height", height);
    if ($(".page").length) height -= 35;
    $(".index .body").css("height", height);
    if ($(".create .body .hscroll").length <= 0) {
        $(".create .body").css("height", height);
    }
};
function InstallOpenAction() {
    $("tr[href] > td").click(function () {
        if ($(this).hasClass("actioncol"))
            return;
        OpenWindow($(this).parent().attr("href"), $(this).parent().attr("winfeature"));
    });
    $("a[href]").click(function (event) {
        event.stopPropagation();
        if ($(this).attr("href") == "#")
            return false;
        else if ($(this).hasClass("open_action"))
            return false;
        else if ($(this).attr("href").indexOf("javascript:" == 0))
            return true;
        OpenWindow($(this).prop("href"), $(this).prop("target"));
        return false;
    });
    $(".open_action").click(function (event) {
        event.stopPropagation();
        if ($(this).attr("href") == "#")
            return false;
        OpenWindow($(this).attr("href"));
        return false;
    });
}

function InstallListCheckBox() {
    $("table input[type='checkbox'].cb_item").click(function (event) {
        event.stopPropagation();
    });
}

function InstallBodyTab() {
    $(".body > ul.tab li").click(function (event) {
        $(".body > .hscroll > ul:not(.tab)").removeClass("cur");
        $(".body > .hscroll > ul:not(.tab):eq(" + $(this).index() + ")").addClass("cur");
        $(".body > ul.tab li").removeClass("cur");
        $(this).addClass("cur");
        top.MoveAction();
        try {
            var tabWin = $(".body > .hscroll > ul.cur iframe")[0];
            if (tabWin) tabWin.contentWindow.$(tabWin.contentWindow).triggerHandler("resize");
        } catch (e) { }
    });
    $(".body > ul.tab li:first").click();
}

function InstallBodyPager() {
    $(".page a").each(function (idx, link) {
        var linkText = $(link).text().trim();
        if (linkText == "首页") $(link).addClass("pg first");
        else if (linkText == "上一页") $(link).addClass("pg prev");
        else if (linkText == "下一页") $(link).addClass("pg next");
        else if (linkText == "尾页") $(link).addClass("pg last");
        else return;
        $(link).text("　");
    });
}

function InstallAdSearch() {
    var pnl = $("<div class='search_panel'><div class='title'>高级搜索</div><div class='clear'></div></div>")
		.insertBefore(".index .sitemap");
    $(".index .function > .adsearch").insertBefore(pnl.children(".clear"));
    $(".search > .ad button").click(function () {
        $(".search_panel").show();
        var height = $(".search_panel").height();
        $(".search_panel").css("height", 1).animate({ height: height });
        return false;
    });
    $(".search_panel > .adsearch li.button .close").click(function () {
        $(".search_panel").animate({ height: 1 }, function () {
            $(".search_panel").hide();
            $(".search_panel").css("height", "auto");
        });
        return false;
    });
}

/* 窗口相关接口 */
function OpenWindow(url, feature, callback) {
    if (top != window) return top.OpenWindow(url, feature, callback);
    SetTitle("页面加载中");
    $(".portal > .head > .action").html("");
    if (typeof (feature) == "string") {
        var target = feature;
        if (feature.indexOf("{") == 0) {
            var w_feature = null;
            try {
                eval("w_feature=" + feature);
                target = w_feature.target;
            }
            catch (e) {
                target = null;
            }
        }
        if (target == "_self") {
            var topWin = $(".portal > .document > .content iframe:last")[0].contentWindow;
            FrameJumpHelper(url, topWin, topWin.location.href);
            return false;
        }
        if (target) {
            window.open(url, target);
            return false;
        }
    }
    var frmId = "frm_" + Math.random().toString().substring(2);
    var baseUrl = $(".portal > .document > .content iframe:last").get(0).contentWindow.location;
    var frmPop = $("<iframe id='" + frmId + "' frameborder='0' onload='MoveAction();'></iframe>").appendTo(".portal > .document > .content");
    FrameJumpHelper(url, frmPop.get(0).contentWindow, baseUrl);

    $(window).triggerHandler("resize");
    frm_stack.push(frmId);
    return false;
}
function FrameJumpHelper(url, fWin, baseUrl) {
    fWin.document.write("<html><head><base href='" + baseUrl + "' /></head><body><a id='jumper' href='" + url + "'></a></body></html>");
    var jumper = fWin.document.getElementById("jumper");
    if (jumper.click) {
        jumper.click();
    } else {
        var evt = fWin.document.createEvent('Event');
        evt.initEvent("click", true, true);
        jumper.dispatchEvent(evt);
    }
}
function CurColor(lvl) {
    if (top.cur_color < 0) top.cur_color = 0;
    var result = GetColor(top.cur_color, lvl);
    return result;
}

function CloseDialog() {
    // 关闭弹窗
}

function CloseWindow(norefresh) {
    // 关闭窗口，根据norefresh决定是否刷新父窗体
    if (!norefresh) {
        var _opener = WindowOpener();
        _opener.location.href = _opener.location.href;
    }
    var frmId = top.frm_stack.pop();
    //top.$("#" + frmId).prop("src", "about:blank");
    return false;
}

function RefreshOpener() {
    // 刷新父窗体操作
}

function WindowOpener() {
    // 获取打开窗体的引用
    return top.$(".portal > .document > .content iframe:last").prev().get(0).contentWindow;
}

function SubmitForm(action, paras) {
    // 模拟表格提交
    // action是form对应的action属性，paras是json形式的提交请求数据

    for (var i = 1; i < arguments.length; i++) {
        var paras = arguments[i];
        for (var para in paras) {
            if ($("#" + para).length <= 0) {
                $("<input type='hidden' name='" + para + "' id='" + para + "' value='" + paras[para] + "' />").appendTo("form");
            }
            $("#" + para).val(paras[para]);
        }
    }
    $("#mvc_command").val(action);
    $("form").submit();

    return false;
}

function SetTitle(title) {
    // 窗体的标题设置到父窗体，使得浏览器上能看到
    if (title && title.trim())
        top.document.title = title.trim() + " - 汕头市电子政务协同平台";
    else
        top.document.title = "汕头市电子政务协同平台";
}

function NavLocation(nav_location, query) {
    // 刷新detail窗口的地址为刷新detail窗口的地址为，query为查询参数
    if (!nav_location) return false;
    return false;
}
/* 窗口相关接口 结束*/


/* 通用open_action加载事件 *//*
function open_action() {
    var feature = {};
    if ($(this).attr("winfeature"))
        eval("feature=" + $(this).attr("winfeature"));
    if ($(this).attr("target"))
        feature.target = $(this).attr("target");
    OpenWindow($(this).attr("href"), feature);
    return false;
}
/* 通用open_action加载事件 结束*/


/* Portal相关操作 */
function PortalInit() {
    /* 获取一级菜单初始化 */
    $(".portal > .menu").html("");
    InitLv1Menus();

    /* 初始化页面 */
    $(".avatar_detail, .setting_detail").appendTo("body");
    $(".logout").live("click", function () {
        location.href = logouturl;
    });

    InitColorChange();

    Lv2TabMenuToggle();
    MainMenuToggle();
    AvatarMenuToggle();
    SettingMenuToggle();

    $(window).resize(ResizePortal).triggerHandler("resize");

    FrameMonitor();
}

function InitLv1Menus() {
    var DrawLv1Menu = function (mi, init) {
        cur_color = mi.color;
        if (!top.cur_color) top.cur_color = 0;
        $("#style_color").prop("href", theme_root + "color/" + (top.cur_color % 12) + ".css");
        var icon = $(".portal > .head > .title > .text").html("<div class='icon'></div>" + mi.text)
            .click(function (event) {
                GotoMenuItem(mi, 1);
                event.stopPropagation();
                return false;
            }).children(".icon").css("backgroundImage", "url(" + mi.iconi + ")");
        $(".portal > .head > .title")[0].item = mi;
        $(".submenu > ul").html("");
        var cur = BuildMenu(mi.children, null);

        if (init && !cur) {
            GotoMenuItem(mi, 2);
            SwitchToIndexPage();
            return;
        }
        SwitchToNormalPage();
        if (init)
            GotoMenuItem(cur, 2);
        else
            GotoMenuItem(mi, 2);
    };
    $.each(menus, function (idx, mi) {
        var html = "<li class='icon' icon='" + mi.icon + "' id='" + mi.id + "'>" + mi.text;
        if (mi.cnt > 0)
            html += "<span class='cnt'>" + mi.cnt + "</span>";
        html += "</li>"
        var mEl = $(html).appendTo(".portal > .menu").css({ "backgroundImage": "url(" + mi.icon + ")", "background-color": GetColor(mi.color, 2) });
        mEl[0].item = mi;
        mEl.click(function () {
            if (!ClearFrame()) return;
            DrawLv1Menu(this.item);
        });
        if (mi.cur) DrawLv1Menu(mi, true);
    });
    $(".submenu").mousewheel(function (evt, delta) {
        var top = parseInt($(".submenu > ul").css("margin-top")) + delta * 10;
        var height = $(".submenu > ul").height();
        var cheight = $(".submenu").height() - 10;
        if (delta < 0 && height + top < cheight) return; // 往上到头
        if (delta > 0 && top > 0) return; // 往下到头
        $(".submenu > ul").css("margin-top", top);
    });
    $(".portal .split").draggable({
        iframeFix: true,
        cursor: "pointer",
        helper: function () {
            var hlp = $("<div class='resize_helper'></div>");
            hlp.css("height", $(".document .submenu").height());
            return hlp;
        },
        axis: "x",
        containment: "parent",
        stop: function (evt, ui) {
            var left = ui.helper.position().left;
            if (left < 180) left = 180;
            else if (left > 500) left = 500;
            $.cookie("__frm_left", left);
            ResizePortal();
        }
    });
}

function SwitchToIndexPage() {
    if (isIndex) return;
    isIndex = true;
}
function SwitchToNormalPage() {
    if (!isIndex) return;
    isIndex = false;
}

function Lv2TabMenuToggle() {
    $(".submenu li.tab").live("click", function () {
        if ($(":animated").length) return false;
        $(this).toggleClass("expand");
        var sub = $(this).next(".sub");
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
        }
    });
}

function ResizePortal() {
    var height = $(window).height() - 44;
    if ($("body").hasClass("index_page")) {
        height = height - 46;
    }
    var frmLeft = parseInt($.cookie("__frm_left"));
    if (isNaN(frmLeft))
        frmLeft = 180;
    var width = $(window).width() - frmLeft - 4;
    $(".portal .submenu").css("width", frmLeft);
    $(".document").css("height", height);
    $(".document .submenu").css("height", height);
    $(".document .split").css("height", height);
    $(".document .content").css({ height: height, width: width });
    $(".document .content > iframe").css({ height: height, width: width });
    return;
}

function InitColorChange() {
    $(".setting_detail > .clrpanel > div").each(function () {
        var clr = $(this).attr("color");
        $(this).css("background-color", GetColor(clr, 2));
        $(this).hover(function () {
            $("#style_color").prop("href", theme_root + "color/" + $(this).attr("color") + ".css");
            UpdateColor(parseInt($(this).attr("color")));
        }, function () {
            $("#style_color").prop("href", theme_root + "color/" + (top.cur_color % 12) + ".css");
            UpdateColor();
        }).click(function () {
            var mi = $(".portal > .head > .title")[0].item;
            mi.color = top.cur_color = parseInt($(this).attr("color"));
            $("#" + mi.id).css("background-color", GetColor(mi.color, 2))
            $.post(changecolor, { id: mi.id, color: mi.color });
            UpdateColor();
        });
    });
}

function FrameMonitor() {
    setInterval(function () {
        try {
            $(".portal > .document > .content iframe:gt(0)").each(function (idx, frm) {
                var exists = false;
                $.each(frm_stack, function (idx, el) {
                    if (frm.id == el) {
                        exists = true;
                        return false;
                    }
                });
                if (!exists) {
                    $(frm).remove();
                    MoveAction();
                }
            });
        }
        catch (e) {
            //alert(e.message);
        }
    }, 100);
}

function MainMenuToggle() {
    var isFocus = false;
    $(".portal > .head .menu > .icon").click(function () {
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
        $(".portal > .menu").animate({ opacity: 1 }, function () { isFocus = true; });
    }).blur(function () {
        $(".portal > .menu").animate({ opacity: 0 }, function () {
            $(".portal > .menu").hide();
            isFocus = false;
        });
    });
}

function AvatarMenuToggle() {
    var isAvatarFocus = false;
    $(".portal > .head .info > .avatar, .index_page .avatar_index a").click(function () {
        if ($(":animated").length) return false;
        if (isAvatarFocus) {
            $(".avatar_detail .helper").blur();
        }
        else {
            $(".avatar_detail .helper").focus();
        }
        return false;
    });
    $(".avatar_detail .helper").focus(function () {
        $(".avatar_detail")
			.css({ height: 1 })
			.show()
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
    $(".portal > .head .info > .button .setting").click(function () {
        if ($(":animated").length) return false;
        if (isSettingFocus) {
            $(".setting_detail .helper").blur();
        }
        else {
            $(".setting_detail .helper").focus();
        }
        return false;
    });
    $(".setting_detail .helper").focus(function () {
        $(".setting_detail")
			.css({ height: 1 })
			.show()
			.animate({ height: 225 }, 250, function () {
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

function BuildMenu(menus, parent, lv) {
    if (!parent) parent = ".submenu > ul";
    if (!lv) lv = 0;
    var cur = null;

    $.each(menus, function (idx, mi) {
        var html = "<li id='" + mi.id + "'>" + mi.text;
        if (mi.cnt > 0)
            html += "<span class='cnt'>" + mi.cnt + "</span>";
        html += "</li>";
        var elMI = $(html).appendTo(parent);
        if (mi.cur) cur = mi;
        if (lv > 0) elMI.css({ padding: "3px 10px 3px " + (17 + lv * 8) + "px", "backgroundPosition": (4 + lv * 8) + "px 5px" });
        if ($("body").hasClass("index_page")) {
            elMI.addClass("icon");
            html = "<div class='img'></div> <span class='txt'>" + mi.text + "</span> <span class='cnt'></span>";
            elMI.html(html);
            elMI.children(".img").css({ backgroundImage: "url(" + mi.iconm + ")", "background-color": GetColor(mi.color, 2) });
            elMI.click(function () {
                location.href = lv1url.replace(/\_id\_/ig, mi.id);
            });
        }
        else {
            elMI.click(function () {
                if (!ClearFrame()) return;
                GotoMenuItem(mi);
            });
        }

        if (!mi.children || !mi.children.length)
            return;

        elMI.addClass("tab")
        html = "<li class='sub'><ul></ul></li>";
        var subLI = $(html).appendTo(parent);
        var subUL = subLI.children("ul");
        var ccur = BuildMenu(mi.children, subUL, lv + 1);
        if (ccur) cur = ccur;
    });

    return cur;
}

function GotoMenuItem(mi, expand) {
    if (mi.isIndex) {
        if (!$("body").hasClass("index_page"))
            $("body").addClass("index_page");
    }
    else {
        $("body").removeClass("index_page");
    }
    ResizePortal();
    if (mi.url) {
        if (mi.url == "#")
            OpenWindow(building, "frmDetail");
        else if (mi.target)
            OpenWindow(mi.url, mi.target);
        else
            OpenWindow(mi.url, "frmDetail");
    } else if (mi.children.length > 0) {
        var cmi = mi.children[0];
        GotoMenuItem(cmi);
        if (expand == 1 && !$("#" + cmi.id).hasClass("expand")) {
            // 动画
            $("#" + cmi.id).trigger("click");
        }
        else if (expand == 2) {
            // 瞬间展开
            SubMenuExpandParent($("#" + cmi.id));
        }
        return;
    } else {
        OpenWindow(building, "frmDetail");
    }
    $(".submenu li.cur").removeClass("cur");
    $("#" + mi.id).addClass("cur");
}

function SubMenuExpandParent(menuLI) {
    if (menuLI.length) {
        menuLI.addClass("expand");
        var sub = menuLI.next();
        sub.css({ height: "auto" });
        sub.addClass("expand");
        SubMenuExpandParent(menuLI.parent().parent().prev());
    }
}
function InstallSubMenu(menus) {
    $(".submenu > ul").html("");
    BuildMenu(menus, null);
}
/* Portal相关操作 结束*/


/* Start相关操作 */
function StartInit() {
    $(".start li > table tr").live("mouseenter mouseleave", function () { $(this).toggleClass("hover"); });
    $(window).resize(ResizeStart).triggerHandler("resize");
    SetTitle();
}

function ResizeStart() {
    var height = $(window).height();
    var width = $(window).width();
    $(".start > .left").css("width", width - 320);
    $(".start > .right").css("width", 300);
    $(".start").css("height", height);
    return;
}

function UpdateSubMenu(menus) {
    top.InstallSubMenu(menus);
}
/* Start相关操作 结束*/

/* 其他 */
function ClearFrame() {
    if (frm_stack.length > 0) {
        if (!confirm("确认离开正在编辑的页面？"))
            return false;
        frm_stack = [];
    }
    return true;
}
function Hint($ctl, dft) {
    $ctl.focus(function () {
        if ($ctl.val() == dft) {
            $ctl.val("");
        }
        $(".search > .ad").show();
    }).blur(function () {
        if (!$ctl.val()) {
            $ctl.val(dft);
        }
        setTimeout(function () {
            $(".search > .ad").hide();
        }, 300);
    }).triggerHandler("blur");
}
function MoveAction() {
    var curFrame = $(".portal > .document > .content iframe:last")[0];
    var frmWin = curFrame.contentWindow;
    if (!frmWin.GetAction) return false;
    var actionObj = frmWin.GetAction();
    return Portal_SetAction(actionObj.html, function (btn) {
        var btnText = ($(btn).val() || $(btn).text()).trim().replace(/(<[\w\W]*>)/, "");
        return actionObj.window.ClickActionButton(btnText);
    });
}
function ClickActionButton(btnText) {
    $(".function > .button .btn").each(function () {
        var curText = ($(this).val() ? $(this).val() : $(this).text()).trim();
        if (curText == btnText) {
            $(this).trigger("click");
            return false;
        }
    });
    return false;
}
function GetAction() {
    if ($(".body > .hscroll > ul").length <= 0 && $("iframe").length && $("iframe")[0].contentWindow.GetAction) {
        return $("iframe")[0].contentWindow.GetAction();
    }
    var curTabFrm = $(".body > .hscroll > ul.cur iframe");
    if (curTabFrm.length && curTabFrm[0].contentWindow.GetAction) {
        return curTabFrm[0].contentWindow.GetAction();
    }
    return { window: window, html: $(".function > .button").html() };
}
function Portal_SetAction(html, callback) {
    $(".portal > .head > .action").html(html);
    var ico_new = $(".portal > .head > .action .btn.ico_new");
    ico_new.html("<div class='ico_new'></div>" + ico_new.text());
    $(".portal > .head > .action .btn").removeProp("onclick").removeAttr("onclick");
    $(".portal > .head > .action .btn").click(function (event) {
        if (callback) {
            callback(this);
        }
        event.stopPropagation();
        return false;
    });
    // 补充关闭按钮
    if ($(".portal > .document > .content iframe").length > 1) {
        var close_exists = false;
        $(".portal > .head > .action .btn").each(function (idx, btn) {
            var btnText = (btn.value ? btn.value : $(btn).text()).trim();
            if (btnText == "关闭") {
                close_exists = true;
                return false;
            }
        });
        if (!close_exists) {
            $("<input type='button' class='btn' value='关闭' />")
				.appendTo(".portal > .head > .action")
				.click(function () { return CloseWindow(true); });
        }
    }
    return false;
}

function GetColor(hIdx, lvl) {
    if (!hIdx) hIdx = 0;
    return COLOR_TEMPLATES[hIdx % 12][lvl]
}
function UpdateColor(cidx) {
    if (typeof (cidx) == "undefined") {
        if (!top.cur_color) top.cur_color = 0;
        cidx = top.cur_color;
    }
    $("#style_color").prop("href", theme_root + "color/" + (cidx % 12) + ".css");
    $("iframe").each(function () {
        try {
            this.contentWindow.UpdateColor(cidx);
        } catch (e) { }
    });
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

function ResizeIFrame(obj){
	$(obj).height(obj.contentWindow.document.documentElement.scrollHeight);
}
/* 其他 结束 */