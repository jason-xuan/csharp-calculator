namespace calaulator_core.scanner
{
    /// <summary>
    /// 仅有一个字符的Tocken
    /// </summary>
    public class Token
    {
        public Tag Tag
        {
            get;
        }

        public Token(Tag t)
        {
            Tag = t;
        }

        /// <summary>
        /// 重载函数，调用时不需要进行类型转换
        /// </summary>
        /// <param name="v">
        /// Token内容
        /// </param>
        public Token(char v)
        {
            Tag = (Tag)v;
        }

        public override string ToString()
        {
            if ((int)Tag < 256)
            {
                char t = (char)Tag;
                return t.ToString();
            }
            return Tag.ToString();
        }
    }

}
