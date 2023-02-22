using UnityEngine;
using UnityEngine.UI;

public class MouseControl : MonoBehaviour
{
    [SerializeField] private float sensitivity = 200;
    [SerializeField] private Transform PlayerModel;
    [SerializeField] private float xRotation = 0;
    [SerializeField] private GameObject slider;

    private void Update()
    {
        sensitivity = slider.GetComponent<Slider>().value;

        // ��������� �������� ��������
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY; // ? ��������� ���������� ���� 
        xRotation = Mathf.Clamp(xRotation, -90, 90); // ������ �������� ����� -90 � 90 ��� ����������� ������������� ������;

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0); // ������� ������ �� y
        PlayerModel.Rotate(Vector3.up * mouseX); // ������� ��������� �� x
    }
}
