using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMover : MonoBehaviour
{

    int InitialWaypoint = 0;
    Path path;
    Vector3 waypoint;
    [SerializeField] float speed = 5f;
    [SerializeField] float waypointTolerance = 1f;
    public float health = 30f;
    float health2;
    [SerializeField] int monsterDamage = 10;
    RoundsH handler;
    // Start is called before the first frame update
    void Start()
    {
        path = GameObject.Find("Path").GetComponent<Path>();
        waypoint = path.GetChildPos(InitialWaypoint);
        transform.position = waypoint;
        handler = GameObject.Find("RoundsHandler").GetComponent<RoundsH>();
        health2 = health;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if(AtWaypoint()) {
            CycleWaypoint();
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoint, speed*Time.deltaTime);



        
    }

    private bool AtWaypoint() {
            float distanceToWaypoint = Vector3.Distance(transform.position, waypoint);
            return distanceToWaypoint <= waypointTolerance;
        }

        private void CycleWaypoint() {
            int nofChilds;
            nofChilds = path.GetChilds();

            if (nofChilds >= InitialWaypoint) {
                InitialWaypoint = InitialWaypoint + 1;
            } else {
                GameObject.FindWithTag("Player").GetComponent<Health>().health -= monsterDamage;
                if(this.name == "Monster Idle(Clone)"){
                    handler.normalAmount -=1;
                    print("NormalKilled");
                } else if(this.name == "Monster Speeder(Clone)"){
                    handler.speederAmount -=1;
                    print("speeder Killed");
                } 
                if(this.name == "Tanker(Clone)"){
                    print("Tank Detroyed");
                    handler.tankAmount -=1;
                }
                Destroy(gameObject);
                //add helth reducing
            }
            
            
            waypoint = path.GetChildPos(InitialWaypoint);
        }

        void OnTriggerEnter2D(Collider2D other) {
            if(other.tag == "Bullet") {
            if(health <= 0) {
                other.transform.parent.GetComponent<TowerBehaviour>().isDestroyed = true;
                if(this.name == "Monster Idle(Clone)"){
                    handler.normalAmount -=1;
                } else if(this.name == "Monster Speeder(Clone)"){
                    handler.speederAmount -=1;
                } else if(this.name == "Tanker(Clone)"){
                    handler.tankAmount -=1;
                }
                Destroy(gameObject);
            }
            } else if (other.name == "cave Spider"){
                health = Mathf.Infinity;
            }

            


        }

        void OnTriggerExit2D(Collider2D other){
            if(other.name == "cave Spider"){
                health = health2;
            }
            
        }


}
