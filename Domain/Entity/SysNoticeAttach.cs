using System;
using System.Data;

using Wicresoft.Common;

namespace CourseMgmt.Domain.Entity
{
	[Serializable]
	[Table("SysNoticeAttach", "ID", "CourseMgmt.ConnectionString")]
	public class SysNoticeAttach : Info
	{
		#region SQL column name consts 
		public const string SQLCOL_ID = "ID";
		public const string SQLCOL_NOTICEID = "NoticeID";
		public const string SQLCOL_FILENAME = "FileName";
		public const string SQLCOL_FILEPATH = "FilePath";
		public const string SQLCOL_FILESIZE = "FileSize";
		public const string SQLCOL_DOWNLOADCOUNT = "DownloadCount";
		public const string SQLCOL_UPLOADTIME = "UploadTime";
		#endregion


		#region Contructors
		/// <summary>
		/// Construct empty entity
		/// </summary>
		public SysNoticeAttach () {}

		/// <summary>
		/// Construct entity by primary key, other fields will be assigned by 
		/// "Load" method.
		/// </summary>
		public SysNoticeAttach (int ID)
		{
			this.ID = ID;
		}
		#endregion

		public override void Init (DataRow row)
		{
			ID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_ID]);
			NoticeID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_NOTICEID]);
			FileName = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_FILENAME]);
			FilePath = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_FILEPATH]);
			FileSize = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_FILESIZE]);
			DownloadCount = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_DOWNLOADCOUNT]);
			UploadTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_UPLOADTIME]);
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

		#region Property <int> NoticeID
		[Property("NoticeID", 4, SqlDbType.Int, false, false)]
		public int NoticeID 
		{
			get { return _NoticeID; }
			set { _NoticeID = value; }
		}
		private int _NoticeID = int.MinValue;
		#endregion

		#region Property <string> FileName
		[Property("FileName", 200, SqlDbType.NVarChar, false, false)]
		public string FileName 
		{
			get { return _FileName; }
			set { _FileName = value; }
		}
		private string _FileName = null;
		#endregion

		#region Property <string> FilePath
		[Property("FilePath", 500, SqlDbType.NVarChar, false, false)]
		public string FilePath 
		{
			get { return _FilePath; }
			set { _FilePath = value; }
		}
		private string _FilePath = null;
		#endregion

		#region Property <int> FileSize
		[Property("FileSize", 4, SqlDbType.Int, false, false)]
		public int FileSize 
		{
			get { return _FileSize; }
			set { _FileSize = value; }
		}
		private int _FileSize = int.MinValue;
		#endregion

		#region Property <int> DownloadCount
		[Property("DownloadCount", 4, SqlDbType.Int, false, false)]
		public int DownloadCount 
		{
			get { return _DownloadCount; }
			set { _DownloadCount = value; }
		}
		private int _DownloadCount = int.MinValue;
		#endregion

		#region Property <DateTime> UploadTime
		[Property("UploadTime", 16, SqlDbType.DateTime, false, false)]
		public DateTime UploadTime 
		{
			get { return _UploadTime; }
			set { _UploadTime = value; }
		}
		private DateTime _UploadTime = DateTime.MinValue;
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
