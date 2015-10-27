using UnityEngine;
using System.Collections;

public class Command : MonoBehaviour
{
    public string level;

    public void LoadLevel()
    {
        Application.LoadLevel(level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
