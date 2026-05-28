using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ColorProgressBar;

namespace Amkor.CADModules.ManufactureHistory.SubForm
{
	// Token: 0x0200000C RID: 12
	public partial class BarPrograss : Form
	{
		// Token: 0x06000039 RID: 57 RVA: 0x0000535B File Offset: 0x0000355B
		public BarPrograss()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00005384 File Offset: 0x00003584
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

		// Token: 0x0600003B RID: 59 RVA: 0x00005414 File Offset: 0x00003614
		private void _timer_Tick(object sender, EventArgs e)
		{
			if (this._ischeck)
			{
				base.Close();
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005438 File Offset: 0x00003638
		private void _timer_Tick2(object sender, EventArgs e)
		{
			if (this.iCount == 5)
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

		// Token: 0x0600003D RID: 61 RVA: 0x0000549F File Offset: 0x0000369F
		public void setMax(int max)
		{
			this.colorProgressBar.Maximum = max;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000054AF File Offset: 0x000036AF
		public void setValue(int value)
		{
			this.colorProgressBar.Value = value;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000054C0 File Offset: 0x000036C0
		public void progress_increase()
		{
			if (base.InvokeRequired)
			{
				base.BeginInvoke(new BarPrograss.invoke_progress_increase(this.progress_increase), new object[0]);
			}
			else if (this.colorProgressBar.Value < this.colorProgressBar.Maximum)
			{
				this.colorProgressBar.Value++;
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00005530 File Offset: 0x00003730
		public void progress_label_set(string value)
		{
			if (base.InvokeRequired)
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

		// Token: 0x06000041 RID: 65 RVA: 0x00005584 File Offset: 0x00003784
		public void progress_labelheader_set(string value)
		{
			if (base.InvokeRequired)
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

		// Token: 0x0400001F RID: 31
		private Timer _timer;

		// Token: 0x04000020 RID: 32
		private Timer _timer2;

		// Token: 0x04000021 RID: 33
		private string _strStatus;

		// Token: 0x04000022 RID: 34
		public bool _ischeck = false;

		// Token: 0x04000023 RID: 35
		private int iCount = 0;

		// Token: 0x0200000D RID: 13
		// (Invoke) Token: 0x06000045 RID: 69
		public delegate void invoke_progress_increase();

		// Token: 0x0200000E RID: 14
		// (Invoke) Token: 0x06000049 RID: 73
		public delegate void invoke_progress_label_set(string value);

		// Token: 0x0200000F RID: 15
		// (Invoke) Token: 0x0600004D RID: 77
		public delegate void invoke_progress_labelheader_set(string value);
	}
}
