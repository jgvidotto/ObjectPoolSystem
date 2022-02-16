using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FindNearestNeighbour : MonoBehaviour
{
    public static List<FindNearestNeighbour> findNearestNeighbours = new List<FindNearestNeighbour>();
    private KdTree<FindNearestNeighbour> kdTreeFindNearestNeighbours = new KdTree<FindNearestNeighbour>();
    private FindNearestNeighbour kdTreeFindNearestNeighbour;
    private void Start()
    {
        findNearestNeighbours.Add(this);
        kdTreeFindNearestNeighbours.AddAll(findNearestNeighbours.Where(n => n && n != this).ToList());
        StartCoroutine(TraceLine());
    }

    public void OnDisable()
    {
        findNearestNeighbours.Remove(this);
        kdTreeFindNearestNeighbours.Clear();
        kdTreeFindNearestNeighbours.AddAll(findNearestNeighbours.Where(n => n && n != this).ToList());
    }

    public IEnumerator TraceLine()
    {
        while (findNearestNeighbours.Count > 1)
        {
            kdTreeFindNearestNeighbour = kdTreeFindNearestNeighbours.FindClosest(transform.position);


            if (kdTreeFindNearestNeighbour != null)
                Debug.DrawLine(transform.position, kdTreeFindNearestNeighbour.transform.position, Color.red);

            yield return null;
        }

    }

}
