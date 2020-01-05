using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using Debug = UnityEngine.Debug;

namespace SVNPluginHelper.Scripts
{
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    [SuppressMessage("ReSharper", "CommentTypo")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class SVNProcessHandler
    {
        private const string TortoiseCommandPrefix = @"/c TortoiseProc.exe /command:";
        private const string SvnCommandPrefix = @"/c svn ";

        internal static void ExecuteTortoiseSVNCommand(string Command)
        {
            var cmd_name = Command.Split(' ')[0];
            Command = TortoiseCommandPrefix + Command;
            ExecuteCommand(Command, cmd_name);
        }

        internal static void ExecuteSVNCommand(string Command)
        {
            var cmd_name = Command.Split(' ')[0];
            Command = SvnCommandPrefix + Command;
            ExecuteCommand(Command, cmd_name);
        }

        private static void ExecuteCommand(string Command, string cmd_name)
        {
            Debug.Log(Command);
            try
            {
                var processStartInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden, FileName = "cmd.exe", Arguments = Command
                };
                var process = Process.Start(processStartInfo);
                if (process == null) return;
                process.WaitForExit();

                var eCode = process.ExitCode;
                Debug.Log(eCode == 0
                    ? $"{cmd_name} Executed Successfully with plugin warnings"
                    : $"{cmd_name} Executed Successfully");
            }
            catch (Exception ex)
            {
                //Catch Exception
                Debug.Log($"{cmd_name}: Failed to execute command " + Command);
                Debug.Log($"{cmd_name}: Caught Exception: " + ex);
            }
            finally
            {
                AssetDatabase.Refresh();
            }
        }
    }
}