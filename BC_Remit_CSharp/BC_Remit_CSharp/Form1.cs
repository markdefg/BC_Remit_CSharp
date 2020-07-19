using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BC_Remit_CSharp.DB;
using MySql.Data.MySqlClient;

namespace BC_Remit_CSharp
{
    public partial class Form1 : Form
    {
        CRUD crud = new CRUD();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            CREATE();
            READ();


        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            UPDATE();
            READ();

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DELETE();
            READ();
        }

        public void READ()
        {
            dataGridView1.DataSource = null;
            crud.Read_contacts();
            dataGridView1.DataSource = crud.dt;

        }

        public void CREATE()
        {
            crud.name = txt_name.Text;
            crud.email = txt_email.Text;
            crud.mobile_no = txt_mobile.Text;

            crud.Create_contact();


        }

        public void UPDATE()
        {
            crud.name = utxt_name.Text;
            crud.email = utxt_email.Text;
            crud.mobile_no = utxt_mobile.Text;
            crud.id = txt_id.Text;

            crud.Update_contact();
        }

        public void DELETE()
        {
            crud.id = txt_id.Text;
            crud.Delete_contact();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    txt_id.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    utxt_name.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    utxt_email.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    utxt_mobile.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Dont click the header!");
            }
        }
    }
}
