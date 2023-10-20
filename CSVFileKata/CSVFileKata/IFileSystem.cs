using System;
namespace CSVFileKata
{
	public interface IFileSystem
	{
		void WriteLine(string fileName, string line);
	}
}

