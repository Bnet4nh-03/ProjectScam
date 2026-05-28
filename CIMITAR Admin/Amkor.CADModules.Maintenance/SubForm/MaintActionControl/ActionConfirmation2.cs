using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Amkor.CADModules.Maintenance.GrobalConst;
using Amkor.CADModules.Maintenance.GrobalConst.Class;
using Amkor.CADModules.Maintenance.SubForm.SubControl;
using ATDFW.Classes.CIMitar;

namespace Amkor.CADModules.Maintenance.SubForm.MaintActionControl
{
	// Token: 0x02000044 RID: 68
	public class ActionConfirmation2 : UserControl
	{
		// Token: 0x060003EA RID: 1002 RVA: 0x00074B68 File Offset: 0x00072D68
		public ActionConfirmation2(FactorySettings factorySettings, cReportItem report)
		{
			cConst._listConfir.Clear();
			this.InitializeComponent();
			bool flag = report.sCategory == "HCC";
			if (flag)
			{
				cConst.initContents(factorySettings, report.sFactory, report.sModel);
			}
			else
			{
				cConst.initContents(factorySettings, report.sFactory, report.sCategory);
			}
			this.Dock = DockStyle.Fill;
			int num = 1;
			foreach (KeyValuePair<int, string> keyValuePair in cConst.listContents)
			{
				bool flag2 = keyValuePair.Key - 1 >= report.listDetails.Count;
				if (!flag2)
				{
					bool flag3 = report.sReportStauts == "2";
					confir confir;
					if (flag3)
					{
						confir = new confir(num, keyValuePair.Key, new CVContent(this.panel2, num.ToString() + "." + keyValuePair.Value, report.listDetails[keyValuePair.Key - 1], report.listDetails[keyValuePair.Key - 1].Trim() != string.Empty));
					}
					else
					{
						confir = new confir(num, keyValuePair.Key, new CVContent(this.panel2, num.ToString() + "." + keyValuePair.Value));
					}
					((CVContent)confir.viewer).Height = 30;
					cConst._listConfir.Add(confir);
					num++;
				}
			}
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00074D38 File Offset: 0x00072F38
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00074D70 File Offset: 0x00072F70
		private void InitializeComponent()
		{
			this.panel2 = new Panel();
			base.SuspendLayout();
			this.panel2.AutoScroll = true;
			this.panel2.Dock = DockStyle.Fill;
			this.panel2.Location = new Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new Size(316, 317);
			this.panel2.TabIndex = 43;
			base.AutoScaleDimensions = new SizeF(7f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.panel2);
			base.Name = "ActionConfirmation2";
			base.Size = new Size(316, 317);
			base.ResumeLayout(false);
		}

		// Token: 0x04000634 RID: 1588
		private IContainer components = null;

		// Token: 0x04000635 RID: 1589
		private Panel panel2;
	}
}
