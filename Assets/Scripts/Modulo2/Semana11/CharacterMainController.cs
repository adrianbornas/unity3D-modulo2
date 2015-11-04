using UnityEngine;
using System.Collections;

public class CharacterMainController : MonoBehaviour {

	// Variables
	private bool primerAtaque;
	private bool segundoAtaque;
	private bool tercerAtaque;
	public float vida;

	// Use this for initialization
	void Start () {
		this.vida		= 50;
		this.primerAtaque = this.segundoAtaque = this.tercerAtaque = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
