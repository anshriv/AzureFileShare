using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure.Storage;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
namespace AzureFileShareTests
{
    class Traverse
    {
        public void Travere()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = "";
                //"DefaultEndpointsProtocol=https;AccountName=anshrivstorage;AccountKey=vUrxvug7tuxdMCu3UggcW/u14m5wyKEaVvSFg6RP8vKze7xKaxBF6hgSE69sxs/kVNdzSABpKTVf+AStQ8wE1g==;EndpointSuffix=core.windows.net";

            // Get a reference to a share named "sample-share"
            ShareClient share = new ShareClient(connectionString, "anshriv");

            // Track the remaining directories to walk, starting from the root
            Queue<ShareDirectoryClient> remaining = new Queue<ShareDirectoryClient>();
            remaining.Enqueue(share.GetRootDirectoryClient());
            while (remaining.Count > 0)
            {
                // Get all of the next directory's files and subdirectories
                ShareDirectoryClient dir = remaining.Dequeue();
                foreach (ShareFileItem item in dir.GetFilesAndDirectories())
                {
                    Console.WriteLine(item.Name);

                    // Keep walking down directories
                    if (item.IsDirectory)
                    {
                        remaining.Enqueue(dir.GetSubdirectoryClient(item.Name));
                    }
                }
            }
        }
    }
}
