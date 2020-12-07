using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMining : MonoBehaviour
{
    GameObject[] minerals;
    public bool isMined = false;
    GameObject ClosestMineral;
    float minDist;
    Animator animator;
    [SerializeField] float MiningRange = 1f;
    [SerializeField] float miningDamage = 10f;
    [SerializeField] float WaitingTime = 5f;
    float coolDown;
    int percentage;
    float iDurability;
    bool playing = false;
    // Start is called before the first frame update
    void Start()
    {
        minDist = Mathf.Infinity;
        animator = GameObject.Find("IdlePick").GetComponent<Animator>();
        animator.enabled = false;
        coolDown = Mathf.Infinity;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        coolDown += Time.deltaTime;
        minerals = GameObject.FindGameObjectsWithTag("Mining");

        foreach (GameObject t in minerals)
        {
            
            float dist = Vector3.Distance(t.transform.position, transform.position);
            
            if(isMined == true) {
                minDist = Mathf.Infinity;
                isMined = false;
            }
            
            if (dist < minDist)
            {
                
                ClosestMineral = t;
                minDist = dist;
                
            }
         
            float distClosest = Vector3.Distance(ClosestMineral.transform.position, transform.position);
            if(distClosest > minDist) {
                minDist = distClosest;
            }
            // if (dist > minDist) {
            //     minDist = dist;
            // }

        }

         print("Enemigo más cercado: " + ClosestMineral); 

         if(Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)){
            animator.enabled = true;

             if(GetComponent<PlayerMover>().isInCave){
                 if(!playing){
                     GetComponent<AudioSource>().Play(0);
                     playing = true;
                 }
             } else {
                 GetComponent<AudioSource>().Pause();
                 playing = false;
             }

            if(Vector3.Distance(transform.position, ClosestMineral.transform.position) <= MiningRange){
               
                iDurability = ClosestMineral.GetComponent<Minerals>().iDurability;
                percentage = Mathf.RoundToInt((ClosestMineral.GetComponent<Minerals>().durability * 100) / iDurability);
                GameObject.Find("Durability").GetComponent<Text>().text = "Rock Durability: " + percentage.ToString() + "%";
                if(WaitingTime <= coolDown){
                ClosestMineral.GetComponent<Minerals>().durability -= miningDamage; 
                coolDown = 0; 
                iDurability = ClosestMineral.GetComponent<Minerals>().iDurability;
                percentage = Mathf.RoundToInt((ClosestMineral.GetComponent<Minerals>().durability * 100) / iDurability);
                GameObject.Find("Durability").GetComponent<Text>().text = "Rock Durability: " + percentage.ToString() + "%";
                }
                
            }


         } else {
             animator.enabled = false;
             playing = false;
              GetComponent<AudioSource>().Pause();
             GameObject.Find("Durability").GetComponent<Text>().text = "Rock Durability: " + "%";
         }



    }
}
