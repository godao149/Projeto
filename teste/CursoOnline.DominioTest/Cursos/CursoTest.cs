using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
using ExpectedObjects;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;
using Curso = CursoOnline.Dominio.Cursos.Curso;

namespace CursoOnline.DominioTest.Cursos 
{
    public class CursoTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly Dominio.Cursos.PublicoAlvo _pubblicoAlvo;
        private readonly double _valor;
        private readonly string _descricao;

        public CursoTest(ITestOutputHelper output)
        {
            var faker = new Faker();
            _output = output;
            _output.WriteLine("Construtor sendo executado");

            _nome = faker.Random.Word();
            _cargaHoraria = faker.Random.Double(50, 1000);
            _pubblicoAlvo = Dominio.Cursos.PublicoAlvo.Estudante;
            _valor = faker.Random.Double(100, 1000);
            _descricao = faker.Lorem.Paragraph();

        
        }

        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executado");
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria =(double) 80,
                PublicoAlvo = Dominio.Cursos.PublicoAlvo.Estudante,
                Valor = (double)950,
                Descricao = _descricao 
            };
            
           

            var curso = new Curso(cursoEsperado.Nome,cursoEsperado.CargaHoraria,cursoEsperado.PublicoAlvo,cursoEsperado.Valor,_descricao);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
           
             Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComNome(nomeInvalido).Build()).ComMensagem("Nome Inválido");
            
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
           Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build()).ComMensagem("Carga horária inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaUmValorMenorQue1(double valorInvalido)
        {
           
             Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComValor(valorInvalido).Build()).ComMensagem("Valor Inválido");
         
        }


        [Fact]
        public void NaoDeveCursoTerUmNomeNulo()
        {
           
            
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = (double)80,
                PublicoAlvo = Dominio.Cursos.PublicoAlvo.Estudante,
                Valor = (double)950
            };

            Assert.Throws<ArgumentException>(() => new Curso(null, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo,
                cursoEsperado.Valor,_descricao));
        }

       
    }
}
