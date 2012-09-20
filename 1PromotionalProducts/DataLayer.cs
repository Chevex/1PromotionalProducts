using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.IO;

public class DataLayer
{
    SqlConnection sConnection = new SqlConnection("Data Source=ChevDB.db.2643546.hostedresource.com; Initial Catalog=ChevDB; User ID=ChevDB; Password='Ch3vyF0rd!'");

    public DataLayer()
    {
        if (HttpContext.Current.Server.MachineName == "CHEVDESKTOP")
        {
            sConnection = new SqlConnection(@"Data Source=CHEVDESKTOP\SQLEXPRESS;Initial Catalog=ChevDB;Integrated Security=True");
        }
        else
        {
            sConnection = new SqlConnection("Data Source=ChevDB.db.2643546.hostedresource.com; Initial Catalog=ChevDB; User ID=ChevDB; Password='Ch3vyF0rd!'");
        }
    }

    public void CloseConn()
    {
        try { sConnection.Close(); }
        catch { }
    }

    #region -= BLOGS TABLE =-

    public int AddPost(DateTime dtDate, string sTitle, string sBody)
    {
        sTitle = sTitle.Replace("'", "''");
        sBody = sBody.Replace("'", "''");
        SqlCommand scomm2 = new SqlCommand("INSERT INTO [1ppBlogs] VALUES ('" + dtDate.ToString() + "','" + sTitle + "','" + sBody + "')", sConnection);
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm2.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeletePost(int iBlogID)
    {
        SqlCommand scomm2 = new SqlCommand("DELETE FROM [1ppBlogs] WHERE BlogID='" + iBlogID.ToString() + "'", sConnection);
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm2.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int UpdatePost(int iBlogID, string sTitle, string sBody)
    {
        sTitle = sTitle.Replace("'", "''");
        sBody = sBody.Replace("'", "''");
        SqlCommand scomm = new SqlCommand("UPDATE [1ppBlogs] SET Title='" + sTitle + "', Body='" + sBody + "' WHERE BlogID='" + iBlogID.ToString() + "'", sConnection);
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetPostsBy_Page(int iPageNumber)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT TOP 5 * FROM [1ppBlogs] WHERE BlogID NOT IN (SELECT TOP (" + iPageNumber.ToString() + "*5) BlogID FROM [1ppBlogs] ORDER BY Date DESC) ORDER BY Date DESC", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public DataTable GetPost(int iBlogID)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [1ppBlogs] WHERE BlogID='" + iBlogID.ToString() + "'", sConnection);
        sda.Fill(dt);
        return dt;
    }

    public int GetPostCount()
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*)AS 'Post Count' FROM [1ppBlogs]", sConnection);
        sda.Fill(dt);
        return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
    }


    #endregion

    #region -= COMMENTS TABLE =-

    public int AddComment(string sName, int iBlogID, DateTime dtDate, string sWebsite, string sBody)
    {
        sWebsite = sWebsite.Replace("'", "''");
        sBody = sBody.Replace("'", "''");
        SqlCommand scomm2 = new SqlCommand("INSERT INTO [1ppComments] VALUES ('" + iBlogID.ToString() + "','" + sName + "','" + dtDate.ToString() + "','" + sWebsite + "','" + sBody + "')", sConnection);
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm2.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public int DeleteComment(int iCommentID)
    {
        SqlCommand scomm2 = new SqlCommand("DELETE FROM [1ppComments] WHERE CommentID='" + iCommentID.ToString() + "'", sConnection);
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm2.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }

    public DataTable GetComments(int iBlogID)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter("select * from [1ppComments] where BlogID='" + iBlogID.ToString() + "'", sConnection);
        sda.Fill(dt);
        return dt;
    }

    #endregion

    public DataSet CustomSelectQuery(string sQuery)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter(sQuery, sConnection);
        sda.Fill(ds);
        return ds;
    }

    public int CustomInputQuery(string sQuery)
    {
        SqlCommand scomm = new SqlCommand(sQuery, sConnection);
        try { sConnection.Open(); }
        catch { }
        int iRowsAffected = scomm.ExecuteNonQuery();
        try { sConnection.Close(); }
        catch { }
        return iRowsAffected;
    }
}
