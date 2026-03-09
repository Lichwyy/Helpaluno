using Helpaluno.Bussiness.DTOs;
using Helpaluno.Bussiness.Entities;

namespace Helpaluno.Bussiness.Interfaces.IServices
{
    public interface IAlunoService
    {
        public List<Aluno> PegarTodosAlunos();
        public Aluno PegarDadosAluno(Guid id);
        public void CadastrarAluno(AlunoDto aluno);
        public void RemoverAluno(Guid id);
        public void EditarDadosAluno(Guid id, AlunoDto aluno);
        public void EditarNome(Guid id, string primeiroNome);
        public void EditarSobrenome(Guid id, string? sobrenome);
        public void EditarDataNascimento(Guid id, DateTime dataNasc);

    }
}
