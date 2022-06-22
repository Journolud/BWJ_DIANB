using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // set up variables
    private Rigidbody2D rb;
    public InputActions controls;

    // Weapon firing variables
    // Primary Weapon
    private delegate void PrimaryDelegate(string _weapon, Transform _firepoint, GameObject _projectile);
    PrimaryDelegate primaryFire;
    public string primaryShotType;
    public Transform primaryShotPoint;
    public GameObject primaryProjectile;
    public float primaryCoolDown;
    private float primaryTimer;

    // Start is called before the first frame update
    void Start()
    {
        // Set up controls
        controls = new InputActions();
        controls.Enable();
        SetAttackFunctions();
        controls.Player.Shoot.performed += _ => primaryFire("primary", primaryShotPoint, primaryProjectile);
        primaryTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        primaryTimer += Time.deltaTime;
    }

    private void SetAttackFunctions()
    {
        if (primaryShotType == "single")
        {
            primaryFire = FireSingle;
        }
        /*
        if (secondaryShotType == "single")
        {
            secondaryFire = FireSingle;
        }
        if (primaryShotType == "spread")
        {
            primaryFire = FireSpread;
        }
        if (secondaryShotType == "spread")
        {
            secondaryFire = FireSpread;
        }
        if (primaryShotType == "merge")
        {
            primaryFire = FireMerge;
        }
        if (secondaryShotType == "merge")
        {
            secondaryFire = FireMerge;
        }
        if (primaryShotType == "superSpread")
        {
            primaryFire = FireSuperSpread;
        }
        if (secondaryShotType == "superSpread")
        {
            secondaryFire = FireSuperSpread;
        }
        */
    }

    private void FireSingle(string _weapon, Transform _firepoint, GameObject _projectile)
    {
        Debug.Log("Pow Pow");
        if (_weapon == "primary")
        {
            if (primaryTimer < primaryCoolDown) { return; }
            else { primaryTimer = 0; }
        }
        /*
        if (_weapon == "secondary")
        {
            if (secondaryTimer < secondaryCoolDown) { return; }
            else { secondaryTimer = 0; }
        }
        */
        Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(controls.Player.Aim.ReadValue<Vector2>());
        Vector2 _direction = _mousePosition - _firepoint.position;
        _direction.Normalize();
        Debug.Log(_direction);
        GameObject _newProjectile = Instantiate(_projectile, _firepoint.position, _firepoint.rotation);
        _newProjectile.GetComponent<Rigidbody2D>().AddForce(_direction * 5, ForceMode2D.Impulse);
    }
}
