using app.Systems;
using System;
using System.Windows;

public class MovementSystem
{
    private readonly Window _window;

    AudioSystem audio = new AudioSystem();

    private double _x;
    private double _y;
    private double _vx = 10;
    private double _vy = 3;
    private double gforce = 1.2;
    private double ground;
    public bool IsDragging = false;

    private Point _dragOffset;

    private double _throwVX;
    private double _physicsVX;
    private double _throwVY;

    public MovementSystem(Window window)
    {
        _window = window;
        double petHeight = 96; // NOT THE ACTUAL WINDOW HEIGHT, ADJUSTED TO LOOK BETTER ON SCREEN
        ground = SystemParameters.WorkArea.Bottom - petHeight;
        _x = 500;
        _y = ground;
        audio.InitializeSound("Assets/audio/sillycatgotthemMOVES.wav");
    }
    private PetState _previousState;

    public PetState Update(PetState state)
    {
        if (IsDragging == true)
        {
            return state;
        }

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
            state = PetState.WalkingRight;
        }

        if (_x > SystemParameters.PrimaryScreenWidth - 128)
        {
            _x = SystemParameters.PrimaryScreenWidth - 128;
            state = PetState.WalkingLeft;
        }

        _window.Left = _x;
        _window.Top = _y;
        _vy += gforce;
        _x += _physicsVX;
        _y += _vy;

        if (_y > ground)
        {
            _y = ground;
            _vy *= -0.6;

            if (Math.Abs(_vy) < 1)
            {
                _vy = 0;
            }
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

    public void StartDrag(Point mousePosition)
    {
        _dragOffset = mousePosition;

        _throwVX = 0;
        _throwVY = 0;
    }

    public void Drag(Point mouseScreen)
    {
        double newX = mouseScreen.X - _dragOffset.X;
        double newY = mouseScreen.Y - _dragOffset.Y;

        // Calculate throw velocity
        _throwVX = newX - _x;
        _throwVY = newY - _y;

        _x = newX;
        _y = newY;

        _window.Left = _x;
        _window.Top = _y;
    }

    public void EndDrag()
    {
        IsDragging = false;

        _physicsVX = _throwVX;
        _vy = _throwVY;
    }
}