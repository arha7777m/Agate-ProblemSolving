using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;

    // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;

    // Titik asal lintasan bola saat ini
    private Vector2 trajectoryOrigin;

    // Untuk mengakses informasi titik asal lintasan
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;

        // Mulai game
        RestartGame();
    }

    private void Update()
    {
        //kalo klik R, restart game (keperluan debug aja)
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;

        // Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        //kondisi koordinat positif / negatif
        float[] random = { -1, 1 };
        int value = Random.Range(0, random.Length);
        float choiceY = random[value]; //arah pada y
        value = Random.Range(0, random.Length);
        float choiceX = random[value]; //arah pada x

        //Tambahkan gaya pada circle ke 4 kemungkinan arah
        //(kiri atas, kiri bawah, kanan bawah, dan kanan atas
        rigidBody2D.AddForce(new Vector2(-xInitialForce*choiceX, yInitialForce*choiceY));
    }

    void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();

        // Setelah 2 detik, berikan gaya ke bola
        Invoke(nameof(PushBall), 2);
    }

    // Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
}
