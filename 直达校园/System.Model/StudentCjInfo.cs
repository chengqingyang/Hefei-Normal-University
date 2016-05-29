
using System;
namespace System.Model
{
	/// <summary>
	/// YW_STUDENTCJ:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StudentCjInfo
	{
		public StudentCjInfo()
		{}
		#region Model
        private Nullable<int> _lsh;
		private string _sno;
		private string _sname;
		private string _classname;
		private string _coursename;
		private string _xnname;
		private string _xqname;
		private decimal? _kcfs;
		private string _bz;
		private DateTime? _lrrq;
		private string _djryxm;
		private DateTime? _xgsj;
		private string _jlzt="0";
		/// <summary>
		/// 
		/// </summary>
        public Nullable<int> LSH
		{
			set{ _lsh=value;}
			get{return _lsh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SNO
		{
			set{ _sno=value;}
			get{return _sno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SNAME
		{
			set{ _sname=value;}
			get{return _sname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CLASSNAME
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string COURSENAME
		{
			set{ _coursename=value;}
			get{return _coursename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string XNNAME
		{
			set{ _xnname=value;}
			get{return _xnname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string XQNAME
		{
			set{ _xqname=value;}
			get{return _xqname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? KCFS
		{
			set{ _kcfs=value;}
			get{return _kcfs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BZ
		{
			set{ _bz=value;}
			get{return _bz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LRRQ
		{
			set{ _lrrq=value;}
			get{return _lrrq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DJRYXM
		{
			set{ _djryxm=value;}
			get{return _djryxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? XGSJ
		{
			set{ _xgsj=value;}
			get{return _xgsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JLZT
		{
			set{ _jlzt=value;}
			get{return _jlzt;}
		}
		#endregion Model

	}
}

