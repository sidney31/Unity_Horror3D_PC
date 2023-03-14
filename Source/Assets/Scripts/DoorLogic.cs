using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform ObjectsChecker;
    [SerializeField] private LayerMask ObjectsLayer;

    public void DoorInteractive()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
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
            
            anim.Play("DoorBlocked");
            return;
        }

        anim.Play("DoorOpen");
    }

    private void DoorClose()
    {
        anim.Play("DoorClose");
    }

    private string GetCurrentAnim()
    {
        AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);
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
