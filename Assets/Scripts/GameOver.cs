using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    GameObject gameOver;
    GameObject[] towers;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Player").GetComponent<Health>().health <= 0){
            towers = GameObject.FindGameObjectsWithTag("Tower");
            foreach (GameObject item in towers)
            {
                item.GetComponent<AudioSource>().enabled = false;
            }
            GameObject.Find("RoundsHandler").SetActive(false);
            Time.timeScale = 1;
            GameObject.Find("Music").SetActive(false);
            gameOver.SetActive(true);
            gameOver.GetComponent<AudioSource>().Play(0);

        }
    }

    public void LoadMenu(){
        Time.timeScale = 0;
        SceneManager.LoadScene("GameScreen", LoadSceneMode.Single);
        
    }
}
