using UnityEngine;

public class PlayerController : MonoBehaviour
{   

	
	//Vitesse en marchant et en courant
    [SerializeField] private float walk, run;

	//Sensibilité de la souris
	private float sensitivity = 500;
	private float speed;

    private bool isMoving = false;
	private bool isRunning = false;
	
	private CharacterController cc;

    private float X, Y;
	
	//Pour les bruits de pas
	[SerializeField] private AudioClip[] sfx_steps;
	private int num_step = 0;
	private float step_timer = 0.0f;
	private float max_step_timer = 0.5f;
	private AudioSource audio_steps;

    private void Start()
    {
        speed = walk;
        cc = GetComponent<CharacterController>();
		audio_steps = GetComponent<AudioSource>();
        cc.enabled = true;

		Cursor.lockState = CursorLockMode.Locked; 
		Cursor.visible = false; 
		//Rend le curseur invisible
		Debug.Log("Cursor State: " + Cursor.lockState);


    }
    private void Update()
    {
		if(!HudManager.pause){
			//Camera limitation variables
			/*
			const float MIN_Y = -60.0f;
			const float MAX_Y = 70.0f;

			Y -= Input.GetAxis("Mouse Y") * (sensitivity * Time.deltaTime);

			/*
			if (Y < MIN_Y)
				Y = MIN_Y;
			else if (Y > MAX_Y)
				Y = MAX_Y;
			*/
			// Cursor.lockState = CursorLockMode.Confined; //CT LE TRUC D'EDOUARD AU CAS OÙ FAUDRAIT LE RECUP
			// je voulais ajouter un truc pour que le curseur bouge pas mais ça marche pas ça me gonfle


			//C un code qui permet de lock le curseur au milieu et qui le fait disparaitre, on peut appuyer sur echap pour avoir de nouveau le curseur
			void OnGUI()
			{
				//Press this button to lock the Cursor
				if (GUI.Button(new Rect(0, 0, 100, 50), "Lock Cursor"))
				{
					Cursor.lockState = CursorLockMode.Locked;
				}

				//Press this button to confine the Cursor within the screen
				if (GUI.Button(new Rect(125, 0, 100, 50), "Confine Cursor"))
				{
					Cursor.lockState = CursorLockMode.Confined;
				}
			}


			X += Input.GetAxis("Mouse X") * (sensitivity * Time.deltaTime);

			Y -= Input.GetAxis("Mouse Y") * (sensitivity * Time.deltaTime);
			Y = Mathf.Clamp(Y, -60f, 70f); // Empêche de regarder trop haut ou bas

			transform.localRotation = Quaternion.Euler(Y, X, 0.0f);

			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");
			Vector3 forward = transform.forward * vertical;
			Vector3 right = transform.right * horizontal;

			cc.SimpleMove((forward + right) * speed);
			
			//Si on appuie sur Shift Gauche, on court
			if (Input.GetKey(KeyCode.LeftShift) || (Input.GetKey(KeyCode.RightShift)))
			{
				speed = run+3;
				isRunning = true;
			}
			else
			{
				isRunning = false;
				speed = walk+2;
			}

			
			if(horizontal != 0 || vertical != 0){ //Si le joueur se déplace, on joue des bruits de pas
				if(step_timer <= 0){
					audio_steps.clip = sfx_steps[num_step];
					audio_steps.Play();
					
					step_timer = max_step_timer;
					if(isRunning){ //S'il court, on divise par 2 le temps avant d'entendre un nouveau pas
						step_timer /= 2;
					}
					num_step = (num_step+1)%sfx_steps.Length;
				} else {
					step_timer -= Time.deltaTime;
				}
			} else {
				step_timer = 0.1f;
			}
		}
    }
}