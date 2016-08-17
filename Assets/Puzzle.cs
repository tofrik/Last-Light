using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour
{
    public int numMirrors;
    public GameObject[] mirrors;
    public LineRenderer[] lines;
    public GameObject[] lights;
    //public Transform[] lightSources;
    

	// Use this for initialization
	void Start ()
    {
        //lightSources = new Transform[lights.Length];
      
        lines[0].enabled = true;
        lines[0].SetPosition(0, lights[0].transform.position);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void RayTest(GameObject raySource)
    {
        RaycastHit hit;
        Transform target;
        if (Physics.Raycast(raySource.transform.position, raySource.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Mirror")
            {
                Vector3 incidenceAngle = hit.point - raySource.transform.position;
                Vector3 reflectionAngle = Vector3.Reflect(incidenceAngle, hit.normal);
                target = hit.transform;
            }
        }
    }
}
