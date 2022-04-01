using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta_Corrente.ConsoleApp
{
    public class Conta
    {
        public int numeroConta;
        public double saldo;
        public bool tipoConta;
        public double limite;
        public Movimentacao[] movimentacoesRealizadas;


        public double Saldo()
        {
            return saldo;

        }

        public void Sacar(double quantidade)
        { 
            
            if (quantidade < saldo)
            {
            Movimentacao novamovimentacao = new Movimentacao();

            int idConta = registroMovimentação();
            novamovimentacao.valor = quantidade;
            novamovimentacao.tipoMovimentacao = "Debito";

           
                double novoSaldo = this.saldo - quantidade;
                this.saldo = novoSaldo;

               ApresentarMensagem("Saque realizada com sucesso!\n",ConsoleColor.Green);
             movimentacoesRealizadas[idConta] = novamovimentacao;
            }
            else ApresentarMensagem("Não foi possivel realizar o saque. Saldo insuficiente!\n", ConsoleColor.Red);
           
           
        }

        public void Depositar(double quantidade)
        {
            int idConta = registroMovimentação();
            Movimentacao novamovimentacao = new Movimentacao();
            novamovimentacao.valor  = quantidade;
            novamovimentacao.tipoMovimentacao = "Credito";

            this.saldo += quantidade;

            movimentacoesRealizadas[idConta] = novamovimentacao;
            ApresentarMensagem("Deposito realizado com sucesso!",ConsoleColor.Green);
        }

        public void transferir(Conta destino, double valor)
        {
            if (valor < saldo)
            {
                int idConta = registroMovimentação();
            Movimentacao novamovimentacao = new Movimentacao();
            novamovimentacao.valor = valor;
            novamovimentacao.tipoMovimentacao = "Tranferencia";
                this.saldo -= valor;
                destino.saldo += valor;
                
                movimentacoesRealizadas[idConta] = novamovimentacao;
                ApresentarMensagem("Tranferencia Realizada com Sucesso!", ConsoleColor.Green);
            }
            
            else ApresentarMensagem("Não foi possivel realizar a Tranferencia. Saldo insuficiente!", ConsoleColor.Red);

            
        }


        public void Extrato()
        {
            string Conta;
            if (this.tipoConta == true)
                Conta = "Especial";

            else
           Conta = "Normal";

            Console.WriteLine("=============================== EXTRATO ===============================");
            Console.WriteLine("\nN° Conta: "+this.numeroConta+"\nSaldo da conta: "+this.saldo+
                "\nTipo de conta:"+Conta+"\nLimite da Conta: "+this.limite);

            Console.WriteLine("\n===================== MOVIMENTAÇÕES DA CONTA =====================\n");
           
            for (int i = 0; i < movimentacoesRealizadas.Length; i++)
            {
                if (movimentacoesRealizadas[i]!=null)
                {
                   if(movimentacoesRealizadas[i].tipoMovimentacao == "Debito")
                    {
                        ApresentarMensagem("\nSaque realizado da conta " + numeroConta +" com o valor de "+ movimentacoesRealizadas[i].valor,ConsoleColor.Red);
                    }
                   else if (movimentacoesRealizadas[i].tipoMovimentacao == "Credito")
                    {
                        ApresentarMensagem("\nDeposito efetuado na conta " + numeroConta + " com o valor de " + movimentacoesRealizadas[i].valor, ConsoleColor.Green);

                    }
                    else if (movimentacoesRealizadas[i].tipoMovimentacao == "Tranferencia")
                    {

                        ApresentarMensagem("\nTransferencia efetuada da conta " + numeroConta + " com o valor de " + movimentacoesRealizadas[i].valor, ConsoleColor.Red);


                    }
                }

            }
            Console.WriteLine("\n=====================================================================\n");
        }
        public int registroMovimentação()
        {
            int idConta=-1;
            for (int i = 0; i < movimentacoesRealizadas.Length; i++)
            {
                if (movimentacoesRealizadas[i] == null)
                    idConta = i;

            }
            return idConta;
        }
        public void EmitirSaldo()
        {
            Console.WriteLine("\n===================== SALDO =====================");
            Console.WriteLine("\nN° Conta: "+this.numeroConta+"\nSaldo Atual: "+saldo);
            Console.WriteLine("\n===============================================\n");
        }
        public void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine(mensagem);

            Console.ResetColor();
        }
    }
}
