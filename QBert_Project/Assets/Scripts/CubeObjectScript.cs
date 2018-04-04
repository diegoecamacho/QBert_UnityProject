using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObjectScript : MonoBehaviour {
    public CubeObjectScript[] Connections;
    CubeObjectScript parentNode = null;
    int nodeDirection;
    int Steps;

    MeshRenderer cubeMesh;
    Material Untouched_Top;

    public bool cubeFinished = false;

    [SerializeField] float yOffset;

    public  Color CubeColor{
    get{
     return cubeMesh.material.color;
    }    
    }

    public float YOffset
    {
        get
        {
            return yOffset;
        }
    }

    public CubeObjectScript ParentNode
    {
        get
        {
            return parentNode;
        }

        set
        {
            parentNode = value;
        }
    }

    public int NodeDirection
    {
        get
        {
            return nodeDirection;
        }

        set
        {
            nodeDirection = value;
        }
    }

    private void Start()
	{
        cubeMesh = gameObject.GetComponent<MeshRenderer>();
        Untouched_Top = (Material)Resources.Load("TopMaterial");
     
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
        {
            Steps++;
            switch (Steps)
            {
                case 1:
                    GameManager.score += 25;
                    cubeMesh.material.color = Color.red;
                    cubeFinished = true;
                     break;
                //case 2:
                //    cubeMesh.material.color = Color.white;
                //    break;
                default:
                    break;
            }
        }
	}
}
