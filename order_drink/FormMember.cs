using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace order_drink
{
    public partial class FormMember : Form
    {
        string myDBConnectionString = "";
        string sex;
        FormManager manager;
        public FormMember()
        {
            InitializeComponent();
        }

        public FormMember(FormManager FM)
        {
            InitializeComponent();
            this.manager = FM;
        }

        private void FormMember_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
        }
       
        void showRefresh()
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select *from member ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            manager.dataGridView1.DataSource = dt;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                DialogResult result = MessageBox.Show("確定要修改?", "修改資料", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(myDBConnectionString);
                    con.Open();
                    if (radButtMan.Checked == true)
                    {
                        sex = "男";
                    }
                    else
                    {
                        sex = "女";
                    }
                    string strSQL = "update member set telephone ='" + txtPhone.Text + "',email='" +
                        txtEmail.Text + "',sex='" + sex + "' where ID= '" + txtID.Text + "'";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("修改成功!!");
                    con.Close();
                    showRefresh();
                    this.Close();
                }
               
            }
            else
            {
                MessageBox.Show("空白資料不能修改!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要刪除?", "刪除資料", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "delete from member where ID = '" + txtID.Text + "'";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("刪除成功!!");
                con.Close();
                showRefresh();
                this.Close();
            }
          
        }

    
    }
}
