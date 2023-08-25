using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CompareTwoFiles
{
    public static class FileManipulator
    {
        public static void AddFiles()
        {
			if (!(GlobalVariables.mainFiles.All(GlobalVariables.secondaryFiles.Contains) && GlobalVariables.mainFiles.Count == GlobalVariables.secondaryFiles.Count))
			{
				var diffFiles = GlobalVariables.mainFiles.Except(GlobalVariables.secondaryFiles);
				foreach (string file in diffFiles)
				{
					string textToAppend = DateTime.Now + " added file " + file;
					File.AppendAllText(GlobalVariables.logPath, Environment.NewLine + textToAppend);

					string str = GlobalVariables.mainPath + file;
					Console.WriteLine(str);
					File.Copy(str, GlobalVariables.secondaryPath + Path.GetFileName(str), true);
					GlobalVariables.mainFiles = FileParserer.Parsed(GlobalVariables.mainPath);
					GlobalVariables.secondaryFiles = FileParserer.Parsed(GlobalVariables.secondaryPath);
				}
			}
			else
			{
				Console.WriteLine("Not found");
				GlobalVariables.mainFiles = FileParserer.Parsed(GlobalVariables.mainPath);
				GlobalVariables.secondaryFiles = FileParserer.Parsed(GlobalVariables.secondaryPath);
			}
		}
		public static void RemoveFiles()
        {
			if (!(GlobalVariables.secondaryFiles.All(GlobalVariables.mainFiles.Contains) && GlobalVariables.mainFiles.Count == GlobalVariables.secondaryFiles.Count))
			{
				var muie = GlobalVariables.secondaryFiles.Except(GlobalVariables.mainFiles);
				foreach (string file in muie)
				{
					string textToAppend = DateTime.Now + " Removed file " + file;
					File.AppendAllText(GlobalVariables.logPath, Environment.NewLine + textToAppend);
					File.Delete(Path.Combine(GlobalVariables.secondaryPath, file));
					GlobalVariables.mainFiles = FileParserer.Parsed(GlobalVariables.mainPath);
					GlobalVariables.secondaryFiles = FileParserer.Parsed(GlobalVariables.secondaryPath);
				}
			}
		}
	}
}
