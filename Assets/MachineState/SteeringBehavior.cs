using UnityEngine;

public class SteeringBehavior : MonoBehaviour
{
    public float Speed = 10f; // Velocidad m�xima del auto
    public float maxSpeed = 10f; // Velocidad m�xima del auto
    public float maxForce = 5f; // Fuerza m�xima de aceleraci�n
    public float slowingRadius = 5f; // Radio de desaceleraci�n
    public Vector3 velocity; // Velocidad actual del auto
    private const float stopThreshold = 0.1f; // Distancia para considerar el auto detenido
 

    private void Start()
    {
       
    }
    // Actualiza la posici�n del auto
    public void UpdatePosition( )
    {
       transform.position += velocity * Time.deltaTime;
       
    }

    // Aplica la fuerza de direcci�n y detiene el auto si est� cerca del destino
    public void ClampMagnitude(Vector3 steeringForce, Transform target)
    {
       
       
        if (IsNearTarget(target, stopThreshold))
        {
            Stop(); // Detiene completamente el auto
        }
        else
        {
            
            // Calcula la nueva velocidad con un l�mite de magnitud
            velocity = Vector3.ClampMagnitude(velocity + steeringForce * Time.deltaTime, Speed);
            
        }
        
    }

    // Calcula la fuerza de direcci�n hacia el objetivo (Seek)
    public Vector3 Seek(Transform target)
    {
        Vector3 desired = target.position - transform.position;
        desired.Normalize();
        desired *= maxSpeed;

        Vector3 steering = desired - velocity;
        return Vector3.ClampMagnitude(steering, maxForce);
    }

    // Calcula la fuerza de direcci�n alej�ndose del objetivo (Flee)
    public Vector3 Flee(Transform target)
    {
        Vector3 desired = transform.position - target.position;
        desired.Normalize();
        desired *= maxSpeed;

        Vector3 steering = desired - velocity;
        return Vector3.ClampMagnitude(steering, maxForce);
    }

    // Calcula la fuerza de direcci�n para llegar suavemente al objetivo (Arrive)
    public Vector3 Arrive(Transform target)
    {
        Vector3 desired = target.position - transform.position;
        float distance = desired.magnitude;

        if (distance < slowingRadius)
        {
            desired = desired.normalized * maxSpeed * (distance / slowingRadius);
        }
        else
        {
            desired = desired.normalized * maxSpeed;
        }

        Vector3 steering = desired - velocity;
        return Vector3.ClampMagnitude(steering, maxForce);
    }

    // M�todo para detener completamente el auto
    public void Stop()
    {
        velocity = Vector3.zero; // Resetea la velocidad
    }

    // Verifica si el auto est� cerca del destino
    public bool IsNearTarget(Transform target, float threshold = 0.1f)
    {
        return Vector3.Distance(transform.position, target.position) <= threshold;
    }
}
