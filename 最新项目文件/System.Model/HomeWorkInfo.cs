using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class HomeWorkInfo
    {
        public HomeWorkInfo()
        { }
        #region Model
        private Nullable<int> _lsh;     //流水号
        private string _zyno;           //作业号
        private string _tgh;            //教工号
        private string _cid;            //课程号
        private string _bzrq;           //布置日期
        private string _zyzw;           //作业正文
        private string _zyfj;           //作业附件
        private string _state;          //作业状态--是否可见
        private string _readed = "0";     //是否阅读
        private string _classno;        //班级编号
        private string _schoolno;       //学校编号
        private string _xnno;           //学年编号
        private string _xqno;           //学期编号
        private DateTime? _djsj = DateTime.Now;  //等级日期
        private string _jlzt = "0";       //记录状态
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
        public string ZYNO
        {
            set { _zyno = value; }
            get { return _zyno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TGH
        {
            set { _tgh = value; }
            get { return _tgh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CID
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BZRQ
        {
            set { _bzrq = value; }
            get { return _bzrq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZYZW
        {
            set { _zyzw = value; }
            get { return _zyzw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZYFJ
        {
            set { _zyfj = value; }
            get { return _zyfj; }
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
        public string READED
        {
            set { _readed = value; }
            get { return _readed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClassNo
        {
            set { _classno = value; }
            get { return _classno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SchoolNo
        {
            set { _schoolno = value; }
            get { return _schoolno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XNNO
        {
            set { _xnno = value; }
            get { return _xnno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XQNO
        {
            set { _xqno = value; }
            get { return _xqno; }
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
