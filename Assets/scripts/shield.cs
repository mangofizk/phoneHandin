using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class shield : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float maxTapDelay = 0.3f;
    float lasttaptime = 0;
    public bool isShieldActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnhancedTouchSupport.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.activeTouches.Count < 1)
            return;

        var touch1 = Touch.activeTouches[0];

        if(touch1.phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
            float timeSinceLastTap = Time.time - lasttaptime;

            if(timeSinceLastTap <= maxTapDelay)
            {
                if (!isShieldActive)
                {
                    StartCoroutine(shieldDuration());
                }
                Debug.Log("Start");                  
                lasttaptime = 0f;
            }
            else
            {
                lasttaptime = Time.time;
            }
        }
    }

    IEnumerator shieldDuration()
    {
        player.GetComponent<SpriteRenderer>().color = Color.blue;
        isShieldActive = true;
        yield return new WaitForSeconds(3f);
        isShieldActive = false ;
        player.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
