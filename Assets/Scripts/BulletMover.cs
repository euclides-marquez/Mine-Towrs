using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] float damage = 10f;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 enPos = closestEn.transform.position;
        // print(enPos);
        // transform.position = Vector3.MoveTowards(transform.position, closestEn.transform.position, speed*Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != "Enemy") return;
        print("entered");
        transform.parent.GetComponent<TowerBehaviour>().fired = false;
        other.GetComponent<MonsterMover>().health -= damage;
        Destroy(gameObject);
    }

    public void toDestroy() {
        transform.parent.GetComponent<TowerBehaviour>().fired = false;
        Destroy(gameObject);
    }
}
