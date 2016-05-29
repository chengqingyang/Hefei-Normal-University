<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // 在应用程序启动时运行的代码

    }

    void Application_End(object sender, EventArgs e)
    {
        //  在应用程序关闭时运行的代码

    }

    void Application_Error(object sender, EventArgs e)
    {
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e)
    {
        // 在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e)
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。

    }

    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        if (Context.User != null)
        {
            String[] roles ={ "" };
            if (User.Identity.IsAuthenticated) //验证过的一般用户才能进行角色验证  
            {
                string cookName = new comConst().userCookies();
                if (Request.Cookies[cookName] == null || Request.Cookies[cookName].Value == "")
                {
                    string userRoles = "";
                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(new comClass().getConnStr()))
                    {
                        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(string.Format("select roles from users where userCode='{0}'", Context.User.Identity.Name), conn))
                        {
                            conn.Open();
                            userRoles = cmd.ExecuteScalar().ToString();
                            conn.Close();
                        }
                    }

                    FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, Context.User.Identity.Name, DateTime.Now, DateTime.Now.AddMinutes(20), false, userRoles, "/"); //建立身份验证票对象
                    string HashTicket = FormsAuthentication.Encrypt(Ticket); //加密序列化验证票为字符串
                    HttpCookie UserCookie = new HttpCookie(cookName, HashTicket);
                    //生成Cookie
                    UserCookie.Expires = DateTime.Now.AddMinutes(20);
                    Context.Response.Cookies.Add(UserCookie); //输出Cookie
                }
                else
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Context.Request.Cookies[new comConst().userCookies()].Value);
                    ArrayList userRoles = new ArrayList();
                    foreach (String role in ticket.UserData.Split(new char[] { ';' }))
                    {
                        userRoles.Add(role);
                    }
                    roles = (String[])userRoles.ToArray(typeof(String));
                    // 把此用户的角色存到内存中，可以运用User.IsInRole()方法进行检验用户角色
                    // 也可以使用实现IPrincipal接口的类，自定义赋值给Context.User
                    Context.User = new System.Security.Principal.GenericPrincipal(Context.User.Identity, roles);
                }
            }
        }
    }
</script>

