using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObjectScript : MonoBehaviour {
    public CubeObjectScript[] Connections;
    CubeObjectScript parentNode = null;
    int Steps;

    MeshRenderer cubeMesh;
    Material Untouched_Top;

    [SerializeField] float yOffset;

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
                    cubeMesh.material.color = Color.white;
                     break;
                case 2:
                    cubeMesh.material.color = Color.yellow;
                    break;
                case 3:
                    cubeMesh.material.color = Color.red;
                    break;
                default:
                    break;
            }
        }
	}
}
