using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Amkor.CADModules.DcolSummaryView.CommonClass;
using Amkor.CADModules.DcolSummaryView.Controls;
using Amkor.CADModules.DcolSummaryView.DataClass;
using ATDFW.Classes.Acount;
using ATDFW.Classes.CIMitar;
using ATDFW.Controls.BaseWinForm;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace Amkor.CADModules.DcolSummaryView
{
	// Token: 0x0200000D RID: 13
	public partial class DcolView : BaseWinView
	{
		// Token: 0x06000034 RID: 52 RVA: 0x00005E68 File Offset: 0x00004068
		public DcolView()
		{
			this._factorySetting = new FactorySettings();
			this._factorySetting._urlServer = "http://10.121.11.110/";
			this._factorySetting._startHour = 6;
			this._factorySetting._startMin = 0;
			this._cimitarMenu = new CIMitarMenu();
			this._cimitarMenu.menucode = 103001;
			this._cimitarUser = new CIMitarAccount();
			this._cimitarUser._exeExcel = false;
			this._cimitarUser._id = "wogud0609";
			this.InitializeComponent();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00005F30 File Offset: 0x00004130
		public DcolView(FactorySettings factorySetting, BaseWinMain basewinmain, CIMitarAccount cimitarUser, CIMitarMenu cimitarMenu)
		{
			this._factorySetting = factorySetting;
			this._baseWinMain = basewinmain;
			this._cimitarUser = cimitarUser;
			this._cimitarMenu = cimitarMenu;
			this.InitializeComponent();
			this.Text = this._cimitarMenu.name;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00005FB1 File Offset: 0x000041B1
		public void BarPrograssView()
		{
			this._barPrograss.ShowDialog();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00005FC0 File Offset: 0x000041C0
		private void ParameterAnalysis_Load(object sender, EventArgs e)
		{
			try
			{
				this._CommonQry._factorySetting = this._factorySetting;
				this.m_Data._CommonQry = this._CommonQry;
				this.strip = (this.radPageView1.ViewElement as RadPageViewStripElement);
				this.strip.NewItemVisibility = StripViewNewItemVisibility.End;
				this.radPageView1_NewPageRequested(null, null);
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000603C File Offset: 0x0000423C
		private void initViewerContorl(RadPageViewPage page)
		{
			try
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				for (int i = this.aFunction.Count - 1; i >= 0; i--)
				{
					string str = this.aFunction[i].ToString();
					Type type = executingAssembly.GetType("Amkor.CADModules.DcolSummaryView.DataView." + str);
					if (type != null && type.BaseType.Name == "UserControl")
					{
						object obj = Activator.CreateInstance(type);
						PropertyInfo property = type.GetProperty("Data");
						if (property != null)
						{
							property.SetValue(obj, this.m_Data);
							new DocumentWindow(type.Name);
							page.Controls.Add((Control)obj);
							page.Dock = DockStyle.Fill;
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00006128 File Offset: 0x00004328
		private void grid_Lot_CellClick(object sender, GridViewCellEventArgs e)
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000612A File Offset: 0x0000432A
		private void UnitDataAnalysis_FormClosing(object sender, FormClosingEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00006134 File Offset: 0x00004334
		private void radPageView1_NewPageRequested(object sender, EventArgs e)
		{
			RadPageViewPage radPageViewPage = new RadPageViewPage();
			radPageViewPage.Text = "Page " + (this.strip.Items.Count + 1);
			this.radPageView1.Pages.Add(radPageViewPage);
			this.radPageView1.SelectedPage = radPageViewPage;
			this.radPageView1.ViewElement.EnsureItemVisible(this.strip.NewItem);
			this.initViewerContorl(radPageViewPage);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000061AE File Offset: 0x000043AE
		private void btnSearch_Click(object sender, EventArgs e)
		{
			this.m_Data.sLot = this.txtLot.Text;
		}

		// Token: 0x04000040 RID: 64
		public cMainData m_Data = new cMainData();

		// Token: 0x04000041 RID: 65
		public CommonQuery _CommonQry = new CommonQuery();

		// Token: 0x04000042 RID: 66
		private Thread _thread;

		// Token: 0x04000043 RID: 67
		private RadPageViewStripElement strip;

		// Token: 0x04000044 RID: 68
		private BarPrograss _barPrograss = new BarPrograss();

		// Token: 0x04000045 RID: 69
		private ArrayList aFunction = new ArrayList
		{
			"DataView"
		};
	}
}
