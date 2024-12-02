using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spikeheadScript : MonoBehaviour
{
    [SerializeField] private float spd;
    [SerializeField] private float range;
    [SerializeField] private float chkDelay;
    [SerializeField] private LayerMask playerLayer;
    private float chkTimer;
    private bool attacking;
    private Vector3[] directions = new Vector3[4];
    private Vector3 destination;

    private void OnEnable(){
        stopSpike();
    }

    private void Update(){
        if (attacking){
            transform.Translate(destination * Time.deltaTime *spd);
        }
        else{
            chkTimer += Time.deltaTime;
            if(chkTimer>chkDelay){
                CheckForPlayer();
            }
        }
    }

        private void CheckForPlayer(){
            calculateVectors();

            for (int i=0;i<directions.Length;i++){
                Debug.DrawRay(transform.position,directions[i], Color.red);
                RaycastHit2D hit1 = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);

                if (hit1.collider !=null && !attacking){
                    attacking=true;
                    destination=directions[i];
                    chkTimer=0;
                }
            }
        }

        private void calculateVectors(){
            directions[0]=transform.right*range;
            directions[1]=-transform.right*range;
            directions[2]=transform.up*range;
            directions[3]=-transform.up*range;
        }
        private void stopSpike(){
            destination = transform.position;
            attacking=false;
        }

        private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("collision2 detected");
        stopSpike();
        if (collision.gameObject.CompareTag("Player1")){
            death();
        }
        }

         private Animator animation1;
    private Rigidbody2D rigid;
    [SerializeField] private AudioSource deathSound;
    private void Start()
    {
        animation1 = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision3){
        restart();
        
    }
    private void death(){
        deathSound.Play();
        restart();
        //animation1.SetTrigger("death");
        //rigid.bodyType = RigidbodyType2D.Static;
    }

    private void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

        
        
    



    
}

