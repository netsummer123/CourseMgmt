using System;
using System.Data;

using Wicresoft.Common;

namespace CourseMgmt.Domain.Entity
{
	[Serializable]
	[Table("SysRole", "ID", "CourseMgmt.ConnectionString")]
	public class SysRole : Info
	{
		#region SQL column name consts 
		public const string SQLCOL_ID = "ID";
		public const string SQLCOL_NAME = "Name";
		public const string SQLCOL_DESCRIPTION = "Description";
		public const string SQLCOL_ROLETYPE = "RoleType";
		#endregion


		#region Contructors
		/// <summary>
		/// Construct empty entity
		/// </summary>
		public SysRole () {}

		/// <summary>
		/// Construct entity by primary key, other fields will be assigned by 
		/// "Load" method.
		/// </summary>
		public SysRole (int ID)
		{
			this.ID = ID;
		}
		#endregion

		public override void Init (DataRow row)
		{
			ID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_ID]);
			Name = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_NAME]);
			Description = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_DESCRIPTION]);
			RoleType = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_ROLETYPE]);
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
		[Property("Name", 100, SqlDbType.NVarChar, false, false)]
		public string Name 
		{
			get { return _Name; }
			set { _Name = value; }
		}
		private string _Name = null;
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

		#region Property <int> RoleType
		[Property("RoleType", 4, SqlDbType.Int, false, false)]
		public int RoleType 
		{
			get { return _RoleType; }
			set { _RoleType = value; }
		}
		private int _RoleType = int.MinValue;
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
