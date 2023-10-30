using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : _MonoBehaviour
{
  public Transform holder;
  public List<Transform> prefabs;
  public List<Transform> poolObjs;
  public int spanwCount = 0;
  protected override void LoadComponents()
  {
    this.LoadHolder();
    this.LoadPrefabs();
  }

  protected virtual void LoadHolder()
  {
    if(this.holder != null) return;
    this.holder = transform.Find("Holer");
  }
  
  protected virtual void LoadPrefabs()
  {
    if(this.prefabs.Count > 0) return;
    
    Transform prefabObjs = transform.Find("Prefabs");
    foreach (Transform prefab in prefabObjs)
    {
      this.prefabs.Add(prefab);
      prefab.gameObject.SetActive(false);
    }
  }

  public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
  {
    Transform prefab = this.GetPrefabByName(prefabName);
    if (prefab == null) return null;
    return this.Spawn(prefab, spawnPos, rotation);
  }

  public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
  {
    Transform newPrefab = this.GetPrefabFromPool(prefab);
    if (newPrefab == null) return null;
    
    newPrefab.SetPositionAndRotation(spawnPos, rotation);
    newPrefab.parent = this.holder;
    newPrefab.gameObject.SetActive(true);

    this.spanwCount++;
    return newPrefab;
  }

  protected virtual void Despawn(Transform obj)
  {
    if(this.poolObjs.Contains(obj)) return;
    this.poolObjs.Add(obj);
    obj.gameObject.SetActive(false);
    this.spanwCount--;
  }
  
  protected virtual Transform GetPrefabFromPool(Transform prefab)
  {
    foreach (Transform obj in poolObjs)
    {
      if(obj == null) continue;
      if (obj.name == prefab.name)
      {
        this.poolObjs.Remove(obj);
        return obj;
      }
    }

    Transform newPrefab = Instantiate(prefab);
    newPrefab.name = prefab.name;
    return newPrefab;
  }
  
  protected virtual Transform GetPrefabByName(string prefabName)
  {
    foreach (Transform prefab in prefabs)
    {
      if (prefab.name == prefabName) return prefab;
    }

    return null;
  }
}
