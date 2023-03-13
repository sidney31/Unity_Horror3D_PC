using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private Animator anim;

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
            case "DoorOpen":
                DoorClose();
                break;
        }
    }

    private void DoorOpen()
    {
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
}
