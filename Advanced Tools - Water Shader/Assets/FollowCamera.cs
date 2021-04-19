using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    private ReflectionProbe probe;
    private Transform camera;

    private void Awake()
    {
        probe = GetComponent<ReflectionProbe>();
        camera = Camera.main.transform;
    }

    void Update()
    {
        probe.transform.position = new Vector3(
            camera.position.x,
            camera.position.y * -1,
            camera.position.z);

        probe.RenderProbe();
    }
}
