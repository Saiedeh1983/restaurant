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
    public partial class FrmCar : Form
    {
        DataTable dtpersonList = new DataTable();
        DataTable dtpersonList2 = new DataTable();
        PersonDAL dalP = new PersonDAL();
        Person person = new Person();
        List<Person> personList = new List<Person>();
        Person p = new Person();
        CarDAL dalc = new CarDAL();
        Car car = new Car();

        List<Car> carList = new List<Car>();
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

        public FrmCar()
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

        private void btnfind_Click(object sender, EventArgs e)
        {
            Clear();
            dtpersonList = dalP.LoadPersonListwithnamefamily(txtname.Text, txtFamily.Text, userID);
            gridPerson.DataSource = dtpersonList;
            gridMaker2();

            p = dalP.LoadPersonwithnamefamily(txtname.Text, txtFamily.Text, userID);
            // userID = StaticUnitID.UserID1;
            PersonID = p.PersonID;
            // Fillnumlastsalary();
            dtpersonList2 = dalc.LoadCarList(PersonID);
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
            car = new Car();
            car = LoadControls();
            //Fillnumlastsalary();
            // i=LoadIncreasesalaryListWithPersonID(PersonID, IncreasesalaryID)
            // p = dalP.LoadPersonwithnamefamily(txtname.Text, txtFamily.Text, userID);
            // userID = StaticUnitID.UserID1;
            // PersonID = p.PersonID;
            if (PersonID != 0)
                if (car.number != "")
                {
                    bool Test = dalc.InsertCar(car);
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
        private void FillControl(Car car)
        {
            id = car.CarID;
            PersonID = car.PersonID;
            txtType.Text = car.Type.Trim();
            txtnumber.Text = car.number.Trim();
            txtDesc.Text = car.Desc.Trim();
            userID = car.UserID;
            date = car.Type;
        }

        private void Clear()
        {
            //  PersonID = increasesalary.PersonID;
            //  numlastincrease.Value = 0;
            txtnumber.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtType.Text = string.Empty;
            userID = car.UserID;
      
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
            gridIncreasesalary.Columns[3].HeaderText = "رقم";
            gridIncreasesalary.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[3].Width = 50;
            gridIncreasesalary.Columns[4].HeaderText = "نوع";
            gridIncreasesalary.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[4].Width = 50;
            gridIncreasesalary.Columns[5].Visible = false;
            gridIncreasesalary.Columns[6].Visible = false;
            gridIncreasesalary.Columns[7].Visible = false;
            gridIncreasesalary.Columns[8].Visible = false;

        }

        private void LoadUC()
        {
            dtpersonList = dalc.LoadCarList(PersonID);
            gridIncreasesalary.DataSource = dtpersonList;
            gridMaker();
            // userID = StaticUnitID.UserID1;
        }
        private Car LoadControls()
        {

            if (car == null)
                car = new Car();
            car.CarID = id;
            car.PersonID = PersonID;
            car.Type = txtType.Text.Trim();
            car.number = txtnumber.Text;
            car.Desc = txtDesc.Text;
            car.UserID = userID;


            return car;
        }

        private void gridIncreasesalary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Clear();
            string q = "";
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[0].Value.ToString());
                PersonID = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[5].Value.ToString());
                txtType.Text = gridIncreasesalary.CurrentRow.Cells[4].Value.ToString().Trim();
                txtnumber.Text = gridIncreasesalary.CurrentRow.Cells[3].Value.ToString();
                txtDesc.Text = gridIncreasesalary.CurrentRow.Cells[6].Value.ToString();
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
            car = LoadControls();
            if (car != null)
            {
                dalc.EditCar(car);
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
            if (car.CarID == 0)
                MessageBox.Show("رکوردی برای حذف شدن وجود ندارد");
            else
            {
                DialogResult dlr;
                dlr = MessageBox.Show("آیا اتومبیل مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (car != null)
                    {
                        dalc.DeleteCar(car.CarID, userID);
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

        private void FrmCar_Load(object sender, EventArgs e)
        {
            LoadUC();
        }

        private void txtnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            FrmPlate frmPlate = new FrmPlate();
            //Person.MdiParent = this;
            frmPlate.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            // Export all the details
            try
            {
                DataTable dtpersonListe = dalc.LoadCarListFORExcel(userID);
                RKLib.ExportData.Export objExport = new RKLib.ExportData.Export("Win");
                objExport.ExportDetails(dtpersonListe, Export.ExportFormat.Excel, "D:\\CarInfo.xls");
                //txtnumber.Text = "گزارشگيري در مسير D:\\EmployeesInfo.xls با موفقيت انجام شد";
                label8.Text = "گزارشگيري D:\\CarInfo.xls با موفقيت انجام شد";
            }
            catch (Exception Ex)
            {
                label8.Text = "گزارشگيري انجام نشد";
            }
        }

        private void btnInsurance_Click(object sender, EventArgs e)
        {
            FrmInsurance frmInsurance = new FrmInsurance();
            //Person.MdiParent = this;
            frmInsurance.Show();
        }
    }
}
