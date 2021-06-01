using System;
using System.Linq;

namespace ChangeDirectory
{
	public class Path
	{
		private string CurrentPath;
		private string[] currentPathSplit;

		public Path(string path)
		{
			//Initialize current directory.
			CurrentPath = path;
			Console.WriteLine("Current Path is:" + CurrentPath);
		}

		public string cd(string newPath)
		{
			try
			{
				//Check if current path  is valid.
				if (CurrentPath != null || CurrentPath != "/")
				{
					currentPathSplit = CurrentPath.Split("/");
				}
				else
				{
					Console.WriteLine("Current Path not valid");
					return null;
				}

				if (newPath == null || newPath == "/")
				{
					CurrentPath = newPath;
					return CurrentPath;
				}

				//Change the directory of the file.
				if (newPath.Length > 1)
				{
					string[] splitnewpath = newPath.Split('/');
					int count = 0;
					foreach (string indexValue in splitnewpath)
					{
						if (indexValue.Contains(".."))
						{
							count++;
						}
					}

					currentPathSplit = currentPathSplit.Take(currentPathSplit.Length - count).ToArray();

					if(splitnewpath[splitnewpath.Length - 1] != "..")
						currentPathSplit = currentPathSplit.Append(splitnewpath[splitnewpath.Length - 1]).ToArray();

					CurrentPath = String.Join("/", currentPathSplit.ToArray());
					return CurrentPath;
				}
				else
				{
					Console.WriteLine("directory not valid format");
					return null;
				}
			}
			catch (Exception e)
			{
				return e.Message;
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Path path = new Path("a/b/c/d");
			string output = path.cd("..");
			Console.WriteLine(output);
			Console.ReadLine();
		}
	}
}
