using UnityEngine;
using System.Collections;

public class Spell : IWeapon
{
    public GameObject spellPrefab;
    public Transform projectileExit;

    public override void Use()
    {
        GameObject spell = (GameObject)Instantiate(spellPrefab, projectileExit.position, projectileExit.rotation);
        Destroy(spell, 30);
    }
}
