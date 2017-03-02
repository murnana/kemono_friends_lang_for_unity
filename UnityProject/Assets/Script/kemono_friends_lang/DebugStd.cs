namespace KemonoFriendsLang
{
    using System;
    using System.Text;
    using UnityEngine;

    class DebugStd : Brainfuck.IStdStream
    {
        public byte In()
        {
            return 0;
        }
        public void Out(byte value)
        {
            var encoding = Encoding.ASCII;
            var c = encoding.GetString(new byte[] { value });
            Debug.LogFormat(string.Format(@"Brainfuck:{0}({1})"
                , c
                , value
            ));
        }
    }
}
