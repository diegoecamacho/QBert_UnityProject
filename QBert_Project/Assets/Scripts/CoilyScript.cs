using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyScript : AgentBase
{
    public static CoilyScript coily;

    QbertScript qbert;
    [SerializeField] float OffsetY = 0.5f;
    Stack<CubeObjectScript> path = new Stack<CubeObjectScript>();
    int count = 0;



    bool Alive = true;
    CubeObjectScript destinationCube;

    // Use this for initialization

    public override void StartScript(CubeObjectScript Cube)
    {
        if (coily == null)
        {
            coily = this;
        }
        else if (coily != this)
        {
            Destroy(gameObject);
        }

        base.StartScript(Cube);

        qbert = GameObject.FindGameObjectWithTag("Player").GetComponent<QbertScript>();
        destinationCube = qbert.CurrentCube;
        BFS(currentCube, qbert.CurrentCube);
        StartCoroutine(Routine());

    }

    protected override IEnumerator Routine()
    {
        while (Alive)
        {
            if (currentCube == qbert.CurrentCube)
            {
                Debug.Log("SameCube");
                yield return null;
                   
            }
            else
            {
                if (destinationCube != qbert.CurrentCube && path.Count < 2)
                {
                    Debug.Log("Destination");
                    destinationCube = qbert.CurrentCube;
                    BFS(currentCube , qbert.CurrentCube);
                }
                else
                {
                    count++;
                    Debug.Log("Pop");
                 if (path.Count != 0)
                 {
                    currentCube = path.Pop();
                    transform.parent = currentCube.transform;
                    
                    if (transform.parent.tag == "Elevator")
                    {
                        Debug.Log("Elevator");
                        Destroy(gameObject);
                    }
                    else
                    {
                        if (currentCube == null)
                        {
                            Debug.Log("Cube Null BFS");
                            BFS(currentCube, qbert.CurrentCube);
                        }
                        else
                        {
                            Debug.Log("Move Coily");
                            transform.position = new Vector3(currentCube.transform.position.x, currentCube.transform.position.y + OffsetY, currentCube.transform.position.z);
                        }
                    }
                 }
               }
               yield return new WaitForSeconds(0.6f);
           }            

        }
    }

    void BFS(CubeObjectScript startNode , CubeObjectScript endNode)
    {

        Queue<CubeObjectScript> queue = new Queue<CubeObjectScript>();
        List<CubeObjectScript> exploredNodes = new List<CubeObjectScript>();
        Stack<CubeObjectScript> _path = new Stack<CubeObjectScript>();
        Debug.Log("Enter");
        count = 0;

        if (startNode == endNode)
        {
            return;
        }
        queue.Enqueue(startNode);

        while (queue.Count != 0)
        {
            Debug.Log("While");
            CubeObjectScript currentNode = queue.Dequeue();

            if (currentNode == endNode)
            {
                Debug.Log("Found");

                while (currentNode != startNode)
                {
                    Debug.Log("Path");
                    path.Push(currentNode);
                    currentNode = currentNode.ParentNode;
                }
            }

            foreach (CubeObjectScript node in currentNode.Connections)
            {
                Debug.Log("Searching");
               
                if(node == null){
                    Debug.Log("Null");
                    continue;
                }
                if (!exploredNodes.Contains(node))
                {
                    Debug.Log("Contains");
                    node.ParentNode = currentNode;
                    exploredNodes.Add(node);

                    queue.Enqueue(node);
                }

            }

        }
    }
}


