using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ColorProgressBar;

namespace AlteraSocketView.View
{
	// Token: 0x02000002 RID: 2
	public partial class BarPrograss : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public BarPrograss()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002060 File Offset: 0x00000260
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

		// Token: 0x06000003 RID: 3 RVA: 0x000020E6 File Offset: 0x000002E6
		private void _timer_Tick(object sender, EventArgs e)
		{
			if (this._ischeck)
			{
				base.Close();
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020F8 File Offset: 0x000002F8
		private void _timer_Tick2(object sender, EventArgs e)
		{
			if (this.iCount == 5)
			{
				this.lblStatus.Text = this._strStatus;
				this.iCount = 0;
				return;
			}
			Label label = this.lblStatus;
			label.Text += ".";
			this.iCount++;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002150 File Offset: 0x00000350
		public void setMax(int max)
		{
			this.colorProgressBar.Maximum = max;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000215E File Offset: 0x0000035E
		public void setValue(int value)
		{
			this.colorProgressBar.Value = value;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000216C File Offset: 0x0000036C
		public void progress_increase()
		{
			if (base.InvokeRequired)
			{
				base.BeginInvoke(new BarPrograss.invoke_progress_increase(this.progress_increase), new object[0]);
				return;
			}
			if (this.colorProgressBar.Value < this.colorProgressBar.Maximum)
			{
				this.colorProgressBar.Value++;
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021C6 File Offset: 0x000003C6
		public void progress_label_set(string value)
		{
			if (base.InvokeRequired)
			{
				base.BeginInvoke(new BarPrograss.invoke_progress_label_set(this.progress_label_set), new object[]
				{
					value
				});
				return;
			}
			this.lblStatus.Text = value;
			this._strStatus = value;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002201 File Offset: 0x00000401
		public void progress_labelheader_set(string value)
		{
			if (base.InvokeRequired)
			{
				base.BeginInvoke(new BarPrograss.invoke_progress_label_set(this.progress_labelheader_set), new object[]
				{
					value
				});
				return;
			}
			this.lbl_header.Text = value;
		}

		// Token: 0x04000001 RID: 1
		private Timer _timer;

		// Token: 0x04000002 RID: 2
		private Timer _timer2;

		// Token: 0x04000003 RID: 3
		private string _strStatus;

		// Token: 0x04000004 RID: 4
		public bool _ischeck;

		// Token: 0x04000005 RID: 5
		private int iCount;

		// Token: 0x0200000E RID: 14
		// (Invoke) Token: 0x0600005C RID: 92
		public delegate void invoke_progress_increase();

		// Token: 0x0200000F RID: 15
		// (Invoke) Token: 0x06000060 RID: 96
		public delegate void invoke_progress_label_set(string value);

		// Token: 0x02000010 RID: 16
		// (Invoke) Token: 0x06000064 RID: 100
		public delegate void invoke_progress_labelheader_set(string value);
	}
}
