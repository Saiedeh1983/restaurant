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
    public partial class FrmUtility : Form
    {
        DataTable dtpersonList = new DataTable();
        DataTable dtpersonList2 = new DataTable();
        RentDAL dalr = new RentDAL();
        Rent rent = new Rent();
        List<Rent> rentList = new List<Rent>();
        Rent r = new Rent();
        UtilityDAL dalu = new UtilityDAL();
        Utility utility = new Utility();
        List<Utility> utilityList = new List<Utility>();

        public int id = 0;
        int RentID = 0;
        int userID = 0;
        string date = "";
        string Month = "";
        int Months = 0;
        int days = 0;
        int years = 0;
        int timeout;
        DateTime d1;
        public string t1 = "";

        public FrmUtility()
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

        private void btnfind_Click(object sender, EventArgs e)
        {
            Clear();
            dtpersonList = dalr.LoadRentListwithContractNumber(txtContractNumber.Text.Trim(), userID);
            gridrent.DataSource = dtpersonList;
            gridMaker2();

            r = dalr.LoadRentWithContractNumber(txtContractNumber.Text, userID);
            // userID = StaticUnitID.UserID1;
            RentID = r.RentID;
            // Fillnumlastsalary();
            dtpersonList2 = dalu.LoadUtilityList(RentID);
            gridIncreasesalary.DataSource = dtpersonList2;
            gridMaker();
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
            utility = new Utility();
            utility = LoadControls();
            //Fillnumlastsalary();
            // i=LoadIncreasesalaryListWithPersonID(PersonID, IncreasesalaryID)
            // p = dalP.LoadPersonwithnamefamily(txtname.Text, txtFamily.Text, userID);
            // userID = StaticUnitID.UserID1;
            // PersonID = p.PersonID;
            if (RentID != 0)
                if (utility.amount != 0)
                {
                    bool Test = dalu.InsertUtility(utility);
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
            else
                MessageBox.Show("مکان انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void FillControl(Utility utility)
        {
           

            id = utility.UtilityID;
            RentID = utility.RentID;
            numamount.Value = utility.amount;
            txtDate.Text = utility.FromDate.Trim();
            txtExpireDate.Text = utility.UntilDate.Trim();
            comtype.Text = utility.TypeOfBill.Trim();
            txtDesc.Text = utility.Desc;
            userID = utility.UserID;
          //  date = utility.expireDate;
        }

        private void Clear()
        {
            //  PersonID = increasesalary.PersonID;
            //  numlastincrease.Value = 0;
     
            numamount.Value = 0;
            txtDate.Text = date;
            txtExpireDate.Text = string.Empty;
            comtype.Text = string.Empty;
            txtDesc.Text = string.Empty;
            userID = utility.UserID;
            date = string.Empty;
        }

        private void gridMaker()
        {
            gridIncreasesalary.Columns[0].Visible = false;
            gridIncreasesalary.Columns[1].HeaderText = "رقم";
            gridIncreasesalary.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[1].Width = 50;
            gridIncreasesalary.Columns[2].HeaderText = "نوع ایجاری";
            gridIncreasesalary.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[2].Width = 50;
            gridIncreasesalary.Columns[3].HeaderText = "مبلغ";
            gridIncreasesalary.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[3].Width = 50;
             gridIncreasesalary.Columns[4].HeaderText = "نوع";
            gridIncreasesalary.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[4].Width = 50;
            gridIncreasesalary.Columns[5].Visible = false;
            gridIncreasesalary.Columns[6].HeaderText = "تاریخ الانتها";
            gridIncreasesalary.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[6].Width = 50;
            gridIncreasesalary.Columns[8].Visible = false;
            gridIncreasesalary.Columns[9].Visible = false;
            gridIncreasesalary.Columns[10].Visible = false;
        }
      
        private void LoadUC()
        {

            dtpersonList2 = dalu.LoadUtilityList(RentID);
            gridIncreasesalary.DataSource = dtpersonList2;
            gridMaker();
        }
        private Utility LoadControls()
        {

            if (utility == null)
                utility = new Utility();
            utility.UtilityID = id;
            utility.RentID = RentID;
            utility.amount = Convert.ToInt32(numamount.Value);
            utility.FromDate = txtDate.Text.Trim();
            utility.UntilDate = txtExpireDate.Text.Trim();
            utility.TypeOfBill = comtype.Text;
            utility.Desc = txtDesc.Text;
            utility.UserID = userID;


            return utility;
        }

        private void gridIncreasesalary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clear();
            string q = "";
            if (e.RowIndex >= 0)
            {
   
                id = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[0].Value.ToString());
                RentID = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[7].Value.ToString());
                numamount.Value=Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[3].Value.ToString());
                txtDate.Text = gridIncreasesalary.CurrentRow.Cells[5].Value.ToString().Trim();
                 txtExpireDate.Text = gridIncreasesalary.CurrentRow.Cells[6].Value.ToString().Trim();
                comtype.Text = gridIncreasesalary.CurrentRow.Cells[4].Value.ToString();
                txtDesc.Text = gridIncreasesalary.CurrentRow.Cells[8].Value.ToString();
                userID = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[9].Value.ToString());
               // date = gridIncreasesalary.CurrentRow.Cells[4].Value.ToString().Trim();
                btnEdit.Enabled = true;
                btnCancel.Enabled = true;
                btnOK.Enabled = false;
            }
        }
        private void gridMaker2()
        {
            gridrent.Columns[0].Visible = false;
            gridrent.Columns[1].HeaderText = "رقم";
            gridrent.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridrent.Columns[1].Width = 50;
            gridrent.Columns[2].HeaderText = "مبلغ";
            gridrent.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridrent.Columns[2].Width = 50;
            gridrent.Columns[3].HeaderText = "نوع";
            gridrent.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridrent.Columns[3].Width = 50;
            gridrent.Columns[4].HeaderText = "تاریخ العقد";
            gridrent.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridrent.Columns[4].Width = 50;
            gridrent.Columns[5].HeaderText = "تاریخ الانتها";
            gridrent.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridrent.Columns[5].Width = 50;
            gridrent.Columns[6].HeaderText = "الاسم";
            gridrent.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridrent.Columns[6].Width = 50;
            gridrent.Columns[7].HeaderText = "اسم العائله";
            gridrent.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridrent.Columns[7].Width = 50;
            gridrent.Columns[8].Visible = false;
            gridrent.Columns[9].Visible = false;
            gridrent.Columns[10].Visible = false;
            gridrent.Columns[11].Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            utility = LoadControls();
            if (utility != null)
            {
                dalu.EditUtility(utility);
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
            if (utility.UtilityID == 0)
                MessageBox.Show("رکوردی برای حذف شدن وجود ندارد");
            else
            {
                DialogResult dlr;
                dlr = MessageBox.Show("آیا اقامت مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (utility != null)
                    {
                        dalu.DeleteUtility(utility.UtilityID, userID);
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

        private void txtbillnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnOK.Enabled = true;
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
                if (dyear.Length > i)
                    if (dyear[i] != '/')
                        t = t + dyear[i];
                    else
                        break;

            //     txtname.Text = id.ToString();
            int day = 0;
            if (t != "")
                day = Convert.ToInt32(t);

            return day;
        }
        public int GetMonth(string x)
        {
            //d1 = DateTime.Now.Date;
            string dyear = x;
            int i = 3;
            string t = "";
            if (dyear.Length>1)
            if (dyear[1] == '/')
                i = 2;
            for (; i <= 4; i++)
                if (dyear.Length > i)
                    if (dyear[i] != '/')
                        t = t + dyear[i];
                    else
                        break;
            //     txtname.Text = id.ToString();
            int Month = 0;
            if (t != "")
                Month = Convert.ToInt32(t);

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
            if (l > 4)
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
        private void FrmUtility_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RentDAL dalr = new RentDAL();
            Rent rent = new Rent();
            List<Rent> rentList = new List<Rent>();

            List<Utility> LHut = dalu.LoadUtilityListWithDistinctRentID(userID);
            Utility hcu = new Utility();
            for (int l = 0; LHut.Count > l; l++)
            {
                hcu.RentID = LHut[l].RentID;
                List<Utility> lh2 = dalu.LoadUtilityList3(LHut[l].RentID);
                string max = lh2[0].UntilDate;
                if (lh2.Count > 1)
                    for (int l2 = 1; lh2.Count > l2; l2++)
                    {
                        //if (lh2[l2].expireDate != "")
                        if (GetmaxDate(lh2[l2].UntilDate, max) == true)
                            max = lh2[l2].UntilDate;
                        if (GetmaxDate(t1, max) == true)
                        // if (max=<date)                                              
                        {
                            Rent c2 = dalr.LoadRent(LHut[l].RentID, userID);
                            MessageBox.Show("قبض شماره  " + " " + c2.ContractNumber.Trim() + "  با هزینه " + LHut[l].amount+ " " + "منفضی شده است");
                           
                        }
                    }
                else if (lh2.Count == 1)
                    if (GetmaxDate(t1, max) == true)
                    // if (max=<date)
                    {
                        Rent c2 = dalr.LoadRent(LHut[l].RentID, userID);
                        MessageBox.Show("قبض شماره  " + " " + c2.ContractNumber.Trim() + "  با هزینه " + LHut[l].amount + " " + "منفضی شده است");
                           
                    }
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Text = "";
            // Export all the details
            try
            {
                DataTable dtpersonListe = dalu.LoadUtilityListFORExcel(userID);
                RKLib.ExportData.Export objExport = new RKLib.ExportData.Export("Win");
                objExport.ExportDetails(dtpersonListe, Export.ExportFormat.Excel, "D:\\UtilityInfo.xls");
                //txtnumber.Text = "گزارشگيري در مسير D:\\EmployeesInfo.xls با موفقيت انجام شد";
                label9.Text = " با موفقيت انجام شد D:\\UtilityInfo.xls گزارشگيري";
           }
           catch (Exception Ex)
            {
                label9.Text = "گزارشگيري انجام نشد";
            }
        }


    }
}
