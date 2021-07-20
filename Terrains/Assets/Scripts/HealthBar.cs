using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float health = 0.0f;
    private float resulthealth;

    private Rect _HealthBar;
    private Rect HealthUp;
    private Rect HealthDown;

    void Start()
    {
        _HealthBar = new Rect(50, 50, 200, 20);
        HealthUp = new Rect(155, 80, 40, 20);
        HealthDown = new Rect(105, 80, 40, 20);
        
        resulthealth = health;
    }

    void OnGUI()
    {
        if (GUI.Button(HealthUp, "+"))
        {
            resulthealth = resulthealth + 0.1f > 1.0f ? 1.0f : resulthealth + 0.1f;
        }
        if (GUI.Button(HealthDown, "-"))
        {
            resulthealth = resulthealth - 0.1f < 0.0f ? 0.0f : resulthealth - 0.1f;
        }

        health = Mathf.Lerp(health, resulthealth, 0.05f);

        GUI.HorizontalScrollbar(_HealthBar, 0.0f, health, 0.0f, 1.0f);

    }
}
