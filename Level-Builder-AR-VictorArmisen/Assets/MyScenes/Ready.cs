using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready : MonoBehaviour
{
    public OnePlane script;
    public void OnClickReady()
    {
        script.SpawnGame = true;
    }
}
