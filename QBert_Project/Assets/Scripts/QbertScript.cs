using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QbertScript : MonoBehaviour {
/// Static Members:
    static bool enableCollison = false;
    static bool InputAllowed = true;
    static GameObject QbertMesh;
    static bool rotate = false;


    ///UI Elements:
    [SerializeField] GameObject[] liveImages;

    /// <summary>
    /// Animations
    /// </summary>
    [SerializeField] GameObject QbertAnim;

   
    enum Directions
    {
        UPLEFT,
        UPRIGHT,
        DOWNLEFT,
        DOWNRIGHT
    };

    int lives = 3;

    private CubeObjectScript currentCube;

    CubeObjectScript destinationNode;

    GameObject QbertAnimation;

    int animationNum;


    /// <summary>
    /// Gets or sets the current cube.
    /// </summary>
    /// <value>The current cube.</value>
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
    /// <summary>
    /// Gets or sets the position.
    /// </summary>
    /// <value>The position.</value>
    public Vector3 Position{
        get{
            return transform.position;
        }
        set{
            transform.position = value;
        }
    }

    /// <summary>
    /// Start this instance.
    /// </summary>
	void Start () {
        currentCube = transform.GetComponentInParent<CubeObjectScript>();
        QbertMesh = GameObject.FindGameObjectWithTag("PlayerMesh");
        lives--;
    }
	
	/// <summary>
    /// Update this instance.
    /// </summary>
	void Update ()
    {
        if (QbertAnimation != null)
        {
            Debug.Log("Rotate");
            transform.rotation = QbertAnimation.transform.rotation;
        }
        InputManager();
        UpdateLives();

    }

    /// <summary>
    /// Updates the lives.
    /// </summary>
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

    /// <summary>
    /// Manages Player Input.
    /// </summary>
    private void InputManager()
    {
        if (InputAllowed)
        {
            
            if ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Keypad7)) && CurrentCube.Connections[0] != null)
            {
                MoveQbert(CurrentCube.Connections[0], Directions.UPLEFT);
            }
            else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Keypad9)) && CurrentCube.Connections[1] != null)
            {
                MoveQbert(CurrentCube.Connections[1], Directions.UPRIGHT);
            }
            else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Keypad1)) && CurrentCube.Connections[2] != null)
            {
                MoveQbert(CurrentCube.Connections[2], Directions.DOWNLEFT);
            }
            else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Keypad3)) && CurrentCube.Connections[3] != null)
            {
                MoveQbert(CurrentCube.Connections[3], Directions.DOWNRIGHT);
            }

            gameObject.GetComponent<BoxCollider>().enabled = enableCollison;

        }
    }

    /// <summary>
    /// Moves Qbert
    /// </summary>
    /// <param name="cubeObject">Cube object.</param>
    /// <param name="directions">Directions.</param>
    void MoveQbert(CubeObjectScript cubeObject , Directions directions)
    {
        InputAllowed = false;

        QbertMesh.SetActive(false);
        enableCollison = false;

        QbertAnimation = Instantiate(QbertAnim, Position, transform.rotation, transform.parent);
        Animator QbertAnimator = QbertAnimation.GetComponent<Animator>();
        QbertAnimator.applyRootMotion = false;
        QbertAnimator.SetBool("Jump", true);
        QbertAnimator.SetInteger("Direction", (int)directions);
        
        CurrentCube = cubeObject;
        transform.parent = CurrentCube.transform;
        Position = new Vector3(CurrentCube.transform.position.x, CurrentCube.transform.position.y + CurrentCube.YOffset, CurrentCube.transform.position.z);

    }


    public static void Move()
    {
        QbertMesh.SetActive(true);
        enableCollison = true;
        InputAllowed = true;

    }
}

