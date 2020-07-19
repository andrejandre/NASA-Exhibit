using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeRotate_junsal : MonoBehaviour
{
    float rotateFloat = 0f;

    void Update()
    {
        rotateFloat += 0.2f;
        transform.localEulerAngles = new Vector3(0f, rotateFloat, 0f);
    }
}         
