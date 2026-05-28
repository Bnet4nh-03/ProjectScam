using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Amkor.CADModules.ManufactureHistory.GrobalConstMFG;
using Amkor.CADModules.ManufactureHistory.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;

namespace Amkor.CADModules.ManufactureHistory.SubForm
{
	// Token: 0x02000012 RID: 18
	public partial class Report : BaseWinView
	{
		// Token: 0x06000066 RID: 102 RVA: 0x0000B194 File Offset: 0x00009394
		public Report(CIMitarAccount cimitarUser, FactorySettings factorySettings)
		{
			this._factorySettings = factorySettings;
			this._cimitarUser = cimitarUser;
			this._lFileList.Clear();
			this.InitializeComponent();
			this.InitGrid(false);
			this.iniData();
			this.getUserData();
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000B234 File Offset: 0x00009434
		private void InitGrid(bool display)
		{
			this.dgFailAtacth.Rows.Clear();
			if (display)
			{
				this.dgFailAtacth.ColumnCount = 1;
				this.dgFailAtacth.RowCount = 1;
				this.dgFailAtacth.ColumnHeadersVisible = false;
			}
			else
			{
				this.dgFailAtacth.ColumnCount = 2;
				this.dgFailAtacth.RowCount = 1;
				this.dgFailAtacth.ColumnHeadersVisible = true;
				this.dgFailAtacth.Columns[0].HeaderText = "File";
				this.dgFailAtacth.Columns[1].HeaderText = "Path";
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000B2E7 File Offset: 0x000094E7
		private void iniData()
		{
			cFunction.getCategoryList(this._factorySettings, "K5_M", this.cbCategory, false);
			cFunction.getCustList(this._factorySettings, this.cbCustList, false);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000B318 File Offset: 0x00009518
		private void cbCustList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cbCustList.SelectedIndex != -1)
			{
				string text = this.cbCustList.SelectedItem.ToString();
				if (text.IndexOf("(") > 0)
				{
					text = text.Substring(text.IndexOf("(") + 1, text.IndexOf(")") - text.IndexOf("(") - 1);
					cFunction.getNickNameList(this._factorySettings, text, this.cbNickName, false);
				}
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000B3A4 File Offset: 0x000095A4
		private void rbContent1_Click(object sender, EventArgs e)
		{
			if (this.rbContent1.Text.Trim() == this._sContent1Init)
			{
				this.rbContent1.Text = string.Empty;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000B3E8 File Offset: 0x000095E8
		private void pbAdd_Click(object sender, EventArgs e)
		{
			this.openFileDialog.FileName = string.Empty;
			if (this.openFileDialog.ShowDialog() == DialogResult.OK)
			{
				cFileList cFileList = new cFileList();
				int num = this.openFileDialog.FileName.LastIndexOf("\\") + 1;
				FileInfo fileInfo = new FileInfo(this.openFileDialog.FileName);
				if (this._lTotalByte + fileInfo.Length > this._lMaximumByte)
				{
					MessageBox.Show("첨부파일 총 용량은 10MB까지 입니다. 확인 부탁드립니다.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					this._lTotalByte += fileInfo.Length;
					cFileList.sFileName = this.openFileDialog.FileName.Substring(num, this.openFileDialog.FileName.Length - num);
					cFileList.sFilePath = this.openFileDialog.FileName;
					cFileList.size = fileInfo.Length;
					this._lFileList.Add(cFileList);
					this.dgFailAtacth.RowCount = this.dgFailAtacth.RowCount + 1;
					for (int i = 0; i < this._lFileList.Count; i++)
					{
						cFileList = this._lFileList[i];
						this.dgFailAtacth.Rows[i].Cells[0].Value = cFileList.sFileName;
						this.dgFailAtacth.Rows[i].Cells[1].Value = cFileList.sFilePath;
					}
					this.dgFailAtacth.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
				}
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000B594 File Offset: 0x00009794
		private void pbDalete_Click(object sender, EventArgs e)
		{
			if (this.dgFailAtacth.RowCount >= 1)
			{
				if (this.dgFailAtacth.Rows[0].Cells[0].Value != null && this.dgFailAtacth.Rows[0].Cells[0].Value.ToString() != string.Empty)
				{
					foreach (cFileList cFileList in this._lFileList)
					{
						if (cFileList.sFileName == this.dgFailAtacth.Rows[this.dgFailAtacth.RowCount - 2].Cells[0].Value.ToString())
						{
							this._lTotalByte -= cFileList.size;
							this._lFileList.Remove(cFileList);
							break;
						}
					}
					this.dgFailAtacth.RowCount = this.dgFailAtacth.RowCount - 1;
				}
				this.dgFailAtacth.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000B6F0 File Offset: 0x000098F0
		private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.cbCategory.SelectedIndex != -1 && this.cbCategory.SelectedItem != null)
			{
				this.subItemClear();
				this.getMachineNumber();
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000B738 File Offset: 0x00009938
		private void subItemClear()
		{
			this.cbMachine.SelectedIndex = -1;
			this.tbModel.Text = string.Empty;
			this.tbRsc.Text = string.Empty;
			this.cbOperation.SelectedIndex = -1;
			this.cbCustList.SelectedIndex = -1;
			this.cbNickName.SelectedIndex = -1;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000B79C File Offset: 0x0000999C
		private void getMachineNumber()
		{
			this.cbMachine.Items.Clear();
			DataSet machineNumber = cFunction.getMachineNumber(this.cbCategory.SelectedItem.ToString());
			if (machineNumber != null && machineNumber.Tables.Count > 0)
			{
				int num = 0;
				string[] array = new string[machineNumber.Tables[0].Rows.Count];
				string[] array2 = new string[machineNumber.Tables[0].Rows.Count];
				AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
				AutoCompleteStringCollection autoCompleteStringCollection2 = new AutoCompleteStringCollection();
				this._MachineModelList.Clear();
				for (int i = 0; i < machineNumber.Tables[0].Rows.Count; i++)
				{
					string sSelectModel = machineNumber.Tables[0].Rows[i]["Model"].ToString();
					string text = string.Empty;
					string sSelectRsc = string.Empty;
					if (this.cbCategory.SelectedItem.ToString().CompareTo("EOL") == 0 || this.cbCategory.SelectedItem.ToString().CompareTo("STACK") == 0)
					{
						sSelectRsc = machineNumber.Tables[0].Rows[i]["Rsc"].ToString();
						text = machineNumber.Tables[0].Rows[i]["Plant"].ToString();
					}
					string text2 = machineNumber.Tables[0].Rows[i]["Name"].ToString();
					MachineInfo machineInfo = new MachineInfo();
					machineInfo.sSelectMachine = text2;
					machineInfo.sSelectModel = sSelectModel;
					machineInfo.sSelectRsc = sSelectRsc;
					this._MachineModelList.Add(machineInfo);
					this.cbMachine.Items.Add(text2);
				}
				string[] array3 = new string[num];
				int num2 = 0;
				for (int i = 0; i < machineNumber.Tables[0].Rows.Count; i++)
				{
					if (array2[i] != null)
					{
						array3[num2++] = array2[i];
					}
				}
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000BA18 File Offset: 0x00009C18
		private void tbMC_TextChanged(object sender, EventArgs e)
		{
			this.tbModel.Text = "";
			this.tbRsc.Text = "";
			if (this.cbCategory.SelectedItem != null && this.cbCategory.SelectedIndex != -1 && this.cbMachine.SelectedItem != null)
			{
				for (int i = 0; i < this._MachineModelList.Count; i++)
				{
					string a = this._MachineModelList[i].sSelectMachine.ToUpper();
					if (a == this.cbMachine.SelectedItem.ToString())
					{
						this.tbModel.Text = this._MachineModelList[i].sSelectModel;
					}
				}
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000BAF0 File Offset: 0x00009CF0
		private void Report_Shown(object sender, EventArgs e)
		{
			DataSet operation = cFunction.getOperation();
			if (operation != null && operation.Tables.Count != 0)
			{
				for (int i = 0; i < operation.Tables[operation.Tables.Count - 1].Rows.Count; i++)
				{
					string str = operation.Tables[operation.Tables.Count - 1].Rows[i]["OperationCode"].ToString();
					string text = operation.Tables[operation.Tables.Count - 1].Rows[i]["OperationName"].ToString();
					text = text + "(" + str + ")";
					if (!this.cbOperation.Items.Contains(text))
					{
						this.cbOperation.Items.Add(text);
					}
				}
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000BC04 File Offset: 0x00009E04
		private void pbSubmit_Click(object sender, EventArgs e)
		{
			if (this.cbCategory.SelectedItem == null || this.cbCategory.SelectedIndex == -1)
			{
				MessageBox.Show("카테고리를 선택해주세요.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (this.cbMachine.SelectedItem == null || this.cbMachine.SelectedIndex == -1)
			{
				MessageBox.Show("장비번호를 입력해주세요.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (string.IsNullOrEmpty(this.tbModel.Text.Trim()))
			{
				MessageBox.Show("모델정보를 확인해주세요.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (this.cbOperation.SelectedItem == null || this.cbOperation.SelectedIndex == -1)
			{
				MessageBox.Show("공정을 선택해주세요.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (this.cbCustList.SelectedItem == null || this.cbCustList.SelectedIndex == -1)
			{
				MessageBox.Show("고객을 선택해주세요.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (this.cbNickName.SelectedItem == null || this.cbNickName.SelectedIndex == -1)
			{
				MessageBox.Show("닉네임을 선택해주세요.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else if (MessageBox.Show("저장하시겠습니까?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				string text = string.Empty;
				string str = string.Empty;
				DateTime now = DateTime.Now;
				string factory = cFunction.getFactory();
				if (factory != null)
				{
					if (!(factory == "K3"))
					{
						if (!(factory == "K5"))
						{
							if (!(factory == "K3_E"))
							{
								if (factory == "K5_M")
								{
									str = "K5 M";
								}
							}
							else
							{
								str = "K3 E";
							}
						}
						else
						{
							str = "K5";
						}
					}
					else
					{
						str = "K3";
					}
				}
				text = str + "_" + now.ToString("yyyyMMdd");
				int reportCount = cFunction.getReportCount(text);
				if (reportCount == 0)
				{
					MessageBox.Show("ERROR,WRONG REPORT COUNT", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					text = string.Concat(new string[]
					{
						text,
						"_",
						this.cbMachine.SelectedItem.ToString(),
						"_",
						this.tbModel.Text.Trim(),
						"_",
						this.tbTeam.Text.Trim(),
						"_",
						string.Format("{0:D3}", reportCount)
					});
					if (this._lFileList.Count != 0)
					{
						this.attachZip(text, now);
					}
					ReportInfo reportInfo = new ReportInfo(text);
					reportInfo.Category = this.cbCategory.SelectedItem.ToString();
					reportInfo.Equipment = this.cbMachine.SelectedItem.ToString();
					reportInfo.Model = this.tbModel.Text.Trim();
					reportInfo.RscDec = this.tbRsc.Text.Trim();
					reportInfo.Operation = this.cbOperation.SelectedItem.ToString();
					reportInfo.NickName = this.cbNickName.SelectedItem.ToString();
					reportInfo.CustName = this.cbCustList.SelectedItem.ToString();
					reportInfo.content = this.rbContent1.Text;
					reportInfo.binary = this.MakeRFTFile(this.rbContent1);
					if (reportInfo.binary == null)
					{
						MessageBox.Show("ERROR,BUFFER NULL!!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						foreach (cFileList cFileList in this._lFileList)
						{
							reportInfo.FileList = reportInfo.FileList + cFileList.sFilePath + ";";
						}
						string empty = string.Empty;
						if (cFunction.sendReport(this._cimitarUser._id, this.tbName.Text.Trim(), this.tbTeam.Text.Trim(), reportInfo, out empty, false))
						{
							MessageBox.Show("저장완료.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							this.rbContent1.Text = this._sContent1Init;
							this.tbModel.Text = string.Empty;
							this.tbRsc.Text = string.Empty;
							this.cbCategory.SelectedIndex = 0;
							this.cbCustList.SelectedIndex = -1;
							this.cbNickName.SelectedIndex = -1;
							this.cbOperation.SelectedIndex = -1;
							this.cbMachine.SelectedIndex = -1;
							this.InitGrid(false);
							this._lFileList.Clear();
						}
						else
						{
							MessageBox.Show(empty, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
				}
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000C174 File Offset: 0x0000A374
		private void pbClear_MouseLeave(object sender, EventArgs e)
		{
			if (((PictureBox)sender).Equals(this.pbClear))
			{
				this.pbClear.Image = Resources.clear;
			}
			else if (((PictureBox)sender).Equals(this.pbSubmit))
			{
				this.pbSubmit.Image = Resources.submit;
			}
			else if (((PictureBox)sender).Equals(this.pbLogin))
			{
				this.pbLogin.Image = Resources.login;
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000C208 File Offset: 0x0000A408
		private void pbClear_MouseEnter(object sender, EventArgs e)
		{
			if (((PictureBox)sender).Equals(this.pbClear))
			{
				this.pbClear.Image = Resources.clearn_down;
			}
			else if (((PictureBox)sender).Equals(this.pbSubmit))
			{
				this.pbSubmit.Image = Resources.submit_down;
			}
			else if (((PictureBox)sender).Equals(this.pbLogin))
			{
				this.pbLogin.Image = Resources.login_down;
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000C29B File Offset: 0x0000A49B
		private void pbSubmit_MouseClick(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0000C2A0 File Offset: 0x0000A4A0
		private void pbClear_Click(object sender, EventArgs e)
		{
			this.rbContent1.Text = this._sContent1Init;
			this.cbCategory.SelectedIndex = -1;
			this.tbRsc.Text = string.Empty;
			this.tbModel.Text = string.Empty;
			this.cbCustList.SelectedIndex = -1;
			this.cbNickName.SelectedIndex = -1;
			this.cbOperation.SelectedIndex = -1;
			this.cbMachine.SelectedIndex = -1;
			this.cbMachine.Items.Clear();
			this._lFileList.Clear();
			this._MachineModelList.Clear();
			this.InitGrid(false);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000C354 File Offset: 0x0000A554
		private void getUserData()
		{
			string requestUriString = "http://10.101.14.181:8080/SmartConsoleWebService/user_info/getUserPPS/" + this._cimitarUser._id;
			WebRequest webRequest = WebRequest.Create(requestUriString);
			webRequest.Credentials = CredentialCache.DefaultCredentials;
			WebResponse response = webRequest.GetResponse();
			Console.WriteLine(((HttpWebResponse)response).StatusDescription);
			Stream responseStream = response.GetResponseStream();
			Encoding utf = Encoding.UTF8;
			StreamReader streamReader = new StreamReader(responseStream, utf);
			string text = streamReader.ReadToEnd();
			streamReader.Close();
			response.Close();
			if (text.ToUpper().IndexOf("NOT EXIST") == -1)
			{
				string[] array = text.Split(new char[]
				{
					';'
				});
				if (array.Length > 0 && array.Length == 3)
				{
					this.tbName.Text = array[0];
					this.tbTeam.Text = array[1];
					this._sSender = array[2];
				}
				else
				{
					MessageBox.Show("Can not recive Data from eMES (" + this._cimitarUser._id + ")\r\nPlease contact to TFA Team");
				}
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x0000C47C File Offset: 0x0000A67C
		private byte[] MakeRFTFile(RichTextBox rb)
		{
			byte[] result;
			if (rb == null)
			{
				result = null;
			}
			else
			{
				string path = rb.Equals(this.rbContent1) ? "C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload\\content\\content1.rtf" : "C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload\\content\\content2.rtf";
				string text = rb.Equals(this.rbContent1) ? "C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload\\content1.zip" : "C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload\\content2.zip";
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				if (Directory.Exists("C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload\\content"))
				{
					Directory.Delete("C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload\\content", true);
					Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload\\content");
				}
				else
				{
					Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload\\content");
				}
				rb.SaveFile(path);
				ZipFile.CreateFromDirectory("C:\\Temp\\CimitarAdmin\\MaintMFG\\Upload\\content", text);
				if (File.Exists(text))
				{
					FileStream fileStream = new FileStream(text, FileMode.Open);
					byte[] array = new byte[fileStream.Length];
					fileStream.Read(array, 0, array.Length);
					fileStream.Close();
					result = array;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000C584 File Offset: 0x0000A784
		private void attachZip(string title, DateTime now)
		{
			string str = title.Replace("/", "_").Trim() + ".zip";
			string text = string.Concat(new string[]
			{
				"\\\\k3tpasqlsvc\\Manufacture_Maintenance\\K5_M_Mfg\\\\",
				now.Year.ToString(),
				"\\",
				now.Month.ToString(),
				"\\",
				now.Day.ToString()
			});
			string destinationArchiveFileName = text + "\\" + str;
			if (!Directory.Exists("\\\\k3tpasqlsvc\\Manufacture_Maintenance\\K5_M_Mfg\\"))
			{
				Directory.CreateDirectory("\\\\k3tpasqlsvc\\Manufacture_Maintenance\\K5_M_Mfg\\");
			}
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			if (Directory.Exists("C:\\Temp\\CimitarAdmin\\MaintMFG\\Uploadattach\\"))
			{
				Directory.Delete("C:\\Temp\\CimitarAdmin\\MaintMFG\\Uploadattach\\", true);
			}
			Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\MaintMFG\\Uploadattach\\");
			foreach (cFileList cFileList in this._lFileList)
			{
				if (File.Exists(cFileList.sFilePath))
				{
					File.Copy(cFileList.sFilePath, "C:\\Temp\\CimitarAdmin\\MaintMFG\\Uploadattach\\" + cFileList.sFileName, true);
				}
			}
			ZipFile.CreateFromDirectory("C:\\Temp\\CimitarAdmin\\MaintMFG\\Uploadattach\\", destinationArchiveFileName);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000C70C File Offset: 0x0000A90C
		private void cbMachine_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.tbModel.Text = "";
			this.tbRsc.Text = "";
			if (this.cbCategory.SelectedItem != null && this.cbCategory.SelectedIndex != -1 && this.cbMachine.SelectedItem != null)
			{
				for (int i = 0; i < this._MachineModelList.Count; i++)
				{
					string a = this._MachineModelList[i].sSelectMachine.ToUpper();
					if (a == this.cbMachine.SelectedItem.ToString())
					{
						this.tbModel.Text = this._MachineModelList[i].sSelectModel;
						this.tbRsc.Text = this._MachineModelList[i].sSelectRsc;
						break;
					}
				}
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000C808 File Offset: 0x0000AA08
		private void pbLogin_Click(object sender, EventArgs e)
		{
			this.pbLogin.Image = Resources.login;
			Login login = new Login();
			if (login.ShowDialog() == DialogResult.OK)
			{
				this._cimitarUser._id = login.id;
				this.getUserData();
			}
			login.Dispose();
		}

		// Token: 0x04000086 RID: 134
		private FactorySettings _factorySettings;

		// Token: 0x04000087 RID: 135
		private new CIMitarAccount _cimitarUser;

		// Token: 0x04000088 RID: 136
		private string _sContent1Init = "※고장 내역 / 정비 내역을 자세히 기입해주세요.";

		// Token: 0x04000089 RID: 137
		private string _sContent2Init = "※조치사항을 자세히 기입해주세요.";

		// Token: 0x0400008A RID: 138
		private long _lTotalByte = 0L;

		// Token: 0x0400008B RID: 139
		private readonly long _lMaximumByte = 10485760L;

		// Token: 0x0400008C RID: 140
		private List<cFileList> _lFileList = new List<cFileList>();

		// Token: 0x0400008D RID: 141
		private List<MachineInfo> _MachineModelList = new List<MachineInfo>();

		// Token: 0x0400008E RID: 142
		private string _sSender = string.Empty;
	}
}
