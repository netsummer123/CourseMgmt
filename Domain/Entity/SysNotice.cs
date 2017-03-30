using System;
using System.Data;

using Wicresoft.Common;

namespace CourseMgmt.Domain.Entity
{
	[Serializable]
	[Table("SysNotice", "ID", "CourseMgmt.ConnectionString")]
	public class SysNotice : Info
	{
		#region SQL column name consts 
		public const string SQLCOL_ID = "ID";
		public const string SQLCOL_TITLE = "Title";
		public const string SQLCOL_CONTENT = "Content";
		public const string SQLCOL_SENDERID = "SenderID";
		public const string SQLCOL_SENDERNAME = "SenderName";
		public const string SQLCOL_SENDTIME = "SendTime";
		public const string SQLCOL_DEPARTMENTID = "DepartmentID";
		public const string SQLCOL_DEPARTMENTNAME = "DepartmentName";
		public const string SQLCOL_ISPUBLISHED = "IsPublished";
		public const string SQLCOL_UPDATETIME = "UpdateTime";
		#endregion


		#region Contructors
		/// <summary>
		/// Construct empty entity
		/// </summary>
		public SysNotice () {}

		/// <summary>
		/// Construct entity by primary key, other fields will be assigned by 
		/// "Load" method.
		/// </summary>
		public SysNotice (int ID)
		{
			this.ID = ID;
		}
		#endregion

		public override void Init (DataRow row)
		{
			ID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_ID]);
			Title = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_TITLE]);
			Content = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_CONTENT]);
			SenderID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_SENDERID]);
			SenderName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_SENDERNAME]);
			SendTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_SENDTIME]);
			DepartmentID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_DEPARTMENTID]);
			DepartmentName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_DEPARTMENTNAME]);
			IsPublished = (bool)ObjectType.BooleanTypeHelper.Read(row[SQLCOL_ISPUBLISHED]);
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

		#region Property <int> SenderID
		[Property("SenderID", 4, SqlDbType.Int, false, false)]
		public int SenderID 
		{
			get { return _SenderID; }
			set { _SenderID = value; }
		}
		private int _SenderID = int.MinValue;
		#endregion

		#region Property <string> SenderName
		[Property("SenderName", 50, SqlDbType.NVarChar, false, false)]
		public string SenderName 
		{
			get { return _SenderName; }
			set { _SenderName = value; }
		}
		private string _SenderName = null;
		#endregion

		#region Property <DateTime> SendTime
		[Property("SendTime", 16, SqlDbType.DateTime, false, false)]
		public DateTime SendTime 
		{
			get { return _SendTime; }
			set { _SendTime = value; }
		}
		private DateTime _SendTime = DateTime.MinValue;
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

		#region Property <bool> IsPublished
		[Property("IsPublished", 1, SqlDbType.Bit, false, false)]
		public bool IsPublished 
		{
			get { return _IsPublished; }
			set { _IsPublished = value; }
		}
		private bool _IsPublished = false;
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
