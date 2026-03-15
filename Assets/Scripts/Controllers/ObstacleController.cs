using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private SpawnArea[] spawnAreas;
    [SerializeField]
    private ScreenColliderController screenColliderController;

    [SerializeField]
    private GameObject obstaclePrefab;
    [SerializeField]
    private int difficulty = 4;
    
    private void Start()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        if (spawnAreas != null)
        {
            
            List<int> pickedIndex = new List<int>();
            SpawnArea[] selectedAreas = new SpawnArea[difficulty];
            
            for (int i = 0; i < difficulty; i++)
            {
                while (true)
                {
                    int index = Random.Range(0, spawnAreas.Length);
                    if (!pickedIndex.Contains(index))
                    {
                        selectedAreas[i] = spawnAreas[index];
                        pickedIndex.Add(index);
                        break;
                    }
                
                }
            }
            
            for (int i = 0; i < selectedAreas.Length; i++)
            {
                Spawn(selectedAreas[i]);
            }
         
        }
    }

    public void Spawn(SpawnArea area)
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

    Vector3 GetRandomPoint(SpawnArea area)
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
