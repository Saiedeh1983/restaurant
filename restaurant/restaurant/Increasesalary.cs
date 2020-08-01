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
    public partial class FrmIncreasesalary : Form
    {
        PersonDAL dalP = new PersonDAL();
        Person person = new Person();
        List<Person> personList = new List<Person>();
        Person p = new Person();
        IncreasesalaryDAL dalI = new IncreasesalaryDAL();
        Increasesalary increasesalary = new Increasesalary();

        List<Increasesalary> increasesalaryList = new List<Increasesalary>();
        public int id = 0;
        int PersonID=0;
        int userID = 0;
        string date = "";
        string Month = "";
        int Months = 0;
        int days = 0;
        int years = 0;
        int timeout;
        DateTime d1;
        public string t1 = "";

        public FrmIncreasesalary()
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
        }

        private void Increasesalary_Load(object sender, EventArgs e)
        {
            LoadUC();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            Fillnumlastsalary();
            btnOK.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void Fillnumlastsalary()
        {
            Increasesalary i = new Increasesalary();
            List<Increasesalary> li = new List<Increasesalary>();
            li = dalI.LoadIncreasesalaryListWithPersonID(PersonID);
            int c = li.Count;
            if (c > 0)
                i = li[c - 1];
            if (PersonID != 0 && i.IncreasesalaryID != 0)
                i = dalI.LoadIncreasesalaryWithPersonID(PersonID, i.IncreasesalaryID);
            numlastsalary.Value = i.lastIncrease + i.lastsalary; 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            increasesalary = new Increasesalary();
            increasesalary = LoadControls();
            Fillnumlastsalary();
           // i=LoadIncreasesalaryListWithPersonID(PersonID, IncreasesalaryID)
           // p = dalP.LoadPersonwithnamefamily(txtname.Text, txtFamily.Text, userID);
            // userID = StaticUnitID.UserID1;
           // PersonID = p.PersonID;
           if(PersonID!=0)
            if (increasesalary.lastsalary != 0)
            {
                bool Test = dalI.InsertIncreasesalary(increasesalary);
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

        private void gridIncreasesalary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clear();
            string q = "";
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[0].Value.ToString());
                PersonID = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[6].Value.ToString());
                numlastincrease.Value = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[3].Value.ToString());
                txtDate.Text = gridIncreasesalary.CurrentRow.Cells[4].Value.ToString().Trim();
                numlastsalary.Value = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[5].Value.ToString());
                txtDesc.Text = gridIncreasesalary.CurrentRow.Cells[7].Value.ToString();
                userID = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[8].Value.ToString());
                date = gridIncreasesalary.CurrentRow.Cells[4].Value.ToString().Trim();
                btnEdit.Enabled = true;
                btnCancel.Enabled = true;
                btnOK.Enabled = false;
            }
        }

        private void FillControl(Increasesalary increasesalary)
        {
            id = increasesalary.IncreasesalaryID;
            PersonID = increasesalary.PersonID;
            numlastincrease.Value = Convert.ToDecimal(increasesalary.lastIncrease);
            txtDate.Text = increasesalary.Date.Trim();
            numlastsalary.Value = Convert.ToDecimal(increasesalary.lastsalary);
            txtDesc.Text = increasesalary.Desc;
            userID = increasesalary.UserID;
            date = increasesalary.Date;
        }

        private void Clear()
        {
          //  PersonID = increasesalary.PersonID;
            numlastincrease.Value =0;
       //     txtDate.Text = string.Empty;
            numlastsalary.Value =0;
            txtDesc.Text = string.Empty;
            userID = increasesalary.UserID;
            date = increasesalary.Date;           
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
            gridIncreasesalary.Columns[3].HeaderText = "آخر زیاده";
            gridIncreasesalary.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[3].Width = 50;
            gridIncreasesalary.Columns[4].HeaderText = "تاریخ التسجیل";
            gridIncreasesalary.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[4].Width = 50;
            gridIncreasesalary.Columns[5].HeaderText = "الراتب بعد الزیاده";
            gridIncreasesalary.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[5].Width = 50;
            gridIncreasesalary.Columns[6].Visible = false;
            gridIncreasesalary.Columns[7].Visible = false;
            gridIncreasesalary.Columns[8].Visible = false;
            gridIncreasesalary.Columns[9].Visible = false;
        }
        private void LoadUC()
        {
            DataTable dtpersonList = dalI.LoadIncreasesalaryList(PersonID);
            gridIncreasesalary.DataSource = dtpersonList;
            gridMaker();
           // userID = StaticUnitID.UserID1;
        }

        private Increasesalary LoadControls()
        {
         
            if (increasesalary == null)
                increasesalary = new Increasesalary();
            increasesalary.IncreasesalaryID = id;
            increasesalary.PersonID = PersonID;
            increasesalary.lastIncrease = Convert.ToInt32(numlastincrease.Value);
            increasesalary.Date = txtDate.Text.Trim();
            increasesalary.lastsalary = Convert.ToInt32(numlastsalary.Value);
            increasesalary.Desc = txtDesc.Text;
            increasesalary.UserID = userID;
           

            return increasesalary;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            increasesalary = LoadControls();
            if (increasesalary != null)
            {
                dalI.EditIncreasesalary(increasesalary);
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
            increasesalary = LoadControls();
            if (increasesalary.IncreasesalaryID == 0)
                MessageBox.Show("رکوردی برای حذف شدن وجود ندارد");
            else
            {
                DialogResult dlr;
                dlr = MessageBox.Show("آیا اضافه حقوق مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (increasesalary != null)
                    {
                        dalI.DeleteIncreasesalary(increasesalary.IncreasesalaryID, userID);
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

        private void gridMaker2()
        {
            gridPerson.Columns[0].Visible = false;
            gridPerson.Columns[1].HeaderText = "تاریخ التسجیل";
            gridPerson.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[2].Visible = false;
            gridPerson.Columns[3].Visible = false;
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
            gridPerson.Columns[9].Visible = false;
            gridPerson.Columns[10].Visible = false;
            gridPerson.Columns[11].HeaderText = "الوظیفه";
            gridPerson.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[11].Width = 50;
            gridPerson.Columns[12].Visible = false;
            gridPerson.Columns[13].Visible = false;
            gridPerson.Columns[14].Visible = false;
            gridPerson.Columns[15].Visible = false;
            gridPerson.Columns[16].Visible = false;
            gridPerson.Columns[17].Visible = false;
            gridPerson.Columns[18].Visible = false;
            gridPerson.Columns[19].Visible = false;
            gridPerson.Columns[20].Visible = false;
            gridPerson.Columns[21].Visible = false;
            gridPerson.Columns[22].Visible = false;
            gridPerson.Columns[23].Visible = false;
            gridPerson.Columns[24].Visible = false;
            gridPerson.Columns[25].Visible = false;
            gridPerson.Columns[26].Visible = false;
            gridPerson.Columns[27].Visible = false;
            gridPerson.Columns[28].Visible = false;
            gridPerson.Columns[29].Visible = false;
            gridPerson.Columns[30].Visible = false;
            gridPerson.Columns[31].Visible = false;
            gridPerson.Columns[32].Visible = false;
        }

        private void numlastincrease_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnOK.Enabled = true;
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
            Fillnumlastsalary();
            DataTable dtpersonList2 = dalI.LoadIncreasesalaryList(PersonID);
            gridIncreasesalary.DataSource = dtpersonList2;
            gridMaker();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fillnumlastsalary();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            // Export all the details
            try
            {
                DataTable dtpersonListe = dalI.LoadIncreasesalaryListFORExcel(userID);
                RKLib.ExportData.Export objExport = new RKLib.ExportData.Export("Win");
                objExport.ExportDetails(dtpersonListe, Export.ExportFormat.Excel, "D:\\IncreasesalaryInfo.xls");
                //txtnumber.Text = "گزارشگيري در مسير D:\\EmployeesInfo.xls با موفقيت انجام شد";
                label8.Text = "گزارشگيري D:\\IncreasesalaryInfo.xls با موفقيت انجام شد";
            }
            catch (Exception Ex)
            {
                label8.Text = "گزارشگيري انجام نشد";
            }
        }
    }
}
