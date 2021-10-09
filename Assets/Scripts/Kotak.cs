using UnityEngine;

public class Kotak : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(1);
            Destroy(gameObject);    
        }
    }
}
