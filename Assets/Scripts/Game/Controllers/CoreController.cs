using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreController : MonoBehaviour
{
    // public static CoreController Instance;
    private float rotSpeed = 300f;

    /* private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    } */

    private void Update()
    {
        // This code for mobile devices
        /* if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 coreRotation = Input.GetTouch(0).deltaPosition;
            core.transform.Rotate(0, coreRotation.x * rotSpeed * Time.deltaTime, 0);
        } */

        //Test code for PC
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            this.transform.Rotate(0, -mouseX * rotSpeed * Time.deltaTime, 0);
        }
    }

    /* public static void DestroyInstance()
    {
        if(Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = null;
        }
    } */
}
