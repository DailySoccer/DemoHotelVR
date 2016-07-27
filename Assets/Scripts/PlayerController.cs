using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private Transform _camera;
	[SerializeField] private CharacterController _character;
	[SerializeField, Range(0f, 50f)] private float _moveSpeedMax = 5f;
	[SerializeField, Range(0f, 500f)] private float _lookSpeedMax = 5f;
	private Vector3 _moveDir;


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
		bool mustStrafe = Input.GetButton("Strafe Mode");

		float h = Input.GetAxis("Horizontal");
		h = Mathf.Clamp(h, -1, 1);

		float v = Input.GetAxis("Vertical");
		v = Mathf.Clamp(v, -1, 1);

		_moveDir = v * _camera.forward;
		if (mustStrafe)
			_moveDir += h * _camera.right;
		_moveDir.y = 0;

		if (!mustStrafe)
			_character.transform.Rotate(0f, h * _lookSpeedMax * Time.deltaTime, 0f);

		_character.SimpleMove(_moveDir * _moveSpeedMax);	
	}

	
}
