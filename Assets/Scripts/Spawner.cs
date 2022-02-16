using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    ObjectPool objectPool;
    private Vector3 insideVector;
    [SerializeField]
    SpawnZone spawnArea;
    private void Start()
    {
        objectPool = ObjectPool.Instance;
        insideVector = new Vector3(spawnArea.x, spawnArea.y, spawnArea.z);
       
    }

    public void SpawnObject()
    {
        objectPool.AmountToSpawn();

        for (int i = 0; i < objectPool.InputValue; i++)
        {
            objectPool.PoolSpawn("Cube", spawnArea.RandomPointInBox(spawnArea.transform.position, insideVector), Quaternion.identity);
        }
    }

    public void Despawn(string tag)
    {
        objectPool.Despawn(tag);
    }

    private void Update()
    {
        objectPool.Amount = objectPool.Prefabs.ToString();
    }

}
