using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public GameObject imageOn;
    public GameObject imageOff;

    public Slider slider;
    public AudioMixer AudioMixer;

    public string nameGroup;

    // Start is called before the first frame update
    void Start()
    {
        AudioMixer.GetFloat(nameGroup, out float value);
        slider.value = value+80;
        UpdateSlider();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateSlider()
    {
        var value = slider.value-80;

        imageOn.SetActive(value != -80);
        imageOff.SetActive(value == -80);

        AudioMixer.SetFloat(nameGroup, value);
    }
}