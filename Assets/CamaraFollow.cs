// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CamaraController : MonoBehaviour

// {
//     public Transform target; // Referencia al objeto que seguirá la cámara
//     public Vector3 offset;// Desplazamiento de la cámara con respecto al objetivo

//     void Start()
//     {
//         // Establece la posición inicial de la cámara
//         transform.position = target.position + offset;
//     }

//     void Update()
//     {
//         if (target != null)
//         {
//             // Calcula la posición a la que debe moverse la cámara
//             Vector3 targetPosition = target.position + offset;
            
//             // Interpolación suave para mover la cámara
//             transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
//         }
//     }
// }

