using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerals : MonoBehaviour
{
    public float durability = 30f;
    public float iDurability;
    // Start is called before the first frame update
    void Start()
    {
        iDurability = durability;
    }

    // Update is called once per frame
    void Update()
    {
        if(durability <= 0) {
            if(this.name == "steel(Clone)") {
                GameObject.FindWithTag("Player").GetComponent<MiningInventory>().amountOfIron += 1;
            } else if (this.name == "coal(Clone)"){
                GameObject.FindWithTag("Player").GetComponent<MiningInventory>().amountOfCoal += 1;
            } else if (this.name == "Diamond(Clone)") {
                GameObject.FindWithTag("Player").GetComponent<MiningInventory>().amountOfDiamond += 1;
            }

            GameObject.FindWithTag("Player").GetComponent<PlayerMining>().isMined = true;
            Destroy(gameObject);
        }
        
    }
}
