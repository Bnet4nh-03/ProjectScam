using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ColorProgressBar;

namespace Amkor.CADModules.RELUnitDataProcModule.UserControls
{
	// Token: 0x02000016 RID: 22
	public partial class BarPrograss : Form
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x0000F721 File Offset: 0x0000D921
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x0000F72E File Offset: 0x0000D92E
		public int ProgressBarValue
		{
			get
			{
				return this.colorProgressBar.Value;
			}
			set
			{
				this.colorProgressBar.Value = value;
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000DA RID: 218 RVA: 0x0000F740 File Offset: 0x0000D940
		// (remove) Token: 0x060000DB RID: 219 RVA: 0x0000F778 File Offset: 0x0000D978
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<EventArgs> Canceled;

		// Token: 0x060000DC RID: 220 RVA: 0x0000F7AD File Offset: 0x0000D9AD
		public BarPrograss()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000F7D4 File Offset: 0x0000D9D4
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

		// Token: 0x060000DE RID: 222 RVA: 0x0000F864 File Offset: 0x0000DA64
		private void _timer_Tick(object sender, EventArgs e)
		{
			bool ischeck = this._ischeck;
			if (ischeck)
			{
				base.Close();
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000F888 File Offset: 0x0000DA88
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

		// Token: 0x060000E0 RID: 224 RVA: 0x0000F8EC File Offset: 0x0000DAEC
		public void setMax(int max)
		{
			this.colorProgressBar.Maximum = max;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000F8FC File Offset: 0x0000DAFC
		public void setValue(int value)
		{
			this.colorProgressBar.Value = value;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000F90C File Offset: 0x0000DB0C
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

		// Token: 0x060000E3 RID: 227 RVA: 0x0000F974 File Offset: 0x0000DB74
		public void progress_increase_set(int value)
		{
			bool invokeRequired = base.InvokeRequired;
			if (invokeRequired)
			{
				base.BeginInvoke(new BarPrograss.invoke_progress_increase_set(this.progress_increase_set), new object[]
				{
					value
				});
			}
			else
			{
				bool flag = this.colorProgressBar.Value < this.colorProgressBar.Maximum;
				if (flag)
				{
					this.colorProgressBar.Value += value;
				}
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000F9E4 File Offset: 0x0000DBE4
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

		// Token: 0x060000E5 RID: 229 RVA: 0x0000FA34 File Offset: 0x0000DC34
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

		// Token: 0x060000E6 RID: 230 RVA: 0x0000FA7C File Offset: 0x0000DC7C
		private void btnCancel_Click(object sender, EventArgs e)
		{
			EventHandler<EventArgs> canceled = this.Canceled;
			bool flag = canceled != null;
			if (flag)
			{
				canceled(this, e);
			}
		}

		// Token: 0x040000D9 RID: 217
		private Timer _timer;

		// Token: 0x040000DA RID: 218
		private Timer _timer2;

		// Token: 0x040000DB RID: 219
		private string _strStatus;

		// Token: 0x040000DC RID: 220
		public bool _ischeck = false;

		// Token: 0x040000DD RID: 221
		private int iCount = 0;

		// Token: 0x02000024 RID: 36
		// (Invoke) Token: 0x06000146 RID: 326
		public delegate void invoke_progress_increase();

		// Token: 0x02000025 RID: 37
		// (Invoke) Token: 0x0600014A RID: 330
		public delegate void invoke_progress_increase_set(int value);

		// Token: 0x02000026 RID: 38
		// (Invoke) Token: 0x0600014E RID: 334
		public delegate void invoke_progress_label_set(string value);

		// Token: 0x02000027 RID: 39
		// (Invoke) Token: 0x06000152 RID: 338
		public delegate void invoke_progress_labelheader_set(string value);
	}
}
