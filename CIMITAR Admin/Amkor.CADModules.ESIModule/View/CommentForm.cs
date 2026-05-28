using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Amkor.CADModules.ESIModule.View
{
	// Token: 0x0200002F RID: 47
	public partial class CommentForm : Form
	{
		// Token: 0x0600016A RID: 362 RVA: 0x00024D67 File Offset: 0x00022F67
		public CommentForm()
		{
			this.InitializeComponent();
			this.tbComment.Text = string.Empty;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00024D90 File Offset: 0x00022F90
		private void btnApply_Click(object sender, EventArgs e)
		{
			this._sComment = this.tbComment.Text;
			base.DialogResult = DialogResult.Yes;
			base.Close();
		}

		// Token: 0x0400026F RID: 623
		public string _sComment = string.Empty;
	}
}
