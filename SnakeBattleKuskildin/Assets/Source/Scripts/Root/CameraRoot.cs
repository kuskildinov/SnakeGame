using UnityEngine;

public class CameraRoot : CompositeRoot
{
    [SerializeField] private CameraMovment _cameraMovment;

    public override void Compose()
    {
        _cameraMovment.Initialize();
    }
}
