using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyEggScript : AgentBase {
    
    bool Continue = true;
    int randomNum;

    [SerializeField] float OffsetY = 0.5f;

    [SerializeField] GameObject coilyPrefab;

    protected override IEnumerator Routine()
    {
        while (Continue)
        {            
                randomNum = Random.Range(0, 2);
                if (randomNum == 0)
                {

                if (currentCube.Connections[2] == null)
                {
                    Debug.Log("LEFT NONE");
                    GameObject Coily = Instantiate(coilyPrefab, new Vector3(currentCube.transform.position.x, currentCube.transform.position.y + 0.5f, currentCube.transform.position.z), new Quaternion());
                    Coily.GetComponent<AgentBase>().StartScript(currentCube);
                    Continue = false;
                    Destroy(gameObject);
                }
                else
                {
                    currentCube = currentCube.Connections[0];
                }
                }
                else
                {
                    if (currentCube.Connections[3] == null)
                    {
                        Debug.Log("RIGHT NONE");
                        GameObject Coily = Instantiate(coilyPrefab, new Vector3(currentCube.transform.position.x, currentCube.transform.position.y + 0.5f, currentCube.transform.position.z),new Quaternion());
                        Coily.GetComponent<AgentBase>().StartScript(currentCube);
                        Continue = false;
                        Destroy(gameObject);
                    }
                    else
                    {
                        currentCube = currentCube.Connections[1];
                    }

                }
                transform.position = new Vector3(currentCube.transform.position.x, currentCube.transform.position.y + OffsetY, currentCube.transform.position.z);
                Debug.Log("SnakeMove");
           

            yield return new WaitForSeconds(2.0f);
        }
    }
        
        
        
}

