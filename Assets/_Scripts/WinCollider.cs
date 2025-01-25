using UnityEngine;

public class WinCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
            GameManager.Instance.NextLevel();
    }
}
