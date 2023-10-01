using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class autoGenerator : MonoBehaviour
{
    public GameObject platform;
    public int nPlatforms;
    public GameObject winPoint;
    public float XWidth = 3f;
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
            }
        }
    }
}