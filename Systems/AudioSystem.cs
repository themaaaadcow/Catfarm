using System.Media;

namespace app.Systems
{
    public class AudioSystem
    {
        private SoundPlayer _player;

        public void InitializeSound(string audio)
        {
            _player = new SoundPlayer(audio);
            _player.Load();
        }

        public void Play()
        {
            _player?.Play();
        }
        public void Stop()
        {
            _player.Stop();
        }
    }
}