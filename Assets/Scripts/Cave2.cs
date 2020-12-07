using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave2 : MonoBehaviour
{
    void Update(){
        transform.position = new Vector3(transform.position.x, transform.position.y, -5);
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag != "Player") return;
        print("entrando por la casa");
        other.transform.position = new Vector3(GameObject.Find("Cave").transform.position.x,GameObject.Find("Cave").transform.position.y - 3.5f,0);
        GameObject.FindWithTag("Player").GetComponent<PlayerMover>().isInCave = false;
    }
}
