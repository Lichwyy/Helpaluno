using Helpaluno.Bussiness.DTOs;
using Helpaluno.Bussiness.Entities;
using Helpaluno.Bussiness.Interfaces.IServices;
using Helpaluno.Bussiness.Interfaces.IRepositories;

namespace Helpaluno.Bussiness.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public void CadastrarAluno(AlunoDto aluno)
        {
            Aluno Aluno = ConverterDtoAluno(aluno);
            _alunoRepository.Criar(Aluno);
        }

        public void EditarDadosAluno(Guid id, AlunoDto aluno)
        {
            ValidarId(id);
            Aluno AlunoExistente = _alunoRepository.EncontrarAlunoPorId(id);
            ValidarAlunoExistente(AlunoExistente);

            Aluno AlunoEditado = ConverterDtoAluno(aluno);
            
            _alunoRepository.Editar(AlunoExistente, AlunoEditado);
        }
        public void EditarDataNascimento(Guid id, DateTime dataNasc)
        {

            ValidarId(id);
            ValidarData(dataNasc);

            Aluno AlunoExistente = _alunoRepository.EncontrarAlunoPorId(id);
            ValidarAlunoExistente(AlunoExistente);
            Aluno AlunoEditado = AlunoExistente;
            AlunoEditado.DataNascimento = dataNasc;
            _alunoRepository.Editar(AlunoExistente, AlunoEditado);
        }

        public void EditarNome(Guid id, string primeiroNome)
        {
            ValidarId(id);
            ValidarStringNulo(primeiroNome, "Primeiro Nome");
            ValidarTamanhoTexto(primeiroNome);

            Aluno AlunoExistente = _alunoRepository.EncontrarAlunoPorId(id);
            ValidarAlunoExistente(AlunoExistente);
            Aluno AlunoEditado = AlunoExistente;
            AlunoEditado.PrimeiroNome= primeiroNome;
            _alunoRepository.Editar(AlunoExistente, AlunoEditado);


        }

        public void EditarSobrenome(Guid id, string? sobrenome)
        {

            ValidarId(id);
            ValidarTamanhoTexto(sobrenome);
            Aluno AlunoExistente = _alunoRepository.EncontrarAlunoPorId(id);
            ValidarAlunoExistente(AlunoExistente);
            Aluno AlunoEditado = AlunoExistente;
            AlunoEditado.Sobrenome= sobrenome;
            _alunoRepository.Editar(AlunoExistente, AlunoEditado);


        }

        public Aluno PegarDadosAluno(Guid id)
        {
            try
            {
                ValidarId(id);
                Aluno Aluno = _alunoRepository.EncontrarAlunoPorId(id);
                ValidarAlunoExistente(Aluno);

                return Aluno;
            }
            catch (Exception e) {
                throw new Exception(e.Message, e);
            }
        }

        public List<Aluno> PegarTodosAlunos()
        {
            List<Aluno> Alunos = _alunoRepository.EncontrarTodosAlunos();
            return Alunos;
        }

        public void RemoverAluno(Guid id)
        {
            ValidarId(id);
            Aluno aluno = _alunoRepository.EncontrarAlunoPorId(id);
            ValidarAlunoExistente(aluno);
            _alunoRepository.Deletar(aluno);
        }
        private void ValidarId(Guid id)
        {
            if (id == Guid.Empty)
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

        private Aluno ConverterDtoAluno(AlunoDto alunoDto)
        {

            ValidarStringNulo(alunoDto.PrimeiroNome, "Primeiro Nome");
            ValidarTamanhoTexto(alunoDto.PrimeiroNome);
            ValidarTamanhoTexto(alunoDto.Sobrenome);
            ValidarData(alunoDto.DataNascimento);
            Aluno aluno = new Aluno();
            aluno.PrimeiroNome = alunoDto.PrimeiroNome;
            aluno.Sobrenome = alunoDto.Sobrenome;
            aluno.Email = alunoDto.Email;
            aluno.DataNascimento = alunoDto.DataNascimento;
            return aluno;

        }
        private void ValidarTamanhoTexto(string texto)
        {
            if (texto.Length > 50)
            {
                throw new Exception("O texto não pode possuir mais do que 50 caracteres");
            }
        }
        private void ValidarAlunoExistente(Aluno aluno)
        {
            if (aluno == null)
            {
                throw new Exception("Aluno não encontrado");
            }
        }
    }
}
