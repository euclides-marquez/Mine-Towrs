using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MineGenerator : MonoBehaviour
{

    GameObject[] placeHolders;
    [SerializeField] GameObject Rock;
    [SerializeField] GameObject Iron;
    [SerializeField] GameObject Coal;
    [SerializeField] GameObject Diamond;
    GameObject mineralToAdd;
    [SerializeField] int numberOfIron = 300;
    [SerializeField] int numberOfCoal = 150;
    [SerializeField] int numberOfDiamond = 50;
    List<int> addedMinerals = new List<int>();
    bool isContained;
    bool first = false;
    GameObject rockInPlace;
    // Start is called before the first frame update
    void Awake()
    {
       
        placeHolders = GameObject.FindGameObjectsWithTag("Minerals");

        for (int i = 0; i < placeHolders.Length; i++)
        {
            mineralToAdd = Instantiate(Rock, placeHolders[i].transform);
            mineralToAdd.transform.position = placeHolders[i].transform.position;

        }

        //spawns Iron
        for (int i = 0; i < numberOfIron; i++)
        {
            int ironToPlace = Random.Range(0, placeHolders.Length);
            // 10

            if(first == false){
                
                placeHolders[ironToPlace].transform.GetChild(0).GetComponent<RockInitialicer>().repeated = true;

                addedMinerals.Add(ironToPlace);
                mineralToAdd = Instantiate(Iron, placeHolders[ironToPlace].transform);
                mineralToAdd.transform.position = placeHolders[ironToPlace].transform.position;
                
                first = true;
                continue;
            }


            containedInList(addedMinerals, ironToPlace);
            if(isContained) {
                i -= 1;
                continue;
            } else {
                placeHolders[ironToPlace].transform.GetChild(0).GetComponent<RockInitialicer>().repeated = true;
                
                addedMinerals.Add(ironToPlace);
                mineralToAdd = Instantiate(Iron, placeHolders[ironToPlace].transform);
                mineralToAdd.transform.position = placeHolders[ironToPlace].transform.position;
                
            }
            
            
        }

        //Spawns Coal 
        

        for (int i = 0; i < numberOfCoal; i++)
        {
            int coalToPlace = Random.Range(0, placeHolders.Length);
            // 10

           


            containedInList(addedMinerals, coalToPlace);
            if(isContained) {
                i -= 1;
                continue;
            } else {
               placeHolders[coalToPlace].transform.GetChild(0).GetComponent<RockInitialicer>().repeated = true;
                addedMinerals.Add(coalToPlace);
                mineralToAdd = Instantiate(Coal, placeHolders[coalToPlace].transform);
                mineralToAdd.transform.position = placeHolders[coalToPlace].transform.position;
       
            }
            
            
        }

        //Spawns Diamond 
       

        for (int i = 0; i < numberOfDiamond; i++)
        {
            int DToPlace = Random.Range(0, placeHolders.Length);
            // 10

            


            containedInList(addedMinerals, DToPlace);
            if(isContained) {
                i -= 1;
                continue;
            } else {
             placeHolders[DToPlace].transform.GetChild(0).GetComponent<RockInitialicer>().repeated = true;
                addedMinerals.Add(DToPlace);
                mineralToAdd = Instantiate(Diamond, placeHolders[DToPlace].transform);
                mineralToAdd.transform.position = placeHolders[DToPlace].transform.position;
               
            }
            
            
        }


        // int numberOfRock = (((placeHolders.Length - numberOfIron) - numberOfCoal) - numberOfDiamond);
        // for (int i = 0; i < numberOfRock; i++)
        // {
        //     int RockToPlace = Random.Range(0, placeHolders.Length);
        //     containedInList(addedMinerals, RockToPlace);
        //     if(isContained) {
        //         i -= 1;
        //         continue;
        //     } else {
        //         addedMinerals.Add(RockToPlace);
        //         mineralToAdd = Instantiate(Rock, placeHolders[RockToPlace].transform);
        //         mineralToAdd.transform.position = placeHolders[RockToPlace].transform.position;
        //     }
            
        // }


      
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void containedInList(List<int> listToCheck, int numberToCheck) {
      
        foreach (int number in listToCheck){
            if(number == numberToCheck) {
                isContained = true;
                break;
            } else {
                isContained = false;
            }

        }
        
    }
}
