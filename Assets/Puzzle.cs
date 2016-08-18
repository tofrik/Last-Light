using UnityEngine;
using System.Collections;

public class Puzzle : MonoBehaviour
{
    public int numMirrors;
    public GameObject[] mirrors;
    public LineRenderer[] lines;
    public GameObject[] lights;
    //public Transform[] lightSources;

    RaycastHit prevHit;
    Vector3 incidenceAngle;
    Vector3 reflectionAngle;
    Transform prevTarget;

    // Use this for initialization
    void Start ()
    {
        //lightSources = new Transform[lights.Length];
       // lines[0].enabled = true;
       // lines[0].SetPosition(0, lights[0].transform.position);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        lines[0].enabled = true;
        lines[0].SetPosition(0, lights[0].transform.position);
        for (int i = 0; i < lights.Length; i++)
        {
            
                RayTest(lights[i], i);
            
          
                
                //break;
            
        }
	}

    bool RayTest(GameObject raySource, int i)
    {
        RaycastHit hit;

        if (i == 0)
        {
            if (Physics.Raycast(raySource.transform.position, raySource.transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Mirror")
                {
                    prevHit = hit;

                    incidenceAngle = hit.point - raySource.transform.position;
                    reflectionAngle = Vector3.Reflect(incidenceAngle, hit.normal);
                    prevTarget = hit.transform;
                    //lines[i].enabled = true;
                    //lines[i].SetPosition(1, (target.position + reflectionAngle));
                    Debug.DrawRay(raySource.transform.position, hit.point - raySource.transform.position, Color.white);
                    if (hit.transform.tag == "Mirror")
                    {
                        MirrorRayTest(hit, i++);
                    }
                    //Debug.DrawRay(raySource.transform.position, raySource.transform.forward, Color.white);
                    return true;
                }
            }
            
        }
        return false;
    }
            
        
        
        /*
        else
        {
            if (Physics.Raycast(prevTarget.position, reflectionAngle, out hit, Mathf.Infinity))
            {
                
                incidenceAngle = hit.point - prevTarget.position;
                reflectionAngle = Vector3.Reflect(incidenceAngle, hit.normal);
                target = hit.transform;
                prevTarget = target;
                lines[i].enabled = true;
                lines[i].SetPosition(0, prevHit.point);
                lines[i].SetPosition(1, (target.position + reflectionAngle));
                Debug.DrawRay(target.position, reflectionAngle, Color.white);
                prevHit = hit;
                return true;

            }

            return false;
        }
        */
    

    bool MirrorRayTest(RaycastHit raySource, int i)
    {
        RaycastHit hit;
        Transform target;
        if (Physics.Raycast(raySource.transform.position, reflectionAngle, out hit, Mathf.Infinity))
        {

            //incidenceAngle = hit.point - raySource.point;
            //reflectionAngle = Vector3.Reflect(incidenceAngle, hit.normal);
            target = hit.transform;
            prevTarget = target;
            //lines[i].enabled = true;
            //lines[i].SetPosition(0, prevHit.point);
            //lines[i].SetPosition(1, (target.position + reflectionAngle));
           // Debug.DrawRay(hit.point, reflectionAngle, Color.white);
            Debug.DrawRay(raySource.point, reflectionAngle, Color.white);
            incidenceAngle = hit.point - raySource.point;
            reflectionAngle = Vector3.Reflect(incidenceAngle, hit.normal);
            prevHit = hit;
            if(hit.transform.tag == "Mirror")
            {
                MirrorRayTest(hit, i++);
            }
            return true;
        }
        return false;
    }
}



   


