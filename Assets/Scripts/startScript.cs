using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour
{
    public void startGame(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
   }
}
