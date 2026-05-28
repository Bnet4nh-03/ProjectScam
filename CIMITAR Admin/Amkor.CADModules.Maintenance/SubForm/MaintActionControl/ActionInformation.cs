using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.Properties;
using Amkor.CADModules.Maintenance.SubForm.SubControl;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.MaintActionControl
{
	// Token: 0x02000048 RID: 72
	public class ActionInformation : UserControl
	{
		// Token: 0x06000412 RID: 1042 RVA: 0x00077D5C File Offset: 0x00075F5C
		public ActionInformation(FactorySettings factorySettings, cReportItem report)
		{
			this._factorySettings = factorySettings;
			this._report = report;
			this.InitializeComponent();
			this.pnHoldInformation.Visible = false;
			this.tbRequestTime.Text = report.sRequestTime;
			this.tbEndTime.Text = report.sEndTime;
			bool flag = report.sCategory == "HCC";
			if (flag)
			{
				this.pnDifficulty.Visible = false;
			}
			else
			{
				this.pnDifficulty.Visible = true;
			}
			cFunction.getCaseList(this.cbCase, false);
			this.cbDifficulty.Items.Clear();
			this.cbDifficulty.Items.Add("Beginning Level(Level-1)");
			this.cbDifficulty.Items.Add("Intermediate Level(Level-2)");
			this.cbDifficulty.Items.Add("Advanced Level(Level-3)");
			this.cbDifficulty.Items.Add("Expert Leve(Level-4)");
			bool flag2 = report.sReportStauts.Trim() == "1" || report.sReportStauts.Trim() == "3";
			if (flag2)
			{
				cFunction.getFactorList(this._factorySettings, this.cbFactor, report.sCategory, report.sFactory, this._FactorList, false);
				bool flag3 = !string.IsNullOrEmpty(report.sCase);
				if (flag3)
				{
					this.cbCase.SelectedIndex = this.cbCase.Items.IndexOf(report.sCase);
					this.cbCase_SelectedIndexChanged(null, null);
				}
				bool flag4 = string.IsNullOrEmpty(report.sHoldTime);
				if (flag4)
				{
					this.dtStartPicker.Value = Convert.ToDateTime(report.sRequestTime);
				}
				else
				{
					this.dtStartPicker.Value = Convert.ToDateTime(report.sHoldTime);
				}
			}
			else
			{
				bool flag5 = report.sReportStauts.Trim() == "2";
				if (flag5)
				{
					this.cbCase.Text = this._report.sCase;
					this.cbFactor.Items.Clear();
					this.cbFactor.Items.Add(this._report.sFactor);
					this.cbFactor.Text = report.sFactor;
					bool flag6 = this.pnFactor.Width < report.sFactor.Length * (int)this.cbFactor.Font.Size;
					if (flag6)
					{
						this.pnFactor.Width = report.sFactor.Length * (int)this.cbFactor.Font.Size;
					}
					this.dtStartPicker.Value = Convert.ToDateTime(report.sStartTime);
					this.downTimeAutoCalc();
				}
			}
			bool flag7 = this._report.sReportStauts.CompareTo("1") == 0;
			if (flag7)
			{
				bool enabled = true;
				this.dtStartPicker.Enabled = enabled;
				this.cbDifficulty.Enabled = enabled;
				this.cbFactor.Enabled = enabled;
				this.cbCase.Enabled = enabled;
			}
			else
			{
				bool flag8 = this._report.sReportStauts.CompareTo("2") == 0;
				if (flag8)
				{
					bool enabled = false;
					this.dtStartPicker.Enabled = enabled;
					this.cbDifficulty.Enabled = enabled;
					this.cbFactor.Enabled = enabled;
					this.cbCase.Enabled = enabled;
					bool flag9 = !string.IsNullOrEmpty(this._report.sHoldName);
					if (flag9)
					{
						this.pnHoldInformation.Visible = true;
					}
					else
					{
						this.pnHoldInformation.Visible = false;
					}
				}
				else
				{
					bool flag10 = this._report.sReportStauts.CompareTo("3") == 0;
					if (flag10)
					{
						bool enabled = true;
						this.dtStartPicker.Enabled = enabled;
						this.cbDifficulty.Enabled = enabled;
						this.cbFactor.Enabled = enabled;
						this.cbCase.Enabled = enabled;
						this.pnHoldInformation.Visible = true;
					}
				}
			}
			this.cbDifficulty.SelectedItem = report.sMaintLevel;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x000781A0 File Offset: 0x000763A0
		public void downTimeAutoCalc()
		{
			bool flag = this.dtStartPicker.Value.ToString().Trim() != string.Empty && this.tbEndTime.Text.Trim() != string.Empty && this.tbRequestTime.Text.Trim() != string.Empty;
			if (flag)
			{
				DateTime dateTime = Convert.ToDateTime(this._report.sStartTime);
				DateTime dateTime2 = Convert.ToDateTime(this.tbEndTime.Text);
				DateTime dateTime3 = Convert.ToDateTime(this.tbRequestTime.Text);
				DateTime dateTime4 = new DateTime(dateTime2.Ticks - dateTime.Ticks);
				DateTime dateTime5 = new DateTime(dateTime2.Ticks - dateTime3.Ticks);
				TimeSpan timeSpan = new TimeSpan(dateTime2.Ticks - dateTime.Ticks);
				this.tbDownTimeS.Text = string.Format("{0:d2}:{1:d2}:{2:d2}", timeSpan.Days * 24 + timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
				timeSpan = new TimeSpan(dateTime2.Ticks - dateTime3.Ticks);
				this.tbDownTimeR.Text = string.Format("{0:d2}:{1:d2}:{2:d2}", timeSpan.Days * 24 + timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
			}
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x0007832C File Offset: 0x0007652C
		private void cbCase_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.cbFactor.Items.Clear();
			bool flag = this.cbCase.SelectedItem == null;
			if (!flag)
			{
				cFunction.getFactorList(this._factorySettings, this.cbFactor, this._report.sCategory, this._report.sFactory, this._FactorList, false);
				this.pnFactor.Width = this.cbCase.Width;
				foreach (KeyValuePair<string, string> keyValuePair in this._FactorList)
				{
					bool flag2 = this.cbCase.SelectedItem.ToString().ToUpper() == keyValuePair.Value;
					if (flag2)
					{
						this.cbFactor.Items.Add(keyValuePair.Key);
						bool flag3 = this.pnFactor.Width < keyValuePair.Key.Length * (int)this.cbFactor.Font.Size;
						if (flag3)
						{
							this.pnFactor.Width = keyValuePair.Key.Length * (int)this.cbFactor.Font.Size;
						}
					}
				}
			}
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0007848C File Offset: 0x0007668C
		private void pbHoldInfo_Click(object sender, EventArgs e)
		{
			this.pbHoldInfo.Image = Resources.info;
			HoldInfoForm holdInfoForm = new HoldInfoForm(this._report.sHoldTeam, this._report.sHoldName, this._report.sHoldTime, this._report.sHoldComment);
			holdInfoForm.ShowDialog();
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x000784E4 File Offset: 0x000766E4
		public void clear(cReportItem report)
		{
			this.cbCase.SelectedIndex = -1;
			this.cbFactor.Items.Clear();
			this.cbDifficulty.SelectedIndex = -1;
			bool flag = string.IsNullOrEmpty(report.sHoldTime);
			if (flag)
			{
				this.dtStartPicker.Value = Convert.ToDateTime(report.sRequestTime);
			}
			else
			{
				this.dtStartPicker.Value = Convert.ToDateTime(report.sHoldTime);
			}
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x0007855C File Offset: 0x0007675C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00078594 File Offset: 0x00076794
		private void InitializeComponent()
		{
			this.panel17 = new Panel();
			this.panel34 = new Panel();
			this.tbDownTimeS = new TextBox();
			this.label21 = new Label();
			this.panel33 = new Panel();
			this.tbDownTimeR = new TextBox();
			this.label20 = new Label();
			this.panel32 = new Panel();
			this.tbEndTime = new TextBox();
			this.label19 = new Label();
			this.panel31 = new Panel();
			this.tbRequestTime = new TextBox();
			this.label17 = new Label();
			this.panel16 = new Panel();
			this.pnHoldInformation = new Panel();
			this.panel2 = new Panel();
			this.panel1 = new Panel();
			this.pbHoldInfo = new PictureBox();
			this.panel43 = new Panel();
			this.label6 = new Label();
			this.pnDifficulty = new Panel();
			this.cbDifficulty = new ComboBox();
			this.label4 = new Label();
			this.pnFactor = new Panel();
			this.cbFactor = new ComboBox();
			this.label36 = new Label();
			this.panel19 = new Panel();
			this.cbCase = new ComboBox();
			this.label35 = new Label();
			this.panel18 = new Panel();
			this.dtStartPicker = new DateTimePicker();
			this.label1 = new Label();
			this.panel17.SuspendLayout();
			this.panel34.SuspendLayout();
			this.panel33.SuspendLayout();
			this.panel32.SuspendLayout();
			this.panel31.SuspendLayout();
			this.panel16.SuspendLayout();
			this.pnHoldInformation.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			((ISupportInitialize)this.pbHoldInfo).BeginInit();
			this.panel43.SuspendLayout();
			this.pnDifficulty.SuspendLayout();
			this.pnFactor.SuspendLayout();
			this.panel19.SuspendLayout();
			this.panel18.SuspendLayout();
			base.SuspendLayout();
			this.panel17.Controls.Add(this.panel34);
			this.panel17.Controls.Add(this.panel33);
			this.panel17.Controls.Add(this.panel32);
			this.panel17.Controls.Add(this.panel31);
			this.panel17.Dock = DockStyle.Top;
			this.panel17.Location = new Point(0, 0);
			this.panel17.Margin = new Padding(0);
			this.panel17.Name = "panel17";
			this.panel17.Size = new Size(1033, 36);
			this.panel17.TabIndex = 88;
			this.panel34.Controls.Add(this.tbDownTimeS);
			this.panel34.Controls.Add(this.label21);
			this.panel34.Dock = DockStyle.Left;
			this.panel34.Location = new Point(603, 0);
			this.panel34.Name = "panel34";
			this.panel34.Padding = new Padding(0, 0, 3, 0);
			this.panel34.Size = new Size(155, 36);
			this.panel34.TabIndex = 85;
			this.tbDownTimeS.BackColor = Color.Gainsboro;
			this.tbDownTimeS.Dock = DockStyle.Fill;
			this.tbDownTimeS.Font = new Font("굴림", 9f);
			this.tbDownTimeS.Location = new Point(0, 13);
			this.tbDownTimeS.Name = "tbDownTimeS";
			this.tbDownTimeS.ReadOnly = true;
			this.tbDownTimeS.Size = new Size(152, 21);
			this.tbDownTimeS.TabIndex = 34;
			this.label21.Dock = DockStyle.Top;
			this.label21.Font = new Font("굴림", 9f);
			this.label21.Location = new Point(0, 0);
			this.label21.Name = "label21";
			this.label21.Size = new Size(152, 13);
			this.label21.TabIndex = 33;
			this.label21.Text = "Down Time (Start)";
			this.panel33.Controls.Add(this.tbDownTimeR);
			this.panel33.Controls.Add(this.label20);
			this.panel33.Dock = DockStyle.Left;
			this.panel33.Location = new Point(433, 0);
			this.panel33.Name = "panel33";
			this.panel33.Padding = new Padding(0, 0, 3, 0);
			this.panel33.Size = new Size(170, 36);
			this.panel33.TabIndex = 84;
			this.tbDownTimeR.BackColor = Color.Gainsboro;
			this.tbDownTimeR.Dock = DockStyle.Fill;
			this.tbDownTimeR.Font = new Font("굴림", 9f);
			this.tbDownTimeR.Location = new Point(0, 13);
			this.tbDownTimeR.Name = "tbDownTimeR";
			this.tbDownTimeR.ReadOnly = true;
			this.tbDownTimeR.Size = new Size(167, 21);
			this.tbDownTimeR.TabIndex = 32;
			this.label20.Dock = DockStyle.Top;
			this.label20.Font = new Font("굴림", 9f);
			this.label20.Location = new Point(0, 0);
			this.label20.Name = "label20";
			this.label20.Size = new Size(167, 13);
			this.label20.TabIndex = 31;
			this.label20.Text = "Down Time (Request)";
			this.panel32.Controls.Add(this.tbEndTime);
			this.panel32.Controls.Add(this.label19);
			this.panel32.Dock = DockStyle.Left;
			this.panel32.Location = new Point(233, 0);
			this.panel32.Name = "panel32";
			this.panel32.Padding = new Padding(0, 0, 3, 0);
			this.panel32.Size = new Size(200, 36);
			this.panel32.TabIndex = 83;
			this.tbEndTime.BackColor = Color.Gainsboro;
			this.tbEndTime.Dock = DockStyle.Fill;
			this.tbEndTime.Font = new Font("굴림", 9f);
			this.tbEndTime.Location = new Point(0, 13);
			this.tbEndTime.Name = "tbEndTime";
			this.tbEndTime.ReadOnly = true;
			this.tbEndTime.Size = new Size(197, 21);
			this.tbEndTime.TabIndex = 30;
			this.label19.Dock = DockStyle.Top;
			this.label19.Font = new Font("굴림", 9f);
			this.label19.Location = new Point(0, 0);
			this.label19.Name = "label19";
			this.label19.Size = new Size(197, 13);
			this.label19.TabIndex = 29;
			this.label19.Text = "End Time";
			this.panel31.Controls.Add(this.tbRequestTime);
			this.panel31.Controls.Add(this.label17);
			this.panel31.Dock = DockStyle.Left;
			this.panel31.Location = new Point(0, 0);
			this.panel31.Name = "panel31";
			this.panel31.Padding = new Padding(3, 0, 3, 0);
			this.panel31.Size = new Size(233, 36);
			this.panel31.TabIndex = 36;
			this.tbRequestTime.BackColor = Color.Gainsboro;
			this.tbRequestTime.Dock = DockStyle.Fill;
			this.tbRequestTime.Font = new Font("굴림", 9f);
			this.tbRequestTime.Location = new Point(3, 13);
			this.tbRequestTime.Margin = new Padding(0);
			this.tbRequestTime.Name = "tbRequestTime";
			this.tbRequestTime.ReadOnly = true;
			this.tbRequestTime.Size = new Size(227, 21);
			this.tbRequestTime.TabIndex = 26;
			this.label17.Dock = DockStyle.Top;
			this.label17.Font = new Font("굴림", 9f);
			this.label17.Location = new Point(3, 0);
			this.label17.Name = "label17";
			this.label17.Size = new Size(227, 13);
			this.label17.TabIndex = 25;
			this.label17.Text = "Request Time";
			this.panel16.Controls.Add(this.pnHoldInformation);
			this.panel16.Controls.Add(this.pnDifficulty);
			this.panel16.Controls.Add(this.pnFactor);
			this.panel16.Controls.Add(this.panel19);
			this.panel16.Controls.Add(this.panel18);
			this.panel16.Dock = DockStyle.Top;
			this.panel16.Location = new Point(0, 36);
			this.panel16.Margin = new Padding(0);
			this.panel16.Name = "panel16";
			this.panel16.Size = new Size(1033, 35);
			this.panel16.TabIndex = 93;
			this.pnHoldInformation.Controls.Add(this.panel2);
			this.pnHoldInformation.Controls.Add(this.panel43);
			this.pnHoldInformation.Dock = DockStyle.Left;
			this.pnHoldInformation.Location = new Point(757, 0);
			this.pnHoldInformation.Name = "pnHoldInformation";
			this.pnHoldInformation.Size = new Size(109, 35);
			this.pnHoldInformation.TabIndex = 80;
			this.panel2.Controls.Add(this.panel1);
			this.panel2.Dock = DockStyle.Top;
			this.panel2.Location = new Point(0, 11);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(109, 15);
			this.panel2.TabIndex = 95;
			this.panel1.Controls.Add(this.pbHoldInfo);
			this.panel1.Dock = DockStyle.Left;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(26, 15);
			this.panel1.TabIndex = 94;
			this.pbHoldInfo.Cursor = Cursors.Hand;
			this.pbHoldInfo.Dock = DockStyle.Fill;
			this.pbHoldInfo.Image = Resources.info;
			this.pbHoldInfo.InitialImage = Resources.clear;
			this.pbHoldInfo.Location = new Point(0, 0);
			this.pbHoldInfo.Name = "pbHoldInfo";
			this.pbHoldInfo.Size = new Size(26, 15);
			this.pbHoldInfo.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbHoldInfo.TabIndex = 82;
			this.pbHoldInfo.TabStop = false;
			this.pbHoldInfo.Click += this.pbHoldInfo_Click;
			this.panel43.Controls.Add(this.label6);
			this.panel43.Dock = DockStyle.Top;
			this.panel43.Location = new Point(0, 0);
			this.panel43.Name = "panel43";
			this.panel43.Size = new Size(109, 11);
			this.panel43.TabIndex = 81;
			this.label6.AutoSize = true;
			this.label6.Dock = DockStyle.Top;
			this.label6.Font = new Font("굴림", 9f);
			this.label6.Location = new Point(0, 0);
			this.label6.Name = "label6";
			this.label6.Size = new Size(96, 12);
			this.label6.TabIndex = 69;
			this.label6.Text = "Hold Information";
			this.pnDifficulty.Controls.Add(this.cbDifficulty);
			this.pnDifficulty.Controls.Add(this.label4);
			this.pnDifficulty.Dock = DockStyle.Left;
			this.pnDifficulty.Location = new Point(603, 0);
			this.pnDifficulty.Name = "pnDifficulty";
			this.pnDifficulty.Padding = new Padding(0, 0, 3, 0);
			this.pnDifficulty.Size = new Size(154, 35);
			this.pnDifficulty.TabIndex = 76;
			this.cbDifficulty.BackColor = SystemColors.Window;
			this.cbDifficulty.Dock = DockStyle.Fill;
			this.cbDifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbDifficulty.Font = new Font("굴림", 9f);
			this.cbDifficulty.FormattingEnabled = true;
			this.cbDifficulty.Items.AddRange(new object[]
			{
				"Beginning Level(Level-1)",
				"Intermediate Level(Level-2)",
				"Advanced Level(Level-3)",
				"Expert Leve(Level-4)"
			});
			this.cbDifficulty.Location = new Point(0, 12);
			this.cbDifficulty.Name = "cbDifficulty";
			this.cbDifficulty.Size = new Size(151, 20);
			this.cbDifficulty.TabIndex = 69;
			this.label4.AutoSize = true;
			this.label4.Dock = DockStyle.Top;
			this.label4.Font = new Font("굴림", 9f);
			this.label4.Location = new Point(0, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(129, 12);
			this.label4.TabIndex = 68;
			this.label4.Text = "Maintenance Difficulty";
			this.pnFactor.Controls.Add(this.cbFactor);
			this.pnFactor.Controls.Add(this.label36);
			this.pnFactor.Dock = DockStyle.Left;
			this.pnFactor.Location = new Point(433, 0);
			this.pnFactor.Name = "pnFactor";
			this.pnFactor.Padding = new Padding(0, 0, 3, 0);
			this.pnFactor.Size = new Size(170, 35);
			this.pnFactor.TabIndex = 75;
			this.cbFactor.BackColor = SystemColors.Window;
			this.cbFactor.Dock = DockStyle.Fill;
			this.cbFactor.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbFactor.Font = new Font("굴림", 9f);
			this.cbFactor.FormattingEnabled = true;
			this.cbFactor.Location = new Point(0, 12);
			this.cbFactor.Name = "cbFactor";
			this.cbFactor.Size = new Size(167, 20);
			this.cbFactor.TabIndex = 73;
			this.label36.AutoSize = true;
			this.label36.Dock = DockStyle.Top;
			this.label36.Font = new Font("굴림", 9f);
			this.label36.Location = new Point(0, 0);
			this.label36.Name = "label36";
			this.label36.Size = new Size(91, 12);
			this.label36.TabIndex = 72;
			this.label36.Text = "Problem Factor";
			this.panel19.Controls.Add(this.cbCase);
			this.panel19.Controls.Add(this.label35);
			this.panel19.Dock = DockStyle.Left;
			this.panel19.Location = new Point(233, 0);
			this.panel19.Name = "panel19";
			this.panel19.Padding = new Padding(0, 0, 3, 0);
			this.panel19.Size = new Size(200, 35);
			this.panel19.TabIndex = 77;
			this.cbCase.BackColor = SystemColors.Window;
			this.cbCase.Dock = DockStyle.Fill;
			this.cbCase.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbCase.Font = new Font("굴림", 9f);
			this.cbCase.FormattingEnabled = true;
			this.cbCase.Items.AddRange(new object[]
			{
				"HARDWARE",
				"SOFTWARE",
				"OTHER"
			});
			this.cbCase.Location = new Point(0, 12);
			this.cbCase.Name = "cbCase";
			this.cbCase.Size = new Size(197, 20);
			this.cbCase.TabIndex = 71;
			this.cbCase.SelectedIndexChanged += this.cbCase_SelectedIndexChanged;
			this.label35.AutoSize = true;
			this.label35.Dock = DockStyle.Top;
			this.label35.Font = new Font("굴림", 9f);
			this.label35.Location = new Point(0, 0);
			this.label35.Name = "label35";
			this.label35.Size = new Size(35, 12);
			this.label35.TabIndex = 70;
			this.label35.Text = "Case";
			this.panel18.Controls.Add(this.dtStartPicker);
			this.panel18.Controls.Add(this.label1);
			this.panel18.Dock = DockStyle.Left;
			this.panel18.Location = new Point(0, 0);
			this.panel18.Name = "panel18";
			this.panel18.Padding = new Padding(3, 0, 3, 0);
			this.panel18.Size = new Size(233, 35);
			this.panel18.TabIndex = 74;
			this.dtStartPicker.CalendarFont = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dtStartPicker.CustomFormat = "yyyy-MM-dd HH:mm";
			this.dtStartPicker.Dock = DockStyle.Fill;
			this.dtStartPicker.Font = new Font("굴림", 9f);
			this.dtStartPicker.Format = DateTimePickerFormat.Custom;
			this.dtStartPicker.Location = new Point(3, 12);
			this.dtStartPicker.Name = "dtStartPicker";
			this.dtStartPicker.Size = new Size(227, 21);
			this.dtStartPicker.TabIndex = 51;
			this.dtStartPicker.Value = new DateTime(1900, 1, 1, 0, 0, 0, 0);
			this.label1.AutoSize = true;
			this.label1.Dock = DockStyle.Top;
			this.label1.Font = new Font("굴림", 9f);
			this.label1.Location = new Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(63, 12);
			this.label1.TabIndex = 52;
			this.label1.Text = "Start Time";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.AutoScroll = true;
			base.AutoScrollMinSize = new Size(1000, 0);
			this.BackColor = Color.White;
			base.Controls.Add(this.panel16);
			base.Controls.Add(this.panel17);
			base.Name = "ActionInformation";
			base.Size = new Size(1033, 72);
			this.panel17.ResumeLayout(false);
			this.panel34.ResumeLayout(false);
			this.panel34.PerformLayout();
			this.panel33.ResumeLayout(false);
			this.panel33.PerformLayout();
			this.panel32.ResumeLayout(false);
			this.panel32.PerformLayout();
			this.panel31.ResumeLayout(false);
			this.panel31.PerformLayout();
			this.panel16.ResumeLayout(false);
			this.pnHoldInformation.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((ISupportInitialize)this.pbHoldInfo).EndInit();
			this.panel43.ResumeLayout(false);
			this.panel43.PerformLayout();
			this.pnDifficulty.ResumeLayout(false);
			this.pnDifficulty.PerformLayout();
			this.pnFactor.ResumeLayout(false);
			this.pnFactor.PerformLayout();
			this.panel19.ResumeLayout(false);
			this.panel19.PerformLayout();
			this.panel18.ResumeLayout(false);
			this.panel18.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000659 RID: 1625
		private Dictionary<string, string> _FactorList = new Dictionary<string, string>();

		// Token: 0x0400065A RID: 1626
		private cReportItem _report;

		// Token: 0x0400065B RID: 1627
		private FactorySettings _factorySettings;

		// Token: 0x0400065C RID: 1628
		private IContainer components = null;

		// Token: 0x0400065D RID: 1629
		private Panel panel17;

		// Token: 0x0400065E RID: 1630
		private Panel panel16;

		// Token: 0x0400065F RID: 1631
		private Panel pnHoldInformation;

		// Token: 0x04000660 RID: 1632
		private Panel panel43;

		// Token: 0x04000661 RID: 1633
		private Label label6;

		// Token: 0x04000662 RID: 1634
		private Panel pnDifficulty;

		// Token: 0x04000663 RID: 1635
		private Label label4;

		// Token: 0x04000664 RID: 1636
		private Panel pnFactor;

		// Token: 0x04000665 RID: 1637
		private Label label36;

		// Token: 0x04000666 RID: 1638
		private Panel panel19;

		// Token: 0x04000667 RID: 1639
		private Label label35;

		// Token: 0x04000668 RID: 1640
		private Panel panel18;

		// Token: 0x04000669 RID: 1641
		private Label label1;

		// Token: 0x0400066A RID: 1642
		public ComboBox cbDifficulty;

		// Token: 0x0400066B RID: 1643
		public ComboBox cbFactor;

		// Token: 0x0400066C RID: 1644
		public ComboBox cbCase;

		// Token: 0x0400066D RID: 1645
		public DateTimePicker dtStartPicker;

		// Token: 0x0400066E RID: 1646
		private Panel panel34;

		// Token: 0x0400066F RID: 1647
		private TextBox tbDownTimeS;

		// Token: 0x04000670 RID: 1648
		private Label label21;

		// Token: 0x04000671 RID: 1649
		private Panel panel33;

		// Token: 0x04000672 RID: 1650
		private TextBox tbDownTimeR;

		// Token: 0x04000673 RID: 1651
		private Label label20;

		// Token: 0x04000674 RID: 1652
		private Panel panel32;

		// Token: 0x04000675 RID: 1653
		public TextBox tbEndTime;

		// Token: 0x04000676 RID: 1654
		private Label label19;

		// Token: 0x04000677 RID: 1655
		private Panel panel31;

		// Token: 0x04000678 RID: 1656
		public TextBox tbRequestTime;

		// Token: 0x04000679 RID: 1657
		private Label label17;

		// Token: 0x0400067A RID: 1658
		private Panel panel2;

		// Token: 0x0400067B RID: 1659
		private Panel panel1;

		// Token: 0x0400067C RID: 1660
		private PictureBox pbHoldInfo;
	}
}
