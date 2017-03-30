
window.attachEvent("onload",function()
{
	window.ComponentArt_HandleCheck=function(qzAiy, postbackId, storageIndex)
	{
		var qzm = qze.qzo(storageIndex);
		var treeDiv=eval(qzm.ParentTreeView.ControlId.replace(/\$/g,"_")+"_div");
		qzm.Checked = qzAiy.checked;
		qzm.SaveState();
		if(qze.ClientSideOnNodeCheckChanged)
		{
			qzm.ResolveAncestors();
			qze.ClientSideOnNodeCheckChanged(qzm);
		}
		;
		if(qzm.AutoPostBackOnCheckChanged)
		{
			__doPostBack(qze.ControlId, 'CHECK ' + qzm.PostBackID + ' ' + qzm.Checked);
			return;
		}
		
		if(qzAiy.checked==true)
		{
			CheckParentNode(treeDiv,qzm,qzAiy.checked)
		}
		qzm.ExpandAll();
		qzm.Expand();
		CheckChildNode(treeDiv,qzm,qzAiy.checked);
	}
})
	
function CheckParentNode(treeDiv,node,value)
{
	if(node!=null)
	{
		var pNode=node.GetParentNode()
		if(pNode!=null)
		{
			try
			{
				treeDiv.all("checker_p"+pNode.StorageIndex.toString(16).toUpperCase()).checked=value;
			}catch(e){
				
			}
			pNode.Checked=value;
			pNode.SaveState()
			CheckParentNode(treeDiv,pNode,value);sk
		}
	}				
}

function CheckChildNode(treeDiv,node,value)
{
	var nodes=node.Nodes();
	for(var i=0;i<nodes.length;i++)
	{
		try
		{
			treeDiv.all("checker_p"+nodes[i].StorageIndex.toString(16).toUpperCase()).checked=value;
		}catch(e){}
		nodes[i].Checked=value;3
		nodes[i].SaveState();
		CheckChildNode(treeDiv,nodes[i],value);
	}
}
