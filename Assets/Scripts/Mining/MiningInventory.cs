using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiningInventory : MonoBehaviour
{
    public int amountOfIron = 0;
    public int amountOfCoal = 0;
    public int amountOfDiamond = 0;

    public int turretAmount = 0;
    public int LauncherAmount = 0;
    public int BigLAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("IronText").GetComponent<Text>().text = "Iron \n" + amountOfIron.ToString();
        GameObject.Find("CoalText").GetComponent<Text>().text = "Coal \n" + amountOfCoal.ToString();
        GameObject.Find("DiamondText").GetComponent<Text>().text = "Diamond \n" + amountOfDiamond.ToString();

        GameObject.Find("TurretText").GetComponent<Text>().text = "Turret \n" + "Amount: " + turretAmount.ToString() + "\n Key I";
        GameObject.Find("LauncherText").GetComponent<Text>().text = "Launcher \n" + "Amount: " + LauncherAmount.ToString() + "\n Key O";
        GameObject.Find("BigL Text").GetComponent<Text>().text = "Big Launcher \n" + "Amount: " + BigLAmount.ToString() + "\n Key P";

        if(amountOfIron < 3) {
            GameObject.Find("TurretB").GetComponent<Button>().interactable = false;
        } else {
            GameObject.Find("TurretB").GetComponent<Button>().interactable = true;
            
        }

        if(amountOfCoal < 3) {
            GameObject.Find("LauncherB").GetComponent<Button>().interactable = false;
        } else {
            GameObject.Find("LauncherB").GetComponent<Button>().interactable = true;
        }

        if(amountOfDiamond < 3) {
            GameObject.Find("BigLB").GetComponent<Button>().interactable = false;
        } else {
            GameObject.Find("BigLB").GetComponent<Button>().interactable = true;
        }


    }


  

    

    

    public void createT(){
        amountOfIron -= 3;
        turretAmount += 1;
        GameObject.Find("Computer").GetComponent<AudioSource>().Play(0);
    }

    public void createL(){
        amountOfCoal -= 3;
        LauncherAmount += 1;
        GameObject.Find("Computer").GetComponent<AudioSource>().Play(0);
    }

    public void createB(){
        amountOfDiamond -= 3;
        BigLAmount += 1;
        GameObject.Find("Computer").GetComponent<AudioSource>().Play(0);
    }

}
