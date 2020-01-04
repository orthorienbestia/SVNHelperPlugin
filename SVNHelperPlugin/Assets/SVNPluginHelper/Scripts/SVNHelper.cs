/*
 * References:
 * https://www.c-sharpcorner.com/UploadFile/dbd837/svn-api-with-C-Sharp-browse-files-in-svn706/
 *https://tortoisesvn.net/docs/release/TortoiseSVN_en/tsvn-automation.html#tsvn-automation-basics
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class SVNHelper : MonoBehaviour
{
    private static string SVNURL = Application.dataPath;
    private static string commandPrefix = @"/c " + "TortoiseProc.exe /command:";

    [MenuItem("SVNHelper/Commit")]
    private static void Commit()
    {
        var svn_command = commandPrefix + @"commit /path:" + SVNURL + " /logmsg:\"test log message\" /closeonend:0";
        ExecuteSVNCommand(svn_command);
    }

    private static void ExecuteSVNCommand(string SVNCommand)
    {
        try
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.FileName = "cmd.exe";
          //  processStartInfo.UseShellExecute = false;
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