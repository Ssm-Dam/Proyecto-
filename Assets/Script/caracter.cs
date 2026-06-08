using Unity.VisualScripting;
using UnityEngine;
public class caracter : MonoBehaviour
{
    [SerializeField]protected float vel; 
    protected Vector2 inputMove;
    [SerializeField]protected float  m_vida;
    protected float m_vidaActual;
    /// <summary>
    /// Salto con Lazer
    /// </summary>
    protected Rigidbody rb;
    [SerializeField]protected float fuerzaSalto;
    [SerializeField]protected Transform lasertag;
    protected void Start()
    {
        m_vidaActual = m_vida;
    }
    void TakeDamage(float damage)
    {
        m_vidaActual -= damage;
    }
    protected bool EstaEnSuelo()
    {
        RaycastHit hit;
        if (Physics.Raycast(lasertag.position, Vector3.down, out hit, 0.2f))
        {
            return hit.collider.CompareTag("Suelo");// True
        }
        return false;
    }
    public void DamagePlayer(float damage)
    {
        TakeDamage(damage);
    }
    public void Die()
    {
        if(m_vidaActual <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        
    }
    public void Move()
    {
        Vector3 direction = new Vector3(inputMove. x,0, inputMove.y);
        transform.Translate(direction*vel*Time.deltaTime);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(lasertag.position,lasertag.position + Vector3.down * 0.2f);

    }

}