namespace calaulator_core.scanner
{
    /// <summary>
    /// 浮点数
    /// </summary>
    public class Real : Token
    {
        private readonly double value;
        public Real(double value) : base(Tag.REAL)
        {
            this.value = value;
        }
        public double Value
        {
            get
            {
                return value;
            }
        }
        public override string ToString()
        {
            return value.ToString();
        }
    }
}
