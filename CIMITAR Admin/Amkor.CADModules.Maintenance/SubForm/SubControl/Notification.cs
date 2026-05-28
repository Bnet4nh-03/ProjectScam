using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x02000038 RID: 56
	public partial class Notification : Form
	{
		// Token: 0x06000386 RID: 902 RVA: 0x0006B9D2 File Offset: 0x00069BD2
		private void btnNo_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0006B9DC File Offset: 0x00069BDC
		private void btnYes_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0006B9E8 File Offset: 0x00069BE8
		public Notification(string mainText, string subText, string buttonText, string subButtonText, Icon icon, bool isNotes = false)
		{
			this.InitializeComponent();
			bool flag = mainText.Trim().Length == 0;
			if (flag)
			{
				this.lbMainTitle.Visible = false;
				this.tbSubTitle.Dock = DockStyle.Fill;
			}
			else
			{
				mainText = mainText.Replace("\\n", Environment.NewLine);
				this.lbMainTitle.Text = mainText;
			}
			bool flag2 = subText.Trim().Length == 0;
			if (flag2)
			{
				this.tbSubTitle.Visible = false;
				this.lbMainTitle.Dock = DockStyle.Fill;
			}
			else
			{
				subText = subText.Replace("\\n", Environment.NewLine);
				this.tbSubTitle.Text = subText;
				this.tbSubTitle.SelectionStart = 0;
				if (isNotes)
				{
					base.Size = new Size(900, 400);
					this.tbSubTitle.TextAlign = HorizontalAlignment.Left;
					this.tbSubTitle.ScrollBars = ScrollBars.Vertical;
				}
			}
			bool flag3 = string.IsNullOrEmpty(buttonText);
			if (flag3)
			{
				this.btnYes.Visible = false;
			}
			else
			{
				this.btnYes.Text = buttonText.Trim();
			}
			bool flag4 = string.IsNullOrEmpty(subButtonText);
			if (flag4)
			{
				this.btnNo.Visible = false;
			}
			else
			{
				this.btnNo.Text = subButtonText.Trim();
			}
			this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			this.pictureBox1.Anchor = AnchorStyles.None;
			this.CenterPictureBox(this.pictureBox1, icon.ToBitmap());
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0006BB73 File Offset: 0x00069D73
		private void CenterPictureBox(PictureBox picBox, Bitmap picImage)
		{
			picBox.Image = picImage;
			picBox.Refresh();
		}
	}
}
