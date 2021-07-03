using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FolderBase
{
    protected string name;
    
    public FolderBase(string name) { this.name = name;}

    // Recursive Methods //
    public abstract void GetFolderStructure( List<FolderBase> folderStructure);
    public abstract void ShowFolderStructure();
    // ------------------------------------------------------------------------ //
    public FolderBase GetFolder() { return this; }
    public string GetName() { return name; }
    public abstract bool IsLeaf();


}
