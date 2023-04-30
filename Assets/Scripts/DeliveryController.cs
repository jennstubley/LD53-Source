using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class DeliveryController : MonoBehaviour
{
    [SerializeField] private int deliveryScoreBoost;
    [SerializeField] private GameObject pizzaBoxPrefab;
    [SerializeField] private GameObject deliverySuccess;
    [SerializeField] private GameObject deliveryFailure;
    [SerializeField] private House firstHouse;

    private List<House> allHouses;
    private House currentGoal;
    private float bannerTime;
    private bool pizzaThrown;

    // Start is called before the first frame update
    void Start()
    {
        allHouses = GetComponentsInChildren<House>().ToList();
        currentGoal = firstHouse;
        currentGoal.SetHighlight(true);
        pizzaThrown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (deliveryFailure.activeSelf || deliverySuccess.activeSelf)
        {
            bannerTime -= Time.deltaTime;
            if (bannerTime <= 0)
            {
                deliverySuccess.SetActive(false);
                deliveryFailure.SetActive(false);
            }
        }
    }

    public House GetNextDelivery()
    {
        return currentGoal;
    }

    public void CompleteDelivery(bool success)
    {
        if (success)
        {
            GameController.Instance.UpdateScore(deliveryScoreBoost);
            deliverySuccess.SetActive(true);
            deliverySuccess.GetComponent<AnimateScale>().Go();
            deliveryFailure.SetActive(false);
        }
        else
        {
            deliveryFailure.SetActive(true);
            deliveryFailure.GetComponent<AnimateScale>().Go();
            deliverySuccess.SetActive(false);
        }
        bannerTime = 2f;
        pizzaThrown = false;

        House house = currentGoal;
        house.SetHighlight(false);
        currentGoal = allHouses.Where(h => h != house).OrderBy(h => Guid.NewGuid()).First();
        currentGoal.SetHighlight(true);

    }

    public void ThrowPizza()
    {
        if (pizzaThrown) return;
        pizzaThrown = true;
        GameObject pizzaBox = Instantiate(pizzaBoxPrefab);
        Car car = FindObjectOfType<Car>();
        pizzaBox.transform.position = car.transform.position;
        pizzaBox.GetComponent<Rigidbody2D>().angularVelocity = 45f;
        pizzaBox.GetComponent<Rigidbody2D>().AddForce(-car.transform.right.normalized * 1000);
    }
}
