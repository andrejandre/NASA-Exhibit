using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Juno_junsal : MonoBehaviour
{
    public VideoPlayer junoDocu;
    public Collider playCollider;
    public Collider pauseCollider;
    public Collider stopCollider;
    public Collider launchCollider;
    public GameObject playObj;
    public GameObject pauseObj;
    public GameObject stopObj;
    public GameObject junoTV;
    public GameObject launchButton;
    public RaycastHit hit;
    public ParticleSystem launchParticles;
    public AudioSource launchAudio;
    private float scaleX = 0.5927929f;
    private float scaleY;
    private float scaleZ = -0.006415213f;
    private float buttonScalar;
    public float scalarPlayPause;
    public bool hitPause = false;
    public bool hitPlay = false;
    public bool hitStop = false;
    public bool hitLaunch = false;
    public bool userDistance;
    void Start()
    {
        junoTV.transform.localScale = new Vector3(0f, 0f, scaleZ);
        junoDocu.Stop();
        playObj.transform.localScale = new Vector3(0f, 0f, 0f);
        pauseObj.transform.localScale = new Vector3(0f, 0f, 0f);
        stopObj.transform.localScale = new Vector3(0f, 0f, 0f);
        launchButton.transform.localScale = new Vector3(0f, 0f, 0f);
        launchParticles.Stop();
        launchAudio = GetComponent<AudioSource>();
    }
    void Update ()
    {
        userDistance = Vector3.Distance(transform.position, junoTV.transform.position) < 1.6f;
        if (userDistance == true)
        {
            scaleY += 0.003f;
            scalarPlayPause += 0.004f;
            buttonScalar += 0.006f;
            junoTV.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            playObj.transform.localScale = new Vector3(scalarPlayPause, scalarPlayPause, scalarPlayPause);
            pauseObj.transform.localScale = new Vector3(scalarPlayPause, scalarPlayPause, scalarPlayPause);
            stopObj.transform.localScale = new Vector3(scalarPlayPause, scalarPlayPause, scalarPlayPause);
            launchButton.transform.localScale = new Vector3(buttonScalar, buttonScalar, buttonScalar);
        }
        if (userDistance == true && scaleY >= 0.390325f)
        {
            scaleY = 0.390325f;
        }
        if (userDistance == true && scalarPlayPause >= 0.1f)
        {
            scalarPlayPause = 0.1f;
        }
        if (userDistance == true && buttonScalar >= 1.4824f)
        {
            buttonScalar = 1.4824f;
        }
        if (userDistance == false)
        {
            scaleY -= 0.003f;
            scalarPlayPause -= 0.004f;
            junoTV.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            playObj.transform.localScale = new Vector3(scalarPlayPause, scalarPlayPause, scalarPlayPause);
            pauseObj.transform.localScale = new Vector3(scalarPlayPause, scalarPlayPause, scalarPlayPause);
            stopObj.transform.localScale = new Vector3(scalarPlayPause, scalarPlayPause, scalarPlayPause);
        }
        if (userDistance == false && scaleY <= 0f)
        {
            scaleY = 0f;
        }
        if (userDistance == false && scalarPlayPause <= 0f)
        {
            scalarPlayPause = 0f;
        }
        if (userDistance == false && buttonScalar <= 0f)
        {
            buttonScalar = 0f;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickLocation = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(clickLocation);
            hitPlay = playCollider.Raycast(ray, out hit, 10000f);
            hitPause = pauseCollider.Raycast(ray, out hit, 10000f);
            hitStop = stopCollider.Raycast(ray, out hit, 10000f);
            hitLaunch = launchCollider.Raycast(ray, out hit, 10000f);
        }
        if (hitPlay == true)
        {
            PlayVideo();
            hitPlay = false;
        }
        if (hitPause == true)
        {
            PauseVideo();
            hitPause = false;
        }
        if (hitStop == true)
        {
            StopVideo();
            hitStop = false;
        }
        if (hitLaunch == true)
        {
            // do something for engine thrust particle effects
            launchAudio.Play(0);
            launchParticles.Play();
            hitLaunch = false;
        }


    }
    public void PlayVideo()
    {
        junoDocu.Play();
    }
    public void PauseVideo()
    {
        junoDocu.Pause();
    }
    public void StopVideo()
    {
        junoDocu.Stop();
    }
}
