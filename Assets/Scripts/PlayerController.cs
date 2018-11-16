using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;
    private bool playerMoving;
    public Vector2 lastMove;
	private Rigidbody2D myRigidBody;


	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();

		lastMove = new Vector2(0f , -1f);

	}
	
	// Update is called once per frame
	void Update () {
        playerMoving = false;
		//gets velocity in order to move and update animations

		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
		//	transform.Translate (new Vector3(Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			myRigidBody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * currentMoveSpeed, myRigidBody.velocity.y);
			playerMoving = true;
			lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
		}

		if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) {
		//    transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));

			myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, Input.GetAxisRaw ("Vertical") * currentMoveSpeed);
			playerMoving = true;
			lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
		}

		if (Input.GetAxisRaw ("Horizontal") < 0.5 && Input.GetAxisRaw ("Horizontal") > -0.5) {
			myRigidBody.velocity = new Vector2 (0f, myRigidBody.velocity.y);
		}

		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
			myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, 0f);
		
		}

		if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f) {
			currentMoveSpeed = moveSpeed * diagonalMoveModifier;
		} else {
			currentMoveSpeed = moveSpeed;
		}

	}

}
