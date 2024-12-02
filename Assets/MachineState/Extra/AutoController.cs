using UnityEngine;
using UnityEngine.AI;

//public class AutoController : MonoBehaviour
//{
//    public Transform targetNode; // Nodo hacia el que se dirige el auto
//    public float rotationSpeed = 5f; // Velocidad de rotaci�n


//    // M�todo para actualizar el nodo de destino
//    public void SetTargetNode(Transform newTargetNode)
//    {
//        targetNode = newTargetNode;
//    }

//    void Update()
//    {
//        if (targetNode != null)
//        {
//            RotateTowardsTarget();
//        }
//    }

//    // Rotar suavemente hacia el nodo de destino
//    private void RotateTowardsTarget()
//    {
//        Vector3 direction = targetNode.position - transform.position; // Direcci�n hacia el nodo
//        direction.y = 0; // Opcional: Mantener el auto nivelado en el eje Y

//        if (direction.magnitude > 0.01f) // Evita c�lculos innecesarios si ya est� alineado
//        {
//            Quaternion targetRotation = Quaternion.LookRotation(direction); // Rotaci�n deseada
//            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
//        }
//    }
//}
public class AutoController : MonoBehaviour
{
    public Transform targetNode; // Nodo hacia el que se dirige el auto
    public float rotationSpeed = 5f; // Velocidad de rotaci�n
    private NavMeshAgent agent; // Referencia al NavMeshAgent

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("AutoController: No se encontr� NavMeshAgent en el auto.");
        }
    }

    // M�todo para actualizar el nodo de destino
    public void SetTargetNode(Transform newTargetNode)
    {
        targetNode = newTargetNode;

        // Actualiza el destino del NavMeshAgent
        if (agent != null && targetNode != null)
        {
            agent.SetDestination(targetNode.position);
        }
    }

    void Update()
    {
        if (targetNode != null)
        {
            RotateTowardsTarget();
        }
    }

    // Rotar suavemente hacia el nodo de destino
    private void RotateTowardsTarget()
    {
        if (agent != null && !agent.isStopped)
        {
            Vector3 direction = targetNode.position - transform.position; // Direcci�n hacia el nodo
            direction.y = 0; // Mantener el auto nivelado en el eje Y

            if (direction.magnitude > 0.1f) // Evita c�lculos innecesarios si ya est� alineado
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction); // Rotaci�n deseada
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
}