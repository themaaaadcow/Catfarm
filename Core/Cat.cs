using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows;
using System;

public class Pet
{
    private readonly Image _image;
    private readonly Window _window;

    private readonly AnimationSystem _animation;
    private readonly MovementSystem _movement;
    private readonly BehaviorSystem _behavior;

    private readonly DispatcherTimer _timer;
    public MovementSystem Movement => _movement;

    public Pet(Image image, Window window)
    {
        _image = image;
        _window = window;

        _animation = new AnimationSystem(_image);
        _movement = new MovementSystem(_window);
        _behavior = new BehaviorSystem();

        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(33) // ~30 FPS
        };
        _timer.Tick += Update;
    }

    public void Start()
    {
        _timer.Start();
    }

    private void Update(object sender, EventArgs e)
    {
        _behavior.Update();
        _movement.Update(_behavior.CurrentState);
        _animation.Update(_behavior.CurrentState);
    }
}