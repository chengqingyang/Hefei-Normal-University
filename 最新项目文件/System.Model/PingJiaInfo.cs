using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class PingJiaInfo
    {
        public PingJiaInfo()
        { }
        #region Model
        private Nullable<int> _lsh;     //流水号
        private string _pjno;           //评价编号
        private string _sno;            //学号
        private string _tgh;            //教工号
        private int? _pf;               //评分
        private string _py;             //评语
        private string _pjsj;           //评价时间
        private string _flag;           //标记是学生还是教师的评价
        private string _state;          //是否评价
        private string _classno;        //班级编号
        private string _schoolno;       //学校编号
        private string _xnno;           //学年编号
        private string _xqno;           //学期编号
        private DateTime? _djsj = DateTime.Now;  //登记时间
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
        public string PJNO
        {
            set { _pjno = value; }
            get { return _pjno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SNO
        {
            set { _sno = value; }
            get { return _sno; }
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
        public int? PF
        {
            set { _pf = value; }
            get { return _pf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PY
        {
            set { _py = value; }
            get { return _py; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PJSJ
        {
            set { _pjsj = value; }
            get { return _pjsj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FLAG
        {
            set { _flag = value; }
            get { return _flag; }
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
