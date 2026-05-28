using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Amkor.CADModules.Maintenance.SubForm.SubControl
{
	// Token: 0x0200003A RID: 58
	public partial class Export : Form
	{
		// Token: 0x060003A0 RID: 928 RVA: 0x0006D1F4 File Offset: 0x0006B3F4
		public Export(string type, int index)
		{
			this.InitializeComponent();
			this._index = index;
			this.radioButton1.Tag = "1";
			this.radioButton3.Tag = "2";
			this._selectList.Add(this.radioButton1);
			this._selectList.Add(this.radioButton3);
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00061297 File Offset: 0x0005F497
		private void button1_Click_1(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0006D278 File Offset: 0x0006B478
		private void button2_Click(object sender, EventArgs e)
		{
			foreach (RadioButton radioButton in this._selectList)
			{
				bool @checked = radioButton.Checked;
				if (@checked)
				{
					string a = radioButton.Tag.ToString();
					if (!(a == "1"))
					{
						if (a == "2")
						{
							int index = this._index;
							if (index != 0)
							{
								if (index == 1)
								{
									base.Tag = "4";
								}
							}
							else
							{
								base.Tag = "2";
							}
						}
					}
					else
					{
						int index2 = this._index;
						if (index2 != 0)
						{
							if (index2 == 1)
							{
								base.Tag = "3";
							}
						}
						else
						{
							base.Tag = "1";
						}
					}
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x040005D4 RID: 1492
		public List<RadioButton> _selectList = new List<RadioButton>();

		// Token: 0x040005D5 RID: 1493
		public int _index = -1;
	}
}
