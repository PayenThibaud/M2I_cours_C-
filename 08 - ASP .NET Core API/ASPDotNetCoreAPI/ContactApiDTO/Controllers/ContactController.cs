using AutoMapper;
using ContactApiDTO.DTOs;
using ContactApiDTO.Models;
using ContactApiDTO.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactApiDTO.Controllers
{
    //[Route("api/[controller]")]
    [Route("contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public ContactController(IRepository<Contact> repository,
                                 IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET /contacts
        [HttpGet]
        public IActionResult GetAll()
        {
            //return Ok(_repository.GetAll());
            IEnumerable<Contact> contacts = _repository.GetAll();

            IEnumerable<ContactDTO> contactDTOs = _mapper.Map<IEnumerable<ContactDTO>>(contacts)!;
            //IEnumerable<ContactDTO> contactDTOs = _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactDTO>>(contacts)!;

            // possible d'ajouter des modification par rapport aux DTOs ici

            return Ok(contactDTOs);
        }

        //GET /contacts/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _repository.Get(id);

            if (contact == null)
                return NotFound(new
                {
                    Message = "There is no Contact with this Id."
                });

            ContactDTO contactDTO = _mapper.Map<ContactDTO>(contact)!;

            return Ok(new
            {
                Message = "Contact found.",
                Contact = contactDTO
            });
        }

        //POST /contacts
        [HttpPost]
        public IActionResult Post([FromBody] ContactDTO contactDTO)
        {
            var contact = _mapper.Map<Contact>(contactDTO)!;

            var contactAdded = _repository.Add(contact);

            var contactAddedDTO = _mapper.Map<ContactDTO>(contactAdded)!;

            if (contactAdded != null)
                return CreatedAtAction(nameof(GetById), 
                                       new { id = contactAddedDTO.Id },
                                       new
                                       {
                                            Message = "Contact Added.",
                                            Contact = contactAddedDTO
                                       });

            return BadRequest("Something went wrong...");
        }

        //PUT /contacts/4
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody] ContactDTO contactDTO)
        {
            var contactFromDb = _repository.Get(id);

            if (contactFromDb == null)
                return NotFound("There is no Contact with this Id.");

            contactDTO.Id = id; // nécessaire dans le cas où l'id n'est pas ou mal définit dan la requete

            var contact = _mapper.Map<Contact>(contactDTO)!;

            var contactUpdated = _repository.Update(contact);

            var contactUpdatedDTO = _mapper.Map<ContactDTO>(contactUpdated);

            if (contactUpdated != null)
                return Ok(new
                {
                    Message = "Contact Updated.",
                    Contact = contactUpdatedDTO
                });

            return BadRequest("Something went wrong...");
        }


        //DELETE /contacts/12
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.Delete(id))
                return Ok("Contect Deleted");

            //return NotFound("Contact Not Found");
            return BadRequest("Something went wrong...");
        }


        //GET /contacts
        [HttpGet("fullnames")]
        public IActionResult GetAllFullNames()
        {
            IEnumerable<Contact> contacts = _repository.GetAll();

            IEnumerable<ContactDTO> contactDTOs = _mapper.Map<IEnumerable<ContactDTO>>(contacts)!;

            IEnumerable<ContactFullNameDTO> fullnames = _mapper.Map<IEnumerable<ContactFullNameDTO>>(contactDTOs)!;

            return Ok(fullnames);
        }
    }
}
