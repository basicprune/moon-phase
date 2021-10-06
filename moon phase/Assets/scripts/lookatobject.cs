using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatobject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objecttolookat;
    public float rotatespeed;
    void Start()
    {
        objecttolookat = GameObject.Find("Vehicle");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetdirection = objecttolookat.transform.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetdirection, rotatespeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

    }
}
