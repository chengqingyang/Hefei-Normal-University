using System;
using System.Collections.Generic;

using System.Text;

namespace System.Model
{
    [Serializable]
    public class RoleInfo
    {
        private Nullable<int> lsh = null;//流水号
        private string rolename = string.Empty;//角色名称
        private string roledemo = string.Empty;//角色描述

        public RoleInfo() { }

        public RoleInfo(
            Nullable<int> lsh,
            string rolename,
            string roledemo
            )
        {
            this.lsh = lsh;
            this.rolename = rolename;
            this.roledemo = roledemo;
        }

        public Nullable<int> Lsh
        {
            get { return lsh; }
            set { lsh = value; }
        }

        public string Rolename
        {
            get { return rolename; }
            set { rolename = value; }
        }

        public string Roledemo
        {
            get { return roledemo; }
            set { roledemo = value; }
        }
    }
}
