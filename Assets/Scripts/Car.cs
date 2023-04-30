using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float crashTime;
    [SerializeField] private GameObject crashObj;
    private Rigidbody2D rb;
    private DeliveryController deliveryController;
    private float crashTimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        deliveryController = FindObjectOfType<DeliveryController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.Instance.IsPaused)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
            return;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Accelerating
            rb.AddRelativeForce(Vector3.up * acceleration);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // Accelerating backwards
            rb.AddRelativeForce(Vector3.down * (acceleration / 2f));
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.angularVelocity = rb.velocity.magnitude * rotationSpeed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.angularVelocity = rb.velocity.magnitude * -rotationSpeed;
        }
    }

    private void Update()
    {
        if (GameController.Instance.IsPaused) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            deliveryController.ThrowPizza();
        }

        if (crashObj.activeSelf)
        {
            crashTimeLeft -= Time.deltaTime;
            if (crashTimeLeft <= 0)
            {
                crashObj.SetActive(false);
            }
        }
    }

    public void Crash(ContactPoint2D contactPoint2D, Object obj)
    {
        crashObj.SetActive(true);
        crashObj.transform.position = contactPoint2D.point;
        crashTimeLeft = crashTime;
    }
}
