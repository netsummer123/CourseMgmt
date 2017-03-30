//添加按钮
function showAdd() {
    var parentId = $(hdSelectedTreeItemId).val();
    //默认取根部门
    if (parentId == '')
        parentId = treeRootId;

    window.top.$.fancybox({
        'type': 'iframe',
        'href': $getUrl('MenuEdit.aspx?SelectedMenuID=' + parentId)
    });
}

var ajaxUrl = '../../Handler/DeptTypeTree.ashx';

function initDeptTree(cookieId) {
    /// <summary>
    /// 初始化树
    /// </summary>
    $('#deptTree').dynatree({
        autoFocus: false, // Set focus to first child, when expanding or lazy-loading.
        persist: true,
        'cookieId': cookieId, // Choose a more unique name, to allow multiple trees.
        initAjax: {
            url: ajaxUrl,
            data: {
                'type': 'getRoot',
                'treeItemId': treeRootId
            },
            addExpandedKeyList: true // add &expandedKeyList= parameter to URL
        },
        onLazyRead: function (node) {
            node.appendAjax({
                url: ajaxUrl,
                data: {
                    'type': 'getRoot',
                    'treeItemId': node.data.key
                },
                success: function (node) {
                    if (node == 'sessionOut') {
                        warning('登录超期，将跳转至登录页面！', function () {
                            setTimeout('window.location.href="login.aspx"', 3000);
                        });
                    }
                }
            });
        },
        onPostInit: function (isReloading, isError) {
            // In lazy mode, this will be called *after* the initAjax request returned.
            // 'this' is the current tree
            // isReloading is set, if status was read from existing cookies
            // isError is set, if Ajax failed
            // Fire an onActivate() event for the currently active node
            this.reactivate();
        },
        // Callback(dtnode) when a node is activated.
        onActivate: function (node) {
            $(hdSelectedTreeItemId).val(node.data.key);
            $(btnQueryByTreeItemId).get(0).click();
        },

        checkbox: false, // Show checkboxes.
        clickFolderMode: 1, // 1:activate, 2:expand, 3:activate and expand
        selectMode: 1, // 1:single, 2:multi, 3:multi-hier
        debugLevel: 0
    });
}

function reloadActiveNode() {
    /// <summary>
    /// 重新加载部门活动结点
    /// </summary>

    var node = $('#deptTree').dynatree("getActiveNode");
    if (node) {
        if (node.isLazy()) {
            node.reloadChildren(function (node, isOk) {
            });
        } else {
            node.tree.reload();
        }
    }
    //刷新列表
    $(btnQueryByTreeItemId).get(0).click();
};
