using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyEggScript : AgentBase {
    
    bool Continue = true;
    int randomNum;

    [SerializeField] float OffsetY = 0.5f;

    [SerializeField] GameObject coilyPrefab;

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
                    if (currentCube.Connections[2] == null)
                    {
                        GameObject Coily = Instantiate(coilyPrefab, new Vector3(currentCube.transform.position.x, currentCube.transform.position.y + 0.5f, currentCube.transform.position.z), coilyPrefab.transform.localRotation ,currentCube.transform);
                        Coily.GetComponent<AgentBase>().StartScript(currentCube);
                        Continue = false;
                        Destroy(gameObject);
                    }
                    else
                    {
                        currentCube = currentCube.Connections[2];
                    }
                }
                else
                {
                    if (currentCube.Connections[3] == null)
                    {
                    GameObject Coily = Instantiate(coilyPrefab, new Vector3(currentCube.transform.position.x, currentCube.transform.position.y + 0.5f, currentCube.transform.position.z),coilyPrefab.transform.localRotation,currentCube.transform);
                        Coily.GetComponent<AgentBase>().StartScript(currentCube);
                        Continue = false;
                        Destroy(gameObject);
                    }
                    else
                    {
                        currentCube = currentCube.Connections[3];
                    }

                }
            transform.position = new Vector3(currentCube.transform.position.x, currentCube.transform.position.y + OffsetY, currentCube.transform.position.z);
            yield return new WaitForSeconds(0.6f);
        }
    }      
}

