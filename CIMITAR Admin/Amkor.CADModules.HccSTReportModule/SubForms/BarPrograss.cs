using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ColorProgressBar;

namespace Amkor.CADModules.HccSTReportModule.SubForms
{
	// Token: 0x02000008 RID: 8
	public partial class BarPrograss : Form
	{
		// Token: 0x0600003A RID: 58 RVA: 0x0000A310 File Offset: 0x00008510
		public BarPrograss()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000A320 File Offset: 0x00008520
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

		// Token: 0x0600003C RID: 60 RVA: 0x0000A3A6 File Offset: 0x000085A6
		private void _timer_Tick(object sender, EventArgs e)
		{
			if (this._ischeck)
			{
				base.Close();
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000A3B8 File Offset: 0x000085B8
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

		// Token: 0x0600003E RID: 62 RVA: 0x0000A410 File Offset: 0x00008610
		public void setMax(int max)
		{
			this.colorProgressBar.Maximum = max;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000A41E File Offset: 0x0000861E
		public void setValue(int value)
		{
			this.colorProgressBar.Value = value;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000A42C File Offset: 0x0000862C
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

		// Token: 0x06000041 RID: 65 RVA: 0x0000A486 File Offset: 0x00008686
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

		// Token: 0x06000042 RID: 66 RVA: 0x0000A4C1 File Offset: 0x000086C1
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

		// Token: 0x04000074 RID: 116
		private Timer _timer;

		// Token: 0x04000075 RID: 117
		private Timer _timer2;

		// Token: 0x04000076 RID: 118
		private string _strStatus;

		// Token: 0x04000077 RID: 119
		public bool _ischeck;

		// Token: 0x04000078 RID: 120
		private int iCount;

		// Token: 0x02000032 RID: 50
		// (Invoke) Token: 0x060000F9 RID: 249
		public delegate void invoke_progress_increase();

		// Token: 0x02000033 RID: 51
		// (Invoke) Token: 0x060000FD RID: 253
		public delegate void invoke_progress_label_set(string value);

		// Token: 0x02000034 RID: 52
		// (Invoke) Token: 0x06000101 RID: 257
		public delegate void invoke_progress_labelheader_set(string value);
	}
}
