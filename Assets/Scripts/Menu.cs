using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    GameObject mainMenu;
    GameObject maps;
    GameObject tutorial;
    GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu = GameObject.Find("MainMenu");
        maps = GameObject.Find("Maps");
        tutorial = GameObject.Find("Tutorial");
        credits = GameObject.Find("Credits");
        Time.timeScale = 1;

        maps.SetActive(false);
        tutorial.SetActive(false);
        credits.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openMaps(){
        GameObject.Find("Click").GetComponent<AudioSource>().Play(0);
        mainMenu.SetActive(false);
        maps.SetActive(true);
        
    }

    public void openTutorial(){
        GameObject.Find("Click").GetComponent<AudioSource>().Play(0);
        tutorial.SetActive(true);
        mainMenu.SetActive(false);
        
    }

    public void openCredits(){
        GameObject.Find("Click").GetComponent<AudioSource>().Play(0);
        credits.SetActive(true);
        mainMenu.SetActive(false);
        
    }

    public void returnToMenu(){
        GameObject.Find("Click").GetComponent<AudioSource>().Play(0);
        maps.SetActive(false);
        tutorial.SetActive(false);
        credits.SetActive(false);
        mainMenu.SetActive(true);
        
    }

    public void LoadScene(){
        GameObject.Find("Click").GetComponent<AudioSource>().Play(0);
        SceneManager.LoadScene("Map1", LoadSceneMode.Single);
        
    }

    public void LoadLevel2(){
        GameObject.Find("Click").GetComponent<AudioSource>().Play(0);
        SceneManager.LoadScene("Map3", LoadSceneMode.Single);
    }

    public void LoadLevel3(){
        GameObject.Find("Click").GetComponent<AudioSource>().Play(0);
        SceneManager.LoadScene("Map2", LoadSceneMode.Single);
    }

    public void ExitGame(){
        Application.Quit();
    }

}
