using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class StudentInfo
    {

        public StudentInfo()
        { }
        #region Model
        private Nullable<int> _lsh;   //流水号
        private string _sno;//学号
        private string _sname;//姓名
        private string _bj; //班级编号
        private string _classname; //班级名称
        private string _schoolno;   //学校编号
        private string _schoolname;   //学校名称
        private string _xb; //性别
        private string _lxdh;//联系电话
        private string _zppath;//图片路径
        private string _sfzh;   //身份证号
        private string _jtzz;//家庭地址
        private string _bz;//备注
        private string _spwd;//密码
        private DateTime? _djsj = DateTime.Now; //添加时间
        private string _jlzt = "0";     //记录状态 0，未删除 9，已删除
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
        public string SNO
        {
            set { _sno = value; }
            get { return _sno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SNAME
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SCHOOLNO
        {
            get { return _schoolno; }
            set { _schoolno = value; }
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
        public string BJ
        {
            set { _bj = value; }
            get { return _bj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CLASSNAME
        {
            set { _classname = value; }
            get { return _classname; }
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
        public string LXDH
        {
            set { _lxdh = value; }
            get { return _lxdh; }
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
        public string SFZH
        {
            set { _sfzh = value; }
            get { return _sfzh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JTZZ
        {
            set { _jtzz = value; }
            get { return _jtzz; }
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
        public string SPWD
        {
            set { _spwd = value; }
            get { return _spwd; }
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
