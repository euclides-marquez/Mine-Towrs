using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void FixedUpdate() {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
