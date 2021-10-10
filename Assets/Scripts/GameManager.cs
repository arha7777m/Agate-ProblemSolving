using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //set nilai awal skor menjadi 0
        AddScore(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void AddScore(int amount)
    {
        //tambah skor sebanyak amount
        score += amount;

        //update nilai score pada text
        scoreText.text = score.ToString("0");
    }

    public void QuitGame()
    {
        Debug.Log("Keluar!");
        Application.Quit();
    }

    public void RestartGame()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexScene);
    }

    public void GoToScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
