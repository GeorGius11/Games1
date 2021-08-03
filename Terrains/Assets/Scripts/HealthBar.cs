using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _health;
    
    private float _resulthealth;
    private Rect _HealthBar;
    private Rect _HealthUp;
    private Rect _HealthDown;

    private void Start()
    {
        _HealthBar = new Rect(50, 50, 200, 20);
        _HealthUp = new Rect(155, 80, 40, 20);
        _HealthDown = new Rect(105, 80, 40, 20);
        
        _resulthealth = _health;
    }

    private void OnGUI()
    {
        if (GUI.Button(_HealthUp, "+"))
        {
            _resulthealth = _resulthealth + 0.1f > 1.0f ? 1.0f : _resulthealth + 0.1f;
        }
        if (GUI.Button(_HealthDown, "-"))
        {
            _resulthealth = _resulthealth - 0.1f < 0.0f ? 0.0f : _resulthealth - 0.1f;
        }

        _health = Mathf.Lerp(_health, _resulthealth, 0.05f);

        GUI.HorizontalScrollbar(_HealthBar, 0.0f, _health, 0.0f, 1.0f);

    }
}
