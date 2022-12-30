using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.IO;
using Core;
using KompasWrapper;

namespace StressTesting
{
	class Program
	{
		static void Main(string[] args)
		{
			const int bitsInGigabyte = 1073741824;
			var builder = new TableBuilder();
			var stopWatch = new Stopwatch();
			stopWatch.Start();
			var tableParameters = new TableParameters();
			var streamWriter = new StreamWriter("log.txt", true);
			var count = 0;
			while (true)
			{
				builder.Build(tableParameters);
				var computerInfo = new ComputerInfo();
				var usedMemory = (computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory) 
				                 / bitsInGigabyte;
				streamWriter.WriteLine(
					$"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
				streamWriter.Flush();
			}
		}
	}
}
