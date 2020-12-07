using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Mining"){
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, -2f);
        } else {
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, -1.5f);
        }
    
    }

    void OnTriggerExit2D(Collider2D other) {
        other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, 0f);
    }
}
