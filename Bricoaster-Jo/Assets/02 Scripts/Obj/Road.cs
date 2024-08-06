using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour, ISnapping
{
    public void Snapping(Collider otherCollider)
    {
        transform.position = otherCollider.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RoadConnector"))
        {
            Snapping(other);
        }
    }
}
