using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ColorProgressBar;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x0200002F RID: 47
	public partial class BarPrograss : Form
	{
		// Token: 0x060002EF RID: 751 RVA: 0x000618CB File Offset: 0x0005FACB
		public BarPrograss()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x000618F4 File Offset: 0x0005FAF4
		private void BarPrograss_Load(object sender, EventArgs e)
		{
			this._timer = new Timer();
			this._timer.Interval = 100;
			this._timer.Tick += this._timer_Tick;
			this._timer.Enabled = true;
			this._timer2 = new Timer();
			this._timer2.Interval = 300;
			this._timer2.Tick += this._timer_Tick2;
			this._timer2.Enabled = true;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00061984 File Offset: 0x0005FB84
		private void _timer_Tick(object sender, EventArgs e)
		{
			bool ischeck = this._ischeck;
			if (ischeck)
			{
				base.Close();
			}
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x000619A8 File Offset: 0x0005FBA8
		private void _timer_Tick2(object sender, EventArgs e)
		{
			bool flag = this.iCount == 5;
			if (flag)
			{
				this.lblStatus.Text = this._strStatus;
				this.iCount = 0;
			}
			else
			{
				Label label = this.lblStatus;
				label.Text += ".";
				this.iCount++;
			}
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00061A0C File Offset: 0x0005FC0C
		public void setMax(int max)
		{
			this.colorProgressBar.Maximum = max;
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00061A1C File Offset: 0x0005FC1C
		public void setValue(int value)
		{
			this.colorProgressBar.Value = value;
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00061A2C File Offset: 0x0005FC2C
		public void progress_increase()
		{
			bool invokeRequired = base.InvokeRequired;
			if (invokeRequired)
			{
				base.BeginInvoke(new BarPrograss.invoke_progress_increase(this.progress_increase), new object[0]);
			}
			else
			{
				bool flag = this.colorProgressBar.Value < this.colorProgressBar.Maximum;
				if (flag)
				{
					this.colorProgressBar.Value++;
				}
			}
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00061A94 File Offset: 0x0005FC94
		public void progress_label_set(string value)
		{
			bool invokeRequired = base.InvokeRequired;
			if (invokeRequired)
			{
				base.BeginInvoke(new BarPrograss.invoke_progress_label_set(this.progress_label_set), new object[]
				{
					value
				});
			}
			else
			{
				this.lblStatus.Text = value;
				this._strStatus = value;
			}
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00061AE4 File Offset: 0x0005FCE4
		public void progress_labelheader_set(string value)
		{
			bool invokeRequired = base.InvokeRequired;
			if (invokeRequired)
			{
				base.BeginInvoke(new BarPrograss.invoke_progress_label_set(this.progress_labelheader_set), new object[]
				{
					value
				});
			}
			else
			{
				this.lbl_header.Text = value;
			}
		}

		// Token: 0x0400052B RID: 1323
		private Timer _timer;

		// Token: 0x0400052C RID: 1324
		private Timer _timer2;

		// Token: 0x0400052D RID: 1325
		private string _strStatus;

		// Token: 0x0400052E RID: 1326
		public bool _ischeck = false;

		// Token: 0x0400052F RID: 1327
		private int iCount = 0;

		// Token: 0x02000086 RID: 134
		// (Invoke) Token: 0x06000656 RID: 1622
		public delegate void invoke_progress_increase();

		// Token: 0x02000087 RID: 135
		// (Invoke) Token: 0x0600065A RID: 1626
		public delegate void invoke_progress_label_set(string value);

		// Token: 0x02000088 RID: 136
		// (Invoke) Token: 0x0600065E RID: 1630
		public delegate void invoke_progress_labelheader_set(string value);
	}
}
