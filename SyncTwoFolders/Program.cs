using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CompareTwoFiles
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Type the time to wait for sync in seconds: ");
			GlobalVariables.timeToWait = int.Parse(Console.ReadLine()) * 1000; // it is *1000 because Thread.Sleep() is in miliseconds. If user type 5 it will be 5000 miliseconds -> 5 seconds

			Console.Write("Type the main path folder: ");
			GlobalVariables.mainPath = @"" + Console.ReadLine() + @"\";
			//string mainPath = "G:\\test\\test1\\";

			Console.Write("Type the secondary path folder: ");
			GlobalVariables.secondaryPath = @"" + Console.ReadLine() + @"\";
			// string secondaryPath = "G:\\test\\test2\\";

			Console.Write(@"Type the log path and name ( G:\test\logfile.txt ) : ");
			GlobalVariables.logPath = @"" + Console.ReadLine();
			File.CreateText(GlobalVariables.logPath).Close();
			//string logPath = "G:\\test\\file.txt";
			
			GlobalVariables.mainFiles = FileParserer.Parsed(GlobalVariables.mainPath);
			GlobalVariables.secondaryFiles = FileParserer.Parsed(GlobalVariables.secondaryPath);

			while (true)
			{

				FileManipulator.AddFiles();
				FileManipulator.RemoveFiles();
				Thread.Sleep(GlobalVariables.timeToWait);

			}
		}
	}
}
