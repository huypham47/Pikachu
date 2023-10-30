using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : Spawner
{
  public static BlockSpawner instance;
  public static string BLOCK = "Block";
  // public BlocksProfile blocksProfile;
  
  protected override void Awake()
  {
    base.Awake();
    if (BlockSpawner.instance != null) Debug.LogError("Only 1 BlockSpawner allow to exist");
    BlockSpawner.instance = this;
  }
}
