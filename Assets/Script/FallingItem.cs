using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class FallingItem : MonoBehaviour
{
    public int itemAmount = 50;
    public bool isFalling = true;

    static int count = 0;

    public GameObject itemPrefab;
    public string name;

    public string inputPointX;
    public string inputPointY;
    public string inputPointZ;

    public string inputFencePointX;
    public string inputFencePointY;
    public string inputFencePointZ;

    float[] pointX;
    float[] pointY;
    float[] pointZ;

    float[] fencePointX;
    float[] fencePointY;
    float[] fencePointZ;

    //store each pos in array
    void Awake()
    {
        string[] tempPointX = inputPointX.Split(',');
        string[] tempPointY = inputPointY.Split(',');
        string[] tempPointZ = inputPointZ.Split(',');

        string[] tempFencePointX = inputFencePointX.Split(',');
        string[] tempFencePointY = inputFencePointY.Split(',');
        string[] tempFencePointZ = inputFencePointZ.Split(',');

        pointX = new float[tempPointX.Length];

        for (int i = 0; i < tempPointX.Length; i++)
        {
            pointX[i] = float.Parse(tempPointX[i]);
        }

        pointY = new float[tempPointY.Length];

        for (int i = 0; i < tempPointY.Length; i++)
        {
            pointY[i] = float.Parse(tempPointY[i]);
        }

        pointZ = new float[tempPointZ.Length];

        for (int i = 0; i < tempPointZ.Length; i++)
        {
            pointZ[i] = float.Parse(tempPointZ[i]);
        }

        fencePointX = new float[tempFencePointX.Length];

        for (int i = 0; i < tempFencePointX.Length; i++)
        {
            fencePointX[i] = float.Parse(tempFencePointX[i]);
        }

        fencePointY = new float[tempFencePointY.Length];

        for (int i = 0; i < tempFencePointY.Length; i++)
        {
            fencePointY[i] = float.Parse(tempFencePointY[i]);
        }

        fencePointZ = new float[tempFencePointZ.Length];

        for (int i = 0; i < tempFencePointZ.Length; i++)
        {
            fencePointZ[i] = float.Parse(tempFencePointZ[i]);
        }
    }

    void Update()
    {
        if (GoalChecker.isOver != true && count<=itemAmount)
        {
            //create random position for each item
            List<Vector3> pos = new List<Vector3>();

            for (int i = 0; i < itemAmount; i++)
            {
                float maxX = Mathf.Max(pointX);
                float maxZ = Mathf.Max(pointZ);
                float maxA = Mathf.Max(fencePointX);
                float maxC = Mathf.Max(fencePointZ);

                float minX = Mathf.Min(pointX);
                float minZ = Mathf.Min(pointZ);
                float minA = Mathf.Min(fencePointX);
                float minC = Mathf.Min(fencePointZ);

                float posX = Random.Range(minX, maxX);
                float posZ;

                if (posX <= maxA && posX >= minA)
                {
                    if (i % 2 == 0)
                    {
                        posZ = Random.Range(maxC, maxZ);
                    }else{
                        posZ = Random.Range(minZ, minC);
                    }
                }
                else
                {
                    posZ = Random.Range(minZ, maxZ);
                }

                pos.Add(new Vector3(posX, pointY[0], posZ));
            }

            //create item until full
            foreach(Vector3 i in pos)
            {
                itemPrefab = (GameObject)Resources.Load("Prefab/" + name);

                GameObject item = (GameObject)Instantiate(itemPrefab, i, Quaternion.identity);
                
                count++;

                //if (count >= itemAmount)
                //{
                //    count = 0;
                //}
            }
        }
    }

    public static void setClear()
    {
        count = 0;
    }
}
