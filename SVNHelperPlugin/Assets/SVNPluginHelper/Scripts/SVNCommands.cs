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
namespace SVNPluginHelper.Scripts
{
    public class SVNCommands
    {
        [MenuItem("SVNCommands/Commit")]
        private static void CommitFromMenu()
        {
            var svn_command =  @"commit /path:" + Application.dataPath + " /logmsg:\"test log message\" /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }

        [MenuItem("Assets/SVNCommands/Rename")]
        private static void RenameFromAssets()
        {
            var selectedObjectName = AssetDatabase.GetAssetPath(Selection.activeObject);
            var svn_command = @"rename /path:" + selectedObjectName + " /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }
    }
}