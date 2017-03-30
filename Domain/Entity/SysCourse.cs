using System;
using System.Data;

using Wicresoft.Common;

namespace CourseMgmt.Domain.Entity
{
	[Serializable]
	[Table("SysCourse", "ID", "CourseMgmt.ConnectionString")]
	public class SysCourse : Info
	{
		#region SQL column name consts 
		public const string SQLCOL_ID = "ID";
		public const string SQLCOL_NAME = "Name";
		public const string SQLCOL_STARTTIME = "StartTime";
		public const string SQLCOL_ENDTIME = "EndTime";
		public const string SQLCOL_YEAR = "Year";
		public const string SQLCOL_DESCRIPTION = "Description";
		#endregion


		#region Contructors
		/// <summary>
		/// Construct empty entity
		/// </summary>
		public SysCourse () {}

		/// <summary>
		/// Construct entity by primary key, other fields will be assigned by 
		/// "Load" method.
		/// </summary>
		public SysCourse (int ID)
		{
			this.ID = ID;
		}
		#endregion

		public override void Init (DataRow row)
		{
			ID = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_ID]);
			Name = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_NAME]);
			StartTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_STARTTIME]);
			EndTime = (DateTime)ObjectType.DateTimeTypeHelper.Read(row[SQLCOL_ENDTIME]);
			Year = (int)ObjectType.IntTypeHelper.Read(row[SQLCOL_YEAR]);
			Description = (string)ObjectType.StringTypeHelper.Read(row[SQLCOL_DESCRIPTION]);
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

		#region Property <string> Description
		[Property("Description", 500, SqlDbType.NVarChar, false, false)]
		public string Description 
		{
			get { return _Description; }
			set { _Description = value; }
		}
		private string _Description = null;
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
