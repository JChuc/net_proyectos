using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.Services.Protocols;
//using System.Xml.Linq;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
namespace Transaccion
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "posserver")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        //"Data Source=POSSERVERJ\\SQLEXPRESS;Initial Catalog=pixel;Integrated Security=true";
        //string cadenaconexion = "Data Source=POSSERVERJ\\SQLEXPRESS;Initial Catalog=dbPixelHospot;Integrated Security=true";
        //string cadenaconexion = ConfigurationManager.ConnectionStrings["conn"].ToString();

        //Conexion SQL Server 
        SqlConnection sql_conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlCommand obj_command = null;
        SqlDataReader obj_reader = null;
        SqlParameter obj_para = null;

        //conexion ODBC
        //@"Driver=Sybase SQL Anywhere 5.0; DefaultDir=c:\PIXELSQL\;Dbf=c:\PIXELSQL\PIXELSQLBASE.db;start=C:\SQLANY50\WIN32\dbclient.exe -x TCPIP;Uid=reportuser;Pwd=12345;Dsn=;"
        //OdbcConnection ConexODBC = new OdbcConnection(@"dsn=PixelSQLbase;Port=5000;Database=PixelSQLbase;Uid=reportuser;Pwd=12345;PacketSize=512;");
        //String QryODBC;
        //OdbcCommand obj_com;
        //OdbcDataReader obj_reader;
        string consulta = null;
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public void HelloWorld(string nombre)
        {
            //string[] usuario = new string[] { "Hola", "Jorge" };
            usuario user1 = new usuario();
            user1.trans=nombre;
            user1.resultado = "Hola mundo";
            var js = new JavaScriptSerializer();
            this.Context.Response.Clear();
            this.Context.Response.ContentType = "application/json";
            this.Context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            string callback = Context.Request["callback"];
            this.Context.Response.Write(callback +"("+js.Serialize(user1).ToString()+ ")" );

            
        }
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        
        public void transact(string Numtra) {
          //  sql_conexion = new SqlConnection(cadenaconexion);
            usuario U1= new usuario();
            string Trans = Numtra;
            string Res = "";
            string Err = "";
            try
            {
                //conexion sql server
                sql_conexion.Open();
                //string cad = "Conexion exitosa";
                //consulta = "Select Top 1 transact, timeord from posdetail where TRANSACT = " + Numtra.Trim() + " order by timeord DESC";
                obj_command = new SqlCommand("Store_GetValueHospot", sql_conexion);
                obj_command.CommandType = CommandType.StoredProcedure;
                obj_para = obj_command.Parameters.Add("@Transaction", SqlDbType.Int);
                obj_para.Direction = ParameterDirection.Input;
                obj_para.Value = Regex.Replace(Numtra.Trim(), "[^0-9A-Za-z]", "", RegexOptions.None);
                obj_reader = obj_command.ExecuteReader();

                //odbc
                //ConexODBC.Open();
                //QryODBC = "Select * from dba.posdetail where TRANSACT = " + Numtra.Trim();
                //obj_com = new OdbcCommand(QryODBC,ConexODBC);
                //obj_reader = obj_com.ExecuteReader();
                string datos = null;
                while (obj_reader.Read())
                    datos = obj_reader.GetValue(0).ToString();
                    //datos = obj_reader.GetSqlBinary(0).ToString();
                    //datos = obj_reader.GetDateTime(1).ToString();
                obj_reader.Close();
                sql_conexion.Close();
                //ConexODBC.Close();
                Res = datos;
            }
            catch (SqlException e)
            //catch(OdbcException e)
            {
                string error = "No se pudo establecer conexion con la base de datos: "+e.Message.ToString();
                sql_conexion.Close();
                //ConexODBC.Close();
                Err = error;
            }
            finally 
            { 
                if(sql_conexion !=null)
                //if(ConexODBC !=null)
                {
                    sql_conexion.Close();
                    //ConexODBC.Close();
                }
            }

            U1.trans = Trans;
            U1.resultado = Res;
            U1.error = Err;
            var js = new JavaScriptSerializer();
            this.Context.Response.Clear();
            this.Context.Response.ContentType = "application/json";
            this.Context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            string callback = Context.Request["callback"];
            this.Context.Response.Write(callback + "(" + js.Serialize(U1).ToString() + ")");


        }//fin del metodo
        
    }//fin de la clase
}
public class usuario {
    public string trans { get; set; }
    public string resultado { get; set; }
    public string error { get; set; }
}
