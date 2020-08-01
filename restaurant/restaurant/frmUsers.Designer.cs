namespace restaurant
{
    partial class frmUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.btnOtherInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnOK = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.gridUser = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.checkTower = new System.Windows.Forms.CheckBox();
            this.checkAccounting = new System.Windows.Forms.CheckBox();
            this.checkControls = new System.Windows.Forms.CheckBox();
            this.checkDocumentsDebt = new System.Windows.Forms.CheckBox();
            this.checkDocumentGet = new System.Windows.Forms.CheckBox();
            this.checkDocumentPay = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comQuestion = new System.Windows.Forms.ComboBox();
            this.txNewPass2 = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbOldUserName = new System.Windows.Forms.Label();
            this.txNewPass = new System.Windows.Forms.TextBox();
            this.lblOldPass = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClear.Size = new System.Drawing.Size(48, 22);
            this.btnClear.Text = "جدید";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOtherInfo
            // 
            this.btnOtherInfo.Name = "btnOtherInfo";
            this.btnOtherInfo.Size = new System.Drawing.Size(152, 22);
            this.btnOtherInfo.Text = "سایر مشخصات";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOtherInfo});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 22);
            this.btnCancel.Text = "حذف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnOK.Enabled = false;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(65, 22);
            this.btnOK.Text = "  ثبت  ";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOK,
            this.btnCancel,
            this.toolStripDropDownButton1,
            this.btnEdit,
            this.btnClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 435);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(600, 25);
            this.toolStrip1.TabIndex = 33;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnEdit
            // 
            this.btnEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEdit.Size = new System.Drawing.Size(58, 22);
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // gridUser
            // 
            this.gridUser.AllowUserToAddRows = false;
            this.gridUser.AllowUserToDeleteRows = false;
            this.gridUser.AllowUserToResizeColumns = false;
            this.gridUser.AllowUserToResizeRows = false;
            this.gridUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridUser.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUser.Location = new System.Drawing.Point(12, 196);
            this.gridUser.Name = "gridUser";
            this.gridUser.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridUser.RowHeadersVisible = false;
            this.gridUser.RowTemplate.Height = 23;
            this.gridUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUser.Size = new System.Drawing.Size(568, 216);
            this.gridUser.TabIndex = 30;
            this.gridUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridUser_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(449, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "لیست کاربرهای ثبت شده";
            // 
            // checkTower
            // 
            this.checkTower.AutoSize = true;
            this.checkTower.Location = new System.Drawing.Point(365, 76);
            this.checkTower.Name = "checkTower";
            this.checkTower.Size = new System.Drawing.Size(81, 17);
            this.checkTower.TabIndex = 5;
            this.checkTower.Text = "اطلاعات برج";
            this.checkTower.UseVisualStyleBackColor = true;
            // 
            // checkAccounting
            // 
            this.checkAccounting.AutoSize = true;
            this.checkAccounting.Location = new System.Drawing.Point(372, 102);
            this.checkAccounting.Name = "checkAccounting";
            this.checkAccounting.Size = new System.Drawing.Size(74, 17);
            this.checkAccounting.TabIndex = 6;
            this.checkAccounting.Text = "حسابداری";
            this.checkAccounting.UseVisualStyleBackColor = true;
            // 
            // checkControls
            // 
            this.checkControls.AutoSize = true;
            this.checkControls.Location = new System.Drawing.Point(348, 125);
            this.checkControls.Name = "checkControls";
            this.checkControls.Size = new System.Drawing.Size(98, 17);
            this.checkControls.TabIndex = 7;
            this.checkControls.Text = "اطلاعات کنترلی";
            this.checkControls.UseVisualStyleBackColor = true;
            // 
            // checkDocumentsDebt
            // 
            this.checkDocumentsDebt.AutoSize = true;
            this.checkDocumentsDebt.Location = new System.Drawing.Point(243, 77);
            this.checkDocumentsDebt.Name = "checkDocumentsDebt";
            this.checkDocumentsDebt.Size = new System.Drawing.Size(95, 17);
            this.checkDocumentsDebt.TabIndex = 8;
            this.checkDocumentsDebt.Text = "اسناد بدهکاری";
            this.checkDocumentsDebt.UseVisualStyleBackColor = true;
            this.checkDocumentsDebt.Visible = false;
            // 
            // checkDocumentGet
            // 
            this.checkDocumentGet.AutoSize = true;
            this.checkDocumentGet.Location = new System.Drawing.Point(257, 102);
            this.checkDocumentGet.Name = "checkDocumentGet";
            this.checkDocumentGet.Size = new System.Drawing.Size(80, 17);
            this.checkDocumentGet.TabIndex = 9;
            this.checkDocumentGet.Text = "سند دریافت";
            this.checkDocumentGet.UseVisualStyleBackColor = true;
            this.checkDocumentGet.Visible = false;
            // 
            // checkDocumentPay
            // 
            this.checkDocumentPay.AutoSize = true;
            this.checkDocumentPay.Location = new System.Drawing.Point(255, 125);
            this.checkDocumentPay.Name = "checkDocumentPay";
            this.checkDocumentPay.Size = new System.Drawing.Size(83, 17);
            this.checkDocumentPay.TabIndex = 10;
            this.checkDocumentPay.Text = "سند پرداخت";
            this.checkDocumentPay.UseVisualStyleBackColor = true;
            this.checkDocumentPay.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(457, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "دسترسی های مجاز:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(395, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(211, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(523, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "سوال  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "پاسخ ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "تکرارکلمه رمز";
            // 
            // comQuestion
            // 
            this.comQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comQuestion.FormattingEnabled = true;
            this.comQuestion.Location = new System.Drawing.Point(225, 45);
            this.comQuestion.Name = "comQuestion";
            this.comQuestion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comQuestion.Size = new System.Drawing.Size(284, 21);
            this.comQuestion.TabIndex = 3;
            // 
            // txNewPass2
            // 
            this.txNewPass2.Location = new System.Drawing.Point(17, 18);
            this.txNewPass2.MaxLength = 10;
            this.txNewPass2.Name = "txNewPass2";
            this.txNewPass2.PasswordChar = '*';
            this.txNewPass2.Size = new System.Drawing.Size(109, 21);
            this.txNewPass2.TabIndex = 2;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(410, 18);
            this.txtUserName.MaxLength = 10;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(101, 21);
            this.txtUserName.TabIndex = 0;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnswer.Location = new System.Drawing.Point(17, 45);
            this.txtAnswer.MaxLength = 50;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAnswer.Size = new System.Drawing.Size(109, 21);
            this.txtAnswer.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkTower);
            this.groupBox1.Controls.Add(this.checkAccounting);
            this.groupBox1.Controls.Add(this.checkControls);
            this.groupBox1.Controls.Add(this.checkDocumentsDebt);
            this.groupBox1.Controls.Add(this.checkDocumentGet);
            this.groupBox1.Controls.Add(this.checkDocumentPay);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comQuestion);
            this.groupBox1.Controls.Add(this.txNewPass2);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.lbOldUserName);
            this.groupBox1.Controls.Add(this.txtAnswer);
            this.groupBox1.Controls.Add(this.txNewPass);
            this.groupBox1.Controls.Add(this.lblOldPass);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(568, 155);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "کاربر جدید";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(4, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(4, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "*";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(17, 75);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(109, 67);
            this.txtDesc.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "توضیحات";
            // 
            // lbOldUserName
            // 
            this.lbOldUserName.AutoSize = true;
            this.lbOldUserName.Location = new System.Drawing.Point(519, 21);
            this.lbOldUserName.Name = "lbOldUserName";
            this.lbOldUserName.Size = new System.Drawing.Size(43, 13);
            this.lbOldUserName.TabIndex = 4;
            this.lbOldUserName.Text = "نام کاربر";
            // 
            // txNewPass
            // 
            this.txNewPass.Location = new System.Drawing.Point(227, 18);
            this.txNewPass.MaxLength = 10;
            this.txNewPass.Name = "txNewPass";
            this.txNewPass.PasswordChar = '*';
            this.txNewPass.Size = new System.Drawing.Size(105, 21);
            this.txNewPass.TabIndex = 1;
            // 
            // lblOldPass
            // 
            this.lblOldPass.AutoSize = true;
            this.lblOldPass.Location = new System.Drawing.Point(335, 21);
            this.lblOldPass.Name = "lblOldPass";
            this.lblOldPass.Size = new System.Drawing.Size(50, 13);
            this.lblOldPass.TabIndex = 2;
            this.lblOldPass.Text = "کلمه رمز ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 460);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gridUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmUsers";
            this.Text = "frmUsers";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripMenuItem btnOtherInfo;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripButton btnOK;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.DataGridView gridUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkTower;
        private System.Windows.Forms.CheckBox checkAccounting;
        private System.Windows.Forms.CheckBox checkControls;
        private System.Windows.Forms.CheckBox checkDocumentsDebt;
        private System.Windows.Forms.CheckBox checkDocumentGet;
        private System.Windows.Forms.CheckBox checkDocumentPay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comQuestion;
        private System.Windows.Forms.TextBox txNewPass2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbOldUserName;
        private System.Windows.Forms.TextBox txNewPass;
        private System.Windows.Forms.Label lblOldPass;
        private System.Windows.Forms.Label label1;
    }
}