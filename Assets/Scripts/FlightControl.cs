using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControl : MonoBehaviour {
    public float speed = 2f;
    public float turnSpeed = 20f;
    private Operation operation;
    private CharacterController controller; 
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start() {
        operation = GetComponentInChildren(typeof(Operation)) as Operation;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        float deltaZ = 0f;
        float deltaY = 0f;

        if (operation.isOn) {
            transform.Rotate(0f, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0f); 
            deltaZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;    
            if (Input.GetKey(KeyCode.PageUp))
                deltaY = speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.PageDown))
                deltaY = -speed * Time.deltaTime;
        } else {
            if (controller.isGrounded == false)
                deltaY = Physics.gravity.y * Time.deltaTime;
        }
        moveDirection = transform.up * deltaY + transform.forward * deltaZ;
        controller.Move(moveDirection);
    }
}
