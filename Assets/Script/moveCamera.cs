using UnityEngine;

public class moveCamera : MonoBehaviour
{
    [Header("���ʳt��")]
    public float moveSpeed = 3.5f;

    [Header("�ƹ��F�ӫ�")]
    public float mouseSensitivity = 2f;

    float rotationX = 0f; // �W�U����

    void Update()
    {
        // ��L����
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        // �ƹ�������� (����k�����)
        if (Input.GetMouseButton(1)) // �k��
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // ���k����
            transform.Rotate(Vector3.up * mouseX, Space.World);

            // �W�U�����]����b -80�X �� 80�X�^
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -80f, 80f);
            Camera.main.transform.localEulerAngles = new Vector3(rotationX, Camera.main.transform.localEulerAngles.y, 0f);
        }
    }
}
