using System;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace Amkor.CADModules.Maintenance.RTFConverter.Logging
{
	// Token: 0x0200004E RID: 78
	internal sealed class LoggerFactoryLog4net : LoggerFactory
	{
		// Token: 0x060001AD RID: 429 RVA: 0x000040F6 File Offset: 0x000022F6
		public LoggerFactoryLog4net()
		{
			XmlConfigurator.Configure();
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00004108 File Offset: 0x00002308
		public override ILogger GetLogger(string name)
		{
			return new LoggerLog4net(name);
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00004120 File Offset: 0x00002320
		protected override ILoggerMonitor CreateMonitor()
		{
			return new LoggerMonitorLog4net();
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00004138 File Offset: 0x00002338
		public override void SetLogFile(string absoluteLogFileName, bool append, string messagePattern)
		{
			bool flag = string.IsNullOrEmpty(absoluteLogFileName);
			if (flag)
			{
				throw new ArgumentNullException("absoluteLogFileName");
			}
			string value = (!string.IsNullOrEmpty(messagePattern)) ? messagePattern : "%date{yyyyMMdd-HH:mm:ss.fff}-%-5level-%-25logger{1}: %message%newline";
			IXmlRepositoryConfigurator xmlRepositoryConfigurator = LogManager.GetRepository(Assembly.GetCallingAssembly()) as IXmlRepositoryConfigurator;
			bool flag2 = xmlRepositoryConfigurator != null;
			if (flag2)
			{
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					XmlElement xmlElement = xmlDocument.CreateElement("log4net");
					xmlElement.SetAttribute("update", "Merge");
					xmlDocument.AppendChild(xmlElement);
					XmlElement xmlElement2 = xmlDocument.CreateElement("root");
					xmlElement.AppendChild(xmlElement2);
					XmlElement xmlElement3 = xmlDocument.CreateElement("appender-ref");
					xmlElement3.SetAttribute("ref", "CONSOLE");
					xmlElement2.AppendChild(xmlElement3);
					XmlElement xmlElement4 = xmlDocument.CreateElement("appender-ref");
					xmlElement4.SetAttribute("ref", "DYN-FILE");
					xmlElement2.AppendChild(xmlElement4);
					XmlElement xmlElement5 = xmlDocument.CreateElement("appender");
					xmlElement5.SetAttribute("name", "CONSOLE");
					xmlElement5.SetAttribute("type", "log4net.Appender.ConsoleAppender");
					xmlElement.AppendChild(xmlElement5);
					XmlElement xmlElement6 = xmlDocument.CreateElement("layout");
					xmlElement6.SetAttribute("type", "log4net.Layout.PatternLayout");
					xmlElement5.AppendChild(xmlElement6);
					XmlElement xmlElement7 = xmlDocument.CreateElement("conversionPattern");
					xmlElement7.SetAttribute("value", value);
					xmlElement6.AppendChild(xmlElement7);
					XmlElement xmlElement8 = xmlDocument.CreateElement("threshold");
					xmlElement8.SetAttribute("value", "WARN");
					xmlElement5.AppendChild(xmlElement8);
					XmlElement xmlElement9 = xmlDocument.CreateElement("appender");
					xmlElement9.SetAttribute("name", "DYN-FILE");
					xmlElement9.SetAttribute("type", "log4net.Appender.FileAppender");
					xmlElement.AppendChild(xmlElement9);
					XmlElement xmlElement10 = xmlDocument.CreateElement("file");
					xmlElement10.SetAttribute("value", absoluteLogFileName);
					xmlElement9.AppendChild(xmlElement10);
					XmlElement xmlElement11 = xmlDocument.CreateElement("appendToFile");
					xmlElement11.SetAttribute("value", append ? "true" : "false");
					xmlElement9.AppendChild(xmlElement11);
					XmlElement xmlElement12 = xmlDocument.CreateElement("layout");
					xmlElement12.SetAttribute("type", "log4net.Layout.PatternLayout");
					xmlElement9.AppendChild(xmlElement12);
					XmlElement xmlElement13 = xmlDocument.CreateElement("conversionPattern");
					xmlElement13.SetAttribute("value", value);
					xmlElement12.AppendChild(xmlElement13);
					xmlRepositoryConfigurator.Configure(xmlElement);
				}
				catch (XmlException innerException)
				{
					throw new InvalidOperationException(Strings.LoggerLoggingLevelXmlError, innerException);
				}
				return;
			}
			throw new InvalidOperationException(Strings.LoggerLoggingLevelRepository);
		}
	}
}
