using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ColorProgressBar;

namespace Amkor.CADModules.UnitDataProcModule.Controls
{
	// Token: 0x02000020 RID: 32
	public partial class BarPrograss : Form
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000B9 RID: 185 RVA: 0x0000E27C File Offset: 0x0000C47C
		// (remove) Token: 0x060000BA RID: 186 RVA: 0x0000E2B4 File Offset: 0x0000C4B4
		public event EventHandler<EventArgs> Canceled;

		// Token: 0x060000BB RID: 187 RVA: 0x0000E2E9 File Offset: 0x0000C4E9
		public BarPrograss()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000E2F8 File Offset: 0x0000C4F8
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

		// Token: 0x060000BD RID: 189 RVA: 0x0000E37E File Offset: 0x0000C57E
		private void _timer_Tick(object sender, EventArgs e)
		{
			if (this._ischeck)
			{
				base.Close();
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000E390 File Offset: 0x0000C590
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

		// Token: 0x060000BF RID: 191 RVA: 0x0000E3E8 File Offset: 0x0000C5E8
		public void setMax(int max)
		{
			this.colorProgressBar.Maximum = max;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000E3F6 File Offset: 0x0000C5F6
		public void setValue(int value)
		{
			this.colorProgressBar.Value = value;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000E404 File Offset: 0x0000C604
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

		// Token: 0x060000C2 RID: 194 RVA: 0x0000E460 File Offset: 0x0000C660
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

		// Token: 0x060000C3 RID: 195 RVA: 0x0000E4C8 File Offset: 0x0000C6C8
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

		// Token: 0x060000C4 RID: 196 RVA: 0x0000E510 File Offset: 0x0000C710
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

		// Token: 0x060000C5 RID: 197 RVA: 0x0000E554 File Offset: 0x0000C754
		private void btnCancel_Click(object sender, EventArgs e)
		{
			EventHandler<EventArgs> canceled = this.Canceled;
			if (canceled != null)
			{
				canceled(this, e);
			}
		}

		// Token: 0x04000122 RID: 290
		private Timer _timer;

		// Token: 0x04000123 RID: 291
		private Timer _timer2;

		// Token: 0x04000124 RID: 292
		private string _strStatus;

		// Token: 0x04000125 RID: 293
		public bool _ischeck;

		// Token: 0x04000126 RID: 294
		private int iCount;

		// Token: 0x02000021 RID: 33
		// (Invoke) Token: 0x060000C9 RID: 201
		public delegate void invoke_progress_increase();

		// Token: 0x02000022 RID: 34
		// (Invoke) Token: 0x060000CD RID: 205
		public delegate void invoke_progress_increase_set(int value);

		// Token: 0x02000023 RID: 35
		// (Invoke) Token: 0x060000D1 RID: 209
		public delegate void invoke_progress_label_set(string value);

		// Token: 0x02000024 RID: 36
		// (Invoke) Token: 0x060000D5 RID: 213
		public delegate void invoke_progress_labelheader_set(string value);
	}
}
