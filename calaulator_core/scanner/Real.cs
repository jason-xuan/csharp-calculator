namespace calaulator_core.scanner
{
    /// <summary>
    /// 浮点数
    /// </summary>
    public class Real : Token
    {
        public readonly double value;
        public Real(double value) : base(Tag.REAL)
        {
            this.value = value;
        }
        public override string ToString()
        {
            return value.ToString();
        }
    }
}
