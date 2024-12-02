using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishscript : MonoBehaviour
{
    private AudioSource finishSound;
    private bool isLevelFinished=false;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision6){
        if ((collision6.gameObject.name =="Player")&&(!isLevelFinished)){
            isLevelFinished=true;
            finishSound.Play();
            Invoke("finishLevel", 0.5f);
        }
    }

    private void finishLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

 
    
}
