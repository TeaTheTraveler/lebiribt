using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor ;
    private float _rotationX = 0;
    public bool isGround = true;
    public Rigidbody th;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    private float speed = 5.0f;
    private float speed2 = 3.0f;
    private float speed3 = 1.5f;

    void Update()
    {

        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            
            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }


        #region

        if (Input.GetKey(KeyCode.Space) && isGround == true) 
        {
            isGround = false; 
            th.AddForce(new Vector3(0f, 200f, 0f)); 
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) 
            transform.position += transform.forward * Time.deltaTime * speed; 

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)) 
            transform.position -= transform.right * Time.deltaTime * speed;  
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift)) 
            transform.position += transform.right * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift)) 
            transform.position -= transform.forward * Time.deltaTime * speed; 

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftAlt)) 
            transform.position += transform.forward * Time.deltaTime * speed3; 

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftAlt)) 
            transform.position -= transform.right * Time.deltaTime * speed3; 

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftAlt)) 
            transform.position += transform.right * Time.deltaTime * speed3;

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftAlt)) 
            transform.position -= transform.forward * Time.deltaTime * speed3; 

        if (Input.GetKey(KeyCode.W)) 
            transform.position += transform.forward * Time.deltaTime * speed2; 

        if (Input.GetKey(KeyCode.A)) 
            transform.position -= transform.right * Time.deltaTime * speed2; 

        if (Input.GetKey(KeyCode.D)) 
            transform.position += transform.right * Time.deltaTime * speed2;

        if (Input.GetKey(KeyCode.S)) 
            transform.position -= transform.forward * Time.deltaTime * speed2; 

       

        #endregion
    }
 void OnCollisionEnter(Collision gr)
        {
            if (gr.transform.tag == "gr") 
                isGround = true; 
        }
}
