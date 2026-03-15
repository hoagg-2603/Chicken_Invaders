using System.Collections;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public static ShipScript Instance;
    [SerializeField] private GameObject ShipPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
       
    }
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpamShip()
    {
        var newShip = Instantiate(ShipPrefab, Camera.main.ViewportToWorldPoint(new Vector3(0.5f,-0.5f,0)), Quaternion.identity);
        var point = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1.5f, 0));
    }

    IEnumerator MoveShipToPoint(GameObject ship, Vector3 point)
    {
        float timer = 0;

        while (ship && ship.transform.position != point) 
        {
            timer += Time.fixedDeltaTime;

            ship.transform.position = Vector3.Lerp(ship.transform.position, point, timer);
            yield return new WaitForFixedUpdate();
        }
    }
}
