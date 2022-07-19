using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private MoveBehaviour moveBehaviour;

    [SerializeField]
    private Inventory inv;

    private Item currentItem;

    public void doPickup(Item itm)
    {
        if (inv.isFull())
        {
            Debug.Log("Inventory Full, can't pickup " + itm.name);
            return;
        }
        currentItem = itm;

        animator.SetTrigger("Pickup");
        moveBehaviour.canMove = false;
    }

    public void addItemToInventory() {
        inv.AddItem(currentItem.itmData);
        Destroy(currentItem.gameObject);

        currentItem = null;
    }

    public void ReEnableMovements()
    {
        moveBehaviour.canMove = true;
    }

}
