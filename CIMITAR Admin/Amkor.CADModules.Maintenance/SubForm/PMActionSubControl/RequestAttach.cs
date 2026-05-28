using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Amkor.CADModules.Maintenance.SubForm.PMActionSubControl
{
	// Token: 0x0200001F RID: 31
	public class RequestAttach : UserControl
	{
		// Token: 0x0600023B RID: 571 RVA: 0x00053429 File Offset: 0x00051629
		public RequestAttach()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00053444 File Offset: 0x00051644
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0005347C File Offset: 0x0005167C
		private void InitializeComponent()
		{
			this.gbReportAttachment = new GroupBox();
			this.dgAttachmentList = new DataGridView();
			this.gbReportAttachment.SuspendLayout();
			((ISupportInitialize)this.dgAttachmentList).BeginInit();
			base.SuspendLayout();
			this.gbReportAttachment.Controls.Add(this.dgAttachmentList);
			this.gbReportAttachment.Dock = DockStyle.Fill;
			this.gbReportAttachment.Font = new Font("Segoe UI Symbol", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.gbReportAttachment.Location = new Point(0, 0);
			this.gbReportAttachment.Name = "gbReportAttachment";
			this.gbReportAttachment.Size = new Size(488, 252);
			this.gbReportAttachment.TabIndex = 103;
			this.gbReportAttachment.TabStop = false;
			this.gbReportAttachment.Text = "Attachment File";
			this.gbReportAttachment.Visible = false;
			this.dgAttachmentList.AllowUserToDeleteRows = false;
			this.dgAttachmentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgAttachmentList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			this.dgAttachmentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgAttachmentList.ColumnHeadersVisible = false;
			this.dgAttachmentList.Dock = DockStyle.Fill;
			this.dgAttachmentList.GridColor = Color.White;
			this.dgAttachmentList.Location = new Point(3, 21);
			this.dgAttachmentList.MultiSelect = false;
			this.dgAttachmentList.Name = "dgAttachmentList";
			this.dgAttachmentList.ReadOnly = true;
			this.dgAttachmentList.RowHeadersVisible = false;
			this.dgAttachmentList.RowTemplate.Height = 23;
			this.dgAttachmentList.Size = new Size(482, 228);
			this.dgAttachmentList.TabIndex = 45;
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.gbReportAttachment);
			base.Name = "RequestAttach";
			base.Size = new Size(488, 252);
			this.gbReportAttachment.ResumeLayout(false);
			((ISupportInitialize)this.dgAttachmentList).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000435 RID: 1077
		private IContainer components = null;

		// Token: 0x04000436 RID: 1078
		private GroupBox gbReportAttachment;

		// Token: 0x04000437 RID: 1079
		private DataGridView dgAttachmentList;
	}
}
