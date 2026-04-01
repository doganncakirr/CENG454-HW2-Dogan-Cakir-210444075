// FlightController.cs
// CENG 454 HW1: Sky-High Prototype
// Author: Doğan Çakır | Student ID: 210444075

using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f;   // degrees/second
    [SerializeField] private float yawSpeed = 45f;     // degrees/second
    [SerializeField] private float rollSpeed = 45f;    // degrees/second
    [SerializeField] private float thrustSpeed = 5f;   // units/second

    // TODO (Task 3-A): Declare a private Rigidbody field named 'rb'
    private Rigidbody rb;

    void Start()
    {
        // TODO (Task 3-B): Cache GetComponent<Rigidbody>() into 'rb'.
        rb = GetComponent<Rigidbody>();
        
        // Then set rb.freezeRotation = true.
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        // TODO (Task 3-C): Pitch, Yaw, Roll
        
        // Pitch (Arrow Up/Down)
        float pitchInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * pitchSpeed * Time.deltaTime * pitchInput);

        // Yaw (Arrow Left/Right)
        float yawInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * yawSpeed * Time.deltaTime * yawInput);

        // Roll (Q/E keys)
        float rollInput = 0f;
        if (Input.GetKey(KeyCode.Q)) rollInput = 1f;
        if (Input.GetKey(KeyCode.E)) rollInput = -1f;
        transform.Rotate(Vector3.forward * rollSpeed * Time.deltaTime * rollInput);
    }

    private void HandleThrust()
    {
        // TODO (Task 3-D): Thrust
        
        // Forward thrust (Spacebar)
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}