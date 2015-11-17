using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemInventory : MonoBehaviour
{
    float timer = 0.0f;
    float delay = 0.25f;

    public float fireDelay = 0.25f;

    private int currentWeaponIndex = 0;

    Dictionary<string, int> playerInventory;

    void Awake()
    {
        playerInventory = new Dictionary<string, int>();
    }

    public void AddItem(string name, int amount)
    {
        List<string> list = new List<string>(playerInventory.Keys);
        int count = 0;
        foreach (string obj in list)
        {
            count += playerInventory[obj];
        }

        if (count < 4)
        {
            if (playerInventory.ContainsKey(name))
            {
                playerInventory[name] += amount;
                string check = name.Substring(1);
                if (check != "4")
                {
                    int num = int.Parse(name);
                    num += 1;
                    string newNum = num.ToString();
                    playerInventory.Add(newNum, 1);
                }
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
        else
        {
            Debug.Log("You can't keep more");
        }
    }

    public void RemoveItem(string name, int amount)
    {
        if (playerInventory.ContainsKey(name))
        {
            playerInventory[name] -= amount;

            if (playerInventory[name] == 0)
            {
                playerInventory.Remove(name);
            }
        }

        if (playerInventory[name] < 0)
        {
            playerInventory[name] = 0;
        }
    }

    void Update()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

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

        if (Input.GetButton("Fire1"))
        {
            if (timer <= 0)
            {
                timer = fireDelay;
            }
        }

        timer -= Time.deltaTime;
    }

    void ChangeWeapon(bool next)
    {
        if (next == true)
        {
            currentWeaponIndex++;

            if (currentWeaponIndex >= playerInventory.Count)
            {
                currentWeaponIndex = 0;
            }
        }
        else if (next == false)
        {
            currentWeaponIndex--;
            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = playerInventory.Count - 1;
            }
        }
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
