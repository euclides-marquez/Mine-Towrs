using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    [SerializeField] float Speed = 5f;
    Animator moveAnimator;
    public bool isInCave = false;
    GameObject miniMap;
    bool paused = false;
    GameObject pause;
    AudioSource background;
    AudioSource Mine;
    bool playing1 = true;
    bool playing2 = false;
    // Start is called before the first frame update
    void Start()
    {
        moveAnimator = gameObject.GetComponent<Animator>();
        miniMap = GameObject.Find("Minimap");
        miniMap.SetActive(false);
        pause = GameObject.Find("Pause");
        pause.SetActive(false);
        background = GameObject.Find("BackGround").GetComponent<AudioSource>();
        Mine = GameObject.Find("MineMusic").GetComponent<AudioSource>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            transform.position = transform.position + new Vector3 (0, Speed*Time.deltaTime, 0);
            moveAnimator.SetBool("RunBack", true);
        } else {
            moveAnimator.SetBool("RunBack", false);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position = transform.position + new Vector3 (0, -Speed*Time.deltaTime, 0);
            moveAnimator.SetBool("Run", true);
        }
        else {
            moveAnimator.SetBool("Run", false);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position = transform.position + new Vector3 (-Speed*Time.deltaTime, 0, 0);
            moveAnimator.SetBool("RunLeft", true);
        } else {
            moveAnimator.SetBool("RunLeft", false);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position = transform.position + new Vector3 (Speed*Time.deltaTime, 0, 0);
            moveAnimator.SetBool("RunRigth", true);
        } else {
            moveAnimator.SetBool("RunRigth", false);
        }
        
        transform.rotation = new Quaternion(0,0,0,0);

        if(isInCave){
            transform.position = new Vector3(transform.position.x, transform.position.y, -3);
            miniMap.SetActive(true);
            if(!playing2){
                Mine.Play(0);
                playing1 = false;
                playing2 = true;
            }
            
            background.Pause();
        } else {
            transform.position = new Vector3(transform.position.x, transform.position.y, -2);
            miniMap.SetActive(false);
            Mine.Pause();
            if (!playing1){
                background.Play(0);
                playing2 = false;
                playing1 = true;
            }
            
        }

        
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(paused){
                pause.SetActive(false);
                Time.timeScale = 1;
                paused = false;
            } else {
                pause.SetActive(true);
                Time.timeScale = 0;
                paused = true;
            }
            
        }


        
    }

    



}
