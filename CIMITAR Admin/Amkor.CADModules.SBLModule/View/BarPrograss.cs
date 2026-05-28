using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ColorProgressBar;

namespace Amkor.CADModules.SBLModule.View
{
	// Token: 0x0200001E RID: 30
	public partial class BarPrograss : Form
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000DF RID: 223 RVA: 0x0000F7D0 File Offset: 0x0000D9D0
		// (remove) Token: 0x060000E0 RID: 224 RVA: 0x0000F808 File Offset: 0x0000DA08
		public event EventHandler<EventArgs> Canceled;

		// Token: 0x060000E1 RID: 225 RVA: 0x0000F83D File Offset: 0x0000DA3D
		public BarPrograss()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000F84C File Offset: 0x0000DA4C
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

		// Token: 0x060000E3 RID: 227 RVA: 0x0000F8D2 File Offset: 0x0000DAD2
		private void _timer_Tick(object sender, EventArgs e)
		{
			if (this._ischeck)
			{
				base.Close();
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000F8E4 File Offset: 0x0000DAE4
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

		// Token: 0x060000E5 RID: 229 RVA: 0x0000F93C File Offset: 0x0000DB3C
		public void setMax(int max)
		{
			this.colorProgressBar.Maximum = max;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000F94A File Offset: 0x0000DB4A
		public void setValue(int value)
		{
			this.colorProgressBar.Value = value;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000F958 File Offset: 0x0000DB58
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

		// Token: 0x060000E8 RID: 232 RVA: 0x0000F9B4 File Offset: 0x0000DBB4
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

		// Token: 0x060000E9 RID: 233 RVA: 0x0000FA1C File Offset: 0x0000DC1C
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

		// Token: 0x060000EA RID: 234 RVA: 0x0000FA64 File Offset: 0x0000DC64
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

		// Token: 0x060000EB RID: 235 RVA: 0x0000FAA8 File Offset: 0x0000DCA8
		private void btnCancel_Click(object sender, EventArgs e)
		{
			EventHandler<EventArgs> canceled = this.Canceled;
			if (canceled != null)
			{
				canceled(this, e);
			}
		}

		// Token: 0x040000FE RID: 254
		private Timer _timer;

		// Token: 0x040000FF RID: 255
		private Timer _timer2;

		// Token: 0x04000100 RID: 256
		private string _strStatus;

		// Token: 0x04000101 RID: 257
		public bool _ischeck;

		// Token: 0x04000102 RID: 258
		private int iCount;

		// Token: 0x0200001F RID: 31
		// (Invoke) Token: 0x060000EF RID: 239
		public delegate void invoke_progress_increase();

		// Token: 0x02000020 RID: 32
		// (Invoke) Token: 0x060000F3 RID: 243
		public delegate void invoke_progress_increase_set(int value);

		// Token: 0x02000021 RID: 33
		// (Invoke) Token: 0x060000F7 RID: 247
		public delegate void invoke_progress_label_set(string value);

		// Token: 0x02000022 RID: 34
		// (Invoke) Token: 0x060000FB RID: 251
		public delegate void invoke_progress_labelheader_set(string value);
	}
}
