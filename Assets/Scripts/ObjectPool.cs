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
        public GameObject prefab;
        public string tag;
    }

    [SerializeField]
    private TMP_InputField inputField;

    [SerializeField]
    TextMeshProUGUI amount;

    public string Amount
    {
        set => amount.text = value;
    }

 

    public List<Pool> poolList;

    public Dictionary<string, Queue<GameObject>> poolDict;

    public static ObjectPool Instance;

    private List<GameObject> prefabs = new List<GameObject>();

    public int Prefabs
    {
        get { return prefabs.Count; }
    }
    public int InputValue
    {
        get { return int.Parse(inputField.text); }
    }

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
        poolDict = new Dictionary<string, Queue<GameObject>>();

    }

    public void AmountToSpawn()
    {
        if(InputValue > 0)
        {
            foreach (Pool p in poolList)
            {
                Queue<GameObject> poolObject = new Queue<GameObject>();

                for (int i = 0; i < InputValue; i++)
                {
                    GameObject ob = Instantiate(p.prefab);
                    ob.SetActive(false);
                    poolObject.Enqueue(ob);
                    if (!prefabs.Contains(ob)) prefabs.Add(ob);
                }
                if (!poolDict.ContainsKey(p.tag))
                {
                    poolDict.Add(p.tag, poolObject);
                }
                else
                {
                    poolDict[p.tag] = poolObject;
                }
            }
        }
        
    }

    public void Despawn(string tag)
    {
        if (InputValue <= poolDict[tag].Count)
        {

            StopAllCoroutines();
            for (int i = 0; i < InputValue; i++)
            {
                GameObject obToRemove = poolDict[tag].Dequeue();
                prefabs.Remove(obToRemove);
                obToRemove.SetActive(false);
            }

            Debug.Log(poolDict[tag].Count);

        }
    }

    public GameObject PoolSpawn(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDict.ContainsKey(tag))
        {
            return null;
        }
        GameObject obToSpawn = poolDict[tag].Dequeue();

        obToSpawn.SetActive(true);
        obToSpawn.transform.position = position;
        obToSpawn.transform.rotation = rotation;

        poolDict[tag].Enqueue(obToSpawn);
        return obToSpawn;
    }
}
