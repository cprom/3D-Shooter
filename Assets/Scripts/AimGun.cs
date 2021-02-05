using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGun : MonoBehaviour
{
    public Camera aimCamera;

    // Start is called before the first frame update
    void Start()
    {
        aimCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightControl))
        {
            aimCamera.enabled = true;
        }
        else
        {
            aimCamera.enabled = false;
        }
    }
}
