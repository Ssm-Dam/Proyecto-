using UnityEngine;
using UnityEngine.UI;
public class contador : MonoBehaviour
{
  public Text contadorTexto;
    public int Minutos;
    public float Segundos;
    public Color ColorAviso;
    public int MinutosLimite;

    public GameObject jugador;
    private bool desaparecio = false;

    private void Start()
    {
        Actualizarcontador();
    }

    private void Update()
    {
        Segundos += Time.deltaTime;

        if (Segundos >= 60)
        {
            Segundos = 0;
            Minutos += 1;
        }

        Actualizarcontador();

        if (Minutos >= MinutosLimite)
        {
            contadorTexto.color = ColorAviso;
        }

        if (Minutos >= 1)
        {
            jugador.SetActive(false);
        }
    }
    public void Actualizarcontador()
    {
        if (Segundos < 9.5f)
        {
            contadorTexto.text = Minutos.ToString() + ":0" + Segundos.ToString("f0");
        }
        else
        {
            contadorTexto.text = Minutos.ToString() + ":" + Segundos.ToString("f0");
        }
    }
}