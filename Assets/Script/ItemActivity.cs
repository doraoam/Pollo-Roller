using UnityEngine;
using System.Collections;

public class ItemActivity : IWeapon
{
    public GameObject itemPrefab;
    public Transform projectileExit;

    public override void Use()
    {
        GameObject spell = (GameObject)Instantiate(itemPrefab, projectileExit.position, projectileExit.rotation);
        Destroy(spell, 15);
    }
}
