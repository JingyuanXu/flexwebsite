using System;//引用System名称空间下的类
using System.Collections.Generic;
using System.Linq;
using System.Web; //引用Web名称空间下的类
using System.Web.Services; //引用Services名称空间下的类
using System.Web.Services.Protocols;//引用Protocols名称空间下的类
using System.Configuration;//引用Data名称空间下的类
using System.Data;
using System.Data.SqlClient;//引用SqlClient名称空间下的类
using System.Collections;//引用Collections名称空间下的类

[WebService(Namespace = "http://tempuri.org/")]//默认的名称空间

[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class WebService : System.Web.Services.WebService
{

    public WebService()                           //默认构造函数
    {

    }

    public class Employee                       //自定义类，用以存储数据
    {

        public string employeeId;

        public string firstName;

        public string lastName;

    }

    [WebMethod]

    [System.Xml.Serialization.XmlInclude(typeof(Employee))]    //声明“Employee”类可写入XML

    public ArrayList GetData()                      //获得数据库数据
    {

        SqlConnection conn = new SqlConnection();  //定义“SqlConnnection”类实例

        //数据库连接字符串
        string ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["use02ConnectionString"].ConnectionString;

        SqlConnection myCon = new SqlConnection(ConStr);//数据库连接 


        conn.ConnectionString = ConStr;
        //定义“SqlCommand”实例，从“Employee”表中取数据

        SqlCommand command = new SqlCommand("select * from Employee", conn);

        conn.Open();                                //打开连接

        SqlDataAdapter da = new SqlDataAdapter();   //定义“SqlDataAdapter”类实例

        //将“command”值传递给“SqlDataAdapter”的“SelectCommand”属性

        da.SelectCommand = command;

        DataSet ds = new DataSet();                 //定义“DataSet”类实例

        da.Fill(ds, "tables");                      //取数据

        ArrayList al = new ArrayList();             //定义“ArrayList”类实例

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)   //将全部数据存储于al变量中
        {

            Employee em = new Employee();               //定义“Employee”类实例

            //添加数据到“al”变量中

            em.employeeId = ds.Tables[0].Rows[i]["employeeId"].ToString().Trim();

            em.firstName = ds.Tables[0].Rows[i]["firstName"].ToString().Trim();

            em.lastName = ds.Tables[0].Rows[i]["lastName"].ToString().Trim();

            al.Add(em);

        }

        conn.Close();                                   //关闭数据库

        return al;

    }

}

