using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

	// Variables
	public float velocidad = 3.0f;
	public float alturaSalto = 10.0f;
	public float velocidadCaida = 3.0f;
	
	private float movimientoEnY;
	private float movimientoEnX;

	private bool enTierra;
	private bool segundoSalto;

	// Referencia a animator
	public Animator animatorComponent;

	// Use this for initialization
	void Start () {

		this.movimientoEnY = 0;
		this.movimientoEnX = 0;

		this.enTierra = true;
		this.segundoSalto = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Avanzar o retroceder
		this.movimientoEnX = Input.GetAxis ("Horizontal");

		// Salto
		if ((Input.GetKeyDown(KeyCode.Space)== true || (Input.GetAxis ("Vertical") > 0)) && this.enTierra == true)
		{
			this.movimientoEnY = 1f * this.velocidad;
			this.enTierra = false;
		}
		else
		{
			// Check if the character is in the air and the vertical movement greater than 0
			if(this.enTierra == false && this.movimientoEnY > 0)
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
		animatorComponent.SetFloat("MovimientoVertical", Mathf.Abs(this.movimientoEnY));
		animatorComponent.SetFloat("DesplazamientoHorizontal", Mathf.Abs(this.movimientoEnX));
		animatorComponent.SetBool("enTierra", this.enTierra);

		// Aplicar movimiento
		GetComponent<Rigidbody2D>().velocity = new Vector2 (this.movimientoEnX * this.velocidad, this.movimientoEnY);
	}
}
