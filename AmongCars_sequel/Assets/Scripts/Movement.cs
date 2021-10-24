using UnityEngine;

public class Movement : MonoBehaviour {
	
	public CharacterController controller;
	public float speed = 8f;
	public float gravity = -9.81f;
	public float jumpHeight = 0.5f;
	
	public AudioSource stepsAudioSource;
	
	public string goal = "Goal";
	public GameAction hitGoalAction;
	
	private bool playerOnTheFloor = true;
	private Vector3 velocity;
	
	void Update() {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		if (! this.stepsAudioSource.isPlaying && this.playerOnTheFloor && (x != 0 || z != 0))
			stepsAudioSource.Play();
		
		Vector3 move = transform.right * x + transform.forward * z;
		this.controller.Move(move * this.speed * Time.deltaTime);
		
		if (this.playerOnTheFloor && Input.GetButtonDown("Jump")) {
			this.velocity.y = Mathf.Sqrt(this.jumpHeight * -2f * this.gravity);
			playerOnTheFloor = false;
			
			if (this.stepsAudioSource.isPlaying)
				this.stepsAudioSource.Stop();
		}
		
		this.velocity.y += this.gravity * Time.deltaTime;
		this.controller.Move(this.velocity * Time.deltaTime);
	}
	
	public void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.CompareTag("Floor")) {
			this.playerOnTheFloor = true;
			this.velocity.y = 0;
		}
			
		else if (hit.gameObject.CompareTag(this.goal))
			this.hitGoalAction.Run();
	}
}