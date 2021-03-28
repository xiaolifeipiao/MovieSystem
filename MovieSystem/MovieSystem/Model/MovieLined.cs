using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// MovieLined:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MovieLined
	{
		public MovieLined()
		{}
		#region Model
		private int _id;
		private int _movieid;
		private DateTime _movietime;
		private int _movielength;
		private int _movieroomid;
		private string _description;
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
		public int MovieId
		{
			set{ _movieid=value;}
			get{return _movieid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime MovieTime
		{
			set{ _movietime=value;}
			get{return _movietime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MovieLength
		{
			set{ _movielength=value;}
			get{return _movielength;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MovieRoomId
		{
			set{ _movieroomid=value;}
			get{return _movieroomid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model

	}
}

