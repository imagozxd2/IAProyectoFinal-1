using UnityEngine;

public class Idle : StateBase
{
    private AutoSensor autoSensor; // Referencia al sensor de detecci�n

    void Awake()
    {
        this.LoadComponent();
    }

    public override void LoadComponent()
    {
        stateType = StateType.Idle;
        base.LoadComponent();
    }

    public override void Enter()
    {
        base.Enter();

        // Obtiene el sensor de detecci�n
        autoSensor = GetComponent<AutoSensor>();
        if (autoSensor == null)
        {
            Debug.LogError("Idle Enter: No se encontr� el AutoSensor en el auto.");
        }

        // Detiene el auto
        SteeringBehavior steering = GetComponent<SteeringBehavior>();
        if (steering != null)
        {
            steering.Stop();
        }

        Debug.Log("Idle Enter: El auto est� detenido.");
    }

    public override void Execute()
    {
        base.Execute();

        // Si ya no hay un obst�culo, cambiar al estado Driving
        if (autoSensor != null && !autoSensor.IsObstacleDetected)
        {
            _MachineState.ActiveState(StateType.Driving);
        }
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Idle Exit: Sali� del estado Idle.");
    }
}
