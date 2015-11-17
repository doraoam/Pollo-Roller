using UnityEngine;
using System.Collections;

public class Spell : IWeapon
{
    public string spellName;
    public int amount;

    public GameObject spellPrefab;
    public Transform projectileExit;

    bool useable = true;

    ItemInventory inventory;

    void Awake()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<ItemInventory>();
    }

    public override void Use()
    {
        GameObject spell = (GameObject)Instantiate(spellPrefab, projectileExit.position, projectileExit.rotation);
        Destroy(spell, 15);
        useable = false;
    }

    void Update()
    {
        if (useable != true)
        {
            inventory.RemoveItem(name, amount);
        }
    }
}
