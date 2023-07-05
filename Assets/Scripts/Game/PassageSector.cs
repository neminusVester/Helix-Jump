using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageSector : MonoBehaviour
{
    public static int completedPassageCount = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            completedPassageCount += 1;
            GameEvents.Instance.PlayerPassedPlatform();
            Destroy(transform.parent.gameObject);
        }
    }



#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log($"count passage sector: {PassageSector.completedPassageCount}");
        }
    }
#endif 

}
