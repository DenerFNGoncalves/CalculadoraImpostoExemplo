using denergoncalves.projetos.CaluladoraImposto.Controle;
using denergoncalves.projetos.CaluladoraImposto.Modelo;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace denergoncalves.projetos.CalculadoraImposto.Testes.Controllers
{
    [TestFixture]
    public class ControleProdutoTeste
    {
        public ControleProduto ControleProduto { get; set; }

        [SetUp]
        public void Setup()
        {
            ControleProduto = new ControleProduto();
        }

        [Test]
        public void AdicionarTributoNuloProduto_LancaExcecao()
        {
            var produto = new Produto(codigo: "0001", "Caneta esferográfica preta", 0.70m);
            Assert.Throws<ArgumentException>(() => { ControleProduto.AdicionaTributo(produto, null); });
        }

        [Test]
        public void AdicionarTributoProdutoNulo_LancaExcecao()
        {
            var tributo = new Tributo(descricao: "IOF", porcentagem: 0.06m);
            Assert.Throws<ArgumentException>(() => { ControleProduto.AdicionaTributo(null, tributo); });
        }


        [Test]
        public void AdicionarTributoProduto_IniciaListaTributosSeNulo()
        {
            var produto = new Produto(codigo: "0001", "Caneta esferográfica preta", 0.70m);
            var tributo = new Tributo(descricao: "IOF", porcentagem: 0.06m);
            produto.Tributos = null;

            ControleProduto.AdicionaTributo(produto, tributo);
            Assert.Contains(tributo, produto.Tributos);
        }

        [Test]
        public void AdicionarTributoProduto_ConfirmaAdicaoTributo()
        {
            var produto = new Produto(codigo: "0001", "Caneta esferográfica preta", 0.70m);
            var tributo = new Tributo(descricao: "IOF", porcentagem: 0.06m);

            ControleProduto.AdicionaTributo(produto, tributo);
            Assert.Contains(tributo, produto.Tributos);
        }


        [TestCase(240.99d, 0.06d, 14.46d)]
        [TestCase(399.99d, 0.07d, 28d)]
        [TestCase(1259.99d, 0.09d, 113.4d)]
        public void AtribuiValorTributoProduto_ConfirmaValor(decimal valor, decimal percTributo, decimal esperado)
        {
            var produto = new Produto(codigo: "0001", descricao: "Drone Eachine E58 Com Câmera", valor);
            var tributo = new Tributo(descricao: "IOF", porcentagem: percTributo);

            ControleProduto.AdicionaTributo(produto, tributo);
            Assert.AreEqual(esperado, tributo.Valor);
        }


        [Test]
        public void AtualizaTributoProdutoSeExistir_ConfirmaAtualizacaoTributo()
        {
            var produto = new Produto(codigo: "0001", "Caneta esferográfica preta", 0.70m);
            var tributo = new Tributo(descricao: "IOF", porcentagem: 0.06m);
            var tributoB = new Tributo(descricao: "IOF", porcentagem: 0.10m);

            ControleProduto.AdicionaTributo(produto, tributo);
            CollectionAssert.Contains(produto.Tributos, tributo);

            ControleProduto.AdicionaTributo(produto, tributoB);

            tributo = ControleProduto.ObtemTributoPorDescricao(produto, "IOF");
            Assert.AreEqual(tributoB.Porcentagem, tributo.Porcentagem);
        }

        [Test]       
        public void RemoveTributoExistente_ConfirmaOperacao()
        {
            var produto = new Produto(codigo: "0001", "Caneta esferográfica preta", 0.70m);
            var tributo = new Tributo(descricao: "IOF", porcentagem: 0.06m); 

            ControleProduto.AdicionaTributo(produto, tributo);
            CollectionAssert.Contains(produto.Tributos, tributo);

            tributo = ControleProduto.RemoveTributo(produto, "IOF");
            CollectionAssert.DoesNotContain(produto.Tributos, tributo);
        }

        [Test]
        public void RemoveTributoInexistente_ConfirmaOperacao()
        {
            var produto = new Produto(codigo: "0001", "Caneta esferográfica preta", 0.70m);              

            var tributo = ControleProduto.RemoveTributo(produto, "IOF");
            CollectionAssert.DoesNotContain(produto.Tributos, tributo);
        }

    }
}
