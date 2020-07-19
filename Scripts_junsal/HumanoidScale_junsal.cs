using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidScale_junsal : MonoBehaviour
{
    public GameObject humanoidObject;
    public bool userDistance;
    public float scaleScalar;
    public Vector3 finalScale = new Vector3(1f, 1f, 1f);
    public Light humanoidLight;
    void Start()
    {
        humanoidLight.intensity = 0f;
    }
    void Update()
    {
        userDistance = Vector3.Distance(transform.position, humanoidObject.transform.position) < 1.8f;
        if (userDistance == true)
        {
            scaleScalar += 0.01f;
            humanoidLight.intensity += 0.01f;
            humanoidObject.transform.localScale = new Vector3(scaleScalar, scaleScalar, scaleScalar);
        }        
        if (scaleScalar >= 1f && userDistance == true)
        {
            scaleScalar = 1f;
        }
        if (humanoidLight.intensity >= 1f && userDistance == true)
        {
            humanoidLight.intensity = 1f;
        }
        if (userDistance == false)
        {
            scaleScalar -= 0.01f;
            humanoidObject.transform.localScale = new Vector3(scaleScalar, scaleScalar, scaleScalar);
        }
        if (scaleScalar <= 0f && userDistance == false)
        {
            scaleScalar = 0f;
        }
        if (humanoidLight.intensity <= 0f && userDistance == false)
        {
            humanoidLight.intensity = 0f;
        }
    }
}
