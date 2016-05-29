using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class ClassInfo
    {
        public ClassInfo()
		{}
		#region Model
		private Nullable<int> _lsh; //流水号
		private string _classno;    //班级编号
		private string _classname;  //班级名称
		private string _bzrname;    //班主任
		private string _bz;         //备注
		private DateTime? _djsj= DateTime.Now;
		private string _jlzt="0";
		private string _schoolno;   //所属学校
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
		public string CLASSNO
		{
			set{ _classno=value;}
			get{return _classno;}
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
		public string BZRNAME
		{
			set{ _bzrname=value;}
			get{return _bzrname;}
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
		/// <summary>
		/// 
		/// </summary>
		public string SCHOOLNO
		{
			set{ _schoolno=value;}
			get{return _schoolno;}
		}
		#endregion Model

	}
}
