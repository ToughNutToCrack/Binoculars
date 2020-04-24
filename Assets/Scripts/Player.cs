using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    public KeyCode toggleBinocular;
    [Space]
    public Binocular binocular;
    [Space]
    public float initialDistance = 10;
    public float minDistance = 30, maxDistance = 3;
    public float scrollSpeed = 20;
    [Space]
    public Volume volume;

    Camera mainCam;
    bool isBinocularModeOn;
    bool isBinocularActive = false;
    LensDistortion lensDist;

    void Start()
    {
        mainCam = GetComponent<Camera>();
        volume.profile.TryGet<LensDistortion>(out lensDist);
    }

    void Update()
    {
        if (Input.GetKeyUp(toggleBinocular))
        {
            isBinocularActive = !isBinocularActive;
            binocular.HandleState(isBinocularActive);
        }

        if (isBinocularModeOn)
        {
            var dist = Input.GetAxis("Mouse ScrollWheel");
            if (dist != 0)
                initialDistance += Time.deltaTime * (dist > 0 ? -scrollSpeed : scrollSpeed);
            initialDistance = Mathf.Clamp(initialDistance, maxDistance, minDistance);
            mainCam.fieldOfView = initialDistance;
        }
    }

    public void HandleZoom(bool wantZoom)
    {
        if (wantZoom)
        {
            mainCam.fieldOfView = initialDistance;
            isBinocularModeOn = true;
            lensDist.active = true;
        }
        else
        {
            mainCam.fieldOfView = 60;
            isBinocularModeOn = false;
            lensDist.active = false;
        }
    }
}
