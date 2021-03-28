using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGameplay : MonoBehaviour
{
    public GameObject particlePrefab;
    public GameObject ballPrefab;
    public GameObject owner = null;

    private bool isOwned = false;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Goal")
        {
            Instantiate(particlePrefab, transform.position, Quaternion.identity);
            Instantiate(ballPrefab, new Vector3(0, 10, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (other.tag == "Wall")
        {
            Instantiate(ballPrefab, new Vector3(0, 10, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void SetOwner(GameObject o)
    {
        if(owner != null)
        {
            if (owner.tag == "Player")
            {
                owner.GetComponent<FlightControl>().SetTimer();
            }
            if (owner.tag == "Enemy")
            {
                owner.GetComponent<EnemyAI>().SetTimer();
            }

        }
        
        owner = o;
        isOwned = true;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isOwned)
        {
            transform.position = owner.transform.Find("BallPos").transform.position;
        }
    }
}
