using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.Class;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using DevAge.Drawing;
using SourceGrid;
using SourceGrid.Cells;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.Maintenance.SubForm
{
	// Token: 0x0200000B RID: 11
	public partial class AdminSetting : BaseWinView
	{
		// Token: 0x06000065 RID: 101 RVA: 0x0000EF32 File Offset: 0x0000D132
		private void cbVendorFactory_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.setVendorNode();
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000EF3B File Offset: 0x0000D13B
		private void cbConfirmType_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.getConfirmationList();
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000EF44 File Offset: 0x0000D144
		public AdminSetting(FactorySettings factorySetting)
		{
			this._factorySetting = factorySetting;
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarMenu.menucode = 103001;
			this._cimitarUser = new CIMitarAccount();
			this._cimitarUser._exeExcel = false;
			this._queryMgr = new QueryMgr(this._factorySetting);
			this.InitializeComponent();
			base.Tag = MainPageType.Admin;
			this.pnMailList.Visible = true;
			this.pnToList.Visible = false;
			this.pnCCList.Visible = false;
			this.cbMailContents.SelectedIndex = -1;
			this.cbMailContents.SelectedIndex = 0;
			this.cbModelCategory.Items.Clear();
			this.cbContents.SelectedIndex = -1;
			this.cbContents.SelectedIndex = 0;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000F06F File Offset: 0x0000D26F
		public void initData()
		{
			this._bAutoLoadBlock = false;
			this.tcMenu.SelectedIndex = 0;
			this.InitGridCell();
			this.clearAllData();
			this.setPlant();
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000F09C File Offset: 0x0000D29C
		private void InitGridCell()
		{
			this.grid_Machine.Selection.EnableMultiSelection = false;
			this.grid_Machine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_Machine.CustomSort = true;
			this.grid_Asset.Selection.EnableMultiSelection = false;
			this.grid_Asset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.grid_Asset.CustomSort = true;
			this.cell_header1 = new SourceGrid.Cells.Views.Cell();
			this.cell_header1.BackColor = Color.FromArgb(130, 179, 237);
			this.cell_header1.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
			this.SetGridHeader();
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000F144 File Offset: 0x0000D344
		private void SetGridHeader()
		{
			this.grid_Machine.ColumnsCount = 21;
			this.grid_Machine.FixedRows = 1;
			this.grid_Machine.FixedColumns = 1;
			this.grid_Machine.Rows.Insert(0);
			this.grid_Machine[0, 0] = new SourceGrid.Cells.ColumnHeader("No.");
			this.grid_Machine[0, 0].View = this.cell_header1;
			this.grid_Machine[0, 1] = new SourceGrid.Cells.ColumnHeader("Machine Name");
			this.grid_Machine[0, 1].View = this.cell_header1;
			this.grid_Machine[0, 2] = new SourceGrid.Cells.ColumnHeader("Category");
			this.grid_Machine[0, 2].View = this.cell_header1;
			this.grid_Machine[0, 3] = new SourceGrid.Cells.ColumnHeader("Rsc Des");
			this.grid_Machine[0, 3].View = this.cell_header1;
			this.grid_Machine[0, 4] = new SourceGrid.Cells.ColumnHeader("Model");
			this.grid_Machine[0, 4].View = this.cell_header1;
			this.grid_Machine[0, 5] = new SourceGrid.Cells.ColumnHeader("Check");
			this.grid_Machine[0, 5].View = this.cell_header1;
			this.grid_Asset.ColumnsCount = 21;
			this.grid_Asset.FixedRows = 1;
			this.grid_Asset.FixedColumns = 1;
			this.grid_Asset.Rows.Insert(0);
			this.grid_Asset[0, 0] = new SourceGrid.Cells.ColumnHeader("No.");
			this.grid_Asset[0, 0].View = this.cell_header1;
			this.grid_Asset[0, 1] = new SourceGrid.Cells.ColumnHeader("Machine Name");
			this.grid_Asset[0, 1].View = this.cell_header1;
			this.grid_Asset[0, 2] = new SourceGrid.Cells.ColumnHeader("Asset #");
			this.grid_Asset[0, 2].View = this.cell_header1;
			this.grid_Asset[0, 3] = new SourceGrid.Cells.ColumnHeader("Check");
			this.grid_Asset[0, 3].View = this.cell_header1;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000F3B0 File Offset: 0x0000D5B0
		private void clearAllData()
		{
			this.grid_Machine.Rows.Clear();
			this.grid_Asset.Rows.Clear();
			this.cbModelCategory.Items.Clear();
			this.cbModelMachine.Items.Clear();
			this.cbRscMachine.Items.Clear();
			this.cbCategoryMachine.Items.Clear();
			this.tvModel.Nodes.Clear();
			this.tvToMailNode.Nodes.Clear();
			this.tvRscDec.Nodes.Clear();
			this.cbGroupMail.Items.Clear();
			this.tvCCMail.Nodes.Clear();
			this.tv_TeamList.Nodes.Clear();
			this.cbCCCategory.Items.Clear();
			this.cbCCMailTeam.Items.Clear();
			this.cbMailList.SelectedIndex = -1;
			this.cbMailList2.SelectedIndex = -1;
			this.tbModelName.Text = string.Empty;
			this.tbNameMachine.Text = string.Empty;
			this.tbRscName.Text = string.Empty;
			this.cbModelMachine.Text = string.Empty;
			this.cbCategoryMachine.Text = string.Empty;
			this.cbRscMachine.Text = string.Empty;
			this.cbGroupMail.Text = string.Empty;
			this.tb_mail.Text = string.Empty;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000F550 File Offset: 0x0000D750
		private void setPlant()
		{
			this._bInitPlant = true;
			this.tvRscDec.Nodes.Clear();
			this.tvFactorList.Nodes.Clear();
			this.cbRscCategory.Items.Clear();
			this.cbModelCategory.Items.Clear();
			this.tbRscName.Text = string.Empty;
			this.tbModelName.Text = string.Empty;
			cFunction.setPlant(this.cbRscPlant, this._factorySetting._factoryName);
			cFunction.setPlant(this.cbModelPlant, this._factorySetting._factoryName);
			cFunction.setPlant(this.cbMailPlant, this._factorySetting._factoryName);
			cFunction.setPlant(this.cbPlantMachine, this._factorySetting._factoryName);
			cFunction.setPlant(this.cbCCPlant, this._factorySetting._factoryName);
			cFunction.setPlant(this.cbToPlant, this._factorySetting._factoryName);
			cFunction.setPlant(this.cbPlant, this._factorySetting._factoryName);
			cFunction.setPlant(this.cbVendorFactory, this._factorySetting._factoryName);
			cFunction.setPlant(this.cbAssetFactory, this._factorySetting._factoryName);
			cFunction.setPlant(this.cbConfirmFactory, this._factorySetting._factoryName);
			this.cbPlantMachine.SelectedIndex = 0;
			this.cbRscPlant.SelectedIndex = 0;
			this.cbMailPlant.SelectedIndex = 0;
			this.cbCCPlant.SelectedIndex = 0;
			this.cbPlant.SelectedIndex = 0;
			this.cbModelPlant.SelectedIndex = 0;
			this.cbVendorFactory.SelectedIndex = 0;
			bool flag = this._factorySetting._factoryName == "ATK_E";
			if (flag)
			{
				cFunction.getCategoryListAll(this._factorySetting, "K3_E", new List<System.Windows.Forms.ComboBox>
				{
					this.cbModelCategory,
					this.cbCategoryMachine,
					this.cbRscCategory,
					this.cbGroupMail,
					this.cbCCCategory,
					this.cbFactorCategory,
					this.cbGroupMail
				}, false);
			}
			else
			{
				bool flag2 = this._factorySetting._factoryName == "ATK_K5_M";
				if (flag2)
				{
					cFunction.getCategoryListAll(this._factorySetting, "K5_M", new List<System.Windows.Forms.ComboBox>
					{
						this.cbModelCategory,
						this.cbCategoryMachine,
						this.cbRscCategory,
						this.cbGroupMail,
						this.cbCCCategory,
						this.cbFactorCategory,
						this.cbGroupMail
					}, false);
				}
				else
				{
					bool flag3 = this._factorySetting._factoryName == "ATK_K5";
					if (flag3)
					{
						cFunction.getCategoryListAll(this._factorySetting, "K5", new List<System.Windows.Forms.ComboBox>
						{
							this.cbModelCategory,
							this.cbCategoryMachine,
							this.cbRscCategory,
							this.cbGroupMail,
							this.cbCCCategory,
							this.cbFactorCategory,
							this.cbGroupMail
						}, false);
					}
					else
					{
						bool flag4 = this._factorySetting._factoryName == "ATV";
						if (flag4)
						{
							cFunction.getCategoryListAll(this._factorySetting, "ATV", new List<System.Windows.Forms.ComboBox>
							{
								this.cbModelCategory,
								this.cbModelCategory,
								this.cbCategoryMachine,
								this.cbRscCategory,
								this.cbGroupMail,
								this.cbCCCategory,
								this.cbFactorCategory,
								this.cbGroupMail
							}, false);
						}
						else
						{
							cFunction.getCategoryListAll(this._factorySetting, "K3", new List<System.Windows.Forms.ComboBox>
							{
								this.cbModelCategory,
								this.cbCategoryMachine,
								this.cbRscCategory,
								this.cbGroupMail,
								this.cbCCCategory,
								this.cbFactorCategory,
								this.cbGroupMail
							}, false);
						}
					}
				}
			}
			this.setModelNode();
			this._bInitPlant = false;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000F9E4 File Offset: 0x0000DBE4
		private void getMachineList()
		{
			bool flag = this.cbCategoryMachine.SelectedIndex == -1 || this.cbPlantMachine.SelectedIndex == -1;
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("select_search_option"), MessageLanguage.getMessage("messagebox_notification"));
			}
			else
			{
				this.grid_Machine.Rows.Clear();
				this.grid_Machine.Selection.EnableMultiSelection = false;
				this.grid_Machine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				this.grid_Machine.CustomSort = true;
				this.SetGridHeader();
				string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintMachineList]";
				text = text + " @_Plant=N'" + this.cbPlantMachine.SelectedItem.ToString().Trim() + "'";
				text = text + ", @_Catagory=N'" + this.cbCategoryMachine.SelectedItem.ToString().Trim() + "'";
				bool flag2 = this.cbModelMachine.SelectedIndex != -1;
				if (flag2)
				{
					text = text + ", @_Model=N'" + this.cbModelMachine.SelectedItem.ToString().Trim() + "'";
				}
				bool flag3 = this.cbRscMachine.SelectedIndex != -1;
				if (flag3)
				{
					text = text + ", @_Rsc=N'" + this.cbRscMachine.SelectedItem.ToString().Trim() + "'";
				}
				text = text + ", @_MachineName=N'" + this.tbNameMachine.Text.Trim() + "'";
				DataSet dataSet = this._queryMgr.queryCall(text);
				bool flag4 = dataSet != null && dataSet.Tables.Count > 0;
				if (flag4)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						this.grid_Machine.Rows.Insert(i + 1);
						this.grid_Machine[i + 1, 0] = new SourceGrid.Cells.Cell(i + 1);
						this.grid_Machine[i + 1, 1] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["MachineName"].ToString());
						this.grid_Machine[i + 1, 2] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["MachineCategory"].ToString());
						this.grid_Machine[i + 1, 3] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Rsc"].ToString());
						this.grid_Machine[i + 1, 4] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["Model"].ToString());
						this.grid_Machine[i + 1, 5] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
					}
				}
				this.grid_Machine.AutoSizeCells();
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000FD18 File Offset: 0x0000DF18
		private void getTeam()
		{
			this.tv_TeamList.Nodes.Clear();
			this.cbTeamlist.Items.Clear();
			cFunction.setPlant(this.cbTeamPlant, this._factorySetting._factoryName);
			cFunction.setPlant(this.cbTeamPlant2, this._factorySetting._factoryName);
			cFunction.setPlant(this.tv_TeamList, this._factorySetting._factoryName);
			this.cbMailList3.SelectedIndex = -1;
			this.cbTeamlist.SelectedIndex = -1;
			string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintTeamInfo]";
			text += " @_Plant='All'";
			DataSet dataSet = this._queryMgr.queryCall(text);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string text2 = dataSet.Tables[0].Rows[i]["Name"].ToString();
					string text3 = dataSet.Tables[0].Rows[i]["Mail"].ToString();
					string key = dataSet.Tables[0].Rows[i]["plant"].ToString();
					bool flag2 = this.tv_TeamList.Nodes.ContainsKey(key);
					if (flag2)
					{
						bool flag3 = text3.Trim() != string.Empty;
						if (flag3)
						{
							this.tv_TeamList.Nodes[key].Nodes.Add(text2).Nodes.Add(text3);
						}
						else
						{
							this.tv_TeamList.Nodes[key].Nodes.Add(text2);
						}
					}
				}
				this.tv_TeamList.ExpandAll();
				dataSet.Dispose();
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000FF1E File Offset: 0x0000E11E
		private void AdminSetting_Shown(object sender, EventArgs e)
		{
			this.initData();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000FF28 File Offset: 0x0000E128
		private void btnAppend_Click(object sender, EventArgs e)
		{
			bool flag = this.tbRscName.Text.Trim() != string.Empty;
			if (flag)
			{
				bool flag2 = this.cbRscPlant.SelectedIndex == -1 || this.cbRscCategory.SelectedIndex == -1;
				if (!flag2)
				{
					string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMachineType]";
					text = text + "@_Plant = N'" + this.cbRscPlant.SelectedItem.ToString().Trim() + "'";
					text = text + ", @_MachineType=N'" + this.tbRscName.Text.Trim() + "'";
					text = text + ", @_Category=N'" + this.cbRscCategory.SelectedItem.ToString().Trim() + "'";
					DataSet dataSet = this._queryMgr.queryCall(text);
					bool flag3 = dataSet != null && dataSet.Tables.Count != 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables[0].Rows.Count > 0;
						if (flag4)
						{
							bool flag5 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
							if (flag5)
							{
								MessageBox.Show(MessageLanguage.getMessage("registe_data"), MessageLanguage.getMessage("messagebox_notification"));
								this.tbRscName.Text = "";
								this.setRscNode();
							}
							else
							{
								MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
							}
						}
						else
						{
							MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00010124 File Offset: 0x0000E324
		private void btnGroupMail_Click(object sender, EventArgs e)
		{
			bool flag = this.cbGroupMail.SelectedIndex == -1;
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("select_cateogry"), MessageLanguage.getMessage("messagebox_notification"));
			}
			else
			{
				bool flag2 = this.cbToPlant.SelectedIndex == -1;
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("select_factory"), MessageLanguage.getMessage("messagebox_notification"));
				}
				else
				{
					bool flag3 = this.cbMailList2.SelectedIndex == -1;
					if (flag3)
					{
						MessageBox.Show(MessageLanguage.getMessage("select_email"), MessageLanguage.getMessage("messagebox_notification"));
					}
					else
					{
						string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMailGroup]";
						text = text + " @_Plant=N'" + this.cbToPlant.SelectedItem.ToString() + "'";
						text = text + ", @_Category=N'" + this.cbGroupMail.SelectedItem.ToString() + "'";
						text = text + ", @_MailList=N'" + this.cbMailList2.SelectedItem.ToString() + "'";
						text += ", @_CommandType=N'ToAppend'";
						DataSet dataSet = this._queryMgr.queryCall(text);
						bool flag4 = dataSet != null && dataSet.Tables.Count != 0;
						if (flag4)
						{
							bool flag5 = dataSet.Tables[0].Rows.Count > 0;
							if (flag5)
							{
								bool flag6 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
								if (flag6)
								{
									this.setToMailNode();
									MessageBox.Show(MessageLanguage.getMessage("registe_data"), MessageLanguage.getMessage("messagebox_notification"));
								}
								else
								{
									MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
								}
							}
							else
							{
								MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
							}
						}
						else
						{
							MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
				}
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0001035C File Offset: 0x0000E55C
		private void btnGroupMainDelet_Click(object sender, EventArgs e)
		{
			bool flag = this.tvToMailNode.SelectedNode != null;
			if (flag)
			{
				bool flag2 = this.tvToMailNode.SelectedNode.Parent == null || this.tvToMailNode.SelectedNode.Parent.Parent == null;
				if (!flag2)
				{
					string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMailGroup]";
					text = text + " @_Plant=N'" + this.tvToMailNode.SelectedNode.Parent.Parent.Text + "'";
					text = text + ", @_Category=N'" + this.tvToMailNode.SelectedNode.Parent.Text + "'";
					text = text + ", @_MailList=N'" + this.tvToMailNode.SelectedNode.Text + "'";
					text += ", @_CommandType=N'ToDelete'";
					DataSet dataSet = this._queryMgr.queryCall(text);
					bool flag3 = dataSet != null && dataSet.Tables.Count != 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables[0].Rows.Count > 0;
						if (flag4)
						{
							bool flag5 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
							if (flag5)
							{
								this.cbMailList2.SelectedIndex = -1;
								this.setToMailNode();
								MessageBox.Show(MessageLanguage.getMessage("delete_data"), MessageLanguage.getMessage("messagebox_notification"));
							}
							else
							{
								MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
							}
						}
						else
						{
							MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00010568 File Offset: 0x0000E768
		private void btnAddModel_Click(object sender, EventArgs e)
		{
			bool flag = this.cbModelPlant.SelectedIndex != -1 && this.cbModelCategory.SelectedIndex != -1 && this.tbModelName.Text.Trim() != string.Empty;
			if (flag)
			{
				string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMachineList]";
				text = text + " @_Plant=N'" + this.cbModelPlant.SelectedItem.ToString().Trim() + "'";
				text = text + " ,@_Model=N'" + this.tbModelName.Text.Trim() + "'";
				text = text + ", @_MachineCategory=N'" + this.cbModelCategory.SelectedItem.ToString().Trim() + "'";
				text += ", @_AppendType=N'Model'";
				DataSet dataSet = this._queryMgr.queryCall(text);
				bool flag2 = dataSet != null && dataSet.Tables.Count != 0;
				if (flag2)
				{
					bool flag3 = dataSet.Tables[0].Rows.Count > 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
						if (flag4)
						{
							this.setModelNode();
							this.tbModelName.Text = "";
							MessageBox.Show(MessageLanguage.getMessage("registe_data"), MessageLanguage.getMessage("messagebox_notification"));
						}
						else
						{
							MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
				}
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00010764 File Offset: 0x0000E964
		private void btnModelDelete_Click(object sender, EventArgs e)
		{
			bool flag = this.tvModel.SelectedNode != null;
			if (flag)
			{
				bool flag2 = this.tvModel.SelectedNode.Parent == null || this.tvModel.SelectedNode.Parent.Parent == null;
				if (!flag2)
				{
					string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMachineList]";
					text = text + " @_Plant=N'" + this.tvModel.SelectedNode.Parent.Parent.Text + "'";
					text = text + ", @_Model=N'" + this.tvModel.SelectedNode.Text + "'";
					text = text + ", @_MachineCategory=N'" + this.tvModel.SelectedNode.Parent.Text + "'";
					text += ", @_AppendType=N'ModelDelete'";
					DataSet dataSet = this._queryMgr.queryCall(text);
					bool flag3 = dataSet != null && dataSet.Tables.Count != 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables[0].Rows.Count > 0;
						if (flag4)
						{
							bool flag5 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
							if (flag5)
							{
								MessageBox.Show(MessageLanguage.getMessage("delete_data"), MessageLanguage.getMessage("messagebox_notification"));
								this.cbModelCategory.Text = "";
								this.setModelNode();
							}
							else
							{
								MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
							}
						}
						else
						{
							MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00010971 File Offset: 0x0000EB71
		private void button1_Click_1(object sender, EventArgs e)
		{
			this.getMachineList();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0001097C File Offset: 0x0000EB7C
		private void btnRegisterMachine_Click(object sender, EventArgs e)
		{
			bool flag = this.cbPlantMachine.SelectedIndex == -1;
			if (!flag)
			{
				bool flag2 = this.cbCategoryMachine.SelectedIndex != -1 && this.cbModelMachine.SelectedIndex != -1;
				if (flag2)
				{
					bool flag3 = this.cbCategoryMachine.SelectedItem.ToString().CompareTo("EOL") == 0 || this.cbCategoryMachine.SelectedItem.ToString().CompareTo("STACK") == 0;
					if (flag3)
					{
						bool flag4 = this.cbRscMachine.SelectedIndex == -1;
						if (flag4)
						{
							MessageBox.Show(MessageLanguage.getMessage("check_data"), MessageLanguage.getMessage("messagebox_notification"));
							return;
						}
					}
					string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMachineList]";
					text = text + " @_Plant=N'" + this.cbPlantMachine.SelectedItem.ToString().Trim() + "'";
					text = text + ", @_MachinName=N'" + this.tbNameMachine.Text.Trim() + "'";
					text = text + ", @_MachineCategory=N'" + this.cbCategoryMachine.SelectedItem.ToString().Trim() + "'";
					text = text + ", @_Model=N'" + this.cbModelMachine.SelectedItem.ToString().Trim() + "'";
					bool flag5 = this.cbCategoryMachine.SelectedItem.ToString().CompareTo("AOI") == 0 || this.cbCategoryMachine.SelectedItem.ToString().CompareTo("EOL") == 0 || this.cbCategoryMachine.SelectedItem.ToString().CompareTo("STACK") == 0;
					if (flag5)
					{
						text = text + ", @_Rsc=N'" + this.cbRscMachine.SelectedItem.ToString().Trim() + "'";
					}
					else
					{
						text += ", @_Rsc=N''";
					}
					text += ", @_AppendType=N'Machine'";
					DataSet dataSet = this._queryMgr.queryCall(text);
					bool flag6 = dataSet != null && dataSet.Tables.Count > 0;
					if (flag6)
					{
						bool flag7 = dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
						if (flag7)
						{
							MessageBox.Show(MessageLanguage.getMessage("registe_data"), MessageLanguage.getMessage("messagebox_notification"));
							this.getMachineList();
						}
						else
						{
							MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
				}
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00010C94 File Offset: 0x0000EE94
		private void cbCategoryMachine_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.cbModelMachine.SelectedIndex = -1;
			this.cbRscMachine.SelectedIndex = -1;
			this.cbModelMachine.Text = "";
			this.cbRscMachine.Text = "";
			this.tbNameMachine.Text = "";
			this.cbModelMachine.Items.Clear();
			this.cbRscMachine.Items.Clear();
			bool flag = ((System.Windows.Forms.ComboBox)sender).Equals(this.cbPlantMachine);
			if (flag)
			{
				this.cbCategoryMachine.SelectedIndex = -1;
			}
			bool flag2 = this.cbCategoryMachine.SelectedIndex == -1;
			if (!flag2)
			{
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintMachineType]";
				DataSet dataSet = this._queryMgr.queryCall(sQuery);
				bool flag3 = dataSet != null && dataSet.Tables.Count > 0;
				if (flag3)
				{
					int i = 0;
					while (i < dataSet.Tables[0].Rows.Count)
					{
						string text = dataSet.Tables[0].Rows[i]["Category"].ToString();
						string b = dataSet.Tables[0].Rows[i]["Plant"].ToString();
						bool flag4 = this.cbPlantMachine.SelectedItem.ToString().Trim() == b;
						if (flag4)
						{
							bool flag5 = text.CompareTo("N/A") != 0 && this.cbCategoryMachine.SelectedItem.ToString().CompareTo(text) == 0;
							if (flag5)
							{
								string text2 = dataSet.Tables[0].Rows[i]["TypeName"].ToString();
								bool flag6 = text2 == "N/A";
								if (!flag6)
								{
									this.cbRscMachine.Items.Add(text2);
								}
							}
						}
						IL_1E4:
						i++;
						continue;
						goto IL_1E4;
					}
				}
				sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintModel]";
				dataSet = this._queryMgr.queryCall(sQuery);
				bool flag7 = dataSet != null && dataSet.Tables.Count > 0;
				if (flag7)
				{
					for (int j = 0; j < dataSet.Tables.Count; j++)
					{
						for (int k = 0; k < dataSet.Tables[j].Rows.Count; k++)
						{
							string item = dataSet.Tables[j].Rows[k]["Model"].ToString();
							string text3 = dataSet.Tables[j].Rows[k]["Category"].ToString();
							string b2 = dataSet.Tables[j].Rows[k]["Plant"].ToString();
							bool flag8 = this.cbPlantMachine.SelectedItem.ToString().Trim() == b2;
							if (flag8)
							{
								bool flag9 = text3.CompareTo("N/A") != 0 && this.cbCategoryMachine.SelectedItem.ToString().CompareTo(text3) == 0;
								if (flag9)
								{
									this.cbModelMachine.Items.Add(item);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00011028 File Offset: 0x0000F228
		private void tcMenu_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool bAutoLoadBlock = this._bAutoLoadBlock;
			if (!bAutoLoadBlock)
			{
				bool flag = this.tcMenu.SelectedTab == this.tpRegister;
				if (flag)
				{
					this.clearAllData();
					this.cbContents.SelectedIndex = -1;
					this.cbContents.SelectedIndex = 0;
				}
				else
				{
					bool flag2 = this.tcMenu.SelectedTab == this.tpMachine;
					if (flag2)
					{
						this.clearAllData();
						this.setPlant();
					}
					else
					{
						bool flag3 = this.tcMenu.SelectedTab == this.tpMail;
						if (flag3)
						{
							this.clearAllData();
							this.cbMailContents.SelectedIndex = -1;
							this.cbMailContents.SelectedIndex = 0;
							this.cbGroupMail.Items.Add("HANDLER");
							this.cbGroupMail.Items.Add("TESTER");
							this.cbCCCategory.Items.Add("HANDLER");
							this.cbCCCategory.Items.Add("TESTER");
							this.setPlant();
						}
						else
						{
							bool flag4 = this.tcMenu.SelectedTab == this.tabpage_team;
							if (flag4)
							{
								this.clearAllData();
								this.getTeam();
							}
							else
							{
								bool flag5 = this.tcMenu.SelectedTab == this.tp_factor;
								if (flag5)
								{
									this.setPlant();
								}
								else
								{
									bool flag6 = this.tcMenu.SelectedTab == this.tpVendor;
									if (flag6)
									{
										this.clearAllData();
										this.setPlant();
									}
									else
									{
										bool flag7 = this.tcMenu.SelectedTab == this.tpConfirmation;
										if (flag7)
										{
											this.cbConfirmFactory.SelectedIndex = -1;
											this.cbConfirmType.SelectedIndex = -1;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00011204 File Offset: 0x0000F404
		private void btnRscDelete_Click(object sender, EventArgs e)
		{
			bool flag = this.tvRscDec.SelectedNode != null;
			if (flag)
			{
				bool flag2 = this.tvRscDec.SelectedNode.Parent == null || this.tvRscDec.SelectedNode.Parent.Parent == null;
				if (!flag2)
				{
					string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMachineType]";
					text = text + " @_Plant='" + this.tvRscDec.SelectedNode.Parent.Parent.Text + "'";
					text = text + ", @_MachineType='" + this.tvRscDec.SelectedNode.Text + "'";
					text = text + ", @_Category='" + this.tvRscDec.SelectedNode.Parent.Text + "'";
					text += ", @_Mode='Delete'";
					DataSet dataSet = this._queryMgr.queryCall(text);
					bool flag3 = dataSet != null && dataSet.Tables.Count != 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables[0].Rows.Count > 0;
						if (flag4)
						{
							bool flag5 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
							if (flag5)
							{
								this.cbRscCategory.Text = "";
								this.setRscNode();
								MessageBox.Show(MessageLanguage.getMessage("delete_data"), MessageLanguage.getMessage("messagebox_notification"));
							}
							else
							{
								MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
							}
						}
						else
						{
							MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00011414 File Offset: 0x0000F614
		private void btnMachineRemove_Click(object sender, EventArgs e)
		{
			bool flag = false;
			bool flag2 = this.cbPlantMachine.SelectedIndex == -1;
			if (!flag2)
			{
				for (int i = 1; i < this.grid_Machine.RowsCount; i++)
				{
					bool flag3 = (bool)this.grid_Machine[i, 5].Value;
					if (flag3)
					{
						flag = true;
						string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMachineList]";
						text = text + " @_Plant=N'" + this.cbPlantMachine.SelectedItem.ToString().Trim() + "'";
						text = string.Concat(new object[]
						{
							text,
							", @_MachinName=N'",
							this.grid_Machine[i, 1],
							"'"
						});
						text = string.Concat(new object[]
						{
							text,
							", @_MachineCategory=N'",
							this.grid_Machine[i, 2],
							"'"
						});
						text = string.Concat(new object[]
						{
							text,
							", @_Rsc=N'",
							this.grid_Machine[i, 3],
							"'"
						});
						text = string.Concat(new object[]
						{
							text,
							", @_Model=N'",
							this.grid_Machine[i, 4],
							"'"
						});
						text += ", @_AppendType=N'MachineDelete'";
						DataSet dataSet = this._queryMgr.queryCall(text);
						bool flag4 = dataSet != null && dataSet.Tables.Count > 0;
						if (!flag4)
						{
							MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
							break;
						}
						bool flag5 = dataSet.Tables[0].Rows.Count > 0;
						if (flag5)
						{
							bool flag6 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
							if (!flag6)
							{
								MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
								break;
							}
							this.grid_Machine[i, 5].Value = false;
						}
					}
				}
				bool flag7 = flag;
				if (flag7)
				{
					MessageBox.Show(MessageLanguage.getMessage("delete_data"), MessageLanguage.getMessage("messagebox_notification"));
					this.getMachineList();
				}
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000116B0 File Offset: 0x0000F8B0
		private void cbRscMachine_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.cbModelMachine.Text = "";
			this.cbModelMachine.SelectedIndex = -1;
			this.tbNameMachine.Text = "";
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000116E2 File Offset: 0x0000F8E2
		private void cbModelMachine_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.tbNameMachine.Text = "";
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000116F8 File Offset: 0x0000F8F8
		private void btnCCAdd_Click(object sender, EventArgs e)
		{
			bool flag = this.cbCCPlant.SelectedIndex == -1;
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("select_factory"), MessageLanguage.getMessage("messagebox_notification"));
			}
			else
			{
				bool flag2 = this.cbCCMailTeam.SelectedIndex == -1;
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("select_team"), MessageLanguage.getMessage("messagebox_notification"));
				}
				else
				{
					bool flag3 = this.cbCCCategory.SelectedIndex == -1;
					if (flag3)
					{
						MessageBox.Show(MessageLanguage.getMessage("select_cateogry"), MessageLanguage.getMessage("messagebox_notification"));
					}
					else
					{
						bool flag4 = this.cbMailList.SelectedIndex == -1;
						if (flag4)
						{
							MessageBox.Show(MessageLanguage.getMessage("select_email"), MessageLanguage.getMessage("messagebox_notification"));
						}
						else
						{
							string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMailGroup]";
							text = text + " @_Plant=N'" + this.cbCCPlant.SelectedItem.ToString() + "'";
							text = text + ", @_Category=N'" + this.cbCCCategory.SelectedItem.ToString() + "'";
							text = text + ", @_MailList=N'" + this.cbMailList.SelectedItem.ToString() + "'";
							text += ", @_CommandType=N'CCAppend'";
							text = text + ", @_CCPartName=N'" + this.cbCCMailTeam.SelectedItem.ToString() + "'";
							DataSet dataSet = this._queryMgr.queryCall(text);
							bool flag5 = dataSet != null && dataSet.Tables.Count != 0;
							if (flag5)
							{
								bool flag6 = dataSet.Tables[0].Rows.Count > 0;
								if (flag6)
								{
									bool flag7 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
									if (flag7)
									{
										this.setCCMailNode();
										MessageBox.Show(MessageLanguage.getMessage("registe_data"), MessageLanguage.getMessage("messagebox_notification"));
									}
									else
									{
										MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
									}
								}
								else
								{
									MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
								}
							}
							else
							{
								MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
							}
						}
					}
				}
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00011984 File Offset: 0x0000FB84
		private void btnCCDel_Click(object sender, EventArgs e)
		{
			bool flag = this.tvCCMail.SelectedNode != null;
			if (flag)
			{
				bool flag2 = this.tvCCMail.SelectedNode.Parent == null || this.tvCCMail.SelectedNode.Parent.Parent == null || this.tvCCMail.SelectedNode.Parent.Parent.Parent == null;
				if (!flag2)
				{
					string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMailGroup]";
					text = text + " @_Plant=N'" + this.tvCCMail.SelectedNode.Parent.Parent.Parent.Text + "'";
					text = text + ", @_Category=N'" + this.tvCCMail.SelectedNode.Parent.Text + "'";
					text = text + ", @_MailList=N'" + this.tvCCMail.SelectedNode.Text + "'";
					text = text + ", @_CCPartName=N'" + this.tvCCMail.SelectedNode.Parent.Parent.Text + "'";
					text += ", @_CommandType=N'CCDelete'";
					DataSet dataSet = this._queryMgr.queryCall(text);
					bool flag3 = dataSet != null && dataSet.Tables.Count != 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables[0].Rows.Count > 0;
						if (flag4)
						{
							bool flag5 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
							if (flag5)
							{
								this.setCCMailNode();
								MessageBox.Show(MessageLanguage.getMessage("delete_data"), MessageLanguage.getMessage("messagebox_notification"));
							}
							else
							{
								MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
							}
						}
						else
						{
							MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
			}
			else
			{
				MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00011BEC File Offset: 0x0000FDEC
		private void cbMailContents_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.pnMailList.Visible = false;
			this.pnToList.Visible = false;
			this.pnCCList.Visible = false;
			switch (this.cbMailContents.SelectedIndex)
			{
			case 0:
				this.pnMailList.Visible = true;
				this.groupBox2.Text = "Mail List";
				this.cbMailPlant.SelectedIndex = 0;
				this.setMailNode();
				break;
			case 1:
				this.pnToList.Visible = true;
				this.groupBox2.Text = "To Mail List";
				this.cbToPlant.SelectedIndex = 0;
				this.cbGroupMail.SelectedIndex = 0;
				this.setMailNode();
				this.setToMailNode();
				break;
			case 2:
				this.pnCCList.Visible = true;
				this.groupBox2.Text = "CC Mail List";
				this.cbMailPlant.SelectedIndex = 0;
				this.cbCCPlant.SelectedIndex = 0;
				this.setMailNode();
				this.setCCMailNode();
				break;
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00011D0C File Offset: 0x0000FF0C
		private void btnAddMail_Click(object sender, EventArgs e)
		{
			bool flag = this.cbMailPlant.SelectedIndex == -1;
			if (!flag)
			{
				string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMail]";
				text = text + " @_plant=N'" + this.cbMailPlant.SelectedItem.ToString().Trim() + "'";
				text = text + ", @_Mail=N'" + this.tb_mail.Text.Trim() + "'";
				text += ", @_command=N'add' ";
				DataSet dataSet = this._queryMgr.queryCall(text);
				bool flag2 = dataSet != null && dataSet.Tables.Count != 0;
				if (flag2)
				{
					bool flag3 = dataSet.Tables[0].Rows.Count > 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
						if (flag4)
						{
							this.tb_mail.Text = string.Empty;
							this.tbMailModify.Text = string.Empty;
							this.setMailNode();
							MessageBox.Show(MessageLanguage.getMessage("registe_data"), MessageLanguage.getMessage("messagebox_notification"));
						}
						else
						{
							MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
				}
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00011EC8 File Offset: 0x000100C8
		private void btnDelMail_Click(object sender, EventArgs e)
		{
			bool flag = this.tv_MailList.SelectedNode == null;
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("select_email"), MessageLanguage.getMessage("messagebox_notification"));
			}
			else
			{
				bool flag2 = this.tv_MailList.SelectedNode.Parent == null;
				if (!flag2)
				{
					string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMail]";
					text = text + " @_Plant=N'" + this.tv_MailList.SelectedNode.Parent.Text + "'";
					text = text + ", @_Mail=N'" + this.tv_MailList.SelectedNode.Text + "'";
					text += ", @_command=N'delete' ";
					DataSet dataSet = this._queryMgr.queryCall(text);
					bool flag3 = dataSet != null && dataSet.Tables.Count != 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables[0].Rows.Count > 0;
						if (flag4)
						{
							bool flag5 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
							if (flag5)
							{
								this.tb_mail.Text = string.Empty;
								this.tbMailModify.Text = string.Empty;
								this.setMailNode();
								MessageBox.Show(MessageLanguage.getMessage("registe_data"), MessageLanguage.getMessage("messagebox_notification"));
							}
							else
							{
								MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
							}
						}
						else
						{
							MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000120BC File Offset: 0x000102BC
		private void cbContents_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool bAutoLoadBlock = this._bAutoLoadBlock;
			if (!bAutoLoadBlock)
			{
				this.gbRscDec.Visible = false;
				this.gbModel.Visible = false;
				int selectedIndex = this.cbContents.SelectedIndex;
				if (selectedIndex != 0)
				{
					if (selectedIndex == 1)
					{
						this.setRscNode();
						this.gbRscDec.Visible = true;
					}
				}
				else
				{
					this.setPlant();
					this.gbModel.Visible = true;
				}
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00012134 File Offset: 0x00010334
		private void btn_addTeam_Click(object sender, EventArgs e)
		{
			bool flag = this.cbTeamPlant.SelectedIndex == -1;
			if (!flag)
			{
				string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintTeam]";
				text = text + " @_Plant=N'" + this.cbTeamPlant.SelectedItem.ToString().Trim() + "' ";
				text += ", @_command=N'add' ";
				text = text + ", @_team=N'" + this.tb_team.Text.Trim() + "'";
				DataSet dataSet = this._queryMgr.queryCall(text);
				bool flag2 = dataSet != null && dataSet.Tables.Count != 0;
				if (flag2)
				{
					bool flag3 = dataSet.Tables[0].Rows.Count > 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
						if (flag4)
						{
							this.tb_team.Text = string.Empty;
							this.getTeam();
							MessageBox.Show(MessageLanguage.getMessage("registe_data"), MessageLanguage.getMessage("messagebox_notification"));
						}
						else
						{
							MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
				}
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000122E0 File Offset: 0x000104E0
		private void btn_delTeam_Click(object sender, EventArgs e)
		{
			bool flag = this.tv_TeamList.SelectedNode.Parent == null || this.tv_TeamList.SelectedNode.Parent.Parent != null;
			if (!flag)
			{
				string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintTeam]";
				text = text + " @_Plant=N'" + this.tv_TeamList.SelectedNode.Parent.Text + "'";
				text += ", @_command=N'delete' ";
				text = text + ", @_team=N'" + this.tv_TeamList.SelectedNode.Text + "'";
				DataSet dataSet = this._queryMgr.queryCall(text);
				bool flag2 = dataSet != null && dataSet.Tables.Count != 0;
				if (flag2)
				{
					bool flag3 = dataSet.Tables[0].Rows.Count > 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
						if (flag4)
						{
							this.tb_team.Text = string.Empty;
							this.getTeam();
							MessageBox.Show(MessageLanguage.getMessage("delete_data"), MessageLanguage.getMessage("messagebox_notification"));
						}
						else
						{
							MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
				}
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000124A8 File Offset: 0x000106A8
		private void btn_TeamAddMail_Click(object sender, EventArgs e)
		{
			bool flag = this.cbTeamlist.SelectedIndex == -1;
			if (flag)
			{
				MessageBox.Show(MessageLanguage.getMessage("select_team"), MessageLanguage.getMessage("messagebox_notification"));
			}
			else
			{
				bool flag2 = this.cbMailList3.SelectedIndex == -1;
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("select_email"), MessageLanguage.getMessage("messagebox_notification"));
				}
				else
				{
					string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintTeam]";
					text += " @_command=N'update' ";
					text = text + ", @_team=N'" + this.cbTeamlist.SelectedItem.ToString() + "'";
					text = text + ", @_mail=N'" + this.cbMailList3.SelectedItem.ToString() + "'";
					DataSet dataSet = this._queryMgr.queryCall(text);
					bool flag3 = dataSet != null && dataSet.Tables.Count != 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables[0].Rows.Count > 0;
						if (flag4)
						{
							bool flag5 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
							if (flag5)
							{
								this.tb_team.Text = string.Empty;
								this.getTeam();
								MessageBox.Show(MessageLanguage.getMessage("registe_data"), MessageLanguage.getMessage("messagebox_notification"));
							}
							else
							{
								MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
							}
						}
						else
						{
							MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0001269C File Offset: 0x0001089C
		private void btn_TeamDelMail_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			bool @checked = this.cb_MailDelete.Checked;
			if (@checked)
			{
				bool flag = this.tv_TeamList.SelectedNode.Parent == null;
				if (flag)
				{
					MessageBox.Show(MessageLanguage.getMessage("select_email"), MessageLanguage.getMessage("messagebox_notification"));
					return;
				}
				bool flag2 = this.tv_TeamList.SelectedNode == null || this.tv_TeamList.SelectedNode.Parent == null || this.tv_TeamList.SelectedNode.Parent.Parent == null;
				if (flag2)
				{
					MessageBox.Show(MessageLanguage.getMessage("select_email"), MessageLanguage.getMessage("messagebox_notification"));
					return;
				}
				text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintTeam]";
				text = text + " @_Plant=N'" + this.tv_TeamList.SelectedNode.Parent.Parent.Text + "' ";
				text += ", @_command=N'deleteMail' ";
				text = text + ", @_team=N'" + this.tv_TeamList.SelectedNode.Parent.Text + "'";
				text += ", @_mail=N''";
			}
			else
			{
				bool flag3 = MessageBox.Show(MessageLanguage.getMessage("delete_team"), MessageLanguage.getMessage("messagebox_warning"), MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK;
				if (!flag3)
				{
					return;
				}
				bool flag4 = this.tv_TeamList.SelectedNode == null || this.tv_TeamList.SelectedNode.Parent == null || this.tv_TeamList.SelectedNode.Parent.Parent != null;
				if (flag4)
				{
					MessageBox.Show(MessageLanguage.getMessage("select_team"), MessageLanguage.getMessage("messagebox_notification"));
					return;
				}
				text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintTeam]";
				text = text + " @_Plant=N'" + this.tv_TeamList.SelectedNode.Parent.Text + "' ";
				text += ", @_command=N'delete' ";
				text = text + ", @_team=N'" + this.tv_TeamList.SelectedNode.Text + "'";
			}
			DataSet dataSet = this._queryMgr.queryCall(text);
			bool flag5 = dataSet != null && dataSet.Tables.Count != 0;
			if (flag5)
			{
				bool flag6 = dataSet.Tables[0].Rows.Count > 0;
				if (flag6)
				{
					bool flag7 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
					if (flag7)
					{
						this.tb_team.Text = string.Empty;
						this.getTeam();
						MessageBox.Show(MessageLanguage.getMessage("delete_data"), MessageLanguage.getMessage("messagebox_notification"));
					}
					else
					{
						MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
				}
			}
			else
			{
				MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000129EC File Offset: 0x00010BEC
		private void btnFactorAdd_Click(object sender, EventArgs e)
		{
			bool flag = this.tbFactor.Text.Trim() != string.Empty;
			if (flag)
			{
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintFactor] @_command=N'update' , @_plant=N'",
					this.cbPlant.SelectedItem.ToString().Trim(),
					"', @_category=N'",
					this.cbFactorCategory.SelectedItem.ToString().Trim(),
					"', @_case=N'",
					this.cbFactorCase.SelectedItem.ToString().Trim(),
					"', @_factor=N'",
					this.tbFactor.Text.Trim(),
					"', @_system='",
					this.cbFactorSystem.SelectedIndex.ToString(),
					"'"
				});
				DataSet dataSet = this._queryMgr.queryCall(sQuery);
				bool flag2 = dataSet != null && dataSet.Tables.Count != 0;
				if (flag2)
				{
					bool flag3 = dataSet.Tables[0].Rows.Count > 0;
					if (flag3)
					{
						bool flag4 = this.cbFactorSystem.SelectedItem != null && dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
						if (flag4)
						{
							this.tbFactor.Text = string.Empty;
							this.setFactorNode(this.cbFactorSystem.SelectedIndex);
							MessageBox.Show(MessageLanguage.getMessage("registe_data"), MessageLanguage.getMessage("messagebox_notification"));
						}
						else
						{
							MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
					else
					{
						MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
					}
				}
				else
				{
					MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
				}
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00012C18 File Offset: 0x00010E18
		private void btnFactorDel_Click(object sender, EventArgs e)
		{
			bool flag = this.tvFactorList.SelectedNode == null || this.cbFactorSystem.SelectedItem == null;
			if (!flag)
			{
				bool flag2 = this.tvFactorList.SelectedNode.Parent == null || this.tvFactorList.SelectedNode.Parent.Parent == null || this.tvFactorList.SelectedNode.Parent.Parent.Parent == null;
				if (!flag2)
				{
					string sQuery = string.Concat(new object[]
					{
						"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintFactor] @_command=N'Delete' , @_plant='",
						this.tvFactorList.SelectedNode.Parent.Parent.Parent.Text,
						"', @_category=N'",
						this.tvFactorList.SelectedNode.Parent.Parent.Text,
						"', @_case='",
						this.tvFactorList.SelectedNode.Parent.Text,
						"', @_factor='",
						this.tvFactorList.SelectedNode.Text,
						"', @_system='",
						this.cbFactorSystem.SelectedIndex,
						"'"
					});
					DataSet dataSet = this._queryMgr.queryCall(sQuery);
					bool flag3 = this.cbFactorSystem.SelectedItem == null;
					if (!flag3)
					{
						bool flag4 = dataSet != null && dataSet.Tables.Count != 0;
						if (flag4)
						{
							bool flag5 = dataSet.Tables[0].Rows.Count > 0;
							if (flag5)
							{
								bool flag6 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
								if (flag6)
								{
									this.tbFactor.Text = string.Empty;
									this.setFactorNode(this.cbFactorSystem.SelectedIndex);
									MessageBox.Show(MessageLanguage.getMessage("delete_data"), MessageLanguage.getMessage("messagebox_notification"));
								}
								else
								{
									MessageBox.Show(MessageLanguage.getMessage("delete_fail"), MessageLanguage.getMessage("messagebox_notification"));
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00012E58 File Offset: 0x00011058
		private void cbToPlant_SelectedIndexChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)sender;
			this.cbMailList.Items.Clear();
			this.cbMailList2.Items.Clear();
			this.cbMailList3.Items.Clear();
			bool flag = comboBox.Equals(this.cbCCPlant) || comboBox.Equals(this.cbTeamPlant2);
			if (flag)
			{
				bool flag2 = comboBox.SelectedIndex == -1;
				if (flag2)
				{
					return;
				}
				string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintTeamInfo]";
				text = text + " @_Plant=N'" + comboBox.SelectedItem.ToString().Trim() + "'";
				DataSet dataSet = this._queryMgr.queryCall(text);
				this.cbCCMailTeam.Items.Clear();
				this.cbTeamlist.Items.Clear();
				bool flag3 = dataSet != null && dataSet.Tables.Count > 0;
				if (flag3)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string text2 = dataSet.Tables[0].Rows[i]["Name"].ToString();
						string b = dataSet.Tables[0].Rows[i]["plant"].ToString();
						bool flag4 = comboBox.Equals(this.cbCCPlant) && this.cbCCMailTeam.Items.IndexOf(text2) == -1;
						if (flag4)
						{
							this.cbCCMailTeam.Items.Add(text2);
						}
						else
						{
							bool flag5 = comboBox.Equals(this.cbTeamPlant2) && comboBox.SelectedItem.ToString().Trim() == b;
							if (flag5)
							{
								this.cbTeamlist.Items.Add(text2);
							}
						}
					}
				}
			}
			string a = comboBox.SelectedItem.ToString();
			if (!(a == "K3") && !(a == "K3_E"))
			{
				if (!(a == "K5") && !(a == "K5_M"))
				{
					if (a == "ATV")
					{
						foreach (string item in this._atvMail)
						{
							this.cbMailList.Items.Add(item);
							this.cbMailList2.Items.Add(item);
							this.cbMailList3.Items.Add(item);
						}
					}
				}
				else
				{
					foreach (string item2 in this._k5Mail)
					{
						this.cbMailList.Items.Add(item2);
						this.cbMailList2.Items.Add(item2);
						this.cbMailList3.Items.Add(item2);
					}
				}
			}
			else
			{
				foreach (string item3 in this._k3Mail)
				{
					this.cbMailList.Items.Add(item3);
					this.cbMailList2.Items.Add(item3);
					this.cbMailList3.Items.Add(item3);
				}
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00013238 File Offset: 0x00011438
		private void tv_MailList_AfterSelect(object sender, TreeViewEventArgs e)
		{
			bool flag = e.Node.Parent != null;
			if (flag)
			{
				this.tbMailModify.Text = e.Node.Text;
			}
			else
			{
				this.tbMailModify.Text = string.Empty;
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00013284 File Offset: 0x00011484
		private void btnModify_Click(object sender, EventArgs e)
		{
			bool flag = this.tv_MailList.SelectedNode.Parent == null;
			if (!flag)
			{
				string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintMail]";
				text = text + " @_plant=N'" + this.tv_MailList.SelectedNode.Parent.Text + "'";
				text = text + ", @_Mail=N'" + this.tv_MailList.SelectedNode.Text.Trim() + "'";
				text = text + ", @_modfiyMail=N'" + this.tbMailModify.Text.Trim() + "'";
				text += ", @_command=N'update' ";
				DataSet dataSet = this._queryMgr.queryCall(text);
				bool flag2 = dataSet != null && dataSet.Tables.Count != 0;
				if (flag2)
				{
					bool flag3 = dataSet.Tables[0].Rows.Count > 0;
					if (flag3)
					{
						bool flag4 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
						if (flag4)
						{
							this.tbMailModify.Text = string.Empty;
							this.setMailNode();
							MessageBox.Show(MessageLanguage.getMessage("registe_data"), MessageLanguage.getMessage("messagebox_notification"));
						}
						else
						{
							MessageBox.Show(MessageLanguage.getMessage("registe_fail"), MessageLanguage.getMessage("messagebox_notification"));
						}
					}
				}
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00013404 File Offset: 0x00011604
		private void Plant_SelectedValueChanged(object sender, EventArgs e)
		{
			bool flag = !this._bInitPlant;
			if (flag)
			{
				System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)sender;
				bool flag2 = comboBox.Equals(this.cbPlantMachine);
				if (flag2)
				{
					cFunction.getCategoryList(this._factorySetting, this.cbPlantMachine.SelectedItem.ToString(), this.cbCategoryMachine, false, false);
					this.cbCategoryMachine.SelectedIndex = -1;
				}
				else
				{
					bool flag3 = comboBox.Equals(this.cbModelPlant);
					if (flag3)
					{
						cFunction.getCategoryList(this._factorySetting, this.cbModelPlant.SelectedItem.ToString(), this.cbModelCategory, false, false);
						this.cbModelCategory.SelectedIndex = -1;
						this.setModelNode();
					}
					else
					{
						bool flag4 = comboBox.Equals(this.cbRscPlant);
						if (flag4)
						{
							cFunction.getCategoryList(this._factorySetting, this.cbRscPlant.SelectedItem.ToString(), this.cbRscCategory, false, false);
							this.cbRscCategory.SelectedIndex = -1;
							this.setRscNode();
						}
						else
						{
							bool flag5 = comboBox.Equals(this.cbToPlant);
							if (flag5)
							{
								cFunction.getCategoryList(this._factorySetting, this.cbToPlant.SelectedItem.ToString(), this.cbGroupMail, false, false);
								this.cbGroupMail.SelectedIndex = -1;
								this.setToMailNode();
							}
							else
							{
								bool flag6 = comboBox.Equals(this.cbCCPlant);
								if (flag6)
								{
									cFunction.getCategoryList(this._factorySetting, this.cbCCPlant.SelectedItem.ToString(), this.cbCCCategory, false, false);
									this.cbCCCategory.SelectedIndex = -1;
									this.setCCMailNode();
								}
								else
								{
									bool flag7 = comboBox.Equals(this.cbPlant);
									if (flag7)
									{
										bool flag8 = this.cbFactorSystem.SelectedItem == null;
										if (!flag8)
										{
											cFunction.getCategoryList(this._factorySetting, this.cbPlant.SelectedItem.ToString(), this.cbFactorCategory, false, false);
											this.cbFactorCategory.SelectedIndex = -1;
											this.setFactorNode(this.cbFactorSystem.SelectedIndex);
										}
									}
									else
									{
										bool flag9 = comboBox.Equals(this.cbMailPlant);
										if (flag9)
										{
											this.setMailNode();
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00013640 File Offset: 0x00011840
		private void setModelNode()
		{
			this.tvModel.Nodes.Clear();
			this.tvModel.Nodes.Add(this.cbModelPlant.SelectedItem.ToString(), this.cbModelPlant.SelectedItem.ToString());
			for (int i = 0; i < this.tvModel.Nodes.Count; i++)
			{
				for (int j = 0; j < this.cbModelCategory.Items.Count; j++)
				{
					this.tvModel.Nodes[i].Nodes.Add(this.cbModelCategory.Items[j].ToString());
				}
			}
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintModel]";
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			for (int k = 0; k < dataSet.Tables[0].Rows.Count; k++)
			{
				string text = dataSet.Tables[0].Rows[k]["Model"].ToString();
				string text2 = dataSet.Tables[0].Rows[k]["Category"].ToString();
				string key = dataSet.Tables[0].Rows[k]["plant"].ToString();
				bool flag = this.tvModel.Nodes.ContainsKey(key);
				if (flag)
				{
					for (int l = 0; l < this.tvModel.Nodes[key].Nodes.Count; l++)
					{
						bool flag2 = text2.CompareTo(this.tvModel.Nodes[key].Nodes[l].Text) == 0;
						if (flag2)
						{
							this.tvModel.Nodes[key].Nodes[l].Nodes.Add(text);
						}
					}
				}
			}
			this.tvModel.ExpandAll();
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00013888 File Offset: 0x00011A88
		private void setRscNode()
		{
			this.tvRscDec.Nodes.Clear();
			this.tvRscDec.Nodes.Add(this.cbRscPlant.SelectedItem.ToString(), this.cbRscPlant.SelectedItem.ToString());
			for (int i = 0; i < this.tvRscDec.Nodes.Count; i++)
			{
				for (int j = 0; j < this.cbModelCategory.Items.Count; j++)
				{
					this.tvRscDec.Nodes[i].Nodes.Add(this.cbRscCategory.Items[j].ToString());
				}
			}
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintMachineType]";
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				for (int k = 0; k < dataSet.Tables[0].Rows.Count; k++)
				{
					string strB = dataSet.Tables[0].Rows[k]["Category"].ToString();
					string text = dataSet.Tables[0].Rows[k]["TypeName"].ToString();
					string key = dataSet.Tables[0].Rows[k]["plant"].ToString();
					bool flag2 = text.CompareTo("N/A") == 0;
					if (!flag2)
					{
						bool flag3 = this.tvRscDec.Nodes.ContainsKey(key);
						if (flag3)
						{
							for (int l = 0; l < this.tvRscDec.Nodes[key].Nodes.Count; l++)
							{
								bool flag4 = this.tvRscDec.Nodes[key].Nodes[l].Text.CompareTo(strB) == 0;
								if (flag4)
								{
									this.tvRscDec.Nodes[key].Nodes[l].Nodes.Add(text);
								}
							}
						}
					}
				}
				this.tvRscDec.ExpandAll();
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00013B0C File Offset: 0x00011D0C
		private void setMailNode()
		{
			bool flag = this.cbMailPlant.SelectedItem == null;
			if (!flag)
			{
				this.tv_MailList.Nodes.Clear();
				this.cbMailList.Items.Clear();
				this.cbMailList2.Items.Clear();
				this.cbMailList3.Items.Clear();
				this._k3Mail.Clear();
				this._k4Mail.Clear();
				this._k5Mail.Clear();
				this._atvMail.Clear();
				this.tv_MailList.Nodes.Add(this.cbMailPlant.SelectedItem.ToString(), this.cbMailPlant.SelectedItem.ToString());
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintMail]";
				DataSet dataSet = this._queryMgr.queryCall(sQuery);
				bool flag2 = dataSet != null && dataSet.Tables.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string text = dataSet.Tables[0].Rows[i]["mail"].ToString();
						string text2 = dataSet.Tables[0].Rows[i]["plant"].ToString();
						string a = text2;
						if (!(a == "K3") && !(a == "K3_E"))
						{
							if (!(a == "K5") && !(a == "K5_M"))
							{
								if (a == "ATV")
								{
									this._atvMail.Add(text);
								}
							}
							else
							{
								this._k5Mail.Add(text);
							}
						}
						else
						{
							this._k3Mail.Add(text);
						}
						bool flag3 = text2 != this.cbMailPlant.SelectedItem.ToString();
						if (!flag3)
						{
							this.tv_MailList.Nodes[text2].Nodes.Add(text);
						}
					}
					this.tv_MailList.ExpandAll();
				}
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00013D54 File Offset: 0x00011F54
		private void setToMailNode()
		{
			this.tvToMailNode.Nodes.Clear();
			this.tvToMailNode.Nodes.Add(this.cbToPlant.SelectedItem.ToString(), this.cbToPlant.SelectedItem.ToString());
			for (int i = 0; i < this.tvToMailNode.Nodes.Count; i++)
			{
				for (int j = 0; j < this.cbGroupMail.Items.Count; j++)
				{
					this.tvToMailNode.Nodes[i].Nodes.Add(this.cbGroupMail.Items[j].ToString(), this.cbGroupMail.Items[j].ToString());
				}
			}
			string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintEmailGroup]";
			text += " @_Plant=N'All'";
			text += ", @_command=N'ToMail'";
			DataSet dataSet = this._queryMgr.queryCall(text);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				for (int k = 0; k < dataSet.Tables[0].Rows.Count; k++)
				{
					string key = dataSet.Tables[0].Rows[k]["Category"].ToString();
					string key2 = dataSet.Tables[0].Rows[k]["Plant"].ToString();
					bool flag2 = this.tvToMailNode.Nodes.ContainsKey(key2) && this.tvToMailNode.Nodes[key2].Nodes.ContainsKey(key);
					if (flag2)
					{
						this.tvToMailNode.Nodes[key2].Nodes[key].Nodes.Add(dataSet.Tables[0].Rows[k]["MailList"].ToString());
					}
				}
				this.tvToMailNode.ExpandAll();
			}
			string a = this.cbToPlant.SelectedItem.ToString();
			if (!(a == "K3") && !(a == "K3_E"))
			{
				if (a == "K5" || a == "K5_M")
				{
					foreach (string item in this._k5Mail)
					{
						this.cbMailList.Items.Add(item);
						this.cbMailList2.Items.Add(item);
						this.cbMailList3.Items.Add(item);
					}
				}
			}
			else
			{
				foreach (string item2 in this._k3Mail)
				{
					this.cbMailList.Items.Add(item2);
					this.cbMailList2.Items.Add(item2);
					this.cbMailList3.Items.Add(item2);
				}
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x000140EC File Offset: 0x000122EC
		private void setCCMailNode()
		{
			this.tvCCMail.Nodes.Clear();
			this.tvCCMail.Nodes.Add(this.cbCCPlant.SelectedItem.ToString(), this.cbCCPlant.SelectedItem.ToString());
			string text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintTeamInfo]";
			text += " @_Plant=N'All'";
			DataSet dataSet = this._queryMgr.queryCall(text);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string text2 = dataSet.Tables[0].Rows[i]["Name"].ToString();
					string text3 = dataSet.Tables[0].Rows[i]["plant"].ToString();
					bool flag2 = text3 != this.cbCCPlant.SelectedItem.ToString();
					if (!flag2)
					{
						this.tvCCMail.Nodes[text3].Nodes.Add(text2, text2);
						for (int j = 0; j < this.cbCCCategory.Items.Count; j++)
						{
							this.tvCCMail.Nodes[text3].Nodes[text2].Nodes.Add(this.cbCCCategory.Items[j].ToString(), this.cbCCCategory.Items[j].ToString());
						}
					}
				}
			}
			dataSet.Clear();
			text = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintEmailGroup]";
			text += " @_Plant=N'All'";
			text += ", @_command=N'CCMail'";
			dataSet = this._queryMgr.queryCall(text);
			bool flag3 = dataSet != null && dataSet.Tables.Count > 0;
			if (flag3)
			{
				for (int k = 0; k < dataSet.Tables[0].Rows.Count; k++)
				{
					string key = dataSet.Tables[0].Rows[k]["Category"].ToString();
					string key2 = dataSet.Tables[0].Rows[k]["Name"].ToString();
					string key3 = dataSet.Tables[0].Rows[k]["plant"].ToString();
					string text4 = dataSet.Tables[0].Rows[k]["MailList"].ToString();
					bool flag4 = this.tvCCMail.Nodes.ContainsKey(key3) && this.tvCCMail.Nodes[key3].Nodes.ContainsKey(key2) && this.tvCCMail.Nodes[key3].Nodes[key2].Nodes.ContainsKey(key);
					if (flag4)
					{
						this.tvCCMail.Nodes[key3].Nodes[key2].Nodes[key].Nodes.Add(text4);
					}
				}
			}
			this.tvCCMail.ExpandAll();
			this.cbToPlant_SelectedIndexChanged(this.cbCCPlant, null);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0001449C File Offset: 0x0001269C
		private void setFactorNode(int system)
		{
			this.tbFactor.Text = string.Empty;
			this.tvFactorList.Nodes.Clear();
			this.tvFactorList.Nodes.Add(this.cbPlant.SelectedItem.ToString(), this.cbPlant.SelectedItem.ToString());
			bool flag = system == 0;
			if (flag)
			{
				for (int i = 0; i < this.cbFactorCategory.Items.Count; i++)
				{
					for (int j = 0; j < this.tvFactorList.GetNodeCount(false); j++)
					{
						this.tvFactorList.Nodes[j].Nodes.Add(this.cbFactorCategory.Items[i].ToString(), this.cbFactorCategory.Items[i].ToString());
						for (int k = 0; k < this.cbFactorCase.Items.Count; k++)
						{
							this.tvFactorList.Nodes[j].Nodes[this.tvFactorList.Nodes[j].Nodes.Count - 1].Nodes.Add(this.cbFactorCase.Items[k].ToString(), this.cbFactorCase.Items[k].ToString());
						}
					}
				}
			}
			else
			{
				this.tvFactorList.Nodes[0].Nodes.Add("REJECT", "REJECT");
				this.tvFactorList.Nodes[0].Nodes[this.tvFactorList.Nodes[0].Nodes.Count - 1].Nodes.Add("HARDWARE", "HARDWARE");
				this.tvFactorList.Nodes[0].Nodes[this.tvFactorList.Nodes[0].Nodes.Count - 1].Nodes.Add("CONTACT", "CONTACT");
				this.tvFactorList.Nodes[0].Nodes[this.tvFactorList.Nodes[0].Nodes.Count - 1].Nodes.Add("FUNCTION", "FUNCTION");
				this.tvFactorList.Nodes[0].Nodes[this.tvFactorList.Nodes[0].Nodes.Count - 1].Nodes.Add("OTHER", "OTHER");
				this.tvFactorList.Nodes[0].Nodes.Add("DISABLE", "DISABLE");
				this.tvFactorList.Nodes[0].Nodes[this.tvFactorList.Nodes[0].Nodes.Count - 1].Nodes.Add("DISABLE", "DISABLE");
			}
			int selectedIndex = this.cbRscCategory.SelectedIndex;
			int selectedIndex2 = this.cbModelCategory.SelectedIndex;
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintFactorList] @_system=N'" + system.ToString() + "', @_plant=N'All', @_category=N'All'";
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag2 = dataSet != null && dataSet.Tables.Count > 0;
			if (flag2)
			{
				for (int l = 0; l < dataSet.Tables.Count; l++)
				{
					for (int m = 0; m < dataSet.Tables[l].Rows.Count; m++)
					{
						string a = string.Empty;
						bool flag3 = dataSet.Tables[l].Columns.Contains("plant");
						if (flag3)
						{
							a = dataSet.Tables[l].Rows[m]["plant"].ToString().ToUpper();
						}
						else
						{
							a = dataSet.Tables[l].Rows[m]["factory"].ToString().ToUpper();
						}
						string key = dataSet.Tables[l].Rows[m]["category"].ToString().ToUpper();
						string text = dataSet.Tables[l].Rows[m]["factor"].ToString().ToUpper();
						string key2 = dataSet.Tables[l].Rows[m]["case"].ToString().ToUpper();
						bool flag4 = a != this.cbPlant.SelectedItem.ToString();
						if (!flag4)
						{
							bool flag5 = !this.tvFactorList.Nodes[0].Nodes.ContainsKey(key);
							if (!flag5)
							{
								bool flag6 = this.tvFactorList.Nodes[0].Nodes[key].Nodes[key2] == null;
								if (!flag6)
								{
									this.tvFactorList.Nodes[0].Nodes[key].Nodes[key2].Nodes.Add(text);
								}
							}
						}
					}
				}
			}
			this.tvFactorList.ExpandAll();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00014AAC File Offset: 0x00012CAC
		private void setVendorNode()
		{
			this.tvVendor.Nodes.Clear();
			bool flag = string.IsNullOrEmpty(this.cbVendorFactory.SelectedItem.ToString());
			if (!flag)
			{
				this.tvVendor.Nodes.Add(this.cbVendorFactory.SelectedItem.ToString(), this.cbVendorFactory.SelectedItem.ToString());
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintVendor] @_factory=N'" + this.cbVendorFactory.SelectedItem.ToString() + "'";
				DataSet dataSet = this._queryMgr.queryCall(sQuery);
				bool flag2 = dataSet.Tables.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string text = dataSet.Tables[0].Rows[i]["vendor"].ToString();
						bool flag3 = this.tvVendor.Nodes.ContainsKey(this.cbVendorFactory.SelectedItem.ToString());
						if (flag3)
						{
							this.tvVendor.Nodes[this.cbVendorFactory.SelectedItem.ToString()].Nodes.Add(text);
						}
					}
					this.tvVendor.ExpandAll();
				}
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00014C1C File Offset: 0x00012E1C
		private void btnAddVendor_Click(object sender, EventArgs e)
		{
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintVendor] @_Command=N'add', @_Vendor=N'",
				this.tbVendor.Text.Trim(),
				"', @_factory=N'",
				this.cbVendorFactory.SelectedItem.ToString(),
				"'"
			});
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet.Tables.Count != 0;
			if (flag)
			{
				string text = dataSet.Tables[0].Rows[0][0].ToString();
				bool flag2 = text.Trim() != "OK";
				if (flag2)
				{
					MessageBox.Show(text, MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					MessageBox.Show(text, MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.tbVendor.Text = string.Empty;
					this.setVendorNode();
				}
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00014D18 File Offset: 0x00012F18
		private void btnDelVendor_Click(object sender, EventArgs e)
		{
			bool flag = this.tvVendor.SelectedNode == null;
			if (!flag)
			{
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintVendor] @_Command=N'delete', @_Vendor=N'",
					this.tvVendor.SelectedNode.Text,
					"', @_factory=N'",
					this.cbVendorFactory.SelectedItem.ToString(),
					"'"
				});
				DataSet dataSet = this._queryMgr.queryCall(sQuery);
				bool flag2 = dataSet != null && dataSet.Tables.Count != 0;
				if (flag2)
				{
					string text = dataSet.Tables[0].Rows[0][0].ToString();
					bool flag3 = text.Trim() != "OK";
					if (flag3)
					{
						MessageBox.Show(text, MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						MessageBox.Show(text, MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.tbVendor.Text = string.Empty;
						this.setVendorNode();
					}
				}
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00014E34 File Offset: 0x00013034
		private void btnImport_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = this.openFileDialog.ShowDialog() == DialogResult.OK;
				if (flag)
				{
					string text = string.Empty;
					FileStream fileStream = File.Open(this.openFileDialog.FileName, FileMode.Open);
					StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
					int num = 0;
					string text2 = string.Empty;
					string empty = string.Empty;
					string text3 = string.Empty;
					string text4 = string.Empty;
					bool flag2 = true;
					while (!streamReader.EndOfStream)
					{
						text = streamReader.ReadLine();
						bool flag3 = !string.IsNullOrEmpty(text.Trim());
						if (flag3)
						{
							string[] array = text.Split(new char[]
							{
								','
							});
							bool flag4 = array.Length == 3;
							if (!flag4)
							{
								flag2 = false;
								MessageBox.Show(text + MessageLanguage.getMessage("wrong_format"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
								break;
							}
							bool flag5 = string.IsNullOrEmpty(array[0]) || string.IsNullOrEmpty(array[1]) || string.IsNullOrEmpty(array[2]);
							if (flag5)
							{
								flag2 = false;
								MessageBox.Show(text + " " + MessageLanguage.getMessage("wrong_format"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
								break;
							}
							num++;
							bool flag6 = num == 1;
							if (flag6)
							{
								text2 = array[0];
								text3 = array[1];
								text4 = array[2];
							}
							else
							{
								text2 = text2 + "," + array[0];
								text3 = text3 + "," + array[1];
								text4 = text4 + "," + array[2];
							}
							bool flag7 = num == 100;
							if (flag7)
							{
								num = 0;
								string sQuery = string.Concat(new string[]
								{
									"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintAsset] @_Command=N'Append', @_Factory=N'",
									text2,
									"', @_Equipment=N'",
									text3,
									"', @_Asset=N'",
									text4,
									"'"
								});
								DataSet dataSet = this._queryMgr.queryCall(sQuery);
								bool flag8 = dataSet != null && dataSet.Tables.Count != 0;
								if (flag8)
								{
									string text5 = dataSet.Tables[0].Rows[0][0].ToString();
									bool flag9 = text5.Trim() != "OK";
									if (flag9)
									{
										MessageBox.Show(text5, MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
										break;
									}
								}
							}
						}
					}
					bool flag10 = flag2 && num != 0;
					if (flag10)
					{
						string sQuery2 = string.Concat(new string[]
						{
							"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintAsset] @_Command=N'Append', @_Factory=N'",
							text2,
							"', @_Equipment=N'",
							text3,
							"', @_Asset=N'",
							text4,
							"'"
						});
						DataSet dataSet2 = this._queryMgr.queryCall(sQuery2);
						bool flag11 = dataSet2 != null && dataSet2.Tables.Count != 0;
						if (flag11)
						{
							string text6 = dataSet2.Tables[0].Rows[0][0].ToString();
							bool flag12 = text6.Trim() != "OK";
							if (flag12)
							{
								MessageBox.Show(text6, MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
							else
							{
								MessageBox.Show(MessageLanguage.getMessage("import_done"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
						}
						this.btnAssetSearch_Click(null, null);
					}
					else
					{
						bool flag13 = flag2;
						if (flag13)
						{
							MessageBox.Show(MessageLanguage.getMessage("import_done"), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							this.btnAssetSearch_Click(null, null);
						}
					}
					fileStream.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(), MessageLanguage.getMessage("messagebox_notification"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00015230 File Offset: 0x00013430
		private void btnAssetSearch_Click(object sender, EventArgs e)
		{
			bool flag = this.cbAssetFactory.SelectedIndex == -1;
			if (!flag)
			{
				this.grid_Asset.Rows.Clear();
				this.grid_Asset.Selection.EnableMultiSelection = false;
				this.grid_Asset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				this.grid_Asset.CustomSort = true;
				this.SetGridHeader();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintAsset] @_Factory=N'",
					this.cbAssetFactory.SelectedItem.ToString().Trim(),
					"', @_Equipment=N'",
					this.tbAssetEquipment.Text.Trim(),
					"', @_Asset=N'",
					this.tbAsset.Text.Trim(),
					"'"
				});
				DataSet dataSet = this._queryMgr.queryCall(sQuery);
				bool flag2 = dataSet != null && dataSet.Tables.Count > 0;
				if (flag2)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						this.grid_Asset.Rows.Insert(i + 1);
						this.grid_Asset[i + 1, 0] = new SourceGrid.Cells.Cell(i + 1);
						this.grid_Asset[i + 1, 1] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["equipment"].ToString());
						this.grid_Asset[i + 1, 2] = new SourceGrid.Cells.Cell(dataSet.Tables[0].Rows[i]["asset"].ToString());
						this.grid_Asset[i + 1, 3] = new SourceGrid.Cells.CheckBox(null, new bool?(false));
					}
				}
				this.grid_Asset.AutoSizeCells();
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00015438 File Offset: 0x00013638
		private void btnDeleteAsset_Click(object sender, EventArgs e)
		{
			bool flag = false;
			bool flag2 = this.cbAssetFactory.SelectedIndex == -1;
			if (!flag2)
			{
				for (int i = 1; i < this.grid_Asset.RowsCount; i++)
				{
					bool flag3 = (bool)this.grid_Asset[i, 3].Value;
					if (flag3)
					{
						flag = true;
						string sQuery = string.Concat(new object[]
						{
							"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintAsset] @_Command=N'Delete', @_Factory=N'",
							this.cbAssetFactory.SelectedItem.ToString(),
							"', @_Equipment=N'",
							this.grid_Asset[i, 1],
							"', @_Asset=N'",
							this.grid_Asset[i, 2],
							"'"
						});
						DataSet dataSet = this._queryMgr.queryCall(sQuery);
						bool flag4 = dataSet != null && dataSet.Tables.Count > 0;
						if (flag4)
						{
							bool flag5 = dataSet.Tables[0].Rows.Count > 0;
							if (flag5)
							{
								bool flag6 = dataSet.Tables[0].Rows[0][0].ToString().ToUpper() == "OK";
								if (!flag6)
								{
									MessageBox.Show(dataSet.Tables[0].Rows[0][0].ToString(), MessageLanguage.getMessage("messagebox_notification"));
									break;
								}
								this.grid_Asset[i, 3].Value = false;
							}
						}
					}
				}
				bool flag7 = flag;
				if (flag7)
				{
					MessageBox.Show(MessageLanguage.getMessage("delete_data"), MessageLanguage.getMessage("messagebox_notification"));
					this.btnAssetSearch_Click(null, null);
				}
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00015614 File Offset: 0x00013814
		private void getConfirmationList()
		{
			bool flag = this.cbConfirmFactory.SelectedItem == null || this.cbConfirmType.SelectedItem == null;
			if (!flag)
			{
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMaintConfirmList] @_factory=N'",
					this.cbConfirmFactory.SelectedItem.ToString(),
					"', @_type=N'",
					this.cbConfirmType.SelectedItem.ToString(),
					"'"
				});
				DataSet dataSet = this._queryMgr.queryCall(sQuery);
				this._listConfirm.Clear();
				this.cbListBox.Items.Clear();
				bool flag2 = dataSet != null && dataSet.Tables.Count > 0;
				if (flag2)
				{
					bool flag3 = dataSet.Tables[0].Rows.Count > 0;
					if (flag3)
					{
						this.cbListBox.Items.Clear();
						for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
						{
							AdminSetting.ConfirmIndex confirmIndex = new AdminSetting.ConfirmIndex();
							confirmIndex.newcontent = string.Empty;
							confirmIndex.newviewidex = -1;
							confirmIndex.content = dataSet.Tables[0].Rows[i]["content"].ToString();
							confirmIndex.columnindex = Convert.ToInt32(dataSet.Tables[0].Rows[i]["columnindex"].ToString());
							confirmIndex.viewindex = Convert.ToInt32(dataSet.Tables[0].Rows[i]["viewindex"].ToString());
							this.cbListBox.Items.Add(confirmIndex.content, false);
							this._listConfirm.Add(confirmIndex);
						}
					}
				}
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00015820 File Offset: 0x00013A20
		private void btnUp_Click(object sender, EventArgs e)
		{
			for (int i = 1; i < this.cbListBox.Items.Count; i++)
			{
				bool itemChecked = this.cbListBox.GetItemChecked(i);
				if (itemChecked)
				{
					string itemText = this.cbListBox.GetItemText(this.cbListBox.Items[i - 1]);
					this.cbListBox.Items[i - 1] = this.cbListBox.GetItemText(this.cbListBox.Items[i]);
					this.cbListBox.Items[i] = itemText;
					this.cbListBox.SetItemChecked(i - 1, true);
					this.cbListBox.SetItemChecked(i, false);
					this.cbListBox.SelectedIndex = i - 1;
					this._listConfirm[i - 1].newviewidex = i + 1;
					this._listConfirm[i].newviewidex = i;
					AdminSetting.ConfirmIndex value = this._listConfirm[i - 1];
					this._listConfirm[i - 1] = this._listConfirm[i];
					this._listConfirm[i] = value;
					break;
				}
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00015960 File Offset: 0x00013B60
		private void btnDown_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.cbListBox.Items.Count - 1; i++)
			{
				bool itemChecked = this.cbListBox.GetItemChecked(i);
				if (itemChecked)
				{
					string itemText = this.cbListBox.GetItemText(this.cbListBox.Items[i + 1]);
					this.cbListBox.Items[i + 1] = this.cbListBox.GetItemText(this.cbListBox.Items[i]);
					this.cbListBox.Items[i] = itemText;
					this.cbListBox.SetItemChecked(i + 1, true);
					this.cbListBox.SetItemChecked(i, false);
					this.cbListBox.SelectedIndex = i + 1;
					this._listConfirm[i].newviewidex = i + 2;
					this._listConfirm[i + 1].newviewidex = i + 1;
					AdminSetting.ConfirmIndex value = this._listConfirm[i + 1];
					this._listConfirm[i + 1] = this._listConfirm[i];
					this._listConfirm[i] = value;
					Debug.WriteLine(this._listConfirm[i].content + "," + this._listConfirm[i].newviewidex.ToString());
					Debug.WriteLine(this._listConfirm[i + 1].content + "," + this._listConfirm[i + 1].newviewidex.ToString());
					break;
				}
			}
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00015B1C File Offset: 0x00013D1C
		private void cbListBox_SelectedValueChanged(object sender, EventArgs e)
		{
			int num = 0;
			while (this.cbListBox.SelectedIndex != -1 && num < this.cbListBox.Items.Count)
			{
				bool flag = this.cbListBox.SelectedIndex != num;
				if (flag)
				{
					this.cbListBox.SetItemChecked(num, false);
				}
				num++;
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00015B84 File Offset: 0x00013D84
		private void cbListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.cbListBox.SelectedIndex == -1;
			if (!flag)
			{
				bool itemChecked = this.cbListBox.GetItemChecked(this.cbListBox.SelectedIndex);
				if (itemChecked)
				{
					string itemText = this.cbListBox.GetItemText(this.cbListBox.Items[this.cbListBox.SelectedIndex]);
					this.tbContent.Text = itemText;
				}
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void cbListBox_ItemCheck(object sender, ItemCheckEventArgs e)
		{
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00015BF8 File Offset: 0x00013DF8
		private void btnApply_Click(object sender, EventArgs e)
		{
			this.cbListBox.ClearSelected();
			this.tbContent.Text = string.Empty;
			string text = string.Empty;
			foreach (AdminSetting.ConfirmIndex confirmIndex in this._listConfirm)
			{
				text = string.Concat(new object[]
				{
					text,
					confirmIndex.columnindex,
					"^",
					confirmIndex.viewindex,
					"^",
					(confirmIndex.newviewidex != -1) ? confirmIndex.newviewidex : 0,
					"^",
					(confirmIndex.newcontent.Trim() == string.Empty) ? string.Empty : confirmIndex.newcontent.Trim()
				});
				text += "@";
			}
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetMaintConfirmList] @factory=N'",
				this.cbConfirmFactory.SelectedItem.ToString(),
				"', @type=N'",
				this.cbConfirmType.SelectedItem.ToString(),
				"', @buffer=N'",
				text,
				"'"
			});
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag = dataSet != null && dataSet.Tables.Count > 0;
			if (flag)
			{
				bool flag2 = dataSet.Tables[0].Rows[0][0].ToString() == "OK";
				if (flag2)
				{
					this.getConfirmationList();
				}
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00015DCC File Offset: 0x00013FCC
		private void btModify_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.cbListBox.Items.Count; i++)
			{
				bool itemChecked = this.cbListBox.GetItemChecked(i);
				if (itemChecked)
				{
					this._listConfirm[i].newcontent = this.tbContent.Text.Replace("'", "''");
					this.cbListBox.Items[i] = this.tbContent.Text;
				}
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00015E58 File Offset: 0x00014058
		private void tbContent_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = e.KeyChar == '@' || e.KeyChar == '^';
			if (flag)
			{
				e.KeyChar = '\0';
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00015E8C File Offset: 0x0001408C
		private void cbConfirFactory_SelectedIndexChanged(object sender, EventArgs e)
		{
			cFunction.getCategoryList(this._factorySetting, this.cbConfirmFactory.SelectedItem.ToString(), this.cbConfirmType, false, false);
			bool flag = this.cbConfirmType.Items.IndexOf("HCC") != -1;
			if (flag)
			{
				this.cbConfirmType.Items.Remove("HCC");
			}
			string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetMachineList] @_Plant = '" + this.cbConfirmFactory.SelectedItem.ToString() + "', @SearchType = 'HCC'";
			DataSet dataSet = this._queryMgr.queryCall(sQuery);
			bool flag2 = dataSet != null && dataSet.Tables.Count > 0;
			if (flag2)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string text = dataSet.Tables[0].Rows[i]["Name"].ToString();
					bool flag3 = this.cbConfirmType.Items.IndexOf(text) == -1;
					if (flag3)
					{
						this.cbConfirmType.Items.Add(text);
					}
				}
			}
			this.cbConfirmType.SelectedIndex = 0;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00015FD8 File Offset: 0x000141D8
		private void cbFactorSystem_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.cbFactorSystem.SelectedItem == null;
			if (!flag)
			{
				int selectedIndex = this.cbFactorSystem.SelectedIndex;
				if (selectedIndex != 0)
				{
					if (selectedIndex == 1)
					{
						this.cbFactorCategory.Items.Clear();
						this.cbFactorCategory.Items.Add("REJECT");
						this.cbFactorCategory.Items.Add("DISABLE");
						this.cbFactorCase.Items.Clear();
						this.setFactorNode(this.cbFactorSystem.SelectedIndex);
					}
				}
				else
				{
					this.cbFactorCategory.Items.Clear();
					bool flag2 = this._factorySetting._factoryName == "ATK_E";
					if (flag2)
					{
						cFunction.getCategoryList(this._factorySetting, "K3_E", this.cbFactorCategory, false, false);
					}
					else
					{
						bool flag3 = this._factorySetting._factoryName == "ATK_K5_M";
						if (flag3)
						{
							cFunction.getCategoryList(this._factorySetting, "K5_M", this.cbFactorCategory, false, false);
						}
						else
						{
							bool flag4 = this._factorySetting._factoryName == "ATK_K5";
							if (flag4)
							{
								cFunction.getCategoryList(this._factorySetting, "K5_M", this.cbFactorCategory, false, false);
							}
							else
							{
								bool flag5 = this._factorySetting._factoryName == "ATV";
								if (flag5)
								{
									cFunction.getCategoryList(this._factorySetting, "ATV", this.cbFactorCategory, false, false);
								}
								else
								{
									cFunction.getCategoryList(this._factorySetting, "K3", this.cbFactorCategory, false, false);
								}
							}
						}
					}
					cFunction.getCaseList(this.cbFactorCase, false);
					this.setFactorNode(this.cbFactorSystem.SelectedIndex);
				}
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000AE4C File Offset: 0x0000904C
		private void cbFactorCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x040000BB RID: 187
		private QueryMgr _queryMgr;

		// Token: 0x040000BC RID: 188
		private SourceGrid.Cells.Views.Cell cell_header1;

		// Token: 0x040000BD RID: 189
		private List<string> _k3Mail = new List<string>();

		// Token: 0x040000BE RID: 190
		private List<string> _k4Mail = new List<string>();

		// Token: 0x040000BF RID: 191
		private List<string> _k5Mail = new List<string>();

		// Token: 0x040000C0 RID: 192
		private List<string> _atvMail = new List<string>();

		// Token: 0x040000C1 RID: 193
		private bool _bAutoLoadBlock = true;

		// Token: 0x040000C2 RID: 194
		private bool _bInitPlant = false;

		// Token: 0x040000C3 RID: 195
		private List<AdminSetting.ConfirmIndex> _listConfirm = new List<AdminSetting.ConfirmIndex>();

		// Token: 0x0200007D RID: 125
		private class ConfirmIndex
		{
			// Token: 0x17000186 RID: 390
			// (get) Token: 0x0600063F RID: 1599 RVA: 0x0008E299 File Offset: 0x0008C499
			// (set) Token: 0x0600063E RID: 1598 RVA: 0x0008E290 File Offset: 0x0008C490
			public int columnindex { get; set; }

			// Token: 0x17000187 RID: 391
			// (get) Token: 0x06000641 RID: 1601 RVA: 0x0008E2AA File Offset: 0x0008C4AA
			// (set) Token: 0x06000640 RID: 1600 RVA: 0x0008E2A1 File Offset: 0x0008C4A1
			public int viewindex { get; set; }

			// Token: 0x17000188 RID: 392
			// (get) Token: 0x06000643 RID: 1603 RVA: 0x0008E2BB File Offset: 0x0008C4BB
			// (set) Token: 0x06000642 RID: 1602 RVA: 0x0008E2B2 File Offset: 0x0008C4B2
			public int newviewidex { get; set; }

			// Token: 0x17000189 RID: 393
			// (get) Token: 0x06000645 RID: 1605 RVA: 0x0008E2CC File Offset: 0x0008C4CC
			// (set) Token: 0x06000644 RID: 1604 RVA: 0x0008E2C3 File Offset: 0x0008C4C3
			public string content { get; set; }

			// Token: 0x1700018A RID: 394
			// (get) Token: 0x06000647 RID: 1607 RVA: 0x0008E2DD File Offset: 0x0008C4DD
			// (set) Token: 0x06000646 RID: 1606 RVA: 0x0008E2D4 File Offset: 0x0008C4D4
			public string newcontent { get; set; }
		}
	}
}
