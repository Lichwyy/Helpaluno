using Microsoft.AspNetCore.Mvc;
using Helpaluno.Bussiness.Interfaces.IServices;
using Helpaluno.Bussiness.Entities;
using Helpaluno.Bussiness.DTOs;

namespace Helpaluno.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Student : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public Student(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public IActionResult PegarDadosAlunos()
        {
            try
            {
                List<Aluno> Alunos = _alunoService.PegarTodosAlunos();
                return Ok(Alunos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public IActionResult PegarDadosAluno(int id) {
            try {
                Aluno Aluno = _alunoService.PegarDadosAluno(id);
                return Ok(Aluno);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CadastrarAluno(AlunoDto aluno)
        {
            try
            {
                _alunoService.CadastrarAluno(aluno);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]
        public IActionResult RemoverAluno(int id)
        {
            try
            {
                _alunoService.RemoverAluno(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("id")]
        public IActionResult EditarDadosAluno(int id, AlunoDto aluno)
        {
            try
            {
                _alunoService.EditarDadosAluno(id, aluno);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("nome/id")]
        public IActionResult EditarNome(int id, string primeiroNome)
        {
            try
            {
                _alunoService.EditarNome(id, primeiroNome);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("sobrenome/id")]
        public IActionResult EditarSobrenome(int id, string? sobrenome)
        {
            try
            {
                _alunoService.EditarSobrenome(id, sobrenome);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("nascimento/id")]
        public IActionResult EditarDataNascimento(int id, DateTime dataNasc)
        {
            try
            {
                _alunoService.EditarDataNascimento(id, dataNasc);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
