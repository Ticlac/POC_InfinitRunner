using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveLimit = 5f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float forwardSpeed = 10f;


    [SerializeField] private Vector3 currentVelocity = Vector3.zero;
    [SerializeField] private Vector3 currentDirection = Vector3.zero;
    private float currentDistanceTraveled = 0f;
    private float currentFuel;
    

    public UnityEvent<Vector3> OnSetVelocity;
    public UnityEvent<float> OnSetDistance;
    public UnityEvent<float> OnSetMaxFuel;
    public UnityEvent<float> OnSetFuel;


    private void Start()
    {
        currentFuel = 200;
        OnSetMaxFuel.Invoke(currentFuel);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 velocity = Vector3.back * forwardSpeed * Time.deltaTime;
        TravelDistance(velocity.magnitude);
        OnSetVelocity.Invoke(velocity);

        currentDirection = Vector3.SmoothDamp(currentDirection, GetInputDirection(), ref currentVelocity, .2f);
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);
    }

    private void ConsumeFuel(float value)
    {
        currentFuel -= value;
        OnSetFuel.Invoke(currentFuel);
    }
    private void TravelDistance(float dist)
    {
        ConsumeFuel(dist * 5);


        currentDistanceTraveled += dist;
        OnSetDistance.Invoke(currentDistanceTraveled);
    }

    private Vector3 GetInputDirection()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.Q))
            direction += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            direction += Vector3.right;

        if (transform.position.x > moveLimit)
            direction = Vector3.left;
        if (transform.position.x < -moveLimit)
            direction = Vector3.right;
        return direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            Debug.Log("Bidon collecté");

        }
    }
}
