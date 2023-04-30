using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryUI : MonoBehaviour
{
    [SerializeField] private DeliveryController deliveryController;
    private Text deliveryText;
    private AnimateScale animateScale;
    private House targetHouse;

    // Start is called before the first frame update
    void Start()
    {
        deliveryText = GetComponent<Text>();
        animateScale = GetComponent<AnimateScale>();
    }

    // Update is called once per frame
    void Update()
    {
        House house = deliveryController.GetNextDelivery();
        if (house != targetHouse)
        {
            if (targetHouse != null) animateScale.Go();
            targetHouse = house;
            deliveryText.text = string.Format("Next Delivery:   {0} {1}", targetHouse.Number, targetHouse.Street);
        }
    }
}
