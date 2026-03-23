using Unity.VisualScripting;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float bobHeight;

    [SerializeField]
    private float bobSpeed;

    private float startYPos;

    void Start()
    {
        startYPos = transform.position.y;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

        float yOffset = Mathf.Sin(Time.time * bobSpeed) * bobHeight / 2; 
        Vector3 pos = transform.position;
        pos.y = startYPos + yOffset;
        transform.position = pos;
    } 

    private void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().IncreaseScore(1);
            Destroy(gameObject);
        }
    }
}
