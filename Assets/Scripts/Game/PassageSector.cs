using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageSector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
