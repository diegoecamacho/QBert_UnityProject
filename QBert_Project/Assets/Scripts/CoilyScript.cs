using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyScript : AgentBase
{
    public static CoilyScript coily;

    CubeObjectScript destinationCube;
    CubeObjectScript startingNode;
    QbertScript qbert;
    [SerializeField] float OffsetY = 0.5f;
    Stack<CubeObjectScript> path = new Stack<CubeObjectScript>();
    int count = 0;



    bool Alive = true;
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
        startingNode = Cube;
        destinationCube = qbert.CurrentCube;
        BFS();
        StartCoroutine(Routine());

    }

    protected override IEnumerator Routine()
    {
        while (Alive)
        {
            if (destinationCube != qbert.CurrentCube && count >=2)
            {
                startingNode = currentCube;
                destinationCube = qbert.CurrentCube;
                BFS();
                foreach (var cube in path)
                {
                    Debug.Log(cube);
                }
            }
            else
            {
                currentCube = path.Pop();
                transform.parent = currentCube.transform;
                count++;
                if (transform.parent.tag == "Elevator")
                {
                    Destroy(gameObject);
                }
                else
                {
                    if (currentCube == null)
                    {
                       
                        BFS();
                    }
                    else
                    {
                        transform.position = new Vector3(currentCube.transform.position.x, currentCube.transform.position.y + OffsetY, currentCube.transform.position.z);
                    }
                }

            }

            yield return new WaitForSeconds(0.7f);
       

        }
      
     
    }

    void BFS()
    {
        count = 0;

        Queue<CubeObjectScript> queue = new Queue<CubeObjectScript>();
        List<CubeObjectScript> exploredNodes = new List<CubeObjectScript>();
        Stack<CubeObjectScript> _path = new Stack<CubeObjectScript>();

        queue.Enqueue(currentCube);

        while (queue.Count != 0)
        {
           
            CubeObjectScript currentNode = queue.Dequeue();

            if (currentNode == destinationCube)
            {
                Debug.Log("Found");

                while (currentNode != startingNode)
                {
                    path.Push(currentNode);
                    currentNode = currentNode.ParentNode;
                }
            }

            foreach (CubeObjectScript node in currentNode.Connections)
            {
               
                if(node == null){
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


