using UnityEngine;
using Capriccioso;
using System.Collections;



public class Bubble : MonoBehaviour 
{

    public float delayBeforeDestroy = 5f;
    
    public void Start()
    {
        StartCoroutine(PopAfterDelay(delayBeforeDestroy));
    }
    
    public IEnumerator PopAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Animator>().SetTrigger("pop");
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
    
}
