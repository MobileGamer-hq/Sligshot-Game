using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SomtoObstacleSpawning : MonoBehaviour
{
    [SerializeField]
    private SomtoSpawnArea[] spawnAreas;

    [SerializeField]
    private GameObject obstaclePrefab;

    private void Start()
    {
        if (spawnAreas != null)
        {
            for (int i = 0; i < spawnAreas.Length; i++)
            {
                Spawn(spawnAreas[i]);
            }
        }
    }

    public void Spawn(SomtoSpawnArea area)
    {
        Vector3 pos = GetRandomPoint(area);

        Quaternion rot = GetRandomRotation();

        Instantiate(obstaclePrefab, pos, rot);
    }

    Quaternion GetRandomRotation()
    {
        
        float randomZ = Random.Range(0f, 360f); //I will add contraints to it but this is just a prototype
        return Quaternion.Euler(0f, 0f, randomZ);
    }

    Vector3 GetRandomPoint(SomtoSpawnArea area)
    {
        Vector3 min = area.areaCorners[0].position;
        Vector3 max = area.areaCorners[0].position;

        foreach (Transform t in area.areaCorners)
        {
            min = Vector3.Min(min, t.position);
            max = Vector3.Max(max, t.position);
        }

        Vector3 random = new Vector3(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y),
            0f
        );

        return random;
    }
}