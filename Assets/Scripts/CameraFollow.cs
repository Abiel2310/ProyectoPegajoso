using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target a seguir")]
    public Transform target; // Asigna aquí tu jugador

    [Header("Configuración de la cámara")]
    public float smoothSpeed = 5f; // Velocidad de seguimiento (mayor = más rápido)
    public Vector3 offset = new Vector3(0, 0, -10); // Para mantener la cámara atrás

    void LateUpdate()
    {
        if (target == null) return;

        // Posición deseada
        Vector3 desiredPosition = target.position + offset;

        // Movimiento suavizado
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Actualiza la posición de la cámara
        transform.position = smoothedPosition;
    }
}

