using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentLibrary : MonoBehaviour
{
    public List<EquipmentLibraryItem> items = new List<EquipmentLibraryItem>();
}

[System.Serializable]   
public class EquipmentLibraryItem
{
    public ItemData itemData;
    public GameObject prefab;
    public GameObject[] toDisableGameObjects;
}