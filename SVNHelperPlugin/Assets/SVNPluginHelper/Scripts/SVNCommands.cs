/*
 * References:
 *     https://www.c-sharpcorner.com/UploadFile/dbd837/svn-api-with-C-Sharp-browse-files-in-svn706/
 *    https://tortoisesvn.net/docs/release/TortoiseSVN_en/tsvn-automation.html#tsvn-automation-basics
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

        private static string SelectedObjectPathWithMeta
        {
            get
            {
                var result = "\"" + ProjectPath + AssetDatabase.GetAssetPath(Selection.activeObject) + "\" \"" +
                             ProjectPath + AssetDatabase.GetAssetPath(Selection.activeObject) + ".meta" + "\"";
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
            var svnCommand = @"commit /path:" + AssetsPath + " /logmsg:\"dummy log message\" /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("SVN Commands/Update/Update to Head")]
        private static void UpdateToHeadFromMenu()
        {
            var svnCommand = @"update /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("SVN Commands/Update/Update to Revision")]
        private static void UpdateToRevisionFromMenu()
        {
            var svnCommand = @"update /path:" + AssetsPath + " /rev /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("SVN Commands/Repository Status")]
        private static void RepoStatusFromMenu()
        {
            var svnCommand = @"repostatus /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("SVN Commands/Repository Browser")]
        private static void RepoBrowserFromMenu()
        {
            var svnCommand = @"repobrowser /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("SVN Commands/Resolve")]
        private static void ResolveFromMenu()
        {
            var svnCommand = @"resolve /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("SVN Commands/Switch")]
        private static void SwitchFromMenu()
        {
            var svnCommand = @"switch /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        #endregion

        #region Commands For Project Window

        [MenuItem("Assets/SVN Commands/Commit")]
        private static void CommitFromAssets()
        {
            var svnCommand = "commit /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("Assets/SVN Commands/Update to Head")]
        private static void UpdateToHeadFromAssets()
        {
            var svnCommand = @"update /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("Assets/SVN Commands/Update to Revision")]
        private static void UpdateToRevisionFromAssets()
        {
            var svnCommand = @"update /path:" + SelectedObjectPath + " /rev /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("Assets/SVN Commands/Log")]
        private static void LogFromAssets()
        {
            var svnCommand = @"log /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("Assets/SVN Commands/Rename")]
        private static void RenameFromAssets()
        {
            var svnCommand = @"rename /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("Assets/SVN Commands/Revert")]
        private static void RevertFromAssets()
        {
            var svnCommand = @"revert /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("Assets/SVN Commands/Add")]
        private static void AddFromAssets()
        {
            var svnCommand = @"add /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("Assets/SVN Commands/Resolve")]
        private static void ResolveFromAssets()
        {
            var svnCommand = @"resolve /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("Assets/SVN Commands/Diff Checker")]
        private static void DiffCheckerFromAssets()
        {
            var svnCommand = @"diff /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        private const string CutKey = "SVN_CutFromAssets";

        [MenuItem("Assets/SVN Commands/Cut Versioned File")]
        private static void CutFromAssets()
        {
            var path = SelectedObjectPathWithMeta;
            Debug.Log(path + " file has been cut");
            PlayerPrefs.SetString(CutKey, path);
        }

        [MenuItem("Assets/SVN Commands/Paste Versioned File")]
        private static void PasteFromAssets()
        {
            var destPath = SelectedObjectPath;
            var svnCommand =
                $"move {PlayerPrefs.GetString(CutKey)} {destPath}";
            SVNProcessHandler.ExecuteSVNCommand(svnCommand);
            PlayerPrefs.SetString(CutKey, "");
        }

        [MenuItem("Assets/SVN Commands/Paste Versioned File", true)]
        private static bool CheckIfCanPasteFromAssets()
        {
            return PlayerPrefs.GetString(CutKey, "") != "";
        }

        #endregion
    }
}