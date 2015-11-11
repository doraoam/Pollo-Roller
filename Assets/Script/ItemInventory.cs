using UnityEngine;
using System.Collections;

public class ItemInventory : MonoBehaviour
{
    float timer = 0.0f;
    float delay = 0.25f;
    IWeapon[] weapons;
    private int currentWeaponIndex = 0;

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

    void Update()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel > 0 && timer < 0)
        {
            timer = delay;

            ChangeWeapon(false);
        }
        timer -= Time.deltaTime;
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
}
