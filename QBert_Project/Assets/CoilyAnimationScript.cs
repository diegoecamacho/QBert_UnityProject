using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyAnimationScript : MonoBehaviour {

    public void DestroyAnimation(){
        CoilyScript.Move();
        Destroy(gameObject);
    }
}
