using app.Systems;
using System.Windows;

public class MovementSystem
{
    private readonly Window _window;

    AudioSystem audio = new AudioSystem();

    private double _x = 100;
    private double _y;
    private double _vx = 10;
    private double _vy = 3;
    private double gforce = 1.2;
    private double ground;

    public MovementSystem(Window window)
    {
        _window = window;
        double petHeight = 96; // NOT THE ACTUAL WINDOW HEIGHT, ADJUSTED TO LOOK BETTER ON SCREEN
        ground = SystemParameters.WorkArea.Bottom - petHeight;
        _y = 0;
        audio.InitializeSound("Assets/audio/sillycatgotthemMOVES.wav");
    }
    private PetState _previousState;

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
        _vy += gforce;
        _y += _vy;

        if (_y > ground)
        {
            _y = ground;
            _vy *= -0.2;
        }

        if (state != _previousState)
        {
            if (state == PetState.WalkingRight ||
                state == PetState.WalkingLeft)
            {
                audio.InitializeSound("Assets/audio/sillycatgotthemMOVES.wav");
                audio.Play();
            }
            else if (state == PetState.Idle)
            {
                audio.Stop();
            }
                _previousState = state;
        }

        return state;
    }
}