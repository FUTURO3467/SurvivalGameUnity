using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/New Item")]
public class ItemData : ScriptableObject
{
    public string name;
    public string description;
    public Sprite icon;
    public GameObject prefab;

    public ItemType type;
    public EquipmentType equipmentType;
}


public enum ItemType
{
    RESSOURCE,
    EQUIPMENT,
    CONSUMABLE
}

public enum EquipmentType
{
    HEAD,
    CHEST,
    HANDS,
    LEGS,
    FEET
}
