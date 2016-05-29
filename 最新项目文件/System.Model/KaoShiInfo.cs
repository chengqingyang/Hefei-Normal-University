using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class KaoShiInfo
    {
        public KaoShiInfo()
        { }
        #region Model
        private Nullable<int> _lsh;       //流水号
        private string _ksno;   //考试编号
        private string _tgh;    //教工号
        private string _cid;    //课程号
        private string _kssj;   //考试时间
        private string _kslx;   //考试类型
        private string _state;  //考试信息状态--是否可见
        private string _classno;        //班级编号
        private string _schoolno;       //学校编号
        private string _xnno;           //学年编号
        private string _xqno;           //学期编号
        private DateTime? _djsj = DateTime.Now;  //登记时间
        private string _jlzt = "0";   //记录状态
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
        public string KSNO
        {
            set { _ksno = value; }
            get { return _ksno; }
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
        public string KSSJ
        {
            set { _kssj = value; }
            get { return _kssj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KSLX
        {
            set { _kslx = value; }
            get { return _kslx; }
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
