using UnityEngine;
using UnityEngine.AI;

public class NPC_RUN : MonoBehaviour
{
    private NavMeshAgent 導航;
    private Animator 動畫; // 改為 Animator
    public Transform 目標;
    public float 距離 = 0;

    void Start()
    {
        導航 = GetComponent<NavMeshAgent>();
        動畫 = GetComponent<Animator>(); // 對應 Animator
    }

    void Update()
    {
        if (目標 != null)
        {
            導航.SetDestination(目標.position);
            距離 = Vector3.Distance(目標.position, transform.position);

            if (距離 <= 3.1f)
            {
                動畫.SetBool("iswalk", false);
            }
            else
            {
                動畫.SetBool("iswalk", true);
            }
        }
    }
}