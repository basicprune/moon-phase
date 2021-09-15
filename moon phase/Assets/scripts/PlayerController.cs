using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private float xMove;

    private float zMove;

    private Vector3 movement;

    public int ammo;

    public Transform bulletspawnpos;
    public GameObject bullet;

    public TMP_Text ammoText;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    void Start()
    {
        ammoText.text = Setguitext(); 
    }
    // comment 

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Mouse0))

        {
            if(ammo > 0) 
            {
            Instantiate(bullet, bulletspawnpos.position, gameObject.transform.rotation);
                ammo = ammo - 1;
                ammoText.text = Setguitext();
            }
            else 
            {
                Debug.Log("your dead");
            }

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

    string Setguitext()
    {
        return $"Ammo: {ammo}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ammo crate") 
        {
            ammo = ammo + 100000;
            Destroy(other.gameObject);
            ammoText.text = Setguitext();
        }
    }

}
