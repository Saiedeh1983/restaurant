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
    public partial class frmUsers : Form
    {
          User user = new User();
        List<User> userList = new List<User>();
        UserDAL dalU = new UserDAL();
        DetailInfoDAL dalD = new DetailInfoDAL();
        int id = 0;
        int admin = 0;
        string date="";
        public frmUsers()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            user = LoadControls();
            if (user.UserID == 0)
                MessageBox.Show("رکوردی برای حذف شدن وجود ندارد", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DialogResult dlr;
                dlr = MessageBox.Show("آیا کاربر مورد نظر حذف شود" + "؟", "پرسش", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (user != null)
                    {
                        if (user.Admin == 1)
                        {
                            MessageBox.Show("کاربر اصلی را نمی توان حذف کرد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            admin = 0;
                        }
                        else
                        {
                            dalU.DeleteUser(user.UserID);
                            MessageBox.Show("حذف شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnOK.Enabled = false;
                            btnCancel.Enabled = false;
                            btnEdit.Enabled = false;
                            admin = 0;
                            Clear();
                            LoadUC();
                        }
                    }
                }
            }
        }

        private void gridUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(gridUser.CurrentRow.Cells[0].Value.ToString());
                txtUserName.Text = gridUser.CurrentRow.Cells[1].Value.ToString();
                txNewPass.Text = gridUser.CurrentRow.Cells[2].Value.ToString();
                txNewPass2.Text = gridUser.CurrentRow.Cells[2].Value.ToString();
                comQuestion.Text = gridUser.CurrentRow.Cells[3].Value.ToString();
                txtAnswer.Text = gridUser.CurrentRow.Cells[4].Value.ToString();
                txtDesc.Text = gridUser.CurrentRow.Cells[5].Value.ToString();
                date = gridUser.CurrentRow.Cells[6].Value.ToString();
                admin = Convert.ToInt32(gridUser.CurrentRow.Cells[7].Value.ToString());
                btnEdit.Enabled = true;
                btnCancel.Enabled = true;
                btnOK.Enabled = false;
            }
        }

        void gridMaker()
        {
            gridUser.Columns[0].Visible = false;
            gridUser.Columns[1].HeaderText = "نام کاربر";
            gridUser.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridUser.Columns[2].Visible = false;
            gridUser.Columns[3].Visible = false;
            gridUser.Columns[4].Visible = false;
            gridUser.Columns[5].Visible = false;
            gridUser.Columns[6].HeaderText = "تاریخ ثبت";
            gridUser.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridUser.Columns[7].Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            user = LoadControls();
            if (user != null)
            {
                dalU.EditUser(user);
                MessageBox.Show("ویرایش شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                btnCancel.Enabled = false;
                btnEdit.Enabled = false;
                btnOK.Enabled = false;
                admin = 0;
                LoadUC();
            }
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            LoadUC();
        }

        private void Clear()
        {
            txtUserName.Text = string.Empty;
            txNewPass.Text = string.Empty;
            txNewPass2.Text = string.Empty;
            txtAnswer.Text = string.Empty;
            txtUserName.Text = string.Empty;
            comQuestion.SelectedIndex = -1;
            txtDesc.Text = "";
        }

        private void LoadUC()
        {
            DataTable dtDetailInfo = dalD.LoadDetailInfoForGrid(8);
            comQuestion.DataSource = dtDetailInfo;
            comQuestion.DisplayMember = "DetailInfoTitle";
            comQuestion.ValueMember = "DetailInfoID";
            comQuestion.SelectedIndex = -1;

            DataTable dtuserList = dalU.LoadUserList();
            gridUser.DataSource = dtuserList;
            gridMaker();
        }

        private User LoadControls()
        {
            if (user == null)
                user = new User();
            user.UserID = id;
            user.UserName = txtUserName.Text;
            user.Password = txNewPass.Text;
            DetailInfo detailInfo = dalD.LoadDetailInfoWithTitle(comQuestion.Text);
            user.Question = Convert.ToInt32(detailInfo.DetailInfoID);
            user.Answer = txtAnswer.Text;
            user.Admin = admin;
            user.Desc = txtDesc.Text;
            user.Date = date;
            if (checkTower.Checked == true)
                user.SequrityStr = "1";
            else
                user.SequrityStr = "0";

            if (checkControls.Checked == true)
                user.SequrityStr = user.SequrityStr + "1";
            else
                user.SequrityStr = user.SequrityStr + "0";

            if (checkAccounting.Checked == true)
                user.SequrityStr = user.SequrityStr + "1";
            else
                user.SequrityStr = user.SequrityStr + "0";

            if (checkDocumentsDebt.Checked == true)
                user.SequrityStr = user.SequrityStr + "1";
            else
                user.SequrityStr = user.SequrityStr + "0";

            if (checkDocumentGet.Checked == true)
                user.SequrityStr = user.SequrityStr + "1";
            else
                user.SequrityStr = user.SequrityStr + "0";

            if (checkDocumentPay.Checked == true)
                user.SequrityStr = user.SequrityStr + "1";
            else
                user.SequrityStr = user.SequrityStr + "0";
            return user;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            user = new User();
            user = LoadControls();
            if (user.UserName != "" && user.Password != "" && user.Question != 0 && txtAnswer.Text != "")
            {
                if (txNewPass.Text != txNewPass2.Text)
                    MessageBox.Show("لطفا کلمه عبور را مجددا وارد نمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //User us = dalU.LoadUser(user.UserID);
                    int Test = dalU.InsertUser(user);
                    if (Test == 0)
                        MessageBox.Show("اشکال در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("ثبت شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnCancel.Enabled = false;
                        btnOK.Enabled = false;
                        admin = 0;
                        Clear();
                        LoadUC();
                    }
                }
            }
            else
            {
                MessageBox.Show("لطفاً تمامی فیلدها را کامل نمائید", "تذکر", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (btnEdit.Enabled == false)
            {
                btnOK.Enabled = true;
                Clear();
            }
        }

    }
}
