/*
 * References:
 * https://www.c-sharpcorner.com/UploadFile/dbd837/svn-api-with-C-Sharp-browse-files-in-svn706/
 *https://tortoisesvn.net/docs/release/TortoiseSVN_en/tsvn-automation.html#tsvn-automation-basics
 */

using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SVNPluginHelper.Scripts
{
    public static class SVNCommands
    {
        #region Fields and Properties

        private static string ProjectPath
        {
            get
            {
                var list = Application.dataPath.Split('/').ToList();
                list.RemoveAt(list.Count - 1);
                var result = string.Join("/", list) + "/";
                return result;
            }
        }

        private static string SelectedObjectPath
        {
            get
            {
                var result = "\"" + ProjectPath + AssetDatabase.GetAssetPath(Selection.activeObject) + "\"";
                return result;
            }
        }

        #endregion

        private static string AssetsPath
        {
            get
            {
                var result = "\"" + Application.dataPath + "\"";
                return result;
            }
        }

        #region Commands For Menu

        [MenuItem("SVN Commands/Commit")]
        private static void CommitFromMenu()
        {
            var svn_command = @"commit /path:" + AssetsPath + " /logmsg:\"dummy log message\" /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }

        [MenuItem("SVN Commands/Update/Update to Head")]
        private static void UpdateToHeadFromMenu()
        {
            var svn_command = @"update /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }

        [MenuItem("SVN Commands/Update/Update to Revision")]
        private static void UpdateToRevisionFromMenu()
        {
            var svn_command = @"update /path:" + AssetsPath + " /rev /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }

        [MenuItem("SVN Commands/Repository Status")]
        private static void RepoStatusFromMenu()
        {
            var svn_command = @"repostatus /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }

        [MenuItem("SVN Commands/Repository Browser")]
        private static void RepoBrowserFromMenu()
        {
            var svn_command = @"repobrowser /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }

        [MenuItem("SVN Commands/Resolve")]
        private static void ResolveFromMenu()
        {
            var svn_command = @"resolve /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }

        [MenuItem("SVN Commands/Switch")]
        private static void SwitchFromMenu()
        {
            var svn_command = @"switch /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }

        #endregion

        #region Commands For Project Window

        [MenuItem("Assets/SVN Commands/Commit")]
        private static void CommitFromAssets()
        {
            var svn_command = "commit /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }
        
        [MenuItem("Assets/SVN Commands/Update to Head")]
        private static void UpdateToHeadFromAssets()
        {
            var svn_command = @"update /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }

        [MenuItem("Assets/SVN Commands/Update to Revision")]
        private static void UpdateToRevisionFromAssets()
        {
            var svn_command = @"update /path:" + SelectedObjectPath + " /rev /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }
        [MenuItem("Assets/SVN Commands/Log")]
        private static void LogFromAssets()
        {
            var svn_command = @"log /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }

        [MenuItem("Assets/SVN Commands/Rename")]
        private static void RenameFromAssets()
        {
            var svn_command = @"rename /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }

        [MenuItem("Assets/SVN Commands/Revert")]
        private static void RevertFromAssets()
        {
            var svn_command = @"revert /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }

        [MenuItem("Assets/SVN Commands/Add")]
        private static void AddFromAssets()
        {
            var svn_command = @"add /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }

        [MenuItem("Assets/SVN Commands/Resolve")]
        private static void ResolveFromAssets()
        {
            var svn_command = @"resolve /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }

        [MenuItem("Assets/SVN Commands/Diff Checker")]
        private static void DiffCheckerFromAssets()
        {
            var svn_command = @"diff /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svn_command);
        }

        private const string CUT_KEY = "SVN_CutFromAssets";

        [MenuItem("Assets/SVN Commands/Cut Versioned File")]
        private static void CutFromAssets()
        {
            var path = ProjectPath + AssetDatabase.GetAssetPath(Selection.activeObject);
            Debug.Log(path + " file has been cut");
            PlayerPrefs.SetString(CUT_KEY, path);
        }

        [MenuItem("Assets/SVN Commands/Paste Versioned File")]
        private static void PasteFromAssets()
        {
            var dest_path = ProjectPath + AssetDatabase.GetAssetPath(Selection.activeObject);
            var svn_command =
                $"move {PlayerPrefs.GetString(CUT_KEY)} {dest_path}";
            SVNProcessHandler.ExecuteSVNCommand(svn_command);
            PlayerPrefs.SetString(CUT_KEY, "");
        }

        [MenuItem("Assets/SVN Commands/Paste Versioned File", true)]
        private static bool CheckIfCanPasteFromAssets()
        {
            return PlayerPrefs.GetString(CUT_KEY, "") != "";
        }

        #endregion
    }
}