using System;
using NUnit.Framework;
using CSVFileKata;
namespace CSVFileKataTests
{
	public class DebuggingCSVFileWriterTests
	{
		[Test]
		public void RunTheTest()
		{
			//arrange
			var customers = new CustomerListBuilder().WithCustomers(100).Build();
			var filename = "customers.csv";
			var productionFileWriter = new DeduplicatingCSVFileWriter(new BatchedCSVFileWriter(15000, new CustomerCSVFileWriter(new RealFileSystem())));
			var debuggingFileWrtier = new BatchedCSVFileWriter(20, new CustomerCSVFileWriter(new RealFileSystem()));

			var sut = new DebuggingCSVFileWriter(productionFileWriter, debuggingFileWrtier);

			//act
			sut.Write(filename, customers);

        }

        private static FakeCSVFileWriter CreateFakeCSVFileWriter()
        {
			return new FakeCSVFileWriter();
        }

        private class RealFileSystem : IFileSystem
        {
            public void WriteLine(string fileName, string line)
            {
				File.AppendAllLines(fileName, new List<string> { line });
            }
        }
    }
}

