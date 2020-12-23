using UnityEngine;
using System.Collections;

public class wallavoidance : MonoBehaviour {

    GameObject[] waypoints;
    Rigidbody2D mrb;

    [SerializeField]
    int current;
    [SerializeField]
    float speed;
    [SerializeField]
    float stoppingDistance;
    [SerializeField]
    bool breaking;
    [SerializeField]
    float rayDistance;

    bool moving = false;

    // Use this for initialization
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        mrb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            moving = true;
        }
        if (moving)
        {
            if (Vector2.Distance(gameObject.transform.position, waypoints[current].transform.position) > stoppingDistance)
            {
                Vector2 force = (Vector2)waypoints[current].transform.position - (Vector2)gameObject.transform.position;
                force *= speed;

                // EVERYTHING IS IDENTICAL TO WAYPOINT EXCEPT FOR HERE
                Debug.DrawLine(mrb.position, mrb.velocity);
                if(Physics2D.CircleCast(mrb.position, .75f, mrb.velocity.normalized, rayDistance, 1 << 8)) // object in the way
                {
                    Debug.Log("Wall in the way");
                    mrb.AddForce(mrb.transform.right * speed);
                } else
                {
                    mrb.AddForce(force);
                }
                // end
            }
            else
            {
                if (breaking)
                {
                    mrb.AddForce(-mrb.velocity, ForceMode2D.Impulse);
                }
                moving = false;
                if ((current + 1) == waypoints.Length)
                {
                    current = 0;
                }
                else
                {
                    current++;
                }
            }
        }
    }
}
