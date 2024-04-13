using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeSoundController : MonoBehaviour
{
    // Start is called before the first frame update

    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;

    private Rigidbody rb;
    private AudioSource audioSource;

    public float minPitch;
    public float maxPitch;
    private float pitchFromCar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        EngineSound();
    }

    void EngineSound()
    {
        currentSpeed = rb.velocity.magnitude;
        pitchFromCar = currentSpeed / 50f;

        if (currentSpeed <= minSpeed)
        {
            audioSource.pitch = minPitch;
        }

        if (currentSpeed > minSpeed && currentSpeed < maxSpeed)
        {
            audioSource.pitch = minPitch + pitchFromCar;
        }

        if (currentSpeed >= maxSpeed)
        {
            audioSource.pitch = maxPitch;
        }
    }
}
