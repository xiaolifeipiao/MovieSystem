using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// MovieSell:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MovieSell
	{
		public MovieSell()
		{}
		#region Model
		private int _id;
		private int? _movielinedid;
		private string _moviesit;
		private decimal? _moviesellprice;
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
		public int? MovieLinedId
		{
			set{ _movielinedid=value;}
			get{return _movielinedid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MovieSit
		{
			set{ _moviesit=value;}
			get{return _moviesit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? MovieSellPrice
		{
			set{ _moviesellprice=value;}
			get{return _moviesellprice;}
		}
		#endregion Model

	}
}

