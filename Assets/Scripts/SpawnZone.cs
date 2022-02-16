using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public float x,y,z;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint();
    }

    private Vector3 SpawnPoint()
    {
        Vector3 p;
        p.x = x;
        p.y = y;
        p.z = z;
        return transform.TransformPoint(p);
    }
    void OnDrawGizmos()
    {
        Vector3 size = new Vector3(x, y, z);
        Gizmos.color = Color.cyan;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, size);
    }


    public Vector3 RandomPointInBox(Vector3 center, Vector3 size)
    {

        return center + new Vector3(
           (Random.value - 0.5f) * size.x,
           (Random.value - 0.5f) * size.y,
           (Random.value - 0.5f) * size.z
        );
    }
}
