using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 3;
    public Transform door;
    public float Duration = 10;
    private float timeElapsed = 0;
    private float beepInterval = 1.0f;
    private AudioSource audioSource;
    public AudioClip beepSound;
    public AudioClip doorSound;
    
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
       
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.up * -moveSpeed * Time.deltaTime;
        }
        float distance = Vector3.Distance(transform.position, door.position);
        beepInterval = Mathf.Lerp(0.1f, 1.0f, distance / Duration);
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= beepInterval)
        {
            //audioSource.Play();
            PlayBeep();
            timeElapsed = 0f;
            Debug.Log("Beep");
        }
        /*else
        {
            timeElapsed = 0;
            Debug.Log("BEEP");
        }*/
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == door)
        {
            PlayDoorSound();
        }
    }
    void PlayBeep()
    {
        if (beepSound !=null)
        {
            audioSource.PlayOneShot(beepSound);
        }
    }
    void PlayDoorSound()
    {
        if (doorSound != null)
        {
            audioSource.PlayOneShot(doorSound);
            beepSound = null;
            moveSpeed = 0;
        }
    }
   /* void soundStops()
    {
        if beepSound && doorSound
    }*/
}
