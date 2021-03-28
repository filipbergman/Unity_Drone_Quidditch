using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControl : MonoBehaviour {
    public float speed = 1.5f;
    public float turnSpeed = 600f;
    private CharacterController controller; 
    private Vector3 moveDirection;
    public GameObject ballpos;
    public GameObject ball;

    private float lastHadBall = 0.0f;

    void OnTriggerEnter(Collider other)
    {
        if(Time.time - lastHadBall > 1)
        {
            if((other.tag == "Ball"))
            {
                other.gameObject.GetComponent<BallGameplay>().SetOwner(this.gameObject);
                ball = other.gameObject;
            }
            lastHadBall = Time.time;
        }
    }

    public void SetTimer()
    {
        lastHadBall = Time.time;
    }

    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        if(ball.GetComponent<BallGameplay>().owner == this.gameObject)
        {
            if (Input.GetKey(KeyCode.F))
            {
                ball.GetComponent<Rigidbody>().AddForce(transform.forward * 1200);
            }
        }

        float deltaZ = 0f;
        float deltaY = 0f;


        transform.Rotate(0f, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0f);
        deltaZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
            deltaY = speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftControl))
            deltaY = -speed * Time.deltaTime;
        moveDirection = transform.up * deltaY + transform.forward * deltaZ;
        controller.Move(moveDirection);
    }
}
