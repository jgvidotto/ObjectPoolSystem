using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public FindNearestNeighbour prefab;
        public string tag;
        public int amount;
    }

    #region PRIVATE_MEMBERS
    private List<GameObject> prefabs = new List<GameObject>();
    #endregion

    #region PUBLIC_MEMBERS

    public Dictionary<string, Queue<FindNearestNeighbour>> poolDict;
    public List<Pool> poolList;
    public int Prefabs
    {
        get { return prefabs.Count; }
    }

    public static ObjectPool Instance;
    #endregion

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        poolDict = new Dictionary<string, Queue<FindNearestNeighbour>>();
        InitPool();
    }

    public void InitPool()
    {
        foreach (Pool p in poolList)
        {
            Queue<FindNearestNeighbour> poolObject = new Queue<FindNearestNeighbour>();

            for (int i = 0; i < p.amount; i++)
            {
                AddObject(p, poolObject);
            }
            if (!poolDict.ContainsKey(p.tag))
            {
                poolDict.Add(p.tag, poolObject);
            }
        }
    }

    private void AddObject(Pool p, Queue<FindNearestNeighbour> poolObject)
    {
        FindNearestNeighbour ob = Instantiate(p.prefab, transform);
        ob.gameObject.SetActive(false);
        poolObject.Enqueue(ob);
        if (!prefabs.Contains(ob.gameObject)) prefabs.Add(ob.gameObject);
    }

    public FindNearestNeighbour PoolSpawn(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDict.ContainsKey(tag))
        {
            return null;
        }
        FindNearestNeighbour obToSpawn = poolDict[tag].Dequeue();
        obToSpawn.gameObject.SetActive(true);
        obToSpawn.transform.position = position;
        obToSpawn.transform.rotation = rotation;
        poolDict[tag].Enqueue(obToSpawn);
        return obToSpawn;
    }
}
