using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ColorProgressBar;

namespace Amkor.CADModules.SAMSUNGModule.View
{
	// Token: 0x02000021 RID: 33
	public partial class BarPrograss : Form
	{
		// Token: 0x0600008A RID: 138 RVA: 0x00005770 File Offset: 0x00003970
		public BarPrograss()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00005780 File Offset: 0x00003980
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

		// Token: 0x0600008C RID: 140 RVA: 0x00005806 File Offset: 0x00003A06
		private void _timer_Tick(object sender, EventArgs e)
		{
			if (this._ischeck)
			{
				base.Close();
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00005818 File Offset: 0x00003A18
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

		// Token: 0x0600008E RID: 142 RVA: 0x00005870 File Offset: 0x00003A70
		public void setMax(int max)
		{
			this.colorProgressBar.Maximum = max;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000587E File Offset: 0x00003A7E
		public void setValue(int value)
		{
			this.colorProgressBar.Value = value;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000588C File Offset: 0x00003A8C
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

		// Token: 0x06000091 RID: 145 RVA: 0x000058E8 File Offset: 0x00003AE8
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

		// Token: 0x06000092 RID: 146 RVA: 0x00005950 File Offset: 0x00003B50
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

		// Token: 0x06000093 RID: 147 RVA: 0x00005998 File Offset: 0x00003B98
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

		// Token: 0x040000C6 RID: 198
		private Timer _timer;

		// Token: 0x040000C7 RID: 199
		private Timer _timer2;

		// Token: 0x040000C8 RID: 200
		private string _strStatus;

		// Token: 0x040000C9 RID: 201
		public bool _ischeck;

		// Token: 0x040000CA RID: 202
		private int iCount;

		// Token: 0x02000022 RID: 34
		// (Invoke) Token: 0x06000097 RID: 151
		public delegate void invoke_progress_increase();

		// Token: 0x02000023 RID: 35
		// (Invoke) Token: 0x0600009B RID: 155
		public delegate void invoke_progress_increase_set(int value);

		// Token: 0x02000024 RID: 36
		// (Invoke) Token: 0x0600009F RID: 159
		public delegate void invoke_progress_label_set(string value);

		// Token: 0x02000025 RID: 37
		// (Invoke) Token: 0x060000A3 RID: 163
		public delegate void invoke_progress_labelheader_set(string value);
	}
}
