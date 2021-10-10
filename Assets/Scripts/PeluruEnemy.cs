using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeluruEnemy : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.right, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
