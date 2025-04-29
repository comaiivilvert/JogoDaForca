namespace JogoDaForcaConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JogoDaForca jogo = new JogoDaForca();
            ExibeMenuInicial();
            Console.Write("Qual sua opção:");
            string grupoEscolhido = Console.ReadLine();
            jogo.IniciarJogo(grupoEscolhido);
            Console.ReadLine();
        }

        private static void ExibeMenuInicial()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Jogo da Forca");
            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("Escolha um tipo de palvras para jogar!");
            Console.WriteLine("1 - Animais");
            Console.WriteLine("2 - Frutas");
            
        }
    }
}
