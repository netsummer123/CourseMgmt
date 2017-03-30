using System;
using System.Data;

using Wicresoft.Common;

namespace CourseMgmt.Domain.Entity
{
	[Serializable]
	[Table("SysMenu", "ID", "CourseMgmt.ConnectionString")]
	public class SysMenu : Info
	{
		#region SQL column name consts 
		public const string SQLCOL_ID = "ID";
		public const string SQLCOL_NAME = "Name";
		public const string SQLCOL_DISPLAYNAME = "DisplayName";
		public const string SQLCOL_TOOLTIP = "ToolTip";
		public const string SQLCOL_IMAGEURL = "ImageUrl";
		public const string SQLCOL_LINK = "Link";
		public const string SQLCOL_TARGET = "Target";
		public const string SQLCOL_TYPE = "Type";
		public const string SQLCOL_DESCRIPTION = "Description";
		public const string SQLCOL_PARENTID = "ParentID";
		public const string SQLCOL_VISIBLE = "Visible";
		public const string SQLCOL_ORDERNUM = "OrderNum";
		#endregion


		#region Contructors
		/// <summary>
		/// Construct empty entity
		/// </summary>
		public SysMenu () {}

		/// <summary>
		/// Construct entity by primary key, other fields will be assigned by 
		/// "Load" method.
		/// </summary>
		public SysMenu (int ID)
		{
			this.ID = ID;
		}
		#endregion

		public override void Init (DataRow row)
		{
			ID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_ID]);
			Name = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_NAME]);
			DisplayName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_DISPLAYNAME]);
			ToolTip = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_TOOLTIP]);
			ImageUrl = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_IMAGEURL]);
			Link = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_LINK]);
			Target = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_TARGET]);
			Type = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_TYPE]);
			Description = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_DESCRIPTION]);
			ParentID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_PARENTID]);
			Visible = (bool)ObjectType.BooleanTypeHelper.Read(row[SQLCOL_VISIBLE]);
			OrderNum = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_ORDERNUM]);
		}

		#region Properties 
		#region Property <int> ID
		[Property("ID", 4, SqlDbType.Int, true, true)]
		public int ID 
		{
			get { return _ID; }
			set { _ID = value; }
		}
		private int _ID = int.MinValue;
		#endregion

		#region Property <string> Name
		[Property("Name", 50, SqlDbType.NVarChar, false, false)]
		public string Name 
		{
			get { return _Name; }
			set { _Name = value; }
		}
		private string _Name = null;
		#endregion

		#region Property <string> DisplayName
		[Property("DisplayName", 50, SqlDbType.NVarChar, false, false)]
		public string DisplayName 
		{
			get { return _DisplayName; }
			set { _DisplayName = value; }
		}
		private string _DisplayName = null;
		#endregion

		#region Property <string> ToolTip
		[Property("ToolTip", 50, SqlDbType.NVarChar, false, false)]
		public string ToolTip 
		{
			get { return _ToolTip; }
			set { _ToolTip = value; }
		}
		private string _ToolTip = null;
		#endregion

		#region Property <string> ImageUrl
		[Property("ImageUrl", 80, SqlDbType.NVarChar, false, false)]
		public string ImageUrl 
		{
			get { return _ImageUrl; }
			set { _ImageUrl = value; }
		}
		private string _ImageUrl = null;
		#endregion

		#region Property <string> Link
		[Property("Link", 150, SqlDbType.NVarChar, false, false)]
		public string Link 
		{
			get { return _Link; }
			set { _Link = value; }
		}
		private string _Link = null;
		#endregion

		#region Property <string> Target
		[Property("Target", 20, SqlDbType.NVarChar, false, false)]
		public string Target 
		{
			get { return _Target; }
			set { _Target = value; }
		}
		private string _Target = null;
		#endregion

		#region Property <int> Type
		[Property("Type", 4, SqlDbType.Int, false, false)]
		public int Type 
		{
			get { return _Type; }
			set { _Type = value; }
		}
		private int _Type = int.MinValue;
		#endregion

		#region Property <string> Description
		[Property("Description", 500, SqlDbType.NVarChar, false, false)]
		public string Description 
		{
			get { return _Description; }
			set { _Description = value; }
		}
		private string _Description = null;
		#endregion

		#region Property <int> ParentID
		[Property("ParentID", 4, SqlDbType.Int, false, false)]
		public int ParentID 
		{
			get { return _ParentID; }
			set { _ParentID = value; }
		}
		private int _ParentID = int.MinValue;
		#endregion

		#region Property <bool> Visible
		[Property("Visible", 1, SqlDbType.Bit, false, false)]
		public bool Visible 
		{
			get { return _Visible; }
			set { _Visible = value; }
		}
		private bool _Visible = false;
		#endregion

		#region Property <int> OrderNum
		[Property("OrderNum", 4, SqlDbType.Int, false, false)]
		public int OrderNum 
		{
			get { return _OrderNum; }
			set { _OrderNum = value; }
		}
		private int _OrderNum = int.MinValue;
		#endregion
		#endregion


		public bool LoadByIdentity(int ID)
		{
			return DataAccess.SelectByIdentity(this, Convert.ToInt64(ID));
		}


		public bool DeleteByIdentity()
		{
			return DataAccess.DeleteByIdentity(this);
		}
	}
}
