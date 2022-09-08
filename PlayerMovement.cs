using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;

    public float rangeX = 13.5f;
    public float horizontalMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if (horizontalMovement > 0 && transform.position.x < rangeX || horizontalMovement < 0 && transform.position.x > -rangeX)
        {
            transform.Translate(Vector3.right * speed * horizontalMovement * Time.deltaTime);
        }
        // same function as the code above but dont looks great
        /* transform.position += Vector3.right * speed * horizontalMovement * Time.deltaTime;
         if (transform.position.x > rangeX)
         {
             transform.position = new Vector3(rangeX, transform.position.y, transform.position.z);
         }
         if (transform.position.x < -rangeX)
         {
             transform.position = new Vector3(-rangeX, transform.position.y, transform.position.z);
         }
         */

    }
}
