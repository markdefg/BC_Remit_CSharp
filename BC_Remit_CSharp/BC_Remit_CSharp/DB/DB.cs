using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace BC_Remit_CSharp.DB
{
    class DB
    {
        public MySqlConnection con;

        public DB()
        {
            string host = "localhost";
            string db = "bc_remit_c#";
            string port = "3306";
            string user = "root";
            string pass = "";
            string constring = "datasource =" + host + ";database =" + db + ";port =" + port + ";username =" + user + ";password =" + pass + "; SslMode=none";
            con = new MySqlConnection(constring);

        }
    }

    class CRUD:DB
    {
        public string name { set; get; }
        public string email { set; get; }
        public string mobile_no { set; get; }
        public string id { set; get; }



        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        public void Create_contact()
        {
            con.Open();
            using(MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO `contacts`(`name`, `email`, `mobile_no`) VALUES (@name,@email,@mobile_no)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@mobile_no", MySqlDbType.VarChar).Value = mobile_no;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update_contact()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE contacts SET name=@name, email=@email, mobile_no=@mobile_no WHERE id=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@mobile_no", MySqlDbType.VarChar).Value = mobile_no;

                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete_contact()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM contacts WHERE id=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Read_contacts()
        {
            dt.Clear();
            string query = "SELECT * FROM contacts";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query, con);
            MDA.Fill(ds);
            dt = ds.Tables[0];

        }
    }
}
