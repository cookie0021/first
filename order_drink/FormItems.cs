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
    public partial class FormItems : Form
    {
        string myDBConnectionString = ""; 
        FormManager manager;
        public FormItems()
        {
            InitializeComponent();
        }

        public FormItems(FormManager FM)
        {
            InitializeComponent();
            this.manager = FM;
        }
        void showRefresh()
        {
            SqlConnection con = new SqlConnection(myDBConnectionString);
            SqlDataAdapter sda = new SqlDataAdapter("select * from Items", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            manager.dataGridView1.DataSource = dt;
        }


        private void FormItems_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(myDBConnectionString);
            con.Open();
            string strSQL = "insert into Items values(@Name,@LPrice,@botPrice);";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@LPrice", txtLPrice.Text);
            cmd.Parameters.AddWithValue("@botPrice", txtBotPrice.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("新增成功!!");
            showRefresh();
            this.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNO.Text != "")
            {

                DialogResult result = MessageBox.Show("確定要修改?", "修改資料", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(myDBConnectionString);
                    con.Open();

                    string strSQL = "update Items set name=@NewName,LPrice=@LPrice,bottlePrice=@botPrice where Id=@selectNO" ;
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@selectNO", txtNO.Text);
                    cmd.Parameters.AddWithValue("@NewName", txtName.Text);
                    cmd.Parameters.AddWithValue("@LPrice", txtLPrice.Text);
                    cmd.Parameters.AddWithValue("@botPrice", txtBotPrice.Text);            
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("修改成功!!");
                    con.Close();
                    showRefresh();
                    this.Close();
                }
            }
        }
            private void btnDelete_Click(object sender, EventArgs e)
            {
            DialogResult result = MessageBox.Show("確定要刪除?", "刪除資料", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(myDBConnectionString);
                con.Open();
                string strSQL = "delete from Items where NO = '" + txtNO.Text + "'";
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
