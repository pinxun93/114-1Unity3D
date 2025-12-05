using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class NPC_RUN : MonoBehaviour
{
    private NavMeshAgent 導航;
    private Animator 動畫; // 改為 Animator
    public Transform 目標;
    public float 距離 = 0;

    public TextMeshPro 血量文字;
    public int 血量 = 100;
    public Transform 血條;

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            血量--;
            血量文字.text = 血量.ToString();
            float 血量比例 = (float)血量/100f;
            血條.localScale = new Vector3(血量比例,1,1);
            if(血量 <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

}