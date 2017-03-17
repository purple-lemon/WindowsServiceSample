using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsServiceSample.Code;

namespace WindowsServiceSample
{
	public partial class Service1 : ServiceBase
	{
		public CancellationTokenSource source = new CancellationTokenSource();
		public Service1()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			var mngr = new ServiceManager();
			Task.Run(
				() => {
					while (true)
					{
						mngr.DoWork();
						Thread.Sleep(5000);
					}
				}, 
				source.Token);
		}

		protected override void OnStop()
		{
			source.Cancel();
		}
	}
}
