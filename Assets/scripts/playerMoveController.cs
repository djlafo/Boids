using UnityEngine;
using System.Collections;

public class playerMoveController : MonoBehaviour {

    Rigidbody2D mrb;
    [SerializeField]
    float speed;

	// Use this for initialization
	void Start () {
        mrb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        mrb.AddForce(new Vector2(Input.GetAxis("Horizontal")*speed, 0f));
        mrb.AddForce(new Vector2(0f, Input.GetAxis("Vertical")*speed));
	}
}
