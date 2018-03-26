using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBase : MonoBehaviour {

   protected CubeObjectScript currentCube;

    public virtual void  StartScript(CubeObjectScript Cube)
    {
        currentCube = Cube;
        transform.parent = Cube.transform;
        StartCoroutine(Routine());
    }

    protected virtual IEnumerator Routine() { return null; }
    
}
