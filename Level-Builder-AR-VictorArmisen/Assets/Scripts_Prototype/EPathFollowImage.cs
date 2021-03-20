using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPathFollowImage : MonoBehaviour
{
    public int indexPath = 0;
    private ImageTrackSingle imageTrackSingle;
    public float speed;
    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        imageTrackSingle = GameObject.FindGameObjectWithTag("SessionOrigin").GetComponent<ImageTrackSingle>();
    }

    void Update()
    {
        Vector3 desiredVelocity = imageTrackSingle.points[indexPath].transform.position - transform.position;
        desiredVelocity.Normalize();
        body.velocity = desiredVelocity;
        if (Vector3.Distance(transform.position, imageTrackSingle.points[indexPath].transform.position) < 0.15f) //If we're using really small sizes, we will have errors in distances. 
        {
            indexPath++;
        }
        if (indexPath >= imageTrackSingle.points.ToArray().Length)
        {
            //Destroy(this.gameObject);
            indexPath = 0;
        }
    }
}
