using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundSaver : MonoBehaviour
{
    // Start is called before the first frame update
    Scene currentScene;
    int Map1Score;
    int Map2Score;
    int Map3Score;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        currentScene = SceneManager.GetActiveScene();
        
        if(currentScene.name == "Map1"){
            Map1Score = GameObject.Find("RoundsHandler").GetComponent<RoundsH>().CurrentRound;
           
        }

        if(currentScene.name == "Map3"){
            Map2Score = GameObject.Find("RoundsHandler").GetComponent<RoundsH>().CurrentRound;
           
        }

        if(currentScene.name == "Map2"){
            Map3Score = GameObject.Find("RoundsHandler").GetComponent<RoundsH>().CurrentRound;
        
        }


        if(currentScene.name == "GameScreen"){
        if(Map1Score >= 50){
            GameObject.Find("Map2").GetComponent<Button>().interactable = true;
        }

        if(Map2Score >= 50){
            GameObject.Find("Map3").GetComponent<Button>().interactable = true;
        }
        }






        
    }


    public void UnlockALL(){
        Map1Score = 100;
        Map2Score = 100;
        Map3Score = 100;
        print("Total power");
    }
}
