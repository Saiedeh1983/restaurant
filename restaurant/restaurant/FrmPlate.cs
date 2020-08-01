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
    public partial class FrmPlate : Form
    {
        CarDAL dalc = new CarDAL();
        Car car = new Car();
        List<Car> carList = new List<Car>();
        Car c = new Car();
        PlateDAL dalpl = new PlateDAL();
        Plate plate = new Plate();
        List<Plate> plateList = new List<Plate>();
        public int id = 0;
        int CarID = 0;
        int userID = 0;
        string date = "";
        string Month = "";
        int Months = 0;
        int days = 0;
        int years = 0;
        int timeout;
        DateTime d1;
        public string t1 = "";
        string number;
        string type;
        public FrmPlate()
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
            txtDate.Text = t1;
            //     txtname.Text = id.ToString();
            date = t1;
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            Clear();
            DataTable dtCarList = dalc.LoadCarListWithnumberandType(txtnumber.Text, txttype.Text, userID);
            gridPerson.DataSource = dtCarList;
            gridMaker2();

            c = dalc.LoadCarWithnumberandType(txtnumber.Text, txttype.Text, userID);
            // userID = StaticUnitID.UserID1;
            CarID = c.CarID;
            // Fillnumlastsalary();
            DataTable dtPlateList = dalpl.LoadPlateList(CarID);
            gridIncreasesalary.DataSource = dtPlateList;
            gridMaker();

        }
        private void FillControl(Plate plate)
        {
            id = plate.PlateID;
            CarID = plate.CarID;
            numamount.Value = Convert.ToDecimal(plate.amount);
            txtDate.Text = plate.Date.Trim();
            txtExpireDate.Text = plate.ExpireDate;
            txtDesc.Text = plate.Desc;
            userID = plate.UserID;
            date = plate.Date;
        }

        private void Clear()
        {
            //  CarID = increasesalary.CarID;
            numamount.Value = 0;
            //     txtDate.Text = string.Empty;
            txtExpireDate.Text = string.Empty;
            txtDesc.Text = string.Empty;
            userID = plate.UserID;
            date = plate.Date;
            date = string.Empty;
        }

        private void gridMaker()
        {

            gridIncreasesalary.Columns[0].Visible = false;
            gridIncreasesalary.Columns[1].HeaderText = "رقم";
            gridIncreasesalary.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[1].Width = 50;
            gridIncreasesalary.Columns[2].HeaderText = "نوع";
            gridIncreasesalary.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridIncreasesalary.Columns[2].Width = 50;
            gridIncreasesalary.Columns[3].HeaderText = "مبلغ";
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
        private Plate LoadControls()
        {

            if (plate == null)
                plate = new Plate();
            plate.PlateID = id;
            plate.CarID = CarID;
            plate.amount = Convert.ToInt32(numamount.Value);
            plate.Date = txtDate.Text.Trim();
            plate.ExpireDate = txtExpireDate.Text;
            plate.Desc = txtDesc.Text;
            plate.UserID = userID;


            return plate;
        }
        private void LoadUC()
        {
          
            DataTable dtPlateList = dalpl.LoadPlateList(CarID);
            gridIncreasesalary.DataSource = dtPlateList;
            gridMaker();
          
            // userID = StaticUnitID.UserID1;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            //  Fillnumlastsalary();
            btnOK.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;
        }
        private void gridMaker2()
        {
            gridPerson.Columns[0].Visible = false;
            gridPerson.Columns[1].Visible = false;
            gridPerson.Columns[1].Width = 0;
            gridPerson.Columns[2].HeaderText = "رقم ";
            gridPerson.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[3].HeaderText = "نوع";
            gridPerson.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[3].Width = 50;
            gridPerson.Columns[4].HeaderText = "وصف";
            gridPerson.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridPerson.Columns[4].Width = 50;
            gridPerson.Columns[5].Visible = false;
            gridPerson.Columns[5].Width = 0;
            gridPerson.Columns[6].Visible = false;
            gridPerson.Columns[6].Width = 0;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            plate = new Plate();
            plate = LoadControls();
            //Fillnumlastsalary();
            // i=LoadIncreasesalaryListWithCarID(CarID, IncreasesalaryID)
            // p = dalP.LoadPersonwithnamefamily(txtname.Text, txtFamily.Text, userID);
            // userID = StaticUnitID.UserID1;
            // CarID = p.CarID;
            if (CarID != 0)
                if (plate.amount != 0)
                {
                    bool Test = dalpl.InsertPlate(plate);
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
                CarID = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[6].Value.ToString());
                numamount.Value = Convert.ToInt32(gridIncreasesalary.CurrentRow.Cells[3].Value.ToString());
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
            if (t!="")
             day = Convert.ToInt32(t);

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
                if(dyear.Length>i)                    
                if (dyear[i] != '/')
                    t = t + dyear[i];
                else
                    break;
            //     txtname.Text = id.ToString();
            int Month = 0;
            if (t!="")
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
            if (l>4)
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
            if (t!="")
                year = Convert.ToInt32(t);

            return year;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            plate = LoadControls();
            if (plate != null)
            {
                dalpl.EditPlate(plate);
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
            plate = LoadControls();
            if (plate.PlateID == 0)
                MessageBox.Show("رکوردی برای حذف شدن وجود ندارد");
            else
            {
                DialogResult dlr;
                dlr = MessageBox.Show("آیا تمدید پلاک مورد نظر حذف شود" + "؟", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (plate != null)
                    {
                        dalpl.DeletePlate(plate.PlateID, userID);
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

        private void numamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnOK.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Plate> LHpl = dalpl.LoadPlateListWithDistinctCarID(userID);
            Plate hc = new Plate();
            for (int l = 0; LHpl.Count > l; l++)
            {
                hc.CarID = LHpl[l].CarID;
                List<Plate> lh2 = dalpl.LoadPlateList3(LHpl[l].CarID);
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
                            Car c2 = dalc.LoadCar(LHpl[l].CarID, userID);
                            MessageBox.Show("تمدید پلاک " + " " + c2.number.Trim() + " " + c2.Type.Trim() + " " + "منفضی شده است");
                        }
                    }
                else if (lh2.Count == 1)
                    if (GetmaxDate(t1, max) == true)
                    // if (max=<date)
                    {
                        Car c2 = dalc.LoadCar(LHpl[l].CarID, userID);
                        MessageBox.Show("تمدید پلاک " + " " + c2.number.Trim() + " " + c2.Type.Trim() + " " + "منفضی شده است");
                    }
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label13.Text = "";
            // Export all the details
            try
            {
                DataTable dtpersonListe = dalpl.LoadPlateListFORExcel(userID);
                RKLib.ExportData.Export objExport = new RKLib.ExportData.Export("Win");
                objExport.ExportDetails(dtpersonListe, Export.ExportFormat.Excel, "D:\\InsuranceInfo.xls");
                //txtnumber.Text = "گزارشگيري در مسير D:\\EmployeesInfo.xls با موفقيت انجام شد";
                label13.Text = "گزارشگيري D:\\InsuranceInfo.xls با موفقيت انجام شد";
            }
            catch (Exception Ex)
            {
                label13.Text = "گزارشگيري انجام نشد";
            }
        }

    }
}
