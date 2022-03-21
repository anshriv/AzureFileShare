using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure.Storage;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;


namespace AzureFileShareTests
{
    class DownloadFile
    {
        public void Download()
        {
            
            // Get a reference to a share named "sample-share"
            ShareClient share = new ShareClient(Constants.connectionstrig, "anshriv");

            // Get a reference to a directory named "sample-dir"
            ShareDirectoryClient directory = share.GetDirectoryClient("root");

            // Get a reference to a file named "sample-file" in directory "sample-dir"
            ShareFileClient file = directory.GetFileClient("Yammer Ignite 2018 Social Content.docx");

            // Download the file
            ShareFileDownloadInfo download = file.Download();
            using (FileStream stream = File.OpenWrite("Yammer Ignite 2018 Social Content.docx"))
            {
                download.Content.CopyTo(stream);
            }
        }
    }
}
