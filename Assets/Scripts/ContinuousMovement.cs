using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

public class ContinuousMovement : MonoBehaviour
{

    public float speed = 1f;
    public XRNode inputSource;
    private float gravity = -9.81f;
    public LayerMask groundMask;
    public float additionalHeight = 0.2f;
    private float fallingSpeed;
    private XROrigin rig;
    public Vector2 inputAxis;
    private CharacterController character;
    
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate() 
    {
        CapsuleFollowHeadset();

        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

        character.Move(direction * Time.fixedDeltaTime * speed);

        if (CheckIfGrounded()) 
        {
            fallingSpeed = 0;
        } 
        else 
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;
        }

        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);

    }

    public void CapsuleFollowHeadset() 
    {
        character.height = rig.Camera.transform.position.y + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.Camera.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height/2 + character.skinWidth, capsuleCenter.z);
    }

    public bool CheckIfGrounded() 
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;

        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundMask);

        return hasHit;
    }
}
