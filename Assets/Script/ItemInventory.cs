using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemInventory : MonoBehaviour
{
    float timer = 0.0f;
    float delay = 0.25f;
    IWeapon[] weapons;
    private int currentWeaponIndex = 0;

    Dictionary<string, int> playerInventory;

    void Awake()
    {
        playerInventory = new Dictionary<string, int>();
    }

    // Use this for initialization
    void Start()
    {
        weapons = GetComponentsInChildren<IWeapon>();
        DisableWeapons();
    }

    // Update is called once per frame
    void DisableWeapons(){
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(false);
        }
        weapons[currentWeaponIndex].gameObject.SetActive(true);
    }

    public void AddItem(string name, int amount)
    {
        if (playerInventory.ContainsKey(name))
        {
            playerInventory[name] += amount;
        }
        else
        {
            playerInventory.Add(name, amount);
        }

        if (playerInventory[name] < 0)
        {
            playerInventory[name] = 0;
        }
    }

    public void RemoveItem(string name, int amount)
    {
        if (playerInventory.ContainsKey(name))
        {
            playerInventory[name] -= amount;
        }

        if (playerInventory[name] < 0)
        {
            playerInventory[name] = 0;
        }
    }

    void Update()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (playerInventory.Count > 0)
        {
            if (scrollWheel > 0 && timer < 0)
            {
                timer = delay;

                ChangeWeapon(true);
            }
            else if (scrollWheel < 0 && timer < 0)
            {
                timer = delay;

                ChangeWeapon(false);
            }
            timer -= Time.deltaTime;
        }
    }

    void ChangeWeapon(bool next)
    {
        if (next == true)
        {
            currentWeaponIndex++;

            if (currentWeaponIndex >= weapons.Length)
            {
                currentWeaponIndex = 0;
            }
        }
        else if (next == false)
        {
            currentWeaponIndex--;
            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = weapons.Length - 1;
            }
        }
        DisableWeapons();
    }

    public bool HasItem(string name)
    {
        if (playerInventory.ContainsKey(name))
        {
            if (playerInventory[name] > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
