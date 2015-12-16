using UnityEngine;
using System.Collections;

public class IWeapon : MonoBehaviour
{
    private float timer = 0;
    public float fireDelay = 1f;
    public bool hasWeapon = true;

    ItemInventory inventory;

    void Awake()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<ItemInventory>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (timer <= 0)
            {
                Use();
                timer = fireDelay;
            }
        }
        timer -= Time.deltaTime;
    }

    public virtual void Use()
    {

    }
}
