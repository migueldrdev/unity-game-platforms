using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private List<CharacterController> pasajeros = new List<CharacterController>();
    private Vector3 ultimaPosicion;

    void Start()
    {
        ultimaPosicion = transform.position;
    }

    // Usamos FixedUpdate para sincronizarnos mejor con la física si hay problemas
    // Pero como tu plataforma usa Update, lo mantendremos en LateUpdate para ir justo después
    void LateUpdate()
    {
        Vector3 movimientoPlataforma = transform.position - ultimaPosicion;

        if (movimientoPlataforma != Vector3.zero && pasajeros.Count > 0)
        {
            foreach (CharacterController pasajero in pasajeros)
            {
                // TRUCO PRO: Usamos .Move() del CharacterController.
                // Esto permite que el jugador detecte colisiones y se mueva suavemente
                // sin "teletransportarse", eliminando el palpitar.
                pasajero.Move(movimientoPlataforma);
            }
        }

        ultimaPosicion = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController cc = other.GetComponent<CharacterController>();
            // Verificamos que no esté ya en la lista para evitar errores
            if (cc != null && !pasajeros.Contains(cc))
            {
                pasajeros.Add(cc);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null && pasajeros.Contains(cc))
            {
                pasajeros.Remove(cc);
            }
        }
    }
}