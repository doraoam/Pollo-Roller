using UnityEngine;
using System.Collections;

public class Spell : IWeapon
{
    public GameObject spellPrefab;
    public Transform projectileExit;

    ItemInventory inventory;

    void Awake()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<ItemInventory>();
        if (inventory == null)
        {
            this.enabled = false;
            return;
        }
    }

    public override void Use()
    {
        GameObject spell = (GameObject)Instantiate(spellPrefab, projectileExit.position, projectileExit.rotation);
        inventory.
        Destroy(spell, 15);
    }
}
