using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.DominioTest
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "Testar")]
        public void DeveVariavel1SerIgualVariavel2()
        {
            //AAA
            
            //Organização
            var variavel1 = 1;
            var variavel2 = 2;

            //Ação
            variavel2 = variavel1;

            //Assert

            Assert.Equal(variavel1,variavel2);
        }
    }
}
