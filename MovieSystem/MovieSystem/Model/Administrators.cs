using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Administrators:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Administrators
	{
		public Administrators()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _useraccount;
		private string _userpassword;
		private int _usertype;
		private string _description;
        private string _time;
        private string _userimage;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserAccount
		{
			set{ _useraccount=value;}
			get{return _useraccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserPassword
		{
			set{ _userpassword=value;}
			get{return _userpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UserType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
        public string UserImage
		{
			set{ _userimage=value;}
			get{return _userimage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
        public string Time
        {
            set { _time = value; }
            get { return _time; }
        }
		#endregion Model

	}
}

