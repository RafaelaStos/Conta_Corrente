using System;

namespace Conta_Corrente.ConsoleApp
{
    internal class TesteContaCorrente
    {
        static void Main(string[] args)
        {
            Conta conta1 = new Conta();

            conta1.numeroConta = 12;
            conta1.saldo = 1000;
            conta1.limite = 0;
            conta1.tipoConta = false;
            conta1.movimentacoesRealizadas = new Movimentacao[10];

            conta1.Sacar(200);
            conta1.Depositar(300);
            conta1.Depositar(500);
            conta1.Sacar(200);

           Conta  conta2 = new Conta();
          conta2.numeroConta = 1235;
          conta2.saldo = 1000;
          conta2.tipoConta = true;
          conta2.limite = 300;
          conta2.movimentacoesRealizadas = new Movimentacao[10];


             //realizando operações com a conta 1
          conta1.Extrato();

          conta1.EmitirSaldo();

          conta1.Depositar(15);

          conta1.EmitirSaldo();

          //Saque inválido
          conta1.Sacar(18000);

          //Saque válido
          conta1.Sacar(15);

          conta1.Extrato();

          //realizando operações com a conta 2
          conta2.Extrato();

          conta2.EmitirSaldo();

          conta2.Depositar(15);

          conta2.EmitirSaldo();

          //Saque inválido
          conta2.Sacar(18000);

          //Saque válido
          conta2.Sacar(15);

          conta2.Extrato();

            //realizando operações transfer~encias entre as contas
            Console.WriteLine("\n=============================================================================================\n");


         //valor excedido
         conta1.transferir(conta2, 15000);
        
         //valor válido
        conta1.transferir(conta2, 15);
        
         //Vendo a transferência na perspectiva da conta1
         conta1.Extrato();
        
         //Vendo a transferência na perspectiva da conta2
         conta2.Extrato();
        
         //valor excedido
         conta2.transferir(conta1, 115000);
        
         //valor válido
         conta2.transferir(conta1,15);
        
         //Vendo a transferência na perspectiva da conta2
         conta2.Extrato();
         conta2.EmitirSaldo();
         //Vendo a transferência na perspectiva da conta1
         conta1.Extrato();
         conta1.EmitirSaldo();

        }
    }
}
