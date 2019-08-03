using System;
using UnityEngine;

public class Jugador : MonoBehaviour {

    private const float FUERZA_DE_PROPULSION = 100f;

    private Rigidbody2D cuerpo;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float impulso = 0f;
    private bool estaCayendo = false;
    
    public float velocidadDeVuelo = 25f;
    public float velocidad = 8f;

    public delegate void EventoRescatar();
    public static event EventoRescatar Rescatar;

    public void Start() {
        cuerpo = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FixedUpdate() {
        Caminar();
        Volar();
        ComprobarSiEstaCayendo();
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Prisionero") {
            Rescatar();
            Destroy(collision.gameObject);
        }
    }

    private void Caminar() {

        float movimientoLateral = Input.GetAxis("Horizontal");

        if (movimientoLateral < 0) {
            spriteRenderer.flipX = true;
        } else if(movimientoLateral > 0) {
            spriteRenderer.flipX = false;
        }
        
        cuerpo.AddForce(new Vector2(movimientoLateral, 0f) * velocidad);
        animator.SetFloat("movimientoLateral", Mathf.Abs(movimientoLateral));
    }

    private void Volar() {             

        if (Input.GetKeyDown(KeyCode.UpArrow)) {    
            cuerpo.AddForce(Vector2.up * FUERZA_DE_PROPULSION);
        }

        impulso = Input.GetAxis("Vertical");
        cuerpo.AddForce(new Vector2(0f, impulso) * velocidadDeVuelo);
        animator.SetFloat("impulso", impulso);        
    }

    private void ComprobarSiEstaCayendo() {

        if (cuerpo.velocity.y < 0 && impulso <= 0.1) {
            estaCayendo = true;
        } else if (cuerpo.velocity.y >= 0) {            
            estaCayendo = false;
        }

        animator.SetBool("cayendo", estaCayendo);
    }

}
