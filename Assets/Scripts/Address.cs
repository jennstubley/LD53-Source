using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Address : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        House house = GetComponentInParent<House>();
        GetComponent<TMP_Text>().text = house.Number.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
