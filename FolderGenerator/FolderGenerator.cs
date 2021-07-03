using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FolderGenerator : MonoBehaviour
{
    #region Variables

    [SerializeField]
    public ScriptableObject asset;

    [Serializable]
    public class RootFolder
    {
        public int id;
        public string name;
    }

    public List<RootFolder> rootFolders;

    [Serializable]
    public class LeafFolder
    {
        public int sub_id;
        public string name;
    }

    public List<LeafFolder> leafFolders;
    #endregion

    /*
    Ex. weapon folder structure:

    New Weapon
        | - Resources
        |   |- Audio
        |   |- Model
        |   |    |- Materials
        |   |    |- Textures
        |   |- Muzzle
        |   |- Trail
        | - weapon.asset
    */

    // Maybe using recursion on the last step could be more user friendly on the editor.
    public void GenerateFolders()
    {
        // Auxs
        bool getRoot = true;
        CompositeFolder rootFolder = null;
        CompositeFolder prevComposite = null;


        #region Generate Composites + Singles folders 
        foreach(var root in rootFolders)
        {
            // Current sub root folder.
            var composite = new CompositeFolder(root.name);

            // We have to capture the root folder. Later we will need the full structure.
            if (getRoot)
            {
                rootFolder = composite;
                getRoot = false;
            }
            // ------------------------------------------------------------------------- //
            
            if(prevComposite != null)
                prevComposite.Add(composite);

            foreach(var leaf in leafFolders)
            {
                if (root.id == leaf.sub_id)
                {
                    var folder = new SingleFolder(leaf.name);
                    composite.Add(folder);
                }
            }

            prevComposite = composite;
        }
        #endregion

        var folders = new List<FolderBase>();
        // GetFolderStructure adds the full structure to the list.
        if (rootFolder != null)
        {
            rootFolder.ShowFolderStructure();
            rootFolder.GetFolderStructure(folders);
        }

        // Creation of the root folder
        string currentRoot = AssetDatabase.CreateFolder("Assets", rootFolder.GetName());
        string currentRootPath = AssetDatabase.GUIDToAssetPath(currentRoot);

        // Create the asset
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance(asset.GetType()), currentRootPath + "/" + asset.GetType().ToString() + ".asset");
        Debug.Log("<b>Asset created! Path: " + currentRootPath + "/" + asset.GetType().ToString() + ".asset</b>\n");

        // Cycle through subroots folders structure while creating them.
        foreach (var f in folders)
        {
            // If not leaf, create subroot.
            if (!f.IsLeaf())
            {
                string tmpGUID = AssetDatabase.CreateFolder(currentRootPath, f.GetName());
                currentRootPath = AssetDatabase.GUIDToAssetPath(tmpGUID);
            }
            else
            {
                AssetDatabase.CreateFolder(currentRootPath, f.GetName());
            }
        }

    }
}
