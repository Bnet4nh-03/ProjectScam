using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x0200003A RID: 58
	public partial class AnsAddSocketComment : Form
	{
		// Token: 0x06000292 RID: 658 RVA: 0x00047ABF File Offset: 0x00045CBF
		public AnsAddSocketComment()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00047ACD File Offset: 0x00045CCD
		public AnsAddSocketComment(string strNo)
		{
			this._strNo = strNo;
			this.InitializeComponent();
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00047AE4 File Offset: 0x00045CE4
		private void SetCommentHistory()
		{
			try
			{
				new DataSet();
				string sQuery = string.Concat(new string[]
				{
					"EXEC [CIMitar_Factory].[dbo].[USP_Admin_AnsSocketCommentHistory] @no = '",
					this._strNo,
					"' , @completedcomment = N'",
					this._strCompletedComment,
					"' , @pincount = N'",
					this._strPinCount,
					"' , @completedname = N'",
					this._strCompletedName,
					"'"
				});
				this.queryMgr.queryCall(sQuery);
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00047B74 File Offset: 0x00045D74
		private void AnsAddSocketComment_Load(object sender, EventArgs e)
		{
			this.queryMgr = new QueryMgr(this._factorySetting);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00047B88 File Offset: 0x00045D88
		private void cmdModify_Click(object sender, EventArgs e)
		{
			try
			{
				string text = this.tb_pincount.Text.ToString().Trim();
				int num;
				bool flag = int.TryParse(text, out num);
				if (flag)
				{
					this._strPinCount = text;
					this._strCompletedName = this.tb_name.Text.ToString().Trim();
					this._strCompletedComment = this.tb_comment.Text.ToString().Trim();
					if (this._strCompletedName != "" && this._strCompletedComment != "" && this._strPinCount != "")
					{
						this.SetCommentHistory();
						MessageBox.Show("Completed update.", "Success");
					}
					else
					{
						MessageBox.Show("Please fill in the item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("PinCount is only numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00047C84 File Offset: 0x00045E84
		private void cmdModify_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdModify.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00047CA1 File Offset: 0x00045EA1
		private void cmdModify_MouseLeave(object sender, EventArgs e)
		{
			this.cmdModify.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00047CBE File Offset: 0x00045EBE
		private void cmdModify_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdModify.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00047CDB File Offset: 0x00045EDB
		private void cmdModify_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00047CE8 File Offset: 0x00045EE8
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00047CF0 File Offset: 0x00045EF0
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00047D0D File Offset: 0x00045F0D
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00047D2A File Offset: 0x00045F2A
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00047D47 File Offset: 0x00045F47
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x04000499 RID: 1177
		private string _strNo;

		// Token: 0x0400049A RID: 1178
		private string _strCompletedComment;

		// Token: 0x0400049B RID: 1179
		private string _strPinCount;

		// Token: 0x0400049C RID: 1180
		private string _strCompletedName;

		// Token: 0x0400049D RID: 1181
		public FactorySettings _factorySetting;

		// Token: 0x0400049E RID: 1182
		public CIMitarAccount _cimitarUser;

		// Token: 0x0400049F RID: 1183
		private QueryMgr queryMgr;
	}
}
