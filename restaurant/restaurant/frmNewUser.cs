using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using restaurant.DAL;
using restaurant.COMMON;



using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using restaurant.COMMON;
using restaurant.DAL;


namespace restaurant
{
    public partial class frmChangePass : Form
    {
        public frmChangePass()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
          
        }

        private void btnPreok_Click(object sender, EventArgs e)
        {
            if (txt1.Text == "" && txt2.Text == "" && txt3.Text == "")
                MessageBox.Show("n", "Error", MessageBoxButtons.OK);

            else
            {

                txtNewUserName.Enabled = true;
                txtNewPassword.Enabled = true;
                txtNewDesc.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            btn.Visible = true;
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
           // SqlConnection cn = new SqlConnection("server=(local);database=restaurant;User ID=sa; Password=123");
           // SqlCommand cmd;
            
        
            //Int32 LastID = 0;
            //try
            //{
          //  string SqlStr = "Insert into test " +
          //                    " (name)" +
          //                    " VALUES (@name)" +
           //                    "SELECT SCOPE_IDENTITY() AS LastID";
            //if (cn.State == ConnectionState.Closed)
            //    cn.Open();
            //cmd = new SqlCommand(SqlStr, cn);
            //User User = new User();
            //cmd.Parameters.AddWithValue("@name", txtPreUserName.Text);
           
           // SqlDataReader Dr;
            //Dr = cmd.ExecuteReader();
            //Dr.Read();
          //  if (Dr.HasRows)
           //     LastID = Convert.ToInt32(Dr.GetValue(0));
          //  Dr.Close();
           // cn.Close();
           
            //}
            //catch { return 0; }
        






            panel1.Visible = true;
            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            btn.Visible = true;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string sequritystr = txt1.Text + txt2.Text + txt3.Text;
            //MessageBox.Show(sequritystr, "tt", MessageBoxButtons.OKCancel);

            panel1.Visible = false;
            txt1.Visible = false;
            txt2.Visible = false;
            txt3.Visible = false;
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            btn.Visible = false;
        }

        private void Clear()
        {
            txtPreUserName.Text = string.Empty;
            txtPrePassword.Text = string.Empty;
            txtPreDesc.Text = string.Empty;
            txtNewUserName.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtNewDesc.Text = string.Empty;
        }


    }
}
