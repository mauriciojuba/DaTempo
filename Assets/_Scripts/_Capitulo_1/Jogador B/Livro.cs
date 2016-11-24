using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TouchScript.Gestures;

public class Livro : MonoBehaviour {

	public Sprite[] Paginas;
	public int PaginaAtual;
	private Sprite ImagemPagina;
    public AudioManager Effect;


	// Use this for initialization


	void Start () {


		PaginaAtual = 0;
		ImagemPagina = Paginas [PaginaAtual];
		gameObject.GetComponent<SpriteRenderer>().sprite = ImagemPagina;
	
	}
		
		
	public void ProcimaPagina(){
		if (PaginaAtual >= 0 && PaginaAtual < Paginas.Length - 1) {

            Effect.playSound("VirarPagina");

			PaginaAtual++;
			ImagemPagina = Paginas [PaginaAtual];
			gameObject.GetComponent<SpriteRenderer> ().sprite = ImagemPagina;
		}
	}

	public void PaginaAnterior(){

		if (PaginaAtual > 0 && PaginaAtual <= Paginas.Length) {

            Effect.playSound("VirarPagina");

            PaginaAtual--;
			ImagemPagina = Paginas [PaginaAtual];
			gameObject.GetComponent<SpriteRenderer> ().sprite = ImagemPagina;

		}
	}
}
