using UnityEngine;

public class PaddleController : MonoBehaviour
{

    [SerializeField] private float speed = 1f;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            var pos = transform.position;
            
            // neue position berechnen
            var newPosX = pos.x - speed * Time.deltaTime;

            transform.position = new Vector3(newPosX, pos.y, pos.z);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            var pos = transform.position;
            
            // neue position berechnen
            var newPosX = pos.x + speed * Time.deltaTime;

            transform.position = new Vector3(newPosX, pos.y, pos.z);
        }
    }
}
