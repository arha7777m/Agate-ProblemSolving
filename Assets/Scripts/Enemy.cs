using UnityEngine;

public class Enemy : MonoBehaviour
{
    //gameobject peluru
    [SerializeField] private GameObject peluruPrefab;

    //selang waktu nembak
    [SerializeField] private float shootRate;

    private float spawnCounter;

    //player
    public float speed;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = shootRate;
    }

    private void Update()
    {
        //cari player
        player = FindObjectOfType<PlayerMovement3>().gameObject;

        //kalo konter 0, tembak, set ulang konternya
        spawnCounter -= Time.deltaTime;
        if (spawnCounter < 0.1)
        {
            Shoot();
            spawnCounter = shootRate;
        }

        //ambil posisi player
        Vector3 playerPosition = player.transform.position;
        playerPosition.z = 0;

        //atur jaraknya enemy dengan player
        playerPosition.x -= transform.position.x;
        playerPosition.y -= transform.position.y;

        //rotasi enemy
        float angle = Mathf.Atan2(playerPosition.x, playerPosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, (angle + 270) * -1));
    }

    void Shoot()
    {
        Instantiate(peluruPrefab, transform.position, transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("CanDestroy") && collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(2);
            Destroy(gameObject);
        }
    }
}
