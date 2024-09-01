using System.Collections;
using UnityEngine;

public class BallFallHandler : MonoBehaviour
{
    public Transform playerBall;
    private bool hasFallen = false; // To check if the ball has already fallen into the hole
    public float fallDuration = 1.0f; // Duration of the fall animation
    public Transform respawnPoint; // Assign a respawn point in the Inspector
    public float fallDepth = -2f; // Depth to which the ball will fall

    public AudioClip fallSound; // AudioClip for the fall sound effect
    private AudioSource audioSource;
    private BallSoundEffects ballSoundEffects;

    private void Start() {
        ballSoundEffects = playerBall.GetComponent<BallSoundEffects>();
        audioSource = playerBall.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasFallen)
        {
            ballSoundEffects.StopRollingSound();
            audioSource.PlayOneShot(fallSound);
            // Trigger the fall animation
            StartCoroutine(FallIntoHole());

            // Mark the ball as having fallen
            hasFallen = true;
        }
    }

    private IEnumerator FallIntoHole()
    {
        Vector3 startPosition = playerBall.position;
        Vector3 endPosition = new Vector3(startPosition.x, startPosition.y + fallDepth, startPosition.z);
        

        float elapsedTime = 0f;

        // Animate the ball falling
        while (elapsedTime < fallDuration)
        {
            playerBall.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / fallDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the ball reaches the final position
        playerBall.position = endPosition;

        // Optionally, you can respawn the ball after it falls
        yield return new WaitForSeconds(0.5f); // Delay before respawning
        playerBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        playerBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        playerBall.position = respawnPoint.position;

        // Reset the fall state (optional, if you want the ball to be able to fall again later)
        hasFallen = false;
    }
}
