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


namespace restaurant
{
       
    public partial class frmlogin : Form
    {
        UserDAL dalU = new UserDAL();
        User user = new User();
        string date = "";
        DateTime d1;
        public frmlogin()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
List<User> userList=dalU.LoadUserListWithUserNameAndPassword(txtUserName.Text,txtNewPass.Text);

            if (userList.Count != 0)
            {
                StaticUnitID.Admin = userList[0].Admin;
                StaticUnitID.UserName = userList[0].UserName;
                if(userList[0].SequrityStr!="")
                StaticUnitID.SequrityStr = Convert.ToInt32(userList[0].SequrityStr);
                StaticUnitID.Question = userList[0].Question;
                StaticUnitID.Answer = userList[0].Answer;
                d1 = DateTime.Now.Date;
                DialogResult dlr = MessageBox.Show("  " + d1 + " آیا تاریخ سیستم صحیح است " + "؟", "پرسش", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dlr == DialogResult.No)
                {
                    // I DONT KNOW
                   // this.Hide();
                    //frmCheckTime frmdate = new frmCheckTime();
                    //frmdate.Show();
                }
                else
                {
                    // I DONT KNOW
                    this.Hide();
                    main tree = new main();
                  //  string SequrityStr = userList[0].SequrityStr;
                    //string Tower = SequrityStr.Substring(0, 1);
                   // if (Tower == "0")
                        //tree.mnuBuild.Enabled = false;
                   // string Control = SequrityStr.Substring(1, 1);
                   // if (Control == "0")
                      //  tree.mnuControls.Enabled = false;
                   // string Accounting = SequrityStr.Substring(2, 1);
                   // if (Accounting == "0")
                       // tree.mnuAccounts.Enabled = false;
                   // else
                   // {
                       // string DocumentsDebt = SequrityStr.Substring(3, 1);
                       // if (DocumentsDebt == "0")
                       //     tree.mnuDebt.Enabled = false;
                       // string DocumentGet = SequrityStr.Substring(4, 1);
                       // if(DocumentGet=="0")
                        //    tree.mnuGet.Enabled=false;
                       // string DocumentPay = SequrityStr.Substring(5, 1);
                       // if (DocumentPay == "0")
                         //    tree.mnuPay.Enabled = false;
                  //  }
                    tree.Show();
                }
            }
            else
                MessageBox.Show("این کاربر وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
