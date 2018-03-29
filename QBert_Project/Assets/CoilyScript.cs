using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyScript : AgentBase
{
    IDictionary<CubeObjectScript, CubeObjectScript> nodeParents = new Dictionary<CubeObjectScript, CubeObjectScript>();
    CubeObjectScript destinationCube;
    QbertScript qbert;
    List<CubeObjectScript> Node = new List<CubeObjectScript>();

 
    bool Continue;
    // Use this for initialization

    public override void StartScript(CubeObjectScript Cube)
    {
        base.StartScript(Cube);
        qbert = GameObject.FindGameObjectWithTag("Player").GetComponent<QbertScript>();
        destinationCube = qbert.CurrentCube;
        StartCoroutine(Routine());

    }

    protected override IEnumerator Routine()
    {
            BFS();
         yield return new WaitForSeconds(1.0f);
     
    }

    void BFS()
    {
        Queue<CubeObjectScript> queue = new Queue<CubeObjectScript>();
        List<CubeObjectScript> exploredNodes = new List<CubeObjectScript>();

        queue.Enqueue(currentCube);

        while (queue.Count != 0)
        {
           
            CubeObjectScript currentNode = queue.Dequeue();
            
            foreach (CubeObjectScript node in currentNode.Connections)
            {
                if (currentNode == destinationCube)
                {
                    Debug.Log("Found");
                    for (int i = 0; i < 20; i++)
                    {
                        Debug.Log(currentNode);
                        currentNode = currentNode.ParentNode;

                    }
                }
                if (node == null)
                {
                    continue;
                }
                if (!exploredNodes.Contains(node))
                {
                    node.ParentNode = currentNode;
                    exploredNodes.Add(node);

               
                

                    queue.Enqueue(node);
                }

            }

        }
        
    }
}


