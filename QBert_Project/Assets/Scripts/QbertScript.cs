using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QbertScript : MonoBehaviour {
    private CubeObjectScript currentCube;

    bool enableCollison = false;

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
        CurrentCube = transform.GetComponentInParent<CubeObjectScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        InputManager();

    }

    private void InputManager()
    {
        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Keypad7)) && CurrentCube.backLeft != null)
        {
            MoveQbert(currentCube.backLeft);
        }
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Keypad9)) && CurrentCube.backRight != null)
        {
            MoveQbert(currentCube.backRight);
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Keypad1)) && CurrentCube.frontLeft != null)
        {
            MoveQbert(currentCube.frontLeft);
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Keypad3)) && CurrentCube.frontRight != null)
        {
            MoveQbert(currentCube.frontRight);
        }
        if (enableCollison)
        {
            gameObject.GetComponent<BoxCollider>().enabled = enableCollison;
        }
        

    }

    private void MoveQbert(CubeObjectScript destinationCube)
    {
        CurrentCube = destinationCube;
        transform.parent = CurrentCube.transform;
        Position = new Vector3(CurrentCube.transform.position.x, CurrentCube.transform.position.y + CurrentCube.YOffset, CurrentCube.transform.position.z);
        enableCollison = true;
    }
}
