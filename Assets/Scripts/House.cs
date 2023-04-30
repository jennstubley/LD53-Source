using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public string Street;
    public int Number;

    private GameObject highlight;

    private void Awake()
    {
        highlight = transform.Find("Highlight").gameObject;
        highlight.SetActive(false);

    }

    public void SetHighlight(bool value)
    {
        highlight.SetActive(value);
    }
}
