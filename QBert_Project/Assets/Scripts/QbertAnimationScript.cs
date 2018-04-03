using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QbertAnimationScript : MonoBehaviour {

    public void DestroyAnimation(){
        QbertScript.Move();
        Destroy(gameObject);
    }
}
