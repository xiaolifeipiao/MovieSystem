using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// MovieInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MovieInfo
	{
		public MovieInfo()
		{}
		#region Model
		private int _id;
		private string _moviename;
		private string _movieactor;
		private string _moviedirector;
		private int? _movietype;
		private decimal? _movieprice;
		private DateTime? _movietime;
		private decimal? _moviefavourable;
		private string _moviepicturepath;
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
		public string MovieName
		{
			set{ _moviename=value;}
			get{return _moviename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MovieActor
		{
			set{ _movieactor=value;}
			get{return _movieactor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MovieDirector
		{
			set{ _moviedirector=value;}
			get{return _moviedirector;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MovieType
		{
			set{ _movietype=value;}
			get{return _movietype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MoviePrice
		{
			set{ _movieprice=value;}
			get{return _movieprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? MovieTime
		{
			set{ _movietime=value;}
			get{return _movietime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MovieFavourable
		{
			set{ _moviefavourable=value;}
			get{return _moviefavourable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MoviePicturePath
		{
			set{ _moviepicturepath=value;}
			get{return _moviepicturepath;}
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

