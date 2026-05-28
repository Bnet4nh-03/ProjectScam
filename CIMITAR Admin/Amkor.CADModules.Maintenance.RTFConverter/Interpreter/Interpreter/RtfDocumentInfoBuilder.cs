using System;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Model;
using Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Support;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x0200008C RID: 140
	public sealed class RtfDocumentInfoBuilder : RtfElementVisitorBase
	{
		// Token: 0x06000464 RID: 1124 RVA: 0x0000C694 File Offset: 0x0000A894
		public RtfDocumentInfoBuilder(RtfDocumentInfo info) : base(RtfElementVisitorOrder.NonRecursive)
		{
			bool flag = info == null;
			if (flag)
			{
				throw new ArgumentNullException("info");
			}
			this.info = info;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0000C6DB File Offset: 0x0000A8DB
		public void Reset()
		{
			this.info.Reset();
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0000C6EC File Offset: 0x0000A8EC
		protected override void DoVisitGroup(IRtfGroup group)
		{
			string destination = group.Destination;
			uint num = <PrivateImplementationDetails>.ComputeStringHash(destination);
			if (num <= 1349246118U)
			{
				if (num <= 684675452U)
				{
					if (num <= 413797721U)
					{
						if (num != 263456517U)
						{
							if (num == 413797721U)
							{
								if (destination == "doccomm")
								{
									this.info.DocumentComment = this.ExtractGroupText(group);
								}
							}
						}
						else if (destination == "info")
						{
							base.VisitGroupChildren(group);
						}
					}
					else if (num != 437767012U)
					{
						if (num == 684675452U)
						{
							if (destination == "creatim")
							{
								this.info.CreationTime = new DateTime?(this.ExtractTimestamp(group));
							}
						}
					}
					else if (destination == "revtim")
					{
						this.info.RevisionTime = new DateTime?(this.ExtractTimestamp(group));
					}
				}
				else if (num <= 1002009594U)
				{
					if (num != 991397836U)
					{
						if (num == 1002009594U)
						{
							if (destination == "printim")
							{
								this.info.PrintTime = new DateTime?(this.ExtractTimestamp(group));
							}
						}
					}
					else if (destination == "manager")
					{
						this.info.Manager = this.ExtractGroupText(group);
					}
				}
				else if (num != 1333443158U)
				{
					if (num == 1349246118U)
					{
						if (destination == "buptim")
						{
							this.info.BackupTime = new DateTime?(this.ExtractTimestamp(group));
						}
					}
				}
				else if (destination == "author")
				{
					this.info.Author = this.ExtractGroupText(group);
				}
			}
			else if (num <= 2556802313U)
			{
				if (num <= 1832983798U)
				{
					if (num != 1738982494U)
					{
						if (num == 1832983798U)
						{
							if (destination == "hlinkbase")
							{
								this.info.HyperLinkbase = this.ExtractGroupText(group);
							}
						}
					}
					else if (destination == "comment")
					{
						this.info.Comment = this.ExtractGroupText(group);
					}
				}
				else if (num != 2300378703U)
				{
					if (num == 2556802313U)
					{
						if (destination == "title")
						{
							this.info.Title = this.ExtractGroupText(group);
						}
					}
				}
				else if (destination == "subject")
				{
					this.info.Subject = this.ExtractGroupText(group);
				}
			}
			else if (num <= 3475980913U)
			{
				if (num != 2858608828U)
				{
					if (num == 3475980913U)
					{
						if (destination == "category")
						{
							this.info.Category = this.ExtractGroupText(group);
						}
					}
				}
				else if (destination == "company")
				{
					this.info.Company = this.ExtractGroupText(group);
				}
			}
			else if (num != 4210524501U)
			{
				if (num == 4225036029U)
				{
					if (destination == "operator")
					{
						this.info.Operator = this.ExtractGroupText(group);
					}
				}
			}
			else if (destination == "keywords")
			{
				this.info.Keywords = this.ExtractGroupText(group);
			}
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0000CAEC File Offset: 0x0000ACEC
		protected override void DoVisitTag(IRtfTag tag)
		{
			string name = tag.Name;
			uint num = <PrivateImplementationDetails>.ComputeStringHash(name);
			if (num <= 926444256U)
			{
				if (num != 466782324U)
				{
					if (num != 886831229U)
					{
						if (num == 926444256U)
						{
							if (name == "id")
							{
								this.info.Id = new int?(tag.ValueAsNumber);
							}
						}
					}
					else if (name == "nofwords")
					{
						this.info.NumberOfWords = new int?(tag.ValueAsNumber);
					}
				}
				else if (name == "nofpages")
				{
					this.info.NumberOfPages = new int?(tag.ValueAsNumber);
				}
			}
			else if (num <= 1798968713U)
			{
				if (num != 1181855383U)
				{
					if (num == 1798968713U)
					{
						if (name == "edmins")
						{
							this.info.EditingTimeInMinutes = new int?(tag.ValueAsNumber);
						}
					}
				}
				else if (name == "version")
				{
					this.info.Version = new int?(tag.ValueAsNumber);
				}
			}
			else if (num != 2572619433U)
			{
				if (num == 3728026500U)
				{
					if (name == "vern")
					{
						this.info.Revision = new int?(tag.ValueAsNumber);
					}
				}
			}
			else if (name == "nofchars")
			{
				this.info.NumberOfCharacters = new int?(tag.ValueAsNumber);
			}
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0000CCB8 File Offset: 0x0000AEB8
		private string ExtractGroupText(IRtfGroup group)
		{
			this.textBuilder.Reset();
			this.textBuilder.VisitGroup(group);
			return this.textBuilder.CombinedText;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0000CCF0 File Offset: 0x0000AEF0
		private DateTime ExtractTimestamp(IRtfGroup group)
		{
			this.timestampBuilder.Reset();
			this.timestampBuilder.VisitGroup(group);
			return this.timestampBuilder.CreateTimestamp();
		}

		// Token: 0x04000197 RID: 407
		private readonly RtfDocumentInfo info;

		// Token: 0x04000198 RID: 408
		private readonly RtfTextBuilder textBuilder = new RtfTextBuilder();

		// Token: 0x04000199 RID: 409
		private readonly RtfTimestampBuilder timestampBuilder = new RtfTimestampBuilder();
	}
}
