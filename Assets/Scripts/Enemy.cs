using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Vector3 startPos;

    [SerializeField]
    private Vector3 endPos;

    private Vector3 targetPos;

    void Start()
    {
        targetPos = endPos;
        transform.position = startPos;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if(transform.position == targetPos)
        {
            if(targetPos == startPos)
            {
                targetPos = endPos;
            }
            else if(targetPos == endPos)
            {
                targetPos = startPos;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().GameOver();
        }
    }
}
