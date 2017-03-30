function ComponentArt_TabStrip(tabStripId,storageArray,qqRc,scrollLookStorageArray){this.TabStripId=tabStripId;this.ItemLooks=new ComponentArt_ItemLookCollection(qqRc);if(storageArray==null){this.StorageArray=new Array();}else{this.StorageArray=storageArray;};this.qqGa=this.StorageArray;this.ActiveGroupList=new Array();this.ExpandedGroupIndex=null;this.ExpandedSubGroupCount=0;this.RecycleGroups=true;this.ZIndexIncrement=0;this.ScrollDownLook=qqGp('ComponentArt_ItemLook',scrollLookStorageArray[0]);var scrollDownOriginalLook=this.ItemLooks[this.ScrollDownLook.LookId];if(scrollDownOriginalLook){scrollDownOriginalLook.ApplyTo(this.ScrollDownLook);};this.ScrollLeftLook=qqGp('ComponentArt_ItemLook',scrollLookStorageArray[1]);var scrollLeftOriginalLook=this.ItemLooks[this.ScrollLeftLook.LookId];if(scrollLeftOriginalLook){scrollLeftOriginalLook.ApplyTo(this.ScrollLeftLook);};this.ScrollRightLook=qqGp('ComponentArt_ItemLook',scrollLookStorageArray[2]);var scrollRightOriginalLook=this.ItemLooks[this.ScrollRightLook.LookId];if(scrollRightOriginalLook){scrollRightOriginalLook.ApplyTo(this.ScrollRightLook);};this.ScrollUpLook=qqGp('ComponentArt_ItemLook',scrollLookStorageArray[3]);var scrollUpOriginalLook=this.ItemLooks[this.ScrollUpLook.LookId];if(scrollUpOriginalLook){scrollUpOriginalLook.ApplyTo(this.ScrollUpLook);};this.ScrollContainer=new ComponentArt_TabStrip_ElementContainer();};ComponentArt_TabStrip.prototype.GetTabFromStorage=function(qzgc){if(qzgc<0){return this.GetRootTab();};var tab=qqGp(this.NodeTypeName,this.StorageArray[qzgc],this,qzgc);tab.ApplyLooks();tab.EffectiveLook().CopyTo(tab);return tab;};ComponentArt_TabStrip.prototype.GetRootTab=function(){var qzke=new ComponentArt_TabStripTab();qzke.ParentTabStrip=this;qzke.StorageIndex=-1;var indexOfParentIndex=FindPropertyIndexInStorageArray(qzke.qqGr,'ParentIndex'),qzzf=new Array();for(var qzba=0;qzba<this.StorageArray.length;qzba++){var tabStorage=this.StorageArray[qzba];for(var qzAde=0;qzAde<tabStorage.length;qzAde+=2){if(tabStorage[qzAde]==indexOfParentIndex){if(tabStorage[qzAde+1]<0){qzzf[qzzf.length]=qzba;};break;};};};qzke.ChildIndexes=qzzf;qzke.SubGroupCssClass=this.TopGroupCssClass;qzke.SubGroupExpandDirection=0;qzke.SubGroupExpandOffsetX=0;qzke.SubGroupExpandOffsetY=0;qzke.SubGroupTabSpacing=this.TopGroupTabSpacing;qzke.SubGroupOrientation=this.Orientation;qzke.SubGroupHeight=this.TopGroupHeight;qzke.SubGroupWidth=this.TopGroupWidth;qzke.SubGroupFullExpand=this.TopGroupFullExpand;qzke.SubGroupAlign=this.TopGroupAlign;qzke.SubGroupSeparators=qqGp('ComponentArt_TabSeparators',this.TopGroupSeparatorStorage);return qzke;};ComponentArt_TabStrip.prototype.Tabs=function(param){return this.GetRootTab().Tabs(param);};ComponentArt_TabStrip.prototype.FindTabByProperty=function(qqGz,qqGy){var indexOfProperty=FindPropertyIndexInStorageArray(this.NodeType.qqGr,qqGz);for(var qzba=0;qzba<this.StorageArray.length;qzba++){var indexOfValue=FindPropertyValueInStorageArray(this.StorageArray[qzba],indexOfProperty);if(indexOfValue){if(this.StorageArray[qzba][indexOfValue]==qqGy){return this.GetTabFromStorage(qzba);};};};return null;};ComponentArt_TabStrip.prototype.FindTabById=function(tabId){return this.FindTabByProperty('ID',tabId);};ComponentArt_TabStrip.prototype.FindTabByPostBackId=function(tabPostBackId){return this.FindTabByProperty('PostBackID',tabPostBackId);};ComponentArt_TabStrip.prototype.SelectTabById=function(tabId){var tab=this.FindTabById(tabId);if(tab!=null){tab.Select();};};ComponentArt_TabStrip.prototype.SelectTabByPostBackId=function(tabPostBackId){var tab=this.FindTabByPostBackId(tabPostBackId);if(tab!=null){tab.Select();};};ComponentArt_TabStrip.prototype.GetSelectedTab=function(){return this.FindTabByPostBackId(this.SelectedTabPostBackID);};ComponentArt_TabStrip.prototype.SetSelectedTab=function(tab){var selectedNodeInput=document.getElementById(this.SelectedNodeInput);if(selectedNodeInput!=null){selectedNodeInput.value=tab==null?null:tab.PostBackID;};if(tab==null){this.SelectedTabPostBackID=null;this.ChildSelectedTabPostBackIDs=[];}else{this.SelectedTabPostBackID=tab.PostBackID;this.ChildSelectedTabPostBackIDs=[];var currentTab=tab.ParentTab();while(currentTab!=null){this.ChildSelectedTabPostBackIDs[this.ChildSelectedTabPostBackIDs.length]=currentTab.PostBackID;currentTab=currentTab.ParentTab();};};};ComponentArt_TabStrip.prototype.Render=function(){var tabStripIsVertical=(this.Orientation==cart_tabstrip_tabstriporientation_verticallefttoright||this.Orientation==cart_tabstrip_tabstriporientation_verticalrighttoleft),qzAdz=document.getElementById(this.PlaceHolderId);this.ScrollContainer.Clear();if(tabStripIsVertical){this.offsetHeight=!this.ScrollingEnabled?null:(this.Height?qzAdz.offsetHeight:null);qzAdz.innerHTML=ComponentArt_TabStrip_VerticalTabStripHtml(this);if(this.ScrollingEnabled){ComponentArt_TabStrip_ConsiderVerticalScrolls(this);};}else{this.offsetWidth=!this.ScrollingEnabled?null:(this.Width?qzAdz.offsetWidth:null);qzAdz.innerHTML=ComponentArt_TabStrip_HorizontalTabStripHtml(this);if(this.ScrollingEnabled){ComponentArt_TabStrip_ConsiderHorizontalScrolls(this);};};};function ComponentArt_TabStripTab(){};ComponentArt_TabStripTab.prototype.TransitoryProperties=ComponentArt_TabStripTab.TransitoryProperties=['ParentTabStrip','StorageIndex'];ComponentArt_TabStripTab.prototype.qqGr=ComponentArt_TabStripTab.qqGr=['PostBackID',,'ParentIndex',,'ChildIndexes',,'Enabled',,'TextAlign',,'TextWrap',,'AutoPostBackOnSelect',,'ID',,'NavigateUrl',,'Target',,'ClientSideCommand',,'Text',,'Width',,'Height',,'KeyboardShortcut',,'ToolTip',,'Value',,'PageViewId',,'TemplateInstanceId',,'SubGroupExpandDirection',,'SubGroupExpandOffsetX',,'SubGroupExpandOffsetY',,'SubGroupCssClass',,'SubGroupTabSpacing',,'SubGroupWidth',,'SubGroupHeight',,'SubGroupFullExpand',,'SubGroupAlign',,'SubGroupSeparators','ComponentArt_TabSeparators','Look','ComponentArt_ItemLook','SelectedLook','ComponentArt_ItemLook','ChildSelectedLook','ComponentArt_ItemLook','DisabledLook','ComponentArt_ItemLook'];ComponentArt_TabStrip.prototype.qqGo=ComponentArt_TabStrip.qqGo=ComponentArt_TabStripTab.qqGr.concat(ComponentArt_TabStripTab.TransitoryProperties);ComponentArt_TabStrip.prototype.NodeTypeName=ComponentArt_TabStrip.NodeTypeName='ComponentArt_TabStripTab';ComponentArt_TabStrip.prototype.NodeType=ComponentArt_TabStrip.NodeType=ComponentArt_TabStripTab;ComponentArt_TabStripTab.prototype.Tabs=function(param){if(param==null){var items=new Array(),length=this.ChildIndexes.length;for(var qzba=0;qzba<length;qzba++){items[qzba]=this.ParentTabStrip.GetTabFromStorage(this.ChildIndexes[qzba]);};return items;}else{if(typeof(param)=='number'){return this.ParentTabStrip.GetTabFromStorage(this.ChildIndexes[param]);}else{var length=this.ChildIndexes.length;for(var qzba=0;qzba<length;qzba++){var qzz=this.ParentTabStrip.GetTabFromStorage(this.ChildIndexes[qzba]);if(qzz.ID==param){return qzz;};};return null;};};};ComponentArt_TabStripTab.prototype.ParentTab=function(){return(this.ParentIndex>=0)?this.ParentTabStrip.GetTabFromStorage(this.ParentIndex):null;};ComponentArt_TabStripTab.prototype.ApplyLooks=function(){var lookPropertyNames=['Look','SelectedLook','ChildSelectedLook','DisabledLook'];for(var qzba=0;qzba<lookPropertyNames.length;qzba++){var itemLook=this[lookPropertyNames[qzba]];if(itemLook){var sourceLook=this.ParentTabStrip.ItemLooks[itemLook.LookId];if(sourceLook){sourceLook.ApplyTo(itemLook);};};};};ComponentArt_TabStripTab.prototype.EffectiveLook=function(){if(this.IsSelected()&&!this.SelectedLook.IsEmpty()){return this.SelectedLook;}else if(!this.Enabled&&!this.DisabledLook.IsEmpty()){return this.DisabledLook;}else if(this.IsChildSelected()&&!this.ChildSelectedLook.IsEmpty()){return this.ChildSelectedLook;}else{return this.Look;};};ComponentArt_TabStripTab.prototype.IsSelected=function(){return this.PostBackID==this.ParentTabStrip.SelectedTabPostBackID;};ComponentArt_TabStripTab.prototype.IsChildSelected=function(){var childSelectedTabs=this.ParentTabStrip.ChildSelectedTabPostBackIDs;for(var qzba=0;qzba<childSelectedTabs.length;qzba++){if(this.PostBackID==childSelectedTabs[qzba]){return true;};};return false;};ComponentArt_TabStripTab.prototype.SaveState=function(){var qqWr=[];for(var qzba=0;2*qzba<this.qqGr.length;qzba++){var qqGj=this.qqGr[2*qzba+1];if(qqGj==null){var qqGz=this.qqGr[2*qzba],qqGy=this[qqGz];if(qqGy!=null){qqWr[qqWr.length]=qzba;qqWr[qqWr.length]=qqGy;};}else if(qqGj=='ComponentArt_ItemLook'){var qqRb=[],lookName=this.qqGr[2*qzba],lookValue=this[lookName];if(!lookValue.IsEmpty()){for(var qzAde=0;2*qzAde<lookValue.qqGr.length;qzAde++){var lookPropertyType=lookValue.qqGr[2*qzAde+1];if(lookPropertyType==null){var lookPropertyName=lookValue.qqGr[2*qzAde],lookPropertyValue=lookValue[lookPropertyName];if(lookPropertyValue!=null){qqRb[qqRb.length]=qzAde;qqRb[qqRb.length]=lookPropertyValue;};};};};qqWr[qqWr.length]=qzba;qqWr[qqWr.length]=qqRb;};};this.ParentTabStrip.StorageArray[this.StorageIndex]=qqWr;};ComponentArt_TabStripTab.prototype.Select=function(){this.ParentTabStrip.SetSelectedTab(this);var commandJS=qqDb(this,this.ParentTabStrip);if(!ComponentArt_CommandNavigatesAway(commandJS)){this.ParentTabStrip.Render();};eval(commandJS);};function ComponentArt_TabSeparators(){};ComponentArt_TabSeparators.prototype.qqGr=ComponentArt_TabSeparators.qqGr=['ShowSeparators',,'SeparatorHeight',,'SeparatorWidth',,'FirstSeparatorHeight',,'FirstSeparatorWidth',,'LastSeparatorHeight',,'LastSeparatorWidth',,'SeparatorImagesFolderUrl',];ComponentArt_TabSeparators.prototype.TransitoryProperties=ComponentArt_TabSeparators.TransitoryProperties=[];var cart_tabstrip_kernel_loaded=true;
