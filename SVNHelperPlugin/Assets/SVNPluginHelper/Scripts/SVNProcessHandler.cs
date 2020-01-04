using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace SVNPluginHelper.Scripts
{
    public static class SVNProcessHandler
    {
        private static string commandPrefix = @"/c " + "TortoiseProc.exe /command:";

        internal static void ExecuteCommand(string SVNCommand)
        {
            var cmd_name = SVNCommand.Split(' ')[0];
            SVNCommand = commandPrefix + SVNCommand;
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processStartInfo.FileName = "cmd.exe";
                processStartInfo.Arguments = SVNCommand;
                Process process = Process.Start(processStartInfo);
                process.WaitForExit();

                int eCode = process.ExitCode;
                if (eCode == 0)
                {
                    Debug.Log($"{cmd_name} Executed Successfully with plugin warnings");
                }
                else
                {
                    Debug.Log($"{cmd_name} Executed Successfully");
                }
            }
            catch (Exception ex)
            {
                //Catch Exception
                Debug.Log($"{cmd_name}: Failed to execute command " + SVNCommand);
                Debug.Log($"{cmd_name}: Caught Exception: " + ex);
            }
        }
        
        
        internal static void ExecuteSVNCommand(string SVNCommand)  
        {  
            try  
            {  
                Process.Start("CMD.exe",SVNCommand);
                // ProcessStartInfo processStartInfo = new ProcessStartInfo();  
                // //processStartInfo.WorkingDirectory = @"C:\Program Files\TortoiseSVN\bin";  
                // processStartInfo.RedirectStandardInput = true;  
                // processStartInfo.CreateNoWindow = true;  
                // processStartInfo.WindowStyle = ProcessWindowStyle.Normal;  
                // processStartInfo.FileName = "cmd.exe";                  
                // processStartInfo.UseShellExecute = false;  
                // processStartInfo.Arguments = SVNCommand;  
                // Process process = Process.Start(processStartInfo);  
                // process.WaitForExit();  
                //
                // int eCode = process.ExitCode;  
                // if (eCode == 0)  
                // {  
                //     //Success  
                // }  
                // else  
                // {  
                //     //Failed
                // }  
            }  
            catch (Exception ex)  
            {  
                //Catch Exception  
            }  
        }  
    }
}