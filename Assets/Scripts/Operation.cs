using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation : MonoBehaviour {
    public GameObject[] bladesOn;
    public GameObject[] bladesOff;
    public bool isOn = false;

    public float jitter = 0.2f; 
    public float hoverHeight = 0.1f;
    private Vector3 origPosition; 
    private Vector3 hoverPosition;

    // Start is called before the first frame update
    void Start() {
        Switch(isOn);
        origPosition = transform.localPosition; 
        hoverPosition = transform.localPosition + new Vector3(0f, hoverHeight, 0f);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) 
            Toggle();
        if (isOn) 
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, hoverPosition + Random.insideUnitSphere, jitter * Time.deltaTime);
        else
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, origPosition, Time.deltaTime);
    }

    private void Switch(bool on) { 
        isOn = on;
        Debug.Log(isOn);
        foreach (GameObject obj in bladesOn) 
            obj.SetActive(isOn); 
        foreach (GameObject obj in bladesOff) 
            obj.SetActive(!isOn); 
    }

    public void Toggle() { 
        Switch(!isOn); 
    }
}
