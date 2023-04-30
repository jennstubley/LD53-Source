using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateScale : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;

    private float time = -1;
    private bool started = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!started) return;
        time += Time.deltaTime;
        if (time > animationCurve.keys[animationCurve.length - 1].time)
        {
            return;
        }
        transform.localScale = Vector3.one * animationCurve.Evaluate(time);
    }

    public void Go()
    {
        started = true;
        time = 0f;
    }
}
