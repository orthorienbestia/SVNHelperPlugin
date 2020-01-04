using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class SVNHelper : MonoBehaviour
{
    [MenuItem("SVNHelper/Commit")]
    static void Commit()
    {
        string SVNURL="https://192.168.56.1/!/#MyUnityProjects";
        string OUTPUT_PATH = "D:\\Git\\Easy Development Plugin\\OUTPUT.txt";
        //string command = @"/c " + "TortoiseProc.exe /command:repobrowser /path:" + SVNURL + " /outfile:" + OUTPUT_PATH;
        string command =  @"/c " +"svn.exe /command:commit /message:" + "THis is demo commit from Unity";
        ExecuteSVNCommand(command);
    }

    private static void ExecuteSVNCommand(string SVNCommand)  
    {  
        try  
        {  
            ProcessStartInfo processStartInfo = new ProcessStartInfo();  
            processStartInfo.WorkingDirectory = @"C:\Program Files\TortoiseSVN\bin";  
            processStartInfo.RedirectStandardInput = true;  
            processStartInfo.CreateNoWindow = true;  
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;  
            processStartInfo.FileName = "cmd.exe";                  
            processStartInfo.UseShellExecute = false;  
            processStartInfo.Arguments = SVNCommand;  
            Process process = Process.Start(processStartInfo);  
            process.WaitForExit();  
  
            int eCode = process.ExitCode;  
            if (eCode == 0)  
            {
                Debug.Log("Committed Successfully");
            }  
            else  
            {
                Debug.Log("Failed to Commit");
            }  
        }  
        catch (Exception ex)  
        {  
            //Catch Exception
            Debug.Log("Failed to Commit");
            Debug.Log("Caught Exception: "+ex);
        }  
    } 
}
