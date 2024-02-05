using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Medify.Models;
using Medify.Resources;
using Medify.Repositories.Base;

namespace Medify.Controllers;

public class DoctorController : BaseController
{
    private readonly IRepository repository;
        public DoctorController(IRepository repository){
            this.repository = repository;
        }   
        
        [HttpGet]
        public IActionResult GetDoctors(){
            var doctors = repository.GetDoctors();
            if(doctors is null){
                return NotFound("Nothing Found");
            }
            return View(doctors);
        }
        [HttpGet]
        public IActionResult GetDoctorById(int id){
            var doctor = repository.GetDoctorById(id);
            if(doctor is null){
                return NotFound($"Doctor ({id}) not found");
            }
            return View(doctor);
        }
        [HttpGet]
        public IActionResult GetDoctorByName(string name){
            var doctor = repository.GetDoctorByName(name);
            if(doctor is null){
                return NotFound($"({name}) not found");
            }
            return View(doctor);
        }
        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor){
            var count = medRepository.AddDoctor(doctor);
            if(count == 0)
                return StatusCode(505);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteDoctor(int id){
            var count = repository.DeleteDoctor(id);
            if(count==0)
                return NotFound();
            return Ok();
        }
}
