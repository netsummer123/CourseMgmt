using System;
using System.Data;

using Wicresoft.Common;

namespace CourseMgmt.Domain.Entity
{
	[Serializable]
	[Table("SysPerformReport", "", "CourseMgmt.ConnectionString")]
	public class SysPerformReport : Info
	{
		#region SQL column name consts 
		public const string SQLCOL_COURSEID = "CourseID";
		public const string SQLCOL_DEPARTMENTID = "DepartmentID";
		public const string SQLCOL_COURSENAME = "CourseName";
		public const string SQLCOL_REGYEAR = "RegYear";
		public const string SQLCOL_DEPARTMENTNAME = "DepartmentName";
		public const string SQLCOL_DEPARTMENTTYPE = "DepartmentType";
		public const string SQLCOL_TEACHERID = "TeacherID";
		public const string SQLCOL_TEACHERNAME = "TeacherName";
		public const string SQLCOL_STATUS = "Status";
		public const string SQLCOL_UPDATETIME = "UpdateTime";
		#endregion


		#region Contructors
		/// <summary>
		/// Construct empty entity
		/// </summary>
		public SysPerformReport () {}

		/// <summary>
		/// Construct entity by primary key, other fields will be assigned by 
		/// "Load" method.
		/// </summary>
		public SysPerformReport (int CourseID, int DepartmentID)
		{
			this.CourseID = CourseID;
			this.DepartmentID = DepartmentID;
		}
		#endregion

		public override void Init (DataRow row)
		{
			CourseID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_COURSEID]);
			DepartmentID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_DEPARTMENTID]);
			CourseName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_COURSENAME]);
			RegYear = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_REGYEAR]);
			DepartmentName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_DEPARTMENTNAME]);
			DepartmentType = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_DEPARTMENTTYPE]);
			TeacherID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_TEACHERID]);
			TeacherName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_TEACHERNAME]);
			Status = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_STATUS]);
			UpdateTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_UPDATETIME]);
		}

		#region Properties 
		#region Property <int> CourseID
		[Property("CourseID", 4, SqlDbType.Int, false, true)]
		public int CourseID 
		{
			get { return _CourseID; }
			set { _CourseID = value; }
		}
		private int _CourseID = int.MinValue;
		#endregion

		#region Property <int> DepartmentID
		[Property("DepartmentID", 4, SqlDbType.Int, false, true)]
		public int DepartmentID 
		{
			get { return _DepartmentID; }
			set { _DepartmentID = value; }
		}
		private int _DepartmentID = int.MinValue;
		#endregion

		#region Property <string> CourseName
		[Property("CourseName", 50, SqlDbType.NVarChar, false, false)]
		public string CourseName 
		{
			get { return _CourseName; }
			set { _CourseName = value; }
		}
		private string _CourseName = null;
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

		#region Property <int> TeacherID
		[Property("TeacherID", 4, SqlDbType.Int, false, false)]
		public int TeacherID 
		{
			get { return _TeacherID; }
			set { _TeacherID = value; }
		}
		private int _TeacherID = int.MinValue;
		#endregion

		#region Property <string> TeacherName
		[Property("TeacherName", 50, SqlDbType.NVarChar, false, false)]
		public string TeacherName 
		{
			get { return _TeacherName; }
			set { _TeacherName = value; }
		}
		private string _TeacherName = null;
		#endregion

		#region Property <int> Status
		[Property("Status", 4, SqlDbType.Int, false, false)]
		public int Status 
		{
			get { return _Status; }
			set { _Status = value; }
		}
		private int _Status = int.MinValue;
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
		#endregion




	}
}
