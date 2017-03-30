
//页面加载完成,ajax回发加载完成后执行的操作，传入一个funtion
//$load调用示例
//$load(function () {
//    //需要页面加载完成执行的代码
//});
var $load = function (loadFunc) {
    $(function () {
        if (typeof (Sys) != 'undefined') {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(loadFunc);
        }
        else {
            loadFunc();
        }
    });
};

// Microsoft.ajax 异步回发加载后触发函数
var $ajaxload = function (loadFunc) {
    if (typeof (Sys) != 'undefined') {
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(loadFunc);
    }
};

//页面所在iframe
var $mainWindow = window.top.document.getElementById("iframe-main") == undefined ? window.self : window.top.document.getElementById("iframe-main").contentWindow;

//获取绝对路径
var $getUrl = function (url) {
    if (url.indexOf("http") > -1) {
        return url;
    }

    var div = document.createElement('div');
    div.innerHTML = '<a href="./"></a>';
    var path = div.firstChild.href;
    div = null;

    //var path = location.href;
    //path = path.substring(0, path.lastIndexOf('/'));

    return path + url;
};

$(function () {
    var notyId;
    if (typeof (Sys) != 'undefined') {
        //Microsoft.ajax数据提交时显示loading
        Sys.Net.WebRequestManager.add_invokingRequest(function (sender, args) {
            var $noty = showLoading();
            notyId = $noty.options.id;

            //TODO 增加禁止按钮重复按多次处理
        });

        //回发完成后隐藏
        Sys.Net.WebRequestManager.add_completedRequest(function (sender, args) {
            $.noty.close(notyId);

            //TODO 增加禁止按钮重复按多次处理
        });

        //捕获错误
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (sender, args) {
            var error = args.get_error();
            if (error != undefined) {
                args.set_errorHandled(true);

                warning("<strong>对不起，系统出错了,请联系管理员！</strong><br/>错误信息：" + error.message);

                //TODO 增加禁止按钮重复按多次处理
            }
        });
    }

    bindWindowResize(function () {
        autoHeightDynamic('#main', 46);
    });
});

function initCustomEntityValidation() {
    $("input[validatetype^='['],select[validatetype^='[']").each(function () {
        var obj = $(this);
        var validTypes = JSON.parse($(this).attr("validatetype"));
        if (validTypes.length > 0) {
            var validArr = [];
            $.each(validTypes, function (index) {
                switch (validTypes[index]) {
                    case 'Required':
                        validArr.push('required');
                        obj.parent().prev().addClass('required');
                        break;
                    case 'Integer':
                        validArr.push('custom[number]');
                        var decimalplaces = obj.attr('decimalplaces');
                        if (decimalplaces) {
                            var objVal = obj.val();
                            if (decimalplaces > 0 && objVal != '') {
                                if (parseFloat(objVal) == 0)
                                    obj.val(0);
                                else
                                    obj.val(parseFloat(objVal).toFixed(parseInt(decimalplaces)));
                            }
                        }
                        break;
                    case 'Date':
                        validArr.push('custom[date]');
                        obj.addClass('datepicker');
                        break;
                    default:
                }
            });
            obj.addClass('validate[' + validArr.join(',') + ']');
        }
    });
}

$load(function () {
    //删除及需要提示的数据前提示
    bindConfirm(".confirm");

    //自定义绑定
    initCustomEntityValidation();

    //日期插件绑定
    if ($.datepicker)
        $(".datepicker").datepicker({
            dateFormat: "yy-mm-dd",
            changeMonth: true,
            changeYear: true
        });

    if ($.timepicker) {
        //日期时间插件绑定
        $(".datetimepicker").datetimepicker();
        //时间插件绑定
        $(".timepicker").timepicker();
    }
});

function bindConfirm(hook, okFunc) {
    /// <summary> 绑定弹出确认提示框 </summary>
    /// <param name="hook">钩子</param>
    /// <param name="okFunc">确认后触发函数</param>

    //删除及需要提示的数据前提示
    $(hook).unbind("click").click(function (event) {
        var delBt = $(this);

        //弹出提醒的对象是提交表单的，则先进行表单校验
        var formId = '#' + delBt.closest('form').attr('id');
        if (delBt.hasClass('submit') && !$(formId).validationEngine('validate'))
            return false;

        var confirmText = "您确定要继续该操作吗？";
        if (delBt.attr("ConfirmText"))
            confirmText = delBt.attr("ConfirmText");


        return notyConfirm(function () {

            if (okFunc) {
                if (okFunc()) {
                    window.location.href = delBt.attr("href");
                }
            }
            else {
                window.location.href = delBt.attr("href");
            }
        }, confirmText);
    });
}

function showLoading() {
    /// <summary>
    /// 弹出加载信息提示框
    /// </summary>

    var $noty = noty({
        type: 'ajaxloading',
        layout: 'center',
        template: '<div class="ajaxloading" title="正在处理..."></div>',
        timeout: false,
        modal: false,
        animation: {
            open: { height: 'toggle' },
            close: { height: 'toggle' },
            easing: 'swing',
            speed: 0 // opening & closing animation speed
        }
    });
    return $noty;
}

/********信息提示**********/
function success(msg, afterCloseFunc, timeout) {
    /// <summary>
    /// 弹出成功信息提示框
    /// </summary>

    var defaultTimeout = 500;
    if (timeout == false || timeout)
        defaultTimeout = timeout;
    noty({
        text: msg,
        layout: 'center',
        type: 'success',
        timeout: defaultTimeout,
        callback: {
            onShow: function () { },
            afterShow: function () { },
            onClose: function () { },
            afterClose: function () {
                if (afterCloseFunc)
                    afterCloseFunc();
            }
        }
    });
}


function warning(msg, afterCloseFunc, timeout) {
    /// <summary>
    /// 弹出警告信息提示框
    /// </summary>

    var defaultTimeout = '2000';
    if (timeout == false || timeout)
        defaultTimeout = timeout;
    noty({
        text: msg,
        layout: 'center',
        type: 'warning',
        timeout: defaultTimeout,
        callback: {
            onShow: function () { },
            afterShow: function () { },
            onClose: function () { },
            afterClose: function () {
                if (afterCloseFunc)
                    afterCloseFunc();
            }
        }
    });

    if (console)
        console.log('警告:' + msg);
}

function info(msg, timeout) {
    /// <summary>
    /// 弹出信息提示框
    /// </summary>

    var defaultTimeout = 1500;
    if (timeout == false || timeout)
        defaultTimeout = timeout;

    noty({
        text: msg,
        layout: 'center',
        type: 'info',
        timeout: defaultTimeout
    });
}

function danger(msg, timeout) {
    /// <summary>
    /// 弹出危险信息提示框
    /// </summary>

    var defaultTimeout = 2500;
    if (timeout == false || timeout)
        defaultTimeout = timeout;

    noty({
        text: msg,
        layout: 'center',
        type: 'danger',
        timeout: defaultTimeout
    });
}

function notyConfirm(okFunc, msg, noFunc) {
    /// <summary> 弹出确认提示框 </summary>
    /// <param name="okFunc">确认后触发函数</param>
    /// <param name="msg">提示消息内容</param>
    /// <param name="noFunc">取消后触发函数</param>

    var confirmText = "您确定要继续该操作吗？";
    if (msg)
        confirmText = msg;

    noty({
        text: confirmText,
        type: 'confirm',
        layout: 'center',
        timeout: false,
        modal: true,
        closeWith: [],
        buttons: [
            {
                addClass: 'btn', text: '<i class="btn-ok">确 定</>', onClick: function ($noty) {
                    $noty.close();

                    if (okFunc)
                        okFunc();
                }
            },
            {
                addClass: 'btn btn-primary', text: '<i class="btn-cancel">取 消</>', onClick: function ($noty) {
                    $noty.close();

                    if (noFunc)
                        noFunc();
                }
            }
        ]
    });

    return false;
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

    if ($(elemId).length > 0) {

        var height = eleHeight - offset;
        if (height >= 0)
            $(elemId).css('height', height);
    }
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

/********列表表格复选框全选**********/
function checkAll(cbAll, cbxContainerCalss) {
    if (arguments[1] == undefined)
        cbxContainerCalss = '.cbx';
    $(cbxContainerCalss + ' input[type="checkbox"]').prop('checked', $(cbAll).prop('checked'));
}

function getChecked() {
    /// <summary>
    /// 获取当前页面勾选的checkbox
    /// </summary>

    var checkedIds = '';
    $('.cbx input[type="checkbox"]:checked').each(function () {
        checkedIds += $(this).attr('title') + ',';
    });
    return checkedIds;
}

function initValidation(formid) {
    /// <summary>
    /// 初始化校验
    /// </summary>
    /// <param name="formid">要校验的表单的Id</param>

    $load(function () {
        if (typeof (formid) != "undefined") {
            $(formid).validationEngine({
                validationEventTrigger: "submit", //"blur",
                promptPosition: "bottomLeft"
            });
        }
    });

    //对于LinkButton按钮提交，进行校验
    $(".submit").click(function () {
        return $(formid).validationEngine('validate');
    });

    if (typeof (Sys) != 'undefined') {
        Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(function (sender, args) {

            //提交元素包含 validate-skip 则不做校验
            var submitElement = $(args.get_postBackElement());
            if (submitElement.hasClass('validate-skip') || submitElement.attr("data-validation-engine-skip") == "true")
                return;

            var result = $(formid).validationEngine('validate');
            var pm = Sys.WebForms.PageRequestManager.getInstance();
            //校验通过
            if (result) {
                //若还未开始异步回发
                if (!pm.get_isInAsyncPostBack())
                    args.set_cancel(false);
            } else {
                //若校验不通过，则取消asp.net Ajax提交
                if (pm.get_isInAsyncPostBack())
                    pm.abortPostBack();
                else
                    args.set_cancel(true);
            }
        });
    }
}

function validate(formid) {
    /// <summary>
    /// 校验表单并返回结果
    /// </summary>
    return $(formid).validationEngine('validate');
}

function initFancybox(isAbsoluteUrl) {
    /// <summary> 初始化fancybox </summary>
    /// <param name="isAbsoluteUrl">是否为绝对url，即不需要对url做特殊处理</param>

    if (window.top.$.fancybox == undefined)
        return false;

    $('body').on('click', '.fancybox', function (event) {
        event.preventDefault();

        var link = $(this);

        var width = link.data('fancy-width');
        var height = link.data('fancy-height');
        var title = link.attr('title');
        var url = link.attr("href");
        var absoluteUrl = link.attr("absoluteUrl");
        if (!isAbsoluteUrl) {

            url = $getUrl(url);
        }

        if (!absoluteUrl) {
            url = $getUrl(url);
        }

        window.top.$.fancybox({
            'type': 'iframe',
            'href': url,
            'autoSize': (width == undefined) && (height == undefined),
            'width': width,
            'height': height,
            'title': title
        });
    });


}

function openInFancybox(obj, isAbsoluteUrl) {
    /// <summary> 在fancybox中打开链接页面 </summary>
    /// <param name="obj">触发的链接</param>

    var link = $(obj);

    var width = link.data('fancy-width');
    var height = link.data('fancy-height');
    var title = link.attr('title');
    var url = link.attr("href");
    if (!isAbsoluteUrl)
        url = $getUrl(url);

    window.top.$.fancybox({
        'type': 'iframe',
        'href': url,
        'autoSize': (width == undefined) && (height == undefined),
        'width': width,
        'height': height
    });

    return false;
}

function closeFancybox() {
    /// <summary>
    /// 关闭fancybox
    /// </summary>

    window.top.$.fancybox.close();
}

function go(url) {
    /// <summary>
    /// 当前页面跳转至指定的url
    /// </summary>

    window.self.location.href = url;
}

function reloadData() {
    ///<summary>查询重新加载数据</summary>

    if (typeof (btnSearch) != "undefined" && $(btnSearch).length > 0)
        $(btnSearch).get(0).click();
}

function refreshData() {
    ///<summary>刷新页面</summary>

    window.self.location.reload();
}

function setReadOnly() {
    ///<summary>设置只读属性</summary>

    $('.readonly').attr('readonly', true);
}

function saved(toLocation, isCloseFancybox) {
    /// <summary> 普通修改页面（非弹出层）保存后调用方法 </summary>
    /// <param name="toLocation">保存后跳转新页面</param>
    /// <param name="isCloseFancybox">保存后是否关闭fancybox</param>

    success("保存成功。", function () {
        $mainWindow.location = toLocation;

        if (isCloseFancybox)
            closeFancybox();
    });
}

function savedWidthMsg(msg, toLocation) {
    /// <summary> 保存后调用方法 </summary>
    /// <param name="msg">保存后提示信息</param>
    /// <param name="toLocation">保存后跳转新页面</param>

    success(msg, function () {
        $mainWindow.location = toLocation;
    });
}

function savedInFancy(isReload, isCloseFancybox) {
    /// <summary> 弹出层修改页面保存后调用方法 </summary>
    /// <param name="toLocation">保存后是否重新加载</param>
    /// <param name="isCloseFancybox">保存后是否关闭fancybox</param>

    success("保存成功。", function () {

        if (isReload)
            $mainWindow.reloadData();

        if (isCloseFancybox)
            closeFancybox();
    });
}

function savedThenRefreshMain(isRefresh, isCloseFancybox) {
    /// <summary> 弹出层修改页面保存后调用方法 </summary>
    /// <param name="isRefresh">保存后是否重新刷新主页面</param>
    /// <param name="isCloseFancybox">保存后是否关闭fancybox</param>

    success("保存成功。", function () {
        if (isRefresh)
            $mainWindow.refreshData();

        if (isCloseFancybox)
            closeFancybox();
    });
}

function savedThenAdd(toLocation, isCloseFancybox, isRefresh) {
    /// <summary> 弹出层修改页面保存并新增后调用方法 </summary>
    /// <param name="toLocation">保存后弹出层跳转新页面</param>
    /// <param name="isCloseFancybox">保存后是否关闭fancybox</param>
    /// <param name="isRefresh">保存后是否重新刷新主页面</param>

    success("保存成功。", function () {
        window.location = toLocation;

        if (isCloseFancybox)
            closeFancybox();

        if (isRefresh)
            $mainWindow.refreshData();

    });
}

function openNew(url) {
    ///<summary>在新窗口打开指定的url</summary>

    $('<a target="_blank" />').attr('href', url).get(0).click();
}

function sessionOut() {
    ///<summary>登录超时</summary>
    warning('登录超期，将跳转至登录页面！', function () {
        setTimeout('window.location.href="login.aspx"', 3000);
    });
    return;
}

function closethis() {
    ///<summary>关闭fancybox页面，或者关闭当前页面</summary>
    if (window.top.$.fancybox)
        $mainWindow.closeFancybox();
    else {
        window.opener = null;
        window.close();
    }
}

function initToggle() {
    ///<summary>初始化</summary>

    $('.toggle').click(function () {
        var contentId = $(this).attr('href');

        if ($(this).hasClass('folder')) {

            if (contentId) {
                $(contentId).hide();
            } else {
                //隐藏内容
                $(".toggle-content").hide();
            }

            $(this).removeClass('folder').addClass('unfolder').html('展开<span></span>');
        }
        else {

            if (contentId) {
                $(contentId).show();
            } else {
                //显示内容
                $(".toggle-content").show();
            }

            $(this).removeClass('unfolder').addClass('folder').html('收起<span></span>');
        }
    });
}