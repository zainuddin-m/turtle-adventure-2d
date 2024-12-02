using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision4){
        if (collision4.gameObject.name=="Player"){
            collision4.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision5){
        if (collision5.gameObject.name=="Player"){
            collision5.gameObject.transform.SetParent(null);
        }
    }

}
