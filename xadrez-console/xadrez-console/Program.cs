﻿using System;
using tabuleiro;
using xadrez;
using xadrez_console.tabuleiro;


namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

           try
            {
            PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {

                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida);


                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();


                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.turno);
                        Console.WriteLine("aguardando jogada: " + partida.jogadorAtual);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);   


                        partida.realizaJogada(origem, destino);

                    } 
                    catch (Exception e)
                    { 
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }


                Tela.imprimirTabuleiro(partida.tab);

            } catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}

