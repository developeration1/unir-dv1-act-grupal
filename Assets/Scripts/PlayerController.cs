using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] SpriteRenderer shotSprite;

    PlayerInputActions input;

    Vector2 mousePosition;

    float shotShowRate = .3f;
    float nextShotShow = 0;

    GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        shotSprite.enabled = false;

        // Objeto del Script generado a partir del Objeto del nuevo sistema de Input
        input = new PlayerInputActions();
        input.Player.Aim.Enable();
        input.Player.Fire.Enable();
        input.Player.Fire.performed += _ => Fire();
    }

    void Update()
    {
        // Obtener el valor de la posición del Mouse
        mousePosition = input.Player.Aim.ReadValue<Vector2>();

        // Rotación del jugador
        Vector2 dir = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rot;

        // Ver el disparo del jugador
        shotSprite.enabled = nextShotShow > Time.realtimeSinceStartup;
    }

    // Disparo del jugador
    void Fire()
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null && hit.collider.CompareTag("Fruit"))
        {
            hit.transform.gameObject.GetComponent<FruitManager>().ShotByPlayer();
        }

        if(nextShotShow < Time.realtimeSinceStartup)
        {
            nextShotShow = Time.realtimeSinceStartup + shotShowRate;
        }
    }
}
