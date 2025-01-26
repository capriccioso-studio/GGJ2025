using System.Collections;
using Capriccioso;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public int BubbleCount;
    public int RemainingBubbles;
    [Header("ColorChanges")]
    public SpriteRenderer spriteRenderer;
    public Color underwaterColor;
    
    [Header("SFX")]
    public AudioSource audioSource;
    public AudioClip snowHitSFX, slideSFX, waterSplash;
    public bool isSliding;

    [Header("Feedbacks")] 
    public MMF_Player HitGroundFeedback;
    
    public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        RemainingBubbles = BubbleCount;
        UIManager.Instance.gameplayUIHandler.SetBubblesText(RemainingBubbles);
        transform.position = GamePositionsReferences.Instance.startPos.position;
        rb2d.linearVelocity = Vector2.zero;

    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Underwater") && spriteRenderer != null)
        {
            spriteRenderer.color = underwaterColor;
            float velocityMagnitude = rb2d.linearVelocity.magnitude;
            float volume = Mathf.Clamp01(velocityMagnitude / 10f);
            audioSource.PlayOneShot(waterSplash, 0.1f);
        }
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && audioSource != null)
        {
            float velocityMagnitude = rb2d.linearVelocity.magnitude;
            float volume = Mathf.Clamp01(velocityMagnitude / 10f); // Adjust the divisor to control sensitivity
            audioSource.PlayOneShot(snowHitSFX, volume);
            HitGroundFeedback.PlayFeedbacks();
        }
        
        
    }
    
    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {

        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
        }
    }

    public void Die()
    {
        GetComponent<Animator>().SetTrigger("Die");
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Underwater") && spriteRenderer != null)
        {
            CLogger.Instance.Log("Player is out of water");
            spriteRenderer.color = Color.white;
        }
    }
}