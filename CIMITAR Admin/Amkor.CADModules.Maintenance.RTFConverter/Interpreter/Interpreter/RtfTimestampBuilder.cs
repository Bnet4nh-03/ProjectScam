using System;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x0200009A RID: 154
	public sealed class RtfTimestampBuilder : RtfElementVisitorBase
	{
		// Token: 0x06000511 RID: 1297 RVA: 0x00010995 File Offset: 0x0000EB95
		public RtfTimestampBuilder() : base(RtfElementVisitorOrder.BreadthFirst)
		{
			this.Reset();
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x000109A7 File Offset: 0x0000EBA7
		public void Reset()
		{
			this.year = 1970;
			this.month = 1;
			this.day = 1;
			this.hour = 0;
			this.minutes = 0;
			this.seconds = 0;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x000109D8 File Offset: 0x0000EBD8
		public DateTime CreateTimestamp()
		{
			return new DateTime(this.year, this.month, this.day, this.hour, this.minutes, this.seconds);
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00010A14 File Offset: 0x0000EC14
		protected override void DoVisitTag(IRtfTag tag)
		{
			string name = tag.Name;
			if (!(name == "yr"))
			{
				if (!(name == "mo"))
				{
					if (!(name == "dy"))
					{
						if (!(name == "hr"))
						{
							if (!(name == "min"))
							{
								if (name == "sec")
								{
									this.seconds = tag.ValueAsNumber;
								}
							}
							else
							{
								this.minutes = tag.ValueAsNumber;
							}
						}
						else
						{
							this.hour = tag.ValueAsNumber;
						}
					}
					else
					{
						this.day = tag.ValueAsNumber;
					}
				}
				else
				{
					this.month = tag.ValueAsNumber;
				}
			}
			else
			{
				this.year = tag.ValueAsNumber;
			}
		}

		// Token: 0x040001D9 RID: 473
		private int year;

		// Token: 0x040001DA RID: 474
		private int month;

		// Token: 0x040001DB RID: 475
		private int day;

		// Token: 0x040001DC RID: 476
		private int hour;

		// Token: 0x040001DD RID: 477
		private int minutes;

		// Token: 0x040001DE RID: 478
		private int seconds;
	}
}
