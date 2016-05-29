using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
	[Serializable]
    public class XueQiInfo
    {
        public XueQiInfo()
		{}
		#region Model
		private Nullable<int> _lsh; //流水号
		private string _xqno;       //学期编号
		private string _xqname;     //学期名称
		private string _xnno;       //学年编号
		private string _schoolno;   //所在学校
		private DateTime? _ksrq;    //开始日期
		private DateTime? _jsrq;    //结束日期
		private DateTime? _xgsj= DateTime.Now;  //修改日期
        private string _state;      //学期状态--可不可用
		private DateTime? _djsj= DateTime.Now;  //登记日期
		private string _jlzt="0";   //记录状态
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
		public string XQNO
		{
			set{ _xqno=value;}
			get{return _xqno;}
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
		public string XNNO
		{
			set{ _xnno=value;}
			get{return _xnno;}
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
		public DateTime? KSRQ
		{
			set{ _ksrq=value;}
			get{return _ksrq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? JSRQ
		{
			set{ _jsrq=value;}
			get{return _jsrq;}
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
        public string STATE
        {
            set { _state = value; }
            get { return _state; }
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
