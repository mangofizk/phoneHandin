using UnityEngine;

public class Enemy : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        Vector3 viewportPos =Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPos.y < 0f )
        {
            Destroy(gameObject);
        }
    }
}
