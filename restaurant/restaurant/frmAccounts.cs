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
    public partial class frmAccounts : Form
    {
        restaurant.COMMON.Account  account = new Account();
        AccountDAL dalA = new AccountDAL();
        DetailInfoDAL dalD = new DetailInfoDAL();
        //DAL.DAL dal = new DAL.DAL();

        int userID = 0;
        int id = 0;
        string date = "";
        public frmAccounts()
        {
            InitializeComponent();
        }
        private void LoadUC()
        
{
            //List<Car> carList = new List<Car>();
            //List<Unit> unitList = new List<Unit>();
            DataTable dtcarList = dalA.LoadAccountList(userID);
            gridAccount.DataSource = dtcarList;
            gridMaker();

            userID = StaticUnitID.UserID1;

            DataTable dtDetailInfo = dalD.LoadDetailInfoForGrid(12);
            comBankName.DataSource = dtDetailInfo;
            comBankName.DisplayMember = "DetailInfoTitle";
            comBankName.ValueMember = "DetailInfoID";
            comBankName.SelectedIndex = -1;

            DataTable dtDetailInfo1 = dalD.LoadDetailInfoForGrid(13);
            comAccountType.DataSource = dtDetailInfo1;
            comAccountType.DisplayMember = "DetailInfoTitle";
            comAccountType.ValueMember = "DetailInfoID";
            comAccountType.SelectedIndex = -1;
        }

        private void Clear()
        {
            txtAccountNum.Text = "";
            comBankName.SelectedValue = -1;
            comAccountType.SelectedValue = -2;
            txtName.Text = "";
            numCodePart.Value = 0;
            txtDesc.Text = "";
        }

        private Account LoadControls()
        {
            if (account == null)
                account = new Account();
            account.AccountID = id;
            account.AccountNum = txtAccountNum.Text;
            account.BankName = Convert.ToInt32(comBankName.SelectedValue);
            account.AccountType = Convert.ToInt32(comAccountType.SelectedValue);
            account.CodePart = Convert.ToInt32(numCodePart.Value);
            account.NamePart = txtName.Text;
            account.Description = txtDesc.Text;
            account.UserID = userID;
            account.Date = date;
            return account;
        }

        private void FillControl(Account account)
        {
            id = account.AccountID;
            txtAccountNum.Text = account.AccountNum;
            comBankName.SelectedValue = gridAccount.CurrentRow.Cells[7].Value.ToString();
            comAccountType.SelectedValue = gridAccount.CurrentRow.Cells[8].Value.ToString();
            numCodePart.Value = Convert.ToDecimal(account.CodePart);
            txtName.Text = account.NamePart;
            txtDesc.Text = account.Description;
            userID = account.UserID;
            date = account.Date;
        }

        void gridMaker()
        {
            gridAccount.Columns[0].Visible = false;
            gridAccount.Columns[1].HeaderText = "شماره حساب";
            gridAccount.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridAccount.Columns[2].HeaderText = "نام بانک";
            gridAccount.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gridAccount.Columns[3].HeaderText = "نوع حساب";
            //gridAccount.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           
            gridAccount.Columns[3].HeaderText = "کد شعبه";
            gridAccount.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridAccount.Columns[4].HeaderText = "نام شعبه";
            gridAccount.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridAccount.Columns[5].Visible = false;
            gridAccount.Columns[6].HeaderText = "تاریخ ثبت";
            gridAccount.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridAccount.Columns[7].Visible = false;
            gridAccount.Columns[8].Visible = false;
            gridAccount.Columns[9].Visible = false;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            account = new Account();
           account =   LoadControls();
            if (account.AccountNum != "" && account.BankName != 0)
            {
               int Test = dalA.InsertAccount(account);
         
                if (Test == 0)
                    MessageBox.Show("اشکال در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
               {
                    MessageBox.Show("ثبت شد", "تایید", MessageBoxButtons.OK);
                    btnOK.Enabled = false;
                    btnCancel.Enabled = false;
                    btnEdit.Enabled = false;
                    Clear();
                    LoadUC();
               }
            }
            else
            {
                MessageBox.Show("لطفاً تمامی فیلدها را کامل نمائید");
            }
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            LoadUC();
        }
    }
}
