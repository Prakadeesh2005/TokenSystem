
namespace TokenSystem
{
    public class Patient
    {
        public int TokenNumber { get; set; }
        public string Name { get; set; } = "";

        public string FormattedToken
        {
            get { return TokenNumber.ToString("D3"); }
        }
        public string DisplayTokenNumber
        {
            get { return TokenNumber.ToString("D3"); }
        }
    }
}
