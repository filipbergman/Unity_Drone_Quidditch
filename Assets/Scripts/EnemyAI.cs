using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject ball;
    public GameObject target;
    public GameObject ballpos;
    private GameObject[] targets;

    private bool hasBall = false;
    private float lastHadBall = 0.0f;

    public float MoveSpeed = 2.0f;


    void OnTriggerEnter(Collider other)
    {
        if (Time.time - lastHadBall > 1)
        {
            if ((other.tag == "Ball") && !hasBall)
            {
                other.gameObject.GetComponent<BallGameplay>().SetOwner(this.gameObject);
                hasBall = true;
                targets = GameObject.FindGameObjectsWithTag("Goal");
                target = targets[Random.Range(0, targets.Length)];
                lastHadBall = Time.time;
            }
            else
            {
                target = GameObject.Find("Drone_root");
            }
        }
        
    }

    public void SetTimer()
    {
        lastHadBall = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Drone_root");
    }

    // Update is called once per frame
    void Update()
    {
        if(target.tag == "Player")
        {
            hasBall = false;
        }
            transform.LookAt(target.transform);

            if (Vector3.Distance(transform.position, target.transform.position) >= 2)
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            }
    }
}
