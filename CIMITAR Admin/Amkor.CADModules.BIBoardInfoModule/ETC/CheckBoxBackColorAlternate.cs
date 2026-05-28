using System;
using System.Drawing;
using DevAge.Drawing.VisualElements;
using SourceGrid;
using SourceGrid.Cells.Views;

namespace ETC
{
	// Token: 0x02000005 RID: 5
	public class CheckBoxBackColorAlternate : SourceGrid.Cells.Views.CheckBox
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00003944 File Offset: 0x00001B44
		public CheckBoxBackColorAlternate(Color firstColor, Color secondColor)
		{
			this.FirstBackground = new BackgroundSolid(firstColor);
			this.SecondBackground = new BackgroundSolid(secondColor);
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00003964 File Offset: 0x00001B64
		// (set) Token: 0x06000016 RID: 22 RVA: 0x0000396C File Offset: 0x00001B6C
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

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00003975 File Offset: 0x00001B75
		// (set) Token: 0x06000018 RID: 24 RVA: 0x0000397D File Offset: 0x00001B7D
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

		// Token: 0x06000019 RID: 25 RVA: 0x00003988 File Offset: 0x00001B88
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

		// Token: 0x0400000E RID: 14
		private IVisualElement mFirstBackground;

		// Token: 0x0400000F RID: 15
		private IVisualElement mSecondBackground;
	}
}
