using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform ObjectsChecker;
    [SerializeField] private LayerMask ObjectsLayer;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DoorInteractive()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
            return;

        switch (GetCurrentAnim())
        {
            case "DoorIdle":
                DoorOpen();
                break;
            case "DoorClose":
                DoorOpen();
                break;
            case "DoorBlocked":
                DoorOpen();
                break;
            case "DoorOpen":
                DoorClose();
                break;
        }
    }

    private void DoorOpen()
    {
        if (ObjectsArroundIsExist())
        {
            animator.Play("DoorBlocked");
            return;
        }

        animator.Play("DoorOpen");
    }

    private void DoorClose()
    {
        animator.Play("DoorClose");
    }

    private string GetCurrentAnim()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        return clipInfo[0].clip.name;
    }
    private bool ObjectsArroundIsExist()
    {
        Collider[] ObjectsArround = Physics.OverlapBox(ObjectsChecker.position,
                                    ObjectsChecker.localScale / 2, 
                                    Quaternion.identity, 
                                    ObjectsLayer);

        if (ObjectsArround.Length == 0)
            return false;
        
        return true;
    }

    private void OnDrawGizmosSelected()
    {
        if (!ObjectsChecker)
            return;

        Gizmos.DrawCube(ObjectsChecker.position, ObjectsChecker.localScale);
    }
}
