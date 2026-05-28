using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ColorProgressBar;

namespace Amkor.CADModules.ESIModule.View
{
	// Token: 0x02000028 RID: 40
	public partial class BarPrograss : Form
	{
		// Token: 0x060000CD RID: 205 RVA: 0x0000B435 File Offset: 0x00009635
		public BarPrograss()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000B444 File Offset: 0x00009644
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

		// Token: 0x060000CF RID: 207 RVA: 0x0000B4CA File Offset: 0x000096CA
		private void _timer_Tick(object sender, EventArgs e)
		{
			if (this._ischeck)
			{
				base.Close();
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000B4DC File Offset: 0x000096DC
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

		// Token: 0x060000D1 RID: 209 RVA: 0x0000B534 File Offset: 0x00009734
		public void setMax(int max)
		{
			this.colorProgressBar.Maximum = max;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x0000B542 File Offset: 0x00009742
		public void setValue(int value)
		{
			this.colorProgressBar.Value = value;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x0000B550 File Offset: 0x00009750
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

		// Token: 0x060000D4 RID: 212 RVA: 0x0000B5AC File Offset: 0x000097AC
		public void progress_increase_set(int value)
		{
			if (base.InvokeRequired)
			{
				base.BeginInvoke(new BarPrograss.invoke_progress_increase_set(this.progress_increase_set), new object[]
				{
					value
				});
				return;
			}
			if (this.colorProgressBar.Value < this.colorProgressBar.Maximum)
			{
				this.colorProgressBar.Value += value;
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000B614 File Offset: 0x00009814
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

		// Token: 0x060000D6 RID: 214 RVA: 0x0000B65C File Offset: 0x0000985C
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

		// Token: 0x0400013E RID: 318
		private Timer _timer;

		// Token: 0x0400013F RID: 319
		private Timer _timer2;

		// Token: 0x04000140 RID: 320
		private string _strStatus;

		// Token: 0x04000141 RID: 321
		public bool _ischeck;

		// Token: 0x04000142 RID: 322
		private int iCount;

		// Token: 0x02000029 RID: 41
		// (Invoke) Token: 0x060000DA RID: 218
		public delegate void invoke_progress_increase();

		// Token: 0x0200002A RID: 42
		// (Invoke) Token: 0x060000DE RID: 222
		public delegate void invoke_progress_increase_set(int value);

		// Token: 0x0200002B RID: 43
		// (Invoke) Token: 0x060000E2 RID: 226
		public delegate void invoke_progress_label_set(string value);

		// Token: 0x0200002C RID: 44
		// (Invoke) Token: 0x060000E6 RID: 230
		public delegate void invoke_progress_labelheader_set(string value);
	}
}
