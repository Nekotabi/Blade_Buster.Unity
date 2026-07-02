using UnityEngine;

public class ActManager : MonoBehaviour
{
    private Touch touch;
    private Vector2 beganPoint;
    private const float tapCurrent = 5f;
    private const float timeCurrent = 0.1f;
    private float distance;
    private float touchStartTime;
    private float touchingTime;
    private bool isTouching;

    private void Start()
    {
        isTouching = false;
    }

    private void Update()
    {
        Debug.Log(Input.touchCount);
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    beganPoint = touch.position;
                    touchStartTime = Time.time;
                    break;
                case TouchPhase.Ended:
                    touchingTime = Time.time - touchStartTime;
                    distance = Vector2.Distance(beganPoint, touch.position);
                    JudgeInput(touchingTime, distance);
                    MainControler.ReferenceRequest();
                    break;
            }
        }
    }

    private void JudgeInput(float _time, float _dist)
    {
        //タップ判定
        if (_dist < tapCurrent)
            MainControler.state = MainControler.InputState.TAP;
        //フリック判定
        else if (_time < timeCurrent)
            MainControler.state = MainControler.InputState.FLICK;
        //スワイプ判定
        else
            MainControler.state = MainControler.InputState.SWIPE;

        touchingTime = 0f;
        distance = 0f;
    }
}
