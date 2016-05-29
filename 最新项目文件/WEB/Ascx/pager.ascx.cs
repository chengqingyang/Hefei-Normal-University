using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


/// <summary>
/// 分页控件绑定委托
/// </summary>
/// <param name="pager$pageindex">当前页码</param>
/// <param name="pageSize">每页显示行数</param>
/// <param name="pageIndex">当前页码</param>
/// <param name="pageRow">当前页显示行数</param>
public delegate void PagerDelegate(int pageSize, int pageIndex);

public partial class Page_pager : System.Web.UI.UserControl
{

    /// <summary>
    /// 当前页码
    /// </summary>
    private int _pageIndex = -1;

    /// <summary>
    /// 记录条数
    /// </summary>
    private int _recordCount = -1;

    /// <summary>
    /// 每页显示记录数


    /// </summary>
    private int _pageSize = 15;

    /// <summary>
    /// 分页控件绑定委托
    /// </summary>
    public PagerDelegate OnPagerDataBind;

    /// <summary>
    /// 当前页码
    /// </summary>
    public int PageIndex
    {
        get
        {
            if (_pageIndex == -1)
            {
                _pageIndex = Convert.ToInt32(Request.Form["pager$pageindex"]);
            }
            return _pageIndex;
        }
        set
        {
            if (value < 1)
                throw new Exception("当前页码必须大于零!");

            _pageIndex = value;
        }
    }

    /// <summary>
    /// 新加分页页码
    /// </summary>
    protected int currentpage1;
    public int CurrentPage1
    {
        set { currentpage1 = value; }
        get { return currentpage1; }
    }

    /// <summary>
    /// 记录条数
    /// </summary>
    public int RecordCount
    {
        get
        {
            if (_recordCount == -1)
            {
                _recordCount = Convert.ToInt32(Request.Form["pager$recordcount"]);
            }
            return _recordCount;
        }
        set
        {
            if (value < 0)
                throw new Exception("记录条数不能小于零!");

            _recordCount = value;
        }
    }

    /// <summary>
    /// 每页显示记录数


    /// </summary>
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            if (value <= 0)
                throw new Exception("每页显示行数不能小于零!");

            _pageSize = value;
        }
    }

    /// <summary>
    /// 总页数
    /// </summary>
    public int PageCount
    {
        get
        {
            if (RecordCount == -1)
                throw new Exception("记录条数没有设置, 不能计算总页数!");

            if (RecordCount == 0)
                return 1;

            int pageCount = RecordCount / PageSize;

            if (RecordCount % PageSize > 0)
            {
                pageCount++;
            }

            return pageCount;
        }
    }

    /// <summary>
    /// 设置分页控件状态


    /// </summary>
    /// <param name="pager$pageindex">页码</param>
    public void SetPageIndex(int pageIndex)
    {
        int pageCount = PageCount;

        if (pageIndex > pageCount)
        {
            pageIndex = pageCount;
        }
        else if (pageIndex < 1)
        {
            pageIndex = 1;
        }

        if (pageIndex == 1)
        {
            lb_first.Enabled = false;
            lb_pre.Enabled = false;
        }
        else {
            lb_first.Enabled = true;
            lb_pre.Enabled = true;
        }

        if (pageIndex == pageCount)
        {
            lb_next.Enabled = false;
            lb_last.Enabled = false;
        }
        else {
            lb_next.Enabled = true;
            lb_last.Enabled = true;
        }

        lbl_records.Text = RecordCount.ToString();
        lbl_pages.Text = string.Format("{0}/{1}", pageIndex, pageCount);

        PageIndex = pageIndex;
    }

    public void PagerDataBind()
    {
        if (OnPagerDataBind != null)
        {
            OnPagerDataBind(PageSize, PageIndex);
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        Page.ClientScript.RegisterHiddenField("pager$pageindex", PageIndex.ToString());
        Page.ClientScript.RegisterHiddenField("pager$recordcount", RecordCount.ToString());
        currentpage1 = PageIndex;
    }

    protected void lb_first_Click(object sender, EventArgs e)
    {
        SetPageIndex(1);
        PagerDataBind();
    }

    protected void lb_pre_Click(object sender, EventArgs e)
    {
        SetPageIndex(PageIndex - 1);
        PagerDataBind();
    }

    protected void lb_next_Click(object sender, EventArgs e)
    {
        SetPageIndex(PageIndex + 1);
        PagerDataBind();
    }

    protected void lb_last_Click(object sender, EventArgs e)
    {
        SetPageIndex(PageCount);
        PagerDataBind();
    }



    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        PageIndex = int.Parse(this.txtPage.Value);
        SetPageIndex(PageIndex);
        PagerDataBind();
    }
}
