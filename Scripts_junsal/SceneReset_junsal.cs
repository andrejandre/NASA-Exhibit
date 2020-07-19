using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReset_junsal : MonoBehaviour
{
    public void ResetScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

