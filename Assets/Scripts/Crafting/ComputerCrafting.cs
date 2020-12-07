using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerCrafting : MonoBehaviour
{
    // Start is called before the first frame update
    bool turned = false;
    [SerializeField] float range = 4f;
    GameObject menu;
    void Start()
    {
        GameObject.Find("MenuText").GetComponent<Text>().enabled = false;
        menu = GameObject.Find("CraftingMenu");
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) <= range){
        if(Input.GetKeyDown(KeyCode.T)){
            print("pushado");
            if(turned == false){
                menu.SetActive(true);
                GameObject.Find("MenuText").GetComponent<Text>().enabled = false; 
                turned = true; 
            } else {
                menu.SetActive(false);
                GameObject.Find("MenuText").GetComponent<Text>().enabled = true;
                turned = false; 
            }
            

        }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag != "Player") return;
        GameObject.Find("MenuText").GetComponent<Text>().enabled = true;
        
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag != "Player") return;
        GameObject.Find("MenuText").GetComponent<Text>().enabled = false;
        menu.SetActive(false);
    }
}
