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
    public partial class FormLogin : Form
    {
        List<string> listJobTitle = new List<string>();
        string jobTitle;
        string myDBConnectionString = "";
        string userTitle = "";
        string user = "";
        string psw = "";
        bool formOrder;
        bool formManager;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mydb";
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();

            listJobTitle.Add("會員");
            listJobTitle.Add("管理者");
            

            foreach (string items in listJobTitle)
            {
                combUser.Items.Add(items);
            }
            combUser.SelectedIndex = 0; //預選
        }



        private void login_Click(object sender, EventArgs e)
        {
            if(txtUser.Text!=""|| txtPsw.Text != "")
            {
                formOrder = false;
                formManager = false;
                SqlConnection conn = new SqlConnection(myDBConnectionString);
                conn.Open();
                if (jobTitle == "會員")
                {
                    string strSQL = "select telephone,psw from member";
                    SqlCommand comm = new SqlCommand(strSQL, conn);
                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())//從資料庫讀取使用者資訊
                    {
                        user = reader["telephone"].ToString();
                        psw = reader["psw"].ToString();
                        if (user.Trim() == txtUser.Text && psw.Trim() == txtPsw.Text)
                        {
                            formOrder = true;
                        }
                    }
                    reader.Close();//查詢關閉
                    conn.Close();//連線關閉
                }

                else if (jobTitle == "管理者")
                {

                    string strSQL = "select jobTitle,userId,psw from manager";
                    SqlCommand comm = new SqlCommand(strSQL, conn);
                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())//從資料庫讀取使用者資訊
                    {

                        userTitle = reader["jobTitle"].ToString();
                        user = reader["userID"].ToString();
                        psw = reader["psw"].ToString();
                        if (user.Trim() == txtUser.Text && psw.Trim() == txtPsw.Text)
                        {
                            formManager = true;
                        }
                    }
                    reader.Close();//查詢關閉
                    conn.Close();//連線關閉

                }

                if (formOrder == true)
                {
                    Globalvar.tel = txtUser.Text;
                    FormOrder order = new FormOrder();
                    order.Show();
                    this.Hide();
                }

                else if (formManager == true)
                {
                    FormManager manager = new FormManager();
                    manager.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("帳號、密碼錯誤!!", "錯誤");
                }

            }

            else
            {
                MessageBox.Show("帳號、密碼不能空白!!");
            }


        }

       private void combUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selIndex = combUser.SelectedIndex;
            jobTitle = listJobTitle[selIndex];
            if (jobTitle == "會員")
            {
                register.Visible = true;
            }
            else
            {
                register.Visible = false;              
            }

       }

       private void register_Click(object sender, EventArgs e)
       {
            FormRegister register = new FormRegister();
            register.Show();
            this.Hide();
            
       }

    
    }
}
