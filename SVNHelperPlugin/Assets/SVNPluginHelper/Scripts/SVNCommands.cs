/*
 * References:
 * https://www.c-sharpcorner.com/UploadFile/dbd837/svn-api-with-C-Sharp-browse-files-in-svn706/
 *https://tortoisesvn.net/docs/release/TortoiseSVN_en/tsvn-automation.html#tsvn-automation-basics
 */

using UnityEditor;
using UnityEngine;

namespace SVNPluginHelper.Scripts
{
    public static class SVNCommands
    {
        #region Commands For Menu

        [MenuItem("SVN Commands/Commit")]
        private static void CommitFromMenu()
        {
            var svn_command = @"commit /path:" + Application.dataPath + " /logmsg:\"dummy log message\" /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }

        [MenuItem("SVN Commands/Update/Update to Head")]
        private static void UpdateToHeadFromMenu()
        {
            var svn_command = @"update /path:" + Application.dataPath + " /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }

        [MenuItem("SVN Commands/Update/Update to Revision")]
        private static void UpdateToRevisionFromMenu()
        {
            var svn_command = @"update /path:" + Application.dataPath + " /rev /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }

        [MenuItem("SVN Commands/Repository Status")]
        private static void RepoStatusFromMenu()
        {
            var svn_command = @"repostatus /path:" + Application.dataPath + " /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }

        [MenuItem("SVN Commands/Repository Browser")]
        private static void RepoBrowserFromMenu()
        {
            var svn_command = @"repobrowser /path:" + Application.dataPath + " /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }
        
        [MenuItem("SVN Commands/Resolve")]
        private static void ResolveFromMenu()
        {
            var svn_command = @"resolve /path:" + Application.dataPath + " /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }
        
        [MenuItem("SVN Commands/Switch")]
        private static void SwitchFromMenu()
        {
            var svn_command = @"switch /path:" + Application.dataPath + " /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }
        #endregion

        #region Commands For Project Window

        [MenuItem("Assets/SVN Commands/Commit")]
        private static void CommitFromAssets()
        {
            var selectedObjectName = AssetDatabase.GetAssetPath(Selection.activeObject);
            var svn_command = @"commit /path:" + selectedObjectName + " /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }
        
        [MenuItem("Assets/SVN Commands/Rename")]
        private static void RenameFromAssets()
        {
            var selectedObjectName = AssetDatabase.GetAssetPath(Selection.activeObject);
            var svn_command = @"rename /path:" + selectedObjectName + " /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }

        [MenuItem("Assets/SVN Commands/Revert")]
        private static void RevertFromAssets()
        {
            var selectedObjectName = AssetDatabase.GetAssetPath(Selection.activeObject);
            var svn_command = @"revert /path:" + selectedObjectName + " /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }

        [MenuItem("Assets/SVN Commands/Add")]
        private static void AddFromAssets()
        {
            var selectedObjectName = AssetDatabase.GetAssetPath(Selection.activeObject);
            var svn_command = @"add /path:" + selectedObjectName + " /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }
        
        [MenuItem("Assets/SVN Commands/Resolve")]
        private static void ResolveFromAssets()
        {
            var selectedObjectName = AssetDatabase.GetAssetPath(Selection.activeObject);
            var svn_command = @"resolve /path:" + selectedObjectName + " /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }
        
        [MenuItem("Assets/SVN Commands/Diff Checker")]
        private static void DiffCheckerFromAssets()
        {
            var selectedObjectName = AssetDatabase.GetAssetPath(Selection.activeObject);
            var svn_command = @"diff /path:" + selectedObjectName + " /closeonend:0";
            SVNProcessHandler.ExecuteCommand(svn_command);
        }
        
        [MenuItem("Assets/SVN Commands/Move")]
        private static void MoveFromAssets()
        {
            var selectedObjectName = AssetDatabase.GetAssetPath(Selection.activeObject);
            var svn_command = @"/c svn move "+"D:/Git/Mine/Unity/SVNHelperPlugin/SVNHelperPlugin/Assets/SVNPluginHelper/Scripts"+" "+Application.dataPath;
            SVNProcessHandler.ExecuteSVNCommand(svn_command);
        }

        #endregion
    }
}