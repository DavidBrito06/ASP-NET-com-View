namespace br.com.alert.test
{
    namespace Fiap.Web.Alunos.Tests
    {
        public class UnitTest1
        {
            [Fact]
            public void VerificaMaioridade_DeveRetornarTrueSeMaiorDeIdade()
            {
                // Arrange
                var dataNascimento = new DateTime(2000, 1, 1); // Uma pessoa nascida em 01/01/2000
                var hoje = DateTime.Now;
                var maioridade = hoje.Year - dataNascimento.Year;
                if (dataNascimento > hoje.AddYears(-maioridade)) maioridade--;
                // Act
                var ehMaiorDeIdade = maioridade >= 18;
                // Assert
                Assert.True(ehMaiorDeIdade);
            }
        }
    }

}
}