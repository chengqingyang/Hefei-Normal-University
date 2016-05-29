using System;
namespace System.Model
{
	/// <summary>
	/// YW_XSQJINFO:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class XsqjInfo
	{
		public XsqjInfo()
		{}
		#region Model
        private Nullable<int> _lsh;//_lsh为可空值类型，可以被赋值null;_lsh.HasValue判断这个可空值类型是否被赋值过一个类型为T的有效值；Nullable<int>等价于int?
		private string _sno;
		private string _sname;
		private string _xnname;
		private string _xqname;
		private string _calssno;
		private string _classname;
		private string _schoolno;
		private string _schoolname;
		private string _qjzt;
		private string _qjsj;
		private string _qjly;
		private string _xsqz;
		private string _jsqz;
		private string _dqzt;
		private DateTime? _xgsj;
		private string _bz;
		private DateTime? _djsj;
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
		public string CALSSNO
		{
			set{ _calssno=value;}
			get{return _calssno;}
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
		public string SCHOOLNO
		{
			set{ _schoolno=value;}
			get{return _schoolno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SCHOOLNAME
		{
			set{ _schoolname=value;}
			get{return _schoolname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QJZT
		{
			set{ _qjzt=value;}
			get{return _qjzt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QJSJ
		{
			set{ _qjsj=value;}
			get{return _qjsj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string QJLY
		{
			set{ _qjly=value;}
			get{return _qjly;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string XSQZ
		{
			set{ _xsqz=value;}
			get{return _xsqz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JSQZ
		{
			set{ _jsqz=value;}
			get{return _jsqz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DQZT
		{
			set{ _dqzt=value;}
			get{return _dqzt;}
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
		public string BZ
		{
			set{ _bz=value;}
			get{return _bz;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DJSJ
		{
			set{ _djsj=value;}
			get{return _djsj;}
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

