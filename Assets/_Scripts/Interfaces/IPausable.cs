namespace _Scripts.Interfaces
{
    public interface IPausable
    {
        public bool IsPausing { get;}
        
        void Pause();
        void Resume();
    }
}