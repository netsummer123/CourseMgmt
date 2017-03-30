using System;
using System.Data;

using Wicresoft.Common;

namespace CourseMgmt.Domain.Entity
{
	[Serializable]
	[Table("SysRoleRel", "", "CourseMgmt.ConnectionString")]
	public class SysRoleRel : Info
	{
		#region SQL column name consts 
		public const string SQLCOL_ROLEID = "RoleID";
		public const string SQLCOL_MENUID = "MenuID";
		#endregion


		#region Contructors
		/// <summary>
		/// Construct empty entity
		/// </summary>
		public SysRoleRel () {}

		/// <summary>
		/// Construct entity by primary key, other fields will be assigned by 
		/// "Load" method.
		/// </summary>
		public SysRoleRel (int RoleID, int MenuID)
		{
			this.RoleID = RoleID;
			this.MenuID = MenuID;
		}
		#endregion

		public override void Init (DataRow row)
		{
			RoleID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_ROLEID]);
			MenuID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_MENUID]);
		}

		#region Properties 
		#region Property <int> RoleID
		[Property("RoleID", 4, SqlDbType.Int, false, true)]
		public int RoleID 
		{
			get { return _RoleID; }
			set { _RoleID = value; }
		}
		private int _RoleID = int.MinValue;
		#endregion

		#region Property <int> MenuID
		[Property("MenuID", 4, SqlDbType.Int, false, true)]
		public int MenuID 
		{
			get { return _MenuID; }
			set { _MenuID = value; }
		}
		private int _MenuID = int.MinValue;
		#endregion
		#endregion




	}
}
