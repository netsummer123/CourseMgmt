using System;
using System.Data;

using Wicresoft.Common;

namespace CourseMgmt.Domain.Entity
{
	[Serializable]
	[Table("SysCourseRel", "", "CourseMgmt.ConnectionString")]
	public class SysCourseRel : Info
	{
		#region SQL column name consts 
		public const string SQLCOL_COURSEID = "CourseID";
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
		public SysCourseRel () {}

		/// <summary>
		/// Construct entity by primary key, other fields will be assigned by 
		/// "Load" method.
		/// </summary>
		public SysCourseRel (int CourseID, int TeacherID, int DepartmentID)
		{
			this.CourseID = CourseID;
			this.TeacherID = TeacherID;
			this.DepartmentID = DepartmentID;
		}
		#endregion

		public override void Init (DataRow row)
		{
			CourseID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_COURSEID]);
			TeacherID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_TEACHERID]);
			DepartmentID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_DEPARTMENTID]);
			TeacherName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_TEACHERNAME]);
			DepartmentName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_DEPARTMENTNAME]);
			RegYear = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_REGYEAR]);
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

		#region Property <int> TeacherID
		[Property("TeacherID", 4, SqlDbType.Int, false, true)]
		public int TeacherID 
		{
			get { return _TeacherID; }
			set { _TeacherID = value; }
		}
		private int _TeacherID = int.MinValue;
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
