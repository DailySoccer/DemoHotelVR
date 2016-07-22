using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	public Transform cameraRef;
	public float MoveSpeed = 5;
	// Use this for initialization
	void Start () {
		charCont = GetComponent<CharacterController>();
		_initiated = cameraRef != null;
	}
	
	// Update is called once per frame
	void Update () {
		if (_initiated) {
			Vector3 movement = Vector3.zero;
#if UNITY_EDITOR
			if (Input.GetKey(KeyCode.UpArrow))
			{
				movement += cameraRef.forward;
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				movement -= cameraRef.forward;
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				movement += cameraRef.right;
			}
			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				movement -= cameraRef.right;
			}
#else
			float input = Input.GetAxis("Vertical") + Input.GetAxis("Fire1");
			input = Mathf.Clamp(input, -1, 1);
			movement = cameraRef.forward * input;
#endif
			movement.y = 0;
			movement.Normalize();
			charCont.SimpleMove(movement * MoveSpeed);	//needs speed vector, not displacement vector
		}
	}

	private CharacterController charCont;
	private bool _initiated;
}
