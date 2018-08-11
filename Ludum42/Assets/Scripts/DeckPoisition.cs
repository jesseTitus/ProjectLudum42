using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckPoisition : MonoBehaviour {

    private void OnDrawGizmos()
    {
        Vector2 size = new Vector2(2.5f, 2.5f);

        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
