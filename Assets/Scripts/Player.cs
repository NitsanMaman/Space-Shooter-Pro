using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public or private reference
    //data type (int, float, bool, string)
    [SerializeField]
    private float _speed =3.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput,verticalInput,0);

        transform.Translate(direction * _speed * Time.deltaTime);

        // if (transform.position.y >= 0){ 
        //     transform.position = new Vector3(transform.position.x, 0, 0);
        // }
        // else if (transform.position.y <= -3.8f){
        //     transform.position = new Vector3(transform.position.x, -3.8f, 0);
        // }

        // how to use mathf.clamp to ensure we are between -3.8 and 0 we can use this isteade of the prev if else if
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x >= 11.3f){
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f){
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }
}
