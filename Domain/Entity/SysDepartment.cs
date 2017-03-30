using System;
using System.Data;

using Wicresoft.Common;

namespace CourseMgmt.Domain.Entity
{
	[Serializable]
	[Table("SysDepartment", "ID", "CourseMgmt.ConnectionString")]
	public class SysDepartment : Info
	{
		#region SQL column name consts 
		public const string SQLCOL_ID = "ID";
		public const string SQLCOL_PARENTID = "ParentID";
		public const string SQLCOL_PARENTNAME = "ParentName";
		public const string SQLCOL_BASEDEPTID = "BaseDeptID";
		public const string SQLCOL_BASEDEPTNAME = "BaseDeptName";
		public const string SQLCOL_DEPTPATH = "DeptPath";
		public const string SQLCOL_NAME = "Name";
		public const string SQLCOL_ORDERNUM = "OrderNum";
		public const string SQLCOL_DEPARTMENTTYPE = "DepartmentType";
		public const string SQLCOL_UPDATETIME = "UpdateTime";
		public const string SQLCOL_REGYEAR = "RegYear";
		public const string SQLCOL_ISDELETED = "IsDeleted";
		#endregion


		#region Contructors
		/// <summary>
		/// Construct empty entity
		/// </summary>
		public SysDepartment () {}

		/// <summary>
		/// Construct entity by primary key, other fields will be assigned by 
		/// "Load" method.
		/// </summary>
		public SysDepartment (int ID)
		{
			this.ID = ID;
		}
		#endregion

		public override void Init (DataRow row)
		{
			ID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_ID]);
			ParentID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_PARENTID]);
			ParentName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_PARENTNAME]);
			BaseDeptID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_BASEDEPTID]);
			BaseDeptName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_BASEDEPTNAME]);
			DeptPath = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_DEPTPATH]);
			Name = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_NAME]);
			OrderNum = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_ORDERNUM]);
			DepartmentType = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_DEPARTMENTTYPE]);
			UpdateTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_UPDATETIME]);
			RegYear = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_REGYEAR]);
			IsDeleted = (bool)ObjectType.BooleanTypeHelper.Read(row[SQLCOL_ISDELETED]);
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

		#region Property <int> ParentID
		[Property("ParentID", 4, SqlDbType.Int, false, false)]
		public int ParentID 
		{
			get { return _ParentID; }
			set { _ParentID = value; }
		}
		private int _ParentID = int.MinValue;
		#endregion

		#region Property <string> ParentName
		[Property("ParentName", 50, SqlDbType.NVarChar, false, false)]
		public string ParentName 
		{
			get { return _ParentName; }
			set { _ParentName = value; }
		}
		private string _ParentName = null;
		#endregion

		#region Property <int> BaseDeptID
		[Property("BaseDeptID", 4, SqlDbType.Int, false, false)]
		public int BaseDeptID 
		{
			get { return _BaseDeptID; }
			set { _BaseDeptID = value; }
		}
		private int _BaseDeptID = int.MinValue;
		#endregion

		#region Property <string> BaseDeptName
		[Property("BaseDeptName", 50, SqlDbType.NVarChar, false, false)]
		public string BaseDeptName 
		{
			get { return _BaseDeptName; }
			set { _BaseDeptName = value; }
		}
		private string _BaseDeptName = null;
		#endregion

		#region Property <string> DeptPath
		[Property("DeptPath", 100, SqlDbType.VarChar, false, false)]
		public string DeptPath 
		{
			get { return _DeptPath; }
			set { _DeptPath = value; }
		}
		private string _DeptPath = null;
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

		#region Property <int> OrderNum
		[Property("OrderNum", 4, SqlDbType.Int, false, false)]
		public int OrderNum 
		{
			get { return _OrderNum; }
			set { _OrderNum = value; }
		}
		private int _OrderNum = int.MinValue;
		#endregion

		#region Property <int> DepartmentType
		[Property("DepartmentType", 4, SqlDbType.Int, false, false)]
		public int DepartmentType 
		{
			get { return _DepartmentType; }
			set { _DepartmentType = value; }
		}
		private int _DepartmentType = int.MinValue;
		#endregion

		#region Property <DateTime> UpdateTime
		[Property("UpdateTime", 16, SqlDbType.DateTime, false, false)]
		public DateTime UpdateTime 
		{
			get { return _UpdateTime; }
			set { _UpdateTime = value; }
		}
		private DateTime _UpdateTime = DateTime.MinValue;
		#endregion

		#region Property <int> RegYear
		[Property("RegYear", 4, SqlDbType.Int, false, false)]
		public int RegYear 
		{
			get { return _RegYear; }
			set { _RegYear = value; }
		}
		private int _RegYear = int.MinValue;
		#endregion

		#region Property <bool> IsDeleted
		[Property("IsDeleted", 1, SqlDbType.Bit, false, false)]
		public bool IsDeleted 
		{
			get { return _IsDeleted; }
			set { _IsDeleted = value; }
		}
		private bool _IsDeleted = false;
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
