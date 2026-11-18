// Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// PlayerMovement
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController controller;

	public GameObject playerCamera;

	public float walkSpeed = 12f;

	public float runSpeed = 20f;

	public float gravity = -9.81f;

	public float jumpHeight = 3f;

	public float bobbingAmount = 0.1f;

	public bool normalizeMovement = true;

	public AudioSource footsteps;

	public Transform groundCheck;

	public float groundDistance = 0.4f;

	public LayerMask groundMask;

	private Vector3 velocity;

	private bool isGrounded;

	private float initCamY;

	private float timer;

	private float camY;

	private bool bobbingUp = true;

	private void Start()
	{
		initCamY = playerCamera.transform.localPosition.y;
	}

	private void Update()
	{
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		if (isGrounded && velocity.y < 0f)
		{
			velocity.y = -2f;
		}
		float axis = Input.GetAxis("Horizontal");
		float axis2 = Input.GetAxis("Vertical");
		Vector3 vector = transform.right * axis + transform.forward * axis2;
		if (normalizeMovement)
		{
			vector = Vector3.Normalize(vector);
		}
		float num = walkSpeed;
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			num = runSpeed;
		}
		controller.Move(vector * num * Time.deltaTime);
		float x = playerCamera.transform.localPosition.x;
		float z = playerCamera.transform.localPosition.z;
		float num2 = camY;
		if (vector == Vector3.zero)
		{
			timer = 0f;
			camY = Mathf.Lerp(playerCamera.transform.localPosition.y, initCamY, Time.deltaTime * num);
		}
		else
		{
			timer += Time.deltaTime * num;
			camY = initCamY + Mathf.Sin(timer) * bobbingAmount;
		}
		playerCamera.transform.localPosition = new Vector3(x, camY, z);
		if (isGrounded && vector != Vector3.zero)
		{
			if (camY > num2)
			{
				if (!bobbingUp)
				{
					footsteps.Play(0uL);
				}
				bobbingUp = true;
			}
			else
			{
				bobbingUp = false;
			}
		}
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
	}
}
