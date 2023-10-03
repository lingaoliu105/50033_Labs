using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class autoGenerator : MonoBehaviour
{
    public GameObject platform;
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;
    public int nPlatforms;
    public GameObject winPoint;
    public float XWidth = 4f;
    public float minY = .2f;
    public float maxY = 1.6f;
    private float lastX;

    private void Start()
    {
        Vector3 spawnPos = new Vector3();
        for (int i = 0; i < nPlatforms; i++)
        {
            spawnPos.y += Random.Range(minY, maxY);
            float newX = Random.Range(-XWidth, XWidth);
            while (Math.Abs(newX - lastX) > 4f)
            {
                newX = Random.Range(-XWidth, XWidth);
            }
            newX = Random.Range(-XWidth, XWidth);
            lastX = newX;
            spawnPos.x = newX;

            if (i == nPlatforms - 1)
            {
                Instantiate(winPoint, spawnPos, Quaternion.identity);
            }
            else
            {
                Instantiate(platform, spawnPos, Quaternion.identity);
                float temp = Random.Range(-2 * XWidth, 2 * XWidth);
                if (spawnPos.y > 15f)
                {
                    int number = Random.Range(0, 8);
                    if (number == 1)
                    {
                        Instantiate(cloud1, new Vector3(-spawnPos.x + temp, spawnPos.y, spawnPos.z), Quaternion.identity);
                    }
                    else if (number == 2)
                    {
                        Instantiate(cloud2, new Vector3(-spawnPos.x + temp, spawnPos.y, spawnPos.z), Quaternion.identity);
                    }
                    else if (number == 3)
                    {
                        Instantiate(cloud2, new Vector3(-spawnPos.x + temp, spawnPos.y, spawnPos.z), Quaternion.identity);
                    }
                }
            }
        }
    }

}