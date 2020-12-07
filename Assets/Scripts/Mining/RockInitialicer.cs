using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockInitialicer : MonoBehaviour
{
    public bool repeated;
    // Start is called before the first frame update
    void Start()
    {
        
        if(repeated){
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
