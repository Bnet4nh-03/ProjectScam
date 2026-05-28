using System;
using System.Drawing;
using DevAge.Drawing.VisualElements;
using SourceGrid;
using SourceGrid.Cells.Views;

namespace CommonLibrary
{
	// Token: 0x02000010 RID: 16
	public class CheckBoxBackColorAlternate : SourceGrid.Cells.Views.CheckBox
	{
		// Token: 0x06000083 RID: 131 RVA: 0x0000827A File Offset: 0x0000647A
		public CheckBoxBackColorAlternate(Color firstColor, Color secondColor)
		{
			this.FirstBackground = new BackgroundSolid(firstColor);
			this.SecondBackground = new BackgroundSolid(secondColor);
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000084 RID: 132 RVA: 0x0000829A File Offset: 0x0000649A
		// (set) Token: 0x06000085 RID: 133 RVA: 0x000082A2 File Offset: 0x000064A2
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

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000086 RID: 134 RVA: 0x000082AB File Offset: 0x000064AB
		// (set) Token: 0x06000087 RID: 135 RVA: 0x000082B3 File Offset: 0x000064B3
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

		// Token: 0x06000088 RID: 136 RVA: 0x000082BC File Offset: 0x000064BC
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

		// Token: 0x04000076 RID: 118
		private IVisualElement mFirstBackground;

		// Token: 0x04000077 RID: 119
		private IVisualElement mSecondBackground;
	}
}
