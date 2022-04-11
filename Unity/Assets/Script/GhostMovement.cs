using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random=UnityEngine.Random;

public class GhostMovement : MonoBehaviour {
    public Transform target;//set target from inspector instead of looking in Update
        public float speed = 3f;
        public string direction = "up";
        public Rigidbody2D rb2D;    
        public static bool CanDie = false;
        public Transform Spawn;
        public Sprite CanDieSprite;
        public Sprite NormalSprite;
        public SpriteRenderer spriteRenderer;
        public GameObject buttonEndRestart;


        void Start () {
            
            rb2D = GetComponent<Rigidbody2D>();
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
    
        void Update(){
            if(target!=null)
            {
                if(direction == "up")
                {
                    rb2D.velocity = Vector2.up * speed * Time.deltaTime;                
                }
                if(direction == "left")
                {
                    rb2D.velocity = Vector2.left * speed * Time.deltaTime;                
                }
                if(direction == "right")
                {
                    rb2D.velocity = Vector2.right * speed * Time.deltaTime;                
                }
                if(direction == "down")
                {
                    rb2D.velocity = Vector2.down * speed * Time.deltaTime;                
                }
            }    
        }
    public void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collide");
        if(col.gameObject.name == "pacman")
        {
            if(CanDie==false)
            {
                Destroy(col.gameObject);
                buttonEndRestart.SetActive(true);
            }
            if(CanDie==true)
            {
                transform.position = Spawn.position;
                direction = "up";
            }
        }
        if(col.gameObject.tag == "maze" || col.gameObject.tag == "ghost")
        {
            int tempRand = Random.Range(1,3);
            {
                if(direction == "up")
                {
                    if(tempRand == 1)
                    {
                        direction = "left";
                    }
                    else if(tempRand == 2)
                    {
                        direction = "right";
                    }
                }
                else if(direction == "left")
                {
                    if(tempRand == 1)
                    {
                        direction = "up";
                    }
                    else if(tempRand == 2)
                    {
                        direction = "down";
                    }
                }
                else if(direction == "right")
                {
                    if(tempRand == 1)
                    {
                        direction = "up";
                    }
                    else if(tempRand == 2)
                    {
                        direction = "down";
                    }
                }
                else if(direction == "down")
                {
                    if(tempRand == 1)
                    {
                        direction = "left";
                    }
                    else if(tempRand == 2)
                    {
                        direction = "right";
                    }
                }
                Debug.Log(tempRand);
            }
        }
    }

    public void CanDieChange()
    {  
        CanDie=true;
        spriteRenderer.sprite = CanDieSprite; 
    } 
    public void CanNotDieChange()
    {  
        CanDie=false;
        spriteRenderer.sprite = NormalSprite; 
    }
 
}
