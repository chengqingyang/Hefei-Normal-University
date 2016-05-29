using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class TestDetailInfo
    {
        public TestDetailInfo()
        { }
        #region Model
        private Nullable<int> _lsh;       //流水号
        private string _ksno;   //考试编号
        private string _sno;    //学号
        private string _js;     //教室
        private string _zwno;   //座位号
        private string _bz;     //备注
        private string _state;  //考试信息状态--是否可见
        private string _readed = "0"; //是否读过
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
        public string KSNO
        {
            set { _ksno = value; }
            get { return _ksno; }
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
        public string JS
        {
            set { _js = value; }
            get { return _js; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZWNO
        {
            set { _zwno = value; }
            get { return _zwno; }
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
        public string JLZT
        {
            set { _jlzt = value; }
            get { return _jlzt; }
        }
        #endregion Model

    }
}