using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class ZiLiaoInfo
    {
        public ZiLiaoInfo()
        { }
        #region Model
        private Nullable<int> _lsh;     //流水号
        private string _zlno;           //资料编号
        private string _scz;            //上传者（学号/教工号）
        private string _cid;            //课程号(课程名)
        private string _zlpath;         //资料保存路径
        private string _zlname;         //资料名
        private string _flag;           //标明是老师还是学生上传的资料
        private string _scsj;           //上传时间
        private string _state;          //是否可见
        private int? _xzcs = 0;           //下载次数
        private DateTime? _djsj = DateTime.Now;  //登记时间
        private string _jlzt = "0";       //记录状态--标记删除
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
        public string ZLNO
        {
            set { _zlno = value; }
            get { return _zlno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SCZ
        {
            set { _scz = value; }
            get { return _scz; }
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
        public string ZLPATH
        {
            set { _zlpath = value; }
            get { return _zlpath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZLNAME
        {
            set { _zlname = value; }
            get { return _zlname; }
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
        public string SCSJ
        {
            set { _scsj = value; }
            get { return _scsj; }
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
        public int? XZCS
        {
            set { _xzcs = value; }
            get { return _xzcs; }
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
