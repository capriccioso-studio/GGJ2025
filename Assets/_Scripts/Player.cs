using System;
using Capriccioso;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("ColorChanges")]
    public SpriteRenderer spriteRenderer;
    public Color underwaterColor;
    
    [Header("SFX")]
    public AudioSource audioSource;
    public AudioClip snowHitSFX, slideSFX;
    public bool isSliding;

    public void Start()
    {
        
    }
    
    public void Update()
    {
        if (isSliding && audioSource.isPlaying == false)
        {
            audioSource.clip = slideSFX;
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Underwater"))
        {
            spriteRenderer.color = underwaterColor;
        }
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            audioSource.PlayOneShot(snowHitSFX);
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isSliding = false;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Underwater"))
        {
            CLogger.Instance.Log("Player is out of water");
            spriteRenderer.color = Color.white;
        }
    }
}
