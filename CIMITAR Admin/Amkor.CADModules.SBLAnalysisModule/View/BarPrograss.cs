using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ColorProgressBar;

namespace Amkor.CADModules.SBLAnalysisModule.View
{
	// Token: 0x02000016 RID: 22
	public partial class BarPrograss : Form
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000090 RID: 144 RVA: 0x0000A860 File Offset: 0x00008A60
		// (remove) Token: 0x06000091 RID: 145 RVA: 0x0000A89C File Offset: 0x00008A9C
		public event EventHandler<EventArgs> Canceled;

		// Token: 0x06000092 RID: 146 RVA: 0x0000A8D8 File Offset: 0x00008AD8
		public BarPrograss()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000A900 File Offset: 0x00008B00
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

		// Token: 0x06000094 RID: 148 RVA: 0x0000A990 File Offset: 0x00008B90
		private void _timer_Tick(object sender, EventArgs e)
		{
			if (this._ischeck)
			{
				base.Close();
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000A9B4 File Offset: 0x00008BB4
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

		// Token: 0x06000096 RID: 150 RVA: 0x0000AA1B File Offset: 0x00008C1B
		public void setMax(int max)
		{
			this.colorProgressBar.Maximum = max;
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000AA2B File Offset: 0x00008C2B
		public void setValue(int value)
		{
			this.colorProgressBar.Value = value;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000AA3C File Offset: 0x00008C3C
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

		// Token: 0x06000099 RID: 153 RVA: 0x0000AAAC File Offset: 0x00008CAC
		public void progress_increase_set(int value)
		{
			if (base.InvokeRequired)
			{
				base.BeginInvoke(new BarPrograss.invoke_progress_increase_set(this.progress_increase_set), new object[]
				{
					value
				});
			}
			else if (this.colorProgressBar.Value < this.colorProgressBar.Maximum)
			{
				this.colorProgressBar.Value += value;
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000AB24 File Offset: 0x00008D24
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

		// Token: 0x0600009B RID: 155 RVA: 0x0000AB78 File Offset: 0x00008D78
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

		// Token: 0x0600009C RID: 156 RVA: 0x0000ABC8 File Offset: 0x00008DC8
		private void btnCancel_Click(object sender, EventArgs e)
		{
			EventHandler<EventArgs> canceled = this.Canceled;
			if (canceled != null)
			{
				canceled(this, e);
			}
		}

		// Token: 0x0400009B RID: 155
		private Timer _timer;

		// Token: 0x0400009C RID: 156
		private Timer _timer2;

		// Token: 0x0400009D RID: 157
		private string _strStatus;

		// Token: 0x0400009E RID: 158
		public bool _ischeck = false;

		// Token: 0x0400009F RID: 159
		private int iCount = 0;

		// Token: 0x02000017 RID: 23
		// (Invoke) Token: 0x060000A0 RID: 160
		public delegate void invoke_progress_increase();

		// Token: 0x02000018 RID: 24
		// (Invoke) Token: 0x060000A4 RID: 164
		public delegate void invoke_progress_increase_set(int value);

		// Token: 0x02000019 RID: 25
		// (Invoke) Token: 0x060000A8 RID: 168
		public delegate void invoke_progress_label_set(string value);

		// Token: 0x0200001A RID: 26
		// (Invoke) Token: 0x060000AC RID: 172
		public delegate void invoke_progress_labelheader_set(string value);
	}
}
