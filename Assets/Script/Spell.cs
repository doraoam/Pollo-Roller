using UnityEngine;
using System.Collections;

public class Spell : IWeapon
{
    public GameObject spellPrefab;
    public Transform projectileExit;

    public void setPrefab(string name)
    {
        spellPrefab = (GameObject)Resources.Load("Prefab/Item" + name);
    }

    public override void Use()
    {
        GameObject spell = (GameObject)Instantiate(spellPrefab, projectileExit.position, projectileExit.rotation);
        Destroy(spell, 15);
    }
}
