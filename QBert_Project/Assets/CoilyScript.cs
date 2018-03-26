using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoilyScript : AgentBase
{
    bool Continue;
    // Use this for initialization
    void Start()
    {

    }

    protected override IEnumerator Routine()
    {
        while (Continue)
        {
            yield return new WaitForSeconds(1.0f);
        }
    }
}
