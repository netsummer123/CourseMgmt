using System;
using System.Data;

using Wicresoft.Common;

namespace CourseMgmt.Domain.Entity
{
	[Serializable]
	[Table("SysPerform", "", "CourseMgmt.ConnectionString")]
	public class SysPerform : Info
	{
		#region SQL column name consts 
		public const string SQLCOL_COURSEID = "CourseID";
		public const string SQLCOL_STUDENTID = "StudentID";
		public const string SQLCOL_USERNAME = "UserName";
		public const string SQLCOL_REALNAME = "RealName";
		public const string SQLCOL_DEPARTMENTID = "DepartmentID";
		public const string SQLCOL_TASKSCORE1 = "TaskScore1";
		public const string SQLCOL_TASKSCORE2 = "TaskScore2";
		public const string SQLCOL_TASKSCORE3 = "TaskScore3";
		public const string SQLCOL_TASKSCORE4 = "TaskScore4";
		public const string SQLCOL_TASKSCORE5 = "TaskScore5";
		public const string SQLCOL_TASKSCORE6 = "TaskScore6";
		public const string SQLCOL_TASKSCORE7 = "TaskScore7";
		public const string SQLCOL_ROUTINESCORE1 = "RoutineScore1";
		public const string SQLCOL_ROUTINESCORE2 = "RoutineScore2";
		public const string SQLCOL_ROUTINESCORE3 = "RoutineScore3";
		public const string SQLCOL_ROUTINESCORE4 = "RoutineScore4";
		public const string SQLCOL_ROUTINESCORETIME = "RoutineScoreTime";
		public const string SQLCOL_FINALSCORE = "FinalScore";
		public const string SQLCOL_FINALSCORETIME = "FinalScoreTime";
		public const string SQLCOL_UPDATETIME = "UpdateTime";
		#endregion


		#region Contructors
		/// <summary>
		/// Construct empty entity
		/// </summary>
		public SysPerform () {}

		/// <summary>
		/// Construct entity by primary key, other fields will be assigned by 
		/// "Load" method.
		/// </summary>
		public SysPerform (int CourseID, int StudentID)
		{
			this.CourseID = CourseID;
			this.StudentID = StudentID;
		}
		#endregion

		public override void Init (DataRow row)
		{
			CourseID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_COURSEID]);
			StudentID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_STUDENTID]);
			UserName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_USERNAME]);
			RealName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_REALNAME]);
			DepartmentID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_DEPARTMENTID]);
			TaskScore1 = (decimal)ObjectType.DecimalTypeHelper.Read(row[SQLCOL_TASKSCORE1]);
			TaskScore2 = (decimal)ObjectType.DecimalTypeHelper.Read(row[SQLCOL_TASKSCORE2]);
			TaskScore3 = (decimal)ObjectType.DecimalTypeHelper.Read(row[SQLCOL_TASKSCORE3]);
			TaskScore4 = (decimal)ObjectType.DecimalTypeHelper.Read(row[SQLCOL_TASKSCORE4]);
			TaskScore5 = (decimal)ObjectType.DecimalTypeHelper.Read(row[SQLCOL_TASKSCORE5]);
			TaskScore6 = (decimal)ObjectType.DecimalTypeHelper.Read(row[SQLCOL_TASKSCORE6]);
			TaskScore7 = (decimal)ObjectType.DecimalTypeHelper.Read(row[SQLCOL_TASKSCORE7]);
			RoutineScore1 = (decimal)ObjectType.DecimalTypeHelper.Read(row[SQLCOL_ROUTINESCORE1]);
			RoutineScore2 = (decimal)ObjectType.DecimalTypeHelper.Read(row[SQLCOL_ROUTINESCORE2]);
			RoutineScore3 = (decimal)ObjectType.DecimalTypeHelper.Read(row[SQLCOL_ROUTINESCORE3]);
			RoutineScore4 = (decimal)ObjectType.DecimalTypeHelper.Read(row[SQLCOL_ROUTINESCORE4]);
			RoutineScoreTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_ROUTINESCORETIME]);
			FinalScore = (decimal)ObjectType.DecimalTypeHelper.Read(row[SQLCOL_FINALSCORE]);
			FinalScoreTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_FINALSCORETIME]);
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

		#region Property <int> StudentID
		[Property("StudentID", 4, SqlDbType.Int, false, true)]
		public int StudentID 
		{
			get { return _StudentID; }
			set { _StudentID = value; }
		}
		private int _StudentID = int.MinValue;
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

		#region Property <string> RealName
		[Property("RealName", 50, SqlDbType.NVarChar, false, false)]
		public string RealName 
		{
			get { return _RealName; }
			set { _RealName = value; }
		}
		private string _RealName = null;
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

		#region Property <decimal> TaskScore1
		[Property("TaskScore1", 20, SqlDbType.Decimal, false, false)]
		public decimal TaskScore1 
		{
			get { return _TaskScore1; }
			set { _TaskScore1 = value; }
		}
		private decimal _TaskScore1 = decimal.MinValue;
		#endregion

		#region Property <decimal> TaskScore2
		[Property("TaskScore2", 20, SqlDbType.Decimal, false, false)]
		public decimal TaskScore2 
		{
			get { return _TaskScore2; }
			set { _TaskScore2 = value; }
		}
		private decimal _TaskScore2 = decimal.MinValue;
		#endregion

		#region Property <decimal> TaskScore3
		[Property("TaskScore3", 20, SqlDbType.Decimal, false, false)]
		public decimal TaskScore3 
		{
			get { return _TaskScore3; }
			set { _TaskScore3 = value; }
		}
		private decimal _TaskScore3 = decimal.MinValue;
		#endregion

		#region Property <decimal> TaskScore4
		[Property("TaskScore4", 20, SqlDbType.Decimal, false, false)]
		public decimal TaskScore4 
		{
			get { return _TaskScore4; }
			set { _TaskScore4 = value; }
		}
		private decimal _TaskScore4 = decimal.MinValue;
		#endregion

		#region Property <decimal> TaskScore5
		[Property("TaskScore5", 20, SqlDbType.Decimal, false, false)]
		public decimal TaskScore5 
		{
			get { return _TaskScore5; }
			set { _TaskScore5 = value; }
		}
		private decimal _TaskScore5 = decimal.MinValue;
		#endregion

		#region Property <decimal> TaskScore6
		[Property("TaskScore6", 20, SqlDbType.Decimal, false, false)]
		public decimal TaskScore6 
		{
			get { return _TaskScore6; }
			set { _TaskScore6 = value; }
		}
		private decimal _TaskScore6 = decimal.MinValue;
		#endregion

		#region Property <decimal> TaskScore7
		[Property("TaskScore7", 20, SqlDbType.Decimal, false, false)]
		public decimal TaskScore7 
		{
			get { return _TaskScore7; }
			set { _TaskScore7 = value; }
		}
		private decimal _TaskScore7 = decimal.MinValue;
		#endregion

		#region Property <decimal> RoutineScore1
		[Property("RoutineScore1", 20, SqlDbType.Decimal, false, false)]
		public decimal RoutineScore1 
		{
			get { return _RoutineScore1; }
			set { _RoutineScore1 = value; }
		}
		private decimal _RoutineScore1 = decimal.MinValue;
		#endregion

		#region Property <decimal> RoutineScore2
		[Property("RoutineScore2", 20, SqlDbType.Decimal, false, false)]
		public decimal RoutineScore2 
		{
			get { return _RoutineScore2; }
			set { _RoutineScore2 = value; }
		}
		private decimal _RoutineScore2 = decimal.MinValue;
		#endregion

		#region Property <decimal> RoutineScore3
		[Property("RoutineScore3", 20, SqlDbType.Decimal, false, false)]
		public decimal RoutineScore3 
		{
			get { return _RoutineScore3; }
			set { _RoutineScore3 = value; }
		}
		private decimal _RoutineScore3 = decimal.MinValue;
		#endregion

		#region Property <decimal> RoutineScore4
		[Property("RoutineScore4", 20, SqlDbType.Decimal, false, false)]
		public decimal RoutineScore4 
		{
			get { return _RoutineScore4; }
			set { _RoutineScore4 = value; }
		}
		private decimal _RoutineScore4 = decimal.MinValue;
		#endregion

		#region Property <DateTime> RoutineScoreTime
		[Property("RoutineScoreTime", 16, SqlDbType.DateTime, false, false)]
		public DateTime RoutineScoreTime 
		{
			get { return _RoutineScoreTime; }
			set { _RoutineScoreTime = value; }
		}
		private DateTime _RoutineScoreTime = DateTime.MinValue;
		#endregion

		#region Property <decimal> FinalScore
		[Property("FinalScore", 20, SqlDbType.Decimal, false, false)]
		public decimal FinalScore 
		{
			get { return _FinalScore; }
			set { _FinalScore = value; }
		}
		private decimal _FinalScore = decimal.MinValue;
		#endregion

		#region Property <DateTime> FinalScoreTime
		[Property("FinalScoreTime", 16, SqlDbType.DateTime, false, false)]
		public DateTime FinalScoreTime 
		{
			get { return _FinalScoreTime; }
			set { _FinalScoreTime = value; }
		}
		private DateTime _FinalScoreTime = DateTime.MinValue;
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
