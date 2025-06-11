using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoint : MonoBehaviour
{

    
    public float movespeed = 5f;
    public float waitTime = 2f;
    public bool loopWaypoints = true;
    public float detectionRange = 3f;
    public int MaxWaypoint = 100;

    // Start is called before the first frame update
    private Transform waypointParent;
    private Transform[] waypoints;
    private int currentWaypointIndex;
    private bool isWaiting;
    private Transform player;
    void Start()
    {
        GameObject waypointObject = GameObject.FindWithTag("Waypoint");
        if (waypointObject != null) 
        {
            waypointParent = waypointObject.transform; 
        }

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        waypoints = new Transform[waypointParent.childCount];
        for (int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }

    }

    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (isWaiting)
        {
            return;
        }

        if (distanceToPlayer <= detectionRange)
        {
            ChasePlayer();
        }
        else
        {
            MoveToWaypoint(); 
        }
       
    }

    void MoveToWaypoint()
    {
        Transform target = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        currentWaypointIndex++;

        if (currentWaypointIndex >= waypoints.Length)
        {
            if (loopWaypoints)
            {
                currentWaypointIndex = 0;
            }
            else
            {
                currentWaypointIndex = waypoints.Length - 1; 
            }
        }

        isWaiting = false;
    }

    void ChasePlayer()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, player.position, movespeed * Time.deltaTime);

    }

}



