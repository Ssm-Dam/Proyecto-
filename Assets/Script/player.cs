using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : caracter
{
    private void Start()
    {
        m_vidaActual = m_vida;
        Debug.Log(m_vidaActual);
        rb=GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    public void FixedUpdate()
    {
        Move();
        Die();
        EstaEnSuelo();
    }
    public void OnMove(InputValue inputValue)
    {
        inputMove = inputValue.Get<Vector2>();
    }
    public void OnJump(InputValue value)
    {
        if(value.isPressed && EstaEnSuelo())
        {
            rb.velocity=new Vector3(rb.velocity.x, fuerzaSalto,rb.velocity.z);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Trampa"))
        {
            DamagePlayer(10);
        }
    }
    public new virtual void Move()
    {
        base.Move();
    }
    
}