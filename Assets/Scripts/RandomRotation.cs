using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		System.Random rand = new System.Random();
		_up = ((float)rand.NextDouble() - 0.5f) * 360;
		_right = ((float)rand.NextDouble() - 0.5f) * 360 * 2;
		_forward = ((float)rand.NextDouble() - 0.5f) * 360 * 3;
		Debug.Log(_up + ", " + _right);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(transform.up, _up * Time.deltaTime);
		transform.Rotate(transform.right, _right * Time.deltaTime);
		transform.Rotate(transform.forward, _forward * Time.deltaTime);
	}

	private float _up, _right, _forward;
}
