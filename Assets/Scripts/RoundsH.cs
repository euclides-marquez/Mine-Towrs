using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsH : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject normal;
    [SerializeField] GameObject Speeder;
    [SerializeField] GameObject Tank;
    public int CurrentRound = 1;
    bool roundCleared = true;
    int normalAmountI = 3;
    int speederAmountI = 0;
    int tankAmountI = 0;
    public int normalAmount = 3;
    public int speederAmount = -1;
    public int tankAmount = -1;
    int SnormalAmount = 3;
    int SspeederAmount;
    int StankAmount;
    [SerializeField] float waitingTime = 10f;
    [SerializeField] float tolerance = 1f;
    float passingTime;
    float passingTime2;
    float passingTime3;
    int totalAmount;

    GameObject currentMonster;
    float normalNewHealth;
    float speedNewHealth;
    float tankNewHealth;


    void Start()
    {
        Instantiate(normal, transform.position, new Quaternion(0,0,0,0));
        passingTime = Mathf.Infinity;
        passingTime2 = 0;

        normalNewHealth = normal.GetComponent<MonsterMover>().health;
        speedNewHealth = Speeder.GetComponent<MonsterMover>().health;
        tankNewHealth = Tank.GetComponent<MonsterMover>().health;
        
    }

    // Update is called once per frame
    void Update()
    {

        totalAmount = normalAmount + speederAmount + tankAmount;
        GameObject.Find("Round").GetComponent<Text>().text = "Round: " + CurrentRound.ToString();

        if(totalAmount <= 0){


            CurrentRound += 1;
            GameObject.Find("Round").GetComponent<Text>().text = "Round: " + CurrentRound.ToString();

            if(CurrentRound >= 10){
                speederAmount = CurrentRound - 9;
            }
            if(CurrentRound >= 25){
                tankAmount = CurrentRound - 24;
            }

            normalAmount = normalAmountI + CurrentRound;
            SnormalAmount = normalAmount;

            
            SspeederAmount = speederAmount;

            
            StankAmount = tankAmount;

        }

        if(CurrentRound >= 18){
            normalNewHealth = normal.GetComponent<MonsterMover>().health*2;
        }
        if(CurrentRound >= 35){
            speedNewHealth = Speeder.GetComponent<MonsterMover>().health*2;
        }
        if(CurrentRound >= 45){
            tankNewHealth = Tank.GetComponent<MonsterMover>().health*2;
        }



        totalAmount = normalAmount + speederAmount + tankAmount;




        if(SnormalAmount > 0){
            if(waitingTime <= passingTime){
            currentMonster =  Instantiate(normal, transform.position, new Quaternion(0,0,0,0));
            currentMonster.GetComponent<MonsterMover>().health = normalNewHealth;
            SnormalAmount -= 1;
            passingTime = 0;
            }
        }

        if(SspeederAmount > 0){
            if(waitingTime <= passingTime2-tolerance){
            currentMonster = Instantiate(Speeder, transform.position, new Quaternion(0,0,0,0));
            currentMonster.GetComponent<MonsterMover>().health = speedNewHealth;
            SspeederAmount -= 1;
            passingTime2 = 0;
            }
        }

        if(StankAmount > 0){
            if(waitingTime <= (passingTime3-tolerance)-2){
            currentMonster = Instantiate(Tank, transform.position, new Quaternion(0,0,0,0));
            currentMonster.GetComponent<MonsterMover>().health = tankNewHealth;
            StankAmount -= 1;
            passingTime3 = 0;
            
            }
        }

        




        passingTime += Time.deltaTime;
        passingTime2 += Time.deltaTime;
        passingTime3 += Time.deltaTime;



    }

    



}
