using UnityEngine;

public class MouseControl : MonoBehaviour
{
    [SerializeField] private float sensitivity = 150;
    [SerializeField] private Transform PlayerModel;
    [SerializeField] private float xRotation = 0;

    private void Start()
    {
        sensitivity = PlayerPrefs.GetInt("Sensitivity");
    }

    private void Update()
    {
        if (ButtonManager.instance.PauseMenu.activeSelf)
        {
            return;
        }

        // ��������� �������� ��������
        float mouseX = Input.GetAxis("Mouse X") * sensitivity; 
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;


        xRotation -= mouseY; // ? ��������� ���������� ���� 
        xRotation = Mathf.Clamp(xRotation, -90, 90); // ������ �������� ����� -90 � 90 ��� ����������� ������������� ������;

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0); // ������� ������ �� y
        PlayerModel.Rotate(Vector3.up * mouseX); // ������� ��������� �� x
    }
}
