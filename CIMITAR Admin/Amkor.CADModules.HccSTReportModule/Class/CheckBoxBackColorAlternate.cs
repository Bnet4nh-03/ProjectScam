using System;
using System.Drawing;
using DevAge.Drawing.VisualElements;
using SourceGrid;
using SourceGrid.Cells.Views;

namespace Amkor.CADModules.HccSTReportModule.Class
{
	// Token: 0x0200002E RID: 46
	public class CheckBoxBackColorAlternate : SourceGrid.Cells.Views.CheckBox
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x0001A386 File Offset: 0x00018586
		public CheckBoxBackColorAlternate(Color firstColor, Color secondColor)
		{
			this.FirstBackground = new BackgroundSolid(firstColor);
			this.SecondBackground = new BackgroundSolid(secondColor);
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x0001A3A6 File Offset: 0x000185A6
		// (set) Token: 0x060000E9 RID: 233 RVA: 0x0001A3AE File Offset: 0x000185AE
		public IVisualElement FirstBackground
		{
			get
			{
				return this.mFirstBackground;
			}
			set
			{
				this.mFirstBackground = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000EA RID: 234 RVA: 0x0001A3B7 File Offset: 0x000185B7
		// (set) Token: 0x060000EB RID: 235 RVA: 0x0001A3BF File Offset: 0x000185BF
		public IVisualElement SecondBackground
		{
			get
			{
				return this.mSecondBackground;
			}
			set
			{
				this.mSecondBackground = value;
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0001A3C8 File Offset: 0x000185C8
		protected override void PrepareView(CellContext context)
		{
			base.PrepareView(context);
			if (Math.IEEERemainder((double)context.Position.Row, 2.0) == 0.0)
			{
				base.Background = this.FirstBackground;
				return;
			}
			base.Background = this.SecondBackground;
		}

		// Token: 0x04000259 RID: 601
		private IVisualElement mFirstBackground;

		// Token: 0x0400025A RID: 602
		private IVisualElement mSecondBackground;
	}
}
