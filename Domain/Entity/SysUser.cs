using System;
using System.Data;

using Wicresoft.Common;

namespace CourseMgmt.Domain.Entity
{
	[Serializable]
	[Table("SysUser", "ID", "CourseMgmt.ConnectionString")]
	public class SysUser : Info
	{
		#region SQL column name consts 
		public const string SQLCOL_ID = "ID";
		public const string SQLCOL_USERNAME = "UserName";
		public const string SQLCOL_PASSWORD = "Password";
		public const string SQLCOL_USERTYPE = "UserType";
		public const string SQLCOL_ROLEIDS = "RoleIDs";
		public const string SQLCOL_ROLES = "Roles";
		public const string SQLCOL_REALNAME = "RealName";
		public const string SQLCOL_SEX = "Sex";
		public const string SQLCOL_BINRTHDAY = "Binrthday";
		public const string SQLCOL_TEL = "Tel";
		public const string SQLCOL_MOBILE = "Mobile";
		public const string SQLCOL_EMAIL = "Email";
		public const string SQLCOL_DUTY = "Duty";
		public const string SQLCOL_BASEDEPTID = "BaseDeptID";
		public const string SQLCOL_BASEDEPTNAME = "BaseDeptName";
		public const string SQLCOL_DEPARTMENTID = "DepartmentID";
		public const string SQLCOL_DEPARTMENTNAME = "DepartmentName";
		public const string SQLCOL_DEPARTMENTTYPE = "DepartmentType";
		public const string SQLCOL_DEPTPATH = "DeptPath";
		public const string SQLCOL_ISDELETED = "IsDeleted";
		public const string SQLCOL_REMARK = "Remark";
		public const string SQLCOL_ORDERNUM = "OrderNum";
		public const string SQLCOL_LASTLOGINTIME = "LastLoginTime";
		public const string SQLCOL_UPDATETIME = "UpdateTime";
		public const string SQLCOL_STATUS = "Status";
		public const string SQLCOL_REGYEAR = "RegYear";
		#endregion


		#region Contructors
		/// <summary>
		/// Construct empty entity
		/// </summary>
		public SysUser () {}

		/// <summary>
		/// Construct entity by primary key, other fields will be assigned by 
		/// "Load" method.
		/// </summary>
		public SysUser (int ID)
		{
			this.ID = ID;
		}
		#endregion

		public override void Init (DataRow row)
		{
			ID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_ID]);
			UserName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_USERNAME]);
			Password = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_PASSWORD]);
			UserType = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_USERTYPE]);
			RoleIDs = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_ROLEIDS]);
			Roles = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_ROLES]);
			RealName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_REALNAME]);
			Sex = (byte)ObjectType.ByteTypeHelper.Read(row[SQLCOL_SEX]);
			Binrthday = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_BINRTHDAY]);
			Tel = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_TEL]);
			Mobile = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_MOBILE]);
			Email = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_EMAIL]);
			Duty = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_DUTY]);
			BaseDeptID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_BASEDEPTID]);
			BaseDeptName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_BASEDEPTNAME]);
			DepartmentID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_DEPARTMENTID]);
			DepartmentName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_DEPARTMENTNAME]);
			DepartmentType = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_DEPARTMENTTYPE]);
			DeptPath = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_DEPTPATH]);
			IsDeleted = (bool)ObjectType.BooleanTypeHelper.Read(row[SQLCOL_ISDELETED]);
			Remark = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_REMARK]);
			OrderNum = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_ORDERNUM]);
			LastLoginTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_LASTLOGINTIME]);
			UpdateTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_UPDATETIME]);
			Status = (byte)ObjectType.ByteTypeHelper.Read(row[SQLCOL_STATUS]);
			RegYear = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_REGYEAR]);
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

		#region Property <string> UserName
		[Property("UserName", 20, SqlDbType.NVarChar, false, false)]
		public string UserName 
		{
			get { return _UserName; }
			set { _UserName = value; }
		}
		private string _UserName = null;
		#endregion

		#region Property <string> Password
		[Property("Password", 50, SqlDbType.NVarChar, false, false)]
		public string Password 
		{
			get { return _Password; }
			set { _Password = value; }
		}
		private string _Password = null;
		#endregion

		#region Property <int> UserType
		[Property("UserType", 4, SqlDbType.Int, false, false)]
		public int UserType 
		{
			get { return _UserType; }
			set { _UserType = value; }
		}
		private int _UserType = int.MinValue;
		#endregion

		#region Property <string> RoleIDs
		[Property("RoleIDs", 100, SqlDbType.VarChar, false, false)]
		public string RoleIDs 
		{
			get { return _RoleIDs; }
			set { _RoleIDs = value; }
		}
		private string _RoleIDs = null;
		#endregion

		#region Property <string> Roles
		[Property("Roles", 300, SqlDbType.NVarChar, false, false)]
		public string Roles 
		{
			get { return _Roles; }
			set { _Roles = value; }
		}
		private string _Roles = null;
		#endregion

		#region Property <string> RealName
		[Property("RealName", 20, SqlDbType.NVarChar, false, false)]
		public string RealName 
		{
			get { return _RealName; }
			set { _RealName = value; }
		}
		private string _RealName = null;
		#endregion

		#region Property <byte> Sex
		[Property("Sex", 1, SqlDbType.TinyInt, false, false)]
		public byte Sex 
		{
			get { return _Sex; }
			set { _Sex = value; }
		}
		private byte _Sex = byte.MinValue;
		#endregion

		#region Property <DateTime> Binrthday
		[Property("Binrthday", 16, SqlDbType.DateTime, false, false)]
		public DateTime Binrthday 
		{
			get { return _Binrthday; }
			set { _Binrthday = value; }
		}
		private DateTime _Binrthday = DateTime.MinValue;
		#endregion

		#region Property <string> Tel
		[Property("Tel", 30, SqlDbType.VarChar, false, false)]
		public string Tel 
		{
			get { return _Tel; }
			set { _Tel = value; }
		}
		private string _Tel = null;
		#endregion

		#region Property <string> Mobile
		[Property("Mobile", 20, SqlDbType.VarChar, false, false)]
		public string Mobile 
		{
			get { return _Mobile; }
			set { _Mobile = value; }
		}
		private string _Mobile = null;
		#endregion

		#region Property <string> Email
		[Property("Email", 50, SqlDbType.NVarChar, false, false)]
		public string Email 
		{
			get { return _Email; }
			set { _Email = value; }
		}
		private string _Email = null;
		#endregion

		#region Property <string> Duty
		[Property("Duty", 50, SqlDbType.NVarChar, false, false)]
		public string Duty 
		{
			get { return _Duty; }
			set { _Duty = value; }
		}
		private string _Duty = null;
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

		#region Property <int> DepartmentID
		[Property("DepartmentID", 4, SqlDbType.Int, false, false)]
		public int DepartmentID 
		{
			get { return _DepartmentID; }
			set { _DepartmentID = value; }
		}
		private int _DepartmentID = int.MinValue;
		#endregion

		#region Property <string> DepartmentName
		[Property("DepartmentName", 50, SqlDbType.NVarChar, false, false)]
		public string DepartmentName 
		{
			get { return _DepartmentName; }
			set { _DepartmentName = value; }
		}
		private string _DepartmentName = null;
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

		#region Property <string> DeptPath
		[Property("DeptPath", 100, SqlDbType.VarChar, false, false)]
		public string DeptPath 
		{
			get { return _DeptPath; }
			set { _DeptPath = value; }
		}
		private string _DeptPath = null;
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

		#region Property <string> Remark
		[Property("Remark", 250, SqlDbType.NVarChar, false, false)]
		public string Remark 
		{
			get { return _Remark; }
			set { _Remark = value; }
		}
		private string _Remark = null;
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

		#region Property <DateTime> LastLoginTime
		[Property("LastLoginTime", 16, SqlDbType.DateTime, false, false)]
		public DateTime LastLoginTime 
		{
			get { return _LastLoginTime; }
			set { _LastLoginTime = value; }
		}
		private DateTime _LastLoginTime = DateTime.MinValue;
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

		#region Property <byte> Status
		[Property("Status", 1, SqlDbType.TinyInt, false, false)]
		public byte Status 
		{
			get { return _Status; }
			set { _Status = value; }
		}
		private byte _Status = byte.MinValue;
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
