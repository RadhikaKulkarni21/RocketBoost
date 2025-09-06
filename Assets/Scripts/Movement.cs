using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;
    [SerializeField] float rotationStrength = 10.0f;

    Rigidbody rb;
    AudioSource audioSource;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        //to fly sideways
        float rotationInput = rotation.ReadValue<float>();
        //Debug.Log("Rotation value: " + rotationInput);

        if(rotationInput < 0)
        {
            ApplyRotation(rotationStrength);
        }

        else if(rotationInput > 0){
            //transform.Rotate(Vector3.back);
            ApplyRotation(-rotationStrength);
        }
    }

    private void ApplyRotation(float rotationPerFrame)
    {
        //this is to avoid the space to become upside down hence no being able to thrust
        rb.freezeRotation = true;
        //we rotate it ourself
        transform.Rotate(Vector3.forward * rotationPerFrame * Time.fixedDeltaTime);
        //giving back the rotation reins to unity, once we stop pressing the keys
        rb.freezeRotation = false;
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            //to fly up
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
