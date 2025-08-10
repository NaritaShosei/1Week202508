using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioData[] AudioDatas;
    [SerializeField] private AudioSource _bgmSource;
    [SerializeField] private AudioSource _seSource;

    public void PlayBGM(string key)
    {
        var data = AudioDatas.First(x => x.Name == key);

        if (data == null) { Debug.LogWarning("未登録のKeyです"); return; }

        BGMStop();

        _bgmSource.clip = data.Clip;
        _bgmSource.volume = data.Volume;
        _bgmSource.loop = true;

        _bgmSource.Play();
    }

    public void PlaySE(string key)
    {
        var data = AudioDatas.First(x => x.Name == key);

        if (data == null) { Debug.LogWarning("未登録のKeyです"); return; }

        _seSource.PlayOneShot(data.Clip, data.Volume);
    }

    public void BGMStop()
    {
        _bgmSource.Stop();
    }

    public bool IsBGMPlaying()
    {
        return _bgmSource.isPlaying;
    }

}
[System.Serializable]
public class AudioData
{
    public string Name;
    public AudioClip Clip;
    [Range(0f, 1f)]
    public float Volume = 0.5f;
}