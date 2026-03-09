using Helpaluno.Bussiness.Entities;

namespace Helpaluno.Bussiness.Interfaces.IRepositories
{
    public interface IAlunoRepository
    {
        public Aluno? EncontrarAlunoPorId(Guid id);
        public List<Aluno> EncontrarTodosAlunos();
        public void Editar(Aluno alunoExistente, Aluno alunoEditado);
        public void Criar(Aluno aluno);
        public void Deletar(Aluno aluno);
    }
}
