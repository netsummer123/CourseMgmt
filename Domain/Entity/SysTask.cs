using System;
using System.Data;

using Wicresoft.Common;

namespace CourseMgmt.Domain.Entity
{
	[Serializable]
	[Table("SysTask", "ID", "CourseMgmt.ConnectionString")]
	public class SysTask : Info
	{
		#region SQL column name consts 
		public const string SQLCOL_ID = "ID";
		public const string SQLCOL_COURSEID = "CourseID";
		public const string SQLCOL_COURSENAME = "CourseName";
		public const string SQLCOL_STUDENTID = "StudentID";
		public const string SQLCOL_DEPARTMENTID = "DepartmentID";
		public const string SQLCOL_CATEGORYID = "CategoryID";
		public const string SQLCOL_TITLE = "Title";
		public const string SQLCOL_CONTENT = "Content";
		public const string SQLCOL_FINISHTIME = "FinishTime";
		public const string SQLCOL_MEMBER = "Member";
		public const string SQLCOL_STATUS = "Status";
		public const string SQLCOL_SCORE = "Score";
		public const string SQLCOL_SCORETIME = "ScoreTime";
		public const string SQLCOL_SCORENOTE = "ScoreNote";
		public const string SQLCOL_UPDATETIME = "UpdateTime";
		#endregion


		#region Contructors
		/// <summary>
		/// Construct empty entity
		/// </summary>
		public SysTask () {}

		/// <summary>
		/// Construct entity by primary key, other fields will be assigned by 
		/// "Load" method.
		/// </summary>
		public SysTask (int ID)
		{
			this.ID = ID;
		}
		#endregion

		public override void Init (DataRow row)
		{
			ID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_ID]);
			CourseID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_COURSEID]);
			CourseName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_COURSENAME]);
			StudentID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_STUDENTID]);
			DepartmentID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_DEPARTMENTID]);
			CategoryID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_CATEGORYID]);
			Title = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_TITLE]);
			Content = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_CONTENT]);
			FinishTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_FINISHTIME]);
			Member = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_MEMBER]);
			Status = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_STATUS]);
			Score = (decimal)ObjectType.DecimalTypeHelper.Read(row[SQLCOL_SCORE]);
			ScoreTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_SCORETIME]);
			ScoreNote = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_SCORENOTE]);
			UpdateTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_UPDATETIME]);
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

		#region Property <int> CourseID
		[Property("CourseID", 4, SqlDbType.Int, false, false)]
		public int CourseID 
		{
			get { return _CourseID; }
			set { _CourseID = value; }
		}
		private int _CourseID = int.MinValue;
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

		#region Property <int> StudentID
		[Property("StudentID", 4, SqlDbType.Int, false, false)]
		public int StudentID 
		{
			get { return _StudentID; }
			set { _StudentID = value; }
		}
		private int _StudentID = int.MinValue;
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

		#region Property <int> CategoryID
		[Property("CategoryID", 4, SqlDbType.Int, false, false)]
		public int CategoryID 
		{
			get { return _CategoryID; }
			set { _CategoryID = value; }
		}
		private int _CategoryID = int.MinValue;
		#endregion

		#region Property <string> Title
		[Property("Title", 200, SqlDbType.NVarChar, false, false)]
		public string Title 
		{
			get { return _Title; }
			set { _Title = value; }
		}
		private string _Title = null;
		#endregion

		#region Property <string> Content
		[Property("Content", 2147483646, SqlDbType.NText, false, false)]
		public string Content 
		{
			get { return _Content; }
			set { _Content = value; }
		}
		private string _Content = null;
		#endregion

		#region Property <DateTime> FinishTime
		[Property("FinishTime", 16, SqlDbType.DateTime, false, false)]
		public DateTime FinishTime 
		{
			get { return _FinishTime; }
			set { _FinishTime = value; }
		}
		private DateTime _FinishTime = DateTime.MinValue;
		#endregion

		#region Property <string> Member
		[Property("Member", 200, SqlDbType.NVarChar, false, false)]
		public string Member 
		{
			get { return _Member; }
			set { _Member = value; }
		}
		private string _Member = null;
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

		#region Property <decimal> Score
		[Property("Score", 20, SqlDbType.Decimal, false, false)]
		public decimal Score 
		{
			get { return _Score; }
			set { _Score = value; }
		}
		private decimal _Score = decimal.MinValue;
		#endregion

		#region Property <DateTime> ScoreTime
		[Property("ScoreTime", 16, SqlDbType.DateTime, false, false)]
		public DateTime ScoreTime 
		{
			get { return _ScoreTime; }
			set { _ScoreTime = value; }
		}
		private DateTime _ScoreTime = DateTime.MinValue;
		#endregion

		#region Property <string> ScoreNote
		[Property("ScoreNote", 200, SqlDbType.NVarChar, false, false)]
		public string ScoreNote 
		{
			get { return _ScoreNote; }
			set { _ScoreNote = value; }
		}
		private string _ScoreNote = null;
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
