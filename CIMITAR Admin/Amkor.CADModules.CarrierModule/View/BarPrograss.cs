using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ColorProgressBar;

namespace Amkor.CADModules.CarrierModule.View
{
	// Token: 0x0200003D RID: 61
	public partial class BarPrograss : Form
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060002BA RID: 698 RVA: 0x0004A504 File Offset: 0x00048704
		// (remove) Token: 0x060002BB RID: 699 RVA: 0x0004A53C File Offset: 0x0004873C
		public event EventHandler<EventArgs> Canceled;

		// Token: 0x060002BC RID: 700 RVA: 0x0004A571 File Offset: 0x00048771
		public BarPrograss()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0004A580 File Offset: 0x00048780
		private void BarPrograss_Load(object sender, EventArgs e)
		{
			this._timer = new Timer();
			this._timer.Interval = 10;
			this._timer.Tick += this._timer_Tick;
			this._timer.Enabled = true;
			this._timer2 = new Timer();
			this._timer2.Interval = 300;
			this._timer2.Tick += this._timer_Tick2;
			this._timer2.Enabled = true;
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0004A606 File Offset: 0x00048806
		private void _timer_Tick(object sender, EventArgs e)
		{
			if (this._ischeck)
			{
				base.Close();
			}
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0004A618 File Offset: 0x00048818
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

		// Token: 0x060002C0 RID: 704 RVA: 0x0004A670 File Offset: 0x00048870
		public void setMax(int max)
		{
			this.colorProgressBar.Maximum = max;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0004A67E File Offset: 0x0004887E
		public void setValue(int value)
		{
			this.colorProgressBar.Value = value;
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0004A68C File Offset: 0x0004888C
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

		// Token: 0x060002C3 RID: 707 RVA: 0x0004A6E8 File Offset: 0x000488E8
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

		// Token: 0x060002C4 RID: 708 RVA: 0x0004A750 File Offset: 0x00048950
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

		// Token: 0x060002C5 RID: 709 RVA: 0x0004A798 File Offset: 0x00048998
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

		// Token: 0x060002C6 RID: 710 RVA: 0x0004A7DC File Offset: 0x000489DC
		private void btnCancel_Click(object sender, EventArgs e)
		{
			EventHandler<EventArgs> canceled = this.Canceled;
			if (canceled != null)
			{
				canceled(this, e);
			}
		}

		// Token: 0x040004E8 RID: 1256
		private Timer _timer;

		// Token: 0x040004E9 RID: 1257
		private Timer _timer2;

		// Token: 0x040004EA RID: 1258
		private string _strStatus;

		// Token: 0x040004EB RID: 1259
		public bool _ischeck;

		// Token: 0x040004EC RID: 1260
		private int iCount;

		// Token: 0x0200003E RID: 62
		// (Invoke) Token: 0x060002CA RID: 714
		public delegate void invoke_progress_increase();

		// Token: 0x0200003F RID: 63
		// (Invoke) Token: 0x060002CE RID: 718
		public delegate void invoke_progress_increase_set(int value);

		// Token: 0x02000040 RID: 64
		// (Invoke) Token: 0x060002D2 RID: 722
		public delegate void invoke_progress_label_set(string value);

		// Token: 0x02000041 RID: 65
		// (Invoke) Token: 0x060002D6 RID: 726
		public delegate void invoke_progress_labelheader_set(string value);
	}
}
