using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoFence : MonoBehaviour
{
    GameObject floor;
    GameObject fence;

    Collider floorCol;
    Collider fenceCol;

    public GameObject fencePrefab;

    float allFence;

    public int edges = 4;

    public string inputPointX;
    public string inputPointY;
    public string inputPointZ;

    float fenceLengthX;
    float fenceLengthZ;

    // Use this for initialization
    void Awake()
    {
        floor = GameObject.FindGameObjectWithTag("floor");
        fence = GameObject.FindGameObjectWithTag("fence");

        floorCol = floor.GetComponent<Collider>();
        fenceCol = fence.GetComponent<Collider>();

        fenceLengthX = (int)floorCol.bounds.size.x;
        fenceLengthZ = (int)floorCol.bounds.size.z;

        allFence = ((fenceLengthX * 2) - 2) + ((fenceLengthZ * 2) - 2);

        string[] tempPointX = inputPointX.Split(',');
        string[] tempPointY = inputPointY.Split(',');
        string[] tempPointZ = inputPointZ.Split(',');

        float[] pointX = new float[edges];
        float[] pointY = new float[edges];
        float[] pointZ = new float[edges];

        int pointer = 0;
        for (int i = 0; i < tempPointX.Length; i++)
        {
            bool pointerMoveAbleX = false;
            bool pointerMoveAbleY = false;
            bool pointerMoveAbleZ = false;

            if (tempPointX[i] != ",")
            {
                pointX[pointer] = float.Parse(tempPointX[i]);
                pointerMoveAbleX = true;
            }

            if (tempPointY[i] != ",")
            {
                pointY[pointer] = float.Parse(tempPointY[i]);
                pointerMoveAbleY = true;
            }

            if (tempPointZ[i] != ",")
            {
                pointZ[pointer] = float.Parse(tempPointZ[i]);
                pointerMoveAbleZ = true;
            }

            if (pointerMoveAbleX && pointerMoveAbleY && pointerMoveAbleZ == true)
            {
                pointer++;
            }
        }

        int[] boxMax = new int[edges];

        for (int i = 0; i < edges; i++)
        {
            int max = 0;

            if (i + 1 < edges)
            {
                if (Mathf.Abs(pointX[i + 1] - pointX[i]) > max)
                {
                    max = (int)Mathf.Abs(pointX[i + 1] - pointX[i]);
                }
                else if (Mathf.Abs(pointY[i + 1] - pointY[i]) > max)
                {
                    max = (int)Mathf.Abs(pointY[i + 1] - pointY[i]);
                }
                else if (Mathf.Abs(pointZ[i + 1] - pointZ[i]) > max)
                {
                    max = (int)Mathf.Abs(pointZ[i + 1] - pointZ[i]);
                }
            }
            else if (i + 1 == edges)
            {
                if (Mathf.Abs(pointX[i] - pointX[0]) > max)
                {
                    max = (int)Mathf.Abs(pointX[i] - pointX[0]);
                }
                else if (Mathf.Abs(pointY[i] - pointY[0]) > max)
                {
                    max = (int)Mathf.Abs(pointY[i] - pointY[0]);
                }
                else if (Mathf.Abs(pointZ[i] - pointZ[0]) > max)
                {
                    max = (int)Mathf.Abs(pointZ[i] - pointZ[0]);
                }
            }

            boxMax[i] = max+1;
        }

        for (int i = 0; i < edges; i++)
        {
            int boxRange = boxMax[i];

            if (edges - i > 1)
            {
                float stockX = Mathf.Abs(pointX[i + 1] - pointX[i]) / (boxMax[i] - 1);
                float[] posX = new float[boxRange];
                for (int x = 0; x < boxRange; x++)
                {
                    bool isPluse = true;

                    if (x == 0)
                    {
                        if (pointX[i + 1] > pointX[i])
                        {
                            posX[x] = pointX[i] + stockX;
                            isPluse = true;
                        }
                        else
                        {
                            posX[x] = pointX[i] - stockX;
                            isPluse = false;
                        }
                    }
                    else
                    {
                        if (isPluse)
                        {
                            posX[x] = posX[x - 1] + stockX;
                        }
                        else
                        {
                            posX[x] = posX[x - 1] - stockX;
                        }
                    }
                }

                float stockY = Mathf.Abs((pointY[i + 1]) - pointY[i]) / (boxMax[i] - 1);
                float[] posY = new float[boxRange];
                for (int y = 0; y < boxRange; y++)
                {
                    bool isPluse = true;

                    if (y == 0)
                    {
                        if (pointY[i + 1] > pointY[i])
                        {
                            posY[y] = pointY[i] + stockY;
                            isPluse = true;
                        }
                        else
                        {
                            posY[y] = pointY[i] - stockY;
                            isPluse = false;
                        }
                    }
                    else
                    {
                        if (isPluse)
                        {
                            posY[y] = posY[y - 1] + stockY;
                        }
                        else
                        {
                            posY[y] = posY[y - 1] - stockY;
                        }
                    }
                }

                float stockZ = Mathf.Abs((pointZ[i + 1]) - pointZ[i]) / (boxMax[i] - 1);
                float[] posZ = new float[boxRange];
                for (int z = 0; z < boxRange; z++)
                {
                    bool isPluse = true;

                    if (z == 0)
                    {
                        if (pointZ[i + 1] > pointZ[i])
                        {
                            posZ[z] = pointZ[i] + stockZ;
                            isPluse = true;
                        }
                        else
                        {
                            posZ[z] = pointZ[i] - stockZ;
                            isPluse = false;
                        }                    
                    }
                    else
                    {
                        if (isPluse)
                        {
                            posZ[z] = posZ[z - 1] + stockZ;
                        }
                        else
                        {
                            posZ[z] = posZ[z - 1] - stockZ;
                        }
                    }
                }

                for (int j = 0; j < boxRange; j++)
                {
                    Vector3 destination = new Vector3(posX[j], posY[j], posZ[j]);
                    GameObject fenceObject = (GameObject)Instantiate(fencePrefab, destination, Quaternion.identity);
                }
            }
            else
            {
                float stockX = Mathf.Abs(pointX[0] - pointX[i]) / (boxMax[i] - 1);
                float[] posX = new float[boxRange];
                for (int x = 0; x < boxRange; x++)
                {
                    bool isPluse = true;

                    if (x == 0)
                    {
                        if (pointX[0] > pointX[i])
                        {
                            posX[x] = pointX[i] + stockX;
                            isPluse = true;
                        }
                        else
                        {
                            posX[x] = pointX[i] - stockX;
                            isPluse = false;
                        }
                    }
                    else
                    {
                        if (isPluse)
                        {
                            posX[x] = posX[x - 1] + stockX;
                        }
                        else
                        {
                            posX[x] = posX[x - 1] - stockX;
                        }
                    }
                }

                float stockY = Mathf.Abs(pointY[0] - pointY[i]) / (boxMax[i] - 1);
                float[] posY = new float[boxRange];
                for (int y = 0; y < boxRange; y++)
                {
                    bool isPluse = true;

                    if (y == 0)
                    {
                        if (pointY[0] > pointY[i])
                        {
                            posY[y] = pointY[i] + stockY;
                            isPluse = true;
                        }
                        else
                        {
                            posY[y] = pointY[i] - stockY;
                            isPluse = false;
                        }
                    }
                    else
                    {
                        if (isPluse)
                        {
                            posY[y] = posY[y - 1] + stockY;
                        }
                        else
                        {
                            posY[y] = posY[y - 1] - stockY;
                        }
                    }
                }

                float stockZ = Mathf.Abs(pointZ[0] - pointZ[i]) / (boxMax[i] - 1);
                float[] posZ = new float[boxRange];
                for (int z = 0; z < boxRange; z++)
                {
                    bool isPluse = true;

                    if (z == 0)
                    {
                        if (pointZ[0] > pointZ[i])
                        {
                            posZ[z] = pointZ[i] + stockZ;
                            isPluse = true;
                        }
                        else
                        {
                            posZ[z] = pointZ[i] - stockZ;
                            isPluse = false;
                        }
                    }
                    else
                    {
                        if (isPluse)
                        {
                            posZ[z] = posZ[z - 1] + stockZ;
                        }
                        else
                        {
                            posZ[z] = posZ[z - 1] - stockZ;
                        }
                    }
                }

                for (int j = 0; j < boxRange; j++)
                {
                    Vector3 destination = new Vector3(posX[j], posY[j], posZ[j]);
                    GameObject fenceObject = (GameObject)Instantiate(fencePrefab, destination, Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
