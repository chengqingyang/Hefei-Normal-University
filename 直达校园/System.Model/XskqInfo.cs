using System;
namespace System.Model
{
	[Serializable]
	public partial class XskqInfo
	{
        public XskqInfo()
		{}
		#region Model
        private Nullable<int> _lsh;//流水号
		private string _sno; //学号
		private string _cq; //出勤
		private string _kk;//旷课 
		private string _sj;//事假
		private string _bj;//病假
		private string _djrygh; //登记人员工号
        private Nullable<DateTime> _djrq;//登记日期
		private string _bz;//备注
        private Nullable<DateTime> _xgsj;//修改日期
        private Nullable<DateTime> _lrsj;//录入日期
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
		public string CQ
		{
			set{ _cq=value;}
			get{return _cq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KK
		{
			set{ _kk=value;}
			get{return _kk;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SJ
		{
			set{ _sj=value;}
			get{return _sj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BJ
		{
			set{ _bj=value;}
			get{return _bj;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DJRYGH
		{
			set{ _djrygh=value;}
			get{return _djrygh;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Nullable<DateTime> DJRQ
		{
			set{ _djrq=value;}
			get{return _djrq;}
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
        public Nullable<DateTime> XGSJ
		{
			set{ _xgsj=value;}
			get{return _xgsj;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Nullable<DateTime> LRSJ
		{
			set{ _lrsj=value;}
			get{return _lrsj;}
		}
		#endregion Model

	}
}

