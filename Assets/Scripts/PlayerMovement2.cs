using UnityEngine;

//Script player ikut kursor
public class PlayerMovement2 : MonoBehaviour
{
    // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;

    //kecepatan player
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //kalo klik R, reset ball position (keperluan debug aja)
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBall();
        }

        //ambil posisi mouse
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        
        //atur jaraknya mouse dengan player
        mousePosition.x -= objectPosition.x;
        mousePosition.y -= objectPosition.y;

        //gerakin player ke mouse
        rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, mousePosition.y * speed * Time.deltaTime);
        rigidBody2D.velocity = new Vector2(mousePosition.x * speed * Time.deltaTime, rigidBody2D.velocity.y);
    }

    void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;

        // Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }
}
