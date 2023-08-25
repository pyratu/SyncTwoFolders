using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTwoFiles
{
    public static class FileParserer
    {
		public static List<string> Parsed(string path)
        {
			string[] files = Directory.GetFiles(path);
			List<String> fileList = new List<string>();

			//path = path + "/";
			//removing the useless part of directory and keeping only file name | from "G:\test\file.txt" to "\file.txt"
			foreach (string file in files)
			{
				string str = file.Replace(path, "");
				fileList.Add(str);
			}
			return fileList;
		}
    }
}
