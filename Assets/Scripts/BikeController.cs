using Unity.VisualScripting;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    // Start is called before the first frame update

    public float motorTorque;
    public float brakeTorque;
    public float maxSpeed;
    public float steeringRange;
    public float steeringRangeAtMaxSpeed;
    public float centreOfGravityOffset;

    public WheelControl frontWheel;
    public WheelControl backWheel;

    private Rigidbody rb;

    public HealthBar healthBar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Adjust center of mass vertically, to help prevent the car from rolling
        rb.centerOfMass += Vector3.up * centreOfGravityOffset;

        frontWheel.WheelCollider.motorTorque = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");

        // Calculate current speed in relation to the forward direction of the car
        // (this returns a negative number when traveling backwards)
        float forwardSpeed = Vector3.Dot(transform.forward, rb.velocity);

        // Calculate how close the car is to top speed
        // as a number from zero to one
        float speedFactor = Mathf.InverseLerp(0, maxSpeed, forwardSpeed);

        // Use that to calculate how much torque is available 
        // (zero torque at top speed)
        float currentMotorTorque = Mathf.Lerp(motorTorque, 0, speedFactor);

        // …and to calculate how much to steer 
        // (the car steers more gently at top speed)
        float currentSteerRange = Mathf.Lerp(steeringRange, steeringRangeAtMaxSpeed, speedFactor);

        // Check whether the user input is in the same direction 
        // as the car's velocity
        bool isAccelerating = Mathf.Sign(vInput) == Mathf.Sign(forwardSpeed);

        bool isBraking = Input.GetKey(KeyCode.Space);

        frontWheel.WheelCollider.steerAngle = hInput * currentSteerRange;
        if (isAccelerating)
        {
            backWheel.WheelCollider.motorTorque = vInput * currentMotorTorque;
            backWheel.WheelCollider.brakeTorque = 0;
            frontWheel.WheelCollider.brakeTorque = 0;
        }
        else if(isBraking)
        {
            backWheel.WheelCollider.brakeTorque = Mathf.Abs(vInput) * brakeTorque * 10;
            backWheel.WheelCollider.motorTorque = 0;
        }
        else
        {
            backWheel.WheelCollider.brakeTorque = Mathf.Abs(vInput) * brakeTorque;
            frontWheel.WheelCollider.brakeTorque = Mathf.Abs(vInput) * brakeTorque;
            backWheel.WheelCollider.motorTorque = 0;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
            return;
        if (collision.gameObject.CompareTag("Finish") || collision.gameObject.CompareTag("Start"))
            return;

        healthBar.TakeDamage(25f);
    }
}
