using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessChange : MonoBehaviour
{
    [SerializeField]
    private Button _firstButton;

    [SerializeField]
    private Button _secondButton;

    [SerializeField]
    private PostProcessProfile _firstProfile;

    [SerializeField]
    private PostProcessProfile _secondProfile;

    [SerializeField]
    private PostProcessVolume _postProcessVolume;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _firstButton.onClick.AddListener(() => ChangeSettings(true));
        _secondButton.onClick.AddListener(() => ChangeSettings(false));
    }

    private void OnDestroy()
    {
        _firstButton.onClick.RemoveAllListeners();
        _secondButton.onClick.RemoveAllListeners();
    }

    private void ChangeSettings(bool isFirst)
    {
        _postProcessVolume.profile = isFirst ? _firstProfile : _secondProfile;
    }
}
