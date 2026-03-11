using System.Collections;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float speed = 55f;
    [SerializeField] private GameObject[] bulletList;
    [SerializeField] private int currentTierBullet;
    [SerializeField] private GameObject VFX;
    [SerializeField] private GameObject shield;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DisableShield());
    }

    // Update is called once per frame
    void Update()
    {
       
        Fire();
        Move();
    }

    void Move()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = Vector3.MoveTowards(
                transform.position,
                mousePos,
                speed*Time.deltaTime
        );

        Vector3 TopLeftPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -TopLeftPoint.x, TopLeftPoint.x),
            Mathf.Clamp(transform.position.y, -TopLeftPoint.y, TopLeftPoint.y),
            0
        );
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletList[currentTierBullet], transform.position, Quaternion.identity);
        }
            
    }

    IEnumerator DisableShield()
    {
        yield return new WaitForSeconds(5f);
        shield.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (!shield.activeSelf && (collision.CompareTag("Chiken") || collision.CompareTag("Egg")))
        {
            Destroy(gameObject);
        }
        
    }

    private void OnDestroy()
    {
        if(gameObject.scene.isLoaded) {
            var vfx = Instantiate(VFX, transform.position, Quaternion.identity);
            Destroy(vfx, 1f);
        }
    }
}
