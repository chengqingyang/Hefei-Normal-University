using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class DaYiInfo
    {
        public DaYiInfo()
        { }
        #region Model
        private Nullable<int> _lsh;           //流水号
        private string _wtno;       //问题号
        private string _twz;        //提问者
        private string _cid;        //问题相关课程
        private string _bjid;       //班级号
        private string _title;      //问题标题
        private string _wtzw;       //问题正文
        private string _answer;     //回复
        private string _twsj;       //提问时间
        private string _hdsj;       //回答时间
        private string _state;      //问题状态--是否解决
        private string _classno;        //班级编号
        private string _schoolno;       //学校编号
        private string _xnno;           //学年编号
        private string _xqno;           //学期编号
        private int? _click;        //点击次数(浏览次数)
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
        public string WTNO
        {
            set { _wtno = value; }
            get { return _wtno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TWZ
        {
            set { _twz = value; }
            get { return _twz; }
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
        public string BJID
        {
            set { _bjid = value; }
            get { return _bjid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TITLE
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WTZW
        {
            set { _wtzw = value; }
            get { return _wtzw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ANSWER
        {
            set { _answer = value; }
            get { return _answer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TWSJ
        {
            set { _twsj = value; }
            get { return _twsj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HDSJ
        {
            set { _hdsj = value; }
            get { return _hdsj; }
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
        public int? CLICK
        {
            set { _click = value; }
            get { return _click; }
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
