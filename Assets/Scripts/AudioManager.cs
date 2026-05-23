using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip hitSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Obstacle.OnObstacleHit += PlayHitSound;
    }

    private void OnDisable()
    {
        Obstacle.OnObstacleHit -= PlayHitSound;
    }

    private void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
