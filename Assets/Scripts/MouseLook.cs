// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MouseLook
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	public float mouseSensitivity = 1000f;

	public Transform playerBody;

	private float xRotation;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		float num = Input.GetAxis("Mouse X") * mouseSensitivity;
		float num2 = Input.GetAxis("Mouse Y") * mouseSensitivity;
		xRotation -= num2;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);
		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * num);
	}
}
