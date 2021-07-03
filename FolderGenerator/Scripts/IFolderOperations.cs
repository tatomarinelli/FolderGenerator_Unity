using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFolderOperations
{
    void Add(FolderBase folder);
    void Remove(FolderBase folder);
}
