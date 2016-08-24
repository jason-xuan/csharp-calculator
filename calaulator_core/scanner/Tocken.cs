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

        public Token(char v)
        {
            Tag = (Tag)v;
        }

        public Token(Tag t)
        {
            Tag = t;
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
