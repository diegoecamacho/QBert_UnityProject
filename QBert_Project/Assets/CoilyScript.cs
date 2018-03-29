using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyScript : AgentBase
{
    CubeObjectScript destinationCube;
    CubeObjectScript previousDestinationCube;
    List<CubeObjectScript> OpenList;
    List<CubeObjectScript> ClosedList;
    bool Continue;
    // Use this for initialization
    void Initialize()
    {
        ClosedList.Add(currentCube);

    }

    protected override IEnumerator Routine()
    {
        while (Continue)
        {
            if (currentCube == destinationCube)
            {

                Debug.Log("Destination Cube");
            }
            else if (previousDestinationCube != destinationCube)
            {
                //TODO Grab new Current Destination cube.

            }
            else
            {
                foreach (CubeObjectScript cube in currentCube.Connections)
                {
                    if (ClosedList.Contains(cube))
                    {
                        continue;
                    }
                    if (!OpenList.Contains(cube))
                    {
                        OpenList.Add(cube);
                    }


                }
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
