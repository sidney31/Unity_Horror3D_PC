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

        // получение движения курсором
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY; // ? локальная координата мыши 
        xRotation = Mathf.Clamp(xRotation, -90, 90); // держит значение между -90 и 90 для ограничения вертикального обзора;

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0); // поворот камеры по y
        PlayerModel.Rotate(Vector3.up * mouseX); // поворот персонажа по x
    }
}
