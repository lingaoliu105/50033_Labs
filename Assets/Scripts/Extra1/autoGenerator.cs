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

    public GameObject parentObject;

    private void Start()
    {
        build();
    }

    private void build()
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
                GameObject child = Instantiate(winPoint, spawnPos, Quaternion.identity);
                child.transform.SetParent(parentObject.transform);
            }
            else
            {
                GameObject child = Instantiate(platform, spawnPos, Quaternion.identity);
                child.transform.SetParent(parentObject.transform);
                float temp = Random.Range(-2 * XWidth, 2 * XWidth);
                if (spawnPos.y > 15f)
                {
                    int number = Random.Range(0, 8);
                    if (number == 1)
                    {
                        GameObject child1 = Instantiate(cloud1, new Vector3(-spawnPos.x + temp, spawnPos.y, spawnPos.z), Quaternion.identity);
                        child1.transform.SetParent(parentObject.transform);
                    }
                    else if (number == 2)
                    {
                        GameObject child2 = Instantiate(cloud2, new Vector3(-spawnPos.x + temp, spawnPos.y, spawnPos.z), Quaternion.identity);
                        child2.transform.SetParent(parentObject.transform);
                    }
                    else if (number == 3)
                    {
                        GameObject child3 = Instantiate(cloud2, new Vector3(-spawnPos.x + temp, spawnPos.y, spawnPos.z), Quaternion.identity);
                        child3.transform.SetParent(parentObject.transform);
                    }
                }
            }
        }
    }

    public void clean()
    {
        foreach (Transform child in parentObject.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void Restart()
    {
        clean();
        build();
    }
}