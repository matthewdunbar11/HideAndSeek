using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Walk : NetworkBehaviour
{
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;

	private Vector3 moveDirection = Vector3.zero;
	void Update() {
        if(!isLocalPlayer)
        {
            return;
        }

		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
		transform.Rotate (0, x, 0);
	}
}