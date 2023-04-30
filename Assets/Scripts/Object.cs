using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private int pointLoss;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Car car = collision.gameObject.GetComponentInParent<Car>();
        if (car != null)
        {
            car.Crash(collision.GetContact(0), this);
            Debug.Log("Hit something!");
            GameController.Instance.UpdateScore(-pointLoss);
        }
    }
}
