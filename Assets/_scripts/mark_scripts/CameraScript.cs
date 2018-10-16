using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    internal static object current;
    public Transform player;

    public float smooth = 0.3f;

    public float height;
    public float xAxis = 0;
    public float zAxis = 4;

    private Vector3 velocity = Vector3.zero;


    void Update()
    {
        Vector3 pos = new Vector3();
        pos.x = player.position.x + xAxis;
        pos.z = player.position.z + zAxis;
        pos.y = player.position.y + height;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);

    }

}
