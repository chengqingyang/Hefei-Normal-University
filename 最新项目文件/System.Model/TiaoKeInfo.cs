using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class TiaoKeInfo
    {
        public TiaoKeInfo()
        { }
        #region Model
        private Nullable<int> _lsh;       //流水号
        private string _tkno;   //调课号
        private string _tgh;    //教工号
        private string _tkrq;   //调课日期
        private string _tkzw;   //调课正文
        private string _state;  //调课状态--是否对家长、学生显示
        private string _classno;        //班级编号
        private string _schoolno;       //学校编号
        private string _xnno;           //学年编号
        private string _xqno;           //学期编号
        private string _readed = "0"; //已读--是否已阅读此调课信息
        private DateTime? _djsj = DateTime.Now;  //登记时间
        private string _jlzt = "0";   //记录状态--标记删除
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
        public string TKNO
        {
            set { _tkno = value; }
            get { return _tkno; }
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
        public string TKRQ
        {
            set { _tkrq = value; }
            get { return _tkrq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TKZW
        {
            set { _tkzw = value; }
            get { return _tkzw; }
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
        public string READED
        {
            set { _readed = value; }
            get { return _readed; }
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