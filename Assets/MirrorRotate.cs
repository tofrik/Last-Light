using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;
using InControl;
using UnityStandardAssets.Cameras;


public class MirrorRotate : MonoBehaviour
{
    MyCharacterActions characterActions;
    GameObject mirror;
    GameObject mirrorBase;
    GameObject player;
    ThirdPersonUserControl thirdPersonScript;
    FreeLookCam freeLookScript;
    ProtectCameraFromWallClip wallClipScript;
    GameObject mainCamera;
    bool canPushMirror = false;

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
        mirrorBase = GameObject.FindGameObjectWithTag("MirrorBase");
        mirror = GameObject.FindGameObjectWithTag("Mirror");
    }

    // Update is called once per frame
    void Update()
    {
        if (thirdPersonScript.canPushMirror == false)
        {

            if (characterActions.RotateMirror.WasPressed == true && canPushMirror == true)
            {
                thirdPersonScript.canPushMirror = true;
                freeLookScript.SetTarget(mirrorBase.transform);
                wallClipScript.closestDistance = 4;
            }
        }
        else
        {
            if(characterActions.Left.IsPressed)
            {
                mirror.transform.Rotate(new Vector3(0, 1, 0));
            }
            if(characterActions.Right.IsPressed)
            {
                mirror.transform.Rotate(new Vector3(0, -1, 0));
            }
            if (characterActions.RotateMirror.WasPressed == true)
            {
                thirdPersonScript.canPushMirror = false;
                freeLookScript.SetTarget(player.transform);
                wallClipScript.closestDistance = 0.5f;
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
