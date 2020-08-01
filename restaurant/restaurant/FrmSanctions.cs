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
    public partial class FrmSanctions : Form
    {
        PersonDAL dalP = new PersonDAL();
        Person person = new Person();
        List<Person> personList = new List<Person>();
        Person p = new Person();
        SanctionsDAL dals = new SanctionsDAL();
        Sanctions sanctions = new Sanctions();
        List<Sanctions> sanctionsList = new List<Sanctions>();
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

        public FrmSanctions()
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
            DataTable dtpersonList2 = dals.LoadSanctionsList(PersonID);
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
            sanctions = new Sanctions();
            sanctions = LoadControls();
            //Fillnumlastsalary();
            // i=LoadIncreasesalaryListWithPersonID(PersonID, IncreasesalaryID)
            // p = dalP.LoadPersonwithnamefamily(txtname.Text, txtFamily.Text, userID);
            // userID = StaticUnitID.UserID1;
            // PersonID = p.PersonID;
            if (PersonID != 0)
                if (sanctions.amount != 0)
                {
                    bool Test = dals.InsertSanctions(sanctions);
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
                txtcouse.Text = gridIncreasesalary.CurrentRow.Cells[5].Value.ToString();
                txtDesc.Text = gridIncreasesalary.CurrentRow.Cells[7].Value.ToString();
                userID = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[8].Value.ToString());
                date = gridIncreasesalary.CurrentRow.Cells[4].Value.ToString().Trim();
                btnEdit.Enabled = true;
                btnCancel.Enabled = true;
                btnOK.Enabled = false;
            }
        }

        private void FillControl(Sanctions sanctions)
        {
            id = sanctions.SanctionsID;
            PersonID = sanctions.PersonID;
            numlastincrease.Value = Convert.ToDecimal(sanctions.amount);
            txtDate.Text = sanctions.Date.Trim();
            txtcouse.Text = sanctions.cause;
            txtDesc.Text = sanctions.Desc;
            userID = sanctions.UserID;
            date = sanctions.Date;
        }

        private void Clear()
        {
            //  PersonID = increasesalary.PersonID;
            numlastincrease.Value = 0;
            //     txtDate.Text = string.Empty;
            txtcouse.Text = string.Empty;
            txtDesc.Text = string.Empty;
            userID = sanctions.UserID;
            date = sanctions.Date;
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
            gridIncreasesalary.Columns[3].HeaderText = "القیمه";
            gridIncreasesalary.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[3].Width = 50;
            gridIncreasesalary.Columns[4].HeaderText = "تاریخ التسجیل";
            gridIncreasesalary.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[4].Width = 50;
            gridIncreasesalary.Columns[5].HeaderText = "وذلک";
            gridIncreasesalary.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[5].Width = 50;
            gridIncreasesalary.Columns[6].Visible = false;
            gridIncreasesalary.Columns[7].Visible = false;
            gridIncreasesalary.Columns[8].Visible = false;
            gridIncreasesalary.Columns[9].Visible = false;
        }

        private void LoadUC()
        {
            DataTable dtpersonList = dals.LoadSanctionsList(PersonID);
            gridIncreasesalary.DataSource = dtpersonList;
            gridMaker();
            // userID = StaticUnitID.UserID1;
        }

        private void FrmSanctions_Load(object sender, EventArgs e)
        {
            LoadUC();
        }
        private Sanctions LoadControls()
        {

            if (sanctions == null)
                sanctions = new Sanctions();
            sanctions.SanctionsID = id;
            sanctions.PersonID = PersonID;
            sanctions.amount = Convert.ToInt32(numlastincrease.Value);
            sanctions.Date = txtDate.Text.Trim();
            sanctions.cause = txtcouse.Text;
            sanctions.Desc = txtDesc.Text;
            sanctions.UserID = userID;


            return sanctions;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            sanctions = LoadControls();
            if (sanctions != null)
            {
                dals.EditSanctions(sanctions);
                MessageBox.Show("ویرایش شد");
                btnEdit.Enabled = false;
                btnCancel.Enabled = false;
                btnOK.Enabled = false;
                Clear();
                LoadUC();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            sanctions = LoadControls();
            if (sanctions.SanctionsID == 0)
                MessageBox.Show("رکوردی برای حذف شدن وجود ندارد");
            else
            {
                DialogResult dlr;
                dlr = MessageBox.Show("آیا خصومات مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (sanctions != null)
                    {
                        dals.DeleteSanctions(sanctions.SanctionsID, userID);
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

        private void numlastincrease_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sanctions i = new Sanctions();
            List<Sanctions> li = new List<Sanctions>();
            li = dals.LoadSanctionsListWithPersonID(PersonID);
            int c = li.Count;
            int l = 1;
            int result = 0;
            for (; l <= c; l++)
            {
                if (l > 0)
                    i = li[l - 1];
                if (PersonID != 0 && i.SanctionsID != 0)
                    //   i = dalI.LoadEncouragementWithPersonID(PersonID, i.EncouragementID);

                    result = result + i.amount;
                txtresult.Text = result.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            label8.Text = "";
            // Export all the details
            try
            {
                DataTable dtpersonListe = dals.LoadSanctionsListFORExcel(userID);
                RKLib.ExportData.Export objExport = new RKLib.ExportData.Export("Win");
                objExport.ExportDetails(dtpersonListe, Export.ExportFormat.Excel, "D:\\SanctionsInfo.xls");
                //txtnumber.Text = "گزارشگيري در مسير D:\\EmployeesInfo.xls با موفقيت انجام شد";
                label8.Text = " با موفقيت انجام شد D:\\SanctionsInfo.xls گزارشگيري";
            }
            catch (Exception Ex)
            {
                label8.Text = "گزارشگيري انجام نشد";
            }
        }

    }
}
