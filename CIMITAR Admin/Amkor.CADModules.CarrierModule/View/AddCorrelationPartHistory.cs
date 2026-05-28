using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.CarrierModule.Class;
using Amkor.CADModules.CarrierModule.Properties;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x02000039 RID: 57
	public partial class AddCorrelationPartHistory : Form
	{
		// Token: 0x06000280 RID: 640 RVA: 0x000466B1 File Offset: 0x000448B1
		public AddCorrelationPartHistory()
		{
			this.InitializeComponent();
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000281 RID: 641 RVA: 0x000466EB File Offset: 0x000448EB
		// (set) Token: 0x06000282 RID: 642 RVA: 0x000466F8 File Offset: 0x000448F8
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

		// Token: 0x06000283 RID: 643 RVA: 0x00046706 File Offset: 0x00044906
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00046714 File Offset: 0x00044914
		private void AddSWHistory_Load(object sender, EventArgs e)
		{
			this.queryMgr = new QueryMgr(this._factorySetting);
			this.txtBarcode.Text = this.corrHistory.Barcode;
			this.txtProduct.Text = this.corrHistory.Product;
			this.txtProdRemark.Text = this.corrHistory.ProdRemark;
			this.txtConfirmUser.Text = this._cimitarUser._id;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0004678C File Offset: 0x0004498C
		private void cmdApply_Click(object sender, EventArgs e)
		{
			string sQuery = string.Concat(new string[]
			{
				"EXEC [CIMitar_Factory].[dbo].[USP_Admin_SetCorrelationPartHistory]  @type = 'Create',  @barcode = '",
				this.txtBarcode.Text,
				"', @product = '",
				this.txtProduct.Text,
				"', @prod_remark = '",
				this.txtProdRemark.Text,
				"', @confirmdate = '",
				this.dtpConfirmDate.Text,
				"', @qty = N'",
				this.txtQty.Text,
				"', @checkqty = '",
				this.txtCheckQty.Text,
				"', @confirmuser = '",
				this._cimitarUser._id,
				"', @remark = N'",
				this.txtComment.Text,
				"'"
			});
			this.queryMgr.queryCall(sQuery);
			MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			base.DialogResult = DialogResult.OK;
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0004688F File Offset: 0x00044A8F
		private void cmdClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00046897 File Offset: 0x00044A97
		private void cmdApply_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x000468B4 File Offset: 0x00044AB4
		private void cmdApply_MouseLeave(object sender, EventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x000468D1 File Offset: 0x00044AD1
		private void cmdApply_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdApply.Image = Resources.TableApply_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600028A RID: 650 RVA: 0x000468EE File Offset: 0x00044AEE
		private void cmdApply_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x000468FB File Offset: 0x00044AFB
		private void cmdClose_MouseDown(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00046918 File Offset: 0x00044B18
		private void cmdClose_MouseLeave(object sender, EventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00046935 File Offset: 0x00044B35
		private void cmdClose_MouseMove(object sender, MouseEventArgs e)
		{
			this.cmdClose.Image = Resources.TableCancel_Down;
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00046952 File Offset: 0x00044B52
		private void cmdClose_MouseUp(object sender, MouseEventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0004695F File Offset: 0x00044B5F
		private void textBox5_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x04000475 RID: 1141
		public FactorySettings _factorySetting;

		// Token: 0x04000476 RID: 1142
		public CIMitarAccount _cimitarUser;

		// Token: 0x04000477 RID: 1143
		private QueryMgr queryMgr;

		// Token: 0x04000478 RID: 1144
		private Thread _thread;

		// Token: 0x04000479 RID: 1145
		private BarPrograss _barPrograss;

		// Token: 0x0400047A RID: 1146
		private bool bAttachFileFlag;

		// Token: 0x0400047B RID: 1147
		public SortedList slResult = new SortedList();

		// Token: 0x0400047C RID: 1148
		public string sType = string.Empty;

		// Token: 0x0400047D RID: 1149
		private GridInfo gridInfo = new GridInfo();

		// Token: 0x0400047E RID: 1150
		private ContextMenu menuGrid;

		// Token: 0x0400047F RID: 1151
		public CCorrPartHistory corrHistory = new CCorrPartHistory();
	}
}
