using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.ManufactureHistory.GrobalConstMFG;
using Amkor.CADModules.ManufactureHistory.Properties;
using ATDFW.Classes.Acount;

namespace Amkor.CADModules.ManufactureHistory.SubForm
{
	// Token: 0x02000013 RID: 19
	public partial class Viewer : Form
	{
		// Token: 0x0600007E RID: 126 RVA: 0x0000F018 File Offset: 0x0000D218
		public Viewer(string title, CIMitarAccount cimitarUser)
		{
			this._cimitarUser = cimitarUser;
			this.InitializeComponent();
			this.initData(title);
			try
			{
				if (Directory.Exists("C:\\Temp\\CimitarAdmin\\MaintMFG\\Downloadattach\\"))
				{
					Directory.Delete("C:\\Temp\\CimitarAdmin\\MaintMFG\\Downloadattach\\", true);
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000F09C File Offset: 0x0000D29C
		public void initData(string title)
		{
			DataSet report = cFunction.getReport(title);
			if (report != null & report.Tables.Count > 0)
			{
				this._reportInfo = new ReportInfo(title);
				this._reportInfo.Category = report.Tables[report.Tables.Count - 1].Rows[report.Tables[report.Tables.Count - 1].Rows.Count - 1]["Category"].ToString();
				this._reportInfo.Equipment = report.Tables[report.Tables.Count - 1].Rows[report.Tables[report.Tables.Count - 1].Rows.Count - 1]["Machine"].ToString();
				this._reportInfo.RscDec = report.Tables[report.Tables.Count - 1].Rows[report.Tables[report.Tables.Count - 1].Rows.Count - 1]["Type"].ToString();
				this._reportInfo.Model = report.Tables[report.Tables.Count - 1].Rows[report.Tables[report.Tables.Count - 1].Rows.Count - 1]["Model"].ToString();
				this._reportInfo.Operation = report.Tables[report.Tables.Count - 1].Rows[report.Tables[report.Tables.Count - 1].Rows.Count - 1]["Operation"].ToString();
				this._reportInfo.CustName = report.Tables[report.Tables.Count - 1].Rows[report.Tables[report.Tables.Count - 1].Rows.Count - 1]["CustName"].ToString();
				this._reportInfo.NickName = report.Tables[report.Tables.Count - 1].Rows[report.Tables[report.Tables.Count - 1].Rows.Count - 1]["NickName"].ToString();
				this._reportInfo.Shift = report.Tables[report.Tables.Count - 1].Rows[report.Tables[report.Tables.Count - 1].Rows.Count - 1]["Shift"].ToString();
				this._reportInfo.dateTime = Convert.ToDateTime(report.Tables[report.Tables.Count - 1].Rows[report.Tables[report.Tables.Count - 1].Rows.Count - 1]["datetime"].ToString());
				this._reportInfo.binary = Convert.FromBase64String(report.Tables[report.Tables.Count - 1].Rows[report.Tables[report.Tables.Count - 1].Rows.Count - 1]["binary1"].ToString());
				this._reportInfo.binary2 = Convert.FromBase64String(report.Tables[report.Tables.Count - 1].Rows[report.Tables[report.Tables.Count - 1].Rows.Count - 1]["binary2"].ToString());
				this._reportInfo.FileList = report.Tables[report.Tables.Count - 1].Rows[report.Tables[report.Tables.Count - 1].Rows.Count - 1]["Files"].ToString();
				string name = report.Tables[report.Tables.Count - 1].Rows[report.Tables[report.Tables.Count - 1].Rows.Count - 1]["Name"].ToString();
				string team = report.Tables[report.Tables.Count - 1].Rows[report.Tables[report.Tables.Count - 1].Rows.Count - 1]["Team"].ToString();
				this.Display(name, team);
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000F624 File Offset: 0x0000D824
		private void Display(string name, string team)
		{
			this.tbName.Text = name;
			this.tbTeam.Text = team;
			this.tbCategory.Text = this._reportInfo.Category;
			this.tbMC.Text = this._reportInfo.Equipment;
			this.tbModel.Text = this._reportInfo.Model;
			this.tbNickname.Text = this._reportInfo.NickName;
			this.tbCustName.Text = this._reportInfo.CustName;
			this.tbOperation.Text = this._reportInfo.Operation;
			this.tbShift.Text = this._reportInfo.Shift;
			this.ContentZipFile();
			if (!string.IsNullOrEmpty(this._reportInfo.FileList.Trim()))
			{
				string[] array = this._reportInfo.FileList.Split(new char[]
				{
					';'
				});
				if (array.Length > 0)
				{
					this.dgAttachmentList.RowCount = array.Length - 1;
					for (int i = 0; i < array.Length - 1; i++)
					{
						if (!string.IsNullOrEmpty(array[i]))
						{
							this.dgAttachmentList.Rows[i].Cells[0].Value = array[i].Substring(array[i].LastIndexOf("\\") + 1, array[i].Length - array[i].LastIndexOf("\\") - 1);
						}
					}
					this.dgAttachmentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
				}
			}
			else
			{
				this.pnAttachment.Visible = false;
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000F7E7 File Offset: 0x0000D9E7
		private void InitGrid()
		{
			this.dgAttachmentList.Rows.Clear();
			this.dgAttachmentList.ColumnCount = 1;
			this.dgAttachmentList.RowCount = 1;
			this.dgAttachmentList.ColumnHeadersVisible = false;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000F824 File Offset: 0x0000DA24
		private void ContentZipFile()
		{
			if (Directory.Exists("C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content"))
			{
				Directory.Delete("C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content", true);
			}
			Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content");
			if (this._reportInfo != null && this._reportInfo.binary != null && this._reportInfo.binary.Length > 0)
			{
				FileStream fileStream = new FileStream("C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content\\content1.zip", FileMode.Create);
				fileStream.Write(this._reportInfo.binary, 0, this._reportInfo.binary.Length);
				if (fileStream != null)
				{
					fileStream.Close();
				}
				if (File.Exists("C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content\\content1.zip"))
				{
					ZipFile.ExtractToDirectory("C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content\\content1.zip", "C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content");
					if (File.Exists("C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content\\content1.rtf"))
					{
						this.rbContent1.Rtf = File.ReadAllText("C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content\\content1.rtf");
					}
					else
					{
						this.rbContent1.Rtf = string.Empty;
					}
				}
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000F92F File Offset: 0x0000DB2F
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000F940 File Offset: 0x0000DB40
		private void dgAttachmentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (!this._bLockEvent)
			{
				this._bLockEvent = true;
				if (e.ColumnIndex == 0 && e.RowIndex >= 0)
				{
					if (this.dgAttachmentList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && this.dgAttachmentList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim().Length != 0)
					{
						try
						{
							if (this._barPrograss == null)
							{
								this._barPrograss = new BarPrograss();
								this._barPrograss.progress_labelheader_set("");
								this._barPrograss.setMax(100);
								this._barPrograss.setValue(1);
								this._thread = new Thread(new ThreadStart(this.BarPrograssView));
								this._thread.Start();
							}
							string text = string.Concat(new string[]
							{
								"\\\\k3tpasqlsvc\\Manufacture_Maintenance\\K5_M_Mfg\\\\",
								this._reportInfo.dateTime.Year.ToString(),
								"\\",
								this._reportInfo.dateTime.Month.ToString(),
								"\\",
								this._reportInfo.dateTime.Day.ToString(),
								"\\",
								this._reportInfo.Title.Replace("/", "_").Trim(),
								".zip"
							});
							string text2 = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Downloadattach\\\\" + this._reportInfo.Title.Replace("/", "_").Trim() + ".zip";
							if (!File.Exists(text2))
							{
								if (!Directory.Exists("C:\\Temp\\CimitarAdmin\\MaintMFG\\Downloadattach\\"))
								{
									Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\MaintMFG\\Downloadattach\\");
								}
								if (File.Exists(text))
								{
									File.Copy(text, text2, true);
								}
								else
								{
									MessageBox.Show("Not Exist Attachment File!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
							}
							if (File.Exists(text2))
							{
								string text3 = "C:\\Temp\\CimitarAdmin\\MaintMFG\\Downloadattach\\\\" + this.dgAttachmentList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();
								if (!Directory.Exists("C:\\Temp\\CimitarAdmin\\MaintMFG\\Downloadattach\\"))
								{
									Directory.CreateDirectory("C:\\Temp\\CimitarAdmin\\MaintMFG\\Downloadattach\\");
								}
								if (!File.Exists(text3))
								{
									ZipFile.ExtractToDirectory(text2, "C:\\Temp\\CimitarAdmin\\MaintMFG\\Downloadattach\\");
									File.Delete(text2);
								}
								Process.Start(text3);
							}
						}
						catch (Exception ex)
						{
							this._bLockEvent = false;
							MessageBox.Show(ex.Message.ToString(), "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
						if (this._barPrograss != null)
						{
							this._barPrograss.setMax(100);
							this._barPrograss.setValue(100);
							Thread.Sleep(10);
							if (this._barPrograss != null)
							{
								this._barPrograss._ischeck = true;
							}
							this._barPrograss = null;
						}
					}
				}
				this._bLockEvent = false;
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0000FCF0 File Offset: 0x0000DEF0
		private void pbEdit_Click(object sender, EventArgs e)
		{
			if (Convert.ToInt32(this.pbEdit.Tag) == 0)
			{
				this.getUserData();
				this.pbEdit.Image = Resources.save;
				this.pbEdit.Tag = 1;
				this.rbContent1.ReadOnly = false;
				this.rbContent1.BackColor = Color.White;
			}
			else
			{
				DialogResult dialogResult = MessageBox.Show("변경사항을 저장하시겠습니까?", "Notification", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Yes)
				{
					this.pbEdit.Tag = 0;
					string empty = string.Empty;
					this._reportInfo.content = this.rbContent1.Text;
					this._reportInfo.binary = this.MakeRFTFile(this.rbContent1);
					if (cFunction.sendReport(this._cimitarUser._id, this._reportInfo.editerName, this._reportInfo.editerDepart, this._reportInfo, out empty, true))
					{
						this.rbContent1.BackColor = Color.Gainsboro;
						this.rbContent1.ReadOnly = true;
						this.pbEdit.Image = Resources.edit;
						MessageBox.Show("저장완료.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show(empty, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else if (dialogResult == DialogResult.No)
				{
					this.pbEdit.Tag = 1;
					this.pbEdit.Image = Resources.save;
					this.rbContent1.ReadOnly = true;
					this.rbContent1.BackColor = Color.Gainsboro;
					this.rbContent1.Text = this._reportInfo.content;
					if (File.Exists("C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content\\content1.rtf"))
					{
						this.rbContent1.Rtf = File.ReadAllText("C:\\Temp\\CimitarAdmin\\MaintMFG\\Download\\content\\content1.rtf");
					}
					else
					{
						this.rbContent1.Rtf = string.Empty;
					}
				}
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000FF0C File Offset: 0x0000E10C
		private void pbEdit_MouseLeave(object sender, EventArgs e)
		{
			if (((PictureBox)sender).Equals(this.pbEdit))
			{
				if (Convert.ToInt32(this.pbEdit.Tag) == 1)
				{
					this.pbEdit.Image = Resources.save;
				}
				else
				{
					this.pbEdit.Image = Resources.edit;
				}
			}
			else if (((PictureBox)sender).Equals(this.pbDelete))
			{
				this.pbDelete.Image = Resources.delete;
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000FFA4 File Offset: 0x0000E1A4
		private void pbEdit_MouseEnter(object sender, EventArgs e)
		{
			if (((PictureBox)sender).Equals(this.pbEdit))
			{
				if (Convert.ToInt32(this.pbEdit.Tag) == 1)
				{
					this.pbEdit.Image = Resources.save_down;
				}
				else
				{
					this.pbEdit.Image = Resources.edit_down;
				}
			}
			else if (((PictureBox)sender).Equals(this.pbDelete))
			{
				this.pbDelete.Image = Resources.delete_down;
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0001003C File Offset: 0x0000E23C
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
					this._reportInfo.editerName = array[0];
					this._reportInfo.editerDepart = array[1];
				}
				else
				{
					MessageBox.Show("Can not recive Data from eMES (" + this._cimitarUser._id + ")\r\nPlease contact to TFA Team");
				}
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00010154 File Offset: 0x0000E354
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

		// Token: 0x0600008A RID: 138 RVA: 0x0001025C File Offset: 0x0000E45C
		private void pbDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("삭제하시겠습니까? 삭제 후 복구는 불가능합니다.", "Notification", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				if (cFunction.setDeleteReport(this._reportInfo.Title))
				{
					string str = string.Concat(new string[]
					{
						"\\\\k3tpasqlsvc\\Manufacture_Maintenance\\K5_M_Mfg\\\\",
						this._reportInfo.dateTime.Year.ToString(),
						"\\",
						this._reportInfo.dateTime.Month.ToString(),
						"\\",
						this._reportInfo.dateTime.Day.ToString()
					});
					string path = str + "\\" + this._reportInfo.Title + ".zip";
					if (File.Exists(path))
					{
						File.Delete(path);
					}
					base.DialogResult = DialogResult.OK;
					base.Close();
				}
				else
				{
					MessageBox.Show("삭제 진행을 실패했습니다. TFA팀에 문의하세요.");
				}
			}
		}

		// Token: 0x040000C8 RID: 200
		private ReportInfo _reportInfo;

		// Token: 0x040000C9 RID: 201
		private bool _bLockEvent = false;

		// Token: 0x040000CA RID: 202
		private BarPrograss _barPrograss = null;

		// Token: 0x040000CB RID: 203
		private Thread _thread = null;

		// Token: 0x040000CC RID: 204
		private CIMitarAccount _cimitarUser;
	}
}
