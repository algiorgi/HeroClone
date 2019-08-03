using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorDelJuego : MonoBehaviour {

    public Transform prisioneros;

    private int cantidadTotalDePrisiones;
    private int prisionerosRescatados;

    public void Start()  {

        cantidadTotalDePrisiones = prisioneros.childCount;
        prisionerosRescatados = 0;        
    }

    private void OnEnable() {
        Jugador.Rescatar += AlRescatarUnPrisionero;
    }

    private void OnDisable() {
        Jugador.Rescatar -= AlRescatarUnPrisionero;
    }

    private void AlRescatarUnPrisionero() {

        prisionerosRescatados++;

        Debug.Log("Prisionero rescatado: " + prisionerosRescatados + " de " + cantidadTotalDePrisiones);
    }
}
