using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// ScreeningRoom:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ScreeningRoom
	{
		public ScreeningRoom()
		{}
		#region Model
		private int _id;
		private string _screeningroomname;
		private int _screeningroomrows;
		private int _screeningroomcells;
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
		public string ScreeningRoomName
		{
			set{ _screeningroomname=value;}
			get{return _screeningroomname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ScreeningRoomRows
		{
			set{ _screeningroomrows=value;}
			get{return _screeningroomrows;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ScreeningRoomCells
		{
			set{ _screeningroomcells=value;}
			get{return _screeningroomcells;}
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

