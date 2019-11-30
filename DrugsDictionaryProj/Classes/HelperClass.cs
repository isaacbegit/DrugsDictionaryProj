using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class HelperClass
    {

    //Importing Data From SQL Server--> Save it to SQlite database

    public static string  Imprting_Data()
    {

        string connString = @"Data Source="+@"DELL-ISAACBE\SQLEXPRESS2017" +"; Initial Catalog=Drugs_DB"+
                   "; Persist Security Info=True;MultipleActiveResultSets=true;User ID=admin;Password=admin";

        DataTable _dt = new DataTable();


        _dt.Columns.Add("DrugArName");
        _dt.Columns.Add("DrugEnName");
        _dt.Columns.Add("DrugID");
        _dt.Columns.Add("ParentDrugArName");
        _dt.Columns.Add("ParentDrugEnName");


       
        string query = "select  DrugArName,"+
      "DrugEnName,"+
      "DrugID,"+
      "ParentDrugArName,"+
      "ParentDrugEnName  from tblDrugBrandNames";

        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();

        // create data adapter
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        // this will query your database and return the result to your datatable
        da.Fill(_dt);
        conn.Close();
        da.Dispose();
        return _dt.Rows.Count.ToString();


    }

    }

