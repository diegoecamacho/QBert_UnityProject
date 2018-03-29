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
        currentCube = transform.GetComponentInParent<CubeObjectScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        InputManager();

    }

    private void InputManager()
    {
        if ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Keypad7)) && CurrentCube.Connections[0] != null)
        {
            MoveQbert(currentCube.Connections[0]);
        }
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Keypad9)) && CurrentCube.Connections[1] != null)
        {
            MoveQbert(currentCube.Connections[1]);
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Keypad1)) && CurrentCube.Connections[2] != null)
        {
            MoveQbert(currentCube.Connections[2]);
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Keypad3)) && CurrentCube.Connections[3] != null)
        {
            MoveQbert(currentCube.Connections[3]);
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
