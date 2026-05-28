using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.HccSTReportModule.Class;

namespace Amkor.CADModules.HccSTReportModule.SubForms.TabPages
{
	// Token: 0x0200000E RID: 14
	public class Tab_EWS_PC : Tab_Base
	{
		// Token: 0x06000077 RID: 119 RVA: 0x00010693 File Offset: 0x0000E893
		public Tab_EWS_PC(string name)
		{
			this.InitializeComponent();
			this.Text = name;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000106A8 File Offset: 0x0000E8A8
		public void SetInfo(CTemp tempInfo, CEWS_PC cEWS_PC)
		{
			this.ClearItems();
			if (tempInfo != null)
			{
				this._tempInfo = tempInfo;
				this.tb_NumOfSites.Text = tempInfo.strNumOfSites.ToString();
				this.tb_TesterModel.Text = tempInfo.strEquipModel;
				this.tb_TouchDownCnt.Text = tempInfo.iTouchDownCnt.ToString();
			}
			if (cEWS_PC != null && tempInfo != null)
			{
				this._cEWS_PC = cEWS_PC;
				this.tb_WscsPkgDesc.Text = cEWS_PC.strWscsPkgDesc;
				this.tb_NumOfSites.Text = cEWS_PC.strNumOfSites;
				if (tempInfo.strNumOfSites != cEWS_PC.strNumOfSites)
				{
					this.tb_NumOfSites.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_NumOfPins.Text = cEWS_PC.iNumOfPins.ToString();
				this.tb_PinType.Text = cEWS_PC.strPinType;
				this.tb_CapableTemp.Text = cEWS_PC.strCapableTemp;
				this.tb_ProbeCardType.Text = cEWS_PC.strProbeCardType;
				this.tb_SeprPcbBoard.Text = cEWS_PC.strSeperPcbBoard;
				this.tb_PcbId.Text = cEWS_PC.strPcbId;
				this.tb_ProbeHeadId.Text = cEWS_PC.strProbeHeadId;
				this.tb_PairedPcbId.Text = cEWS_PC.strPairedPcbId;
				this.tb_MfrName.Text = cEWS_PC.strMfrName;
				this.tb_MfrPartNo.Text = cEWS_PC.strMfrPartNo;
				this.tb_RepairSupplier.Text = cEWS_PC.strRepairSupplier;
				this.tb_TesterModel.Text = cEWS_PC.strTesterModel;
				if (tempInfo.strEquipModel != cEWS_PC.strTesterModel)
				{
					this.tb_TesterModel.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_ProberModel.Text = cEWS_PC.strProberModel;
				this.tb_IncomTipLg.Text = cEWS_PC.iIncommTipLg.ToString();
				this.tb_IncomTipDia.Text = cEWS_PC.iIncommTipDia.ToString();
				this.tb_CurTipLg.Text = cEWS_PC.iCurTipLg.ToString();
				this.tb_CurTipDia.Text = cEWS_PC.iCurTipDia.ToString();
				this.tb_TouchDownCnt.Text = cEWS_PC.iTouchDownCnt.ToString();
				if (tempInfo.iTouchDownCnt != cEWS_PC.iTouchDownCnt)
				{
					this.tb_TouchDownCnt.BackColor = Color.FromArgb(246, 229, 141);
				}
				this.tb_AccumTouchDown.Text = cEWS_PC.iAccumTouchDown.ToString();
				this.tb_MinTipLgSpec.Text = cEWS_PC.iMinTipLgSpec.ToString();
				this.tb_MinTipDiaSpec.Text = cEWS_PC.iMinTipDiaSpec.ToString();
				this.tb_ExpectTouchDown.Text = cEWS_PC.iExpectTouchDown.ToString();
			}
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00010970 File Offset: 0x0000EB70
		public CEWS_PC InputInfos()
		{
			CEWS_PC cews_PC = new CEWS_PC();
			cews_PC.strWscsPkgDesc = this.tb_WscsPkgDesc.Text;
			cews_PC.strNumOfSites = this.tb_NumOfSites.Text;
			if (this.tb_NumOfPins.Text != "")
			{
				if (!int.TryParse(this.tb_NumOfPins.Text, out cews_PC.iNumOfPins))
				{
					MessageBox.Show("No. Of Pins must be Integer!");
					return null;
				}
			}
			else
			{
				cews_PC.iNumOfPins = 0;
			}
			cews_PC.strPinType = this.tb_PinType.Text;
			cews_PC.strCapableTemp = this.tb_CapableTemp.Text;
			cews_PC.strProbeCardType = this.tb_ProbeCardType.Text;
			cews_PC.strSeperPcbBoard = this.tb_SeprPcbBoard.Text;
			cews_PC.strPcbId = this.tb_PcbId.Text;
			cews_PC.strProbeHeadId = this.tb_ProbeHeadId.Text;
			cews_PC.strPairedPcbId = this.tb_PairedPcbId.Text;
			cews_PC.strMfrName = this.tb_MfrName.Text;
			cews_PC.strMfrPartNo = this.tb_MfrPartNo.Text;
			cews_PC.strRepairSupplier = this.tb_RepairSupplier.Text;
			cews_PC.strTesterModel = this.tb_TesterModel.Text;
			cews_PC.strProberModel = this.tb_ProberModel.Text;
			if (this.tb_IncomTipLg.Text != "")
			{
				if (!int.TryParse(this.tb_IncomTipLg.Text, out cews_PC.iIncommTipLg))
				{
					MessageBox.Show("Incomming Tip Lg must be Integer!");
					return null;
				}
			}
			else
			{
				cews_PC.iIncommTipLg = 0;
			}
			if (this.tb_IncomTipDia.Text != "")
			{
				if (!int.TryParse(this.tb_IncomTipDia.Text, out cews_PC.iIncommTipDia))
				{
					MessageBox.Show("Incomming Tip Dia must be Integer!");
					return null;
				}
			}
			else
			{
				cews_PC.iIncommTipDia = 0;
			}
			if (this.tb_CurTipLg.Text != "")
			{
				if (!int.TryParse(this.tb_CurTipLg.Text, out cews_PC.iCurTipLg))
				{
					MessageBox.Show("Current Tip Lg must be Integer!");
					return null;
				}
			}
			else
			{
				cews_PC.iCurTipLg = 0;
			}
			if (this.tb_CurTipDia.Text != "")
			{
				if (!int.TryParse(this.tb_CurTipDia.Text, out cews_PC.iCurTipDia))
				{
					MessageBox.Show("Current Tip Dia must be Integer!");
					return null;
				}
			}
			else
			{
				cews_PC.iCurTipDia = 0;
			}
			if (this.tb_TouchDownCnt.Text != "")
			{
				if (!int.TryParse(this.tb_TouchDownCnt.Text, out cews_PC.iTouchDownCnt))
				{
					MessageBox.Show("Touch Down Count must be Integer!");
					return null;
				}
			}
			else
			{
				cews_PC.iTouchDownCnt = 0;
			}
			if (this.tb_AccumTouchDown.Text != "")
			{
				if (!int.TryParse(this.tb_AccumTouchDown.Text, out cews_PC.iAccumTouchDown))
				{
					MessageBox.Show("Accum. Touch Down must be Integer!");
					return null;
				}
			}
			else
			{
				cews_PC.iAccumTouchDown = 0;
			}
			if (this.tb_MinTipLgSpec.Text != "")
			{
				if (!int.TryParse(this.tb_MinTipLgSpec.Text, out cews_PC.iMinTipLgSpec))
				{
					MessageBox.Show("Min Tip Lg must be Integer!");
					return null;
				}
			}
			else
			{
				cews_PC.iMinTipLgSpec = 0;
			}
			if (this.tb_MinTipDiaSpec.Text != "")
			{
				if (!int.TryParse(this.tb_MinTipDiaSpec.Text, out cews_PC.iMinTipDiaSpec))
				{
					MessageBox.Show("Min Tip Dia must be Integer!");
					return null;
				}
			}
			else
			{
				cews_PC.iMinTipDiaSpec = 0;
			}
			if (this.tb_ExpectTouchDown.Text != "")
			{
				if (!int.TryParse(this.tb_ExpectTouchDown.Text, out cews_PC.iExpectTouchDown))
				{
					MessageBox.Show("Expect. Touch Down must be Integer!");
					return null;
				}
			}
			else
			{
				cews_PC.iExpectTouchDown = 0;
			}
			return cews_PC;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00010D10 File Offset: 0x0000EF10
		public void ClearItems()
		{
			this.tb_WscsPkgDesc.Text = "";
			this.tb_NumOfSites.Text = "";
			this.tb_NumOfPins.Text = "";
			this.tb_PinType.Text = "";
			this.tb_CapableTemp.Text = "";
			this.tb_ProbeCardType.Text = "";
			this.tb_SeprPcbBoard.Text = "";
			this.tb_PcbId.Text = "";
			this.tb_ProbeHeadId.Text = "";
			this.tb_PairedPcbId.Text = "";
			this.tb_MfrName.Text = "";
			this.tb_MfrPartNo.Text = "";
			this.tb_RepairSupplier.Text = "";
			this.tb_TesterModel.Text = "";
			this.tb_ProberModel.Text = "";
			this.tb_IncomTipLg.Text = "";
			this.tb_IncomTipDia.Text = "";
			this.tb_CurTipLg.Text = "";
			this.tb_CurTipDia.Text = "";
			this.tb_TouchDownCnt.Text = "";
			this.tb_AccumTouchDown.Text = "";
			this.tb_MinTipLgSpec.Text = "";
			this.tb_MinTipDiaSpec.Text = "";
			this.tb_ExpectTouchDown.Text = "";
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00010EA0 File Offset: 0x0000F0A0
		private void tb_NumOfSites_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this._tempInfo.strNumOfSites != this.tb_NumOfSites.Text && MessageBox.Show(string.Concat(new string[]
			{
				"Information is Different\nHCC: ",
				this._tempInfo.strNumOfSites,
				"\nTHIS: ",
				this.tb_NumOfSites.Text,
				"\nDo you want to change info from HCC?"
			}), "Different Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.tb_NumOfSites.Text = this._tempInfo.strNumOfSites;
				this.tb_NumOfSites.BackColor = Color.White;
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00010F40 File Offset: 0x0000F140
		private void tb_TesterModel_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this._tempInfo.strEquipModel != this.tb_TesterModel.Text && MessageBox.Show(string.Concat(new string[]
			{
				"Information is Different\nHCC: ",
				this._tempInfo.strEquipModel,
				"\nTHIS: ",
				this.tb_TesterModel.Text,
				"\nDo you want to change info from HCC?"
			}), "Different Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.tb_TesterModel.Text = this._tempInfo.strEquipModel;
				this.tb_TesterModel.BackColor = Color.White;
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00010FE0 File Offset: 0x0000F1E0
		private void tb_TouchDownCnt_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this._tempInfo.iTouchDownCnt.ToString() != this.tb_TouchDownCnt.Text && MessageBox.Show(string.Concat(new string[]
			{
				"Information is Different\nHCC: ",
				this._tempInfo.iTouchDownCnt.ToString(),
				"\nTHIS: ",
				this.tb_TouchDownCnt.Text,
				"\nDo you want to change info from HCC?"
			}), "Different Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.tb_TouchDownCnt.Text = this._tempInfo.iTouchDownCnt.ToString();
				this.tb_TouchDownCnt.BackColor = Color.White;
			}
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0001108C File Offset: 0x0000F28C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000110AC File Offset: 0x0000F2AC
		private void InitializeComponent()
		{
			this.tb_WscsPkgDesc = new TextBox();
			this.label1 = new Label();
			this.tb_NumOfSites = new TextBox();
			this.label2 = new Label();
			this.tb_NumOfPins = new TextBox();
			this.label3 = new Label();
			this.tb_PinType = new TextBox();
			this.label4 = new Label();
			this.tb_CapableTemp = new TextBox();
			this.label5 = new Label();
			this.tb_ProbeCardType = new TextBox();
			this.label6 = new Label();
			this.tb_SeprPcbBoard = new TextBox();
			this.label7 = new Label();
			this.tb_PcbId = new TextBox();
			this.label8 = new Label();
			this.tb_ProbeHeadId = new TextBox();
			this.label9 = new Label();
			this.tb_PairedPcbId = new TextBox();
			this.label10 = new Label();
			this.tb_MfrName = new TextBox();
			this.label11 = new Label();
			this.tb_MfrPartNo = new TextBox();
			this.label12 = new Label();
			this.tb_RepairSupplier = new TextBox();
			this.label13 = new Label();
			this.tb_TesterModel = new TextBox();
			this.label14 = new Label();
			this.tb_ProberModel = new TextBox();
			this.label15 = new Label();
			this.tb_IncomTipLg = new TextBox();
			this.label16 = new Label();
			this.tb_IncomTipDia = new TextBox();
			this.label17 = new Label();
			this.tb_CurTipLg = new TextBox();
			this.label18 = new Label();
			this.tb_CurTipDia = new TextBox();
			this.label19 = new Label();
			this.tb_TouchDownCnt = new TextBox();
			this.label20 = new Label();
			this.tb_AccumTouchDown = new TextBox();
			this.label21 = new Label();
			this.tb_MinTipLgSpec = new TextBox();
			this.label22 = new Label();
			this.tb_MinTipDiaSpec = new TextBox();
			this.label23 = new Label();
			this.tb_ExpectTouchDown = new TextBox();
			this.label24 = new Label();
			this.groupBox1 = new GroupBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.groupBox1);
			this.tb_WscsPkgDesc.Location = new Point(139, 24);
			this.tb_WscsPkgDesc.Margin = new Padding(3, 5, 3, 5);
			this.tb_WscsPkgDesc.Name = "tb_WscsPkgDesc";
			this.tb_WscsPkgDesc.Size = new Size(200, 23);
			this.tb_WscsPkgDesc.TabIndex = 14;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(13, 27);
			this.label1.Name = "label1";
			this.label1.Size = new Size(112, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "Wscs Package Desc.";
			this.tb_NumOfSites.Location = new Point(139, 51);
			this.tb_NumOfSites.Margin = new Padding(3, 5, 3, 5);
			this.tb_NumOfSites.Name = "tb_NumOfSites";
			this.tb_NumOfSites.Size = new Size(200, 23);
			this.tb_NumOfSites.TabIndex = 16;
			this.tb_NumOfSites.MouseDoubleClick += this.tb_NumOfSites_MouseDoubleClick;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(13, 54);
			this.label2.Name = "label2";
			this.label2.Size = new Size(67, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "No. of Sites";
			this.tb_NumOfPins.Location = new Point(139, 78);
			this.tb_NumOfPins.Margin = new Padding(3, 5, 3, 5);
			this.tb_NumOfPins.Name = "tb_NumOfPins";
			this.tb_NumOfPins.Size = new Size(200, 23);
			this.tb_NumOfPins.TabIndex = 18;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(13, 81);
			this.label3.Name = "label3";
			this.label3.Size = new Size(65, 15);
			this.label3.TabIndex = 17;
			this.label3.Text = "No. of Pins";
			this.tb_PinType.Location = new Point(139, 105);
			this.tb_PinType.Margin = new Padding(3, 5, 3, 5);
			this.tb_PinType.Name = "tb_PinType";
			this.tb_PinType.Size = new Size(200, 23);
			this.tb_PinType.TabIndex = 20;
			this.label4.AutoSize = true;
			this.label4.Location = new Point(13, 108);
			this.label4.Name = "label4";
			this.label4.Size = new Size(52, 15);
			this.label4.TabIndex = 19;
			this.label4.Text = "Pin Type";
			this.tb_CapableTemp.Location = new Point(139, 132);
			this.tb_CapableTemp.Margin = new Padding(3, 5, 3, 5);
			this.tb_CapableTemp.Name = "tb_CapableTemp";
			this.tb_CapableTemp.Size = new Size(200, 23);
			this.tb_CapableTemp.TabIndex = 22;
			this.label5.AutoSize = true;
			this.label5.Location = new Point(13, 135);
			this.label5.Name = "label5";
			this.label5.Size = new Size(120, 15);
			this.label5.TabIndex = 21;
			this.label5.Text = "Capable Temperature";
			this.tb_ProbeCardType.Location = new Point(139, 159);
			this.tb_ProbeCardType.Margin = new Padding(3, 5, 3, 5);
			this.tb_ProbeCardType.Name = "tb_ProbeCardType";
			this.tb_ProbeCardType.Size = new Size(200, 23);
			this.tb_ProbeCardType.TabIndex = 24;
			this.label6.AutoSize = true;
			this.label6.Location = new Point(13, 162);
			this.label6.Name = "label6";
			this.label6.Size = new Size(94, 15);
			this.label6.TabIndex = 23;
			this.label6.Text = "Probe Card Type";
			this.tb_SeprPcbBoard.Location = new Point(139, 186);
			this.tb_SeprPcbBoard.Margin = new Padding(3, 5, 3, 5);
			this.tb_SeprPcbBoard.Name = "tb_SeprPcbBoard";
			this.tb_SeprPcbBoard.Size = new Size(200, 23);
			this.tb_SeprPcbBoard.TabIndex = 26;
			this.label7.AutoSize = true;
			this.label7.Location = new Point(13, 189);
			this.label7.Name = "label7";
			this.label7.Size = new Size(111, 15);
			this.label7.TabIndex = 25;
			this.label7.Text = "Seperate PCB Board";
			this.tb_PcbId.Location = new Point(139, 213);
			this.tb_PcbId.Margin = new Padding(3, 5, 3, 5);
			this.tb_PcbId.Name = "tb_PcbId";
			this.tb_PcbId.Size = new Size(200, 23);
			this.tb_PcbId.TabIndex = 28;
			this.label8.AutoSize = true;
			this.label8.Location = new Point(13, 216);
			this.label8.Name = "label8";
			this.label8.Size = new Size(43, 15);
			this.label8.TabIndex = 27;
			this.label8.Text = "PCB ID";
			this.tb_ProbeHeadId.Location = new Point(486, 24);
			this.tb_ProbeHeadId.Margin = new Padding(3, 5, 3, 5);
			this.tb_ProbeHeadId.Name = "tb_ProbeHeadId";
			this.tb_ProbeHeadId.Size = new Size(200, 23);
			this.tb_ProbeHeadId.TabIndex = 30;
			this.label9.AutoSize = true;
			this.label9.Location = new Point(360, 27);
			this.label9.Name = "label9";
			this.label9.Size = new Size(83, 15);
			this.label9.TabIndex = 29;
			this.label9.Text = "Probe Head ID";
			this.tb_PairedPcbId.Location = new Point(486, 51);
			this.tb_PairedPcbId.Margin = new Padding(3, 5, 3, 5);
			this.tb_PairedPcbId.Name = "tb_PairedPcbId";
			this.tb_PairedPcbId.Size = new Size(200, 23);
			this.tb_PairedPcbId.TabIndex = 32;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(360, 54);
			this.label10.Name = "label10";
			this.label10.Size = new Size(79, 15);
			this.label10.TabIndex = 31;
			this.label10.Text = "Paired PCB ID";
			this.tb_MfrName.Location = new Point(486, 78);
			this.tb_MfrName.Margin = new Padding(3, 5, 3, 5);
			this.tb_MfrName.Name = "tb_MfrName";
			this.tb_MfrName.Size = new Size(200, 23);
			this.tb_MfrName.TabIndex = 34;
			this.label11.AutoSize = true;
			this.label11.Location = new Point(360, 81);
			this.label11.Name = "label11";
			this.label11.Size = new Size(64, 15);
			this.label11.TabIndex = 33;
			this.label11.Text = "Mfr. Name";
			this.tb_MfrPartNo.Location = new Point(486, 105);
			this.tb_MfrPartNo.Margin = new Padding(3, 5, 3, 5);
			this.tb_MfrPartNo.Name = "tb_MfrPartNo";
			this.tb_MfrPartNo.Size = new Size(200, 23);
			this.tb_MfrPartNo.TabIndex = 36;
			this.label12.AutoSize = true;
			this.label12.Location = new Point(360, 108);
			this.label12.Name = "label12";
			this.label12.Size = new Size(100, 15);
			this.label12.TabIndex = 35;
			this.label12.Text = "Mfr. Part Number";
			this.tb_RepairSupplier.Location = new Point(486, 132);
			this.tb_RepairSupplier.Margin = new Padding(3, 5, 3, 5);
			this.tb_RepairSupplier.Name = "tb_RepairSupplier";
			this.tb_RepairSupplier.Size = new Size(200, 23);
			this.tb_RepairSupplier.TabIndex = 38;
			this.label13.AutoSize = true;
			this.label13.Location = new Point(360, 135);
			this.label13.Name = "label13";
			this.label13.Size = new Size(86, 15);
			this.label13.TabIndex = 37;
			this.label13.Text = "Repair Supplier";
			this.tb_TesterModel.Location = new Point(486, 159);
			this.tb_TesterModel.Margin = new Padding(3, 5, 3, 5);
			this.tb_TesterModel.Name = "tb_TesterModel";
			this.tb_TesterModel.Size = new Size(200, 23);
			this.tb_TesterModel.TabIndex = 40;
			this.tb_TesterModel.MouseDoubleClick += this.tb_TesterModel_MouseDoubleClick;
			this.label14.AutoSize = true;
			this.label14.Location = new Point(360, 162);
			this.label14.Name = "label14";
			this.label14.Size = new Size(75, 15);
			this.label14.TabIndex = 39;
			this.label14.Text = "Tester Model";
			this.tb_ProberModel.Location = new Point(486, 186);
			this.tb_ProberModel.Margin = new Padding(3, 5, 3, 5);
			this.tb_ProberModel.Name = "tb_ProberModel";
			this.tb_ProberModel.Size = new Size(200, 23);
			this.tb_ProberModel.TabIndex = 42;
			this.label15.AutoSize = true;
			this.label15.Location = new Point(360, 189);
			this.label15.Name = "label15";
			this.label15.Size = new Size(79, 15);
			this.label15.TabIndex = 41;
			this.label15.Text = "Prober Model";
			this.tb_IncomTipLg.Location = new Point(486, 213);
			this.tb_IncomTipLg.Margin = new Padding(3, 5, 3, 5);
			this.tb_IncomTipLg.Name = "tb_IncomTipLg";
			this.tb_IncomTipLg.Size = new Size(200, 23);
			this.tb_IncomTipLg.TabIndex = 44;
			this.label16.AutoSize = true;
			this.label16.Location = new Point(360, 216);
			this.label16.Name = "label16";
			this.label16.Size = new Size(105, 15);
			this.label16.TabIndex = 43;
			this.label16.Text = "Incomming Tip Lg";
			this.tb_IncomTipDia.Location = new Point(836, 24);
			this.tb_IncomTipDia.Margin = new Padding(3, 5, 3, 5);
			this.tb_IncomTipDia.Name = "tb_IncomTipDia";
			this.tb_IncomTipDia.Size = new Size(200, 23);
			this.tb_IncomTipDia.TabIndex = 46;
			this.label17.AutoSize = true;
			this.label17.Location = new Point(710, 27);
			this.label17.Name = "label17";
			this.label17.Size = new Size(109, 15);
			this.label17.TabIndex = 45;
			this.label17.Text = "Incomming Tip Dia";
			this.tb_CurTipLg.Location = new Point(836, 51);
			this.tb_CurTipLg.Margin = new Padding(3, 5, 3, 5);
			this.tb_CurTipLg.Name = "tb_CurTipLg";
			this.tb_CurTipLg.Size = new Size(200, 23);
			this.tb_CurTipLg.TabIndex = 48;
			this.label18.AutoSize = true;
			this.label18.Location = new Point(710, 54);
			this.label18.Name = "label18";
			this.label18.Size = new Size(83, 15);
			this.label18.TabIndex = 47;
			this.label18.Text = "Current Tip Lg";
			this.tb_CurTipDia.Location = new Point(836, 78);
			this.tb_CurTipDia.Margin = new Padding(3, 5, 3, 5);
			this.tb_CurTipDia.Name = "tb_CurTipDia";
			this.tb_CurTipDia.Size = new Size(200, 23);
			this.tb_CurTipDia.TabIndex = 50;
			this.label19.AutoSize = true;
			this.label19.Location = new Point(710, 81);
			this.label19.Name = "label19";
			this.label19.Size = new Size(87, 15);
			this.label19.TabIndex = 49;
			this.label19.Text = "Current Tip Dia";
			this.tb_TouchDownCnt.Location = new Point(836, 105);
			this.tb_TouchDownCnt.Margin = new Padding(3, 5, 3, 5);
			this.tb_TouchDownCnt.Name = "tb_TouchDownCnt";
			this.tb_TouchDownCnt.Size = new Size(200, 23);
			this.tb_TouchDownCnt.TabIndex = 52;
			this.tb_TouchDownCnt.MouseDoubleClick += this.tb_TouchDownCnt_MouseDoubleClick;
			this.label20.AutoSize = true;
			this.label20.Location = new Point(710, 108);
			this.label20.Name = "label20";
			this.label20.Size = new Size(110, 15);
			this.label20.TabIndex = 51;
			this.label20.Text = "Touch Down Count";
			this.tb_AccumTouchDown.Location = new Point(836, 132);
			this.tb_AccumTouchDown.Margin = new Padding(3, 5, 3, 5);
			this.tb_AccumTouchDown.Name = "tb_AccumTouchDown";
			this.tb_AccumTouchDown.Size = new Size(200, 23);
			this.tb_AccumTouchDown.TabIndex = 54;
			this.label21.AutoSize = true;
			this.label21.Location = new Point(710, 135);
			this.label21.Name = "label21";
			this.label21.Size = new Size(118, 15);
			this.label21.TabIndex = 53;
			this.label21.Text = "Accum. Touch Down";
			this.tb_MinTipLgSpec.Location = new Point(836, 159);
			this.tb_MinTipLgSpec.Margin = new Padding(3, 5, 3, 5);
			this.tb_MinTipLgSpec.Name = "tb_MinTipLgSpec";
			this.tb_MinTipLgSpec.Size = new Size(200, 23);
			this.tb_MinTipLgSpec.TabIndex = 56;
			this.label22.AutoSize = true;
			this.label22.Location = new Point(710, 162);
			this.label22.Name = "label22";
			this.label22.Size = new Size(92, 15);
			this.label22.TabIndex = 55;
			this.label22.Text = "Min Tip Lg Spec";
			this.tb_MinTipDiaSpec.Location = new Point(836, 186);
			this.tb_MinTipDiaSpec.Margin = new Padding(3, 5, 3, 5);
			this.tb_MinTipDiaSpec.Name = "tb_MinTipDiaSpec";
			this.tb_MinTipDiaSpec.Size = new Size(200, 23);
			this.tb_MinTipDiaSpec.TabIndex = 58;
			this.label23.AutoSize = true;
			this.label23.Location = new Point(710, 189);
			this.label23.Name = "label23";
			this.label23.Size = new Size(96, 15);
			this.label23.TabIndex = 57;
			this.label23.Text = "Min Tip Dia Spec";
			this.tb_ExpectTouchDown.Location = new Point(836, 213);
			this.tb_ExpectTouchDown.Margin = new Padding(3, 5, 3, 5);
			this.tb_ExpectTouchDown.Name = "tb_ExpectTouchDown";
			this.tb_ExpectTouchDown.Size = new Size(200, 23);
			this.tb_ExpectTouchDown.TabIndex = 60;
			this.label24.AutoSize = true;
			this.label24.Location = new Point(710, 216);
			this.label24.Name = "label24";
			this.label24.Size = new Size(114, 15);
			this.label24.TabIndex = 59;
			this.label24.Text = "Expect. Touch Down";
			this.groupBox1.Controls.Add(this.tb_WscsPkgDesc);
			this.groupBox1.Controls.Add(this.tb_ExpectTouchDown);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label24);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tb_MinTipDiaSpec);
			this.groupBox1.Controls.Add(this.tb_NumOfSites);
			this.groupBox1.Controls.Add(this.label23);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tb_MinTipLgSpec);
			this.groupBox1.Controls.Add(this.tb_NumOfPins);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.tb_AccumTouchDown);
			this.groupBox1.Controls.Add(this.tb_PinType);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.tb_TouchDownCnt);
			this.groupBox1.Controls.Add(this.tb_CapableTemp);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tb_CurTipDia);
			this.groupBox1.Controls.Add(this.tb_ProbeCardType);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.tb_CurTipLg);
			this.groupBox1.Controls.Add(this.tb_SeprPcbBoard);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.tb_IncomTipDia);
			this.groupBox1.Controls.Add(this.tb_PcbId);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tb_IncomTipLg);
			this.groupBox1.Controls.Add(this.tb_ProbeHeadId);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tb_ProberModel);
			this.groupBox1.Controls.Add(this.tb_PairedPcbId);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tb_TesterModel);
			this.groupBox1.Controls.Add(this.tb_MfrName);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.tb_RepairSupplier);
			this.groupBox1.Controls.Add(this.tb_MfrPartNo);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Dock = DockStyle.Fill;
			this.groupBox1.Location = new Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(1050, 248);
			this.groupBox1.TabIndex = 61;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input Fields";
			base.Name = "Tab_EWS_PC";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040000C4 RID: 196
		private CTemp _tempInfo;

		// Token: 0x040000C5 RID: 197
		private CEWS_PC _cEWS_PC;

		// Token: 0x040000C6 RID: 198
		private IContainer components;

		// Token: 0x040000C7 RID: 199
		private TextBox tb_WscsPkgDesc;

		// Token: 0x040000C8 RID: 200
		private Label label1;

		// Token: 0x040000C9 RID: 201
		private TextBox tb_NumOfPins;

		// Token: 0x040000CA RID: 202
		private Label label3;

		// Token: 0x040000CB RID: 203
		private TextBox tb_NumOfSites;

		// Token: 0x040000CC RID: 204
		private Label label2;

		// Token: 0x040000CD RID: 205
		private GroupBox groupBox1;

		// Token: 0x040000CE RID: 206
		private TextBox tb_ExpectTouchDown;

		// Token: 0x040000CF RID: 207
		private Label label24;

		// Token: 0x040000D0 RID: 208
		private TextBox tb_MinTipDiaSpec;

		// Token: 0x040000D1 RID: 209
		private Label label23;

		// Token: 0x040000D2 RID: 210
		private TextBox tb_MinTipLgSpec;

		// Token: 0x040000D3 RID: 211
		private Label label22;

		// Token: 0x040000D4 RID: 212
		private Label label4;

		// Token: 0x040000D5 RID: 213
		private TextBox tb_AccumTouchDown;

		// Token: 0x040000D6 RID: 214
		private TextBox tb_PinType;

		// Token: 0x040000D7 RID: 215
		private Label label21;

		// Token: 0x040000D8 RID: 216
		private Label label5;

		// Token: 0x040000D9 RID: 217
		private TextBox tb_TouchDownCnt;

		// Token: 0x040000DA RID: 218
		private TextBox tb_CapableTemp;

		// Token: 0x040000DB RID: 219
		private Label label20;

		// Token: 0x040000DC RID: 220
		private Label label6;

		// Token: 0x040000DD RID: 221
		private TextBox tb_CurTipDia;

		// Token: 0x040000DE RID: 222
		private TextBox tb_ProbeCardType;

		// Token: 0x040000DF RID: 223
		private Label label19;

		// Token: 0x040000E0 RID: 224
		private Label label7;

		// Token: 0x040000E1 RID: 225
		private TextBox tb_CurTipLg;

		// Token: 0x040000E2 RID: 226
		private TextBox tb_SeprPcbBoard;

		// Token: 0x040000E3 RID: 227
		private Label label18;

		// Token: 0x040000E4 RID: 228
		private Label label8;

		// Token: 0x040000E5 RID: 229
		private TextBox tb_IncomTipDia;

		// Token: 0x040000E6 RID: 230
		private TextBox tb_PcbId;

		// Token: 0x040000E7 RID: 231
		private Label label17;

		// Token: 0x040000E8 RID: 232
		private Label label9;

		// Token: 0x040000E9 RID: 233
		private TextBox tb_IncomTipLg;

		// Token: 0x040000EA RID: 234
		private TextBox tb_ProbeHeadId;

		// Token: 0x040000EB RID: 235
		private Label label16;

		// Token: 0x040000EC RID: 236
		private Label label10;

		// Token: 0x040000ED RID: 237
		private TextBox tb_ProberModel;

		// Token: 0x040000EE RID: 238
		private TextBox tb_PairedPcbId;

		// Token: 0x040000EF RID: 239
		private Label label15;

		// Token: 0x040000F0 RID: 240
		private Label label11;

		// Token: 0x040000F1 RID: 241
		private TextBox tb_TesterModel;

		// Token: 0x040000F2 RID: 242
		private TextBox tb_MfrName;

		// Token: 0x040000F3 RID: 243
		private Label label14;

		// Token: 0x040000F4 RID: 244
		private Label label12;

		// Token: 0x040000F5 RID: 245
		private TextBox tb_RepairSupplier;

		// Token: 0x040000F6 RID: 246
		private TextBox tb_MfrPartNo;

		// Token: 0x040000F7 RID: 247
		private Label label13;
	}
}
