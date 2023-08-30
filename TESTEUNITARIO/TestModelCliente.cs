using API_EXTERNAS;
using MODEL;

namespace TESTEUNITARIO
{
    public class Tests
    {
        // Inst�ncia do ClientePJ que ser� utilizada nos testes
        private ClientePJ cliente = new ClientePJ();
        // Inst�ncia do ModelApiReceita que ser� utilizada nos testes
        private ModelApiReceita dadosApi = new ModelApiReceita();

        // Teste para validar campo de nome
        [Test]
        public void ValidarCampoNome()
        {
            // Arrange
            // Par�metro aceit�vel: maior que 5 e menor que 45 caracteres
            string nome = "Diogo Aparecido de Godoi ME";
            bool resultadoExperado = true;

            // Act
            bool validarNome = cliente.SetNome(nome);

            // Assert
            Assert.That(validarNome, Is.EqualTo(resultadoExperado));
        }

        // Teste para invalidar campo de nome
        [Test]
        public void InvalidarCampoNome()
        {
            // Arrange
            bool resultadoExperado = false;
            // Par�metro inv�lido: maior que 45 caracteres
            string nome = "OKPOAKPAOKDPAKPOAKDPOKAPOKDPSOAKDPOAKDPOKDPOKWADOPKAWPDO";

            // Act
            bool validarNome = cliente.SetNome(nome);

            if (validarNome == false)
            {
                // Par�metro menor que 6 caracteres
                validarNome = cliente.SetNome("Diogo");
            }

            // Assert
            Assert.That(validarNome, Is.EqualTo(resultadoExperado));
        }

        // Teste para validar campo de CNPJ
        [Test]
        public void ValidarCampoCnpj()
        {
            // Arrange
            // Par�metro aceit�vel
            string cnpj = "12321145000102";
            bool resultadoExperado = true;

            // Act
            bool validarCpj = cliente.SetCnpj(cnpj);

            // Assert
            Assert.That(validarCpj, Is.EqualTo(resultadoExperado));
        }

        // Teste para invalidar campo de CNPJ
        [Test]
        public void InvalidarCampoCnpj()
        {
            // Arrange
            // Par�metro inv�lido: maior que 14 caracteres
            string strCnpj = "1233211123321568";
            bool resultadoExperado = false;

            // Act
            bool validarCpj = cliente.SetCnpj(strCnpj);
            if (validarCpj == false)
            {
                // Par�metro inv�lido: menor que 14 caracteres
                validarCpj = cliente.SetCnpj("0");
            }

            // Assert
            Assert.That(validarCpj, Is.EqualTo(resultadoExperado));
        }

        [Test]
        // Teste para validar campo de telefone
        public void ValidarCampoTelefone()
        {
            // Arrange
            // Par�metro aceit�vel: deve ter mais de 5 e menos de 45 caracteres
            string telefone = "19997590581";
            bool resultadoExperado = true;

            // Act
            bool validarNome = cliente.SetTelefone(telefone);

            // Assert
            Assert.That(validarNome, Is.EqualTo(resultadoExperado));
        }

        [Test]
        // Teste para invalidar campo de telefone
        public void InvalidarCampoTelefone()
        {
            // Arrange
            bool resultadoExperado = false;
            // Par�metro inv�lido: tem mais de 18 caracteres
            string telefone = "199877895987459878989";

            // Act
            bool validarNome = cliente.SetTelefone(telefone);

            if (validarNome == false)
            {
                // Par�metro com menos de 10 caracteres
                telefone = "19987";
                validarNome = cliente.SetTelefone(telefone);
            }

            // Assert
            Assert.That(validarNome, Is.EqualTo(resultadoExperado));
        }

        [Test]
        // Teste para validar campo de logradouro
        public void ValidarCampoLogradouro()
        {
            // Arrange
            // Par�metro aceit�vel
            string logradouro = "Rua Bento Gon�alves";
            bool resultadoExperado = true;

            // Act
            bool validarCpj = cliente.SetLogradouro(logradouro);

            // Assert
            Assert.That(validarCpj, Is.EqualTo(resultadoExperado));
        }

        [Test]
        // Teste para invalidar campo de logradouro
        public void InvalidarCampoLogradouro()
        {
            // Arrange
            // Par�metro inv�lido: tem mais de 45 caracteres
            string logradouro = "Rua XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            bool resultadoExperado = false;

            // Act
            bool validarCpj = cliente.SetLogradouro(logradouro);
            if (validarCpj == false)
            {
                logradouro = "Rua";
                // Par�metro inv�lido: tem menos de 5 caracteres
                validarCpj = cliente.SetLogradouro(logradouro);
            }

            // Assert
            Assert.That(validarCpj, Is.EqualTo(resultadoExperado));
        }

        [Test]
        // Teste para validar campo de numero
        public void ValidarCampoNumero()
        {
            // Arrange
            // Par�metro aceit�vel: deve ter mais de 5 e menos de 45 caracteres
            string numero = "150A";
            bool resultadoExperado = true;

            // Act
            bool validarNome = cliente.SetNumero(numero);

            // Assert
            Assert.That(validarNome, Is.EqualTo(resultadoExperado));
        }

        [Test]
        // Teste para invalidar campo de numero
        public void InvalidarCampoNumero()
        {
            // Arrange
            bool resultadoExperado = false;
            // Par�metro inv�lido: tem mais de 7 caracteres
            string numero = "199877895987459878989";

            // Act
            bool validarNomero = cliente.SetNumero(numero);

            if (validarNomero == false)
            {
                // Par�metro vazio
                numero = "";
                validarNomero = cliente.SetNumero(numero);
            }

            // Assert
            Assert.That(validarNomero, Is.EqualTo(resultadoExperado));
        }

        [Test]
        // Teste para validar campo de bairro
        public void ValidarCampoBairro()
        {
            // Arrange
            // Par�metro aceit�vel
            string bairro = "Jardim S�o Dimas";
            bool resultadoExperado = true;

            // Act
            bool validarCpj = cliente.SetBairro(bairro);

            // Assert
            Assert.That(validarCpj, Is.EqualTo(resultadoExperado));
        }

        [Test]
        // Teste para invalidar campo de bairro
        public void InvalidarCampoBairro()
        {
            // Arrange
            // Par�metro inv�lido: tem mais de 45 caracteres
            string bairro = "Bairro YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY";
            bool resultadoExperado = false;

            // Act
            bool validarCpj = cliente.SetBairro(bairro);
            if (validarCpj == false)
            {
                bairro = "X";
                // Par�metro inv�lido: tem menos de 5 caracteres
                validarCpj = cliente.SetBairro(bairro);
            }

            // Assert
            Assert.That(validarCpj, Is.EqualTo(resultadoExperado));
        }

        [Test]
        // Teste para validar campo de municipio
        public void ValidarCampoMunicipio()
        {
            // Arrange
            // Par�metro aceit�vel: deve ter mais de 5 e menos de 35 caracteres
            string municipio = "Amparo";
            bool resultadoExperado = true;

            // Act
            bool validarNome = cliente.SetMunicipio(municipio);

            // Assert
            Assert.That(validarNome, Is.EqualTo(resultadoExperado));
        }

        [Test]
        // Teste para invalidar campo de municipio
        public void InvalidarCampoMunicipio()
        {
            // Arrange
            bool resultadoExperado = false;
            // Par�metro inv�lido: tem mais de 35 caracteres
            string municipio = "AmparoAmparoAmparoAmparoAmparoAmparoAmparoAmparoAmparoAmparo";

            // Act
            bool validarNome = cliente.SetMunicipio(municipio);

            if (validarNome == false)
            {
                // Par�metro vazio
                municipio = " ";
                validarNome = cliente.SetMunicipio(municipio);
            }

            // Assert
            Assert.That(validarNome, Is.EqualTo(resultadoExperado));
        }

        [Test]
        // Teste para validar campo de uf
        public void ValidarCampoUf()
        {
            // Arrange
            // Par�metro aceit�vel
            string uf = "SP";
            bool resultadoExperado = true;

            // Act
            bool validarCpj = cliente.SetUf(uf);

            // Assert
            Assert.That(validarCpj, Is.EqualTo(resultadoExperado));
        }

        [Test]
        // Teste para invalidar campo de uf
        public void InvalidarCampoUf()
        {
            // Arrange
            // Par�metro inv�lido: tem mais de 2 caracteres
            string uf = "PER";
            bool resultadoExperado = false;

            // Act
            bool validarCpj = cliente.SetUf(uf);
            if (validarCpj == false)
            {
                // Par�metro inv�lido: string vazia
                uf = " ";
                validarCpj = cliente.SetUf(uf);
            }

            // Assert
            Assert.That(validarCpj, Is.EqualTo(resultadoExperado));
        }

        [Test]
        // Teste para configurar dados da API e verificar se s�o obtidos corretamente
        public void SetDadosApi()
        {
            // Arrange
            dadosApi.telefone = "19997590581";
            dadosApi.logradouro = "Avenida Orlando Audrai Barros Bueno";
            dadosApi.numero = "250";
            dadosApi.bairro = "Jardim S�o Dimas";
            dadosApi.municipio = "Amparo";
            dadosApi.uf = "SP";
            cliente.SetDadosAPI(dadosApi);
            var resultadoEsperado = dadosApi;

            // Act
            var resultado = cliente.GetDadosAPI();

            // Assert
            Assert.That(resultado, Is.EqualTo(resultadoEsperado));
        }

        // Teste para obter o nome da empresa
        [Test]
        public void GetNome()
        {
            // Arrange
            string nome = "Metalfor Metalurgia e servi�os";
            cliente.SetNome(nome);
            string resultadoEsperado = "Metalfor Metalurgia e servi�os";

            // Act
            string nomeEmpresa = cliente.GetNome();

            // Assert
            Assert.That(nomeEmpresa, Is.EqualTo(resultadoEsperado));
        }
    }
}
