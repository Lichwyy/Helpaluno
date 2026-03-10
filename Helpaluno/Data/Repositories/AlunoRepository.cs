using Helpaluno.Bussiness.Entities;
using Helpaluno.Bussiness.Interfaces.IRepositories;
using Helpaluno.Data.Contexts;

namespace Helpaluno.Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {

        private readonly AppSettingsDbContext _context;
        public AlunoRepository(AppSettingsDbContext context)
        { 
            _context = context;
        }

        public void Criar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        public void Deletar(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
        }

        public void Editar(Aluno alunoExistente, Aluno alunoEditado)
        {
            alunoExistente.PrimeiroNome = alunoEditado.PrimeiroNome;
            alunoExistente.Sobrenome = alunoEditado.Sobrenome;
            alunoExistente.DataNascimento = alunoEditado.DataNascimento;
            _context.SaveChanges();
        }

        public Aluno? EncontrarAlunoPorId(Guid id)
        {
            Aluno? Aluno = _context.Alunos.FirstOrDefault(aluno => aluno.Id == id);
            return Aluno;
            
        }

        public List<Aluno> EncontrarTodosAlunos()
        {
            List<Aluno> Alunos = _context.Alunos.ToList();
            return Alunos;
        }

        public List<string> EncontrarTodosEmails()
        {
            List<string> TodosEmails = _context.Alunos.Select(aluno => aluno.Email).ToList();
            return TodosEmails;
        }
    }
}
