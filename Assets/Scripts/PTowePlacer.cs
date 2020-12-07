using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PTowePlacer : MonoBehaviour
{

    [SerializeField] GameObject Turret;
    [SerializeField] GameObject Launcher;
    [SerializeField] GameObject BigL;
    Transform Player; 
    Transform FixedPos;
    MiningInventory inventory;
    GameObject currentTurret;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<MiningInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();

        if(Input.GetKeyDown(KeyCode.I) && inventory.turretAmount > 0) {
            print("pushed");
            FixedPos = Player;
            GameObject.Find("Screw").GetComponent<AudioSource>().Play(0);
            currentTurret = Instantiate(Turret, Player);
            inventory.turretAmount -= 1;
            currentTurret.GetComponent<BoxCollider2D>().enabled = false;
        }   

        if(Input.GetKeyDown(KeyCode.O) && inventory.LauncherAmount > 0) {
            print("pushed");
            FixedPos = Player;
            GameObject.Find("Screw").GetComponent<AudioSource>().Play(0);
            currentTurret = Instantiate(Launcher, Player);
            inventory.LauncherAmount -= 1;
            currentTurret.GetComponent<BoxCollider2D>().enabled = false;
        }  

        if(Input.GetKeyDown(KeyCode.P) && inventory.BigLAmount > 0) {
            print("pushed");
            FixedPos = Player;
            GameObject.Find("Screw").GetComponent<AudioSource>().Play(0);
            currentTurret = Instantiate(BigL, Player);
            inventory.BigLAmount -= 1;
            currentTurret.GetComponent<BoxCollider2D>().enabled = false;
        }  





    }

    public Transform GetPos(){
        return FixedPos;
    }



}
