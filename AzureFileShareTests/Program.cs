using System;

namespace AzureFileShareTests
{
    class Program
    {
        static void Main(string[] args)
        {
            DownloadFile downloadFile = new DownloadFile();
            downloadFile.Download();

            Traverse traverse = new Traverse();
            traverse.Travere();
        }
    }
}
