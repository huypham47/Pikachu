using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "SO/BlockProfile", order = 1)]
public class BlockProfile : ScriptableObject
{
  public List<Sprite> sprites = new List<Sprite>();
}
