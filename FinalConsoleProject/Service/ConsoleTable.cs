namespace FinalConsoleProject.Service
{
    internal class ConsoleTable
    {
        private string v1;
        private string v2;
        private string v3;
        private string v4;
        private string v5;

        public ConsoleTable(string v1, string v2, string v3, string v4, string v5 )
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
        }

       

        internal void AddRow(string name, decimal price, Common.Enum.Categories categories, int number, int id)
        {
            throw new NotImplementedException();
        }
    }
}