using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private float pickupRange = 2.6f;

    public PickupBehaviour pickupBehaviour;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private GameObject pickupText;

    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position ,transform.forward,out hit, pickupRange, layerMask))
        {
            if (hit.transform.CompareTag("Item"))
            {
                pickupText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickupBehaviour.doPickup(hit.transform.gameObject.GetComponent<Item>());
                }
            }

        }
        else
        {
            pickupText.SetActive(false);
        }
    }
}
