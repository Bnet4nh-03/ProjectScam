using System;
using System.Drawing;

namespace Amkor.CADModules.Maintenance.RTFConverter
{
	// Token: 0x02000014 RID: 20
	public interface IRtfVisualImage : IRtfVisual
	{
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600008A RID: 138
		RtfVisualImageFormat Format { get; }

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600008B RID: 139
		RtfTextAlignment Alignment { get; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600008C RID: 140
		int Width { get; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600008D RID: 141
		int Height { get; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600008E RID: 142
		int DesiredWidth { get; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600008F RID: 143
		int DesiredHeight { get; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000090 RID: 144
		int ScaleWidthPercent { get; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000091 RID: 145
		int ScaleHeightPercent { get; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000092 RID: 146
		string ImageDataHex { get; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000093 RID: 147
		byte[] ImageDataBinary { get; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000094 RID: 148
		Image ImageForDrawing { get; }
	}
}
