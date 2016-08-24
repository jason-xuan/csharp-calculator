using System;

namespace calaulator_core.scanner
{
    /// <summary>
    /// 多于1个字符的Tocken
    /// </summary>
    public class Word : Token
    {
        private string lex = "";
        public string Lex
        {
            get
            {
                return lex;
            }
        }

        /// <summary>
        /// 常用的静态 Word 对象，不重复构建
        /// </summary>
        public static readonly Word
            and, or, eq, ne, le, ge, minus, True, False, sin, cos, tan, ln, log;
        static Word()
        {
            eq = new Word("==", Tag.EQ);
            ne = new Word("!=", Tag.NE);
            le = new Word("<=", Tag.LE);
            ge = new Word(">=", Tag.GE);
            True = new Word("True", Tag.TRUE);
            False = new Word("False", Tag.FALSE);
            sin  = new Word("sin", Tag.SIN);
            cos = new Word("cos", Tag.COS);
            tan = new Word("tan", Tag.TAN);
            ln = new Word("ln", Tag.LN);
            log = new Word("log", Tag.LOG);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="lex">
        /// Token内容
        /// </param>
        /// <param name="tag">
        /// Token类型
        /// </param>
        public Word(string lex, Tag tag) : base(tag)
        {
            this.lex = lex;
        }

        /// <summary>
        /// 取得该Token的内容
        /// </summary>
        /// <returns>
        /// 该Token内容
        /// </returns>
        public override string ToString()
        {
            return Lex;
        }

    }
}
