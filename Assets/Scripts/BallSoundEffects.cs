using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSoundEffects : MonoBehaviour
{
    private AudioSource rollingAudioSource;
    private AudioSource collisionAudioSource;
    private Rigidbody rb;
    public float minSpeedForRollingSound = 0.1f;
    public float fadeSpeed = 1.0f;

    void Start()
    {
        // Get the Audio Sources attached to the ball
        AudioSource[] audioSources = GetComponents<AudioSource>();
        rollingAudioSource = audioSources[0]; // Assume the first Audio Source is for rolling
        collisionAudioSource = audioSources[1]; // Assume the second Audio Source is for collisions
        
        // Get the Rigidbody component for speed detection
        rb = GetComponent<Rigidbody>();
        rollingAudioSource.volume = 0f;
    }

    void Update()
    {
        float speed = rb.velocity.magnitude;

        // Fade in the rolling sound if the ball is moving above the minimum speed
        if (speed > minSpeedForRollingSound)
        {
            if (!rollingAudioSource.isPlaying)
            {
                rollingAudioSource.Play(); // Start playing the rolling sound if not already playing
            }
            rollingAudioSource.volume = Mathf.Lerp(rollingAudioSource.volume, 0.5f, fadeSpeed * Time.deltaTime); // Fade in to full volume
        }
        else
        {
            // Fade out the rolling sound when the ball slows down
            rollingAudioSource.volume = Mathf.Lerp(rollingAudioSource.volume, 0f, fadeSpeed * Time.deltaTime);

            // Stop playing the rolling sound once it has fully faded out
            if (rollingAudioSource.volume <= 0.01f)
            {
                rollingAudioSource.Stop();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            collisionAudioSource.Play();
        }
    }

    public void StopRollingSound()
    {
        // Instantly stop the rolling sound
        rollingAudioSource.Stop();
    }
}
