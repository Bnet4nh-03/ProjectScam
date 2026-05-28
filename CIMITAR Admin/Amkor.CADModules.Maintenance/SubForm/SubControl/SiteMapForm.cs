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
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x0200003B RID: 59
	public partial class SiteMapForm : Form, IHCC
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x0006DA75 File Offset: 0x0006BC75
		public HCC _hCC { get; }

		// Token: 0x060003A6 RID: 934 RVA: 0x0006DA7D File Offset: 0x0006BC7D
		private void pnSiteChart_MouseLeave(object sender, EventArgs e)
		{
			this.pnSiteChart.Image = Resources.analysis;
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0006DA90 File Offset: 0x0006BC90
		private void pnSiteChart_MouseEnter(object sender, EventArgs e)
		{
			this.pnSiteChart.Image = Resources.analysis_down;
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0006DAA4 File Offset: 0x0006BCA4
		public SiteMapForm(FactorySettings factorySettings, cReportItem report, HCC hCC, bool canEdit)
		{
			this._hCC = hCC;
			this._maxSite = Convert.ToInt32(this._hCC.hCCParameter.site);
			this._siteListTemp = (this._siteList = new Control[this._maxSite]);
			this._report = report;
			this._canEdit = canEdit;
			this._factorySettings = factorySettings;
			this.InitializeComponent();
			this.rbAllSiteGood.Enabled = this._canEdit;
			this.rbAllSiteReject.Enabled = this._canEdit;
			this.pbOK.Visible = this._canEdit;
			this.pnGoodColor.BackColor = this._hCC.siteMap.GOOD_COLOR;
			this.pnRejectColor.BackColor = this._hCC.siteMap.REJECT_COLOR;
			this.pnAlreadyReject.BackColor = this._hCC.siteMap.OVERLAB_REJECT_COLOR;
			this.lbHCCLocation.Text = "Location : " + this._hCC.hCCParameter.location;
			bool flag = this._hCC.hCCParameter.siteDirection == SITE_DRIECTION.NONE;
			if (flag)
			{
				int num = this._hCC.hCCParameter.siteRow * this._hCC.hCCParameter.siteCol;
				bool flag2 = num > this._maxSite;
				if (flag2)
				{
					this._maxSite = num;
					this._siteList = (this._siteListTemp = new Control[this._maxSite]);
				}
			}
			this._factorEnable = this._canEdit;
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x0006DC6C File Offset: 0x0006BE6C
		private void createMenuStrip()
		{
			this._contextMenuStrip = new ContextMenuStrip();
			this._contextMenuStrip.Items.Add("SITE NUMBER :");
			this._contextMenuStrip.Items.Add(new ToolStripSeparator());
			this._contextMenuStrip.Size = new Size(161, 223);
			this._contextMenuStrip.Items.Add(this._hCC.siteMap.GOOD);
			this._contextMenuStrip.Items[this._contextMenuStrip.Items.Count - 1].Tag = this._hCC.siteMap.GOOD;
			this._contextMenuStrip.Items.Add(this._hCC.siteMap.DISABLE);
			this._contextMenuStrip.Items[this._contextMenuStrip.Items.Count - 1].Tag = this._hCC.siteMap.DISABLE;
			this._contextMenuStrip.Items[this._contextMenuStrip.Items.Count - 1].Enabled = false;
			this._contextMenuStrip.Items.Add(this._hCC.siteMap.HARDWARE);
			this._contextMenuStrip.Items.Add(this._hCC.siteMap.CONTACT);
			this._contextMenuStrip.Items.Add(this._hCC.siteMap.FUNCTION);
			this._contextMenuStrip.Items.Add(this._hCC.siteMap.OTHER);
			this._contextMenuStrip.Items.Add(new ToolStripSeparator());
			this._contextMenuStrip.Items.Add(new SiteMapToolStripLabel("[MANUAL REJECT]"));
			this._contextMenuStrip.Items[this._contextMenuStrip.Items.Count - 1].Visible = false;
			this._contextMenuStrip.Items.Add(new SiteMapToolStripTextBox("INPUT COMMENT"));
			this._contextMenuStrip.Items[this._contextMenuStrip.Items.Count - 1].Visible = false;
			this._contextMenuStrip.Items.Add(new SiteMapToolStripButton("APPLY"));
			this._contextMenuStrip.Items[this._contextMenuStrip.Items.Count - 1].Visible = false;
			foreach (KeyValuePair<string, Dictionary<string, List<string>>> keyValuePair in this._hCC.siteMap.factors)
			{
				bool flag = keyValuePair.Key == this._hCC.siteMap.REJECT;
				if (flag)
				{
					foreach (KeyValuePair<string, List<string>> keyValuePair2 in keyValuePair.Value)
					{
						bool flag2 = keyValuePair2.Key == this._hCC.siteMap.HARDWARE;
						if (flag2)
						{
							foreach (string text in keyValuePair2.Value)
							{
								((ToolStripMenuItem)this._contextMenuStrip.Items[4]).DropDownItems.Add(text);
								((ToolStripMenuItem)this._contextMenuStrip.Items[4]).DropDownItems[((ToolStripMenuItem)this._contextMenuStrip.Items[4]).DropDownItems.Count - 1].Tag = this._hCC.siteMap.REJECT;
							}
						}
						else
						{
							bool flag3 = keyValuePair2.Key == this._hCC.siteMap.CONTACT;
							if (flag3)
							{
								foreach (string text2 in keyValuePair2.Value)
								{
									((ToolStripMenuItem)this._contextMenuStrip.Items[5]).DropDownItems.Add(text2);
									((ToolStripMenuItem)this._contextMenuStrip.Items[5]).DropDownItems[((ToolStripMenuItem)this._contextMenuStrip.Items[5]).DropDownItems.Count - 1].Tag = this._hCC.siteMap.REJECT;
								}
							}
							else
							{
								bool flag4 = keyValuePair2.Key == this._hCC.siteMap.FUNCTION;
								if (flag4)
								{
									foreach (string text3 in keyValuePair2.Value)
									{
										((ToolStripMenuItem)this._contextMenuStrip.Items[6]).DropDownItems.Add(text3);
										((ToolStripMenuItem)this._contextMenuStrip.Items[6]).DropDownItems[((ToolStripMenuItem)this._contextMenuStrip.Items[6]).DropDownItems.Count - 1].Tag = this._hCC.siteMap.REJECT;
									}
								}
								else
								{
									bool flag5 = keyValuePair2.Key == this._hCC.siteMap.OTHER;
									if (flag5)
									{
										foreach (string text4 in keyValuePair2.Value)
										{
											((ToolStripMenuItem)this._contextMenuStrip.Items[7]).DropDownItems.Add(text4);
											((ToolStripMenuItem)this._contextMenuStrip.Items[7]).DropDownItems[((ToolStripMenuItem)this._contextMenuStrip.Items[7]).DropDownItems.Count - 1].Tag = this._hCC.siteMap.REJECT;
										}
									}
								}
							}
						}
					}
				}
			}
			this._contextMenuStrip.Items[0].Enabled = false;
			this._contextMenuStrip.Items[0].Font = new Font(this._contextMenuStrip.Items[0].Font, FontStyle.Bold | FontStyle.Underline);
			this._contextMenuStrip.ItemClicked += this.ContextMenuStripItemClick;
			((ToolStripMenuItem)this._contextMenuStrip.Items[3]).DropDownItemClicked += this.ContextMenuStripItemClick;
			((ToolStripMenuItem)this._contextMenuStrip.Items[4]).DropDownItemClicked += this.ContextMenuStripItemClick;
			((ToolStripMenuItem)this._contextMenuStrip.Items[5]).DropDownItemClicked += this.ContextMenuStripItemClick;
			((ToolStripMenuItem)this._contextMenuStrip.Items[6]).DropDownItemClicked += this.ContextMenuStripItemClick;
			((ToolStripMenuItem)this._contextMenuStrip.Items[7]).DropDownItemClicked += this.ContextMenuStripItemClick;
			this._contextMenuStrip.Opened += this.contextMenuStripOpened;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0006E510 File Offset: 0x0006C710
		private void contextMenuStripOpened(object o, EventArgs arg)
		{
			bool flag = o.GetType().Equals(typeof(ContextMenuStrip));
			ContextMenuStrip contextMenuStrip;
			if (flag)
			{
				contextMenuStrip = (ContextMenuStrip)o;
			}
			else
			{
				contextMenuStrip = (ContextMenuStrip)((ToolStripMenuItem)o).Owner;
			}
			bool flag2 = contextMenuStrip != null && contextMenuStrip.Tag != null;
			if (flag2)
			{
				try
				{
					int siteNumber = Convert.ToInt32(contextMenuStrip.Tag.ToString());
					DoubleBufferPanel doubleBufferPanel = (DoubleBufferPanel)this._siteList.FirstOrDefault((Control x) => ((DoubleBufferPanel)x).SiteNo == siteNumber);
					bool flag3 = doubleBufferPanel.SiteStatus == SITESTATUS.REJECT;
					if (flag3)
					{
						contextMenuStrip.Items[3].Enabled = true;
					}
					else
					{
						contextMenuStrip.Items[3].Enabled = false;
					}
				}
				catch (Exception ex)
				{
					cFunction.ErrorMessageBox(ex.Message.ToString(), "contextMenuStripOpened", "D:\\SVN\\CMTDEV451\\02_CIMitarClient\\02_App_Modules\\Amkor.CIMitarAdmin\\Amkor.CADModules.Maintenance\\Amkor.CADModules.Maintenance\\SubForm\\SubControl\\SiteMap.cs", 208);
				}
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0006E620 File Offset: 0x0006C820
		public bool createSiteMapData(bool realMap)
		{
			int num = 0;
			bool canEdit = this._canEdit;
			if (canEdit)
			{
				this.createMenuStrip();
			}
			string[] array = cFunction.getBoardSiteMap(this._factorySettings, this._hCC.hCCParameter.location, this.cbRealSiteMap.Checked, this.cbRealSiteMap.Checked ? string.Empty : this._report.sReportName).Trim().Split(new char[]
			{
				'|'
			});
			bool flag = array.Length - 1 != 0;
			if (flag)
			{
				bool flag2 = this._hCC.hCCParameter.siteRow * this._hCC.hCCParameter.siteCol != array.Length - 1;
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("wrong_sitemap_size").Replace("@1", (this._hCC.hCCParameter.siteCol * this._hCC.hCCParameter.siteRow).ToString()).Replace("@2", (array.Length - 1).ToString()), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return false;
				}
			}
			bool flag3 = array.Length == 1 || array.Length == 0;
			if (flag3)
			{
				array = new string[this._maxSite];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = i + 1 + "@1@GOOD";
				}
			}
			bool result;
			try
			{
				this._hCC.siteMap.mapData = array;
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = array[j].Replace("@4@", "@3@");
				}
				switch (this._hCC.hCCParameter.siteDirection)
				{
				case SITE_DRIECTION.NONE:
				{
					string[] array2 = this._hCC.hCCParameter.numberOfSite.Split(new char[]
					{
						','
					});
					int num2 = 0;
					while (num2 < array2.Length && num2 < this._siteList.Length && num < array.Length)
					{
						bool flag4 = array2[num2].Trim() == "0";
						if (flag4)
						{
							this._siteList[num] = new DoubleBufferPanel(this._hCC, SITESTATUS.NOTUSE, num2 + 1, string.Empty, this._factorEnable)
							{
								ContextMenuStrip = null
							};
						}
						else
						{
							this._siteList[num] = new DoubleBufferPanel(this._hCC, array[num].Split(new char[]
							{
								'@'
							}), this._factorEnable);
							((DoubleBufferPanel)this._siteList[num]).changeSiteNoText(array2[num2]);
						}
						num++;
						num2++;
					}
					break;
				}
				case SITE_DRIECTION.RIGHT:
				{
					int num3 = 0;
					while (num3 < this._hCC.hCCParameter.siteRow && num < this._siteList.Length)
					{
						int num4 = 0;
						while (num4 < this._hCC.hCCParameter.siteCol && num < array.Length)
						{
							this._siteList[this._hCC.hCCParameter.siteCol * num3 + num4] = new DoubleBufferPanel(this._hCC, array[num].Split(new char[]
							{
								'@'
							}), this._factorEnable);
							num++;
							num4++;
						}
						num3++;
					}
					break;
				}
				case SITE_DRIECTION.DOWN:
				{
					int num5 = 0;
					while (num5 < this._hCC.hCCParameter.siteRow && num < this._siteList.Length)
					{
						int num6 = 0;
						while (num6 < this._hCC.hCCParameter.siteCol && num < array.Length)
						{
							this._siteList[this._hCC.hCCParameter.siteRow * num6 + num5] = new DoubleBufferPanel(this._hCC, array[num].Split(new char[]
							{
								'@'
							}), this._factorEnable);
							num++;
							num6++;
						}
						num5++;
					}
					break;
				}
				case SITE_DRIECTION.LEFT:
				{
					int num7 = 0;
					while (num7 < this._hCC.hCCParameter.siteCol && num < this._siteList.Length)
					{
						int num8 = 0;
						while (num8 < this._hCC.hCCParameter.siteRow && num < array.Length)
						{
							this._siteList[this._hCC.hCCParameter.siteRow - num8 - 1 + num7 * this._hCC.hCCParameter.siteRow] = new DoubleBufferPanel(this._hCC, array[num].Split(new char[]
							{
								'@'
							}), this._factorEnable);
							num++;
							num8++;
						}
						num7++;
					}
					break;
				}
				case SITE_DRIECTION.UP:
				{
					int num9 = 0;
					while (num9 < this._hCC.hCCParameter.siteRow && num < this._siteList.Length)
					{
						int num10 = 0;
						while (num10 < this._hCC.hCCParameter.siteCol && num < array.Length)
						{
							this._siteList[this._hCC.hCCParameter.siteRow * this._hCC.hCCParameter.siteCol - (this._hCC.hCCParameter.siteRow + num10 * this._hCC.hCCParameter.siteRow) + num9] = new DoubleBufferPanel(this._hCC, array[num].Split(new char[]
							{
								'@'
							}), this._factorEnable);
							num++;
							num10++;
						}
						num9++;
					}
					break;
				}
				case SITE_DRIECTION.RIGHT_DOWN_RIGHT:
				{
					int num11 = 0;
					while (num11 < this._hCC.hCCParameter.siteRow && num < this._siteList.Length)
					{
						int num12 = 0;
						while (num12 < this._hCC.hCCParameter.siteCol && num < array.Length)
						{
							this._siteList[this._hCC.hCCParameter.siteCol * num11 + num12] = new DoubleBufferPanel(this._hCC, array[num].Split(new char[]
							{
								'@'
							}), this._factorEnable);
							num++;
							num12++;
						}
						num11++;
					}
					break;
				}
				case SITE_DRIECTION.LEFT_UP_LEFT:
				{
					int num13 = 0;
					while (num13 < this._hCC.hCCParameter.siteRow && num < this._siteList.Length)
					{
						int num14 = 0;
						while (num14 < this._hCC.hCCParameter.siteCol && num < array.Length)
						{
							this._siteList[this._hCC.hCCParameter.siteCol * this._hCC.hCCParameter.siteRow - (num14 + this._hCC.hCCParameter.siteCol * num13) - 1] = new DoubleBufferPanel(this._hCC, array[num].Split(new char[]
							{
								'@'
							}), this._factorEnable);
							num++;
							num14++;
						}
						num13++;
					}
					break;
				}
				case SITE_DRIECTION.DOWN_RIGHT_DOWN:
				{
					int num15 = 0;
					while (num15 < this._hCC.hCCParameter.siteRow && num < this._siteList.Length)
					{
						int num16 = 0;
						while (num16 < this._hCC.hCCParameter.siteCol && num < array.Length)
						{
							this._siteList[this._hCC.hCCParameter.siteRow * num16 + num15] = new DoubleBufferPanel(this._hCC, array[num].Split(new char[]
							{
								'@'
							}), this._factorEnable);
							num++;
							num16++;
						}
						num15++;
					}
					break;
				}
				case SITE_DRIECTION.UP_LEFT_UP:
				{
					int num17 = 0;
					while (num17 < this._hCC.hCCParameter.siteRow && num < this._siteList.Length)
					{
						int num18 = 0;
						while (num18 < this._hCC.hCCParameter.siteCol && num < array.Length)
						{
							this._siteList[this._hCC.hCCParameter.siteRow * this._hCC.hCCParameter.siteCol - (num18 * this._hCC.hCCParameter.siteRow + 1) - num17] = new DoubleBufferPanel(this._hCC, array[num].Split(new char[]
							{
								'@'
							}), this._factorEnable);
							num++;
							num18++;
						}
						num17++;
					}
					break;
				}
				case SITE_DRIECTION.LEFT_DOWN_LEFT:
				{
					int num19 = 0;
					while (num19 < this._hCC.hCCParameter.siteCol && num < this._siteList.Length)
					{
						int num20 = 0;
						while (num20 < this._hCC.hCCParameter.siteRow && num < array.Length)
						{
							this._siteList[this._hCC.hCCParameter.siteRow - num20 - 1 + num19 * this._hCC.hCCParameter.siteRow] = new DoubleBufferPanel(this._hCC, array[num].Split(new char[]
							{
								'@'
							}), this._factorEnable);
							num++;
							num20++;
						}
						num19++;
					}
					break;
				}
				case SITE_DRIECTION.RIGHT_UP_RIGHT:
				{
					int num21 = 0;
					while (num21 < this._hCC.hCCParameter.siteCol && num < this._siteList.Length)
					{
						int num22 = 0;
						while (num22 < this._hCC.hCCParameter.siteRow && num < array.Length)
						{
							this._siteList[this._hCC.hCCParameter.siteCol * this._hCC.hCCParameter.siteRow - this._hCC.hCCParameter.siteRow * num21 - this._hCC.hCCParameter.siteRow + num22] = new DoubleBufferPanel(this._hCC, array[num].Split(new char[]
							{
								'@'
							}), this._factorEnable);
							num++;
							num22++;
						}
						num21++;
					}
					break;
				}
				case SITE_DRIECTION.DOWN_LEFT_DOWN:
				{
					int num23 = 0;
					while (num23 < this._hCC.hCCParameter.siteRow && num < this._siteList.Length - 1)
					{
						int num24 = 0;
						while (num24 < this._hCC.hCCParameter.siteCol && num < array.Length - 1)
						{
							this._siteList[this._hCC.hCCParameter.siteRow * (num24 + 1) - 1 - num23] = new DoubleBufferPanel(this._hCC, array[num].Split(new char[]
							{
								'@'
							}), this._factorEnable);
							num++;
							num24++;
						}
						num23++;
					}
					break;
				}
				case SITE_DRIECTION.UP_RIGHT_UP:
				{
					int num25 = 0;
					while (num25 < this._hCC.hCCParameter.siteRow && num < this._siteList.Length)
					{
						int num26 = 0;
						while (num26 < this._hCC.hCCParameter.siteCol && num < array.Length)
						{
							this._siteList[this._hCC.hCCParameter.siteRow * this._hCC.hCCParameter.siteCol - (this._hCC.hCCParameter.siteRow + num26 * this._hCC.hCCParameter.siteRow) + num25] = new DoubleBufferPanel(this._hCC, array[num].Split(new char[]
							{
								'@'
							}), this._factorEnable);
							num++;
							num26++;
						}
						num25++;
					}
					break;
				}
				}
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), MessageLanguage.getMessage("messagebox_error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = false;
			}
			return result;
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0006F310 File Offset: 0x0006D510
		private bool createSiteMap(bool Initialize, bool realMap)
		{
			this.SiteMapLayout.Controls.Clear();
			this.SiteMapLayout.ColumnStyles.Clear();
			this.SiteMapLayout.RowStyles.Clear();
			this.SiteMapLayout.ColumnCount = this._hCC.hCCParameter.siteRow + 1;
			if (Initialize)
			{
				this.SiteMapLayout.RowCount = this._hCC.hCCParameter.siteCol + 1;
				bool flag = !this.createSiteMapData(realMap);
				if (flag)
				{
					return false;
				}
			}
			else
			{
				int num = (this._siteList.Length > 10) ? (this._siteList.Length / 10) : 10;
				num = ((this._siteList.Length > 10) ? (num + this._siteList.Length % 10) : 1);
				this.SiteMapLayout.ColumnCount = 11;
				this.SiteMapLayout.RowCount = num + 1;
			}
			for (int i = 1; i < this.SiteMapLayout.ColumnCount; i++)
			{
				this.SiteMapLayout.Controls.Add(new DoubleBufferCheckBox
				{
					Name = this._hCC.siteMap.CHACKLABEL_COL + i.ToString(),
					colPosition = i,
					rowPosition = 0,
					isCol = true,
					Checked = false,
					CheckAlign = ContentAlignment.MiddleCenter,
					Dock = DockStyle.Fill,
					Parent = this.SiteMapLayout,
					Enabled = this._canEdit
				}, i, 0);
				((DoubleBufferCheckBox)this.SiteMapLayout.Controls[this.SiteMapLayout.Controls.Count - 1]).CheckedChanged += this.SelectedSiteLine;
			}
			for (int j = 1; j < this.SiteMapLayout.RowCount; j++)
			{
				this.SiteMapLayout.Controls.Add(new DoubleBufferCheckBox
				{
					Name = this._hCC.siteMap.CHACKLABEL_ROW + j.ToString(),
					rowPosition = j,
					colPosition = 0,
					isRow = true,
					Checked = false,
					CheckAlign = ContentAlignment.MiddleCenter,
					Dock = DockStyle.Fill,
					Parent = this.SiteMapLayout,
					Enabled = this._canEdit
				}, 0, j);
				((DoubleBufferCheckBox)this.SiteMapLayout.Controls[this.SiteMapLayout.Controls.Count - 1]).CheckedChanged += this.SelectedSiteLine;
			}
			this.SiteMapLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30f));
			this.SiteMapLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
			this.SiteMapLayout.Controls.Add(new Panel(), 0, 0);
			this.SiteMapLayout.Controls.AddRange(this._siteList.ToArray<Control>());
			this.calcSiteSummary();
			return true;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0006F647 File Offset: 0x0006D847
		private void SetSiteStatus(int index, string rejectReason = "")
		{
			((DoubleBufferPanel)this._siteList[index]).setStatusText(this.rangeDialogResult, true, rejectReason);
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0006F668 File Offset: 0x0006D868
		private void SetSiteStatus(SITESTATUS status, string rejectReason = "")
		{
			bool flag = this._siteList != null;
			if (flag)
			{
				this._siteList.ToList<Control>().ForEach(delegate(Control x)
				{
					bool flag2 = x != null;
					if (flag2)
					{
						((DoubleBufferPanel)x).setStatusText(status, false, rejectReason);
					}
				});
				this.calcSiteSummary();
			}
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0006F6C0 File Offset: 0x0006D8C0
		private void calcSiteSummary()
		{
			bool flag = this._siteList == null || this._siteList.Length == 0;
			if (!flag)
			{
				int num = this._siteList.Count((Control x) => x != null && ((DoubleBufferPanel)x).SiteStatus == SITESTATUS.GOOD);
				int num2 = this._siteList.Count((Control x) => x != null && ((DoubleBufferPanel)x).SiteStatus == SITESTATUS.DISABLE);
				int num3 = this._siteList.Count((Control x) => x != null && ((DoubleBufferPanel)x).SiteStatus == SITESTATUS.REJECT);
				this.lbSummary.Text = string.Format("Good : {0} | Reject : {1} | Disable : {2}", num, num3, num2);
			}
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0006F795 File Offset: 0x0006D995
		private void pbCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0006F7A8 File Offset: 0x0006D9A8
		private void pbCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pbCancel.Image = Resources.cancel_down;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0006F7BB File Offset: 0x0006D9BB
		private void pbOK_MouseEnter(object sender, EventArgs e)
		{
			this.pbOK.Image = Resources.apply_down;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0006F7CE File Offset: 0x0006D9CE
		private void pbOK_MouseLeave(object sender, EventArgs e)
		{
			this.pbOK.Image = Resources.apply;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0006F7E4 File Offset: 0x0006D9E4
		private void rbAllSiteGood_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this._Initialize && this.rbAllSiteGood.Checked;
			if (flag)
			{
				bool flag2 = MessageBox.Show(MessageLanguage.getMessage("sitemap_allgood"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes;
				if (flag2)
				{
					this.SetSiteStatus(SITESTATUS.GOOD, this._hCC.siteMap.GOOD);
				}
				this.rbAllSiteGood.Checked = false;
			}
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0006F858 File Offset: 0x0006DA58
		private void rbAllSiteFail_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = !this._Initialize && this.rbAllSiteReject.Checked;
			if (flag)
			{
				SiteMapMultiSelectDialog siteMapMultiSelectDialog = new SiteMapMultiSelectDialog(this, this._hCC, true, this._report.sReportStauts != "2", true);
				bool flag2 = siteMapMultiSelectDialog.ShowDialog() == DialogResult.OK;
				if (flag2)
				{
					this.SetSiteStatus(SITESTATUS.REJECT, this.rangeDialogSelectedReject);
					this.rangeDialogResult = SITESTATUS.REJECT;
					this.rangeDialogSelectedReject = string.Empty;
				}
				this.rbAllSiteReject.Checked = false;
			}
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0006F8E8 File Offset: 0x0006DAE8
		private void SiteMapLayout_ControlAdded(object sender, ControlEventArgs e)
		{
			bool flag = !e.Control.GetType().Equals(typeof(DoubleBufferCheckBox));
			if (flag)
			{
				this.SiteMapLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));
				this.SiteMapLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50f));
			}
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0006F954 File Offset: 0x0006DB54
		private void tbSiteStartNumber_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b';
			if (flag)
			{
				e.Handled = true;
			}
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0006F98C File Offset: 0x0006DB8C
		private void tbSiteStartNumber_MouseClick(object sender, MouseEventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			bool flag = !char.IsDigit(textBox.Text.ToCharArray()[0]);
			if (flag)
			{
				textBox.Text = string.Empty;
			}
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0006F9C8 File Offset: 0x0006DBC8
		private void ContextMenuStripItemClick(object o, ToolStripItemClickedEventArgs e)
		{
			bool flag = o.GetType().Equals(typeof(ContextMenuStrip));
			ContextMenuStrip contextMenuStrip;
			if (flag)
			{
				contextMenuStrip = (ContextMenuStrip)o;
			}
			else
			{
				contextMenuStrip = (ContextMenuStrip)((ToolStripMenuItem)o).Owner;
			}
			bool flag2 = contextMenuStrip != null && contextMenuStrip.Tag != null;
			if (flag2)
			{
				try
				{
					int siteNumber = Convert.ToInt32(contextMenuStrip.Tag.ToString());
					DoubleBufferPanel doubleBufferPanel = (DoubleBufferPanel)this._siteList.FirstOrDefault((Control x) => ((DoubleBufferPanel)x).SiteNo == siteNumber);
					bool flag3 = e.ClickedItem.Tag == null;
					if (!flag3)
					{
						string a = e.ClickedItem.Tag.ToString();
						bool flag4 = a == this._hCC.siteMap.GOOD;
						bool flag5;
						if (flag4)
						{
							flag5 = doubleBufferPanel.setStatusText(SITESTATUS.GOOD, true, e.ClickedItem.ToString().Trim().ToUpper());
						}
						else
						{
							bool flag6 = a == this._hCC.siteMap.DISABLE;
							if (flag6)
							{
								flag5 = doubleBufferPanel.setStatusText(SITESTATUS.DISABLE, true, e.ClickedItem.ToString().Trim().ToUpper());
							}
							else
							{
								flag5 = doubleBufferPanel.setStatusText(SITESTATUS.REJECT, true, e.ClickedItem.ToString().Trim().ToUpper());
							}
						}
						bool flag7 = !flag5;
						if (flag7)
						{
							this._contextMenuStrip.Close();
							MessageBox.Show(MessageLanguage.getMessage("sitemap_reject"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						this.calcSiteSummary();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message.ToString(), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0006FBB0 File Offset: 0x0006DDB0
		private void SelectedSiteLine(object o, EventArgs e)
		{
			bool @checked = ((CheckBox)o).Checked;
			if (@checked)
			{
				CheckBox checkBox = (CheckBox)o;
				bool flag = MessageBox.Show(this, MessageLanguage.getMessage("sitemap_row_column_state"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel;
				if (flag)
				{
					checkBox.Checked = false;
				}
				else
				{
					SiteMapMultiSelectDialog siteMapMultiSelectDialog = new SiteMapMultiSelectDialog(this, this._hCC, true, this._report.sReportStauts != "2", false);
					bool flag2 = siteMapMultiSelectDialog.ShowDialog() == DialogResult.Cancel;
					if (flag2)
					{
						checkBox.Checked = false;
					}
					else
					{
						checkBox.Checked = false;
						int index = this.SiteMapLayout.Controls.IndexOf((CheckBox)o);
						DoubleBufferCheckBox doubleBufferCheckBox = (DoubleBufferCheckBox)this.SiteMapLayout.Controls[index];
						bool flag3 = doubleBufferCheckBox.Name.IndexOf(this._hCC.siteMap.CHACKLABEL_COL) != -1;
						if (flag3)
						{
							for (int i = 0; i < this._hCC.hCCParameter.siteCol; i++)
							{
								this.SetSiteStatus(i * this._hCC.hCCParameter.siteRow + (doubleBufferCheckBox.colPosition - 1), this.rangeDialogSelectedReject);
							}
						}
						else
						{
							bool flag4 = doubleBufferCheckBox.Name.IndexOf(this._hCC.siteMap.CHACKLABEL_ROW) != -1;
							if (flag4)
							{
								for (int j = 0; j < this._hCC.hCCParameter.siteRow; j++)
								{
									this.SetSiteStatus(j + (doubleBufferCheckBox.rowPosition - 1) * this._hCC.hCCParameter.siteRow, this.rangeDialogSelectedReject);
								}
							}
						}
						this.rangeDialogResult = SITESTATUS.REJECT;
						this.rangeDialogSelectedReject = string.Empty;
						this.calcSiteSummary();
					}
				}
			}
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0006FD9C File Offset: 0x0006DF9C
		private void pbOK_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = MessageBox.Show(MessageLanguage.getMessage("sitemap_save"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No;
				if (!flag)
				{
					string text = string.Empty;
					foreach (Control control in from x in this._siteList
					orderby ((DoubleBufferPanel)x).SiteNo
					select x)
					{
						DoubleBufferPanel doubleBufferPanel = (DoubleBufferPanel)control;
						text = string.Concat(new object[]
						{
							text,
							doubleBufferPanel.SiteNo,
							"@",
							Convert.ToInt32(doubleBufferPanel.SiteStatus),
							"@",
							doubleBufferPanel.Failure,
							"|"
						});
					}
					string text2 = cFunction.setBoardSiteMap(this._factorySettings, this._report.sReportName, this._hCC.hCCParameter.location, this._hCC.hCCParameter.siteCol, this._hCC.hCCParameter.siteRow, this._hCC.hCCParameter.siteDirection, this._hCC.hCCParameter.numberOfSite, text);
					bool flag2 = !string.IsNullOrEmpty(text2);
					if (flag2)
					{
						MessageBox.Show(text2, MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), MessageLanguage.getMessage("messagebox_error"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				base.Close();
			}
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0006FF98 File Offset: 0x0006E198
		private void pbCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0006FFA4 File Offset: 0x0006E1A4
		private void cbRejectView_CheckedChanged(object sender, EventArgs e)
		{
			this.SiteMapLayout.Controls.Clear();
			bool @checked = this.cbRejectView.Checked;
			if (@checked)
			{
				Array.Copy(this._siteList, this._siteListTemp, this._siteList.Length);
				Control[] array = this._siteList.ToList<Control>().FindAll((Control x) => ((DoubleBufferPanel)x).SiteStatus == SITESTATUS.REJECT).ToArray();
				bool flag = array.Length == 0;
				if (flag)
				{
					MessageBox.Show(MessageLanguage.getMessage("sitemap_not_find_reject"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					this._siteList = new Control[array.Length];
					this._siteList = array;
					this.createSiteMap(false, this.cbRealSiteMap.Checked);
				}
			}
			else
			{
				bool flag2 = this._siteList.Length != this._siteListTemp.Length;
				if (flag2)
				{
					this._siteList = new Control[this._maxSite];
				}
				Array.Copy(this._siteListTemp, this._siteList, this._siteListTemp.Length);
				this.createSiteMap(true, this.cbRealSiteMap.Checked);
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x000700D8 File Offset: 0x0006E2D8
		private void cbRealSiteMap_CheckedChanged(object sender, EventArgs e)
		{
			Array.Clear(this._siteList, 0, this._siteList.Length);
			bool flag = !this.createSiteMap(true, this.cbRealSiteMap.Checked);
			if (flag)
			{
				this._siteList = null;
				base.Close();
			}
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void pnSiteChart_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00070124 File Offset: 0x0006E324
		private void SiteMapForm_Shown(object sender, EventArgs e)
		{
			this.cbRealSiteMap.Checked = this._canEdit;
			this.cbRealSiteMap.Enabled = !this._canEdit;
			bool flag = !this._canEdit;
			if (flag)
			{
				this.cbRealSiteMap_CheckedChanged(null, null);
			}
			this._Initialize = false;
		}

		// Token: 0x040005DF RID: 1503
		private List<SiteMapInformation> _list = new List<SiteMapInformation>();

		// Token: 0x040005E0 RID: 1504
		private ContextMenuStrip _contextMenuStrip;

		// Token: 0x040005E1 RID: 1505
		private Control[] _siteList;

		// Token: 0x040005E2 RID: 1506
		private Control[] _siteListTemp;

		// Token: 0x040005E3 RID: 1507
		private bool _Initialize = true;

		// Token: 0x040005E4 RID: 1508
		private readonly int _maxSite;

		// Token: 0x040005E5 RID: 1509
		private readonly bool _canEdit;

		// Token: 0x040005E6 RID: 1510
		private readonly cReportItem _report;

		// Token: 0x040005E7 RID: 1511
		private readonly bool _factorEnable = false;

		// Token: 0x040005E9 RID: 1513
		public SITESTATUS rangeDialogResult = SITESTATUS.REJECT;

		// Token: 0x040005EA RID: 1514
		public string rangeDialogSelectedReject = string.Empty;

		// Token: 0x040005EB RID: 1515
		private FactorySettings _factorySettings;
	}
}
