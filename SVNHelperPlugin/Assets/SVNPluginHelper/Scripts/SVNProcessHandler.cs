using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace SVNPluginHelper.Scripts
{
    public class SVNProcessHandler
    {
        private static string commandPrefix = @"/c " + "TortoiseProc.exe /command:";
        
        internal static void ExecuteCommand(string SVNCommand)
        {
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
                    Debug.Log("Couldn't be executed");
                }
                else
                {
                    Debug.Log("Executed Successfully");
                }
            }
            catch (Exception ex)
            {
                //Catch Exception
                Debug.Log("Failed to Commit");
                Debug.Log("Caught Exception: " + ex);
            }
        }
    }
}