using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ColorProgressBar;

namespace Amkor.CADModules.DcolSummaryView.Controls
{
	// Token: 0x0200001C RID: 28
	public partial class BarPrograss : Form
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600008A RID: 138 RVA: 0x00007C48 File Offset: 0x00005E48
		// (remove) Token: 0x0600008B RID: 139 RVA: 0x00007C80 File Offset: 0x00005E80
		public event EventHandler<EventArgs> Canceled;

		// Token: 0x0600008C RID: 140 RVA: 0x00007CB5 File Offset: 0x00005EB5
		public BarPrograss()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00007CC4 File Offset: 0x00005EC4
		private void BarPrograss_Load(object sender, EventArgs e)
		{
			this._timer = new Timer();
			this._timer.Interval = 100;
			this._timer.Tick += this._timer_Tick;
			this._timer.Enabled = true;
			this._timer2 = new Timer();
			this._timer2.Interval = 200;
			this._timer2.Tick += this._timer_Tick2;
			this._timer2.Enabled = true;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00007D4A File Offset: 0x00005F4A
		private void _timer_Tick(object sender, EventArgs e)
		{
			if (this._ischeck)
			{
				base.Close();
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00007D5C File Offset: 0x00005F5C
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

		// Token: 0x06000090 RID: 144 RVA: 0x00007DB4 File Offset: 0x00005FB4
		public void setMax(int max)
		{
			this.colorProgressBar.Maximum = max;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00007DC2 File Offset: 0x00005FC2
		public void setValue(int value)
		{
			this.colorProgressBar.Value = value;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00007DD0 File Offset: 0x00005FD0
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

		// Token: 0x06000093 RID: 147 RVA: 0x00007E2C File Offset: 0x0000602C
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

		// Token: 0x06000094 RID: 148 RVA: 0x00007E94 File Offset: 0x00006094
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

		// Token: 0x06000095 RID: 149 RVA: 0x00007EDC File Offset: 0x000060DC
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

		// Token: 0x06000096 RID: 150 RVA: 0x00007F20 File Offset: 0x00006120
		private void btnCancel_Click(object sender, EventArgs e)
		{
			EventHandler<EventArgs> canceled = this.Canceled;
			if (canceled != null)
			{
				canceled(this, e);
			}
		}

		// Token: 0x04000091 RID: 145
		private Timer _timer;

		// Token: 0x04000092 RID: 146
		private Timer _timer2;

		// Token: 0x04000093 RID: 147
		private string _strStatus;

		// Token: 0x04000094 RID: 148
		public bool _ischeck;

		// Token: 0x04000095 RID: 149
		private int iCount;

		// Token: 0x0200001D RID: 29
		// (Invoke) Token: 0x0600009A RID: 154
		public delegate void invoke_progress_increase();

		// Token: 0x0200001E RID: 30
		// (Invoke) Token: 0x0600009E RID: 158
		public delegate void invoke_progress_increase_set(int value);

		// Token: 0x0200001F RID: 31
		// (Invoke) Token: 0x060000A2 RID: 162
		public delegate void invoke_progress_label_set(string value);

		// Token: 0x02000020 RID: 32
		// (Invoke) Token: 0x060000A6 RID: 166
		public delegate void invoke_progress_labelheader_set(string value);
	}
}
