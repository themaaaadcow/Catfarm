using System.Windows;

public class MovementSystem
{
    private readonly Window _window;

    private double _x = 100;
    private double _y;
    private double _vx = 10;

    public MovementSystem(Window window)
    {
        _window = window;

        double screenBottom = SystemParameters.WorkArea.Bottom;
        double petHeight = 96; // NOT THE ACTUAL WINDOW HEIGHT, ADJUSTED TO LOOK BETTER ON SCREEN

        _y = screenBottom - petHeight;
    }

    public PetState Update(PetState state)
    {
        if (state == PetState.WalkingRight)
        {
            _x += _vx;
        }

        if (state == PetState.WalkingLeft)
        {
            _x -= _vx;
        }

        // Screen bounds
        if (_x < 0)
        {
            _x = 0;
            state = PetState.Idle;
            state = PetState.WalkingRight;
        }

        if (_x > SystemParameters.PrimaryScreenWidth - 128)
        {
            _x = SystemParameters.PrimaryScreenWidth - 128;
            state = PetState.Idle;
            state = PetState.WalkingLeft;
        }

        _window.Left = _x;
        _window.Top = _y;

        return state;
    }
}