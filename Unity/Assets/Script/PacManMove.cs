using System;
using UnityEngine;
using System.Collections;

public class PacManMove : MonoBehaviour
{

    public float speed = 0.4f;
    Vector2 _dest = Vector2.zero;
    Vector2 _dir = Vector2.zero;
    Vector2 _nextDir = Vector2.zero;
    public GameObject[] Ghosts;
    public static int GhostAmount;

    // Use this for initialization
    void Start()
    {            
        for(int i = 0; i<GhostAmount; i++)
            {
                Ghosts[i].SetActive(true);;
            }
        Debug.Log("start");
        _dest = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInputAndMove();

    }

  


    void ReadInputAndMove()
    {
        // move closer to destination
        Vector2 p = Vector2.MoveTowards(transform.position, _dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
        if (Input.GetKey(KeyCode.DownArrow) ){
             _nextDir = -Vector2.up;
        }
        if (Input.GetKey(KeyCode.UpArrow) ) _nextDir = Vector2.up;
        if (Input.GetKey(KeyCode.RightArrow)) _nextDir = Vector2.right;
        if (Input.GetKey(KeyCode.LeftArrow) ) _nextDir = -Vector2.right;
        


        if (Vector2.Distance(_dest, transform.position) < 10f)
        {
            
                _dest = (Vector2)transform.position + _nextDir;
                _dir = _nextDir;
        }
    }

    public Vector2 getDir()
    {
        return _dir;
    }

   IEnumerator OnTriggerEnter2D(Collider2D other)
	{
        if(other.gameObject.tag == "dot")
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "boost")
        {
            Destroy(other.gameObject);
            for(int i = 0; i<Ghosts.Length; i++)
            {
                Ghosts[i].GetComponent<GhostMovement>().CanDieChange();
            }
            
                yield return new WaitForSeconds(10);

            for(int i = 0; i<Ghosts.Length; i++)
            {
                Ghosts[i].GetComponent<GhostMovement>().CanNotDieChange();
            }
        }
    }
}
