using MODEL;

namespace TESTEUNITARIO
{
    public class Tests
    {
        private ClientePJ cliente = new ClientePJ();

        [Test]
        public void ValidarCampoNome()
        {
            //Arrange
            //Parametro aceitável maior que 5 e menor que 45 caracteres
            string nome = "Diogo Aparecido de Godoi ME";
            bool resultadoExperado = true;

            //Act
            bool validarNome = cliente.SetNome(nome); 

            //Assert
            Assert.That(validarNome, Is.EqualTo(resultadoExperado));
        }
        [Test]
        public void InvalidarCampoNome()
        {
            //Arrange
            Cliente cliente = new Cliente();
            bool resultadoExperado = false;
            //Parametro inválido maior que 45 caracteres
            string nome = "OKPOAKPAOKDPAKPOAKDPOKAPOKDPSOAKDPOAKDPOKDPOKWADOPKAWPDO";

            //Act
            bool validarNome = cliente.SetNome(nome); 

            if (validarNome == false)
            {
                //Parametro menor que 6 caracteres
                validarNome = cliente.SetNome("Diogo");
            }

            //Assert
            Assert.That(validarNome, Is.EqualTo(resultadoExperado));
        }
        [Test]
        public void ValidarCampoCnpj()
        {
            //Arrange
            //Parametro aceitável 
            string cnpj = "12321145000102";
            bool resultadoExperado = true;
            //Act
            bool validarCpj = cliente.SetCnpj(cnpj);

            //Assert
            Assert.That(validarCpj, Is.EqualTo(resultadoExperado));
        }
        [Test]
        public void InvalidarCampoCnpj()
        {
            //Arrange
            //Parametro inválido, maior que 14 caracteres
            string strCnpj = "1233211123321568";
            bool resultadoExperado = false;

            //Act
            bool validarCpj = cliente.SetCnpj(strCnpj);
            if(validarCpj == false)
            {
            //Parametro inválido, menor que 14 caracteres
                validarCpj = cliente.SetCnpj("0");
            }

            //Assert
            Assert.That(validarCpj, Is.EqualTo(resultadoExperado));
        }
    }
}
