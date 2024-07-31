using Demo01.Data;
using Demo01.Models;
using Demo01.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrepeController : ControllerBase
    {
        // AVEC FAKEDB
        #region FAKEDB
        //private readonly CrepeFakeDb _fakeDb;

        //public CrepesController(CrepeFakeDb fakeDb)
        //{
        //    _fakeDb = fakeDb;
        //}

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var crepes = _fakeDb.Crepes;

        //    if (crepes.Any()) // la liste est-elle non vide
        //        return Ok(crepes); // statuscode 200

        //    //return NotFound(); // 404 => implique que le fait de ne pas trouver de crêpes soit une erreur
        //    return NoContent(); // 204 => implique que le fait de ne pas trouver de crêpes soit une réussite
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var crepe = _fakeDb.Crepes.FirstOrDefault(c => c.Id == id);

        //    if (crepe == null)
        //        return NotFound(new
        //        {
        //            Message = "Crepe non trouvée !"
        //        });

        //    return Ok(new
        //    {
        //        Message = "Crepe trouvée !",
        //        Crepe = crepe
        //    });
        //}

        //[HttpPost]
        //public IActionResult Post([FromBody]Crepe crepe)
        ////public IActionResult Post([FromForm]Crepe crepe) // si formulaire
        //{
        //    _fakeDb.Crepes.Add(crepe);

        //    //return Ok("Crepe ajoutée");
        //    return CreatedAtAction(nameof(GetById), new { id = crepe.Id }, "Crepe ajoutée"); // meilleure version à utiliser de préférence
        //    //return Created($"api/Crepe/{crepe.Id}", "Crepe ajoutée");

        //    // dans le cas ou l'ajout aura échoué, il convient de retourner un BadRequest() => 400
        //}
        #endregion

        // AVEC EFCore + REPOSITORY
        private readonly IRepository<Crepe> _repository;

        public CrepeController(IRepository<Crepe> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var crepe = _repository.GetById(id);

            if (crepe == null)
                return NotFound(new
                {
                    Message = "There is no Crepe with this Id."
                });

            return Ok(new
            {
                Message = "Crepe found.",
                Crepe = crepe
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Crepe crepe)
        {
            int createdAtId = _repository.Add(crepe);
            if (createdAtId > 0)
                return CreatedAtAction(nameof(GetById), new { id = createdAtId }, "Crepe Added !");
            return BadRequest("Something went wrong...");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Crepe crepe)
        {
            var crepeFromDb = _repository.GetById(id);

            if (crepeFromDb == null)
                return NotFound("There is no Crepe with this Id.");

            crepe.Id = id;

            if (_repository.Update(crepe))
                return Ok("Crepe Updated.");

            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.Delete(id))
                return Ok("Crepe Deleted");
            return NotFound("Crepe Not Found");
        }
    }
}
