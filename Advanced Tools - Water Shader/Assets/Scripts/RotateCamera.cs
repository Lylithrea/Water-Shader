using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public int rotX, rotY, rotZ;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(rotX, rotY, rotZ));
    }
}
