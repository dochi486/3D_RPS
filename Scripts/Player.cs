using System.Collections;
using TMPro;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Run,
    Shoot,
}

public class Character : MonoBehaviour
{
    public IEnumerator HitCo(float damage)
    {
        GameObject damageTextGoInResource = (GameObject)Resources.Load("DamageText");
        var pos = transform.position;
        pos.y -= 2;
        pos.z += 10;
        GameObject damageTextGo = Instantiate(damageTextGoInResource, pos, damageTextGoInResource.transform.rotation, transform);
        damageTextGo.GetComponent<TextMeshPro>().text = damage.ToString(); //�÷��̾��� power�� string���� ��ȯ�Ͽ� �ؽ�Ʈ�޽����ο� �����Ѵ�
        Destroy(damageTextGo, 2);
        yield return new WaitForSeconds(0.5f);
    }
}

public class Player : MonoBehaviour
{
    //TODO ����ī�޶� ���������忡�� ���� ���� ���
    //TODO �� �� �� ���� ����Ʈ
    //TODO �÷��̾� Ʈ������ ������ ���콺 ������ �������� �ٲٱ�
    //TODO ������ ������ ���� ������ �ְ� �װɷ� �Ѿ� ����ġ �����ϱ�

    Animator animator;
    public static Player instance;
    public Transform bulletFirePosition;
    public PlayerState playerState = PlayerState.Idle;
    Vector3 move;
    public float speed = 10;
    public float mouseSensitivity = 0.5f;
    public Transform cameraTr;
    public Transform leftHandWeapon;
    public Transform rightHandWeapon;
    public float shootDelaySeconds;
    public Transform laserFirePosition;
    public InventoryItem weapon1;
    public InventoryItem weapon2;

    private void Awake()
    {
        cameraTr = Camera.main.transform;
        instance = this;
    }
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            Move();
            GunFire();
            CameraRotate();
        }
        UIEnable();

        EquipItemInit();
        //InteractKey();
    }

    private void EquipItemInit()
    {
        if (UserData.Instance.itemData.data.equipMap.Count != 0)
        {
            if (UserData.Instance.itemData.data.equipMap.TryGetValue(1, out InventoryItem equippedWeapon1) == false)
            {
                Debug.LogWarning($"1�� ���Կ� ������ �������� �����ϴ�.");
            }
            weapon1 = equippedWeapon1;
            if (UserData.Instance.itemData.data.equipMap.TryGetValue(2, out InventoryItem equippedWeapon2) == false)
            {
                Debug.LogWarning($"2�� ���Կ� ������ �������� �����ϴ�.");
            }
            weapon2 = equippedWeapon2;
        }
    }

    private void InteractKey()
    {
        //if(Input.GetKeyDown(KeyCode.Mouse1))
    }

    private void UIEnable()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UIManager.Instance.InventoryUIInit();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UIManager.Instance.QuestUIInit();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            UIManager.Instance.SkillUIInit();
        }
    }

    private void CameraRotate()
    {
        float mouseMoveX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        float mouseMoveY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        var worldUp = cameraTr.InverseTransformDirection(Vector3.up);
        var rotation = cameraTr.rotation * Quaternion.AngleAxis(mouseMoveX, worldUp) *
            Quaternion.AngleAxis(mouseMoveY, Vector3.left);
        transform.eulerAngles = new Vector3(0f, rotation.eulerAngles.y, 0f);
        cameraTr.rotation = rotation;
    }


    private void GunFire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(GunFireCo());
        }
    }

    private IEnumerator GunFireCo()
    {
        animator.Play("Shoot");
        yield return new WaitForSeconds(shootDelaySeconds);
        Instantiate(Resources.Load("BulletPrefab"), bulletFirePosition.position, transform.rotation);
        Instantiate(Resources.Load("LaserPrefab"), laserFirePosition.position, transform.rotation);
    }



    private void Move()
    {
        move = Vector3.zero; //0���� �ʱ�ȭ ����� Ű �� �� ������ �� �� �� ���� ����ŭ�� �̵�

        if (Input.GetKey(KeyCode.W))
            move.z = 1;
        if (Input.GetKey(KeyCode.S))
            move.z = -1;
        if (Input.GetKey(KeyCode.A))
            move.x = -1;
        if (Input.GetKey(KeyCode.D))
            move.x = 1;


        if (move != Vector3.zero)
        {
            move.Normalize();
            transform.Translate(speed * move * Time.deltaTime, Space.Self);
            animator.Play("Run");
        }
    }
}
