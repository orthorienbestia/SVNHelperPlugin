/*
 * References:
 *     https://www.c-sharpcorner.com/UploadFile/dbd837/svn-api-with-C-Sharp-browse-files-in-svn706/
 *    https://tortoisesvn.net/docs/release/TortoiseSVN_en/tsvn-automation.html#tsvn-automation-basics
 * 
 */

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SVNPluginHelper.Scripts
{
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    [SuppressMessage("ReSharper", "CommentTypo")]
    public static class SVNCommands
    {
        #region Fields and Properties

        internal static string ProjectPath
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

        internal static string AssetsPath
        {
            get
            {
                var result = "\"" + Application.dataPath + "\"";
                return result;
            }
        }

        #region Commands For Menu

        [MenuItem("SVN Commands/Commit", false, 1)]
        private static void CommitFromMenu()
        {
            var svnCommand = @"commit /path:" + AssetsPath + " /logmsg:\"dummy log message\" /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("SVN Commands/Update to Head", false, 2)]
        private static void UpdateToHeadFromMenu()
        {
            var svnCommand = @"update /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("SVN Commands/Update to Revision", false, 3)]
        private static void UpdateToRevisionFromMenu()
        {
            var svnCommand = @"update /path:" + AssetsPath + " /rev /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }
        
        [MenuItem("SVN Commands/Revert", false, 50)]
        private static void RevertFromMenu()
        {
            var svnCommand = @"revert /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }
        
        [MenuItem("SVN Commands/Resolve", false, 51)]
        private static void ResolveFromMenu()
        {
            var svnCommand = @"resolve /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        // [MenuItem("SVN Commands/Conflict Editor")]
        // private static void ConflictEditorFromMenu()
        // {
        //     var svnCommand = @"conflicteditor /path:" + AssetsPath + " /closeonend:0";
        //     SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        // }

        [MenuItem("SVN Commands/Create Patch",false, 100)]
        private static void ConflictEditorFromMenu()
        {
            var svnCommand = @"createpatch /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("SVN Commands/Shelve",false, 101)]
        private static void ShelveFromMenu()
        {
            var svnCommand = @"shelve /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("SVN Commands/Unshelve",false, 102)]
        private static void UnShelveFromMenu()
        {
            var svnCommand = @"unshelve /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }
        
        
        [MenuItem("SVN Commands/Repository Status", false, 200)]
        private static void RepoStatusFromMenu()
        {
            var svnCommand = @"repostatus /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("SVN Commands/Repository Browser",false, 201)]
        private static void RepoBrowserFromMenu()
        {
            var svnCommand = @"repobrowser /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }
        
        [MenuItem("SVN Commands/Switch",false, 1000)]
        private static void SwitchFromMenu()
        {
            var svnCommand = @"switch /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }
        
        [MenuItem("SVN Commands/Cleanup",false, 1001)]
        private static void CleanupFromMenu()
        {
            var svnCommand = @"cleanup /path:" + AssetsPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("SVN Commands/Settings",false, 1002)]
        private static void SettingsFromMenu()
        {
            var svnCommand = @"settings /path:" + AssetsPath + " /closeonend:0";
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

        [MenuItem("Assets/SVN Commands/Lock")]
        private static void LockFromAssets()
        {
            var svnCommand = @"lock /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("Assets/SVN Commands/Unlock")]
        private static void UnlockFromAssets()
        {
            var svnCommand = @"unlock /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("Assets/SVN Commands/Properties")]
        private static void PropertiesFromAssets()
        {
            var svnCommand = @"properties /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("Assets/SVN Commands/Revision Graph")]
        private static void RevisionGraphFromAssets()
        {
            var svnCommand = @"revisiongraph /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("Assets/SVN Commands/Cleanup")]
        private static void CleanupFromAssets()
        {
            var svnCommand = @"cleanup /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("Assets/SVN Commands/Shelve")]
        private static void ShelveFromAssets()
        {
            var svnCommand = @"shelve /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        [MenuItem("Assets/SVN Commands/Unshelve")]
        private static void UnshelveFromAssets()
        {
            var svnCommand = @"unshelve /path:" + SelectedObjectPath + " /closeonend:0";
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

        [MenuItem("Assets/SVN Commands/Settings")]
        private static void SettingsFromAssets()
        {
            var svnCommand = @"settings /path:" + SelectedObjectPath + " /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        #endregion
    }
}