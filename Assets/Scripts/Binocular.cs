using UnityEngine;
using UnityEngine.Playables;

public class Binocular : MonoBehaviour
{
    public PlayableDirector directorOn;
    public PlayableDirector directorOff;
    bool isPlaying;

    public void HandleState(bool wantActive)
    {
        if (isPlaying)
            return;

        isPlaying = true;

        if (wantActive)
        {
            directorOff.Stop();
            directorOn.Play();
        }
        else
        {
            directorOn.Stop();
            directorOff.Play();
        }
    }

    public void HoldMoment()
    {
        isPlaying = false;
    }
}
