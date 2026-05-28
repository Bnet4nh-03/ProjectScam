using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.GrobalConst.Interface;
using Amkor.CADModules.Maintenance.Properties;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000042 RID: 66
	public partial class SiteMapMultiSelectDialog : Form, IHCC
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x000723DB File Offset: 0x000705DB
		public HCC _hCC { get; }

		// Token: 0x060003D8 RID: 984 RVA: 0x000723E4 File Offset: 0x000705E4
		public SiteMapMultiSelectDialog(Control owner, HCC hCC, bool isColumn, bool enable, bool onlyReject)
		{
			this.InitializeComponent();
			try
			{
				this._hCC = hCC;
				this._enable = enable;
				if (isColumn)
				{
					base.Owner = (Form)owner;
				}
				else
				{
					this._sitemap = (DoubleBufferPanel)owner;
				}
				base.Size = this.sizeDefault;
				this.pnManualReject.Visible = false;
				bool flag = !this.rbManaulReject.Visible;
				if (flag)
				{
					this.pnManualReject.Visible = false;
					this.pnRejectReason.Dock = DockStyle.Fill;
				}
				if (onlyReject)
				{
					this.rbSiteReject.Checked = true;
					this.rbSiteGood.Visible = false;
					this.rbDisable.Visible = false;
				}
				bool flag2 = !isColumn;
				if (flag2)
				{
					bool flag3 = ((DoubleBufferPanel)owner).Controls.IndexOfKey(this._hCC.siteMap.NUMBERPANEL) != -1;
					if (!flag3)
					{
						throw new Exception("Can not find the site number. Please contact to the TFA team.");
					}
					this.lbTitle.Text = "Site No : " + ((DoubleBufferPanel)owner).Controls[this._hCC.siteMap.NUMBERPANEL].Text;
					this.rbDisable.Text = "Disable";
					this.rbSiteGood.Text = "Good";
					this.rbSiteReject.Text = "Reject";
					bool flag4 = ((DoubleBufferPanel)owner).SiteStatus == SITESTATUS.GOOD;
					if (flag4)
					{
						this.rbDisable.Enabled = false;
						this.rbSiteGood.Checked = true;
					}
					else
					{
						bool flag5 = ((DoubleBufferPanel)owner).SiteStatus == SITESTATUS.REJECT;
						if (flag5)
						{
							this.rbSiteReject.Checked = true;
						}
						else
						{
							bool flag6 = ((DoubleBufferPanel)owner).SiteStatus == SITESTATUS.DISABLE;
							if (flag6)
							{
								this.rbDisable.Checked = true;
							}
						}
					}
					bool flag7 = !this._enable;
					if (flag7)
					{
						this.rbDisable.Enabled = this._enable;
						this.rbSiteGood.Enabled = this._enable;
						this.rbSiteReject.Enabled = this._enable;
					}
				}
				this.pbOK.Visible = this._enable;
				this.tbFactor.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				cFunction.ErrorMessageBox(ex.Message.ToString(), ".ctor", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\SubControl\\SiteMapMultiSelectDialog.cs", 96);
				base.DialogResult = DialogResult.Abort;
				base.Close();
			}
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x000726E4 File Offset: 0x000708E4
		private void pbOK_MouseEnter(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.apply_down;
		}

		// Token: 0x060003DA RID: 986 RVA: 0x000726F7 File Offset: 0x000708F7
		private void pbOK_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.apply;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x00006E82 File Offset: 0x00005082
		private void pbCancel_MouseEnter(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.cancel_down;
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00006E95 File Offset: 0x00005095
		private void pbCancel_MouseLeave(object sender, EventArgs e)
		{
			((PictureBox)sender).Image = Resources.cancel;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0007270A File Offset: 0x0007090A
		private void rbSiteGood_CheckedChanged(object sender, EventArgs e)
		{
			base.Size = this.sizeDefault;
			this.pnRejectReason.Visible = false;
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00072727 File Offset: 0x00070927
		private void rbSiteReject_CheckedChanged(object sender, EventArgs e)
		{
			base.Size = this.sizeMaximum;
			this.pnRejectReason.Visible = true;
			this.setFactor(false);
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0007274C File Offset: 0x0007094C
		private void rbDisable_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = this._sitemap != null;
			if (flag)
			{
				base.Size = this.sizeMaximum;
				this.pnRejectReason.Visible = true;
				this.setFactor(true);
			}
			else
			{
				base.Size = this.sizeDefault;
				this.pnRejectReason.Visible = false;
			}
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x000727AC File Offset: 0x000709AC
		private void pbOK_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			bool @checked = this.rbSiteGood.Checked;
			if (@checked)
			{
				bool flag = this._sitemap != null;
				if (flag)
				{
					this._sitemap.setStatusText(SITESTATUS.GOOD, true, this._hCC.siteMap.GOOD);
				}
				else
				{
					((SiteMapForm)base.Owner).rangeDialogResult = SITESTATUS.GOOD;
					((SiteMapForm)base.Owner).rangeDialogSelectedReject = this._hCC.siteMap.GOOD;
				}
			}
			else
			{
				bool checked2 = this.rbSiteReject.Checked;
				if (checked2)
				{
					foreach (KeyValuePair<string, List<Control>> keyValuePair in this.checkcBoxs)
					{
						foreach (Control control in keyValuePair.Value)
						{
							CheckBox checkBox = (CheckBox)control;
							bool checked3 = checkBox.Checked;
							if (checked3)
							{
								bool flag2 = text.Length == 0;
								if (flag2)
								{
									text += checkBox.Text;
									text2 = checkBox.Text;
								}
								else
								{
									text = text + "," + checkBox.Text;
								}
							}
						}
					}
					bool flag3 = this.rbSiteReject.Checked && text.Length == 0;
					if (flag3)
					{
						MessageBox.Show(MessageLanguage.getMessage("check_sitemap_reject_content"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					bool flag4 = this._sitemap != null;
					if (flag4)
					{
						this._sitemap.setStatusText(SITESTATUS.REJECT, true, text);
					}
					else
					{
						((SiteMapForm)base.Owner).rangeDialogResult = SITESTATUS.REJECT;
						((SiteMapForm)base.Owner).rangeDialogSelectedReject = text;
					}
				}
				else
				{
					bool checked4 = this.rbDisable.Checked;
					if (checked4)
					{
						bool flag5 = this._sitemap != null;
						if (flag5)
						{
							this._sitemap.setStatusText(SITESTATUS.DISABLE, true, this._hCC.siteMap.DISABLE);
						}
						else
						{
							((SiteMapForm)base.Owner).rangeDialogResult = SITESTATUS.DISABLE;
							((SiteMapForm)base.Owner).rangeDialogSelectedReject = this._hCC.siteMap.DISABLE;
						}
					}
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00061297 File Offset: 0x0005F497
		private void pbCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00072A44 File Offset: 0x00070C44
		private void setFactor(bool isDisable)
		{
			this.checkcBoxs.Clear();
			int num = 1;
			string[] array = null;
			bool flag = this._sitemap != null;
			if (flag)
			{
				array = this._sitemap.Failure.Split(new char[]
				{
					','
				});
			}
			foreach (object obj in this.tbFactor.TabPages)
			{
				TabPage tabPage = (TabPage)obj;
				tabPage.Controls.Clear();
				foreach (KeyValuePair<string, List<string>> keyValuePair in this._hCC.siteMap.factors["REJECT"])
				{
					bool flag2 = keyValuePair.Key.ToUpper() == tabPage.Text.ToUpper();
					if (flag2)
					{
						using (List<string>.Enumerator enumerator3 = keyValuePair.Value.GetEnumerator())
						{
							while (enumerator3.MoveNext())
							{
								string factor = enumerator3.Current;
								bool flag3 = !this.checkcBoxs.ContainsKey(keyValuePair.Key.ToUpper());
								if (flag3)
								{
									this.checkcBoxs.Add(keyValuePair.Key, new List<Control>());
								}
								CheckBox checkBox = new CheckBox
								{
									Name = "rbContents" + num.ToString(),
									Text = factor,
									Dock = DockStyle.Top,
									AutoSize = true,
									Checked = (array != null && array.FirstOrDefault((string x) => x == factor) != null),
									TabIndex = num,
									Enabled = (!isDisable && this._enable)
								};
								this.checkcBoxs[keyValuePair.Key].Add(checkBox);
								tabPage.Controls.Add(checkBox);
								checkBox.BringToFront();
								num++;
							}
						}
					}
				}
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00072CD8 File Offset: 0x00070ED8
		private void tbFactor_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.checkcBoxs.Clear();
			this.tbFactor.TabPages[this.tbFactor.SelectedIndex].Controls.Clear();
			int num = 1;
			foreach (KeyValuePair<string, List<string>> keyValuePair in this._hCC.siteMap.factors["REJECT"])
			{
				bool flag = keyValuePair.Key == this.tbFactor.SelectedTab.Text;
				if (flag)
				{
					foreach (string text in keyValuePair.Value)
					{
						num++;
					}
				}
			}
		}

		// Token: 0x04000616 RID: 1558
		private List<Control> radioButtons = new List<Control>();

		// Token: 0x04000617 RID: 1559
		private Dictionary<string, List<Control>> checkcBoxs = new Dictionary<string, List<Control>>();

		// Token: 0x04000618 RID: 1560
		private readonly Size sizeDefault = new Size(283, 179);

		// Token: 0x04000619 RID: 1561
		private readonly Size sizeMaximum = new Size(435, 555);

		// Token: 0x0400061A RID: 1562
		private DoubleBufferPanel _sitemap = null;

		// Token: 0x0400061B RID: 1563
		private readonly bool _enable = false;
	}
}
