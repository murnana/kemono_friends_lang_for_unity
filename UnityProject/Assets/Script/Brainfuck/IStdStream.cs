namespace Brainfuck
{
    public interface IStdStream
    {
        byte In();
        void Out(byte value);
    }
}