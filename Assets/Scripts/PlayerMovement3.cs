using UnityEngine;

//Script player gerak keyboard, arahin player dengan kursor
public class PlayerMovement3 : MonoBehaviour
{
    //gameobject peluru
    [SerializeField] private GameObject peluruPrefab;
    [SerializeField] private Transform peluruPoint;
    
    [SerializeField] private GameObject endPanel;

    //rigidbody 2D bola
    private Rigidbody2D rigidBody2D;

    //besarnya gaya awal yang diberikan untuk mendorong bola
    private float moveInputX;
    private float moveInputY;

    //kecepatan player
    public float speed;

    //bool lagi shoot
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //kalo klik R, reset ball position (keperluan debug aja)
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }

        if (Input.GetMouseButtonDown(0))
        {
            isMoving = false;
            Shoot();
        }

        isMoving = true;

        //ambil posisi mouse
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);

        //atur jaraknya mouse dengan player
        mousePosition.x -= objectPosition.x;
        mousePosition.y -= objectPosition.y;

        //rotasi player
        float angle = Mathf.Atan2(mousePosition.x, mousePosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, (angle + 270) * -1));

        //kalo lagi gk nembak, bisa jalan
        if (isMoving)
        {
            //input & bergerak move x
            moveInputX = Input.GetAxis("Horizontal");
            rigidBody2D.velocity = new Vector2(moveInputX * speed * Time.deltaTime, rigidBody2D.velocity.y);

            //input & bergerak move y
            moveInputY = Input.GetAxis("Vertical");
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, moveInputY * speed * Time.deltaTime);
        }    
    }

    void ResetGame()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;

        // Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }

    void Shoot()
    {
        Instantiate(peluruPrefab, peluruPoint.transform.position, peluruPoint.transform.rotation);
    }

    private void OnDestroy()
    {
        Time.timeScale = 0;
        endPanel.SetActive(true);
    }
}
