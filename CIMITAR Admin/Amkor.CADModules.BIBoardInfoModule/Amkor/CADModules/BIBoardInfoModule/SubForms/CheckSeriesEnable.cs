using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.BIBoardInfoModule.Properties;
using DATA;

namespace Amkor.CADModules.BIBoardInfoModule.SubForms
{
	// Token: 0x02000026 RID: 38
	public partial class CheckSeriesEnable : Form
	{
		// Token: 0x060000DD RID: 221 RVA: 0x00013C24 File Offset: 0x00011E24
		public CheckSeriesEnable()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00013C32 File Offset: 0x00011E32
		public CheckSeriesEnable(List<CSrsInfo> cSrsInfos)
		{
			this.InitializeComponent();
			this._cSrsInfos = cSrsInfos;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000055FE File Offset: 0x000037FE
		private void CheckSeriesEnable_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				base.Close();
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00013C47 File Offset: 0x00011E47
		private void CheckSeriesEnable_Load(object sender, EventArgs e)
		{
			this.Init();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00013C50 File Offset: 0x00011E50
		private void Init()
		{
			int num = 0;
			foreach (CSrsInfo csrsInfo in this._cSrsInfos)
			{
				CheckBox checkBox = new CheckBox();
				checkBox.AutoSize = true;
				checkBox.Location = new Point(16, 22);
				checkBox.Name = csrsInfo.strSrsName + "_CheckBox";
				checkBox.Size = new Size(83, 19);
				checkBox.TabIndex = 0;
				checkBox.Text = "Visible";
				checkBox.UseVisualStyleBackColor = true;
				checkBox.Checked = csrsInfo.isVisible;
				RadioButton radioButton = new RadioButton();
				radioButton.AutoSize = true;
				radioButton.Location = new Point(100, 21);
				radioButton.Name = csrsInfo.strSrsName + "_RB_Line";
				radioButton.Size = new Size(47, 19);
				radioButton.TabIndex = 1;
				radioButton.TabStop = true;
				radioButton.Text = "Line";
				radioButton.UseVisualStyleBackColor = true;
				if (csrsInfo.iChartType == 3)
				{
					radioButton.Checked = true;
				}
				RadioButton radioButton2 = new RadioButton();
				radioButton2.AutoSize = true;
				radioButton2.Location = new Point(153, 21);
				radioButton2.Name = csrsInfo.strSrsName + "_RB_StackedColunm";
				radioButton2.Size = new Size(109, 19);
				radioButton2.TabIndex = 1;
				radioButton2.TabStop = true;
				radioButton2.Text = "StackedColumn";
				radioButton2.UseVisualStyleBackColor = true;
				if (csrsInfo.iChartType == 11)
				{
					radioButton2.Checked = true;
				}
				GroupBox groupBox = new GroupBox();
				groupBox.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
				groupBox.Controls.Add(checkBox);
				groupBox.Controls.Add(radioButton);
				groupBox.Controls.Add(radioButton2);
				groupBox.Location = new Point(12, 12 + num);
				groupBox.Name = csrsInfo.strSrsName + "_groupBox";
				groupBox.Size = new Size(271, 50);
				groupBox.TabIndex = 0;
				groupBox.TabStop = false;
				groupBox.Text = csrsInfo.strSrsName;
				base.Controls.Add(groupBox);
				num += 50;
			}
			int height = base.Height + 50 * (this._cSrsInfos.Count - 1);
			base.Height = height;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00013EE0 File Offset: 0x000120E0
		private void pb_Save_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00013EE0 File Offset: 0x000120E0
		private void pb_Save_MouseLeave(object sender, EventArgs e)
		{
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00013EE0 File Offset: 0x000120E0
		private void pb_Save_MouseMove(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00013EE4 File Offset: 0x000120E4
		private void pb_Save_MouseUp(object sender, MouseEventArgs e)
		{
			foreach (CSrsInfo csrsInfo in this._cSrsInfos)
			{
				foreach (object obj in base.Controls)
				{
					if (obj.GetType() == typeof(GroupBox))
					{
						foreach (object obj2 in ((GroupBox)obj).Controls)
						{
							if (obj2.GetType() == typeof(CheckBox))
							{
								CheckBox checkBox = (CheckBox)obj2;
								if (checkBox.Name == csrsInfo.strSrsName + "_CheckBox")
								{
									csrsInfo.isVisible = checkBox.Checked;
								}
							}
							if (obj2.GetType() == typeof(RadioButton))
							{
								RadioButton radioButton = (RadioButton)obj2;
								if (radioButton.Name == csrsInfo.strSrsName + "_RB_Line")
								{
									if (radioButton.Checked)
									{
										csrsInfo.iChartType = 3;
									}
									else
									{
										csrsInfo.iChartType = 11;
									}
								}
							}
						}
					}
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x0400019E RID: 414
		private List<CSrsInfo> _cSrsInfos;
	}
}
