using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ColorGradingChange : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume _postProcessVolume;

    private ColorGrading _colorGrading;

    private bool _isChanging = false;

    private void Start()
    {
        _colorGrading = ScriptableObject.CreateInstance<ColorGrading>();
        _colorGrading.enabled.Override(true);
        _colorGrading.temperature.Override(1);
        _postProcessVolume = PostProcessManager.instance.QuickVolume(7, 2, _colorGrading);
    }

    private void Update()
    {
        StartCoroutine(ChangeSpeed(0, 100, 5));
    }

    private void OnTriggerEnter(Collider other)
    {
        //_colorGrading.temperature.value = Mathf.Lerp(0, 100, 50);
        _isChanging = true;
    }

    IEnumerator ChangeSpeed(float start, float end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            _colorGrading.temperature.value = Mathf.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        _colorGrading.temperature.value = end;
    }
}
