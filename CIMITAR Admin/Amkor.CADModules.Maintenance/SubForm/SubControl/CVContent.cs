using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000039 RID: 57
	public class CVContent : UserControl, IMessageFilter
	{
		// Token: 0x0600038B RID: 907
		[DllImport("user32.dll")]
		private static extern IntPtr WindowFromPoint(Point pt);

		// Token: 0x0600038C RID: 908
		[DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

		// Token: 0x0600038D RID: 909 RVA: 0x0006C351 File Offset: 0x0006A551
		internal static int GET_WHEEL_DELTA_WPARAM(IntPtr wParam)
		{
			return (int)((short)CVContent.HIWORD(wParam));
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0006C35A File Offset: 0x0006A55A
		internal static ushort HIWORD(IntPtr dwValue)
		{
			return (ushort)((long)dwValue >> 16 & 65535L);
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0006C370 File Offset: 0x0006A570
		public CVContent(Panel parent, string title, string content, bool isYes)
		{
			this.InitializeComponent();
			Application.AddMessageFilter(this);
			this.Dock = DockStyle.Top;
			base.Parent = parent;
			this.lbTitle.Text = title.Trim();
			this.tbContent.Text = content.Trim();
			this.cbYes.Paint += this.onPaint;
			this.cbNo.Paint += this.onPaint;
			if (isYes)
			{
				this.cbYes.Checked = true;
			}
			else
			{
				this.cbNo.Checked = true;
			}
			this.tbContent.ReadOnly = true;
			this.cbYes.Enabled = false;
			this.cbNo.Enabled = false;
			base.BringToFront();
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0006C458 File Offset: 0x0006A658
		public CVContent(Panel parent, string title)
		{
			this.Dock = DockStyle.Top;
			this.InitializeComponent();
			Application.AddMessageFilter(this);
			this.Dock = DockStyle.Top;
			base.Parent = parent;
			this.lbTitle.Text = title.Trim();
			this.tbContent.Text = string.Empty;
			this.cbYes.Paint += this.onPaint;
			this.cbNo.Paint += this.onPaint;
			this.tbContent.ReadOnly = false;
			this.cbYes.Enabled = true;
			this.cbNo.Enabled = true;
			base.BringToFront();
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0006C524 File Offset: 0x0006A724
		private void onPaint(object sender, PaintEventArgs e)
		{
			base.OnPaint(e);
			bool flag = !this.cbYes.Enabled;
			Rectangle rectangle;
			if (flag)
			{
				int num = (base.ClientSize.Height - 2) / 3;
				rectangle = new Rectangle(new Point(25, 3), new Size(num, num));
			}
			else
			{
				int num = (base.ClientSize.Height - 2) / 2;
				rectangle = new Rectangle(new Point(15, 0), new Size(num, num));
			}
			ControlPaint.DrawCheckBox(e.Graphics, rectangle, ((CheckBox)sender).Checked ? ButtonState.Checked : ButtonState.Normal);
		}

		// Token: 0x06000392 RID: 914 RVA: 0x0006C5C8 File Offset: 0x0006A7C8
		private void cbYes_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = this._checkCheckBox && this.cbNo.Checked;
			if (flag)
			{
				this._checkCheckBox = false;
				this.cbNo.Checked = false;
			}
			else
			{
				this._checkCheckBox = true;
			}
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0006C614 File Offset: 0x0006A814
		private void cbNo_CheckedChanged(object sender, EventArgs e)
		{
			bool flag = this._checkCheckBox && this.cbYes.Checked;
			if (flag)
			{
				this._checkCheckBox = false;
				this.cbYes.Checked = false;
			}
			else
			{
				this._checkCheckBox = true;
			}
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0006C660 File Offset: 0x0006A860
		public bool PreFilterMessage(ref Message m)
		{
			bool flag = m.HWnd == this.tbContent.Handle || m.HWnd == this.lbTitle.Handle;
			if (flag)
			{
				bool flag2 = m.Msg == 522;
				if (flag2)
				{
					CVContent.SendMessage(base.Parent.Handle, m.Msg, m.WParam, m.LParam);
				}
			}
			return false;
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0006C6E0 File Offset: 0x0006A8E0
		public bool getCheckStatus()
		{
			return this.cbYes.Checked || this.cbNo.Checked;
		}

		// Token: 0x06000396 RID: 918 RVA: 0x0006C718 File Offset: 0x0006A918
		public bool isYes()
		{
			bool @checked = this.cbYes.Checked;
			bool result;
			if (@checked)
			{
				bool flag = string.IsNullOrEmpty(this.tbContent.Text.Trim());
				result = !flag;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x0006C75C File Offset: 0x0006A95C
		public bool getContentLen()
		{
			bool @checked = this.cbYes.Checked;
			return !@checked || this.tbContent.Text.Trim().Length >= 10;
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0006C7A0 File Offset: 0x0006A9A0
		public string getContent()
		{
			bool @checked = this.cbYes.Checked;
			string result;
			if (@checked)
			{
				result = this.tbContent.Text.Trim().Replace("'", "''");
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0006C7E8 File Offset: 0x0006A9E8
		public void clear()
		{
			this.tbContent.Text = string.Empty;
			this.cbYes.Checked = false;
			this.cbNo.Checked = false;
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0006C816 File Offset: 0x0006AA16
		public void setContent(string str)
		{
			this.tbContent.Text = str;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0006C828 File Offset: 0x0006AA28
		private void label2_Click(object sender, EventArgs e)
		{
			bool enabled = this.cbYes.Enabled;
			if (enabled)
			{
				this.cbYes.Checked = !this.cbYes.Checked;
			}
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0006C860 File Offset: 0x0006AA60
		private void label3_Click(object sender, EventArgs e)
		{
			bool enabled = this.cbYes.Enabled;
			if (enabled)
			{
				this.cbNo.Checked = !this.cbNo.Checked;
			}
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0006C898 File Offset: 0x0006AA98
		private void tbContent_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = e.KeyChar == '|';
			if (flag)
			{
				e.KeyChar = '\0';
			}
		}

		// Token: 0x0600039E RID: 926 RVA: 0x0006C8BC File Offset: 0x0006AABC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600039F RID: 927 RVA: 0x0006C8F4 File Offset: 0x0006AAF4
		private void InitializeComponent()
		{
			this.panel1 = new Panel();
			this.panel3 = new Panel();
			this.tbContent = new TextBox();
			this.panel2 = new Panel();
			this.lbTitle = new Label();
			this.panel5 = new Panel();
			this.cbYes = new CheckBox();
			this.label2 = new Label();
			this.panel4 = new Panel();
			this.cbNo = new CheckBox();
			this.label3 = new Label();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.ForeColor = Color.White;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(485, 62);
			this.panel1.TabIndex = 0;
			this.panel3.Controls.Add(this.tbContent);
			this.panel3.Dock = DockStyle.Fill;
			this.panel3.ForeColor = Color.White;
			this.panel3.Location = new Point(0, 22);
			this.panel3.Name = "panel3";
			this.panel3.Size = new Size(357, 40);
			this.panel3.TabIndex = 0;
			this.tbContent.Dock = DockStyle.Fill;
			this.tbContent.Font = new Font("굴림", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 129);
			this.tbContent.ForeColor = Color.Black;
			this.tbContent.Location = new Point(0, 0);
			this.tbContent.Multiline = true;
			this.tbContent.Name = "tbContent";
			this.tbContent.ScrollBars = ScrollBars.Vertical;
			this.tbContent.Size = new Size(357, 40);
			this.tbContent.TabIndex = 1;
			this.tbContent.KeyPress += this.tbContent_KeyPress;
			this.panel2.BorderStyle = BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.lbTitle);
			this.panel2.Dock = DockStyle.Top;
			this.panel2.ForeColor = Color.White;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(357, 22);
			this.panel2.TabIndex = 0;
			this.lbTitle.Dock = DockStyle.Fill;
			this.lbTitle.Font = new Font("굴림", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 129);
			this.lbTitle.ForeColor = Color.Black;
			this.lbTitle.Location = new Point(0, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new Size(355, 20);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "Title";
			this.lbTitle.TextAlign = ContentAlignment.MiddleLeft;
			this.panel5.BorderStyle = BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.cbYes);
			this.panel5.Controls.Add(this.label2);
			this.panel5.Dock = DockStyle.Right;
			this.panel5.ForeColor = Color.White;
			this.panel5.Location = new Point(357, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new Size(64, 62);
			this.panel5.TabIndex = 0;
			this.cbYes.CheckAlign = ContentAlignment.MiddleCenter;
			this.cbYes.Cursor = Cursors.Hand;
			this.cbYes.Dock = DockStyle.Fill;
			this.cbYes.Font = new Font("굴림", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 129);
			this.cbYes.Location = new Point(0, 22);
			this.cbYes.Name = "cbYes";
			this.cbYes.Size = new Size(62, 38);
			this.cbYes.TabIndex = 0;
			this.cbYes.UseVisualStyleBackColor = true;
			this.cbYes.CheckedChanged += this.cbYes_CheckedChanged;
			this.label2.Cursor = Cursors.Hand;
			this.label2.Dock = DockStyle.Top;
			this.label2.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, 129);
			this.label2.ForeColor = Color.Black;
			this.label2.Location = new Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(62, 22);
			this.label2.TabIndex = 0;
			this.label2.Text = "YES";
			this.label2.TextAlign = ContentAlignment.MiddleCenter;
			this.label2.Click += this.label2_Click;
			this.panel4.BorderStyle = BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.cbNo);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Dock = DockStyle.Right;
			this.panel4.ForeColor = Color.White;
			this.panel4.Location = new Point(421, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new Size(64, 62);
			this.panel4.TabIndex = 0;
			this.cbNo.CheckAlign = ContentAlignment.MiddleCenter;
			this.cbNo.Cursor = Cursors.Hand;
			this.cbNo.Dock = DockStyle.Fill;
			this.cbNo.Font = new Font("굴림", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 129);
			this.cbNo.Location = new Point(0, 22);
			this.cbNo.Name = "cbNo";
			this.cbNo.Size = new Size(62, 38);
			this.cbNo.TabIndex = 0;
			this.cbNo.UseVisualStyleBackColor = true;
			this.cbNo.CheckedChanged += this.cbNo_CheckedChanged;
			this.label3.Cursor = Cursors.Hand;
			this.label3.Dock = DockStyle.Top;
			this.label3.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, 129);
			this.label3.ForeColor = Color.Black;
			this.label3.Location = new Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(62, 22);
			this.label3.TabIndex = 0;
			this.label3.Text = "NO";
			this.label3.TextAlign = ContentAlignment.MiddleCenter;
			this.label3.Click += this.label3_Click;
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.panel1);
			this.ForeColor = Color.White;
			base.Name = "CVContent";
			base.Size = new Size(485, 62);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x040005C7 RID: 1479
		private bool _checkCheckBox = false;

		// Token: 0x040005C8 RID: 1480
		private IContainer components = null;

		// Token: 0x040005C9 RID: 1481
		private Panel panel1;

		// Token: 0x040005CA RID: 1482
		private Panel panel5;

		// Token: 0x040005CB RID: 1483
		private Panel panel4;

		// Token: 0x040005CC RID: 1484
		private Panel panel3;

		// Token: 0x040005CD RID: 1485
		private Panel panel2;

		// Token: 0x040005CE RID: 1486
		private Label lbTitle;

		// Token: 0x040005CF RID: 1487
		private TextBox tbContent;

		// Token: 0x040005D0 RID: 1488
		private Label label2;

		// Token: 0x040005D1 RID: 1489
		private Label label3;

		// Token: 0x040005D2 RID: 1490
		private CheckBox cbYes;

		// Token: 0x040005D3 RID: 1491
		private CheckBox cbNo;
	}
}
