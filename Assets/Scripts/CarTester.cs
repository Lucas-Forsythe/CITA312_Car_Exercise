using UnityEngine;

public class CarTester : MonoBehaviour
{
    private int hitcount = 0;
    //A rigidbody is a class component that allows a GameObject to be affected by physics.
    // Three property names are mass, use gravity, and linear damping.
    private Rigidbody rb;
    public float moveSpeed = 1000f;

    public float turnSpeed = 100f;
    
    void Start()
    {
        // rb is a varaible that references the specific rigidbody component attached to whatever has the CarTester script attached to it.
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.mass = 2f;
        //rb.AddForce(0,0,10000f);
        /*This sent the car flying off the screen.
        rb.AddForce(1000f, 0, 1000f, ForceMode.Impulse);
        */
        /*This sent the car moving but did not ahve the same strenght.
        rb.AddForce(1000f, 0, 1000f, ForceMode.Acceleration);
        Mass can affect forces but only force and impulse.
        */
    }

    // Update is called once per frame
    void Update()
    {
        MoveVehicle();
        TurnVehicle();

        if (Input.GetAxis("Vertical") != 0)
        {
            //Debug.Log("Car is moving");
        }
    }

    void MoveVehicle()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * verticalInput * moveSpeed * Time.deltaTime);

        //Boost
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveSpeed = 1500f;
        }
    }

    void TurnVehicle()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        if (verticalInput != 0)
        {
            transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        hitcount++;
        //Void means return nothing
        //OnCollisionEnter is a built in unity function that is called when two colliders touch
        //Collision is a class that has information such as point of collision and what hit what
        //collision is the variable that is passed into our function
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle Detected");
        }
        Debug.Log("Car has collided with " + collision.gameObject.name);
        Debug.Log("Car has collided " + hitcount + " times");
    }
}
