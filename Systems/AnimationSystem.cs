using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;

public class AnimationSystem
{
    private readonly Image _image;

    private Dictionary<PetState, List<BitmapImage>> _animations;
    private int _frame = 0;

    public AnimationSystem(Image image)
    {
        _image = image;

        _animations = new Dictionary<PetState, List<BitmapImage>>
        {
            { PetState.Idle, LoadFrames("Assets/idle") },
            { PetState.WalkingRight, LoadFrames("Assets/walkRight") },
            { PetState.WalkingLeft, LoadFrames("Assets/walkLeft") }
        };
    }

    public void Update(PetState state)
    {
        if (!_animations.ContainsKey(state)) return;

        var frames = _animations[state];
        _frame = (_frame + 1) % frames.Count;

        _image.Source = frames[_frame];
    }

    private List<BitmapImage> LoadFrames(string basePath)
    {
        var list = new List<BitmapImage>();

        int i = 1;
        while (true)
        {
            string path = $"pack://application:,,,/{basePath}_{i}.png";

            try
            {
                list.Add(new BitmapImage(new Uri(path)));
                Console.WriteLine($"Loaded: {path}");
                i++;
            }
            catch
            {
                break; // stop when no more frames exist
            }
        }

        return list;
    }
}