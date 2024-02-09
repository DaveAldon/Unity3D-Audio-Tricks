using UnityEngine;

public class AudioController : MonoBehaviour
{
  public void SetLinearVolume(float sliderValue)
  {
    float volume = sliderValue / 100f;
    AudioListener.volume = volume;
    Debug.Log($"Linear Volume: {volume}");
  }

  public void SetLogarithmicVolume(float sliderValue)
  {
    float db = -80 + (sliderValue * 0.8f);
    float volume = Mathf.Pow(10, db / 20);
    AudioListener.volume = volume;
    Debug.Log($"Logarithmic Volume: {volume}");
  }
}