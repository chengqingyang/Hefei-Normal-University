using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class TeacherInfo
    {

        public TeacherInfo()
        { }
        #region Model
        private Nullable<int> _lsh;       //流水号
        private string _tgh;    //教工号
        private string _tname;  //教师名
        private string _tpwd;   //教师密码
        private Nullable<DateTime> _csrq;//出生日期
        private string _sfzh;   //身份证号
        private string _xb;     //性别
        private string _zc;     //职称
        private string _zppath; //照片路径
        private string _zjkc;   //主教课程
        private string _lxdh;   //联系电话
        private string _bz;     //备注
        private string _schoolno;   //所在学校编号
        private string _schoolname;   //学校名称
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
        public string TGH
        {
            set { _tgh = value; }
            get { return _tgh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TNAME
        {
            set { _tname = value; }
            get { return _tname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TPWD
        {
            set { _tpwd = value; }
            get { return _tpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Nullable<DateTime> CSRQ
        {
            set { _csrq = value; }
            get { return _csrq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SFZH
        {
            set { _sfzh = value; }
            get { return _sfzh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XB
        {
            set { _xb = value; }
            get { return _xb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZC
        {
            set { _zc = value; }
            get { return _zc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZPPATH
        {
            set { _zppath = value; }
            get { return _zppath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZJKC
        {
            set { _zjkc = value; }
            get { return _zjkc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LXDH
        {
            set { _lxdh = value; }
            get { return _lxdh; }
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
            get { return _schoolname; }
            set { _schoolname = value; }
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
