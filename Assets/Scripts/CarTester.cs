using UnityEngine;

public class CarTester : MonoBehaviour
{
    public float moveSpeed = 1000f;

    public float turnSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        MoveVehicle();
        TurnVehicle();

        if (Input.GetAxis("Vertical") != 0)
        {
            Debug.Log("Car is moving");
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
}
