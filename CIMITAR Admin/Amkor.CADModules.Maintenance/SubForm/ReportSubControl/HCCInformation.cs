using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Interface;

namespace Amkor.CADModules.Maintenance.SubForm.ReportSubControl
{
	// Token: 0x02000015 RID: 21
	public class HCCInformation : UserControl, IHCC
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600017C RID: 380 RVA: 0x000443FA File Offset: 0x000425FA
		public HCC _hCC { get; }

		// Token: 0x0600017D RID: 381 RVA: 0x00044402 File Offset: 0x00042602
		public HCCInformation(QueryMgr queryMgr, HCC hCC)
		{
			this._queryMgr = queryMgr;
			this._hCC = hCC;
			this.InitializeComponent();
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00044428 File Offset: 0x00042628
		public void clear()
		{
			this.tbHCCLocation.Text = string.Empty;
			this.tbHCCNickname.Text = string.Empty;
			this.tbHCCBoardNo.Text = string.Empty;
			this.tbHCCBoardType.Text = string.Empty;
			this.tbHCCSite.Text = string.Empty;
			this.tbHCCHanlderType.Text = string.Empty;
			this.tbHCCPKGType.Text = string.Empty;
			this._hCC.initialize();
		}

		// Token: 0x0600017F RID: 383 RVA: 0x000444B9 File Offset: 0x000426B9
		public void initHCCContents(bool visible)
		{
			this.pnHCCInfo.Visible = visible;
			this.clear();
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000444D0 File Offset: 0x000426D0
		public void setBoardNo(bool visible)
		{
			this.pnBoardNo.Visible = visible;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x000444DF File Offset: 0x000426DF
		public void setK3Board()
		{
			this.pnHCCSite.Visible = true;
			this.pnHCCHandlerType.Visible = true;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x000444FC File Offset: 0x000426FC
		public string getLocation()
		{
			return this.tbHCCLocation.Text.Trim().ToUpper();
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00044513 File Offset: 0x00042713
		public string getBoardType()
		{
			return this.tbHCCBoardType.Text.Trim();
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00044525 File Offset: 0x00042725
		public string getNickname()
		{
			return this.tbHCCNickname.Text.Trim();
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00044537 File Offset: 0x00042737
		public string getSite()
		{
			return this.tbHCCSite.Text.Trim();
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00044549 File Offset: 0x00042749
		public string getHandlerType()
		{
			return this.tbHCCHanlderType.Text.Trim();
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0004455B File Offset: 0x0004275B
		public string getPkgType()
		{
			return this.tbHCCPKGType.Text.Trim();
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0004456D File Offset: 0x0004276D
		public string getBoardNo()
		{
			return this.tbHCCBoardNo.Text.Trim();
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0004457F File Offset: 0x0004277F
		public string existNickName()
		{
			return this.lbNickname.Text.Trim();
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00044594 File Offset: 0x00042794
		public void getHCCLocationList(ReportInformation ri)
		{
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintHCCLocationList] @_Factory = '",
				ri.getFactory(),
				"', @_Content = '",
				ri.getContent(),
				"'"
			});
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				string[] array = new string[dataSet.Tables[0].Rows.Count];
				AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					array[i] = dataSet.Tables[0].Rows[i]["hclocation"].ToString();
				}
				autoCompleteStringCollection.AddRange(array);
				this.tbHCCLocation.AutoCompleteCustomSource = autoCompleteStringCollection;
				this.tbHCCLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
				this.tbHCCLocation.AutoCompleteSource = AutoCompleteSource.CustomSource;
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x000446B0 File Offset: 0x000428B0
		private void tbHCCLocation_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyValue == 13;
			if (flag)
			{
				bool flag2 = string.IsNullOrEmpty(this.tbHCCLocation.Text.Trim().ToUpper());
				if (!flag2)
				{
					string sQuery = string.Concat(new string[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintCheckStatus] @_Plant=N'",
						this._ri.getFactory(),
						"', @_Category=N'",
						this._ri.getCategory(),
						"',@_Machine=N'",
						this.tbHCCLocation.Text.Trim().ToUpper(),
						"',@_Model=N'",
						this._ri.getModel(),
						"'"
					});
					DataSet dataSet = this._queryMgr.queryCall(sQuery);
					bool flag3 = dataSet != null && dataSet.Tables.Count > 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables.Count >= 1 && dataSet.Tables[0].Rows.Count != 0;
						if (flag4)
						{
							MessageBox.Show(MessageLanguage.getMessage("check_request_status"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
						bool flag5 = dataSet.Tables.Count == 2 && dataSet.Tables[1].Rows.Count != 0;
						if (flag5)
						{
							MessageBox.Show(MessageLanguage.getMessage("check_pm_request_status"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
					this.tbHCCLocation_Leave(null, null);
				}
			}
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00044840 File Offset: 0x00042A40
		private void tbHCCLocation_Leave(object sender, EventArgs e)
		{
			this._hCC.initialize();
			this.tbHCCNickname.Text = (this.tbHCCBoardType.Text = string.Empty);
			this.tbHCCHanlderType.Text = (this.tbHCCBoardNo.Text = string.Empty);
			this.tbHCCSite.Text = (this.tbHCCPKGType.Text = string.Empty);
			this._ri._hCC.LotNumber = string.Empty;
			this._ri._hCC.Machine = string.Empty;
			bool flag = string.IsNullOrEmpty(this.tbHCCLocation.Text.Trim());
			if (!flag)
			{
				this._hCC.getInformation(this._ri.getFactory(), this._ri.getContent(), this.tbHCCLocation.Text.Trim());
				this.tbHCCBoardType.Text = this._hCC.hCCParameter.boardType;
				this._ri.setHCCId(this._hCC.hCCParameter.hccid);
				bool flag2 = string.IsNullOrEmpty(this._hCC.hCCParameter.nickname.Trim());
				if (flag2)
				{
					this.tbHCCNickname.Text = this._hCC.hCCParameter.device;
					this.lbNickname.Text = "Device";
				}
				else
				{
					this.tbHCCNickname.Text = this._hCC.hCCParameter.nickname;
					this.lbNickname.Text = "Nickname";
				}
				bool flag3 = this._ri.getContentIndex() == 0;
				if (flag3)
				{
					this.tbHCCBoardNo.Text = this._hCC.hCCParameter.boardid;
				}
				this.tbHCCHanlderType.Text = this._hCC.hCCParameter.handlerType;
				this.tbHCCSite.Text = this._hCC.hCCParameter.site;
				this.tbHCCPKGType.Text = this._hCC.hCCParameter.pkgType;
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00044A70 File Offset: 0x00042C70
		public int getSiteCount()
		{
			int result = 0;
			int.TryParse(this.tbHCCSite.Text.Trim(), out result);
			return result;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00044A9D File Offset: 0x00042C9D
		public void setLocationLeave()
		{
			this.tbHCCLocation_Leave(null, null);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00044AA8 File Offset: 0x00042CA8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00044AE0 File Offset: 0x00042CE0
		private void InitializeComponent()
		{
			this.pnHCCInfo = new Panel();
			this.groupBox7 = new GroupBox();
			this.textBox2 = new TextBox();
			this.pnHCCBase = new Panel();
			this.panel10 = new Panel();
			this.tbHCCPKGType = new TextBox();
			this.label21 = new Label();
			this.pnHCCHandlerType = new Panel();
			this.tbHCCHanlderType = new TextBox();
			this.label24 = new Label();
			this.pnHCCSite = new Panel();
			this.tbHCCSite = new TextBox();
			this.label7 = new Label();
			this.pnNickname = new Panel();
			this.tbHCCNickname = new TextBox();
			this.lbNickname = new Label();
			this.pnHCCType = new Panel();
			this.tbHCCBoardType = new TextBox();
			this.label20 = new Label();
			this.pnBoardNo = new Panel();
			this.tbHCCBoardNo = new TextBox();
			this.label23 = new Label();
			this.pnHardware = new Panel();
			this.tbHCCLocation = new TextBox();
			this.label19 = new Label();
			this.pnHCCInfo.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.pnHCCBase.SuspendLayout();
			this.panel10.SuspendLayout();
			this.pnHCCHandlerType.SuspendLayout();
			this.pnHCCSite.SuspendLayout();
			this.pnNickname.SuspendLayout();
			this.pnHCCType.SuspendLayout();
			this.pnBoardNo.SuspendLayout();
			this.pnHardware.SuspendLayout();
			base.SuspendLayout();
			this.pnHCCInfo.Controls.Add(this.groupBox7);
			this.pnHCCInfo.Dock = DockStyle.Fill;
			this.pnHCCInfo.Location = new Point(0, 0);
			this.pnHCCInfo.Margin = new Padding(0);
			this.pnHCCInfo.Name = "pnHCCInfo";
			this.pnHCCInfo.Size = new Size(1230, 76);
			this.pnHCCInfo.TabIndex = 75;
			this.pnHCCInfo.Visible = false;
			this.groupBox7.Controls.Add(this.textBox2);
			this.groupBox7.Controls.Add(this.pnHCCBase);
			this.groupBox7.Dock = DockStyle.Fill;
			this.groupBox7.Location = new Point(0, 0);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Padding = new Padding(3, 0, 0, 0);
			this.groupBox7.Size = new Size(1230, 76);
			this.groupBox7.TabIndex = 70;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "HCC Info'";
			this.textBox2.BackColor = Color.Gainsboro;
			this.textBox2.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.textBox2.Location = new Point(2400, 38);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new Size(49, 23);
			this.textBox2.TabIndex = 97;
			this.textBox2.Visible = false;
			this.pnHCCBase.AutoScroll = true;
			this.pnHCCBase.Controls.Add(this.panel10);
			this.pnHCCBase.Controls.Add(this.pnHCCHandlerType);
			this.pnHCCBase.Controls.Add(this.pnHCCSite);
			this.pnHCCBase.Controls.Add(this.pnNickname);
			this.pnHCCBase.Controls.Add(this.pnHCCType);
			this.pnHCCBase.Controls.Add(this.pnBoardNo);
			this.pnHCCBase.Controls.Add(this.pnHardware);
			this.pnHCCBase.Dock = DockStyle.Fill;
			this.pnHCCBase.Location = new Point(3, 14);
			this.pnHCCBase.Name = "pnHCCBase";
			this.pnHCCBase.Padding = new Padding(3, 0, 0, 0);
			this.pnHCCBase.Size = new Size(1227, 62);
			this.pnHCCBase.TabIndex = 87;
			this.panel10.Controls.Add(this.tbHCCPKGType);
			this.panel10.Controls.Add(this.label21);
			this.panel10.Dock = DockStyle.Left;
			this.panel10.Location = new Point(1063, 0);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new Padding(0, 0, 3, 0);
			this.panel10.Size = new Size(274, 45);
			this.panel10.TabIndex = 95;
			this.tbHCCPKGType.BackColor = Color.Gainsboro;
			this.tbHCCPKGType.Dock = DockStyle.Fill;
			this.tbHCCPKGType.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCPKGType.Location = new Point(0, 17);
			this.tbHCCPKGType.Name = "tbHCCPKGType";
			this.tbHCCPKGType.ReadOnly = true;
			this.tbHCCPKGType.Size = new Size(271, 23);
			this.tbHCCPKGType.TabIndex = 67;
			this.label21.Dock = DockStyle.Top;
			this.label21.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label21.Location = new Point(0, 0);
			this.label21.Name = "label21";
			this.label21.Size = new Size(271, 17);
			this.label21.TabIndex = 13;
			this.label21.Text = "PKG Type";
			this.pnHCCHandlerType.Controls.Add(this.tbHCCHanlderType);
			this.pnHCCHandlerType.Controls.Add(this.label24);
			this.pnHCCHandlerType.Dock = DockStyle.Left;
			this.pnHCCHandlerType.Location = new Point(789, 0);
			this.pnHCCHandlerType.Name = "pnHCCHandlerType";
			this.pnHCCHandlerType.Padding = new Padding(0, 0, 3, 0);
			this.pnHCCHandlerType.Size = new Size(274, 45);
			this.pnHCCHandlerType.TabIndex = 94;
			this.tbHCCHanlderType.BackColor = Color.Gainsboro;
			this.tbHCCHanlderType.Dock = DockStyle.Fill;
			this.tbHCCHanlderType.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCHanlderType.Location = new Point(0, 17);
			this.tbHCCHanlderType.Name = "tbHCCHanlderType";
			this.tbHCCHanlderType.ReadOnly = true;
			this.tbHCCHanlderType.Size = new Size(271, 23);
			this.tbHCCHanlderType.TabIndex = 67;
			this.label24.Dock = DockStyle.Top;
			this.label24.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label24.Location = new Point(0, 0);
			this.label24.Name = "label24";
			this.label24.Size = new Size(271, 17);
			this.label24.TabIndex = 13;
			this.label24.Text = "Handler Type";
			this.pnHCCSite.Controls.Add(this.tbHCCSite);
			this.pnHCCSite.Controls.Add(this.label7);
			this.pnHCCSite.Dock = DockStyle.Left;
			this.pnHCCSite.Location = new Point(688, 0);
			this.pnHCCSite.Name = "pnHCCSite";
			this.pnHCCSite.Padding = new Padding(0, 0, 3, 0);
			this.pnHCCSite.Size = new Size(101, 45);
			this.pnHCCSite.TabIndex = 92;
			this.pnHCCSite.Visible = false;
			this.tbHCCSite.BackColor = Color.Gainsboro;
			this.tbHCCSite.Dock = DockStyle.Fill;
			this.tbHCCSite.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCSite.Location = new Point(0, 17);
			this.tbHCCSite.Name = "tbHCCSite";
			this.tbHCCSite.ReadOnly = true;
			this.tbHCCSite.Size = new Size(98, 23);
			this.tbHCCSite.TabIndex = 67;
			this.label7.Dock = DockStyle.Top;
			this.label7.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label7.Location = new Point(0, 0);
			this.label7.Name = "label7";
			this.label7.Size = new Size(98, 17);
			this.label7.TabIndex = 13;
			this.label7.Text = "Number of Site";
			this.pnNickname.Controls.Add(this.tbHCCNickname);
			this.pnNickname.Controls.Add(this.lbNickname);
			this.pnNickname.Dock = DockStyle.Left;
			this.pnNickname.Location = new Point(504, 0);
			this.pnNickname.Name = "pnNickname";
			this.pnNickname.Padding = new Padding(0, 0, 3, 0);
			this.pnNickname.Size = new Size(184, 45);
			this.pnNickname.TabIndex = 89;
			this.tbHCCNickname.BackColor = Color.Gainsboro;
			this.tbHCCNickname.Dock = DockStyle.Fill;
			this.tbHCCNickname.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCNickname.Location = new Point(0, 17);
			this.tbHCCNickname.Name = "tbHCCNickname";
			this.tbHCCNickname.ReadOnly = true;
			this.tbHCCNickname.Size = new Size(181, 23);
			this.tbHCCNickname.TabIndex = 67;
			this.lbNickname.Dock = DockStyle.Top;
			this.lbNickname.Font = new Font("Segoe UI Symbol", 9.75f);
			this.lbNickname.Location = new Point(0, 0);
			this.lbNickname.Name = "lbNickname";
			this.lbNickname.Size = new Size(181, 17);
			this.lbNickname.TabIndex = 13;
			this.lbNickname.Text = "Nickname";
			this.pnHCCType.Controls.Add(this.tbHCCBoardType);
			this.pnHCCType.Controls.Add(this.label20);
			this.pnHCCType.Dock = DockStyle.Left;
			this.pnHCCType.Location = new Point(320, 0);
			this.pnHCCType.Name = "pnHCCType";
			this.pnHCCType.Padding = new Padding(0, 0, 3, 0);
			this.pnHCCType.Size = new Size(184, 45);
			this.pnHCCType.TabIndex = 88;
			this.tbHCCBoardType.BackColor = Color.Gainsboro;
			this.tbHCCBoardType.Dock = DockStyle.Fill;
			this.tbHCCBoardType.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCBoardType.Location = new Point(0, 17);
			this.tbHCCBoardType.Name = "tbHCCBoardType";
			this.tbHCCBoardType.ReadOnly = true;
			this.tbHCCBoardType.Size = new Size(181, 23);
			this.tbHCCBoardType.TabIndex = 67;
			this.label20.Dock = DockStyle.Top;
			this.label20.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label20.Location = new Point(0, 0);
			this.label20.Name = "label20";
			this.label20.Size = new Size(181, 17);
			this.label20.TabIndex = 13;
			this.label20.Text = "Hardware Type";
			this.pnBoardNo.Controls.Add(this.tbHCCBoardNo);
			this.pnBoardNo.Controls.Add(this.label23);
			this.pnBoardNo.Dock = DockStyle.Left;
			this.pnBoardNo.Location = new Point(197, 0);
			this.pnBoardNo.Name = "pnBoardNo";
			this.pnBoardNo.Padding = new Padding(0, 0, 3, 0);
			this.pnBoardNo.Size = new Size(123, 45);
			this.pnBoardNo.TabIndex = 91;
			this.pnBoardNo.Visible = false;
			this.tbHCCBoardNo.BackColor = Color.Gainsboro;
			this.tbHCCBoardNo.Dock = DockStyle.Fill;
			this.tbHCCBoardNo.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCBoardNo.Location = new Point(0, 17);
			this.tbHCCBoardNo.Name = "tbHCCBoardNo";
			this.tbHCCBoardNo.ReadOnly = true;
			this.tbHCCBoardNo.Size = new Size(120, 23);
			this.tbHCCBoardNo.TabIndex = 67;
			this.label23.Dock = DockStyle.Top;
			this.label23.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label23.Location = new Point(0, 0);
			this.label23.Name = "label23";
			this.label23.Size = new Size(120, 17);
			this.label23.TabIndex = 13;
			this.label23.Text = "Board No.";
			this.pnHardware.Controls.Add(this.tbHCCLocation);
			this.pnHardware.Controls.Add(this.label19);
			this.pnHardware.Dock = DockStyle.Left;
			this.pnHardware.Location = new Point(3, 0);
			this.pnHardware.Name = "pnHardware";
			this.pnHardware.Padding = new Padding(0, 0, 3, 0);
			this.pnHardware.Size = new Size(194, 45);
			this.pnHardware.TabIndex = 90;
			this.tbHCCLocation.CharacterCasing = CharacterCasing.Upper;
			this.tbHCCLocation.Dock = DockStyle.Fill;
			this.tbHCCLocation.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.tbHCCLocation.Location = new Point(0, 17);
			this.tbHCCLocation.Name = "tbHCCLocation";
			this.tbHCCLocation.Size = new Size(191, 23);
			this.tbHCCLocation.TabIndex = 8;
			this.tbHCCLocation.KeyDown += this.tbHCCLocation_KeyDown;
			this.tbHCCLocation.Leave += this.tbHCCLocation_Leave;
			this.label19.Dock = DockStyle.Top;
			this.label19.Font = new Font("Segoe UI Symbol", 9.75f);
			this.label19.Location = new Point(0, 0);
			this.label19.Name = "label19";
			this.label19.Size = new Size(191, 17);
			this.label19.TabIndex = 7;
			this.label19.Text = "Hardware Location";
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.pnHCCInfo);
			base.Name = "HCCInformation";
			base.Size = new Size(1230, 76);
			this.pnHCCInfo.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.pnHCCBase.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.pnHCCHandlerType.ResumeLayout(false);
			this.pnHCCHandlerType.PerformLayout();
			this.pnHCCSite.ResumeLayout(false);
			this.pnHCCSite.PerformLayout();
			this.pnNickname.ResumeLayout(false);
			this.pnNickname.PerformLayout();
			this.pnHCCType.ResumeLayout(false);
			this.pnHCCType.PerformLayout();
			this.pnBoardNo.ResumeLayout(false);
			this.pnBoardNo.PerformLayout();
			this.pnHardware.ResumeLayout(false);
			this.pnHardware.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x0400031E RID: 798
		private QueryMgr _queryMgr;

		// Token: 0x04000320 RID: 800
		public ReportBoardInformation _rbi;

		// Token: 0x04000321 RID: 801
		public ReportInformation _ri;

		// Token: 0x04000322 RID: 802
		private IContainer components = null;

		// Token: 0x04000323 RID: 803
		private Panel pnHCCInfo;

		// Token: 0x04000324 RID: 804
		private GroupBox groupBox7;

		// Token: 0x04000325 RID: 805
		private TextBox textBox2;

		// Token: 0x04000326 RID: 806
		private Panel pnHCCBase;

		// Token: 0x04000327 RID: 807
		private Panel panel10;

		// Token: 0x04000328 RID: 808
		private TextBox tbHCCPKGType;

		// Token: 0x04000329 RID: 809
		private Label label21;

		// Token: 0x0400032A RID: 810
		private Panel pnHCCHandlerType;

		// Token: 0x0400032B RID: 811
		private TextBox tbHCCHanlderType;

		// Token: 0x0400032C RID: 812
		private Label label24;

		// Token: 0x0400032D RID: 813
		private Panel pnHCCSite;

		// Token: 0x0400032E RID: 814
		private TextBox tbHCCSite;

		// Token: 0x0400032F RID: 815
		private Label label7;

		// Token: 0x04000330 RID: 816
		private Panel pnNickname;

		// Token: 0x04000331 RID: 817
		private TextBox tbHCCNickname;

		// Token: 0x04000332 RID: 818
		private Label lbNickname;

		// Token: 0x04000333 RID: 819
		private Panel pnHCCType;

		// Token: 0x04000334 RID: 820
		private TextBox tbHCCBoardType;

		// Token: 0x04000335 RID: 821
		private Label label20;

		// Token: 0x04000336 RID: 822
		private Panel pnBoardNo;

		// Token: 0x04000337 RID: 823
		private TextBox tbHCCBoardNo;

		// Token: 0x04000338 RID: 824
		private Label label23;

		// Token: 0x04000339 RID: 825
		private Panel pnHardware;

		// Token: 0x0400033A RID: 826
		private TextBox tbHCCLocation;

		// Token: 0x0400033B RID: 827
		private Label label19;
	}
}
