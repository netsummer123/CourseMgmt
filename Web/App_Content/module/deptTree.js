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

var ajaxUrl = '../../Handler/DeptTree.ashx';

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
                'treeItemId': treeRootId,
                'year': year
            },
            addExpandedKeyList: true // add &expandedKeyList= parameter to URL
        },
        onLazyRead: function (node) {
            node.appendAjax({
                url: ajaxUrl,
                data: {
                    'type': 'getChildren',
                    'deptType': node.data.key,
                    'year': year
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
            if (node.data.nodeType == 'DeptType') {
                $(hdDeptType).val(node.data.key);
                $(hdSelectedTreeItemId).val('');
            } else {
                $(hdSelectedTreeItemId).val(node.data.key);
                $(hdDeptType).val('');
            }
            $(btnQueryByTreeItemId).get(0).click();
        },

        checkbox: false, // Show checkboxes.
        clickFolderMode: 1, // 1:activate, 2:expand, 3:activate and expand
        selectMode: 1, // 1:single, 2:multi, 3:multi-hier
        debugLevel: 0
    });
}

function initDeptTreeCheckBox(cookieId, onselect) {
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
                'treeItemId': treeRootId,
                'year': year,
                'teacherId': teacherId,
                'courseId': courseId
            },
            addExpandedKeyList: true // add &expandedKeyList= parameter to URL
        },
        onLazyRead: function (node) {
            node.appendAjax({
                url: ajaxUrl,
                data: {
                    'type': 'getChildren',
                    'deptType': node.data.key,
                    'year': year,
                    'teacherId': teacherId,
                    'courseId': courseId
                },
                success: function (node) {

                    if (node == 'sessionOut') {
                        warning('登录超期，将跳转至登录页面！', function () {
                            setTimeout('window.location.href="login.aspx"', 3000);
                        });
                    }

                    var selectedNodes = node.tree.getSelectedNodes();
                    var selectedKeys = $.map(selectedNodes, function (node) {
                        return node.data.key;
                    });

                    //存储
                    $(hdSelectedTreeItemId).val(selectedKeys.join(','));
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
        //勾选
        onSelect: function (flag, node) {
            if (onselect)
                onselect(flag, node);
        },

        checkbox: true, // Show checkboxes.
        clickFolderMode: 3, // 1:activate, 2:expand, 3:activate and expand
        selectMode: 2, // 1:single, 2:multi, 3:multi-hier
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
