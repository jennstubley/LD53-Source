using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaBox : MonoBehaviour
{
    private House currentHouse;
    private float ttl;
    private bool deliverySuccess;
    private Rigidbody2D rb;
    private bool wasMoving;

    // Start is called before the first frame update
    void Start()
    {
        ttl = -1;
        deliverySuccess = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ttl >= 0)
        {
            ttl -= Time.deltaTime;
            if (ttl <= 0)
            {
                Destroy(gameObject);
                return;
            }
        }
        if (rb.velocity.magnitude > 0.001f) wasMoving = true;

        if (ttl == -1 && !deliverySuccess && wasMoving && rb.velocity.magnitude <= .5f)
        {
            ttl = 1f;
            FindObjectOfType<DeliveryController>().CompleteDelivery(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        House house = collision.GetComponentInParent<House>();
        if (house != null && currentHouse == null)
        {
            Debug.Log("Entering house");
            currentHouse = house;
            FindObjectOfType<DeliveryController>().CompleteDelivery(true);
            deliverySuccess = true;
            ttl = 1f;
        }
    }
}
