using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObjectScript : MonoBehaviour {
    public CubeObjectScript frontLeft;
    public CubeObjectScript frontRight;
    public CubeObjectScript backRight;
    public CubeObjectScript backLeft;

    Material Untouched_Top;
    Material Stepped_Top;
    Material Random_Top;


    [SerializeField] float yOffset = 0.3f;

	private void Start()
	{
        Untouched_Top = (Material)Resources.Load("Top_Untouched");
        Stepped_Top = (Material)Resources.Load("Top_Clicked");
        Random_Top = (Material)Resources.Load("Top_Random");

        Debug.Log(Untouched_Top);

        if (Untouched_Top != null)
        {
            Debug.Log("Hello Children");
        }

    }



	public float YOffset
    {
        get
        {
            return yOffset;
        }
    }

	private void OnTriggerEnter(Collider other)
	{
        Debug.Log("AAAA");
		if (other.gameObject.tag == "Player")
        {
            
        }
	}
}
