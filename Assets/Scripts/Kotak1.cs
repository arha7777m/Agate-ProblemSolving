using UnityEngine;

public class Kotak1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(1);
            DissappearKotak();
            Invoke("AppearKotak", 3f);
        }
    }

    void AppearKotak()
    {
        //ambil posisi player
        Vector2 playerPosition = FindObjectOfType<PlayerMovement2>().transform.position;

        //kotak akan muncul dalam area border
        Vector2 randomPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4.25f, 4.25f));

        //ubah posisi random spawn kotak selama posisinya didalam area player
        while ((Mathf.Abs(playerPosition.x - randomPosition.x) < 1) &&
            (Mathf.Abs(playerPosition.y - randomPosition.y) < 1))
        {
            randomPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4.25f, 4.25f));
        }

        //assign posisi kotak yang baru
        transform.position = randomPosition;

        //munculinkotak
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<Collider2D>().enabled = true;
    }

    void DissappearKotak()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
}
