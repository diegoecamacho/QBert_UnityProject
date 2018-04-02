using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QbertScript : MonoBehaviour {

    //UI Elements:
    [SerializeField] GameObject[] liveImages;
    Animator animator;

    enum Directions
    {
        UPLEFT,
        UPRIGHT,
        DOWNLEFT,
        DOWNRIGHT
    };

    int lives = 3;

    private CubeObjectScript currentCube;

    bool enableCollison = false;
    bool InputAllowed = true;

    CubeObjectScript destinationNode;

    int animationNum;

    public CubeObjectScript CurrentCube
    {
        get
        {
            return currentCube;
        }

        set
        {
            currentCube = value;
        }
    }
    public Vector3 Position{
        get{
            return transform.position;
        }
        set{
            transform.position = value;
        }
    }

    // Use this for initialization
	void Start () {
        currentCube = transform.GetComponentInParent<CubeObjectScript>();
        animator = GetComponent<Animator>();
        lives--;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("JumpState"));
        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"));
        InputManager();
        UpdateLives();

    }

    private void UpdateLives()
    {
        switch (lives)
        {
            case 0:
                liveImages[0].SetActive(false);
                break;
            case 1:
                liveImages[1].SetActive(false);
                break;
            case 2:
                liveImages[2].SetActive(false);
                break;
            default:
                break;
        }
    }

    private void InputManager()
    {
       // if (InputAllowed)
        //{
            if ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Keypad7)) && CurrentCube.Connections[0] != null)
            {
                MoveQbert(CurrentCube.Connections[0],Directions.UPLEFT);
            }
            else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Keypad9)) && CurrentCube.Connections[1] != null)
            {
                MoveQbert(CurrentCube.Connections[1],Directions.UPRIGHT);
            }
            else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Keypad1)) && CurrentCube.Connections[2] != null)
            {
                MoveQbert(CurrentCube.Connections[2],Directions.DOWNLEFT);
            }
            else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Keypad3)) && CurrentCube.Connections[3] != null)
            {
                MoveQbert(CurrentCube.Connections[3],Directions.DOWNRIGHT);
            }
            if (enableCollison)
            {
                gameObject.GetComponent<BoxCollider>().enabled = enableCollison;
            }

        //}
          
  
       
        

    }

    private void MoveQbert(CubeObjectScript cubeObject , Directions directions)
    {
        Debug.Log((int)directions);
        InputAllowed = false;

        
        CurrentCube = cubeObject;
        transform.parent = CurrentCube.transform;
        Position = new Vector3(CurrentCube.transform.position.x, CurrentCube.transform.position.y + CurrentCube.YOffset, CurrentCube.transform.position.z);

       // animator.applyRootMotion = false;
       // animator.SetBool("Jump", true);
        //animator.SetInteger("Direction", (int)directions);

    }


    private void Move()
    {
        // animator.SetBool("Jump", false);
        //animator.applyRootMotion = true;
        enableCollison = true;
        InputAllowed = true;
    }
}

