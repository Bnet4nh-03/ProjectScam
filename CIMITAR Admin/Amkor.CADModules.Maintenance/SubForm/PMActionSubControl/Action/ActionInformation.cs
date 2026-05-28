using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.Properties;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl.Action
{
	// Token: 0x0200002A RID: 42
	public class ActionInformation : UserControl
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x0005B9E4 File Offset: 0x00059BE4
		public string getRequestTime()
		{
			return this.tbRequestTime.Text.Trim();
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0005B9F6 File Offset: 0x00059BF6
		public string getCase()
		{
			return this.cbCase.SelectedItem.ToString().Trim();
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0005BA0D File Offset: 0x00059C0D
		public string getFactor()
		{
			return this.cbFactor.SelectedItem.ToString().Trim();
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0005BA24 File Offset: 0x00059C24
		public string getVendorText()
		{
			return this.tbVendor.Text.Trim();
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0005BA36 File Offset: 0x00059C36
		public string getAsset()
		{
			return this.tbAsset.Text.Trim();
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0005BA48 File Offset: 0x00059C48
		public string getStartTimeString()
		{
			return this.dtStartPicker.Value.ToString("yyyy-MM-dd HH:mm").Trim();
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0005BA72 File Offset: 0x00059C72
		public string getDifficulty()
		{
			return this.cbDifficulty.SelectedItem.ToString().Trim();
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0005BA89 File Offset: 0x00059C89
		public string getDoneTime()
		{
			return this.tbDoneTime.Text.Trim();
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0005BA9B File Offset: 0x00059C9B
		public int getCaseIndex()
		{
			return this.cbCase.SelectedIndex;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0005BAA8 File Offset: 0x00059CA8
		public int getFactorIndex()
		{
			return this.cbFactor.SelectedIndex;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0005BAB5 File Offset: 0x00059CB5
		public int getDifficultyIndex()
		{
			return this.cbDifficulty.SelectedIndex;
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0005BAC2 File Offset: 0x00059CC2
		public DateTime getStartTime()
		{
			return this.dtStartPicker.Value;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0005BAD0 File Offset: 0x00059CD0
		public void setDoneTime()
		{
			this.tbDoneTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0005BAFC File Offset: 0x00059CFC
		public ActionInformation(cReportItem report, FactorySettings factorySettings)
		{
			this._report = report;
			this._factorySettings = factorySettings;
			this._queryMgr = new QueryMgr(factorySettings);
			this.InitializeComponent();
			this.tbRequestTime.Text = report.sRequestTime;
			this.tbAsset.Text = report.sAsset;
			this.tbVendor.Text = report.sVendor;
			this.tbApprovalTime2.Text = report.sApprovalTime;
			bool flag = report.sReportStauts == "11";
			if (!flag)
			{
				bool flag2 = report.sReportStauts == "12";
				if (flag2)
				{
					this.dtStartPicker.Value = Convert.ToDateTime(report.sApprovalTime);
					bool flag3 = this._report.sWorkType.ToUpper().IndexOf("VENDOR") != -1;
					if (flag3)
					{
						this.pnVendor.Visible = true;
						this.pnAsset.Visible = true;
						bool flag4 = string.IsNullOrEmpty(this.tbAsset.Text.Trim());
						if (flag4)
						{
							this.tbAsset.ReadOnly = false;
							this.tbAsset.BackColor = Color.White;
							this.tbAsset.Text = "N/A";
						}
						else
						{
							this.tbAsset.ReadOnly = true;
							this.tbAsset.BackColor = Color.Gainsboro;
						}
						this.getVendor();
					}
				}
				else
				{
					bool flag5 = report.sReportStauts == "13" || report.sReportStauts == "14";
					if (flag5)
					{
						this.tbApprovalTime2.ReadOnly = true;
						this.tbAsset.ReadOnly = true;
						this.tbDoneTime.ReadOnly = true;
						this.tbRequestTime.ReadOnly = true;
						this.tbVendor.ReadOnly = true;
						this.cbCase.Enabled = false;
						this.cbDifficulty.Enabled = false;
						this.cbFactor.Enabled = false;
						this.tbAsset.Text = report.sAsset;
						this.tbVendor.Text = report.sVendor;
						this.dtStartPicker.Value = Convert.ToDateTime(report.sStartTime);
						this.tbDoneTime.Text = report.sEndTime;
						this.cbCase.Text = report.sCase;
						this.cbDifficulty.SelectedItem = report.sPMDifficulty;
						this.cbFactor.Text = report.sFactor;
						this.dtStartPicker.Enabled = false;
					}
					else
					{
						bool flag6 = report.sReportStauts == "97" || report.sReportStauts == "98";
						if (flag6)
						{
						}
					}
				}
			}
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0005BDEC File Offset: 0x00059FEC
		private void cbCase_SelectedIndexChanged(object sender, EventArgs e)
		{
			cFunction.getFactorList(this._factorySettings, this.cbFactor, this._report.sCategory, this._report.sFactory, this._FactorList, false);
			this.cbFactor.Items.Clear();
			this.pnFactor.Width = this.cbCase.Width;
			bool flag = this.cbCase.SelectedItem != null;
			if (flag)
			{
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

		// Token: 0x060002B5 RID: 693 RVA: 0x0005BF50 File Offset: 0x0005A150
		private void getVendor()
		{
			this.tbVendor.Text = string.Empty;
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintVendor] @_factory=N'" + this._report.sFactory + "'";
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				string[] array = new string[dataSet.Tables[0].Rows.Count];
				AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string text = dataSet.Tables[0].Rows[i]["vendor"].ToString();
					array[i] = text;
				}
				autoCompleteStringCollection.AddRange(array);
				this.tbVendor.AutoCompleteCustomSource = autoCompleteStringCollection;
				this.tbVendor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				this.tbVendor.AutoCompleteSource = AutoCompleteSource.CustomSource;
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0005C068 File Offset: 0x0005A268
		private int checkPlant()
		{
			bool flag = this._report.sReportName.ToUpper().IndexOf("K3_") != -1;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				bool flag2 = this._report.sReportName.ToUpper().IndexOf("K5_") != -1;
				if (flag2)
				{
					result = 2;
				}
				else
				{
					bool flag3 = this._report.sReportName.ToUpper().IndexOf("K3 EV") != -1;
					if (flag3)
					{
						result = 3;
					}
					else
					{
						bool flag4 = this._report.sReportName.ToUpper().IndexOf("K5 M") != -1;
						if (flag4)
						{
							result = 4;
						}
						else
						{
							result = -1;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0005C120 File Offset: 0x0005A320
		public void clear()
		{
			this.dtStartPicker.Value = Convert.ToDateTime(this._report.sApprovalTime);
			this.tbVendor.Text = string.Empty;
			this.cbCase.SelectedIndex = -1;
			this.cbFactor.Items.Clear();
			this.tbDoneTime.Text = string.Empty;
			this.cbDifficulty.SelectedIndex = -1;
			bool flag = !this.tbAsset.ReadOnly && this.tbAsset.Text.ToUpper().Trim() != "N/A";
			if (flag)
			{
				this.tbAsset.Text = string.Empty;
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0005C1E0 File Offset: 0x0005A3E0
		public bool checkAsset()
		{
			return this.tbAsset.Visible && string.IsNullOrEmpty(this.tbAsset.Text.Trim());
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0005C220 File Offset: 0x0005A420
		public bool checkVendor()
		{
			return this.tbVendor.Visible && string.IsNullOrEmpty(this.tbVendor.Text.Trim());
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0005C260 File Offset: 0x0005A460
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0005C298 File Offset: 0x0005A498
		private void InitializeComponent()
		{
			this.panel9 = new Panel();
			this.pnDone = new Panel();
			this.tbDoneTime = new TextBox();
			this.label19 = new Label();
			this.panel18 = new Panel();
			this.dtStartPicker = new DateTimePicker();
			this.label1 = new Label();
			this.panel25 = new Panel();
			this.tbApprovalTime2 = new TextBox();
			this.label30 = new Label();
			this.panel15 = new Panel();
			this.tbRequestTime = new TextBox();
			this.label17 = new Label();
			this.panel16 = new Panel();
			this.pnHoldInformation = new Panel();
			this.pbHoldInfo = new PictureBox();
			this.panel43 = new Panel();
			this.label6 = new Label();
			this.pnDifficulty = new Panel();
			this.cbDifficulty = new ComboBox();
			this.label38 = new Label();
			this.pnFactor = new Panel();
			this.cbFactor = new ComboBox();
			this.label36 = new Label();
			this.panel19 = new Panel();
			this.cbCase = new ComboBox();
			this.label35 = new Label();
			this.pnVendor = new Panel();
			this.tbVendor = new TextBox();
			this.label4 = new Label();
			this.pnAsset = new Panel();
			this.tbAsset = new TextBox();
			this.label28 = new Label();
			this.panel9.SuspendLayout();
			this.pnDone.SuspendLayout();
			this.panel18.SuspendLayout();
			this.panel25.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel16.SuspendLayout();
			this.pnHoldInformation.SuspendLayout();
			((ISupportInitialize)this.pbHoldInfo).BeginInit();
			this.panel43.SuspendLayout();
			this.pnDifficulty.SuspendLayout();
			this.pnFactor.SuspendLayout();
			this.panel19.SuspendLayout();
			this.pnVendor.SuspendLayout();
			this.pnAsset.SuspendLayout();
			base.SuspendLayout();
			this.panel9.Controls.Add(this.pnDone);
			this.panel9.Controls.Add(this.panel18);
			this.panel9.Controls.Add(this.panel25);
			this.panel9.Controls.Add(this.panel15);
			this.panel9.Dock = DockStyle.Fill;
			this.panel9.Location = new Point(0, 0);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new Padding(0, 0, 0, 3);
			this.panel9.Size = new Size(1052, 46);
			this.panel9.TabIndex = 75;
			this.pnDone.Controls.Add(this.tbDoneTime);
			this.pnDone.Controls.Add(this.label19);
			this.pnDone.Dock = DockStyle.Left;
			this.pnDone.Location = new Point(678, 0);
			this.pnDone.Name = "pnDone";
			this.pnDone.Padding = new Padding(0, 0, 3, 0);
			this.pnDone.Size = new Size(200, 43);
			this.pnDone.TabIndex = 82;
			this.tbDoneTime.BackColor = Color.Gainsboro;
			this.tbDoneTime.Dock = DockStyle.Fill;
			this.tbDoneTime.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbDoneTime.Location = new Point(0, 17);
			this.tbDoneTime.Name = "tbDoneTime";
			this.tbDoneTime.ReadOnly = true;
			this.tbDoneTime.Size = new Size(197, 23);
			this.tbDoneTime.TabIndex = 30;
			this.label19.AutoSize = true;
			this.label19.Dock = DockStyle.Top;
			this.label19.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label19.Location = new Point(0, 0);
			this.label19.Name = "label19";
			this.label19.Size = new Size(71, 17);
			this.label19.TabIndex = 29;
			this.label19.Text = "Done Time";
			this.panel18.Controls.Add(this.dtStartPicker);
			this.panel18.Controls.Add(this.label1);
			this.panel18.Dock = DockStyle.Left;
			this.panel18.Location = new Point(445, 0);
			this.panel18.Name = "panel18";
			this.panel18.Padding = new Padding(3, 0, 3, 0);
			this.panel18.Size = new Size(233, 43);
			this.panel18.TabIndex = 85;
			this.dtStartPicker.CalendarFont = new Font("Segoe UI", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dtStartPicker.CustomFormat = "yyyy-MM-dd HH:mm";
			this.dtStartPicker.Dock = DockStyle.Fill;
			this.dtStartPicker.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.dtStartPicker.Format = DateTimePickerFormat.Custom;
			this.dtStartPicker.Location = new Point(3, 17);
			this.dtStartPicker.Name = "dtStartPicker";
			this.dtStartPicker.Size = new Size(227, 23);
			this.dtStartPicker.TabIndex = 51;
			this.dtStartPicker.Value = new DateTime(1900, 1, 1, 0, 0, 0, 0);
			this.label1.AutoSize = true;
			this.label1.Dock = DockStyle.Top;
			this.label1.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(67, 17);
			this.label1.TabIndex = 52;
			this.label1.Text = "Start Time";
			this.panel25.Controls.Add(this.tbApprovalTime2);
			this.panel25.Controls.Add(this.label30);
			this.panel25.Dock = DockStyle.Left;
			this.panel25.Location = new Point(212, 0);
			this.panel25.Name = "panel25";
			this.panel25.Size = new Size(233, 43);
			this.panel25.TabIndex = 87;
			this.tbApprovalTime2.BackColor = Color.Gainsboro;
			this.tbApprovalTime2.Dock = DockStyle.Fill;
			this.tbApprovalTime2.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbApprovalTime2.Location = new Point(0, 17);
			this.tbApprovalTime2.Name = "tbApprovalTime2";
			this.tbApprovalTime2.ReadOnly = true;
			this.tbApprovalTime2.Size = new Size(233, 23);
			this.tbApprovalTime2.TabIndex = 26;
			this.label30.AutoSize = true;
			this.label30.Dock = DockStyle.Top;
			this.label30.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label30.Location = new Point(0, 0);
			this.label30.Name = "label30";
			this.label30.Size = new Size(93, 17);
			this.label30.TabIndex = 25;
			this.label30.Text = "Approval Time";
			this.panel15.Controls.Add(this.tbRequestTime);
			this.panel15.Controls.Add(this.label17);
			this.panel15.Dock = DockStyle.Left;
			this.panel15.Location = new Point(0, 0);
			this.panel15.Name = "panel15";
			this.panel15.Padding = new Padding(0, 0, 3, 0);
			this.panel15.Size = new Size(212, 43);
			this.panel15.TabIndex = 86;
			this.tbRequestTime.BackColor = Color.Gainsboro;
			this.tbRequestTime.Dock = DockStyle.Fill;
			this.tbRequestTime.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbRequestTime.Location = new Point(0, 17);
			this.tbRequestTime.Name = "tbRequestTime";
			this.tbRequestTime.ReadOnly = true;
			this.tbRequestTime.Size = new Size(209, 23);
			this.tbRequestTime.TabIndex = 30;
			this.label17.AutoSize = true;
			this.label17.Dock = DockStyle.Top;
			this.label17.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label17.Location = new Point(0, 0);
			this.label17.Name = "label17";
			this.label17.Size = new Size(87, 17);
			this.label17.TabIndex = 29;
			this.label17.Text = "Request Time";
			this.panel16.Controls.Add(this.pnHoldInformation);
			this.panel16.Controls.Add(this.pnDifficulty);
			this.panel16.Controls.Add(this.pnFactor);
			this.panel16.Controls.Add(this.panel19);
			this.panel16.Controls.Add(this.pnVendor);
			this.panel16.Controls.Add(this.pnAsset);
			this.panel16.Dock = DockStyle.Bottom;
			this.panel16.Location = new Point(0, 46);
			this.panel16.Name = "panel16";
			this.panel16.Padding = new Padding(0, 0, 0, 3);
			this.panel16.Size = new Size(1052, 43);
			this.panel16.TabIndex = 93;
			this.pnHoldInformation.Controls.Add(this.pbHoldInfo);
			this.pnHoldInformation.Controls.Add(this.panel43);
			this.pnHoldInformation.Dock = DockStyle.Left;
			this.pnHoldInformation.Location = new Point(924, 0);
			this.pnHoldInformation.Name = "pnHoldInformation";
			this.pnHoldInformation.Size = new Size(109, 40);
			this.pnHoldInformation.TabIndex = 80;
			this.pnHoldInformation.Visible = false;
			this.pbHoldInfo.Cursor = Cursors.Hand;
			this.pbHoldInfo.Dock = DockStyle.Left;
			this.pbHoldInfo.Image = Resources.info;
			this.pbHoldInfo.InitialImage = Resources.clear;
			this.pbHoldInfo.Location = new Point(0, 15);
			this.pbHoldInfo.Name = "pbHoldInfo";
			this.pbHoldInfo.Padding = new Padding(3);
			this.pbHoldInfo.Size = new Size(39, 25);
			this.pbHoldInfo.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pbHoldInfo.TabIndex = 82;
			this.pbHoldInfo.TabStop = false;
			this.panel43.Controls.Add(this.label6);
			this.panel43.Dock = DockStyle.Top;
			this.panel43.Location = new Point(0, 0);
			this.panel43.Name = "panel43";
			this.panel43.Size = new Size(109, 15);
			this.panel43.TabIndex = 81;
			this.label6.Dock = DockStyle.Top;
			this.label6.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label6.Location = new Point(0, 0);
			this.label6.Name = "label6";
			this.label6.Size = new Size(109, 17);
			this.label6.TabIndex = 69;
			this.label6.Text = "Hold Information";
			this.pnDifficulty.Controls.Add(this.cbDifficulty);
			this.pnDifficulty.Controls.Add(this.label38);
			this.pnDifficulty.Dock = DockStyle.Left;
			this.pnDifficulty.Location = new Point(746, 0);
			this.pnDifficulty.Name = "pnDifficulty";
			this.pnDifficulty.Padding = new Padding(0, 0, 3, 0);
			this.pnDifficulty.Size = new Size(178, 40);
			this.pnDifficulty.TabIndex = 105;
			this.cbDifficulty.BackColor = SystemColors.Window;
			this.cbDifficulty.Dock = DockStyle.Fill;
			this.cbDifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbDifficulty.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbDifficulty.FormattingEnabled = true;
			this.cbDifficulty.Items.AddRange(new object[]
			{
				"Beginning Level(Level-1)",
				"Intermediate Level(Level-2)",
				"Advanced Level(Level-3)",
				"Expert Leve(Level-4)"
			});
			this.cbDifficulty.Location = new Point(0, 17);
			this.cbDifficulty.Name = "cbDifficulty";
			this.cbDifficulty.Size = new Size(175, 23);
			this.cbDifficulty.TabIndex = 69;
			this.label38.Dock = DockStyle.Top;
			this.label38.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label38.Location = new Point(0, 0);
			this.label38.Name = "label38";
			this.label38.Size = new Size(175, 17);
			this.label38.TabIndex = 68;
			this.label38.Text = "PM Difficulty";
			this.pnFactor.Controls.Add(this.cbFactor);
			this.pnFactor.Controls.Add(this.label36);
			this.pnFactor.Dock = DockStyle.Left;
			this.pnFactor.Location = new Point(576, 0);
			this.pnFactor.Name = "pnFactor";
			this.pnFactor.Padding = new Padding(0, 0, 3, 0);
			this.pnFactor.Size = new Size(170, 40);
			this.pnFactor.TabIndex = 75;
			this.cbFactor.BackColor = SystemColors.Window;
			this.cbFactor.Dock = DockStyle.Fill;
			this.cbFactor.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbFactor.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbFactor.FormattingEnabled = true;
			this.cbFactor.Location = new Point(0, 17);
			this.cbFactor.Name = "cbFactor";
			this.cbFactor.Size = new Size(167, 23);
			this.cbFactor.TabIndex = 73;
			this.label36.Dock = DockStyle.Top;
			this.label36.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label36.Location = new Point(0, 0);
			this.label36.Name = "label36";
			this.label36.Size = new Size(167, 17);
			this.label36.TabIndex = 72;
			this.label36.Text = "Problem Factor";
			this.panel19.Controls.Add(this.cbCase);
			this.panel19.Controls.Add(this.label35);
			this.panel19.Dock = DockStyle.Left;
			this.panel19.Location = new Point(376, 0);
			this.panel19.Name = "panel19";
			this.panel19.Padding = new Padding(0, 0, 3, 0);
			this.panel19.Size = new Size(200, 40);
			this.panel19.TabIndex = 77;
			this.cbCase.BackColor = SystemColors.Window;
			this.cbCase.Dock = DockStyle.Fill;
			this.cbCase.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbCase.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.cbCase.FormattingEnabled = true;
			this.cbCase.Items.AddRange(new object[]
			{
				"HARDWARE",
				"SOFTWARE",
				"OTHER"
			});
			this.cbCase.Location = new Point(0, 17);
			this.cbCase.Name = "cbCase";
			this.cbCase.Size = new Size(197, 23);
			this.cbCase.TabIndex = 71;
			this.cbCase.SelectedIndexChanged += this.cbCase_SelectedIndexChanged;
			this.label35.AutoSize = true;
			this.label35.Dock = DockStyle.Top;
			this.label35.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label35.Location = new Point(0, 0);
			this.label35.Name = "label35";
			this.label35.Size = new Size(36, 17);
			this.label35.TabIndex = 70;
			this.label35.Text = "Case";
			this.pnVendor.Controls.Add(this.tbVendor);
			this.pnVendor.Controls.Add(this.label4);
			this.pnVendor.Dock = DockStyle.Left;
			this.pnVendor.Location = new Point(212, 0);
			this.pnVendor.Name = "pnVendor";
			this.pnVendor.Padding = new Padding(3, 0, 3, 0);
			this.pnVendor.Size = new Size(164, 40);
			this.pnVendor.TabIndex = 103;
			this.pnVendor.Visible = false;
			this.tbVendor.CharacterCasing = CharacterCasing.Upper;
			this.tbVendor.Dock = DockStyle.Fill;
			this.tbVendor.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbVendor.Location = new Point(3, 17);
			this.tbVendor.Name = "tbVendor";
			this.tbVendor.Size = new Size(158, 23);
			this.tbVendor.TabIndex = 9;
			this.label4.AutoSize = true;
			this.label4.Dock = DockStyle.Top;
			this.label4.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label4.Location = new Point(3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(51, 17);
			this.label4.TabIndex = 8;
			this.label4.Text = "Vendor";
			this.pnAsset.Controls.Add(this.tbAsset);
			this.pnAsset.Controls.Add(this.label28);
			this.pnAsset.Dock = DockStyle.Left;
			this.pnAsset.Location = new Point(0, 0);
			this.pnAsset.Name = "pnAsset";
			this.pnAsset.Padding = new Padding(0, 0, 3, 0);
			this.pnAsset.Size = new Size(212, 40);
			this.pnAsset.TabIndex = 104;
			this.pnAsset.Visible = false;
			this.tbAsset.BackColor = Color.Gainsboro;
			this.tbAsset.Dock = DockStyle.Fill;
			this.tbAsset.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbAsset.Location = new Point(0, 17);
			this.tbAsset.Name = "tbAsset";
			this.tbAsset.ReadOnly = true;
			this.tbAsset.Size = new Size(209, 23);
			this.tbAsset.TabIndex = 16;
			this.label28.AutoSize = true;
			this.label28.Dock = DockStyle.Top;
			this.label28.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label28.Location = new Point(0, 0);
			this.label28.Name = "label28";
			this.label28.Size = new Size(51, 17);
			this.label28.TabIndex = 15;
			this.label28.Text = "Asset #";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel9);
			base.Controls.Add(this.panel16);
			base.Name = "ActionInformation";
			base.Size = new Size(1052, 89);
			this.panel9.ResumeLayout(false);
			this.pnDone.ResumeLayout(false);
			this.pnDone.PerformLayout();
			this.panel18.ResumeLayout(false);
			this.panel18.PerformLayout();
			this.panel25.ResumeLayout(false);
			this.panel25.PerformLayout();
			this.panel15.ResumeLayout(false);
			this.panel15.PerformLayout();
			this.panel16.ResumeLayout(false);
			this.pnHoldInformation.ResumeLayout(false);
			((ISupportInitialize)this.pbHoldInfo).EndInit();
			this.panel43.ResumeLayout(false);
			this.pnDifficulty.ResumeLayout(false);
			this.pnFactor.ResumeLayout(false);
			this.panel19.ResumeLayout(false);
			this.panel19.PerformLayout();
			this.pnVendor.ResumeLayout(false);
			this.pnVendor.PerformLayout();
			this.pnAsset.ResumeLayout(false);
			this.pnAsset.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040004C0 RID: 1216
		private FactorySettings _factorySettings;

		// Token: 0x040004C1 RID: 1217
		private cReportItem _report;

		// Token: 0x040004C2 RID: 1218
		private QueryMgr _queryMgr;

		// Token: 0x040004C3 RID: 1219
		private Dictionary<string, string> _FactorList = new Dictionary<string, string>();

		// Token: 0x040004C4 RID: 1220
		private IContainer components = null;

		// Token: 0x040004C5 RID: 1221
		private Panel panel9;

		// Token: 0x040004C6 RID: 1222
		private Panel pnDone;

		// Token: 0x040004C7 RID: 1223
		private TextBox tbDoneTime;

		// Token: 0x040004C8 RID: 1224
		private Label label19;

		// Token: 0x040004C9 RID: 1225
		private Panel panel18;

		// Token: 0x040004CA RID: 1226
		private DateTimePicker dtStartPicker;

		// Token: 0x040004CB RID: 1227
		private Label label1;

		// Token: 0x040004CC RID: 1228
		private Panel panel25;

		// Token: 0x040004CD RID: 1229
		private TextBox tbApprovalTime2;

		// Token: 0x040004CE RID: 1230
		private Label label30;

		// Token: 0x040004CF RID: 1231
		private Panel panel15;

		// Token: 0x040004D0 RID: 1232
		private TextBox tbRequestTime;

		// Token: 0x040004D1 RID: 1233
		private Label label17;

		// Token: 0x040004D2 RID: 1234
		private Panel panel16;

		// Token: 0x040004D3 RID: 1235
		private Panel pnHoldInformation;

		// Token: 0x040004D4 RID: 1236
		private PictureBox pbHoldInfo;

		// Token: 0x040004D5 RID: 1237
		private Panel panel43;

		// Token: 0x040004D6 RID: 1238
		private Label label6;

		// Token: 0x040004D7 RID: 1239
		private Panel pnDifficulty;

		// Token: 0x040004D8 RID: 1240
		private ComboBox cbDifficulty;

		// Token: 0x040004D9 RID: 1241
		private Label label38;

		// Token: 0x040004DA RID: 1242
		private Panel pnFactor;

		// Token: 0x040004DB RID: 1243
		private ComboBox cbFactor;

		// Token: 0x040004DC RID: 1244
		private Label label36;

		// Token: 0x040004DD RID: 1245
		private Panel panel19;

		// Token: 0x040004DE RID: 1246
		private ComboBox cbCase;

		// Token: 0x040004DF RID: 1247
		private Label label35;

		// Token: 0x040004E0 RID: 1248
		private Panel pnVendor;

		// Token: 0x040004E1 RID: 1249
		private TextBox tbVendor;

		// Token: 0x040004E2 RID: 1250
		private Label label4;

		// Token: 0x040004E3 RID: 1251
		private Panel pnAsset;

		// Token: 0x040004E4 RID: 1252
		private TextBox tbAsset;

		// Token: 0x040004E5 RID: 1253
		private Label label28;
	}
}
