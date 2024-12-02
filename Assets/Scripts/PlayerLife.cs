using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator animation1;
    private Rigidbody2D rigid;
    [SerializeField] private AudioSource deathSound;
    private void Start()
    {
        animation1 = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision3){
        if (collision3.gameObject.CompareTag("Enemy")){
            death();
        }
    }
    private void death(){
        deathSound.Play();
        animation1.SetTrigger("death");
        rigid.bodyType = RigidbodyType2D.Static;
    }

    private void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
