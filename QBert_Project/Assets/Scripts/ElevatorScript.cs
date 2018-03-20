using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : CubeObjectScript {

    Animator animator;
    [SerializeField] CubeObjectScript destinationCube;
    QbertScript Qbert;

    // Use this for initialization
    void Start () {
        Qbert = GameObject.FindGameObjectWithTag("Player").GetComponent<QbertScript>();
        animator = gameObject.GetComponent<Animator>();
        animator.enabled = false;
    }

    private void Update()
    {
        if (animator.enabled && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            
            Qbert.CurrentCube = destinationCube;
            Qbert.transform.parent = destinationCube.transform;
            Qbert.Position = new Vector3(destinationCube.transform.position.x, destinationCube.transform.position.y + destinationCube.YOffset, destinationCube.transform.position.z);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.enabled = true;
        animator.SetBool("onElevator", true);
    }
}
