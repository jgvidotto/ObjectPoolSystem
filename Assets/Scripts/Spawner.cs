using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    ObjectPool objectPool;
    private Vector3 insideVector;
    private void Start()
    {
        objectPool = ObjectPool.Instance;
        insideVector = new Vector3(SpawnZone.Instance.x, SpawnZone.Instance.y, SpawnZone.Instance.z);
        ObjectPool.DoneInit += Init;
    }

    public void Init(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            objectPool.PoolSpawn("Cube", SpawnZone.Instance.RandomPointInBox(SpawnZone.Instance.transform.position, insideVector), Quaternion.identity);
        }
    }

    public void SpawnObject()
    {
        //objectPool.AmountToSpawn();

        for (int i = 0; i < objectPool.InputValue; i++)
        {
            objectPool.PoolSpawn("Cube", SpawnZone.Instance.RandomPointInBox(SpawnZone.Instance.transform.position, insideVector), Quaternion.identity);
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
