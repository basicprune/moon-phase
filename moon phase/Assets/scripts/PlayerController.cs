using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private float xMove;

    private float zMove;

    private Vector3 movement;



    public Transform bulletspawnpos;
    public GameObject bullet;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Start()
    {
        
    }
    // comment 

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))

        {
            Instantiate(bullet, bulletspawnpos.position, gameObject.transform.rotation);
        }




        if (Input.GetKey(KeyCode.W))
        {


            zMove = 1;

        }


        else if (Input.GetKey(KeyCode.S))
        {

            zMove = -1;

        }
        else
        {
            zMove = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {


            xMove = 1;

        }


        else if (Input.GetKey(KeyCode.A))
        {

            xMove = -1;

        }
        else
        {
            xMove = 0;
        }

        Debug.Log(zMove);
        Debug.Log(xMove);

        float yRotation = Input.GetAxisRaw("Mouse X");
        transform.Rotate(0, yRotation, 0);

        movement = new Vector3(xMove, 0, zMove);
        transform.Translate(movement.x * speed * Time.deltaTime, movement.y, movement.z * speed * Time.deltaTime);

    }
}
