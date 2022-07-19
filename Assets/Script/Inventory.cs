using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> content = new List<ItemData>();

    [SerializeField]
    private GameObject invPanel;

    [SerializeField]
    private Transform inventorySlotsParent;

    const int INVENTORY_SIZE = 24;

    public static Inventory instance;

    [Header("Action panel reference")]

    [SerializeField]
    private GameObject actionPanel;
    [SerializeField]
    private GameObject useItemButton;
    [SerializeField]
    private GameObject equipItemButton;
    [SerializeField]
    private GameObject dropItemButton;
    [SerializeField]
    private GameObject destroyItemButton;


    [SerializeField]
    private ItemData currentItemData;

    [SerializeField]
    private Sprite emptySlot;

    [SerializeField]
    private Transform dropPoint;

    [SerializeField]
    private EquipmentLibrary equipmentLibrary;

    private void Awake()
    {
        instance = this;
    }

    public void AddItem(ItemData itm)
    {
        
        content.Add(itm);
        RefreshContent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            invPanel.SetActive(!invPanel.activeSelf);
        }
    }

    private void Start()
    {
        RefreshContent();
    }

    public void closeInventory()
    {
        invPanel.SetActive(false);
    }

    private void RefreshContent()
    {
        //Vidage de tous les slots
        for (int i = 0; i < inventorySlotsParent.childCount; i++)
        {
            Slot slot = inventorySlotsParent.GetChild(i).GetComponent<Slot>();
            slot.item = null;
            slot.visual.sprite = emptySlot;
        }


        //Peuplement du visuel selon le contenu réel de l'inventaire
            for (int i = 0; i < content.Count; i++)
        {
            Slot slot = inventorySlotsParent.GetChild(i).GetComponent<Slot>();
            slot.item = content[i];
            slot.visual.sprite = content[i].icon;

        } 
    }

    public bool isFull()
    {
        return INVENTORY_SIZE <= content.Count;
    }

    public void OpenActionPanel(ItemData data, Vector3 slotPosition)
    {
        currentItemData = data;
        actionPanel.SetActive(false);
        if (data == null) return;

        switch (data.type)
        {
            case ItemType.RESSOURCE:
                useItemButton.SetActive(false);
                equipItemButton.SetActive(false);
                break;

            case ItemType.EQUIPMENT:
                useItemButton.SetActive(false);
                equipItemButton.SetActive(true);
                break;

            case ItemType.CONSUMABLE:
                useItemButton.SetActive(true);
                equipItemButton.SetActive(false);
                break;
        }
        actionPanel.transform.position = slotPosition;
        actionPanel.SetActive(true);
    }

    public void CloseActionPanel()
    {
        actionPanel.SetActive(false);
        currentItemData = null;
    }

    public void UseActionButton()
    {
        CloseActionPanel();
    }
    public void EquipActionButton()
    {
        EquipmentLibraryItem equipItem = equipmentLibrary.items.Where(elem => elem.itemData == currentItemData).First();
        if(equipItem == null)
        {
            Debug.LogError("Aucun item trouvé");
            return;
        }

        foreach (GameObject gObject in equipItem.toDisableGameObjects)
        {
            gObject.SetActive(false);
        }

        equipItem.prefab.SetActive(true);

        CloseActionPanel();
    }
    public void DropActionButton()
    {
        if (!CheckItem()) return;

        GameObject instantiateItem = Instantiate(currentItemData.prefab);
        instantiateItem.transform.position = dropPoint.position;
        RemoveItemFromInventory();

    }
    public void DestroyActionButton()
    {
        if (!CheckItem()) return;
        RemoveItemFromInventory();
    }

    private bool CheckItem()
    {
        return currentItemData != null && content.Contains(currentItemData);
    }

    private void RemoveItemFromInventory()
    {
        content.Remove(currentItemData);
        RefreshContent();
        CloseActionPanel();
    }

}
