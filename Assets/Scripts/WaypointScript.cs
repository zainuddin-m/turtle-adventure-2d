using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentwaypoint=0;
    [SerializeField] private float spd=3f;
    private void Update()
    {
        if(Vector2.Distance(waypoints[currentwaypoint].transform.position, transform.position)<0.1f){
            currentwaypoint=currentwaypoint+1;
            if (currentwaypoint >= waypoints.Length){
                currentwaypoint=0;
            }
        }
        transform.position=Vector2.MoveTowards(transform.position, waypoints[currentwaypoint].transform.position, (Time.deltaTime*spd));
    }
}
