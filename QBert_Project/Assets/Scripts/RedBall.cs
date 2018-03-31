using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : AgentBase
{
    bool Continue = true;
    int randomNum;

    [SerializeField] float OffsetY = 0.5f;

    public override void StartScript(CubeObjectScript Cube)
    {
        base.StartScript(Cube);
        StartCoroutine(Routine());
    }

    protected override IEnumerator Routine()
    {
        while (Continue)
        {
            randomNum = Random.Range(0, 2);
            if (randomNum == 0)
            {
                 currentCube = currentCube.Connections[2];
                
                if (currentCube == null)
                {
                    Debug.Log("Destroy");
                    Continue = false;
                    StopAllCoroutines();
                    Destroy(gameObject);
                } 
            }
            else
            {
                currentCube = currentCube.Connections[3];
                if (currentCube == null)
                {
                    Debug.Log("Destroy");
                    Continue = false;
                    StopAllCoroutines();
                    Destroy(gameObject);
                }
            }
            transform.position = new Vector3(currentCube.transform.position.x, currentCube.transform.position.y + OffsetY, currentCube.transform.position.z);
            yield return new WaitForSeconds(0.8f);
        }
    }
}
