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
using System.Collections;
using System.Data.OleDb;
using RKLib.ExportData;
namespace restaurant
{
    public partial class FrmPhoneBook : Form
    {
        DataTable dtpersonList = new DataTable();
        DataTable dtpersonList2 = new DataTable();
        PersonDAL dalP = new PersonDAL();
        Person person = new Person();
        List<Person> personList = new List<Person>();
        Person p = new Person();
        PhoneBookDAL dalp = new PhoneBookDAL();
        PhoneBook phoneBook = new PhoneBook();

        List<PhoneBook> phoneBookList = new List<PhoneBook>();
        public int id = 0;
        int PersonID = 0;
        int userID = 0;
        string date = "";
        string Month = "";
        int Months = 0;
        int days = 0;
        int years = 0;
        int timeout;
        DateTime d1;
        public string t1 = "";

        public FrmPhoneBook()
        {
            InitializeComponent();
            d1 = DateTime.Now.Date;
            Months = DateTime.Now.Month;
            days = DateTime.Now.Day;
            years = DateTime.Now.Year;
            string d2 = d1.ToShortDateString();
            int i = 0;
            if (Months.ToString().Length == 1 && days.ToString().Length == 1)
                for (; i <= 7; i++)
                    t1 = t1 + d2[i];
            else if (Months.ToString().Length == 1 || days.ToString().Length == 1)
                for (; i <= 8; i++)
                    t1 = t1 + d2[i];
            else
                for (; i <= 8; i++)
                    t1 = t1 + d2[i];

            //     txtname.Text = id.ToString();

            date = t1;
        }

        

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            //  Fillnumlastsalary();
            btnOK.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            phoneBook = new PhoneBook();
            phoneBook = LoadControls();
            //Fillnumlastsalary();
            // i=LoadIncreasesalaryListWithPersonID(PersonID, IncreasesalaryID)
            // p = dalP.LoadPersonwithnamefamily(txtname.Text, txtFamily.Text, userID);
            // userID = StaticUnitID.UserID1;
            // PersonID = p.PersonID;
          
                if (phoneBook.Name != "")
                {
                    bool Test = dalp.InsertPhoneBook(phoneBook);
                    if (Test == false)
                        MessageBox.Show("اشکال در ثبت", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (Test == true)
                    {
                        MessageBox.Show("ثبت شد", "تایید", MessageBoxButtons.OK);
                        btnEdit.Enabled = false;
                        btnCancel.Enabled = false;
                        btnOK.Enabled = false;
                        Clear();
                        LoadUC();
                    }
                }
                else
                {
                    MessageBox.Show("لطفاً تمامی فیلدها را کامل نمائید");
                }
         
        }
        private void FillControl(PhoneBook phoneBook)
        {
            id = phoneBook.PhoneBookID;
            PersonID = phoneBook.PersonID;
            txtname.Text = phoneBook.Name.Trim();
            txtTel.Text = phoneBook.Tel;
            txtDesc.Text = phoneBook.Desc;
            userID = phoneBook.UserID;
            txtaddress.Text= phoneBook.Address;
        }

        private void Clear()
        {
            //  PersonID = increasesalary.PersonID;
            //  numlastincrease.Value = 0;
            txtaddress.Text = string.Empty;
            txtDesc.Text = string.Empty;
            userID = phoneBook.UserID;
            txtname.Text = string.Empty;
            txtTel.Text = string.Empty;
        }

        private void gridMaker()
        {

            gridIncreasesalary.Columns[0].Visible = false;
            gridIncreasesalary.Columns[1].HeaderText = "اسم";
            gridIncreasesalary.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[1].Width = 50;
            gridIncreasesalary.Columns[2].HeaderText = "هاتف";
            gridIncreasesalary.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[2].Width = 50;
            gridIncreasesalary.Columns[3].HeaderText = "عنوان";
            gridIncreasesalary.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[3].Width = 50;
           
            gridIncreasesalary.Columns[4].Visible = false;
            gridIncreasesalary.Columns[5].Visible = false;
            gridIncreasesalary.Columns[6].Visible = false;


        }

        private void LoadUC()
        {
            dtpersonList = dalp.LoadPhoneBookList(userID);
            gridIncreasesalary.DataSource = dtpersonList;
            gridMaker();
            // userID = StaticUnitID.UserID1;
        }
        private PhoneBook LoadControls()
        {

            if (phoneBook == null)
                phoneBook = new PhoneBook();
            phoneBook.PhoneBookID = id;
            phoneBook.PersonID = PersonID;
            phoneBook.Tel = txtTel.Text.Trim();
            phoneBook.Address = txtaddress.Text.Trim();
            phoneBook.Name = txtname.Text.Trim();
            phoneBook.Desc = txtDesc.Text.Trim();
            phoneBook.UserID = userID;


            return phoneBook;
        }

        private void gridIncreasesalary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clear();
            string q = "";
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[0].Value.ToString());
                txtname.Text = gridIncreasesalary.CurrentRow.Cells[1].Value.ToString().Trim();
                txtTel.Text = gridIncreasesalary.CurrentRow.Cells[2].Value.ToString().Trim();
                txtaddress.Text = gridIncreasesalary.CurrentRow.Cells[3].Value.ToString();
                txtDesc.Text = gridIncreasesalary.CurrentRow.Cells[4].Value.ToString();
                userID = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[5].Value.ToString());
                btnEdit.Enabled = true;
                btnCancel.Enabled = true;
                btnOK.Enabled = false;
            }
        }
       
        private void btnEdit_Click(object sender, EventArgs e)
        {
            phoneBook = LoadControls();
            if (phoneBook != null)
            {
                dalp.EditPhoneBook(phoneBook);
                MessageBox.Show("ویرایش شد");
                btnEdit.Enabled = false;
                btnCancel.Enabled = false;
                btnOK.Enabled = false;
                Clear();
                LoadUC();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            phoneBook = LoadControls();
            if (phoneBook.PhoneBookID == 0)
                MessageBox.Show("رکوردی برای حذف شدن وجود ندارد");
            else
            {
                DialogResult dlr;
                dlr = MessageBox.Show("آیا شرکت مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (phoneBook != null)
                    {
                        dalp.DeletePhoneBook(phoneBook.PhoneBookID, userID);
                        MessageBox.Show("حذف شد");
                        btnEdit.Enabled = false;
                        btnCancel.Enabled = false;
                        btnOK.Enabled = false;
                        Clear();
                        LoadUC();
                    }
                }
            }
        }

        private void FrmPhoneBook_Load(object sender, EventArgs e)
        {
            LoadUC();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            // Export all the details
           try
            {
                DataTable dtpersonListe = dalp.LoadPhoneBookListFORExcel(userID);
                RKLib.ExportData.Export objExport = new RKLib.ExportData.Export("Win");
                objExport.ExportDetails(dtpersonListe, Export.ExportFormat.Excel, "D:\\PhoneBookInfo.xls");
                //txtnumber.Text = "گزارشگيري در مسير D:\\EmployeesInfo.xls با موفقيت انجام شد";
                  label3.Text = "گزارشگيري D:\\PhoneBookInfo.xls با موفقيت انجام شد";
            }
            catch (Exception Ex)
            {
                label3.Text = "گزارشگيري انجام نشد";
            }

        }
    }
}
