using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerCtrl : _MonoBehaviour
{
    public BlockSpawner blockSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBlockSpawner();
    }

    protected virtual void LoadBlockSpawner()
    {
        if(this.blockSpawner != null) return;
        this.blockSpawner = GetComponentInChildren<BlockSpawner>();
    }
}
