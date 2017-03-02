namespace Brainfuck
{
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// プログラムクラス
    /// Brainfuckで最も基本となるもの
    /// </summary>
    [System.Serializable]
    public sealed class Program
    {
        // 定数
        //----------------------------------------------------------------
        public const int MAX_MEMORY = 30000;

        // メンバ変数
        //----------------------------------------------------------------
        private byte[]       m_memory;
        private int          m_memoryAddress;
        private BRAIN_FUCK[] m_program;
        private int          m_programAddress;

        // メンバ関数
        //----------------------------------------------------------------
        /// <summary>
        /// プログラムの作成
        /// </summary>
        /// <param name="program"></param>
        public Program(List<BRAIN_FUCK> program)
        {
            m_program = program.ToArray();
            Reset();
        }

        /// <summary>
        /// ソースからコンパイル
        /// </summary>
        /// <param name="source">テキスト</param>
        /// <param name="compile">コンパイラの種類</param>
        public Program(string source, ICompiler compile)
        {
            var program = new List<BRAIN_FUCK>();
            string[] brain_fuck_str = {
                compile.nxt,
                compile.inc,
                compile.prv,
                compile.dec,
                compile.opn,
                compile.cls,
                compile.put,
                compile.get
            };

            // string一致検索
            for (int i = 0; i < source.Length;)
            {
                var before = i;
                for (int j = 0; j < brain_fuck_str.Length; ++j)
                {
                    if (brain_fuck_str[j].Length > source.Length - i) continue;
                    var index = source.IndexOf(brain_fuck_str[j], i, brain_fuck_str[j].Length);
                    if (index >= 0)
                    {
                        var add = (BRAIN_FUCK)j;
                        program.Add(add);
                        i = index + brain_fuck_str[j].Length;
                        break;
                    };
                }
                if (before == i) ++i;
            }
            m_program = program.ToArray();
            Reset();
        }

        /// <summary>
        /// 最初から
        /// </summary>
        public void Reset()
        {
            m_memory         = new byte[MAX_MEMORY];
            for (int i = 0; i < MAX_MEMORY; ++i)
            {
                m_memory[i] = new byte();
                m_memory[i] = 0;
            }
            m_memoryAddress  = 0;
            m_programAddress = 0;
        }

        /// <summary>
        /// 1メソッドごとに更新
        /// </summary>
        /// <param name="std"></param>
        public void Update(IStdStream std)
        {
            DoProgram(m_program[m_programAddress++], ref std);

            // 最後まで行ったら元に戻る
            if (m_programAddress >= m_program.Length) Reset();
        }

        /// <summary>
        /// 最後までプログラムを走らせる
        /// </summary>
        /// <param name="std"></param>
        public void Run(IStdStream std)
        {
            var beforeProgramAddress = m_programAddress;
            for (m_programAddress = 0 ; m_programAddress < m_program.Length; ++m_programAddress)
            {
                DoProgram(m_program[m_programAddress], ref std);
            }
            m_programAddress = beforeProgramAddress;
        }

        /// <summary>
        /// 指定されたプログラムを走らせる
        /// </summary>
        /// <param name="program"></param>
        /// <param name="std"></param>
        private void DoProgram(BRAIN_FUCK program, ref IStdStream std)
        {
            var comp = new KemonoFriendsLang.Compiler();
            switch (program)
            {
                case BRAIN_FUCK.NXT:
                    ++m_memoryAddress;
                    break;

                case BRAIN_FUCK.INC:
                    ++m_memory[m_memoryAddress];
                    break;

                case BRAIN_FUCK.PRV:
                    --m_memoryAddress;
                    break;

                case BRAIN_FUCK.DEC:
                    --m_memory[m_memoryAddress];
                    break;

                case BRAIN_FUCK.OPN:
                    m_programAddress = opn(m_programAddress);
                    break;

                case BRAIN_FUCK.CLS:
                    m_programAddress = cls(m_programAddress);
                    break;

                case BRAIN_FUCK.PUT:
                    std.Out(m_memory[m_memoryAddress]);
                    break;

                case BRAIN_FUCK.GET:
                    m_memory[m_memoryAddress] = std.In();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 条件を満たしたら
        /// ループ終了個所をさがす
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        private int opn(int start)
        {
            if (m_memory[m_memoryAddress] != 0) return start;

            int c = 0;
            for (int i = start + 1; i < m_program.Length; ++i)
            {
                if (m_program[i] == BRAIN_FUCK.OPN) ++c;
                if (m_program[i] == BRAIN_FUCK.CLS)
                {
                    if (c <= 0) return i;
                    --c;
                }
            }
            return -1;
        }

        /// <summary>
        /// 条件を満たしたら
        /// ループ開始視点をさぐる
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        private int cls(int start)
        {
            if (m_memory[m_memoryAddress] == 0) return start;

            for (int i = start - 1; i >= 0; --i)
            {
                if (m_program[i] == BRAIN_FUCK.OPN) return i;
            }
            return -1;
        }
    }
}