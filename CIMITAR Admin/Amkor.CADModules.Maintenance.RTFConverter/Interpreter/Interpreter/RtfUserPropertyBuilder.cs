using System;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x0200009B RID: 155
	public sealed class RtfUserPropertyBuilder : RtfElementVisitorBase
	{
		// Token: 0x06000515 RID: 1301 RVA: 0x00010AD0 File Offset: 0x0000ECD0
		public RtfUserPropertyBuilder(RtfDocumentPropertyCollection collectedProperties) : base(RtfElementVisitorOrder.NonRecursive)
		{
			bool flag = collectedProperties == null;
			if (flag)
			{
				throw new ArgumentNullException("collectedProperties");
			}
			this.collectedProperties = collectedProperties;
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x00010B0C File Offset: 0x0000ED0C
		public IRtfDocumentProperty CreateProperty()
		{
			return new RtfDocumentProperty(this.propertyTypeCode, this.propertyName, this.staticValue, this.linkValue);
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00010B3B File Offset: 0x0000ED3B
		public void Reset()
		{
			this.propertyTypeCode = 0;
			this.propertyName = null;
			this.staticValue = null;
			this.linkValue = null;
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00010B5C File Offset: 0x0000ED5C
		protected override void DoVisitGroup(IRtfGroup group)
		{
			string destination = group.Destination;
			if (!(destination == "userprops"))
			{
				if (destination != null)
				{
					if (!(destination == "propname"))
					{
						if (!(destination == "staticval"))
						{
							if (destination == "linkval")
							{
								this.textBuilder.Reset();
								this.textBuilder.VisitGroup(group);
								this.linkValue = this.textBuilder.CombinedText;
							}
						}
						else
						{
							this.textBuilder.Reset();
							this.textBuilder.VisitGroup(group);
							this.staticValue = this.textBuilder.CombinedText;
						}
					}
					else
					{
						this.textBuilder.Reset();
						this.textBuilder.VisitGroup(group);
						this.propertyName = this.textBuilder.CombinedText;
					}
				}
				else
				{
					this.Reset();
					base.VisitGroupChildren(group);
					this.collectedProperties.Add(this.CreateProperty());
				}
			}
			else
			{
				base.VisitGroupChildren(group);
			}
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00010C68 File Offset: 0x0000EE68
		protected override void DoVisitTag(IRtfTag tag)
		{
			string name = tag.Name;
			if (name == "proptype")
			{
				this.propertyTypeCode = tag.ValueAsNumber;
			}
		}

		// Token: 0x040001DF RID: 479
		private readonly RtfDocumentPropertyCollection collectedProperties;

		// Token: 0x040001E0 RID: 480
		private readonly RtfTextBuilder textBuilder = new RtfTextBuilder();

		// Token: 0x040001E1 RID: 481
		private int propertyTypeCode;

		// Token: 0x040001E2 RID: 482
		private string propertyName;

		// Token: 0x040001E3 RID: 483
		private string staticValue;

		// Token: 0x040001E4 RID: 484
		private string linkValue;
	}
}
