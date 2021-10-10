using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{ 
    public void QuitGame()
    {
        Debug.Log("Keluar!");
        Application.Quit();
    }

    public void GoToScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
