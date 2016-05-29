using System;
using System.Collections.Generic;
using System.Text;

namespace System.Model
{
    [Serializable]
    public class UserInfo
    {
        #region Model
        private Nullable<int> _lsh;
        private string _loginname;
        private string _loginpwd;
        private int? _rolecode;
        private string _truename;
        private string _connphone;
        private string _cardid;
        private string _address;
        private string _userstate;
        private DateTime? _lastlogin = DateTime.Now;
        private string _jlzt = "0";
        private string _schoolname;
        private string _schoolno;
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
        public string LOGINNAME
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LOGINPWD
        {
            set { _loginpwd = value; }
            get { return _loginpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ROLECODE
        {
            set { _rolecode = value; }
            get { return _rolecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TRUENAME
        {
            set { _truename = value; }
            get { return _truename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CONNPHONE
        {
            set { _connphone = value; }
            get { return _connphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CARDID
        {
            set { _cardid = value; }
            get { return _cardid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ADDRESS
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string USERSTATE
        {
            set { _userstate = value; }
            get { return _userstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LASTLOGIN
        {
            set { _lastlogin = value; }
            get { return _lastlogin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JLZT
        {
            set { _jlzt = value; }
            get { return _jlzt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SCHOOLNAME
        {
            set { _schoolname = value; }
            get { return _schoolname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SCHOOLNO
        {
            set { _schoolno = value; }
            get { return _schoolno; }
        }
        #endregion Model
    }
}
