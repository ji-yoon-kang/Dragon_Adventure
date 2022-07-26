using UnityEngine;

public class SwingArm : MonoBehaviour
{
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject ForwardDirection;
    public GameObject CenterEyeCamera;

    private Vector3 PositonPreviousFrameLeftHand;
    private Vector3 PositonPreviousFrameRightHand;
    private Vector3 PlayerPositionPreviousFrame;
    private Vector3 PlayerPositionThisFrame;
    private Vector3 PositionThisFrameLeftHand;
    private Vector3 PositionThisFrameRightHand;

    public float Speed = 50;
    private float HandSpeed;
    // 용에 탑승 했을 때
    // 좌우 모든 트리거를 누르고
    // 위에서 아래로 채찍질을 하면 날아 가는 걸로
    // 조종은 thumbstick으로 일단 구현하고 controller 각도로 방향조절 하는 것으로 바꾸기
    // 착지
    // 좌우 트리거 
    // Start is called before the first frame update
    void Start()
    {
        PlayerPositionPreviousFrame = transform.position;
        PositonPreviousFrameLeftHand = LeftHand.transform.position;
        PositonPreviousFrameRightHand = RightHand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float yRotation = CenterEyeCamera.transform.eulerAngles.y;
        ForwardDirection.transform.eulerAngles = new Vector3(0, yRotation, 0);

        PositionThisFrameLeftHand = LeftHand.transform.position;
        PositionThisFrameRightHand = RightHand.transform.position;

        PlayerPositionThisFrame = transform.position;

        var playerDistanceMoved = Vector3.Distance(PlayerPositionThisFrame,
            PlayerPositionPreviousFrame);
        var leftHandDistanceMoved = Vector3.Distance(PositonPreviousFrameLeftHand,
            PositionThisFrameLeftHand);
        var rightHandDistanceMoved = Vector3.Distance(PositonPreviousFrameRightHand,
            PositionThisFrameRightHand);

        HandSpeed = ((leftHandDistanceMoved - playerDistanceMoved) +
            (rightHandDistanceMoved - playerDistanceMoved));

        if (Time.timeSinceLevelLoad > 1f)
        {
            transform.position += ForwardDirection.transform.forward *
                HandSpeed * Speed * Time.deltaTime;
        }

        PositonPreviousFrameLeftHand = PositionThisFrameLeftHand;
        PositonPreviousFrameRightHand = PositionThisFrameRightHand;

        PlayerPositionPreviousFrame = PlayerPositionThisFrame;

    }
}
