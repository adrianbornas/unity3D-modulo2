using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

	// Variables
	public float velocidad = 3.0f;
	public float alturaSalto = 5.0f;
	public float velocidadCaida = 3.0f;
	
	private float movimientoEnY;
	private float movimientoEnX;

	private bool enTierra;
	private bool segundoSalto;
	private float margenEnTierra = 0.1f;

	// Animator reference
	public Animator animatorComponent;

	// GroundLayer reference
	public LayerMask groundLayer;

	// Use this for initialization
	void Start () {

		this.movimientoEnY = 0;
		this.movimientoEnX = 0;

		this.enTierra = true;
		this.segundoSalto = false;
	}
	
	// Update is called once per frame
	void Update () {
		this.movimientoEnX = Input.GetAxis ("Horizontal");

		// Jump
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.up, this.margenEnTierra);
		if ((Input.GetKeyDown(KeyCode.Space) == true) && (hit.collider != null) && (this.movimientoEnY < this.alturaSalto))
		{
			this.CharacterJump();
		}
		else
		{
			// Check if the character is in the air and the vertical movement less than maximum jump distance
			if(this.enTierra == false && this.movimientoEnY >= this.alturaSalto)
			{
				// Reduce vertical movement
				this.movimientoEnY -= this.velocidadCaida;

				// If the vertical movement is less or equal to 0, the character is on the floor
				if (this.movimientoEnY < 0)
				{
					this.movimientoEnY = 0;
					this.movimientoEnY = 0;
					this.enTierra = true;
				}
			}
		}
		
		// Update the animator variables
		animatorComponent.SetFloat("posicionVertical", Mathf.Abs(this.movimientoEnY));
		animatorComponent.SetFloat("desplazamientoHorizontal", Mathf.Abs(this.movimientoEnX));
		animatorComponent.SetBool("enTierra", this.enTierra);

		// Movement
		GetComponent<Rigidbody2D>().velocity = new Vector2 (this.movimientoEnX * this.velocidad * Time.deltaTime, this.movimientoEnY);
	}

	void CharacterJump() {
		this.movimientoEnY = 1f * this.velocidad * Time.deltaTime;
		this.enTierra = false;
	}
}
