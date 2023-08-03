// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

string ids = "1404,1448,1481,1564";
const string bucketName = "h2b-web-novo";


try
{
    ProcessStartInfo startInfo = new ProcessStartInfo();
    startInfo.FileName = "cmd.exe";
    startInfo.RedirectStandardInput = true;

    using (Process process = Process.Start(startInfo))
    {
        if (process is null)
        {
            Console.WriteLine("Process created is null. Exiting.");
            return;
        }

        foreach (string tenant in ids.Split(','))
            process.StandardInput.WriteLine($"aws s3 rm s3://{bucketName}/{tenant} --recursive");

        process.StandardInput.WriteLine("exit");

        process.WaitForExit();
    }
}
catch (Exception e)
{
    Console.WriteLine("Error: " + e.Message + e.StackTrace);
}

Console.WriteLine("Finished");

Console.ReadKey();