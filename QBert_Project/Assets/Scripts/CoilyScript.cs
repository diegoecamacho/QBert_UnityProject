using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyScript : AgentBase
{
    public static CoilyScript coily;

    static GameObject CoilyMesh;

    QbertScript qbert;
    [SerializeField] float OffsetY = 0.5f;

    [SerializeField]GameObject CoilyAnimPrefab;

   
    Stack<CubeObjectScript> path = new Stack<CubeObjectScript>();
    int count = 0;



    bool Alive = true;
    CubeObjectScript destinationCube;

    public int NodeDirection = 0;


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
	    CoilyMesh = GameObject.FindGameObjectWithTag("CoilyMesh");
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
                yield return null;
                   
            }
            else
            {
                if (destinationCube != qbert.CurrentCube && path.Count < 2)
                {
                    destinationCube = qbert.CurrentCube;
                    BFS(currentCube , qbert.CurrentCube);
                }
                else
                {
                    count++;
                   
                 if (path.Count != 0)
                 {
                    currentCube = path.Pop();
                    if (currentCube == null)
                    {
                      
                        BFS(currentCube, qbert.CurrentCube);
                    }
                    else
                    {
                            MoveCoily();
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
       
        count = 0;

        if (startNode == endNode)
        {
            return;
        }
        queue.Enqueue(startNode);

        while (queue.Count != 0)
        {

            CubeObjectScript currentNode = queue.Dequeue();

            if (currentNode == endNode)
            {
           

                while (currentNode != startNode)
                {

                    path.Push(currentNode);
                    currentNode = currentNode.ParentNode;
                }
            }

            foreach (CubeObjectScript node in currentNode.Connections)
            {
                NodeDirection++;
                if(node == null){
                  
                    continue;
                }
                if (!exploredNodes.Contains(node))
                {
                 
                    node.ParentNode = currentNode;
                    node.NodeDirection = NodeDirection - 1;


                    exploredNodes.Add(node);

                    queue.Enqueue(node);
                }

            }
            NodeDirection = 0;

        }
    }

    void MoveCoily(){

        ///TODO:

        var coilyAnimGameobject = Instantiate(CoilyAnimPrefab, transform.position, transform.rotation, currentCube.transform);
        CoilyMesh.SetActive(false);
        Animator coilyAnimation = coilyAnimGameobject.GetComponent<Animator>();
        coilyAnimation.SetBool("Jump", true);
        coilyAnimation.SetInteger("Direction", currentCube.NodeDirection);

        transform.parent = currentCube.transform;
        transform.position = new Vector3(currentCube.transform.position.x, currentCube.transform.position.y + OffsetY, currentCube.transform.position.z);
        if (transform.parent.tag == "Elevator")
        {

            Destroy(gameObject);
        }
        
    }

    public static void Move(){
        CoilyMesh.SetActive(true);
        
    }
}
