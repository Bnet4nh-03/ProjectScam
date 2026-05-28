using System;

namespace Amkor.CADModules.Maintenance.RTFConverter.Interpreter.Interpreter
{
	// Token: 0x02000090 RID: 144
	public sealed class RtfInterpreter : RtfInterpreterBase, IRtfElementVisitor
	{
		// Token: 0x0600048A RID: 1162 RVA: 0x0000DB6C File Offset: 0x0000BD6C
		public RtfInterpreter(params IRtfInterpreterListener[] listeners) : base(new RtfInterpreterSettings(), listeners)
		{
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0000DB7C File Offset: 0x0000BD7C
		public RtfInterpreter(IRtfInterpreterSettings settings, params IRtfInterpreterListener[] listeners) : base(settings, listeners)
		{
			this.fontTableBuilder = new RtfFontTableBuilder(base.Context.WritableFontTable, settings.IgnoreDuplicatedFonts);
			this.colorTableBuilder = new RtfColorTableBuilder(base.Context.WritableColorTable);
			this.documentInfoBuilder = new RtfDocumentInfoBuilder(base.Context.WritableDocumentInfo);
			this.userPropertyBuilder = new RtfUserPropertyBuilder(base.Context.WritableUserProperties);
			this.imageBuilder = new RtfImageBuilder();
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0000DBFC File Offset: 0x0000BDFC
		public static bool IsSupportedDocument(IRtfGroup rtfDocument)
		{
			try
			{
				RtfInterpreter.GetSupportedDocument(rtfDocument);
			}
			catch (RtfException)
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x0000DC30 File Offset: 0x0000BE30
		public static IRtfGroup GetSupportedDocument(IRtfGroup rtfDocument)
		{
			bool flag = rtfDocument == null;
			if (flag)
			{
				throw new ArgumentNullException("rtfDocument");
			}
			bool flag2 = rtfDocument.Contents.Count == 0;
			if (flag2)
			{
				throw new RtfEmptyDocumentException(Strings.EmptyDocument);
			}
			IRtfElement rtfElement = rtfDocument.Contents[0];
			bool flag3 = rtfElement.Kind > RtfElementKind.Tag;
			if (flag3)
			{
				throw new RtfStructureException(Strings.MissingDocumentStartTag);
			}
			IRtfTag rtfTag = (IRtfTag)rtfElement;
			bool flag4 = !"rtf".Equals(rtfTag.Name);
			if (flag4)
			{
				throw new RtfStructureException(Strings.InvalidDocumentStartTag("rtf"));
			}
			bool flag5 = !rtfTag.HasValue;
			if (flag5)
			{
				throw new RtfUnsupportedStructureException(Strings.MissingRtfVersion);
			}
			bool flag6 = rtfTag.ValueAsNumber != 1;
			if (flag6)
			{
				throw new RtfUnsupportedStructureException(Strings.UnsupportedRtfVersion(rtfTag.ValueAsNumber));
			}
			return rtfDocument;
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0000DD0F File Offset: 0x0000BF0F
		protected override void DoInterpret(IRtfGroup rtfDocument)
		{
			this.InterpretContents(RtfInterpreter.GetSupportedDocument(rtfDocument));
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0000DD1F File Offset: 0x0000BF1F
		private void InterpretContents(IRtfGroup rtfDocument)
		{
			base.Context.Reset();
			this.lastGroupWasPictureWrapper = false;
			base.NotifyBeginDocument();
			this.VisitChildrenOf(rtfDocument);
			base.Context.State = RtfInterpreterState.Ended;
			base.NotifyEndDocument();
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0000DD58 File Offset: 0x0000BF58
		private void VisitChildrenOf(IRtfGroup group)
		{
			bool flag = false;
			bool flag2 = base.Context.State == RtfInterpreterState.InDocument;
			if (flag2)
			{
				base.Context.PushCurrentTextFormat();
				flag = true;
			}
			try
			{
				foreach (object obj in group.Contents)
				{
					IRtfElement rtfElement = (IRtfElement)obj;
					rtfElement.Visit(this);
				}
			}
			finally
			{
				bool flag3 = flag;
				if (flag3)
				{
					base.Context.PopCurrentTextFormat();
				}
			}
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0000DE08 File Offset: 0x0000C008
		void IRtfElementVisitor.VisitTag(IRtfTag tag)
		{
			bool flag = base.Context.State != RtfInterpreterState.InDocument;
			if (flag)
			{
				bool flag2 = base.Context.FontTable.Count > 0;
				if (flag2)
				{
					bool flag3 = base.Context.ColorTable.Count > 0 || "viewkind".Equals(tag.Name);
					if (flag3)
					{
						base.Context.State = RtfInterpreterState.InDocument;
					}
				}
			}
			switch (base.Context.State)
			{
			case RtfInterpreterState.Init:
			{
				bool flag4 = "rtf".Equals(tag.Name);
				if (!flag4)
				{
					throw new RtfStructureException(Strings.InvalidInitTagState(tag.ToString()));
				}
				base.Context.State = RtfInterpreterState.InHeader;
				base.Context.RtfVersion = tag.ValueAsNumber;
				break;
			}
			case RtfInterpreterState.InHeader:
			{
				string name = tag.Name;
				if (name == "deff")
				{
					base.Context.DefaultFontId = "f" + tag.ValueAsNumber;
				}
				break;
			}
			case RtfInterpreterState.InDocument:
			{
				string name2 = tag.Name;
				uint num = <PrivateImplementationDetails>.ComputeStringHash(name2);
				if (num <= 2170419830U)
				{
					if (num <= 1495897564U)
					{
						if (num <= 1128467232U)
						{
							if (num <= 480244007U)
							{
								if (num != 400234023U)
								{
									if (num != 480244007U)
									{
										break;
									}
									if (!(name2 == "highlight"))
									{
										break;
									}
									goto IL_BC9;
								}
								else
								{
									if (!(name2 == "line"))
									{
										break;
									}
									base.NotifyInsertBreak(RtfVisualBreakKind.Line);
									break;
								}
							}
							else if (num != 632598351U)
							{
								if (num != 671913016U)
								{
									if (num != 1128467232U)
									{
										break;
									}
									if (!(name2 == "up"))
									{
										break;
									}
									int num2 = tag.ValueAsNumber;
									bool flag5 = num2 == 0;
									if (flag5)
									{
										num2 = 6;
									}
									base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithSuperScript(num2);
									break;
								}
								else
								{
									if (!(name2 == "-"))
									{
										break;
									}
									base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.OptionalHyphen);
									break;
								}
							}
							else
							{
								if (!(name2 == "strike"))
								{
									break;
								}
								bool derivedStrikeThrough = !tag.HasValue || tag.ValueAsNumber != 0;
								base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithStrikeThrough(derivedStrikeThrough);
								break;
							}
						}
						else if (num <= 1428787088U)
						{
							if (num != 1131883462U)
							{
								if (num != 1428787088U)
								{
									break;
								}
								if (!(name2 == "cb"))
								{
									break;
								}
								goto IL_BC9;
							}
							else
							{
								if (!(name2 == "ulnone"))
								{
									break;
								}
								base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithUnderline(false);
								break;
							}
						}
						else if (num != 1445123422U)
						{
							if (num != 1457505901U)
							{
								if (num != 1495897564U)
								{
									break;
								}
								if (!(name2 == "cf"))
								{
									break;
								}
								goto IL_BC9;
							}
							else
							{
								if (!(name2 == "lquote"))
								{
									break;
								}
								base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.LeftSingleQuote);
								break;
							}
						}
						else
						{
							if (!(name2 == "fs"))
							{
								break;
							}
							int valueAsNumber = tag.ValueAsNumber;
							bool flag6 = valueAsNumber >= 0;
							if (flag6)
							{
								base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithFontSize(valueAsNumber);
								break;
							}
							throw new RtfInvalidDataException(Strings.InvalidFontSize(valueAsNumber));
						}
					}
					else if (num <= 1666584168U)
					{
						if (num <= 1598240564U)
						{
							if (num != 1565273706U)
							{
								if (num != 1598240564U)
								{
									break;
								}
								if (!(name2 == "ul"))
								{
									break;
								}
								bool derivedUnderline = !tag.HasValue || tag.ValueAsNumber != 0;
								base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithUnderline(derivedUnderline);
								break;
							}
							else
							{
								if (!(name2 == "qr"))
								{
									break;
								}
								base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithAlignment(RtfTextAlignment.Right);
								break;
							}
						}
						else if (num != 1598828944U)
						{
							if (num != 1662835111U)
							{
								if (num != 1666584168U)
								{
									break;
								}
								if (!(name2 == "par"))
								{
									break;
								}
								base.NotifyInsertBreak(RtfVisualBreakKind.Paragraph);
								break;
							}
							else
							{
								if (!(name2 == "dn"))
								{
									break;
								}
								int num3 = tag.ValueAsNumber;
								bool flag7 = num3 == 0;
								if (flag7)
								{
									num3 = 6;
								}
								base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithSuperScript(-num3);
								break;
							}
						}
						else
						{
							if (!(name2 == "ql"))
							{
								break;
							}
							base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithAlignment(RtfTextAlignment.Left);
							break;
						}
					}
					else if (num <= 1806694916U)
					{
						if (num != 1683285682U)
						{
							if (num != 1699494658U)
							{
								if (num != 1806694916U)
								{
									break;
								}
								if (!(name2 == "enspace"))
								{
									break;
								}
								base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.EnSpace);
								break;
							}
							else
							{
								if (!(name2 == "qj"))
								{
									break;
								}
								base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithAlignment(RtfTextAlignment.Justify);
								break;
							}
						}
						else
						{
							if (!(name2 == "sect"))
							{
								break;
							}
							base.NotifyInsertBreak(RtfVisualBreakKind.Section);
							break;
						}
					}
					else if (num != 1819811044U)
					{
						if (num != 1850493229U)
						{
							if (num != 2170419830U)
							{
								break;
							}
							if (!(name2 == "page"))
							{
								break;
							}
							base.NotifyInsertBreak(RtfVisualBreakKind.Page);
							break;
						}
						else
						{
							if (!(name2 == "qc"))
							{
								break;
							}
							base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithAlignment(RtfTextAlignment.Center);
							break;
						}
					}
					else if (!(name2 == "pard"))
					{
						break;
					}
				}
				else if (num <= 3658226030U)
				{
					if (num <= 3242461418U)
					{
						if (num <= 2566336076U)
						{
							if (num != 2328620175U)
							{
								if (num != 2566336076U)
								{
									break;
								}
								if (!(name2 == "tab"))
								{
									break;
								}
								base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.Tabulator);
								break;
							}
							else
							{
								if (!(name2 == "qmspace"))
								{
									break;
								}
								base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.QmSpace);
								break;
							}
						}
						else if (num != 2861155257U)
						{
							if (num != 3008542559U)
							{
								if (num != 3242461418U)
								{
									break;
								}
								if (!(name2 == "endash"))
								{
									break;
								}
								base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.EnDash);
								break;
							}
							else
							{
								if (!(name2 == "rdblquote"))
								{
									break;
								}
								base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.RightDoubleQuote);
								break;
							}
						}
						else
						{
							if (!(name2 == "nosupersub"))
							{
								break;
							}
							base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithSuperScript(0);
							break;
						}
					}
					else if (num <= 3434512309U)
					{
						if (num != 3349635810U)
						{
							if (num != 3434512309U)
							{
								break;
							}
							if (!(name2 == "ldblquote"))
							{
								break;
							}
							base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.LeftDoubleQuote);
							break;
						}
						else if (!(name2 == "sectd"))
						{
							break;
						}
					}
					else if (num != 3552460647U)
					{
						if (num != 3647204775U)
						{
							if (num != 3658226030U)
							{
								break;
							}
							if (!(name2 == "_"))
							{
								break;
							}
							base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.NonBreakingHyphen);
							break;
						}
						else
						{
							if (!(name2 == "rquote"))
							{
								break;
							}
							base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.RightSingleQuote);
							break;
						}
					}
					else
					{
						if (!(name2 == "plain"))
						{
							break;
						}
						base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveNormal();
						break;
					}
				}
				else if (num <= 3902055289U)
				{
					if (num <= 3809224601U)
					{
						if (num != 3696113941U)
						{
							if (num != 3809224601U)
							{
								break;
							}
							if (!(name2 == "f"))
							{
								break;
							}
							string fullName = tag.FullName;
							bool flag8 = base.Context.FontTable.ContainsFontWithId(fullName);
							if (flag8)
							{
								base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithFont(base.Context.FontTable[fullName]);
							}
							else
							{
								bool flag9 = base.Settings.IgnoreUnknownFonts && base.Context.FontTable.Count > 0;
								if (!flag9)
								{
									throw new RtfUndefinedFontException(Strings.UndefinedFont(fullName));
								}
								base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithFont(base.Context.FontTable[0]);
							}
							break;
						}
						else
						{
							if (!(name2 == "sub"))
							{
								break;
							}
							base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithSuperScript(false);
							break;
						}
					}
					else if (num != 3823790992U)
					{
						if (num != 3876335077U)
						{
							if (num != 3902055289U)
							{
								break;
							}
							if (!(name2 == "bullet"))
							{
								break;
							}
							base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.Bullet);
							break;
						}
						else
						{
							if (!(name2 == "b"))
							{
								break;
							}
							bool derivedBold = !tag.HasValue || tag.ValueAsNumber != 0;
							base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithBold(derivedBold);
							break;
						}
					}
					else
					{
						if (!(name2 == "chcbpat"))
						{
							break;
						}
						goto IL_BC9;
					}
				}
				else if (num <= 4077666505U)
				{
					if (num != 3960223172U)
					{
						if (num != 4075356123U)
						{
							if (num != 4077666505U)
							{
								break;
							}
							if (!(name2 == "v"))
							{
								break;
							}
							bool derivedHidden = !tag.HasValue || tag.ValueAsNumber != 0;
							base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithHidden(derivedHidden);
							break;
						}
						else
						{
							if (!(name2 == "emdash"))
							{
								break;
							}
							base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.EmDash);
							break;
						}
					}
					else
					{
						if (!(name2 == "i"))
						{
							break;
						}
						bool derivedItalic = !tag.HasValue || tag.ValueAsNumber != 0;
						base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithItalic(derivedItalic);
						break;
					}
				}
				else if (num != 4152230356U)
				{
					if (num != 4199938611U)
					{
						if (num != 4211887457U)
						{
							break;
						}
						if (!(name2 == "~"))
						{
							break;
						}
						base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.NonBreakingSpace);
						break;
					}
					else
					{
						if (!(name2 == "emspace"))
						{
							break;
						}
						base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.EmSpace);
						break;
					}
				}
				else
				{
					if (!(name2 == "super"))
					{
						break;
					}
					base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithSuperScript(true);
					break;
				}
				base.Context.WritableCurrentTextFormat = base.Context.WritableCurrentTextFormat.DeriveWithAlignment(RtfTextAlignment.Left);
				break;
				IL_BC9:
				int valueAsNumber2 = tag.ValueAsNumber;
				bool flag10 = valueAsNumber2 >= 0 && valueAsNumber2 < base.Context.ColorTable.Count;
				if (!flag10)
				{
					throw new RtfUndefinedColorException(Strings.UndefinedColor(valueAsNumber2));
				}
				IRtfColor rtfColor = base.Context.ColorTable[valueAsNumber2];
				bool flag11 = "cf".Equals(tag.Name);
				base.Context.WritableCurrentTextFormat = (flag11 ? base.Context.WritableCurrentTextFormat.DeriveWithForegroundColor(rtfColor) : base.Context.WritableCurrentTextFormat.DeriveWithBackgroundColor(rtfColor));
				break;
			}
			}
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0000EB48 File Offset: 0x0000CD48
		void IRtfElementVisitor.VisitGroup(IRtfGroup group)
		{
			string destination = group.Destination;
			switch (base.Context.State)
			{
			case RtfInterpreterState.Init:
			{
				bool flag = "rtf".Equals(destination);
				if (!flag)
				{
					throw new RtfStructureException(Strings.InvalidInitGroupState(destination));
				}
				this.VisitChildrenOf(group);
				break;
			}
			case RtfInterpreterState.InHeader:
			{
				string text = destination;
				uint num = <PrivateImplementationDetails>.ComputeStringHash(text);
				if (num <= 1860974018U)
				{
					if (num <= 1131883462U)
					{
						if (num != 0U)
						{
							if (num != 1131883462U)
							{
								break;
							}
							if (!(text == "ulnone"))
							{
								break;
							}
						}
						else if (text != null)
						{
							break;
						}
					}
					else if (num != 1819811044U)
					{
						if (num != 1860974018U)
						{
							break;
						}
						if (!(text == "generator"))
						{
							break;
						}
						base.Context.State = RtfInterpreterState.InDocument;
						IRtfText rtfText = (group.Contents.Count == 3) ? (group.Contents[2] as IRtfText) : null;
						bool flag2 = rtfText != null;
						if (flag2)
						{
							string text2 = rtfText.Text;
							base.Context.Generator = (text2.EndsWith(";") ? text2.Substring(0, text2.Length - 1) : text2);
							break;
						}
						throw new RtfInvalidDataException(Strings.InvalidGeneratorGroup(group.ToString()));
					}
					else if (!(text == "pard"))
					{
						break;
					}
				}
				else if (num <= 3051949850U)
				{
					if (num != 3003421458U)
					{
						if (num != 3051949850U)
						{
							break;
						}
						if (!(text == "colortbl"))
						{
							break;
						}
						this.colorTableBuilder.VisitGroup(group);
						break;
					}
					else
					{
						if (!(text == "fonttbl"))
						{
							break;
						}
						this.fontTableBuilder.VisitGroup(group);
						break;
					}
				}
				else if (num != 3349635810U)
				{
					if (num != 3552460647U)
					{
						break;
					}
					if (!(text == "plain"))
					{
						break;
					}
				}
				else if (!(text == "sectd"))
				{
					break;
				}
				base.Context.State = RtfInterpreterState.InDocument;
				bool flag3 = !group.IsExtensionDestination;
				if (flag3)
				{
					this.VisitChildrenOf(group);
				}
				break;
			}
			case RtfInterpreterState.InDocument:
			{
				string text3 = destination;
				uint num = <PrivateImplementationDetails>.ComputeStringHash(text3);
				if (num <= 1966078305U)
				{
					if (num <= 290031026U)
					{
						if (num <= 180202684U)
						{
							if (num != 155321749U)
							{
								if (num != 180202684U)
								{
									goto IL_69B;
								}
								if (!(text3 == "footerf"))
								{
									goto IL_69B;
								}
							}
							else
							{
								if (!(text3 == "pict"))
								{
									goto IL_69B;
								}
								this.imageBuilder.VisitGroup(group);
								base.NotifyInsertImage(this.imageBuilder.Format, this.imageBuilder.Width, this.imageBuilder.Height, this.imageBuilder.DesiredWidth, this.imageBuilder.DesiredHeight, this.imageBuilder.ScaleWidthPercent, this.imageBuilder.ScaleHeightPercent, this.imageBuilder.ImageDataHex);
							}
						}
						else if (num != 263456517U)
						{
							if (num != 290031026U)
							{
								goto IL_69B;
							}
							if (!(text3 == "footer"))
							{
								goto IL_69B;
							}
						}
						else
						{
							if (!(text3 == "info"))
							{
								goto IL_69B;
							}
							this.documentInfoBuilder.VisitGroup(group);
						}
					}
					else if (num <= 881512982U)
					{
						if (num != 347978874U)
						{
							if (num != 881512982U)
							{
								goto IL_69B;
							}
							if (!(text3 == "upr"))
							{
								goto IL_69B;
							}
							IRtfGroup rtfGroup = group.SelectChildGroupWithDestination("ud");
							bool flag4 = rtfGroup != null;
							if (flag4)
							{
								this.VisitChildrenOf(rtfGroup);
							}
							else
							{
								IRtfGroup rtfGroup2 = (group.Contents.Count > 2) ? (group.Contents[2] as IRtfGroup) : null;
								bool flag5 = rtfGroup2 != null;
								if (flag5)
								{
									this.VisitChildrenOf(rtfGroup2);
								}
							}
						}
						else if (!(text3 == "footerl"))
						{
							goto IL_69B;
						}
					}
					else if (num != 1392331604U)
					{
						if (num != 1475767949U)
						{
							if (num != 1966078305U)
							{
								goto IL_69B;
							}
							if (!(text3 == "stylesheet"))
							{
								goto IL_69B;
							}
						}
						else
						{
							if (!(text3 == "nonshppict"))
							{
								goto IL_69B;
							}
							bool flag6 = !this.lastGroupWasPictureWrapper;
							if (flag6)
							{
								this.VisitChildrenOf(group);
							}
							this.lastGroupWasPictureWrapper = false;
						}
					}
					else
					{
						if (!(text3 == "pntext"))
						{
							goto IL_69B;
						}
						goto IL_681;
					}
				}
				else if (num <= 3580221526U)
				{
					if (num <= 3378890098U)
					{
						if (num != 2363025592U)
						{
							if (num != 3378890098U)
							{
								goto IL_69B;
							}
							if (!(text3 == "headerf"))
							{
								goto IL_69B;
							}
						}
						else
						{
							if (!(text3 == "userprops"))
							{
								goto IL_69B;
							}
							this.userPropertyBuilder.VisitGroup(group);
						}
					}
					else if (num != 3479555812U)
					{
						if (num != 3580221526U)
						{
							goto IL_69B;
						}
						if (!(text3 == "headerr"))
						{
							goto IL_69B;
						}
					}
					else if (!(text3 == "headerl"))
					{
						goto IL_69B;
					}
				}
				else if (num <= 3718652721U)
				{
					if (num != 3607388050U)
					{
						if (num != 3718652721U)
						{
							goto IL_69B;
						}
						if (!(text3 == "footnote"))
						{
							goto IL_69B;
						}
					}
					else
					{
						if (!(text3 == "shppict"))
						{
							goto IL_69B;
						}
						this.VisitChildrenOf(group);
						this.lastGroupWasPictureWrapper = true;
					}
				}
				else if (num != 3834172512U)
				{
					if (num != 4139617600U)
					{
						if (num != 4141617394U)
						{
							goto IL_69B;
						}
						if (!(text3 == "listtext"))
						{
							goto IL_69B;
						}
						goto IL_681;
					}
					else if (!(text3 == "footerr"))
					{
						goto IL_69B;
					}
				}
				else if (!(text3 == "header"))
				{
					goto IL_69B;
				}
				break;
				IL_681:
				base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.ParagraphNumberBegin);
				this.VisitChildrenOf(group);
				base.NotifyInsertSpecialChar(RtfVisualSpecialCharKind.ParagraphNumberEnd);
				break;
				IL_69B:
				bool flag7 = !group.IsExtensionDestination;
				if (flag7)
				{
					this.VisitChildrenOf(group);
				}
				break;
			}
			}
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0000F210 File Offset: 0x0000D410
		void IRtfElementVisitor.VisitText(IRtfText text)
		{
			switch (base.Context.State)
			{
			case RtfInterpreterState.Init:
				throw new RtfStructureException(Strings.InvalidInitTextState(text.Text));
			case RtfInterpreterState.InHeader:
			{
				bool flag = !string.IsNullOrEmpty(text.Text.Trim());
				if (flag)
				{
					base.Context.State = RtfInterpreterState.InDocument;
				}
				break;
			}
			}
			base.NotifyInsertText(text.Text);
		}

		// Token: 0x040001AC RID: 428
		private readonly RtfFontTableBuilder fontTableBuilder;

		// Token: 0x040001AD RID: 429
		private readonly RtfColorTableBuilder colorTableBuilder;

		// Token: 0x040001AE RID: 430
		private readonly RtfDocumentInfoBuilder documentInfoBuilder;

		// Token: 0x040001AF RID: 431
		private readonly RtfUserPropertyBuilder userPropertyBuilder;

		// Token: 0x040001B0 RID: 432
		private readonly RtfImageBuilder imageBuilder;

		// Token: 0x040001B1 RID: 433
		private bool lastGroupWasPictureWrapper;
	}
}
