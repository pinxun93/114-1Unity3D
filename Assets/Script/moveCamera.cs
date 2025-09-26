using UnityEngine;

public class moveCamera : MonoBehaviour
{
    [Header("移動速度")]
    public float moveSpeed = 3.5f;

    [Header("滑鼠靈敏度")]
    public float mouseSensitivity = 2f;

    float rotationX = 0f; // 上下角度

    void Update()
    {
        // 鍵盤移動
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

        // 滑鼠控制視角 (按住右鍵旋轉)
        if (Input.GetMouseButton(1)) // 右鍵
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // 左右旋轉
            transform.Rotate(Vector3.up * mouseX, Space.World);

            // 上下視角（限制在 -80° 到 80°）
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -80f, 80f);
            Camera.main.transform.localEulerAngles = new Vector3(rotationX, Camera.main.transform.localEulerAngles.y, 0f);
        }
    }
}
