using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Class;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000038 RID: 56
	public partial class AddSocketComment : Form
	{
		// Token: 0x06000268 RID: 616 RVA: 0x000454E8 File Offset: 0x000436E8
		public AddSocketComment()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00045501 File Offset: 0x00043701
		public AddSocketComment(string strSearchSocketId)
		{
			this.strSearchSocketId = strSearchSocketId;
			this.bResult = false;
			this.InitializeComponent();
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00045528 File Offset: 0x00043728
		private void AddSocketComment_Load(object sender, EventArgs e)
		{
			this.queryMgr = new QueryMgr(this._factorySetting);
			this.cInsertInfo = new CInsertInfo();
			this.GetTester();
			this.GetComment();
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00045554 File Offset: 0x00043754
		private DataSet getTypeDefinitionList(string sTypeName, ComboBox comboBox)
		{
			DataSet dataSet = new DataSet();
			try
			{
				comboBox.Items.Clear();
				string sQuery = "EXEC [CIMitar_Factory].[dbo].[USP_GetTypeDefList] @typename = '" + sTypeName + "'";
				dataSet = this.queryMgr.queryCall(sQuery);
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					comboBox.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			return dataSet;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00045604 File Offset: 0x00043804
		private void GetTester()
		{
			this.getTypeDefinitionList("CarrierTester", this.cmbTester);
			if (this.cmbTester.Items.Count > 0)
			{
				this.cmbTester.SelectedIndex = 0;
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00045637 File Offset: 0x00043837
		private void GetComment()
		{
			this.getTypeDefinitionList("SocketMemo", this.cmb_comment);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0004564C File Offset: 0x0004384C
		private string SetInsertComment()
		{
			string result = "-1";
			try
			{
				DataSet dataSet = new DataSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetSocketCommentHistory] @socketid = '",
					this.strSearchSocketId,
					"', @site = '",
					this.cInsertInfo.strSite,
					"', @testername = '",
					this.cmbTester.Text.Trim(),
					"', @requestcomment = N'",
					this.cInsertInfo.strComment,
					"', @requestname = N'",
					this.cInsertInfo.strName,
					"'"
				});
				dataSet = this.queryMgr.queryCall(sQuery);
				if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						result = dataSet.Tables[0].Rows[i]["result"].ToString();
					}
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00045798 File Offset: 0x00043998
		private void cmdModify_Click(object sender, EventArgs e)
		{
			string text = this.tb_site.Text.ToString().Trim();
			int num;
			bool flag = int.TryParse(text, out num);
			if (flag)
			{
				this.cInsertInfo.strSite = text;
				this.cInsertInfo.strName = this.tb_name.Text.ToString().Trim();
				this.cInsertInfo.strComment = this.cmb_comment.Text.ToString().Trim();
				if (this.cInsertInfo.CheckInfo() != 0)
				{
					this.bResult = false;
					MessageBox.Show("Please fill in the item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				string a = this.SetInsertComment();
				if (a == "0")
				{
					this.bResult = true;
					MessageBox.Show("Update Success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				if (a == "-1")
				{
					this.bResult = false;
					MessageBox.Show("An unprocessed comment already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			else
			{
				this.bResult = false;
				MessageBox.Show("Sites are only numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000270 RID: 624 RVA: 0x000458AF File Offset: 0x00043AAF
		private void cmdModify_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdModify.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x000458CC File Offset: 0x00043ACC
		private void cmdModify_MouseLeave(object sender, EventArgs e)
		{
			this.cmdModify.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x000458E9 File Offset: 0x00043AE9
		private void cmdModify_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdModify.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00045906 File Offset: 0x00043B06
		private void cmdModify_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00045913 File Offset: 0x00043B13
		private void AddSocketComment_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (this.bResult)
			{
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				base.DialogResult = DialogResult.Cancel;
			}
			base.Close();
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00045933 File Offset: 0x00043B33
		private void cmdClose_Click(object sender, EventArgs e)
		{
			if (this.bResult)
			{
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				base.DialogResult = DialogResult.Cancel;
			}
			base.Close();
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00045953 File Offset: 0x00043B53
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00045970 File Offset: 0x00043B70
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0004598D File Offset: 0x00043B8D
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x000459AA File Offset: 0x00043BAA
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x000459B7 File Offset: 0x00043BB7
		private void tb_comment_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ',')
			{
				e.Handled = true;
				MessageBox.Show("You can not type a comma.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600027B RID: 635 RVA: 0x000459DD File Offset: 0x00043BDD
		private void cmb_comment_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ',')
			{
				e.Handled = true;
				MessageBox.Show("You can not type a comma.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00045A03 File Offset: 0x00043C03
		private void tb_site_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ',')
			{
				e.Handled = true;
				MessageBox.Show("You can not type a comma.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00045A29 File Offset: 0x00043C29
		private void tb_name_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ',')
			{
				e.Handled = true;
				MessageBox.Show("You can not type a comma.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0400045C RID: 1116
		public FactorySettings _factorySetting;

		// Token: 0x0400045D RID: 1117
		public CIMitarAccount _cimitarUser;

		// Token: 0x0400045E RID: 1118
		private QueryMgr queryMgr;

		// Token: 0x0400045F RID: 1119
		private CInsertInfo cInsertInfo;

		// Token: 0x04000460 RID: 1120
		private string strSearchSocketId = "";

		// Token: 0x04000461 RID: 1121
		private bool bResult;
	}
}
