using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // current blood volume
    public float health = 0.0f;
    // Increase/decrease blood volume
    private float resulthealth;

    private Rect _HealthBar;
    private Rect HealthUp;
    private Rect HealthDown;

    void Start()
    {
        //Health bar area
        _HealthBar = new Rect(50, 50, 200, 20);
        //Add blood button area
        HealthUp = new Rect(105, 80, 40, 20);
        //Reduce blood button area
        HealthDown = new Rect(155, 80, 40, 20);
        resulthealth = health;
    }

    void OnGUI()
    {
        if (GUI.Button(HealthUp, "Add"))
        {
            resulthealth = resulthealth + 0.1f > 1.0f ? 1.0f : resulthealth + 0.1f;
        }
        if (GUI.Button(HealthDown, "Reduce"))
        {
            resulthealth = resulthealth - 0.1f < 0.0f ? 0.0f : resulthealth - 0.1f;
        }

        //Interpolate to calculate the health value to achieve smooth changes in the health bar value
        health = Mathf.Lerp(health, resulthealth, 0.05f);

        // Use the width of the horizontal scroll bar as the displayed value of the health bar
        GUI.HorizontalScrollbar(_HealthBar, 0.0f, health, 0.0f, 1.0f);
    }
}
