using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Class;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x0200004F RID: 79
	public partial class AddSWHistory : Form
	{
		// Token: 0x060003A1 RID: 929 RVA: 0x0005695C File Offset: 0x00054B5C
		public AddSWHistory()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x00056996 File Offset: 0x00054B96
		// (set) Token: 0x060003A3 RID: 931 RVA: 0x000569A3 File Offset: 0x00054BA3
		public string Caption
		{
			get
			{
				return this.lblTop.Text;
			}
			set
			{
				this.lblTop.Text = value;
			}
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x000569B1 File Offset: 0x00054BB1
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x000569C0 File Offset: 0x00054BC0
		private void AddSWHistory_Load(object sender, EventArgs e)
		{
			this.queryMgr = new QueryMgr(this._factorySetting);
			if (this.sType == "Modify")
			{
				this.txtSWversion.Text = this.SW.Version;
				this.dtpApprovalDate.Text = this.SW.Approvaldate;
				this.dtpDoneDate.Text = this.SW.Donedate;
				this.txtComment.Text = this.SW.Comment;
				this.txtAttachFile.Text = this.SW.Filename;
			}
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00056A60 File Offset: 0x00054C60
		private void cmdUploadFile_Click(object sender, EventArgs e)
		{
			this.openFileDialog.Filter = "(*.*)|*.*";
			this.openFileDialog.FilterIndex = 1;
			this.openFileDialog.FileName = string.Empty;
			DialogResult dialogResult = this.openFileDialog.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				this.txtAttachFile.Text = this.openFileDialog.SafeFileName;
				this.bAttachFileFlag = true;
			}
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00056AC8 File Offset: 0x00054CC8
		private void cmdApply_Click(object sender, EventArgs e)
		{
			if (this.txtSWversion.Text == string.Empty)
			{
				MessageBox.Show("Input S/W Version please", "CIMitarAdmin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (this.bAttachFileFlag && this.txtAttachFile.Text != string.Empty && !this.uploadfile())
			{
				return;
			}
			this.SW.Version = this.txtSWversion.Text;
			this.SW.Approvaldate = this.dtpApprovalDate.Text;
			this.SW.Donedate = this.dtpDoneDate.Text;
			this.SW.Comment = this.txtComment.Text;
			this.SW.Filename = this.txtAttachFile.Text;
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_ApplySWVersion]  @id = '",
				this.SW.id,
				"',  @version = '",
				this.SW.Version,
				"', @approvaldate = '",
				this.SW.Approvaldate,
				"', @donedate = '",
				this.SW.Donedate,
				"', @comment = N'",
				this.SW.Comment,
				"', @filename = '",
				this.SW.Filename,
				"', @userid = '",
				this._cimitarUser._id,
				"', @type = '",
				this.sType,
				"'"
			});
			DataSet dataSet = this.queryMgr.queryCall(sQuery);
			if (dataSet == null || dataSet.Tables.Count <= 0 || dataSet.Tables[0].Rows.Count <= 0)
			{
				MessageBox.Show("Upload Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			if (dataSet.Tables[0].Rows[0]["ReturnCode"].ToString() == "-1")
			{
				MessageBox.Show("Upload Fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			MessageBox.Show("Upload Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00056D18 File Offset: 0x00054F18
		private bool uploadfile()
		{
			string text = "\\\\10.121.1.91\\TitanSW";
			string safeFileName = this.openFileDialog.SafeFileName;
			string fileName = this.openFileDialog.FileName;
			string text2 = string.Empty;
			bool result;
			try
			{
				if (Directory.Exists(text))
				{
					string str = string.Empty;
					if (this.sType == "Create")
					{
						string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_Admin_GetSWVersion]  @type = 'ID'";
						DataSet dataSet = this.queryMgr.queryCall(sQuery);
						if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
						{
							str = dataSet.Tables[0].Rows[0][0].ToString();
						}
					}
					else
					{
						str = this.SW.id;
					}
					text = text + "\\" + str;
					if (!Directory.Exists(text))
					{
						Directory.CreateDirectory(text);
					}
					text2 = text + "\\" + safeFileName;
					if (File.Exists(text2))
					{
						DialogResult dialogResult = MessageBox.Show("duplicate file name. Overwrite file?", "Fail", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (dialogResult == DialogResult.Yes)
						{
							File.Delete(text2);
							File.Copy(fileName, text2);
							result = true;
						}
						else
						{
							result = false;
						}
					}
					else
					{
						File.Copy(fileName, text2);
						result = true;
					}
				}
				else
				{
					MessageBox.Show("directory is not exist : " + text, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					result = false;
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
				MessageBox.Show("File upload fail", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				result = false;
			}
			return result;
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00056EB8 File Offset: 0x000550B8
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00056EC0 File Offset: 0x000550C0
		private void cmdApply_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00056EDD File Offset: 0x000550DD
		private void cmdApply_MouseLeave(object sender, EventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00056EFA File Offset: 0x000550FA
		private void cmdApply_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00056F17 File Offset: 0x00055117
		private void cmdApply_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00056F24 File Offset: 0x00055124
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x00056F41 File Offset: 0x00055141
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x00056F5E File Offset: 0x0005515E
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x00056F7B File Offset: 0x0005517B
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x00056F88 File Offset: 0x00055188
		private void cmdUploadFile_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdUploadFile.Image = Resources.OpenTable;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00056FA5 File Offset: 0x000551A5
		private void cmdUploadFile_MouseLeave(object sender, EventArgs e)
		{
			this.cmdUploadFile.Image = Resources.OpenTable;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x00056FC2 File Offset: 0x000551C2
		private void cmdUploadFile_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdUploadFile.Image = Resources.OpenTable_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00056FDF File Offset: 0x000551DF
		private void cmdUploadFile_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x040005DC RID: 1500
		public FactorySettings _factorySetting;

		// Token: 0x040005DD RID: 1501
		public CIMitarAccount _cimitarUser;

		// Token: 0x040005DE RID: 1502
		private QueryMgr queryMgr;

		// Token: 0x040005DF RID: 1503
		private Thread _thread;

		// Token: 0x040005E0 RID: 1504
		private BarPrograss _barPrograss;

		// Token: 0x040005E1 RID: 1505
		private bool bAttachFileFlag;

		// Token: 0x040005E2 RID: 1506
		public SortedList slResult = new SortedList();

		// Token: 0x040005E3 RID: 1507
		public string sType = string.Empty;

		// Token: 0x040005E4 RID: 1508
		public SWVersion SW = new SWVersion();

		// Token: 0x040005E5 RID: 1509
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x040005E6 RID: 1510
		private ContextMenu menuGrid;
	}
}
