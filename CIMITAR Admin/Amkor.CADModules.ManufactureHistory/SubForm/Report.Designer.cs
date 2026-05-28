namespace Amkor.CADModules.ManufactureHistory.SubForm
{
	// Token: 0x02000012 RID: 18
	public partial class Report : global::ATDFW.Controls.BaseWinForm.BaseWinView
	{
		// Token: 0x0600007C RID: 124 RVA: 0x0000C860 File Offset: 0x0000AA60
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000C898 File Offset: 0x0000AA98
		private void InitializeComponent()
		{
			this.panel18 = new global::System.Windows.Forms.Panel();
			this.Panel99 = new global::System.Windows.Forms.Panel();
			this.pbClear = new global::System.Windows.Forms.PictureBox();
			this.pbSubmit = new global::System.Windows.Forms.PictureBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.panel13 = new global::System.Windows.Forms.Panel();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.panel12 = new global::System.Windows.Forms.Panel();
			this.rbContent1 = new global::System.Windows.Forms.RichTextBox();
			this.panel15 = new global::System.Windows.Forms.Panel();
			this.groupbax2 = new global::System.Windows.Forms.GroupBox();
			this.panel19 = new global::System.Windows.Forms.Panel();
			this.pbAdd = new global::System.Windows.Forms.PictureBox();
			this.panel21 = new global::System.Windows.Forms.Panel();
			this.pbDalete = new global::System.Windows.Forms.PictureBox();
			this.dgFailAtacth = new global::System.Windows.Forms.DataGridView();
			this.label10 = new global::System.Windows.Forms.Label();
			this.panel14 = new global::System.Windows.Forms.Panel();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.panel20 = new global::System.Windows.Forms.Panel();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.pbLogin = new global::System.Windows.Forms.PictureBox();
			this.panel11 = new global::System.Windows.Forms.Panel();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.pnMC = new global::System.Windows.Forms.Panel();
			this.cbMachine = new global::System.Windows.Forms.ComboBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.panel17 = new global::System.Windows.Forms.Panel();
			this.cbNickName = new global::System.Windows.Forms.ComboBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.panel16 = new global::System.Windows.Forms.Panel();
			this.cbCustList = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.panel10 = new global::System.Windows.Forms.Panel();
			this.cbOperation = new global::System.Windows.Forms.ComboBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.pnRsc = new global::System.Windows.Forms.Panel();
			this.tbRsc = new global::System.Windows.Forms.TextBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.pnModel = new global::System.Windows.Forms.Panel();
			this.tbModel = new global::System.Windows.Forms.TextBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.cbCategory = new global::System.Windows.Forms.ComboBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.tbTeam = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.tbName = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			this.Panel99.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbClear).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbSubmit).BeginInit();
			this.panel1.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel15.SuspendLayout();
			this.groupbax2.SuspendLayout();
			this.panel19.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbAdd).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbDalete).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.dgFailAtacth).BeginInit();
			this.panel14.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel20.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pbLogin).BeginInit();
			this.panel11.SuspendLayout();
			this.panel9.SuspendLayout();
			this.pnMC.SuspendLayout();
			this.panel17.SuspendLayout();
			this.panel16.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel5.SuspendLayout();
			this.pnRsc.SuspendLayout();
			this.pnModel.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel6.SuspendLayout();
			base.SuspendLayout();
			this.panel18.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel18.Location = new global::System.Drawing.Point(1287, 0);
			this.panel18.Name = "panel18";
			this.panel18.Size = new global::System.Drawing.Size(23, 47);
			this.panel18.TabIndex = 40;
			this.Panel99.Controls.Add(this.pbClear);
			this.Panel99.Controls.Add(this.panel18);
			this.Panel99.Controls.Add(this.pbSubmit);
			this.Panel99.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.Panel99.Location = new global::System.Drawing.Point(0, 515);
			this.Panel99.Margin = new global::System.Windows.Forms.Padding(0);
			this.Panel99.Name = "Panel99";
			this.Panel99.Size = new global::System.Drawing.Size(1358, 47);
			this.Panel99.TabIndex = 75;
			this.pbClear.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbClear.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbClear.Image = global::Amkor.CADModules.ManufactureHistory.Properties.Resources.clear;
			this.pbClear.Location = new global::System.Drawing.Point(1239, 0);
			this.pbClear.Name = "pbClear";
			this.pbClear.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbClear.Size = new global::System.Drawing.Size(48, 47);
			this.pbClear.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbClear.TabIndex = 41;
			this.pbClear.TabStop = false;
			this.pbClear.Click += new global::System.EventHandler(this.pbClear_Click);
			this.pbClear.MouseEnter += new global::System.EventHandler(this.pbClear_MouseEnter);
			this.pbClear.MouseLeave += new global::System.EventHandler(this.pbClear_MouseLeave);
			this.pbSubmit.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbSubmit.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbSubmit.Image = global::Amkor.CADModules.ManufactureHistory.Properties.Resources.submit;
			this.pbSubmit.Location = new global::System.Drawing.Point(1310, 0);
			this.pbSubmit.Name = "pbSubmit";
			this.pbSubmit.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbSubmit.Size = new global::System.Drawing.Size(48, 47);
			this.pbSubmit.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbSubmit.TabIndex = 10;
			this.pbSubmit.TabStop = false;
			this.pbSubmit.Click += new global::System.EventHandler(this.pbSubmit_Click);
			this.pbSubmit.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.pbSubmit_MouseClick);
			this.pbSubmit.MouseEnter += new global::System.EventHandler(this.pbClear_MouseEnter);
			this.pbSubmit.MouseLeave += new global::System.EventHandler(this.pbClear_MouseLeave);
			this.panel1.Controls.Add(this.panel13);
			this.panel1.Controls.Add(this.Panel99);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1358, 562);
			this.panel1.TabIndex = 73;
			this.panel13.Controls.Add(this.panel3);
			this.panel13.Controls.Add(this.panel15);
			this.panel13.Controls.Add(this.panel14);
			this.panel13.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel13.Location = new global::System.Drawing.Point(0, 0);
			this.panel13.Name = "panel13";
			this.panel13.Size = new global::System.Drawing.Size(1358, 515);
			this.panel13.TabIndex = 76;
			this.panel3.Controls.Add(this.panel12);
			this.panel3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new global::System.Drawing.Point(0, 116);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(1017, 399);
			this.panel3.TabIndex = 43;
			this.panel12.Controls.Add(this.rbContent1);
			this.panel12.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel12.Location = new global::System.Drawing.Point(0, 0);
			this.panel12.Name = "panel12";
			this.panel12.Size = new global::System.Drawing.Size(1017, 399);
			this.panel12.TabIndex = 72;
			this.rbContent1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.rbContent1.Font = new global::System.Drawing.Font("굴림", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 129);
			this.rbContent1.Location = new global::System.Drawing.Point(0, 0);
			this.rbContent1.Name = "rbContent1";
			this.rbContent1.Size = new global::System.Drawing.Size(1017, 399);
			this.rbContent1.TabIndex = 12;
			this.rbContent1.TabStop = false;
			this.rbContent1.Text = "※고장 내역 / 정비 내역을 자세히 기입해주세요.";
			this.rbContent1.Click += new global::System.EventHandler(this.rbContent1_Click);
			this.panel15.Controls.Add(this.groupbax2);
			this.panel15.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel15.Location = new global::System.Drawing.Point(1017, 116);
			this.panel15.Name = "panel15";
			this.panel15.Size = new global::System.Drawing.Size(341, 399);
			this.panel15.TabIndex = 44;
			this.groupbax2.Controls.Add(this.panel19);
			this.groupbax2.Controls.Add(this.dgFailAtacth);
			this.groupbax2.Controls.Add(this.label10);
			this.groupbax2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupbax2.Location = new global::System.Drawing.Point(0, 0);
			this.groupbax2.Name = "groupbax2";
			this.groupbax2.Size = new global::System.Drawing.Size(341, 225);
			this.groupbax2.TabIndex = 74;
			this.groupbax2.TabStop = false;
			this.groupbax2.Text = "Attachment File";
			this.panel19.Controls.Add(this.pbAdd);
			this.panel19.Controls.Add(this.panel21);
			this.panel19.Controls.Add(this.pbDalete);
			this.panel19.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel19.Location = new global::System.Drawing.Point(3, 182);
			this.panel19.Name = "panel19";
			this.panel19.Size = new global::System.Drawing.Size(335, 40);
			this.panel19.TabIndex = 43;
			this.pbAdd.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbAdd.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbAdd.Image = global::Amkor.CADModules.ManufactureHistory.Properties.Resources.add;
			this.pbAdd.Location = new global::System.Drawing.Point(241, 0);
			this.pbAdd.Name = "pbAdd";
			this.pbAdd.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbAdd.Size = new global::System.Drawing.Size(35, 40);
			this.pbAdd.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbAdd.TabIndex = 41;
			this.pbAdd.TabStop = false;
			this.pbAdd.Click += new global::System.EventHandler(this.pbAdd_Click);
			this.panel21.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.panel21.Location = new global::System.Drawing.Point(276, 0);
			this.panel21.Name = "panel21";
			this.panel21.Size = new global::System.Drawing.Size(24, 40);
			this.panel21.TabIndex = 43;
			this.pbDalete.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbDalete.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.pbDalete.Image = global::Amkor.CADModules.ManufactureHistory.Properties.Resources.minus;
			this.pbDalete.Location = new global::System.Drawing.Point(300, 0);
			this.pbDalete.Name = "pbDalete";
			this.pbDalete.Padding = new global::System.Windows.Forms.Padding(3);
			this.pbDalete.Size = new global::System.Drawing.Size(35, 40);
			this.pbDalete.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbDalete.TabIndex = 42;
			this.pbDalete.TabStop = false;
			this.pbDalete.Click += new global::System.EventHandler(this.pbDalete_Click);
			this.dgFailAtacth.AllowUserToDeleteRows = false;
			this.dgFailAtacth.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgFailAtacth.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.dgFailAtacth.Location = new global::System.Drawing.Point(3, 34);
			this.dgFailAtacth.MultiSelect = false;
			this.dgFailAtacth.Name = "dgFailAtacth";
			this.dgFailAtacth.ReadOnly = true;
			this.dgFailAtacth.RowTemplate.Height = 23;
			this.dgFailAtacth.Size = new global::System.Drawing.Size(335, 108);
			this.dgFailAtacth.TabIndex = 23;
			this.label10.AutoSize = true;
			this.label10.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label10.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.Location = new global::System.Drawing.Point(3, 17);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(252, 17);
			this.label10.TabIndex = 40;
			this.label10.Text = "※첨부파일 총 용량은 10MB까지 입니다.";
			this.panel14.Controls.Add(this.groupBox1);
			this.panel14.Controls.Add(this.panel2);
			this.panel14.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel14.Location = new global::System.Drawing.Point(0, 0);
			this.panel14.Name = "panel14";
			this.panel14.Size = new global::System.Drawing.Size(1358, 116);
			this.panel14.TabIndex = 3;
			this.groupBox1.Controls.Add(this.panel20);
			this.groupBox1.Controls.Add(this.panel11);
			this.groupBox1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new global::System.Drawing.Point(211, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(1147, 111);
			this.groupBox1.TabIndex = 72;
			this.groupBox1.TabStop = false;
			this.panel20.Controls.Add(this.groupBox5);
			this.panel20.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel20.Location = new global::System.Drawing.Point(857, 17);
			this.panel20.Margin = new global::System.Windows.Forms.Padding(0);
			this.panel20.Name = "panel20";
			this.panel20.Size = new global::System.Drawing.Size(287, 91);
			this.panel20.TabIndex = 92;
			this.groupBox5.Controls.Add(this.pbLogin);
			this.groupBox5.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.groupBox5.Location = new global::System.Drawing.Point(0, 0);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(75, 91);
			this.groupBox5.TabIndex = 97;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "User Info";
			this.pbLogin.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pbLogin.Image = global::Amkor.CADModules.ManufactureHistory.Properties.Resources.login;
			this.pbLogin.Location = new global::System.Drawing.Point(20, 22);
			this.pbLogin.Name = "pbLogin";
			this.pbLogin.Size = new global::System.Drawing.Size(44, 44);
			this.pbLogin.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbLogin.TabIndex = 10;
			this.pbLogin.TabStop = false;
			this.pbLogin.Click += new global::System.EventHandler(this.pbLogin_Click);
			this.pbLogin.MouseEnter += new global::System.EventHandler(this.pbClear_MouseEnter);
			this.pbLogin.MouseLeave += new global::System.EventHandler(this.pbClear_MouseLeave);
			this.panel11.Controls.Add(this.panel9);
			this.panel11.Controls.Add(this.panel5);
			this.panel11.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel11.Location = new global::System.Drawing.Point(3, 17);
			this.panel11.Name = "panel11";
			this.panel11.Size = new global::System.Drawing.Size(854, 91);
			this.panel11.TabIndex = 91;
			this.panel9.Controls.Add(this.pnMC);
			this.panel9.Controls.Add(this.panel17);
			this.panel9.Controls.Add(this.panel16);
			this.panel9.Controls.Add(this.panel10);
			this.panel9.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel9.Location = new global::System.Drawing.Point(0, 50);
			this.panel9.Name = "panel9";
			this.panel9.Size = new global::System.Drawing.Size(854, 41);
			this.panel9.TabIndex = 90;
			this.pnMC.Controls.Add(this.cbMachine);
			this.pnMC.Controls.Add(this.label5);
			this.pnMC.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnMC.Location = new global::System.Drawing.Point(636, 0);
			this.pnMC.Name = "pnMC";
			this.pnMC.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.pnMC.Size = new global::System.Drawing.Size(212, 41);
			this.pnMC.TabIndex = 92;
			this.cbMachine.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbMachine.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMachine.Font = new global::System.Drawing.Font("Segoe UI", 9f);
			this.cbMachine.FormattingEnabled = true;
			this.cbMachine.Location = new global::System.Drawing.Point(0, 17);
			this.cbMachine.Name = "cbMachine";
			this.cbMachine.Size = new global::System.Drawing.Size(209, 23);
			this.cbMachine.TabIndex = 8;
			this.cbMachine.SelectedIndexChanged += new global::System.EventHandler(this.cbMachine_SelectedIndexChanged);
			this.label5.AutoSize = true;
			this.label5.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label5.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label5.Location = new global::System.Drawing.Point(0, 0);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(45, 17);
			this.label5.TabIndex = 7;
			this.label5.Text = "M/C #";
			this.panel17.Controls.Add(this.cbNickName);
			this.panel17.Controls.Add(this.label7);
			this.panel17.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel17.Location = new global::System.Drawing.Point(424, 0);
			this.panel17.Name = "panel17";
			this.panel17.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel17.Size = new global::System.Drawing.Size(212, 41);
			this.panel17.TabIndex = 93;
			this.cbNickName.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbNickName.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbNickName.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbNickName.Location = new global::System.Drawing.Point(0, 17);
			this.cbNickName.Name = "cbNickName";
			this.cbNickName.Size = new global::System.Drawing.Size(209, 23);
			this.cbNickName.TabIndex = 16;
			this.cbNickName.TabStop = false;
			this.label7.AutoSize = true;
			this.label7.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label7.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label7.Location = new global::System.Drawing.Point(0, 0);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(68, 17);
			this.label7.TabIndex = 15;
			this.label7.Text = "NickName";
			this.panel16.Controls.Add(this.cbCustList);
			this.panel16.Controls.Add(this.label2);
			this.panel16.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel16.Location = new global::System.Drawing.Point(212, 0);
			this.panel16.Name = "panel16";
			this.panel16.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel16.Size = new global::System.Drawing.Size(212, 41);
			this.panel16.TabIndex = 92;
			this.cbCustList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbCustList.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCustList.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbCustList.Location = new global::System.Drawing.Point(0, 17);
			this.cbCustList.Name = "cbCustList";
			this.cbCustList.Size = new global::System.Drawing.Size(209, 23);
			this.cbCustList.TabIndex = 16;
			this.cbCustList.TabStop = false;
			this.cbCustList.SelectedIndexChanged += new global::System.EventHandler(this.cbCustList_SelectedIndexChanged);
			this.label2.AutoSize = true;
			this.label2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label2.Location = new global::System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(64, 17);
			this.label2.TabIndex = 15;
			this.label2.Text = "Customer";
			this.panel10.Controls.Add(this.cbOperation);
			this.panel10.Controls.Add(this.label6);
			this.panel10.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel10.Location = new global::System.Drawing.Point(0, 0);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel10.Size = new global::System.Drawing.Size(212, 41);
			this.panel10.TabIndex = 91;
			this.cbOperation.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbOperation.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOperation.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbOperation.Location = new global::System.Drawing.Point(0, 17);
			this.cbOperation.Name = "cbOperation";
			this.cbOperation.Size = new global::System.Drawing.Size(209, 23);
			this.cbOperation.TabIndex = 16;
			this.cbOperation.TabStop = false;
			this.label6.AutoSize = true;
			this.label6.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label6.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label6.Location = new global::System.Drawing.Point(0, 0);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(67, 17);
			this.label6.TabIndex = 15;
			this.label6.Text = "Operation";
			this.panel5.Controls.Add(this.pnRsc);
			this.panel5.Controls.Add(this.pnModel);
			this.panel5.Controls.Add(this.panel7);
			this.panel5.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new global::System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(854, 50);
			this.panel5.TabIndex = 89;
			this.pnRsc.Controls.Add(this.tbRsc);
			this.pnRsc.Controls.Add(this.label8);
			this.pnRsc.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnRsc.Location = new global::System.Drawing.Point(424, 0);
			this.pnRsc.Name = "pnRsc";
			this.pnRsc.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.pnRsc.Size = new global::System.Drawing.Size(184, 50);
			this.pnRsc.TabIndex = 91;
			this.tbRsc.BackColor = global::System.Drawing.Color.Gainsboro;
			this.tbRsc.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tbRsc.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tbRsc.Location = new global::System.Drawing.Point(0, 17);
			this.tbRsc.Name = "tbRsc";
			this.tbRsc.ReadOnly = true;
			this.tbRsc.Size = new global::System.Drawing.Size(181, 23);
			this.tbRsc.TabIndex = 67;
			this.tbRsc.TabStop = false;
			this.label8.AutoSize = true;
			this.label8.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label8.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label8.Location = new global::System.Drawing.Point(0, 0);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(54, 17);
			this.label8.TabIndex = 13;
			this.label8.Text = "Rsc Dec";
			this.pnModel.Controls.Add(this.tbModel);
			this.pnModel.Controls.Add(this.label9);
			this.pnModel.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.pnModel.Location = new global::System.Drawing.Point(212, 0);
			this.pnModel.Name = "pnModel";
			this.pnModel.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.pnModel.Size = new global::System.Drawing.Size(212, 50);
			this.pnModel.TabIndex = 90;
			this.tbModel.BackColor = global::System.Drawing.Color.Gainsboro;
			this.tbModel.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tbModel.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tbModel.Location = new global::System.Drawing.Point(0, 17);
			this.tbModel.Name = "tbModel";
			this.tbModel.ReadOnly = true;
			this.tbModel.Size = new global::System.Drawing.Size(209, 23);
			this.tbModel.TabIndex = 16;
			this.tbModel.TabStop = false;
			this.label9.AutoSize = true;
			this.label9.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label9.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label9.Location = new global::System.Drawing.Point(0, 0);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(46, 17);
			this.label9.TabIndex = 15;
			this.label9.Text = "Model";
			this.panel7.Controls.Add(this.cbCategory);
			this.panel7.Controls.Add(this.label4);
			this.panel7.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel7.Location = new global::System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new global::System.Windows.Forms.Padding(3, 0, 3, 0);
			this.panel7.Size = new global::System.Drawing.Size(212, 50);
			this.panel7.TabIndex = 89;
			this.cbCategory.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.cbCategory.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCategory.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbCategory.Location = new global::System.Drawing.Point(3, 17);
			this.cbCategory.Name = "cbCategory";
			this.cbCategory.Size = new global::System.Drawing.Size(206, 23);
			this.cbCategory.TabIndex = 6;
			this.cbCategory.TabStop = false;
			this.cbCategory.SelectedIndexChanged += new global::System.EventHandler(this.cbCategory_SelectedIndexChanged);
			this.label4.AutoSize = true;
			this.label4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label4.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label4.Location = new global::System.Drawing.Point(3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(61, 17);
			this.label4.TabIndex = 5;
			this.label4.Text = "Category";
			this.panel2.Controls.Add(this.groupBox3);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new global::System.Windows.Forms.Padding(3, 0, 3, 3);
			this.panel2.Size = new global::System.Drawing.Size(211, 116);
			this.panel2.TabIndex = 71;
			this.groupBox3.Controls.Add(this.panel8);
			this.groupBox3.Controls.Add(this.panel4);
			this.groupBox3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new global::System.Drawing.Point(3, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(205, 113);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.panel8.Controls.Add(this.tbTeam);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel8.Location = new global::System.Drawing.Point(3, 67);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel8.Size = new global::System.Drawing.Size(199, 43);
			this.panel8.TabIndex = 94;
			this.tbTeam.BackColor = global::System.Drawing.Color.Gainsboro;
			this.tbTeam.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tbTeam.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tbTeam.Location = new global::System.Drawing.Point(0, 17);
			this.tbTeam.Name = "tbTeam";
			this.tbTeam.ReadOnly = true;
			this.tbTeam.Size = new global::System.Drawing.Size(196, 23);
			this.tbTeam.TabIndex = 16;
			this.tbTeam.TabStop = false;
			this.label3.AutoSize = true;
			this.label3.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label3.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label3.Location = new global::System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(39, 17);
			this.label3.TabIndex = 15;
			this.label3.Text = "Dept.";
			this.panel4.Controls.Add(this.panel6);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new global::System.Drawing.Point(3, 17);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(199, 50);
			this.panel4.TabIndex = 3;
			this.panel6.Controls.Add(this.tbName);
			this.panel6.Controls.Add(this.label1);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new global::System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.panel6.Size = new global::System.Drawing.Size(199, 50);
			this.panel6.TabIndex = 92;
			this.tbName.BackColor = global::System.Drawing.Color.Gainsboro;
			this.tbName.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tbName.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.tbName.Location = new global::System.Drawing.Point(0, 17);
			this.tbName.Name = "tbName";
			this.tbName.ReadOnly = true;
			this.tbName.Size = new global::System.Drawing.Size(196, 23);
			this.tbName.TabIndex = 16;
			this.tbName.TabStop = false;
			this.label1.AutoSize = true;
			this.label1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Symbol", 9.75f);
			this.label1.Location = new global::System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(43, 17);
			this.label1.TabIndex = 15;
			this.label1.Text = "Name";
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(1358, 562);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Report";
			this.Text = "History";
			base.Shown += new global::System.EventHandler(this.Report_Shown);
			this.Panel99.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbClear).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbSubmit).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel15.ResumeLayout(false);
			this.groupbax2.ResumeLayout(false);
			this.groupbax2.PerformLayout();
			this.panel19.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbAdd).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pbDalete).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.dgFailAtacth).EndInit();
			this.panel14.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel20.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pbLogin).EndInit();
			this.panel11.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.pnMC.ResumeLayout(false);
			this.pnMC.PerformLayout();
			this.panel17.ResumeLayout(false);
			this.panel17.PerformLayout();
			this.panel16.ResumeLayout(false);
			this.panel16.PerformLayout();
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.pnRsc.ResumeLayout(false);
			this.pnRsc.PerformLayout();
			this.pnModel.ResumeLayout(false);
			this.pnModel.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400008F RID: 143
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.PictureBox pbClear;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.Panel panel18;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.PictureBox pbSubmit;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.Panel Panel99;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.OpenFileDialog openFileDialog;

		// Token: 0x04000096 RID: 150
		private global::System.Windows.Forms.Panel panel13;

		// Token: 0x04000097 RID: 151
		private global::System.Windows.Forms.Panel panel12;

		// Token: 0x04000098 RID: 152
		private global::System.Windows.Forms.RichTextBox rbContent1;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.Panel panel15;

		// Token: 0x0400009A RID: 154
		private global::System.Windows.Forms.GroupBox groupbax2;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.Panel panel19;

		// Token: 0x0400009C RID: 156
		private global::System.Windows.Forms.PictureBox pbAdd;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.Panel panel21;

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.PictureBox pbDalete;

		// Token: 0x0400009F RID: 159
		private global::System.Windows.Forms.DataGridView dgFailAtacth;

		// Token: 0x040000A0 RID: 160
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.Panel panel14;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.Panel panel10;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.Panel pnRsc;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.TextBox tbRsc;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.Label label8;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.Panel pnModel;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.TextBox tbModel;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.Label label9;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.Panel pnMC;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040000AF RID: 175
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.ComboBox cbCategory;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.TextBox tbTeam;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.TextBox tbName;

		// Token: 0x040000BA RID: 186
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.ComboBox cbOperation;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.Panel panel16;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.ComboBox cbCustList;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.Panel panel17;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.ComboBox cbNickName;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.ComboBox cbMachine;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.Panel panel20;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.PictureBox pbLogin;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.Panel panel11;
	}
}
