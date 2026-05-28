using System;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Interface;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x0200003C RID: 60
	internal class DoubleBufferPanel : Panel, IHCC
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x00071AB0 File Offset: 0x0006FCB0
		// (set) Token: 0x060003C3 RID: 963 RVA: 0x00071AA7 File Offset: 0x0006FCA7
		public SITESTATUS SiteStatus { get; private set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x00071AC1 File Offset: 0x0006FCC1
		// (set) Token: 0x060003C5 RID: 965 RVA: 0x00071AB8 File Offset: 0x0006FCB8
		public int SiteNo { get; private set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x00071AD2 File Offset: 0x0006FCD2
		// (set) Token: 0x060003C7 RID: 967 RVA: 0x00071AC9 File Offset: 0x0006FCC9
		public string Failure { get; private set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x00071ADA File Offset: 0x0006FCDA
		public HCC _hCC { get; }

		// Token: 0x060003CA RID: 970 RVA: 0x00071AE2 File Offset: 0x0006FCE2
		public DoubleBufferPanel()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.UpdateStyles();
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00071B08 File Offset: 0x0006FD08
		public DoubleBufferPanel(HCC hcc, SITESTATUS status, int SiteNo, string Failure, bool factorEnable)
		{
			this._hCC = hcc;
			this._factorEnable = factorEnable;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			base.UpdateStyles();
			bool flag = SiteNo == 0;
			if (flag)
			{
				base.Name = this._hCC.siteMap.SITEPANEL + "0_" + SiteNo.ToString();
			}
			else
			{
				base.Name = this._hCC.siteMap.SITEPANEL + SiteNo.ToString();
			}
			this.Cursor = Cursors.Hand;
			this.Dock = DockStyle.Fill;
			this.SiteStatus = status;
			this.SiteNo = SiteNo;
			this.Failure = ((this.SiteStatus == SITESTATUS.GOOD) ? this._hCC.siteMap.GOOD : ((this.SiteStatus == SITESTATUS.DISABLE) ? this._hCC.siteMap.DISABLE : Failure));
			base.MouseDown += this.SiteMapMouseDown;
			this.createSubControls(SiteNo);
			this.setStatusText(this.SiteStatus, false, Failure);
		}

		// Token: 0x060003CC RID: 972 RVA: 0x00071C2C File Offset: 0x0006FE2C
		public DoubleBufferPanel(HCC hcc, string[] buffer, bool factorEnable)
		{
			try
			{
				bool flag = buffer == null || buffer.Length == 0 || buffer.Length != 3;
				if (flag)
				{
					throw new Exception("THIS SITE INFORMATION IS INVALID DATA. PLEASE CONTACT TO TFA TEAM.");
				}
				this._hCC = hcc;
				this._factorEnable = factorEnable;
				base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
				base.UpdateStyles();
				base.Name = this._hCC.siteMap.SITEPANEL + Convert.ToInt32(buffer[0].Trim());
				this.Cursor = Cursors.Hand;
				this.Dock = DockStyle.Fill;
				this.BackColor = this._hCC.siteMap.NOTUSE_COLOR;
				this.SiteStatus = (SITESTATUS)Convert.ToInt32(buffer[1]);
				this.SiteNo = Convert.ToInt32(buffer[0]);
				this.Failure = ((this.SiteStatus == SITESTATUS.GOOD) ? this._hCC.siteMap.GOOD : buffer[2]);
				base.MouseDown += this.SiteMapMouseDown;
				this.createSubControls(this.SiteNo);
				this.setStatusText(this.SiteStatus, false, this.Failure);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00071DA0 File Offset: 0x0006FFA0
		private void createSubControls(int siteNo)
		{
			base.Controls.Add(new Label
			{
				Name = this._hCC.siteMap.STATUSLABEL,
				Dock = DockStyle.Fill,
				AutoSize = false,
				Font = new Font(this.Font, FontStyle.Bold),
				Text = this._hCC.siteMap.GOOD,
				TextAlign = ContentAlignment.TopCenter,
				BackColor = Color.Transparent,
				Parent = this
			});
			base.Controls.Add(new Label
			{
				Name = this._hCC.siteMap.NUMBERPANEL,
				Dock = DockStyle.Top,
				AutoSize = false,
				Font = new Font(this.Font, FontStyle.Bold),
				Text = ((this.SiteStatus == SITESTATUS.NOTUSE) ? string.Empty : siteNo.ToString()),
				BackColor = Color.Transparent,
				Size = new Size(1, this.Font.Height),
				Padding = new Padding(1, 1, 0, 0),
				Parent = this
			});
			base.Controls[0].MouseDown += this.SiteMapMouseDown;
			base.Controls[1].MouseDown += this.SiteMapMouseDown;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00071F10 File Offset: 0x00070110
		public void changeSiteNoText(string no)
		{
			int num = base.Controls.IndexOfKey(this._hCC.siteMap.NUMBERPANEL);
			bool flag = num < 0;
			if (!flag)
			{
				base.Controls[num].Text = no;
			}
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00071F58 File Offset: 0x00070158
		public bool setStatusText(SITESTATUS status, bool notInitial, string text)
		{
			int num = base.Controls.IndexOfKey(this._hCC.siteMap.STATUSLABEL);
			bool flag = num != -1;
			bool result;
			if (flag)
			{
				bool flag2 = this.SiteStatus != SITESTATUS.NOTUSE;
				if (flag2)
				{
					switch (status)
					{
					case SITESTATUS.GOOD:
						this.BackColor = this._hCC.siteMap.GOOD_COLOR;
						this.Failure = this._hCC.siteMap.GOOD;
						break;
					case SITESTATUS.REJECT:
						this.BackColor = ((text.IndexOf(",") == -1) ? this._hCC.siteMap.REJECT_COLOR : this._hCC.siteMap.OVERLAB_REJECT_COLOR);
						break;
					case SITESTATUS.DISABLE:
						if (notInitial)
						{
							bool flag3 = this.BackColor == this._hCC.siteMap.REJECT_COLOR || this.BackColor == this._hCC.siteMap.OVERLAB_REJECT_COLOR;
							if (!flag3)
							{
								return false;
							}
							this.BackColor = this._hCC.siteMap.DISABLE_COLOR;
						}
						else
						{
							this.BackColor = this._hCC.siteMap.DISABLE_COLOR;
						}
						break;
					case SITESTATUS.NOTUSE:
						this.BackColor = this._hCC.siteMap.NOTUSE_COLOR;
						this.ContextMenuStrip = null;
						break;
					}
					string text2 = string.Empty;
					if (notInitial)
					{
						text2 = this.Failure;
					}
					else
					{
						this.Failure = text;
					}
					this.SiteStatus = status;
					bool flag4 = this.BackColor.Equals(this._hCC.siteMap.DISABLE_COLOR);
					if (flag4)
					{
						base.Controls[num].Text = this.Failure;
					}
					else
					{
						this.Failure = text;
						base.Controls[num].Text = text;
					}
				}
				else
				{
					this.BackColor = this._hCC.siteMap.NOTUSE_COLOR;
					this.ContextMenuStrip = null;
					this.Failure = string.Empty;
					text = string.Empty;
					base.Controls[num].Text = text;
					this.SiteStatus = SITESTATUS.NOTUSE;
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x000721D0 File Offset: 0x000703D0
		private void SiteMapMouseDown(object o, MouseEventArgs e)
		{
			try
			{
				bool flag = this.SiteStatus == SITESTATUS.NOTUSE;
				if (!flag)
				{
					SiteMapMultiSelectDialog siteMapMultiSelectDialog = new SiteMapMultiSelectDialog(this, this._hCC, false, this._factorEnable, false);
					bool flag2 = siteMapMultiSelectDialog.DialogResult != DialogResult.Abort;
					if (flag2)
					{
						siteMapMultiSelectDialog.ShowDialog();
					}
				}
			}
			catch (Exception ex)
			{
				cFunction.ErrorMessageBox(ex.Message.ToString(), "SiteMapMouseDown", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\SubControl\\SiteMap.cs", 1329);
			}
		}

		// Token: 0x04000610 RID: 1552
		private readonly bool _factorEnable = false;
	}
}
