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
    public partial class FrmRent : Form
    {
        DataTable dtpersonList = new DataTable();
        DataTable dtpersonList2 = new DataTable();
        PersonDAL dalP = new PersonDAL();
        Person person = new Person();
        List<Person> personList = new List<Person>();
        Person p = new Person();
        RentDAL dalr = new RentDAL();
        Rent rent = new Rent();
        List<Rent> rentList = new List<Rent>();

        public int id = 0;
        int userID = 0;
        string date = "";
        string Month = "";
        int Months = 0;
        int days = 0;
        int years = 0;
        int timeout;
        DateTime d1;
        public string t1 = "";
        public FrmRent()
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
            txtDate.Text = t1;
            date = t1;
        }

        private void FrmRent_Load(object sender, EventArgs e)
        {
            LoadUC();
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
            rent = new Rent();
            rent = LoadControls();
            //Fillnumlastsalary();
            // i=LoadIncreasesalaryListWithPersonID(PersonID, IncreasesalaryID)
            // p = dalP.LoadPersonwithnamefamily(txtname.Text, txtFamily.Text, userID);
            // userID = StaticUnitID.UserID1;
            // PersonID = p.PersonID;

            if (rent.ContractNumber != "")
                {
                    bool Test = dalr.InsertRent(rent);
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
        private void FillControl(Rent rent)
        {
            id = rent.RentID;
            txtnumber.Text = rent.ContractNumber.Trim();
            numprice.Value = rent.Price;
            comType.Text = rent.Type.Trim();
            txtDate.Text = rent.Date.Trim();
            txtexpireDate.Text = rent.expireDate.Trim();
            txtName.Text = rent.Name.Trim();
            txtFamily.Text = rent.Family.Trim();
            txtAddress.Text = rent.Address.Trim();
            txtDesc.Text = rent.Desc;
            userID = rent.UserID;
           // date = rent.expireDate;
        }

        private void Clear()
        {
            //  PersonID = increasesalary.PersonID;
            //  numlastincrease.Value = 0;
            txtnumber.Text = string.Empty;
            numprice.Value = 0;
            comType.Text = string.Empty;
            txtDate.Text = t1;
            txtexpireDate.Text = string.Empty;
            txtName.Text = string.Empty;
            txtFamily.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDesc.Text = string.Empty;
            userID = rent.UserID;
           
           // date = string.Empty;
        }

        private void gridMaker()
        {         
            gridIncreasesalary.Columns[0].Visible = false;
            gridIncreasesalary.Columns[1].HeaderText = "رقم";
            gridIncreasesalary.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[1].Width = 50;
            gridIncreasesalary.Columns[2].HeaderText = "مبلغ";
            gridIncreasesalary.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[2].Width = 50;
            gridIncreasesalary.Columns[3].HeaderText = "نوع";
            gridIncreasesalary.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[3].Width = 50;
            gridIncreasesalary.Columns[4].HeaderText = "تاریخ العقد";
            gridIncreasesalary.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[4].Width = 50;
            gridIncreasesalary.Columns[5].HeaderText = "تاریخ الانتها";
            gridIncreasesalary.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[5].Width = 50;
            gridIncreasesalary.Columns[6].HeaderText = "الاسم";
            gridIncreasesalary.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[6].Width = 50;
            gridIncreasesalary.Columns[7].HeaderText = "اسم العائله";
            gridIncreasesalary.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[7].Width = 50;
            gridIncreasesalary.Columns[8].Visible = false;
            gridIncreasesalary.Columns[9].Visible = false;
            gridIncreasesalary.Columns[10].Visible = false;
            gridIncreasesalary.Columns[11].Visible = false;
        }

        private void LoadUC()
        {
            DataTable dtpersonList = dalr.LoadRentList(userID);
            gridIncreasesalary.DataSource = dtpersonList;
            gridMaker();
            // userID = StaticUnitID.UserID1;
        }
        private Rent LoadControls()
        {
                       
            if (rent == null)
                rent = new Rent();
            rent.RentID = id;
            rent.ContractNumber = txtnumber.Text.Trim();
            rent.Price =Convert.ToInt32( numprice.Value);
            rent.Type = comType.Text.Trim();
            rent.Date = txtDate.Text.Trim();
            rent.expireDate = txtexpireDate.Text.Trim();
            rent.Name = txtName.Text.Trim();
            rent.Family = txtFamily.Text.Trim();
            rent.Address = txtAddress.Text;
            rent.Desc = txtDesc.Text;
            rent.UserID = userID;
            return rent;
        }
        private void gridIncreasesalary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clear();
            string q = "";
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[0].Value.ToString());
                txtnumber.Text = gridIncreasesalary.CurrentRow.Cells[1].Value.ToString();
                numprice.Value = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[2].Value.ToString());
                comType.Text = gridIncreasesalary.CurrentRow.Cells[3].Value.ToString().Trim();
                txtDate.Text = gridIncreasesalary.CurrentRow.Cells[4].Value.ToString().Trim();
                txtexpireDate.Text = gridIncreasesalary.CurrentRow.Cells[5].Value.ToString().Trim();
                txtName.Text = gridIncreasesalary.CurrentRow.Cells[6].Value.ToString().Trim();
                txtFamily.Text = gridIncreasesalary.CurrentRow.Cells[7].Value.ToString().Trim();
                txtAddress.Text = gridIncreasesalary.CurrentRow.Cells[8].Value.ToString().Trim();
                txtDesc.Text = gridIncreasesalary.CurrentRow.Cells[9].Value.ToString();
                userID = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[10].Value.ToString());
              //  date = gridIncreasesalary.CurrentRow.Cells[4].Value.ToString().Trim();
                btnEdit.Enabled = true;
                btnCancel.Enabled = true;
                btnOK.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            rent = LoadControls();
            if (rent != null)
            {
                dalr.EditRent(rent);
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
            if (rent.RentID == 0)
                MessageBox.Show("رکوردی برای حذف شدن وجود ندارد");
            else
            {
                DialogResult dlr;
                dlr = MessageBox.Show("آیا اجاره نامه مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (rent != null)
                    {
                        dalr.DeleteRent(rent.RentID, userID);
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
        public bool GetmaxDate(string a, string b)
        {
            bool r = false;
            int yeara = 0;
            int yearb = 0;
            int montha = 0;
            int monthb = 0;
            int daya = 0;
            int dayb = 0;
            a = a.Trim();
            b = b.Trim();
            if (a.Trim() != "")
            {
                yeara = GetYear(a);
                montha = GetMonth(a);
                daya = GetDayOfMonth(a);

            }
            if (b.Trim() != "")
            {
                yearb = GetYear(b);
                monthb = GetMonth(b);
                dayb = GetDayOfMonth(b);
            }
            if (yeara > yearb)
                r = true;
            else if (yeara == yearb)
                if (montha > monthb)
                    r = true;
                else if (montha == monthb)
                {
                    if (daya > dayb)
                        r = true;
                    else r = false;
                }
                else r = false;
            return r;

        }
        public int GetDayOfMonth(string x)
        {
            //d1 = DateTime.Now.Date;
            string dyear = x;
            int i = 0;
            string t = "";
            for (; i <= 2; i++)
                if (dyear[i] != '/')
                    t = t + dyear[i];
                else
                    break;

            //     txtname.Text = id.ToString();

            int day = Convert.ToInt32(t);

            return day;
        }
        public int GetMonth(string x)
        {
            //d1 = DateTime.Now.Date;
            string dyear = x;
            int i = 3;
            string t = "";
            if (dyear[1] == '/')
                i = 2;
            for (; i <= 4; i++)
                if (dyear[i] != '/')
                    t = t + dyear[i];
                else
                    break;
            //     txtname.Text = id.ToString();
            int Month = Convert.ToInt32(t);

            return Month;
        }
        public int GetYear(string x)
        {
            //d1 = DateTime.Now.Date;
            x = x.Trim();
            string dyear = x;
            int i = 6;
            string t = "";
            int l = x.Length;
            int i3 = 4;
            if (dyear[3] == '/')
            {
                for (; i3 < l; i3++)

                    t = t + dyear[i3];
            }
            if (dyear[4] == '/')
            {
                i = 5;
                for (; i < l; i++)

                    t = t + dyear[i];
            }
            else if (dyear[5] == '/')
                for (int i2 = 6; i2 < l; i2++)
                    t = t + dyear[i2];

            //     txtname.Text = id.ToString();
            int year = 0;
            if (t != "")
                year = Convert.ToInt32(t);

            return year;
        }
        private void numprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void txtnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Rent> LHr = dalr.LoadRentListmax(userID);
            Rent hc = new Rent();
            // int l2 = 1;
            for (int l2 = 0; LHr.Count > l2; l2++)
            {

                if (GetmaxDate(t1, LHr[l2].expireDate) == true)
                {

                    MessageBox.Show("ایجاری شماره " + " " + LHr[l2].ContractNumber.Trim() + " و در تاریخ" + LHr[l2].Date.Trim() + " " + "و به آدرس  " + LHr[l2].Address.Trim() + " " + "منفضی شده است");
                }

            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label12.Text = "";
            // Export all the details
            try
            {
                DataTable dtpersonListe = dalr.LoadRentListFORExcel(userID);
                RKLib.ExportData.Export objExport = new RKLib.ExportData.Export("Win");
                objExport.ExportDetails(dtpersonListe, Export.ExportFormat.Excel, "D:\\RentInfo.xls");
                //txtnumber.Text = "گزارشگيري در مسير D:\\EmployeesInfo.xls با موفقيت انجام شد";
                label12.Text = " با موفقيت انجام شد D:\\RentInfo.xls گزارشگيري";
            }
            catch (Exception Ex)
            {
                label12.Text = "گزارشگيري انجام نشد";
            }
        }


    }
}
