namespace JogoDaForcaConsoleApp
{
    public class JogoDaForca
    {
        string palavraAleatoria="";
        int tentativasChutes;
        int quantidadeErros;
        bool jogadorEnforcou = false;
        bool jogadorAcertou = false;

        public void IniciarJogo(string opcao)
        {
           palavraAleatoria = GeradorPalavraAleatoria(opcao);
           ChutarLetra(); 
        }
        public string GeradorPalavraAleatoria(string grupoEscolhido)
        {
            string[] palavrasFrutas = {"ABACATE","ABACAXI","ACEROLA","ACAI","ARACA","ABACATE","BACABA","BACURI","BANANA","CAJA",
                                       "CAJU","CARAMBOLA","CUPUACU","GRAVIOLA","GOIABA","JABUTICABA","JENIPAPO","MACA","MANGABA","MANGA","MARACUJA","MURICI","PEQUI",
                                        "PITANGA","PITAYA","SAPOTI","TANGERINA","UMBU","UVA"};
            string[] palavrasAnimais = { "CACHORRO", "GATO", "PASSARO", "LEAO", "GIRAFA", "TARTARUGA", "ORNITORRINCO" };

            Random random = new Random();

            string palavraEscolhidaAleatoria = "";


            if (grupoEscolhido == "1")
            {
               return palavraEscolhidaAleatoria = palavrasAnimais[random.Next(palavrasAnimais.Length)];
            }
            else
            {
               return palavraEscolhidaAleatoria = palavrasFrutas[random.Next(palavrasFrutas.Length)];
            }
        }
        public void ChutarLetra()
        {
            char[] letrasEncontradas = new char[palavraAleatoria.Length];
            char[] chutesPassados = new char[200];
            

            for (int caractere = 0; caractere < letrasEncontradas.Length; caractere++)
                letrasEncontradas[caractere] = '_';


            do
            {
                DesenhaForca();
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Erros do jogador: " + quantidadeErros);
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Palavra escolhida: " + String.Join("", letrasEncontradas));
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Letras já digitadas:");
                for (int i = 0; i < tentativasChutes; i++)
                    Console.Write(chutesPassados[i] + (i < tentativasChutes - 1 ? ", " : "\n"));
                Console.WriteLine("----------------------------------------------");


                Console.Write("Digite uma letra: ");
                char chute = Console.ReadLine().ToUpper()[0];

                bool jaDigitou = false;

                for (int i = 0; i < palavraAleatoria.Length; i++)
                {
                    if (chutesPassados[i] == chute)
                    {
                        jaDigitou = true;
                        break;

                    }
                }
                if (jaDigitou)
                {
                    Console.WriteLine("Você já tentou essa letra!");
                    Console.ReadLine();
                }
                else
                {
                    chutesPassados[tentativasChutes] = chute;
                    tentativasChutes++;
                }


                bool letraFoiEncontrada = false;

                for (int contador = 0; contador < palavraAleatoria.Length; contador++)
                {
                    char letraAtual = palavraAleatoria[contador];

                    if (chute == letraAtual)
                    {
                        letrasEncontradas[contador] = letraAtual;
                        letraFoiEncontrada = true;

                    }

                }

                if (letraFoiEncontrada == false)
                    quantidadeErros++;

                string palavraEncontrada = String.Join("", letrasEncontradas);

                jogadorAcertou = palavraEncontrada == palavraAleatoria;
                jogadorEnforcou = quantidadeErros > 5;

                if (jogadorAcertou)
                {
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine($"Você acertou a palavra secreta {palavraAleatoria}, parabéns!");
                    Console.WriteLine("----------------------------------------------");
                }
                else if (jogadorEnforcou)
                {
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine($"Que azar! Você PERDEU! A palavra era {palavraAleatoria}. Tente novamente!");
                    Console.WriteLine("----------------------------------------------");
                }
            } while (jogadorEnforcou == false && jogadorAcertou == false);
        }

        private void DesenhaForca()
        {
            string cabecaDoBoneco = quantidadeErros >= 1 ? " o " : " ";
            string tronco = quantidadeErros >= 2 ? "x" : " ";
            string troncoBaixo = quantidadeErros >= 2 ? " x " : " ";
            string bracoEsquerdo = quantidadeErros >= 3 ? "/" : " ";
            string bracoDireito = quantidadeErros >= 4 ? @"\" : " ";
            string pernas = quantidadeErros >= 5 ? "/ \\" : " ";


            Console.Clear();
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Jogo da Forca");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(" ___________        ");
            Console.WriteLine(" |/        |        ");
            Console.WriteLine(" |        {0}       ", cabecaDoBoneco);
            Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdo, tronco, bracoDireito);
            Console.WriteLine(" |        {0}       ", troncoBaixo);
            Console.WriteLine(" |        {0}       ", pernas);
            Console.WriteLine(" |                  ");
            Console.WriteLine(" |                  ");
            Console.WriteLine("_|____              ");
        }
    }
}
