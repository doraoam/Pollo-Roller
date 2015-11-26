using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemInventory : MonoBehaviour
{
    float timer = 0.0f;
    float delay = 0.25f;

    public string spellName;

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
                    spellName = newNum;
                }
            }
            else
            {
                playerInventory.Add(name, amount);
                spellName = name;
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
        }
        

        if (Input.GetButton("Fire1") && playerInventory.Count >= 0)
        {
            GameObject spellCreater = GameObject.FindGameObjectWithTag("script");
            Spell spellCaster = spellCreater.GetComponent<Spell>();

            spellCaster.setPrefab(spellName);
            //spellCaster.Use();
        }

        timer -= Time.deltaTime;
    }

    void ChangeWeapon(bool next)
    {
        List<string> weapons = new List<string>(this.playerInventory.Keys);
        string[] spellList = weapons.ToArray();
        
        if (next == true)
        {
            currentWeaponIndex++;
            
            if (currentWeaponIndex >= weapons.Count)
            {
                currentWeaponIndex = 0;
            }
        }
        else if (next == false)
        {
            currentWeaponIndex--;
            
            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = weapons.Count - 1;
            }
        }

        spellName = spellList[currentWeaponIndex];
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
