using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFolder : FolderBase
{
    public SingleFolder(string name) : base(name)
    {

    }

    public override void ShowFolderStructure()
    {
        Debug.Log($"{name}");
    }
    public override void GetFolderStructure(List<FolderBase> folderStructure)
    {
        Debug.LogError("Leaf calling GetFolderStructure!");
    }

    public override bool IsLeaf()
    {
        return true;
    }
}
