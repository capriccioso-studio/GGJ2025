using UnityEngine;
using Capriccioso;


public class Bubble : MonoBehaviour 
{

    public float delayBeforeDestroy = 5f;
    
    public void Start()
    {
        Destroy(gameObject, delayBeforeDestroy);
    }
    
}
