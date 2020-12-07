using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    PTowePlacer placer;
    bool placed = false;
    Transform pos;
    Vector3 fixedP;
    GameObject[] enemies;
    float minDist;
    GameObject ClosestEnemy;
    [SerializeField] float speed = 3f;
  
    [SerializeField] float waitingTime = 5f;
    float currentTime;
    [SerializeField] float range = 5f;
    [SerializeField] GameObject Bullet;
    public bool fired = false;
    GameObject newBullet = null;
    public bool isDestroyed = false;
    bool ignore;
    float TimeToMaterialize = 0;
    
    

    // Start is called before the first frame update
    void Start()
    {
        placer = GameObject.FindWithTag("Player").GetComponent<PTowePlacer>();
        placed = false;
       
        minDist = Mathf.Infinity;
        gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        currentTime = Mathf.Infinity;
    }

    // Update is called once per frame
    void Update()
    {
        // Physics.IgnoreCollision(GameObject.FindWithTag("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>(), ignore = true);

        


        currentTime += Time.deltaTime;
      


        TimeToMaterialize += Time.deltaTime;
        if(TimeToMaterialize >= 5f){
            GetComponent<BoxCollider2D>().enabled = true;
        }


        //Fix the tower Position 
         if (placed == false) {
             pos = placer.GetPos();
          
             fixedP = pos.position;
             placed = true;
        }
        gameObject.transform.position = fixedP;
        



        if(currentTime >= 0.2f){
            isDestroyed = true;
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject t in enemies)
        {
           
            float dist = Vector3.Distance(t.transform.position, transform.position);
            
            if(isDestroyed == true) {
                minDist = Mathf.Infinity;
                isDestroyed = false;
            }
            
            if (dist < minDist)
            {
                
                ClosestEnemy = t;
                minDist = dist;
                
            }
         
            float distClosest = Vector3.Distance(ClosestEnemy.transform.position, transform.position);
            if(distClosest > minDist) {
                minDist = distClosest;
            }
            // if (dist > minDist) {
            //     minDist = dist;
            // }

        }

           
        
         
         Vector3 dir = ClosestEnemy.transform.position - transform.position;
         float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        

        if(Vector3.Distance(ClosestEnemy.transform.position, transform.position) <= range) {
            if(currentTime >= waitingTime){
                fire();
                currentTime = 0;
            }
            
        } else {
            newBullet.GetComponent<BulletMover>().toDestroy();
            
        }

        if(newBullet != null){
            newBullet.transform.position = Vector3.MoveTowards(newBullet.transform.position, ClosestEnemy.transform.position, speed*Time.deltaTime);
        }

        

        


        
        
    }


    private void fire(){
        
        if(fired == false){
        newBullet = Instantiate(Bullet, gameObject.transform);
        if(!GameObject.FindWithTag("Player").GetComponent<PlayerMover>().isInCave){
            GetComponent<AudioSource>().Play(0);
        }
        
        fired = true;
        }


        Vector3 dir = ClosestEnemy.transform.position - newBullet.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);  
        
        
      


    }



  






}
