using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    [Header("Post Processing")]
    [SerializeField] private PostProcessProfile Profile;
    [SerializeField] private AmbientOcclusion AmbientOcclusion;
    [SerializeField] private Bloom Bloom;
    [SerializeField] private MotionBlur MotionBlur;
    [Space]
    [SerializeField] private Toggle AmbientOcclusionToggle;
    [SerializeField] private Toggle BloomToggle;
    [SerializeField] private Toggle MotionBlurToggle;

    [Header("Sensitivity")]
    [SerializeField] private TMP_Text LabelSens;
    [SerializeField] private Slider Slider;
    [SerializeField] private int Sensitivity = 3;

    [Header("Texture Quality")]
    [SerializeField] private TMP_Dropdown Dropdown;
    [SerializeField] private int DropdownValue;

    private void Awake()
    {
        instance = this;

        Slider.value = PlayerPrefs.GetInt("Sensitivity");
        Dropdown.value = PlayerPrefs.GetInt("TextureQuality");
        AmbientOcclusionToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("AmbientOcclusion"));
        BloomToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("Bloom"));
        MotionBlurToggle.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("MotionBlur"));
    }

    public void SetSensitivity(float val)
    {
        Sensitivity = Convert.ToInt32(val);
        LabelSens.text = val.ToString();
        PlayerPrefs.SetInt("Sensitivity", Sensitivity);
    }

    public void SetTextureQuality(int val)
    {
        QualitySettings.SetQualityLevel(val);
        PlayerPrefs.SetInt("TextureQuality", val);
    }

    public void SetAmbientOcclusion(bool val)
    {
        Profile.TryGetSettings(out AmbientOcclusion);
        AmbientOcclusion.active = val;
        PlayerPrefs.SetInt("AmbientOcclusion", Convert.ToInt32(val));
    }
    public void SetBloom(bool val)
    {
        Profile.TryGetSettings(out Bloom);
        Bloom.active = val; 
        PlayerPrefs.SetInt("Bloom", Convert.ToInt32(val));
    }
    public void SetMotionBlur(bool val)
    {
        Profile.TryGetSettings(out MotionBlur);
        MotionBlur.active = val;
        PlayerPrefs.SetInt("MotionBlur", Convert.ToInt32(val));
    }

}

