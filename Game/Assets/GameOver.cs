using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private GameObject sara;
    public GameObject gameOverUI;

       
    // Start is called before the first frame update
    void Start() {
        sara = GameObject.FindGameObjectWithTag("Sara");
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update() {        
        if (sara.GetComponent<SaraHealth>().getCurrentHealth()<=0) {
            // Sara is dead
            gameOverUI.SetActive(true);
        }
    }

    public void MainMenu() {
        Debug.Log("Load Main Menu");                
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
