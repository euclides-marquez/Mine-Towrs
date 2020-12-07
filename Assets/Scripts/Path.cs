using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDrawGizmos(){
        for (int i = 0; i < transform.childCount; i++)
            {
                int j = GetNextIndex(i);
                Transform waypoint = transform.GetChild(i);
                Transform waypoint2 = transform.GetChild(j);
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(waypoint.position, 0.5f);
                Gizmos.DrawLine(waypoint.position, waypoint2.position);
                

            }

    }


    private int GetNextIndex(int i)
        {
            if(i +1 == transform.childCount) {
                return i;
            } else {
                return i + 1;
            }
            
        }

    public Vector3 GetChildPos(int i) {
            Transform waypoint = transform.GetChild(i);
            return waypoint.position;
        }

    public int GetChilds(){
            return transform.childCount;
        }

}
