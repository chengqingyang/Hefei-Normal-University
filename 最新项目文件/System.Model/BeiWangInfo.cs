using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class BeiWangInfo
    {
        public BeiWangInfo()
        { }
        #region Model
        private Nullable<int> _lsh;     //流水号
        private string _bwno;           //备忘号
        private string _cjz;            //创建者
        private string _title;          //备忘标题
        private string _bwzw;           //备忘正文
        private string _bwsj;           //备忘时间（提醒时间）
        private string _type;           //备忘类型(教师0，家长1)
        private DateTime? _djsj = DateTime.Now;  //登记时间
        private string _jlzt = "0";     //记录状态
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
        public string BWNO
        {
            set { _bwno = value; }
            get { return _bwno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CJZ
        {
            set { _cjz = value; }
            get { return _cjz; }
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
        public string BWZW
        {
            set { _bwzw = value; }
            get { return _bwzw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BWSJ
        {
            set { _bwsj = value; }
            get { return _bwsj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TYPE
        {
            set { _type = value; }
            get { return _type; }
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
