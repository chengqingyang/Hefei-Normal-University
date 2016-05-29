﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class XueNianInfo
    {
        public XueNianInfo()
		{}
		#region Model
		private Nullable<int> _lsh; //流水号
		private string _xnno;       //学年编号
		private string _schoolno;   //学校编号
		private string _xnname;     //学年名称
		private DateTime? _ksrq;    //开始日期
		private DateTime? _jsrq;    //结束日期
		private string _djrygh;     //登记人员工号
		private string _state="0";  //记录状态--是否可用
		private DateTime? _xgsj= DateTime.Now;  //修改时间
		private DateTime? _djsj= DateTime.Now;  //登记时间
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
		public string XNNAME
		{
			set{ _xnname=value;}
			get{return _xnname;}
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
		public string DJRYGH
		{
			set{ _djrygh=value;}
			get{return _djrygh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string STATE
		{
			set{ _state=value;}
			get{return _state;}
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
