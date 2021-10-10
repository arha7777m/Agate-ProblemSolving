using UnityEngine;

public class Peluru : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.right, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            SpriteRenderer enemy = collision.gameObject.GetComponent<SpriteRenderer>();
            enemy.color = Color.white;
            collision.gameObject.tag = "CanDestroy";
            Destroy(gameObject);
        }
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
