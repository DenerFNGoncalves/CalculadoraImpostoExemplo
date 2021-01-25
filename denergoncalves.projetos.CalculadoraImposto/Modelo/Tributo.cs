using System;
using System.Collections.Generic;
using System.Text;

namespace denergoncalves.projetos.CaluladoraImposto.Modelo
{
    public class Tributo
    {
        public string Descricao { get; set; }

        public decimal Porcentagem { get; set; }

        public decimal Valor { get; set; }


        public Tributo(string descricao, decimal porcentagem)
        {
            Descricao = descricao;
            Porcentagem = porcentagem;
        }
    }
}
