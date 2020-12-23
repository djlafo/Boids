using UnityEngine;
using System.Collections;

public class interpose : MonoBehaviour {

    GameObject[] players;
    Rigidbody2D mrb;

    [SerializeField]
    float speed;

	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
        mrb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 midpoint = (players[0].transform.position + players[1].transform.position)/2;
        Vector2 force = (midpoint - mrb.position).normalized;
        force *= speed;

        mrb.AddForce(force);
	}
}
