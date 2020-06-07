using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //To manage the speed and for serialization add serialize with pruvate component
    [SerializeField] float turnSpeed = 45.0f;
    [SerializeField] float speed = 20.0f;
    private float horizontalInput ;
    private float forwardInput ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        // we want move here
        //what do we move?For tht we need transform
        // on my machine this is working fine to make sure it works fine on all machines we will mulitply it with time and it is also a standard practice
        transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);
        transform.Rotate(Vector3.up , turnSpeed * horizontalInput * Time.deltaTime);
        
    }
}
