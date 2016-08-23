namespace calaulator_core.scanner
{
    /// <summary>
    /// 整数
    /// </summary>
    public class Num : Token
    {
        public readonly int value;
        public Num(int value) : base(Tag.NUM)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return value.ToString();
        }
    }

}
