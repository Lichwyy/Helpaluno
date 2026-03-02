using Helpaluno.Bussiness.Entities;

namespace Helpaluno.Bussiness.Interfaces.IRepositories
{
    public interface IAlunoRepository
    {
        public Aluno EncontrarAlunoPorId(int id);
        public List<Aluno> EncontrarTodosAlunos();
        public void Editar(int id, Aluno aluno);
        public void Criar(Aluno aluno);
        public void Deletar(int id);
    }
}
