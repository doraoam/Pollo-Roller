using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public string itemName = "";
    public int amount = 1;

    ItemInventory inventory;

    void Awake()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<ItemInventory>();
        if (inventory == null)
        {
            this.enabled = false;
            return;
        }
        //gameObject.layer = LayerMask.NameToLayer("Interactable");
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Player"))
        {
            inventory.AddItem(itemName, amount);
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        transform.Rotate(Vector3.up * 25 * Time.deltaTime);
    }
}
