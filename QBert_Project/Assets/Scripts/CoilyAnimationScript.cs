using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyAnimationScript : MonoBehaviour {

    public void DestroyAnimation(){
        if (CoilyScript.coily != null)
        {
            CoilyScript.Move();
        }
        
        Destroy(gameObject);
    }
}
