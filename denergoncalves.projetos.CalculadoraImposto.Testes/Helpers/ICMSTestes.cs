using denergoncalves.projetos.CaluladoraImposto;
using NUnit.Framework;
using System;

namespace denergoncalves.projetos.CalculadoraImposto.Testes.Helpers
{
    [TestFixture]
    public class ICMSTestes
    {
        [TestCase(120, -1)]
        [TestCase(230, -0.1)]
        [TestCase(0.24, -81)]
        public void AdicionarICMS_ValorQualquerICMSMenorZero_LancaErro(decimal valor, decimal icms)
        {
            Assert.Throws<ArgumentException>(() => ICMSHelper.AdicionarICMS(valor, icms));
        }

        [TestCase(0, 1)]
        [TestCase(78, 1.45)]
        [TestCase(-0, 100)]
        public void AdicionarICMS_ValorQualquerICMSMaiorIgualUm_LancaErro(decimal valor, decimal icms)
        {
            Assert.Throws<ArgumentException>(() => ICMSHelper.AdicionarICMS(valor, icms));
        }

        [TestCase(0, 0.1)]
        [TestCase(0, 0.25)]
        public void AdicionarICMS_ValorZeroICMSOk_RetornaZero(decimal valor, decimal icms)
        {
            decimal esperado = 0;
            Assert.AreEqual(esperado, ICMSHelper.AdicionarICMS(valor, icms));
        }


        [TestCase(210, 0)]
        [TestCase(88, 0)]
        [TestCase(-785, 0)]
        public void AdicionarICMS_ValorQualquerICMSZero_RetornaValor(decimal valor, decimal icms)
        {
            decimal esperado = valor;
            Assert.AreEqual(esperado, ICMSHelper.AdicionarICMS(valor, icms));
        }


        [TestCase(-280, 0.30, -400)]
        [TestCase(-75, 0.25, -100)]
        [TestCase(-160, 0.20, -200)]
        public void AdicionarICMS_ValorNegativoICMSOk_RetornaValorNegativoComICMS(decimal valor, decimal icms, decimal esperado)
        {
            Assert.AreEqual(esperado, ICMSHelper.AdicionarICMS(valor, icms));
        }


        [TestCase(280, 0.30, 400)]
        [TestCase(85, 0.15,  100)]
        [TestCase(1760, 0.50, 3520)]
        public void AdicionarICMS_ValorPositivoICMSOk_RetornaValorComICMS(decimal valor, decimal icms, decimal esperado)
        {
            Assert.AreEqual(esperado, ICMSHelper.AdicionarICMS(valor, icms));
        }
    }
}
