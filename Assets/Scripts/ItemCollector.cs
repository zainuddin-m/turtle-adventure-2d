using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int bananacount = 0;
    [SerializeField] private Text bananas;
    [SerializeField] private AudioSource itemSound;
    private void OnTriggerEnter2D(Collider2D collision1){
        if (collision1.gameObject.CompareTag("Banana")){
            itemSound.Play();
            Destroy(collision1.gameObject);
            bananacount++;
            bananas.text = ("Bananas: "+bananacount);
        }
    }
}
