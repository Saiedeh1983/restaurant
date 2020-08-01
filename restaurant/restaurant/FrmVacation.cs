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
    public partial class FrmVacation : Form
    {
        PersonDAL dalP = new PersonDAL();
        Person person = new Person();
        List<Person> personList = new List<Person>();
        Person p = new Person();
        VacationDAL dalv = new VacationDAL();
        Vacation vacation = new Vacation();

        List<Vacation> vacationList = new List<Vacation>();
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
        public FrmVacation()
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
            DataTable dtpersonList = dalP.LoadPersonListwithnamefamily(txtname.Text, txtFamily.Text, userID);
            gridPerson.DataSource = dtpersonList;
            gridMaker2();

            p = dalP.LoadPersonwithnamefamily(txtname.Text, txtFamily.Text, userID);
            // userID = StaticUnitID.UserID1;
            PersonID = p.PersonID;
            // Fillnumlastsalary();
            DataTable dtpersonList2 = dalv.LoadVacationList(PersonID);
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
            vacation = new Vacation();
            vacation = LoadControls();
            //Fillnumlastsalary();
            // i=LoadIncreasesalaryListWithPersonID(PersonID, IncreasesalaryID)
            // p = dalP.LoadPersonwithnamefamily(txtname.Text, txtFamily.Text, userID);
            // userID = StaticUnitID.UserID1;
            // PersonID = p.PersonID;
            if (PersonID != 0)
                if (vacation.amount != 0)
                {
                    bool Test = dalv.InsertVacation(vacation);
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
                MessageBox.Show("کارمند انتخاب نشده است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void FillControl(Vacation vacation)
        {
            id = vacation.VacationID;
            PersonID = vacation.PersonID;
            numvacation.Value = Convert.ToDecimal(vacation.amount);
            txtDate.Text = vacation.Date.Trim();
            txtExpireDate.Text = vacation.ExpireDate;
            txtDesc.Text = vacation.Desc;
            userID = vacation.UserID;
            date = vacation.Date;
        }

        private void Clear()
        {
            //  PersonID = increasesalary.PersonID;
            numvacation.Value = 0;
            //     txtDate.Text = string.Empty;
            txtExpireDate.Text = string.Empty;
            txtDesc.Text = string.Empty;
            userID = vacation.UserID;
            date = vacation.Date;
            date = string.Empty;
        }

        private void gridMaker()
        {

            gridIncreasesalary.Columns[0].Visible = false;
            gridIncreasesalary.Columns[1].HeaderText = "اسم";
            gridIncreasesalary.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[1].Width = 50;
            gridIncreasesalary.Columns[2].HeaderText = "اسم العائله";
            gridIncreasesalary.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[2].Width = 50;
            gridIncreasesalary.Columns[3].HeaderText = "کم اجازه";
            gridIncreasesalary.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[3].Width = 50;
            gridIncreasesalary.Columns[4].HeaderText = "تاریخ التسجیل";
            gridIncreasesalary.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[4].Width = 50;
            gridIncreasesalary.Columns[5].HeaderText = "تاریخ الانتها";
            gridIncreasesalary.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[5].Width = 50;
            gridIncreasesalary.Columns[6].Visible = false;
            gridIncreasesalary.Columns[7].Visible = false;
            gridIncreasesalary.Columns[8].Visible = false;
            gridIncreasesalary.Columns[9].Visible = false;
        }

        private void LoadUC()
        {
            DataTable dtpersonList = dalv.LoadVacationList(PersonID);
            gridIncreasesalary.DataSource = dtpersonList;
            gridMaker();
            // userID = StaticUnitID.UserID1;
        }

        private void Frmencouragement_Load(object sender, EventArgs e)
        {
            LoadUC();
        }

        private Vacation LoadControls()
        {

            if (vacation == null)
                vacation = new Vacation();
            vacation.VacationID = id;
            vacation.PersonID = PersonID;
            vacation.amount = Convert.ToInt32(numvacation.Value);
            vacation.Date = txtDate.Text.Trim();
            vacation.ExpireDate = txtExpireDate.Text;
            vacation.Desc = txtDesc.Text;
            vacation.UserID = userID;


            return vacation;
        }
        private void gridIncreasesalary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clear();
            string q = "";
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[0].Value.ToString());
                PersonID = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[6].Value.ToString());
                numvacation.Value = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[3].Value.ToString());
                txtDate.Text = gridIncreasesalary.CurrentRow.Cells[4].Value.ToString().Trim();
                txtExpireDate.Text = gridIncreasesalary.CurrentRow.Cells[5].Value.ToString();
                txtDesc.Text = gridIncreasesalary.CurrentRow.Cells[7].Value.ToString();
                userID = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[8].Value.ToString());
                date = gridIncreasesalary.CurrentRow.Cells[4].Value.ToString().Trim();
                btnEdit.Enabled = true;
                btnCancel.Enabled = true;
                btnOK.Enabled = false;
            }
        }
        private void gridMaker2()
        {
            gridPerson.Columns[0].Visible = false;
            gridPerson.Columns[1].HeaderText = "تاریخ التسجیل";
            gridPerson.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[2].Visible = false;
            gridPerson.Columns[2].Width = 0;
            gridPerson.Columns[3].Visible = false;
            gridPerson.Columns[3].Width = 0;
            gridPerson.Columns[4].HeaderText = "الاسم";
            gridPerson.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[4].Width = 50;
            gridPerson.Columns[5].HeaderText = "اسم العائله";
            gridPerson.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[5].Width = 50;
            gridPerson.Columns[6].HeaderText = "اسم الاب";
            gridPerson.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[6].Width = 50;
            gridPerson.Columns[7].HeaderText = "جنسیه";
            gridPerson.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[7].Width = 50;
            gridPerson.Columns[8].Visible = false;
            gridPerson.Columns[8].Width = 0;
            gridPerson.Columns[9].Visible = false;
            gridPerson.Columns[9].Width = 0;
            gridPerson.Columns[10].Visible = false;
            gridPerson.Columns[10].Width = 0;
            gridPerson.Columns[11].HeaderText = "الوظیفه";
            gridPerson.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[11].Width = 50;
            gridPerson.Columns[12].Visible = false;
            gridPerson.Columns[12].Width = 0;
            gridPerson.Columns[13].Visible = false;
            gridPerson.Columns[13].Width = 0;
            gridPerson.Columns[14].Visible = false;
            gridPerson.Columns[14].Width = 0;
            gridPerson.Columns[15].Visible = false;
            gridPerson.Columns[15].Width = 0;
            gridPerson.Columns[16].Visible = false;
            gridPerson.Columns[16].Width = 0;
            gridPerson.Columns[17].Visible = false;
            gridPerson.Columns[17].Width = 0;
            gridPerson.Columns[18].Visible = false;
            gridPerson.Columns[18].Width = 0;
            gridPerson.Columns[19].Visible = false;
            gridPerson.Columns[19].Width = 0;
            gridPerson.Columns[20].Visible = false;
            gridPerson.Columns[20].Width = 0;
            gridPerson.Columns[21].Visible = false;
            gridPerson.Columns[21].Width = 0;
            gridPerson.Columns[22].Visible = false;
            gridPerson.Columns[22].Width = 0;
            gridPerson.Columns[23].Visible = false;
            gridPerson.Columns[23].Width = 0;
            gridPerson.Columns[24].Visible = false;
            gridPerson.Columns[24].Width = 0;
            gridPerson.Columns[25].Visible = false;
            gridPerson.Columns[25].Width = 0;
            gridPerson.Columns[26].Visible = false;
            gridPerson.Columns[26].Width = 0;
            gridPerson.Columns[27].Visible = false;
            gridPerson.Columns[27].Width = 0;
            gridPerson.Columns[28].Visible = false;
            gridPerson.Columns[28].Width = 0;
            gridPerson.Columns[29].Visible = false;
            gridPerson.Columns[29].Width = 0;
            gridPerson.Columns[30].Visible = false;
            gridPerson.Columns[30].Width = 0;
            gridPerson.Columns[31].Visible = false;
            gridPerson.Columns[31].Width = 0;
            gridPerson.Columns[32].Visible = false;
            gridPerson.Columns[32].Width = 0;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            vacation = LoadControls();
            if (vacation != null)
            {
                dalv.EditVacation(vacation);
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
            vacation = LoadControls();
            if (vacation.VacationID == 0)
                MessageBox.Show("رکوردی برای حذف شدن وجود ندارد");
            else
            {
                DialogResult dlr;
                dlr = MessageBox.Show("آیا مرخصی مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (vacation != null)
                    {
                        dalv.DeleteVacation(vacation.VacationID, userID);
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
            int year = Convert.ToInt32(t);

            return year;
        }
        private void numvacation_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Vacation> LH = dalv.LoadVacationListWithDistinctPersonID(userID);
            Vacation hc = new Vacation();
            for (int l = 0; LH.Count > l; l++)
            {
                hc.PersonID = LH[l].PersonID;
                List<Vacation> lh2 = dalv.LoadVacationList3(LH[l].PersonID);
                string max = lh2[0].ExpireDate;
                if (lh2.Count > 1)
                    for (int l2 = 1; lh2.Count > l2; l2++)
                    {
                        //if (lh2[l2].expireDate != "")
                        if (GetmaxDate(lh2[l2].ExpireDate, max) == true)
                            max = lh2[l2].ExpireDate;
                        if (GetmaxDate(t1, max) == true)
                        // if (max=<date)
                        {
                            Person p2 = dalP.LoadPerson(LH[l].PersonID, userID);
                            MessageBox.Show("مرخصی " + " " + p2.Name.Trim() + " " + p2.Family.Trim() + " " + "منفضی شده است");
                        }
                    }
                else if (lh2.Count == 1)
                    if (GetmaxDate(t1, max) == true)
                    // if (max=<date)
                    {
                        Person p2 = dalP.LoadPerson(LH[l].PersonID, userID);
                        MessageBox.Show("مرخصی " + " " + p2.Name.Trim() + " " + p2.Family.Trim() + " " + "منفضی شده است");
                    }
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label13.Text = "";
            // Export all the details
            try
            {
                DataTable dtpersonListe = dalv.LoadVacationListFORExcel(userID);
                RKLib.ExportData.Export objExport = new RKLib.ExportData.Export("Win");
                objExport.ExportDetails(dtpersonListe, Export.ExportFormat.Excel, "D:\\VacationInfo.xls");
                //txtnumber.Text = "گزارشگيري در مسير D:\\EmployeesInfo.xls با موفقيت انجام شد";
                label13.Text = "گزارشگيري D:\\VacationInfo.xls با موفقيت انجام شد";
            }
            catch (Exception Ex)
            {
                label13.Text = "گزارشگيري انجام نشد";
            }
        }


    }
}
