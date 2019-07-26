using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorDeColeccionables : MonoBehaviour {

    private const int PUNTOS_POR_GEMA = 25;

    private int puntos = 0;

    private void OnEnable() {
        Gema.Coleccionar += Coleccionar;             
    }

    private void OnDisable() {
        Gema.Coleccionar -= Coleccionar;
    }

    void Coleccionar() {
        puntos+= PUNTOS_POR_GEMA; 
        Debug.Log("Puntos: " + puntos);
    }
}
