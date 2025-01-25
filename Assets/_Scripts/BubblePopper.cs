using System;
using UnityEngine;

public class BubblePopper : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            other.GetComponent<Animator>().SetTrigger("pop");
            Destroy(other.gameObject, 0.2f);
        }
    }
}
