using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthSystem : MonoBehaviour
{
    [SerializeField] private float startHealth;
    private float currentHealth;

    private void newlife(){
        currentHealth = startHealth;
    }
    public void damageTaken(float damage1){
        currentHealth= Mathf.Clamp((currentHealth) - (damage1), 0, (startHealth));
    

    if (currentHealth >0f){
        //player hurt
    }
    else{
        //game over
    }
    }
}
