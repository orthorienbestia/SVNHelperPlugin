using SVNPluginHelper.Scripts;
using UnityEditor;
using UnityEngine;

public class AssetDatabaseEditor : UnityEditor.AssetModificationProcessor
{
    public static AssetDeleteResult OnWillDeleteAsset(string AssetPath, RemoveAssetOptions rao)
    {
        if (EditorUtility.DisplayDialog("Remove from version control ?",
            "Do you want to remove this file/folder from version control ?", "Yes", "No"))
        {
            Debug.Log(AssetPath);
            var svnCommand =
                $"remove /path: {SVNCommands.ProjectPath + AssetPath} {SVNCommands.ProjectPath + AssetPath}.meta /closeonend:0";
            SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
            // svnCommand = @"remove /path:" + AssetPath + ".meta /closeonend:0";
            // SVNProcessHandler.ExecuteTortoiseSVNCommand(svnCommand);
        }

        return AssetDeleteResult.DidNotDelete;
    }
}