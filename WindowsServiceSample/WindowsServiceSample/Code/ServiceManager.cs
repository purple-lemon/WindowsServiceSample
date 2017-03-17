using SimpleLogger;
using SimpleLogger.Logging.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceSample.Code
{
	public class ServiceManager
	{
		public void DoWork()
		{
			Logger.LoggerHandlerManager
		   .AddHandler(new FileLoggerHandler());

			var fileName = "InfoFile.txt";
			var fileInfo = new FileInfo(fileName);
			if (fileInfo.Exists)
			{
				Logger.Log(Logger.Level.Fine, File.ReadAllText(fileInfo.FullName));
			}
			Logger.Log(Logger.Level.Error, "NO FILE FOUND");
		}

		//public string IsFilePath(string fullFileName)
		//{
		//	Path.GetFileNameWithoutExtension(fullFileName).Equals(fullFileName);
		//}
	}
}
