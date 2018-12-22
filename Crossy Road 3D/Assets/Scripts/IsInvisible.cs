using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInvisible : MonoBehaviour {

    // Método é chamado quando o objeto sai da cena.
    private void OnBecameInvisible() {
        // Destroi o objeto pai depois de 2 segundos
        Destroy(transform.parent.gameObject, 2.0f);
    }
}
