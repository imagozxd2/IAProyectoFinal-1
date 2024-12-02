using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMove : StateBase
{
    protected SteeringBehavior _SteeringBehavior;
    public Transform place; // Destino del movimiento

    public override void LoadComponent()
    {
        // Obt�n el componente SteeringBehavior
        //_SteeringBehavior = GetComponent<SteeringBehavior>();
        //if (_SteeringBehavior == null)
        //{
        //    Debug.LogError("StateMove: No se encontr� SteeringBehavior en el objeto.");
        //}
        base.LoadComponent();
    }

    public virtual void MoveToPlace()
    {
        //// Validaci�n: verifica que el destino est� asignado
        //if (place == null)
        //{
        //    Debug.LogWarning("StateMove: El destino (place) no est� asignado.");
        //    return;
        //}

        //// Calcula la fuerza de direcci�n hacia el destino
        //Vector3 steeringForce = _SteeringBehavior.Arrive(place);

        //// Aplica la fuerza y ajusta la magnitud, deteni�ndose si est� cerca
        //_SteeringBehavior.ClampMagnitude(steeringForce, place);

        //// Actualiza la posici�n del objeto
        //_SteeringBehavior.UpdatePosition();

        //// Detiene el movimiento si est� cerca del destino
        //if (_SteeringBehavior.IsNearTarget(place, 0.1f))
        //{
        //    _SteeringBehavior.Stop(); // Detiene la velocidad
        //}
    }
}
