using UnityEngine;


public enum CollectionEffect 
{
    None,
    SpeedBoost,
    EnemyAggression,
    EnemySlow,
    AreaUnlock,
    KeySpawn,
    LimitVision
}

[CreateAssetMenu(fileName = "Item", menuName = "RumpledCode/Item", order = 1)]
public class Item : ScriptableObject 
{
    public string id;
    public string description;
    public Sprite icon;
    public GameObject prefab;

    [Header("CollectionEffect")]
    public CollectionEffect collectionEffect = CollectionEffect.None;
    public float effectAmount = 0.2f;
}
