using UnityEngine;
using System.Collections;

public class Spell : IWeapon
{
    public GameObject spellPrefab;
    public Transform projectileExit;

    string name;

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

    public void setPrefab(string name)
    {
        spellPrefab = (GameObject)Resources.Load("Prefab/Item" + name);
        this.name = name;
    }

    public override void Use()
    {
        if (spellPrefab != null)
        {
            GameObject spell = (GameObject)Instantiate(spellPrefab, projectileExit.position, projectileExit.rotation);
            inventory.RemoveItem(name);
            Destroy(spell, 3);
        }
    }
}
