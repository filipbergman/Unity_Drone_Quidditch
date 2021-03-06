using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailFollow : MonoBehaviour {
    public Transform target;
    public float sensitivity = 5f;
    private Vector3 distance;

    // Start is called before the first frame update
    void Start() {
        distance = new Vector3(0f, 0f, (transform.position - target.position).magnitude); 
        transform.SetParent(target);
    }

    // Update is called once per frame
    void Update() {
        distance.z -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;

        if (Input.GetMouseButton(0)) { 
            transform.Rotate(0f, Input.GetAxis("Mouse X") * sensitivity, 0f, Space.World); 
            transform.Rotate(-Input.GetAxis("Mouse Y") * sensitivity, 0f, 0f, Space.Self); 
        }
        transform.position = target.position - transform.rotation * distance;
    }
}
