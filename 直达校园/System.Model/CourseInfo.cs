using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class CourseInfo
    {
        public CourseInfo()
		{}
		#region Model
		private Nullable<int> _lsh; //流水号
		private string _schoolno;   //所属学校编号
		private string _courseno;   //课程号
		private string _coursename; //课程名
		private string _bz;         //备注
		private string _djrygh;     //等级人员工号
		private DateTime? _xgsj= DateTime.Now;  //修改时间
		private DateTime? _djsj= DateTime.Now;  //登记时间
		private string _jlzt="0";               //记录状态
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
		public string SCHOOLNO
		{
			set{ _schoolno=value;}
			get{return _schoolno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string COURSENO
		{
			set{ _courseno=value;}
			get{return _courseno;}
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
		public string BZ
		{
			set{ _bz=value;}
			get{return _bz;}
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
