using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform ethan;

	private Vector3 offset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
	// Use this for initialization
	void Start () {
		offset = transform.position - ethan.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 newPos = ethan.position + offset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
	}
}
