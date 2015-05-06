using System;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;

namespace DungeonShambles.Audio
{
    public class Audio
    {
        public int buffer;
        public int source;

        public Audio()
        {
            AL.GenSources(1, out source);
        }

        public void Init()
        {
            AL.Source(source, ALSourcei.Buffer, buffer);
        }

        public void Play()
        {
            AL.SourcePlay(source);
        }

        public void Pause()
        {
            AL.SourceStop(source);
        }

        public void Destory()
        {
            AL.DeleteSources(1, ref source);
            AL.DeleteBuffers(1, ref buffer);
        }
    }
}
