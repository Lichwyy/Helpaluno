using Helpaluno.Bussiness.DTOs;
using Helpaluno.Bussiness.Entities;
using Helpaluno.Bussiness.Interfaces.IServices;
using Helpaluno.Bussiness.Interfaces.IRepositories;

namespace Helpaluno.Bussiness.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoService(IAlunoRepository alunoRepository) {
            _alunoRepository = alunoRepository;
        }

        public void CadastrarAluno(AlunoDto aluno)
        {
            throw new NotImplementedException();
        }

        public void EditarDadosAluno(int id, AlunoDto aluno)
        {
            throw new NotImplementedException();
        }

        public void EditarDataNascimento(int id, DateTime dataNasc)
        {
            try
            {
                ValidarId(id);
                ValidarData(dataNasc);

                Aluno alunoEditado = _alunoRepository.EncontrarAlunoPorId(id);
                alunoEditado.DataNascimento = dataNasc;
                _alunoRepository.Editar(id, alunoEditado);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void EditarNome(int id, string primeiroNome)
        {
            try
            {
                ValidarId(id);
                ValidarStringNulo(primeiroNome, "Primeiro Nome");
                if (primeiroNome.Length > 50)
                {
                    throw new Exception("O primeiro nome não pode possuir mais do que 50 caracteres");
                }

                Aluno alunoEditado = _alunoRepository.EncontrarAlunoPorId(id);
                alunoEditado.PrimeiroNome= primeiroNome;
                _alunoRepository.Editar(id, alunoEditado);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void EditarSobrenome(int id, string? sobrenome)
        {
            try
            {
                ValidarId(id);
                if (sobrenome?.Length > 50)
                {
                    throw new Exception("O sobrenome não pode possuir mais do que 50 caracteres");
                    
                }
                Aluno alunoEditado = _alunoRepository.EncontrarAlunoPorId(id);
                alunoEditado.Sobrenome = sobrenome;
                _alunoRepository.Editar(id, alunoEditado);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Aluno PegarDadosAluno(int id)
        {
            try
            {
                ValidarId(id);
                Aluno Aluno = _alunoRepository.EncontrarAlunoPorId(id);
                return Aluno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Aluno> PegarTodosAlunos()
        {
            try
            {
                List<Aluno> Alunos = _alunoRepository.EncontrarTodosAlunos();
                return Alunos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void RemoverAluno(int id)
        {
            ValidarId(id);
            throw new NotImplementedException();
        }
        private void ValidarId(int id)
        {
            if (id >= 0)
            {
                throw new Exception("Digite um id válido");
            }
        }
        private void ValidarStringNulo(string valor, string indice)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new Exception($"{indice} não pode ser nulo");
            }
        }
        
        private void ValidarData(DateTime data)
        {   
            DateTime DataAtual = DateTime.Now;
            DateTime DataLimite = DataAtual.AddYears(-130);

            if (data > DataAtual)
            {
                throw new Exception("Não é possível registrar uma data futura");
            }
            if (data < DataLimite)
            {
                throw new Exception("Você não tem mais do que 130 anos, stop the cap");
            }
        }
    }
}
