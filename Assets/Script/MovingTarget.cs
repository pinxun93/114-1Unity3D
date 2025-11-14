using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    // 編輯器中可調整的參數
    [Header("移動設定")]
    [Tooltip("來回移動的總距離 (以世界座標單位計算)")]
    public float distance = 5.0f;

    [Tooltip("從起點移動到終點所需的時間 (秒)")]
    public float speed = 2.0f; // 這裡 speed 其實更像 timePeriod 或 duration

    // 私有變數
    private Vector3 _startPosition; // 儲存物體的初始位置

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 在遊戲開始時，記錄物體的初始世界座標
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 計算 Ping Pong 值
        // Time.time 是遊戲運行以來的時間（秒）。
        // Time.time * speed 決定了移動的速度（改變速度的快慢）。
        // Mathf.PingPong 會讓值在 0 到 distance 之間來回變化。
        float pingPongValue = Mathf.PingPong(Time.time * speed, distance);

        // 2. 應用到位置上
        // 假設我們想要在 X 軸上來回移動
        Vector3 newPosition = _startPosition;
        newPosition.x += pingPongValue; // 將 pingPongValue 加到 X 軸上

        // 3. 更新物體的位置
        transform.position = newPosition;
    }
}
