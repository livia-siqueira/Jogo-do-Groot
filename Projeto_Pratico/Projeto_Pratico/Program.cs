using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Projeto_Pratico
{
    class Program
    {
        //Metodo para Cabeçalho
        public void Cabeçalho()
        {
            Console.WriteLine("========================= JOGO DA VIAGEM DE ÔNIBUS =============================");
        }
        //Metodo MENU
        public int Opcao(string nome)
        {
            int opcao;
            Console.WriteLine("Seja bem-vindo (a) " + nome);
            Console.WriteLine("           Menu viagem de ônibus:" +
                "\n            1 - Jogar" +
                "\n            2 - Ajuda" +
                "\n            3 - Informações do Desenvolvedor" +
                "\n            5- Sair"
                );
            opcao = int.Parse(Console.ReadLine());
            return opcao;
        }
        // Método para Categoria
        public int Categoria()
        {
            int escolha;
            Console.WriteLine("========================= VAMOS JOGAR =============================");
            Console.WriteLine("            Escolha uma categoria:" +
                "\n           1- Filmes" +
                "\n           2- Séries" +
                "\n           3- Animais" +
                "\n           4- Profissões" +
                "\n           5- Paises"
                );
            escolha = int.Parse(Console.ReadLine());
            return escolha;
        }
        /* public void Ranking(string nome, int pontostotais, int j)
        {
            
        }*/
        // PROGRAMA PRINCIPAL
        static void Main(string[] args)
        {
            int OP, ESC, j = 0, u = 0, resp = 0, t = 0, r = 1, i;
            string nome;
            bool re = true;
            string[] cate = new string[99];
            string linhas, linhas2;
            string letra, letra2;
            char l1, l2;
            string[] dicas = new string[99];
            Random aleatorio = new Random();
            using (StreamReader listas = new StreamReader(@"J:\Livia\JOGO_DO_GROOT_LIVIA\lista_lpr.txt"))
            {
                while ((linhas2 = listas.ReadLine()) != null)
                {
                    for (int k = 0; k < 99; k++)
                    {
                        cate[k] = listas.ReadLine();
                    }
                }
            }
            using (StreamReader listas2 = new StreamReader(@"J:\Livia\JOGO_DO_GROOT_LIVIA\dicas_lpr.txt"))
            {
                while ((linhas = listas2.ReadLine()) != null)
                {
                    for (int k = 0; k < 99; k++)
                    {
                        dicas[k] = listas2.ReadLine();
                    }
                }
            }
            Program p = new Program();
            do
            {
                p.Cabeçalho();
                Console.WriteLine("Olá jogador! \nEntre com o seu nome: ");
                j++;
                nome = Console.ReadLine();
                Console.Clear();
                do
                {
                    p.Cabeçalho();
                    OP = p.Opcao(nome);
                    Console.Clear();
                    p.Cabeçalho();
                    switch (OP)
                    {
                        case 1:
                            do
                            {
                                int n = 0;
                                int c_palavratoda = 0;
                                int cont_espaco = 0, erros = 0, pontostotais = 0, p_erros = 0, pontos = 0;
                                string palavra = string.Empty;



                                n = 0;
                                ESC = p.Categoria();
                                Console.Clear();
                                switch (ESC)
                                {
                                    case 1:
                                        Console.WriteLine("               Filmes         ");
                                        t = aleatorio.Next(0, 19);
                                        break;
                                    case 2:
                                        Console.WriteLine("               Séries         ");
                                        t = aleatorio.Next(20, 39);
                                        break;
                                    case 3:
                                        Console.WriteLine("               Animais         ");
                                        t = aleatorio.Next(40, 59);
                                        break;
                                    case 4:
                                        Console.WriteLine("               Profissões         ");
                                        t = aleatorio.Next(60, 79);
                                        break;
                                    case 5:
                                        Console.WriteLine("               Países         ");
                                        t = aleatorio.Next(80, 99);
                                        break;
                                }

                                for (int x = 0; x < cate[t].Length; x++)
                                {
                                    if (cate[t][x] == ' ')
                                    {
                                        palavra = palavra + "  ";
                                        cont_espaco++;
                                    }
                                    else
                                    {
                                        palavra = palavra + "_ ";
                                    }
                                }
                                Char[] letras = new char[cate[t].Length + 3];
                                do
                                {
                                    if (re == false)
                                    {
                                        re = true;
                                    }
                                    Console.Clear();
                                    p.Cabeçalho();
                                    u = 1;
                                    Stopwatch tempo = new Stopwatch();
                                    tempo.Start();
                                    Console.WriteLine("             Dica: " + dicas[t]);
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("                   " + palavra);
                                    Console.WriteLine("Entre com uma letra: ");
                                    letra = Console.ReadLine().ToUpper();
                                    l1 = Convert.ToChar(letra);
                                    letra2 = letra.ToLower();
                                    l2 = Convert.ToChar(letra2);
                                    if (letras.Contains(l1))
                                    {
                                        Console.WriteLine("Essa letra já foi digitada   \nAperte qualquer tecla para continuar");
                                        Console.ReadKey();
                                        re = false;

                                    }
                                    if (re == true)
                                    {
                                        if (palavra.Contains("_"))
                                        {

                                            for (i = 0; i < cate[t].Length; i++)
                                            {

                                                if ((cate[t][i] == l1) || (cate[t][i] == l2))
                                                {

                                                    string M_AUXILIAR = palavra.Substring(0, i * 2);
                                                    M_AUXILIAR += l1;
                                                    M_AUXILIAR += palavra.Substring((i * 2) + 1, palavra.Length - (i * 2) - 1);
                                                    palavra = M_AUXILIAR;
                                                    u = 2;
                                                    c_palavratoda++;

                                                }

                                            }
                                            if ((u == 2))
                                            {
                                                Console.WriteLine("UAU, LETRA ENCONTRADA :) \nAperte qualquer tecla para continuar");
                                                Console.ReadKey();
                                                Console.Clear();
                                                pontos++;

                                            }
                                            else
                                            {


                                                Console.WriteLine("QUE PENA, LETRA NÃO ENCONTRADA :/ \nAperte qualquer tecla para continuar");
                                                p_erros += 3;
                                                erros++;
                                                Console.ReadKey();
                                                Console.Clear();

                                            }
                                            letras[n] = l1;
                                            n++;
                                        }
                                        p.Cabeçalho();
                                        tempo.Stop();
                                        TimeSpan ts = tempo.Elapsed;
                                        if ((c_palavratoda) == (cate[t].Length) || (c_palavratoda + cont_espaco) == cate[t].Length)
                                        {

                                            Console.WriteLine("MUITO BEM, " + nome + "! NOSSA PALAVRA ERA EXATAMENTE " + "'" + cate[t] + "'" + "\nCONFIRA COMO VOCÊ SE SAIU NA PARTIDA: ");
                                            pontostotais = pontos - p_erros;
                                            Console.WriteLine();
                                            Console.WriteLine("          \nAcertos: {0} \nErros: {1}", pontos, p_erros);
                                            Console.WriteLine("PONTOS CONQUISTADOS NA PARTIDA: " + pontostotais);
                                            string tempo_jogo = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                            ts.Hours, ts.Minutes, ts.Seconds,
                                            ts.Milliseconds / 10);
                                            Console.WriteLine("Tempo para descoberta da palavra " + tempo_jogo);
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            break;
                                        }

                                    }
                                } while (erros < 3);
                                if (erros >= 3)
                                {
                                    Console.Clear();
                                    Console.WriteLine("A palavra gerada era: " + cate[t]);
                                    Console.WriteLine("Não foi dessa vez,  " + nome + " não desista :) ");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                }
                                Console.WriteLine("Deseja jogar: \n1- Sim \n3-Sair do jogo");
                                r = int.Parse(Console.ReadLine());
                                Console.Clear();
                                if ((r == 3))
                                {
                                    OP = 5;
                                }

                            } while (r == 1);
                            break;
                        case 2:
                            Console.Clear();
                            p.Cabeçalho();
                            Console.WriteLine("                         - APRENDA A JOGAR -        ");
                            Console.WriteLine(
                                "\n- A cada letra correta será somado 1 ponto." +
                                "\n- A cada letra errada será subtraido 3 pontos." +
                                "\n- Você deve escolher uma categoria." +
                                "\n- Escolha uma letra, caso ela exista na palavra gerada da Categoria X, será apresentada." +
                                "\n- Seu objetivo é descobrir as letras pertencentes a palavra, e você só poderá errar três vezes."
                                );
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Voltar:  \n1-Sim \n2-Não");
                            resp = int.Parse(Console.ReadLine());
                            Console.Clear();
                            if (resp == 2)
                            {
                                OP = 5;

                            }
                            break;
                        case 3:
                             Console.WriteLine();
                                Console.WriteLine("Informações do Desenvolvedor: " +
                                    "\n Livia Siqueira" +
                                    "\n 16 anos" +
                                    "\n INST. FED. Campus Campos do Jordão"
                                    );
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Voltar: \n1-Sim \n2-Não");
                                resp = int.Parse(Console.ReadLine());
                                Console.Clear();
                            if (resp==2)
                            {
                                OP = 5;
                            }
                            break;
                        case 4:

                            break;
                    }
                } while (OP != 5);
                p.Cabeçalho();
                Console.WriteLine("Deseja entrar com outro jogador? \n1-Sim \n2-Não");
                resp = int.Parse(Console.ReadLine());
                Console.Clear();
            } while (resp == 1);

            Console.WriteLine("Obrigada por jogar nosso jogo \nEsperamos que tenha gostado :)");
            Console.ReadKey();
        }
    }
}
    

