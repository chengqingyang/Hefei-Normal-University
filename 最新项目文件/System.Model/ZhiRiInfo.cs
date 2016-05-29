using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class ZhiRiInfo
    {
        public ZhiRiInfo()
        { }
        #region Model
        private Nullable<int> _lsh;       //流水号
        private string _wno;    //周编号(第几周)
        private string _tgh;    //教工号
        private string _mon;    //星期一
        private string _tue;    //星期二
        private string _wed;    //星期三
        private string _thu;    //星期四
        private string _fri;    //星期五
        private string _zrnr;   //值日内容
        private string _classno;    //班级编号
        private string _schoolno;   //学校编号
        private string _xnno;       //学年编号
        private string _xqno;       //学期编号
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
        public string WNO
        {
            set { _wno = value; }
            get { return _wno; }
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
        public string MON
        {
            set { _mon = value; }
            get { return _mon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TUE
        {
            set { _tue = value; }
            get { return _tue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WED
        {
            set { _wed = value; }
            get { return _wed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string THU
        {
            set { _thu = value; }
            get { return _thu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FRI
        {
            set { _fri = value; }
            get { return _fri; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZRNR
        {
            set { _zrnr = value; }
            get { return _zrnr; }
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