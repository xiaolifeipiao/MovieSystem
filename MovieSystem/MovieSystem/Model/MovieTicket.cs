using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Model
{
    /// <summary>
    /// MovieTicket:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
  public  class MovieTicket
    {
        #region Model
		private string  _movieid;
		private string _movieroom;
		private string _moviename;
        private string _moviesit;
        private decimal _movieprice;
		/// <summary>
		/// 
		/// </summary>
		public string MovieId
		{
			set{ _movieid=value;}
			get{return _movieid;}
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
        public string MovieRoom
        {
            set { _movieroom = value; }
            get { return _movieroom; }
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
        public decimal MoviePrice
		{
            set { _movieprice = value; }
            get { return _movieprice; }
		}
		#endregion Model

	}
    
}
