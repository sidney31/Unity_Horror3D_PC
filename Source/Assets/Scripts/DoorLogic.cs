using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        anim = GetComponentInParent<Animator>();
    }

    private void OnMouseDown() // детект контакта с дверью
    {
        if (Input.GetMouseButtonDown(0) && Vector3.Distance(transform.position, player.position) <= 1.5f)
        {
            DoorInteractive();
        }

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

    public void DoorInteractive() 
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
