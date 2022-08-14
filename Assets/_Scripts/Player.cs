using System;
using UnityEngine;

public enum Power
{
    None,
    FireFlower
}

public class Player : MonoBehaviour
{

    [Header("Player")]
    [SerializeField] CameraController cameraController;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameButton smashButton;
    [SerializeField] GameObject handObject;

    [SerializeField] WeaponConfig defaultWeapon = null;
    [SerializeField] Transform handTransform = null;
    [SerializeField] SpriteRenderer playerBody = null;

    [Header("Sounds")]
    [SerializeField] GameObject stepsSounds;
    [SerializeField] GameObject pickupSounds;

    WeaponConfig currentWeaponConfig;
    Plants currentWeapon;

    Vector3 offsetToCamera;
    const float acceleration = 3f;
    float velocity;
    const float MaxSpeed = 4f;
    Vector3 originalHandLocalPos;

    public Plants NearbyPlant { get; internal set; }
    Power activePower = Power.None;
    bool isPowerActive = false;

    private void Awake()
    {
        currentWeaponConfig = defaultWeapon;
        offsetToCamera = transform.position - cameraController.transform.position;
        smashButton.OnButtonDown += OnSmashButtonDown;
        originalHandLocalPos = handObject.transform.localPosition;
    }

    private void Start()
    {
        AttachWeapon(currentWeaponConfig);
        currentWeapon = SetupDefaultWeapon();

        ScoreKeeper.Reset();
    }

    private Plants SetupDefaultWeapon()
    {
        return AttachWeapon(defaultWeapon);
    }

    public void EquipWeapon(WeaponConfig weapon)
    {
        currentWeaponConfig = weapon;
        currentWeapon = AttachWeapon(weapon);
    }

    private Plants AttachWeapon(WeaponConfig weapon)
    {
        Animator animator = handTransform.GetComponent<Animator>();

        return weapon.Spawn(handTransform, animator, playerBody);
    }

    private void OnSmashButtonDown(bool isDown)
    {
        if (!isDown)
        {
            return;
        }

        if (!isPowerActive)
        {

            handObject.transform.localPosition = originalHandLocalPos + Vector3.down * 1;
        }

        if (NearbyPlant)
        {
            EquipWeapon(NearbyPlant.PickUp());
            NearbyPlant.gameObject.SetActive(false);
            NearbyPlant = null;
            isPowerActive = true;
            pickupSounds.GetComponent<AudioSource>().Play();
        }
        else
        {
            print("activando poder");
            handTransform.GetComponent<Animator>().SetTrigger("Attack");
            AudioSource weaponSound =handTransform.GetComponentInChildren<AudioSource>();
            if(weaponSound == null) return;
            weaponSound.Play();
        }
    }



    private void Update()
    {
        float direction = cameraController.transform.position.x + offsetToCamera.x - transform.position.x;

        if (Mathf.Abs(direction) > 0.01f)
        {
            velocity += Mathf.Sign(direction) * acceleration * Time.deltaTime;
            velocity = Mathf.Clamp(velocity, -MaxSpeed, MaxSpeed);
            transform.position += Vector3.right * velocity * Time.deltaTime;
            float bounce = Mathf.Abs(Mathf.Sin(Time.time * 10f)) * 0.1f;
            spriteRenderer.transform.localPosition = Vector3.up * bounce;
            stepsSounds.SetActive(true);
        }
        else
        {
            velocity *= 0.5f;
            spriteRenderer.transform.localPosition = Vector3.zero;
            stepsSounds.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSmashButtonDown(true);
        }

        handObject.transform.localPosition = Vector3.Lerp(handObject.transform.localPosition, originalHandLocalPos, 5f * Time.deltaTime);
    }

    internal void OnWeaponHit(Enemy enemy)
    {
        enemy.Damage(1);
    }

}
