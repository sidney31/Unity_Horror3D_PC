using System.Collections;
using TreeEditor;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private bool CanDoorInteractive;
    [SerializeField] private bool DoorIsOpen;

    private void Start()
    {
        CanDoorInteractive = true;
        DoorIsOpen = false;
    }

    public void DoorInteractive() 
    {
        if (!CanDoorInteractive)
            return;

        switch (DoorIsOpen)
        {
            case true:
                StartCoroutine(CloseDoor());
                break;
            case false:
                StartCoroutine(OpenDoor());
                break;
        }
    }

    private IEnumerator OpenDoor()
    {
        float StartYRotation = transform.parent.rotation.y;
        CanDoorInteractive = false;
        Debug.Log($"StartRotation {StartYRotation}. EndRotation {StartYRotation - 90}");
        while (transform.parent.rotation.y >= StartYRotation - 90)
        {
            Quaternion TempRotation = transform.parent.rotation;
            TempRotation.y -= 1;
            transform.parent.rotation = TempRotation;
            Debug.Log(transform.parent.rotation);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        CanDoorInteractive = true;
        DoorIsOpen = true;
    }
    private IEnumerator CloseDoor()
    {
        Debug.Log("closing...");
        CanDoorInteractive = false;
        float StartYRotation = transform.parent.rotation.y;
        while (transform.parent.rotation.y >= StartYRotation + 90)
        {
            Quaternion TempRotation = transform.parent.rotation;
            TempRotation.y += 1;
            transform.parent.rotation = TempRotation;
            Debug.Log(transform.parent.rotation.y);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        CanDoorInteractive = true;
        DoorIsOpen = false;
        Debug.Log("closed");
    }
}
