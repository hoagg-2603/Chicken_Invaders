using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Boss")
        {
            BossController.instance.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
