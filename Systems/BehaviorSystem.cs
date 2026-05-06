using System;

public class BehaviorSystem
{
    private Random _rand = new Random();

    public PetState CurrentState { get; private set; } = PetState.Idle;

    public void Update()
    {
        // Random transitions
        if (_rand.NextDouble() < 0.01)
        {
            CurrentState = CurrentState switch
            {
                PetState.Idle => _rand.Next(2) == 0 ? PetState.WalkingLeft : PetState.WalkingRight,
                PetState.WalkingLeft => PetState.Idle,
                PetState.WalkingRight => PetState.Idle,
                _ => CurrentState // Default case to handle other states
            };
        }
    }
}
