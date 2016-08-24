using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;
using InControl;
using UnityStandardAssets.Cameras;


public class MirrorRotate : MonoBehaviour
{
    MyCharacterActions characterActions;
    public GameObject mirror;
    public GameObject mirrorBase;
    GameObject player;
    ThirdPersonUserControl thirdPersonScript;
    FreeLookCam freeLookScript;
    ProtectCameraFromWallClip wallClipScript;
    GameObject mainCamera;
    bool canPushMirror = false;
    float timer = 0;
    bool timerSet = false;

	// Use this for initialization
	void Start ()
    {
        characterActions = new MyCharacterActions();
        characterActions.RotateMirror.AddDefaultBinding(Key.R);
        characterActions.RotateMirror.AddDefaultBinding(InputControlType.RightBumper);
        characterActions.Left.AddDefaultBinding(Key.A);
        characterActions.Left.AddDefaultBinding(InputControlType.LeftStickRight);
        characterActions.Right.AddDefaultBinding(Key.D);
        characterActions.Right.AddDefaultBinding(InputControlType.LeftStickLeft);

        mainCamera = GameObject.FindGameObjectWithTag("BaseCamera");
        freeLookScript = mainCamera.GetComponentInChildren<FreeLookCam>();
        wallClipScript = mainCamera.GetComponentInChildren<ProtectCameraFromWallClip>();


        player = GameObject.FindGameObjectWithTag("Player");
        thirdPersonScript = player.GetComponentInChildren<ThirdPersonUserControl>();
       // mirrorBase = GameObject.FindGameObjectWithTag("MirrorBase");

    }

    // Update is called once per frame
    void Update()
    {

        if(timerSet == true)
        {
            thirdPersonScript.canPushMirror = false;
            timer += Time.deltaTime;
            if(timer >= 1.0f)
            {
                timerSet = false;
                timer = 0f;
            }
        }
 
        if(thirdPersonScript.canPushMirror == true)
        {
            if(characterActions.Left.IsPressed)
            {
                mirror.transform.Rotate(new Vector3(0, 1, 0));
            }
            if(characterActions.Right.IsPressed)
            {
                mirror.transform.Rotate(new Vector3(0, -1, 0));
            }
            if (characterActions.RotateMirror.IsPressed == true)
            {
                thirdPersonScript.canPushMirror = false;
                freeLookScript.SetTarget(player.transform);
                wallClipScript.closestDistance = 0.5f;
                timerSet = true;
            }
        }
        else if (thirdPersonScript.canPushMirror == false && timerSet == false)
        {
            if (characterActions.RotateMirror.IsPressed == true && canPushMirror == true)
            {
                thirdPersonScript.canPushMirror = true;
                freeLookScript.SetTarget(mirrorBase.transform);
                wallClipScript.closestDistance = 5;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            canPushMirror = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canPushMirror = false;
        }
    }
}
