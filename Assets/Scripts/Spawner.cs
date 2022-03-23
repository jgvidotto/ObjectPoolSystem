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
    }

    private void Update()
    {
        objectPool.PoolSpawn("Cube", SpawnZone.Instance.RandomPointInBox(SpawnZone.Instance.transform.position, insideVector), Quaternion.identity);
    }

}
