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

var ajaxUrl = '../../Handler/MenuTree.ashx';

function initMenuTree(cookieId) {
    /// <summary>
    /// 初始化树
    /// </summary>

    $('#menuTree').dynatree({
        autoFocus: false, // Set focus to first child, when expanding or lazy-loading.
        persist: true,
        'cookieId': cookieId, // Choose a more unique name, to allow multiple trees.
        initAjax: {
            url: ajaxUrl,
            data: {
                'type': 'getRootMenu',
                'treeItemId': treeRootId
            },
            addExpandedKeyList: true // add &expandedKeyList= parameter to URL
        },
        onLazyRead: function (node) {
            node.appendAjax({
                url: ajaxUrl,
                data: {
                    'type': 'getChildrenMenu',
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

function initMenuTreeCheckBox(cookieId, onselect) {
    /// <summary>
    /// 初始化菜单树,带复选框
    /// </summary>

    $('#menuTree').dynatree({
        autoFocus: false, // Set focus to first child, when expanding or lazy-loading.
        persist: true,
        'cookieId': cookieId, // Choose a more unique name, to allow multiple trees.
        initAjax: {
            url: ajaxUrl,
            data: {
                'type': 'getVisibleRootMenu',
                'treeItemId': treeRootId,
                'roleId': $(hdSelectedRoleId).val() //当前选择的角色Id
            },
            addExpandedKeyList: true // add &expandedKeyList= parameter to URL
        },
        onLazyRead: function (node) {
            node.appendAjax({
                url: ajaxUrl,
                data: {
                    'type': 'getVisibleChildrenMenu',
                    'treeItemId': node.data.key,
                    'roleId': $(hdSelectedRoleId).val() //当前选择的角色Id
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

function initDropdownMenuTree(cookieId, onclick) {
    /// <summary>
    /// 初始化下拉列表选择树
    /// </summary>
    /// <param name="cookieId">保存树的cookieId</param>
    /// <param name="onclick">点击树结点时回调函数</param>


    $('#menuTree').dynatree({
        autoFocus: false, // Set focus to first child, when expanding or lazy-loading.
        persist: true,
        'cookieId': cookieId, // Choose a more unique name, to allow multiple trees.
        initAjax: {
            url: ajaxUrl,
            data: {
                'type': 'getRootMenu',
                'treeItemId': treeRootId
            },
            //addActiveKey: true,  // add &activeKey= parameter to URL
            //addFocusedKey: true, // add &focusedKey= parameter to URL
            addExpandedKeyList: true // add &expandedKeyList= parameter to URL
        },
        onLazyRead: function (node) {
            node.appendAjax({
                url: ajaxUrl,
                data: {
                    'type': 'getChildrenMenu',
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
        // Called when a node was clicked.
        // Use node.getEventTargetType(event) to check which area was clicked.
        // Return false to prevent default processing (setting focus, activate the node, expand folders, etc.).
        onClick: function (node, event) {
            if (node.getEventTargetType(event) != "title")
                return;

            if (hdSelectedTreeItemId)
                $(hdSelectedTreeItemId).val(node.data.key);

            if (SelectedTreeItemName) {
                var tagName = $(SelectedTreeItemName).prop('tagName');
                if (tagName == 'INPUT')
                    $(SelectedTreeItemName).val(node.data.title);
                else if (tagName == 'SPAN')
                    $(SelectedTreeItemName).text(node.data.title);
            }

            //回调函数
            if (onclick)
                onclick();

            //隐藏下拉浮动div
            $('#dropdownMenu').hide();
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

    var node = $('#menuTree').dynatree("getActiveNode");
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
