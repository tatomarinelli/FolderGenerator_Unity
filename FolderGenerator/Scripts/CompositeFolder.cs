using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeFolder : FolderBase, IFolderOperations
{
    private List<FolderBase> _folders;

    public CompositeFolder(string name) : base(name)
    {
        _folders = new List<FolderBase>();
    }

    public void Add(FolderBase folder)
    {
        _folders.Add(folder);
    }

    public void Remove(FolderBase folder)
    {
        _folders.Remove(folder);
    }

    public override void ShowFolderStructure()
    {
        Debug.Log($"<b>{name}</b> - <i>Contains the following folders:</i> \n");

        foreach(var folder in _folders)
        { 
            var f = folder.GetFolder();
            if (!f.IsLeaf())
            {
                Debug.Log("\t -- " + folder.GetFolder().GetName() + "\n");
                folder.ShowFolderStructure();
            }
            else
            {
                Debug.Log("\t -- " + folder.GetFolder().GetName() + "\n");
            }
        }
    }

    public override void GetFolderStructure(List<FolderBase> folderStructure)
    {
        foreach(var folder in _folders)
        { 
            var f = folder.GetFolder();
            if (!f.IsLeaf())
            {
                folderStructure.Add(f);
                folder.GetFolderStructure(folderStructure);
            }
            else
            {
                folderStructure.Add(f);
            }            
        }
    }

    public override bool IsLeaf()
    {
        return false;
    }

}
