using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class SchoolInfo
    {
        public SchoolInfo()
        { }
        #region Model
        private Nullable<int> _lsh;               //流水号
        private string _schoolno;       //学校编号
        private string _schoolname;     //学校名称
        private string _schooladdr;     //学校地址
        private string _xzname;         //校长姓名
        private string _bz;             //备注
        private DateTime? _djsj = DateTime.Now;
        private string _jlzt = "0";
        /// <summary>
        /// 
        /// </summary>
        public Nullable<int> LSH
        {
            set { _lsh = value; }
            get { return _lsh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SCHOOLNO
        {
            set { _schoolno = value; }
            get { return _schoolno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SCHOOLNAME
        {
            set { _schoolname = value; }
            get { return _schoolname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SCHOOLADDR
        {
            set { _schooladdr = value; }
            get { return _schooladdr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XZNAME
        {
            set { _xzname = value; }
            get { return _xzname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BZ
        {
            set { _bz = value; }
            get { return _bz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DJSJ
        {
            set { _djsj = value; }
            get { return _djsj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JLZT
        {
            set { _jlzt = value; }
            get { return _jlzt; }
        }
        #endregion Model

    }
}
