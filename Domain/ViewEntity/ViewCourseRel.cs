using System;
using System.Data;

using Wicresoft.Common;

namespace CourseMgmt.Domain.Entity
{
	[Serializable]
	[Table("ViewCourseRel", null, "CourseMgmt.ConnectionString")]
	public class ViewCourseRel : ViewInfo
	{
		#region SQL column name consts 
		public const string SQLCOL_ID = "ID";
		public const string SQLCOL_NAME = "Name";
		public const string SQLCOL_STARTTIME = "StartTime";
		public const string SQLCOL_ENDTIME = "EndTime";
		public const string SQLCOL_YEAR = "Year";
		public const string SQLCOL_TEACHERID = "TeacherID";
		public const string SQLCOL_DEPARTMENTID = "DepartmentID";
		public const string SQLCOL_TEACHERNAME = "TeacherName";
		public const string SQLCOL_DEPARTMENTNAME = "DepartmentName";
		public const string SQLCOL_REGYEAR = "RegYear";
		#endregion


		#region Contructors
		/// <summary>
		/// Construct empty entity
		/// </summary>
		public ViewCourseRel () {}

		#endregion

		public override void Init (DataRow row)
		{
			ID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_ID]);
			Name = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_NAME]);
			StartTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_STARTTIME]);
			EndTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_ENDTIME]);
			Year = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_YEAR]);
			TeacherID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_TEACHERID]);
			DepartmentID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_DEPARTMENTID]);
			TeacherName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_TEACHERNAME]);
			DepartmentName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_DEPARTMENTNAME]);
			RegYear = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_REGYEAR]);
		}

		#region Properties 
		#region Property <int> ID
		[Property("ID", 4, SqlDbType.Int, false, false)]
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

		#region Property <DateTime> StartTime
		[Property("StartTime", 16, SqlDbType.DateTime, false, false)]
		public DateTime StartTime 
		{
			get { return _StartTime; }
			set { _StartTime = value; }
		}
		private DateTime _StartTime = DateTime.MinValue;
		#endregion

		#region Property <DateTime> EndTime
		[Property("EndTime", 16, SqlDbType.DateTime, false, false)]
		public DateTime EndTime 
		{
			get { return _EndTime; }
			set { _EndTime = value; }
		}
		private DateTime _EndTime = DateTime.MinValue;
		#endregion

		#region Property <int> Year
		[Property("Year", 4, SqlDbType.Int, false, false)]
		public int Year 
		{
			get { return _Year; }
			set { _Year = value; }
		}
		private int _Year = int.MinValue;
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

		#region Property <int> DepartmentID
		[Property("DepartmentID", 4, SqlDbType.Int, false, false)]
		public int DepartmentID 
		{
			get { return _DepartmentID; }
			set { _DepartmentID = value; }
		}
		private int _DepartmentID = int.MinValue;
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

		#region Property <string> DepartmentName
		[Property("DepartmentName", 50, SqlDbType.NVarChar, false, false)]
		public string DepartmentName 
		{
			get { return _DepartmentName; }
			set { _DepartmentName = value; }
		}
		private string _DepartmentName = null;
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
	}
}
