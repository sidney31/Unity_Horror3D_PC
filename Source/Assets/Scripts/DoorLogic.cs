using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void DoorClose()
    {
        anim.Play("DoorClose", 0, 0);
    }

    private void DoorOpen()
    {
        anim.Play("DoorOpen", 0, 0);
    }

    private string GetDoorState()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("DoorOpen"))
        {
            return "DoorOpen";
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("DoorClose"))
        {
            return "DoorClose";
        }
        else
        {
            return "idle";
        }
    }

    public void MoveDoor()
    {
        switch (GetDoorState())
        {
            case "DoorOpen":
                DoorClose();
                break;
            default:
                DoorOpen();
                break;
        }
    }
}
