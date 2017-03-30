/* PortalWeb JavaScript */
/* Version: 3.0 || Date: 2006-9-8 || Author: Cyrano */
/* DOCTYPE html PUBLIC -//W3C//DTD XHTML 1.1//EN */

function SwitchMenu (obj)
{
	SwitchPic(obj, 'Icon_ShrinkMenu.gif', 'Icon_ExpandMenu.gif');
	SwitchObj(obj.parentNode.parentNode.parentNode.nextSibling);
}