using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovetowards : MonoBehaviour
{
    public GameObject bloodexplosion;
    public GameObject player;
    public float speed;
    Rigidbody rb;

    public float timetodie;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Vehicle");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 alienpos = this.transform.position;
        Vector3 playerpos = player.transform.position;
        this.transform.position = Vector3.MoveTowards(alienpos, playerpos, speed * Time.deltaTime);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {

            rb.freezeRotation = false;
            speed = 0;
            Instantiate(bloodexplosion, transform.position, Quaternion.identity);
            Destroy(gameObject, timetodie);
        }
    }

    private void OnDestroy()
    {
        Instantiate(bloodexplosion, transform.position, Quaternion.identity);
    }

}
