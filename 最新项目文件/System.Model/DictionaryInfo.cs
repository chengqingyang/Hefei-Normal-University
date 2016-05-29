
using System;
namespace System.Model
{

	[Serializable]
	public partial class DictionaryInfo
	{
        public DictionaryInfo()
		{}
		#region Model
        private Nullable<int> _lsh;
		private string _dazx;
		private string _wtbh;
		private string _wtnr;
		private string _dabh;
		private string _daxx;
		private string _bz;
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
		public string DAZX
		{
			set{ _dazx=value;}
			get{return _dazx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WTBH
		{
			set{ _wtbh=value;}
			get{return _wtbh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WTNR
		{
			set{ _wtnr=value;}
			get{return _wtnr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DABH
		{
			set{ _dabh=value;}
			get{return _dabh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DAXX
		{
			set{ _daxx=value;}
			get{return _daxx;}
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
		public string JLZT
		{
			set{ _jlzt=value;}
			get{return _jlzt;}
		}
		#endregion Model

	}
}

