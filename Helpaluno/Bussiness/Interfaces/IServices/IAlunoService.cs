using Helpaluno.Bussiness.DTOs;
using Helpaluno.Bussiness.Entities;

namespace Helpaluno.Bussiness.Interfaces.IServices
{
    public interface IAlunoService
    {
        public List<Aluno> PegarTodosAlunos();
        public Aluno PegarDadosAluno(int id);
        public void CadastrarAluno(AlunoDto aluno);
        public void RemoverAluno(int id);
        public void EditarDadosAluno(int id, AlunoDto aluno);
        public void EditarNome(int id, string primeiroNome);
        public void EditarSobrenome(int id, string? sobrenome);
        public void EditarDataNascimento(int id, DateTime dataNasc);

    }
}
