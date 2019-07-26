using UnityEngine;

public class Gema : MonoBehaviour {

    public delegate void AlColeccionar();
    public static event AlColeccionar Coleccionar;

    private void OnTriggerEnter2D(Collider2D collision) {
        Coleccionar();
        Destroy(gameObject);
    }


}
