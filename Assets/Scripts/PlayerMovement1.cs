using UnityEngine;

//skrip input player gerak
//kiri, kanan, atas, bawah
public class PlayerMovement1 : MonoBehaviour
{
    // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;

    // Besarnya gaya awal yang diberikan untuk mendorong bola
    private float moveInputX;
    private float moveInputY;

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

        //input & bergerak move x
        moveInputX = Input.GetAxis("Horizontal");
        rigidBody2D.velocity = new Vector2(moveInputX * speed * Time.deltaTime, rigidBody2D.velocity.y);

        //input & bergerak move y
        moveInputY = Input.GetAxis("Vertical");
        rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, moveInputY * speed * Time.deltaTime);
    }

    void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;

        // Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }
}
