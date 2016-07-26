using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private Transform _camera;
	[SerializeField] private CharacterController _character;
	[SerializeField] private float _moveSpeed = 5f;
	[SerializeField] private float _rotationSpeed = 5f;


	private void Awake()
	{
		if(_character == null)
			_character = GetComponent<CharacterController>();
		if (_camera == null)
			_camera = GetComponentInChildren<Camera>().transform;

		enabled = _camera != null;
	}

	private void OnDestroy()
	{
		_camera = null;
		_character = null;
	}

	
	// Update is called once per frame
	private void Update ()
	{
		bool mustStrafe = Input.GetButton("Must Strafe");

		float h = Input.GetAxis("Horizontal");
		h = Mathf.Clamp(h, -1, 1);

		float v = Input.GetAxis("Vertical");
		v = Mathf.Clamp(v, -1, 1);

			
		Vector3 movement = v * _camera.forward;
		if (mustStrafe)
			movement += h * _camera.right;

		movement.y = 0;
		_character.SimpleMove(movement * _moveSpeed * Time.deltaTime);	

		if(!mustStrafe)
			_character.transform.Rotate(0f, h * _rotationSpeed * Time.deltaTime, 0f);
	}

}
