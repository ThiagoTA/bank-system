using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas
{
    class Cliente
    {
        public string Nome { get; private set; }

        public string Email { get; set; }

        public int AnoNascimento { get; private set; }

        public string Cpf { get; private set; }

        public Cliente(string nome, int anoNascimento, string email ,string cpf)
        {
            if (Int32.Parse(DateTime.Now.ToString("yyyy")) - anoNascimento < 18)
                throw new System.ArgumentException("\n\n-ERRO: O cliente deve ter mais de 18 anos!-");
            if (cpf.Length != 11)
                throw new System.ArgumentException("\n\n-ERRO:O CPF deve possuir 11 dígitos!-");
            Nome = nome;
            AnoNascimento = anoNascimento;
            Cpf = cpf;
            Email = email;

        }

    }
}
