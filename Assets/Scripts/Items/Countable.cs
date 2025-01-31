using UnityEngine;

public class Countable : ItemType
{
    [Range(1, 1000)] public int maxStackAmount;
}
