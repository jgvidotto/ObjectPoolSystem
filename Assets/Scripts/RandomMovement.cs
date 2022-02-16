using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{

    [SerializeField] 
    [Range(1, 10)] private float speed;
    private Vector3 tempDestination;

    void Start()
    {
        
        tempDestination = new Vector3(Random.Range(0, 5) + Random.Range(0, 5),
                  transform.position.y + Random.Range(0, 5),
                  transform.position.z + Random.Range(0, 5));
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, tempDestination, speed * Time.deltaTime);

    }


}
