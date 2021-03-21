using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class OnePlane : MonoBehaviour
{
    public ARPlaneManager planeManager;
    int count = 0;
    private List<ARPlane> planes = new List<ARPlane>();
    public Button ready;
    public bool SpawnGame = false;
    public GameObject gameGround;
    public PathCreate pathCreate;

    private void Update()
    {
        if(SpawnGame)
        {
            //Spawn the game on the hit point where the cube is. 
            GameObject cube = GameObject.FindGameObjectWithTag("Point");
            Instantiate(gameGround, cube.transform.position, gameGround.transform.rotation);
            Destroy(this);
            cube.SetActive(false);
            foreach(var plane in planeManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
            planeManager.enabled = false;
            pathCreate.enabled = true;
        } 
        else
        {
            //Detecting. 
            count = planeManager.trackables.count;
            foreach (var plane in planeManager.trackables)
            {
                planes.Add(plane);
            }
            //i==planesCount-1
            for (int i = 0; i < planes.Count; i++)
            {
                if (i == planes.Count - 1)
                    planes[i].gameObject.SetActive(true); //El mas nuevo activado. 
                else
                    planes[i].gameObject.SetActive(false);
            }
        }
    }
}
